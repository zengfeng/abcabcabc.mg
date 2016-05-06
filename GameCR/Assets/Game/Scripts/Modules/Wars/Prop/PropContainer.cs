using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.signals;
using System;

namespace Games.Module.Wars
{
	/** 属性节点 */
	public class PropNdoe
	{
		/** 附加属性数据 */
		public AttachPropData attachPropData;
		/** 节点ID */
		public int uid	{ get{	return	attachPropData.uid;	}	}
		/** 应用属性的单位 */
		public Dictionary<int, IPropUnit>  unitDict = new Dictionary<int, IPropUnit>();

		/** 单位--应用附加属性 */
		public void UnitApp(IPropUnit unit, bool calculate = false)
		{
			if(unitDict.ContainsKey(unit.uid))
			{
				UnitRevoke(unit);
			}

			unit.AppProps(attachPropData, calculate);
			unitDict.Add(unit.uid, unit);
			unit.sClearProp += OnUnitCleanProp;
		}

		/** 单位--移除附加属性 */
		public void UnitRevoke(IPropUnit unit, bool calculate = false)
		{
			unit.RevokeProps(attachPropData, calculate);
			unit.sClearProp -= OnUnitCleanProp;
			unitDict.Remove(unit.uid);
		}
		
		/** 销毁属性节点 */
		public void Destroy()
		{
			foreach(KeyValuePair<int, IPropUnit> kvp in unitDict)
			{
				IPropUnit unit = kvp.Value;
				unit.RevokeProps(attachPropData, true);
				unit.sClearProp -= OnUnitCleanProp;
			}

			unitDict.Clear();

		}

		/** 单位清除属性事件，一般士兵死亡时、建筑换势力时调用 */
		private void OnUnitCleanProp(IPropUnit unit)
		{
			UnitRevoke(unit, false);
		}



		/** 构造方法 */
		public PropNdoe()
		{

		}

		public PropNdoe(AttachPropData attachPropData)
		{
			this.attachPropData = attachPropData;
		}

		public override string ToString ()
		{
			return string.Format ("[PropNdoe: uid={0}] attachPropData={1}", uid, attachPropData);
		}
	}

	/** 属性容器 */
	public class PropContainer
	{
		/** 添加属性节点 */
		public Action<PropNdoe> sAddNode;

		/** 属性节点列表 */
		public Dictionary<int, PropNdoe> nodeDict = new Dictionary<int, PropNdoe>();

		/** 添加属性节点--使用附加数据 */
		public void Add(AttachPropData attachPropData)
		{
			PropNdoe node = new PropNdoe(attachPropData);
			Add(node);
		}
		
		/** 添加属性节点--PropNdoe */
		public void Add(PropNdoe propNode)
		{
			if(nodeDict.ContainsKey(propNode.uid))
			{
				Remove(propNode.uid);
			}

			nodeDict.Add(propNode.uid, propNode);
			if(sAddNode != null) sAddNode(propNode);
		}

		/** 移除属性节点--id */
		public void Remove(int id)
		{
			PropNdoe propNode;
			if(nodeDict.TryGetValue(id, out propNode))
			{
				Remove(propNode);
			}
		}
		
		/** 移除属性节点-- AttachPropData */
		public void Remove(AttachPropData attachPropData)
		{
			Remove(attachPropData.uid);
		}
		
		/** 移除属性节点--PropNdoe  */
		public void Remove(PropNdoe propNode)
		{
			propNode.Destroy();
			nodeDict.Remove(propNode.uid);
		}

		/** 清理属性节点 */
		public void Clear()
		{
			foreach(KeyValuePair<int, PropNdoe> kvp in nodeDict)
			{
				kvp.Value.Destroy();
			}

			nodeDict.Clear();
		}

		/** 单位--应用所有节点 */
		public void UnitApp(IPropUnit unit, bool calculate = false)
		{
			int i = 0;
			int count = nodeDict.Count;
			bool isCalculate = false;
			foreach(KeyValuePair<int, PropNdoe> kvp in nodeDict)
			{
				i ++;
				isCalculate = calculate && i == count;
				kvp.Value.UnitApp(unit, isCalculate);
			}
		}

		
		public void Print ()
		{
			Debug.Log("####PropContainer####");
			foreach(var node in nodeDict)
			{
				Debug.Log(node);
			}
		}

	}
}
