using UnityEngine;
using System.Collections;

namespace CC.Runtime.Actions
{
	public class DelayDisableAnimator : MonoBehaviour 
	{
		public Animator animator;
		public float delayTime = 1F;
		private float _time = 0F;
		
		void OnEnable()
		{
			if(animator == null) animator = GetComponent<Animator>();
			_time = Time.time + delayTime;
		}
		
		void Update () 
		{
			if(Time.time > _time)
			{
				if(animator != null) animator.enabled = false;
				this.enabled = false;
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