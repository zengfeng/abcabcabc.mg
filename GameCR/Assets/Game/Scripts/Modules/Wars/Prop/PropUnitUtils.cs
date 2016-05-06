using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games.Module.Props;
using CC.Runtime.signals;
using System;
using CC.Runtime.Utils;


namespace Games.Module.Wars
{
	
	public delegate void PropEventHandler(IPropUnit unit);

	/** 属性实体 */
	public interface IPropUnit
	{
		/** 单位ID */
		int uid{get;}
		/** 清除属性 */
		Action<IPropUnit> sClearProp{get;set;}
		/** 获取属性列表 */
		float[] Props{get;}
		/** 设置属性列表 */
		void SetProps(float[] props);
		/** 获取附加属性列表标记 */
		Dictionary<int, AttachPropData> AttachProps{get;}
	}


	public class AttachPropData
	{
		private static int UID = 100000;
		public int uid;
		public Prop[] props;

		public AttachPropData()
		{
			Construction(0, new Prop[]{});
		}

		
		public AttachPropData(Prop[] props)
		{
			Construction(0, props);
		}

		public AttachPropData(int uid, Prop[] props)
		{
			Construction(uid, props);
		}

		private void Construction(int uid, Prop[] props)
		{
			if(uid <= 0)
			{
				uid = UID++;
			}
			
			this.uid = uid;
			this.props = props;
		}




		public void App(IPropUnit src)
		{
			int addCount = 0;
			foreach(Prop prop in props)
			{
				if(float.IsNaN(prop.value))
				{
					Debug.Log(string.Format("<color=red>AttachPropData App prop.Value=NaN  prop={0}</color>", prop));
				}

				if(prop.type == PropType.Final)
				{
					Debug.Log(string.Format("<color=red>AttachPropData App 附加属性不可以是‘最终类型’ prop={0}</color>", prop));
				}
				
				src.Props[prop.id] += prop.value;
				if(prop.additive == 0)
				{
					addCount ++;
				}
				
				// 如果是状态 且值小于0.就把值设置为0
				if(prop.type == PropType.State && src.Props[prop.id] < 0)
				{
					src.Props[prop.id] = 0;
				}

			}
			
			if(addCount > 0)
			{
				src.AttachProps.Add(uid, this);
			}
		}

		public void Revoke(IPropUnit src)
		{
			foreach(Prop prop in props)
			{
				
				if(float.IsNaN(prop.value))
				{
					Debug.Log(string.Format("<color=red>AttachPropData Revoke  prop.Value=NaN  prop={0}</color>", prop));
				}
				
				if(prop.additive == 0)
				{
					src.Props[prop.id] -= prop.value;
					// 如果是状态 且值小于0.就把值设置为0
					if(prop.type == PropType.State && src.Props[prop.id] < 0)
					{
						src.Props[prop.id] = 0;
					}
				}
			}
			src.AttachProps.Remove(uid);
		}

		public override string ToString ()
		{
			return string.Format ("[AttachPropData uid={0}, props={1}]", uid, props.ToStr());
		}
	}



	/** 属性工具 */
	public static class PropUnitUtils
	{
		/** 属性实体--添加附加 */
		public static void AppProps(this IPropUnit src, AttachPropData attachPropData, bool calculate = false)
		{
			if(attachPropData == null) return;

			if(src.AttachProps.ContainsKey(attachPropData.uid))
			{
				src.RevokeProps(attachPropData.uid);
			}
            //Debug.Log(string.Format("<color=0x33DD55>  attachPropData={0}, calculate={1}</color>", attachPropData, calculate));
			attachPropData.App(src);

			
			if(calculate)
			{
				src.Props.Calculate();
			}
		}

