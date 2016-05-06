using UnityEngine;
using System.Collections;
using System;

namespace CC.Runtime
{


	public class ShakePhoneEvent : MonoBehaviour 
	{
		public Action OnShake;
		float old_y = 0.0f;
		float new_y = 0.0f;
		float d_y = 0.0f;
		void Update () 
		{
			new_y = Input.acceleration.y;
			d_y = new_y - old_y;
			old_y = new_y;

			if (d_y > 0.8f)
			{
				if(OnShake != null)
				{
					
					Debug.Log("acceleration=" + Input.acceleration);
					OnShake();
					#if UNITY_ANDROID || UNITY_IPHONE
					//Handheld.Vibrate();//震动效果
					#endif
				}
			}
		}
	}
}
