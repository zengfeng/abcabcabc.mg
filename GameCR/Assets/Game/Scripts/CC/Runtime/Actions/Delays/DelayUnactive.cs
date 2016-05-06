using UnityEngine;
using System.Collections;

namespace CC.Runtime.Actions
{
	public class DelayUnactive : MonoBehaviour 
	{
		public bool finalDisable = false;
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
				gameObject.SetActive(false);
				if(finalDisable) this.enabled = false;
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