		/** 属性实体--移除附加 */
		public static void RevokeProps(this IPropUnit src, AttachPropData attachPropData, bool calculate = false)
		{
			if(attachPropData == null) return;

			if(src.AttachProps.ContainsKey(attachPropData.uid))
			{
				attachPropData.Revoke(src);
			}
			
			if(calculate)
			{
				src.Props.Calculate();
			}
		}
		
		
		/** 属性实体--移除附加 */
		public static void RevokeProps(this IPropUnit src, int attachPropUid, bool calculate = false)
		{
			AttachPropData attachPropData;
			if(src.AttachProps.TryGetValue(attachPropUid, out attachPropData))
			{
				RevokeProps(src, attachPropData, calculate);
			}
		}

		
		
		/** 属性实体--清空 */
		public static void RevokeAll(this IPropUnit src)
		{
			if(src.sClearProp != null) src.sClearProp(src);
			src.Props.PropClear();
			src.AttachProps.Clear();
		}



		/** 计算属性 (int * (1 + intPer) + add) * (1 + per)  */
		public static void Calculate(this float[] src)
		{
			List<PropIdGroup> list = PropId.GetPropListA();
			foreach(PropIdGroup group in list)
			{
				// final = (int * (1 + intPer) + add) * (1 + per)
				src[group.final] = ( src[group.init] * ( 1 +  src[group.initPer] ) 			+ src[group.add] ) 			* (1 + src[group.per]			/ 100F);
				src[group.final].Limit(group.final);
			}

			list = PropId.GetPropListC();
			foreach(PropIdGroup group in list)
			{
				// final = (int * (1 + intPer) + add + convertFinal * convertRate) * (1 + per)
//				src[group.final] = ( src[group.init] * ( 1 +  src[group.initPer] ) 			+ src[group.add] + src[group.cFinal] *  group.cRate) 			* (1 + src[group.per]			/ 100F);
				src[group.final] = ( (src[group.init]  + src[group.cInit] * group.cRate) * ( 1 +  src[group.initPer] + src[group.cInitPer] * group.cRate) 			+ src[group.add] + src[group.cAdd] * group.cRate) 			* (1 + (src[group.per]	+ src[group.cPer] * group.cRate)		/ 100F);
				src[group.final].Limit(group.final);

//				if(group.final == PropId.MoveSpeed)
//				{
//					Debug.Log("solider src[group.final]=" + src[group.final] + "  src[group.convertFinal]=" + src[group.convertFinal] + "  group.convertRate=" + group.convertRate + "  src[group.init]=" + src[group.init] + "  src[group.per]=" + src[group.per]);
//				}
			}

			list = PropId.GetPropListB();
			foreach(PropIdGroup group in list)
			{
				src[group.final] = ( src[group.final] + src[group.init] * src[group.initPer]			+ src[group.add] ) 			* (1 + src[group.per]			/ 100F);
				src[group.initPer] = 0;
				src[group.add] = 0;
				src[group.per] = 0;
			}

		}

		public static Prop[] PropsToInit(this Prop[] src)
		{
			List<Prop> list = new List<Prop>();
			float[] props = new float[PropId.MAX];
			props.PropAdd(src);
			props = props.PropsToInit();
			return props.FilterZero();
		}

		public static float[] PropsToInit_Float(this Prop[] src)
		{
			List<Prop> list = new List<Prop>();
			float[] props = new float[PropId.MAX];
			props.PropAdd(src);
			props = props.PropsToInit();
			return props;
		}

		public static float[] PropsToInit(this float[] src)
		{
			
			float[] props = new float[PropId.MAX];
			List<PropIdGroup> list = PropId.GetPropListA();
			foreach(PropIdGroup group in list)
			{
				props[group.init] = src[group.add] * (1 + src[group.per] / 100F);
			}
			
			list = PropId.GetPropListC();
			foreach(PropIdGroup group in list)
			{
				props[group.init] = src[group.add] * (1 + src[group.per] / 100F);
			}

			list = PropId.GetPropListB();
			foreach(PropIdGroup group in list)
			{
				props[group.init] = src[group.add] * (1 + src[group.per] / 100F);
			}

			return props;
		}

	}

}
