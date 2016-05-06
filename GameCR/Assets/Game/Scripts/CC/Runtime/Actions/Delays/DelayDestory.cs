using UnityEngine;
using System.Collections;

namespace CC.Runtime.Actions
{
	public class DelayDestory : MonoBehaviour 
	{

		
		public delegate void EventHandler();
		public event EventHandler OnBeforeDestroy;


		public float delayTime = 4.0F;
		private float _time = 0F;

		void OnEnable()
		{
			_time = Time.time + delayTime;
		}
		
		void Update () 
		{
			if(Time.time > _time)
			{
				if(OnBeforeDestroy != null) OnBeforeDestroy();
				DestroyImmediate(gameObject);
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
