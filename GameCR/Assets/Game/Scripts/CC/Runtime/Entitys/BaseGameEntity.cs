using UnityEngine;
using System.Collections;
namespace CC.Runtime.Entitys
{
	public class BaseGameEntity : MonoBehaviour
	{
		public int _Id;
		static int NextID = 1;
		public int ID
		{
			get{return _Id;}

			set
			{
				_Id = value;
				NextID = value + 1;
			}

		}
		
		public string EName = "";
		/** 更新频率 */
		public float UpdateRateTime = 2F;
		/** 更新延迟启动 */
		public float UpdateDelayTime = 0.5F;
		
		protected virtual  void Start () 
		{
			if(_Id <= 0)ID = NextID;
		}

		
		protected virtual void OnUpdate () 
		{
		}

		protected virtual void OnEnable()
		{
			InvokeRepeating("OnUpdate", UpdateDelayTime, UpdateRateTime);
			EntityManager.Instance.RegisterEntity(this);
		}

		protected virtual void OnDisable()
		{
			CancelInvoke();
			EntityManager.Instance.RemoveEntity(this);
		}


		public override string ToString ()
		{
			return string.Format ("[{0}: ID={1} EName={2}]", this.GetType().Name, ID, EName);
		}


	}
}
