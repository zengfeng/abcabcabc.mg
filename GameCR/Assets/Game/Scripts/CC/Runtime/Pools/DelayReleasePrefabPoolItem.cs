using UnityEngine;
using System.Collections;


namespace CC.Runtime.Pools
{
	public class DelayReleasePrefabPoolItem : MonoBehaviour 
	{
		public float delayTime = 1F;
		private float _time = 0F;



		void OnEnable()
		{
			_time = Time.time + delayTime;
		}

		void Update () 
		{
			if(Time.time > _time)
			{
				PrefabPoolItem item = GetComponent<PrefabPoolItem>();
				if(item != null) item.Release();
			}
		}

		public float DelayTime
		{
			get
			{
				return delayTime;
			}
			
			set
			{
				delayTime = value;
				_time = Time.time + delayTime;
			}
		}
	}
}