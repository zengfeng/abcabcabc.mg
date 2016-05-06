using UnityEngine;
using System.Collections;

namespace CC.Runtime.Actions
{
	public class DelayActive : MonoBehaviour 
	{
		public GameObject[] list;
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
				foreach(GameObject go in list)
				{
					if(go != null) go.SetActive(true);
				}
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