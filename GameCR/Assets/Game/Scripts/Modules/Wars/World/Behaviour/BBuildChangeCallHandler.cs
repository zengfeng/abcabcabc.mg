using UnityEngine;
using System.Collections;
using CC.Runtime;
using CC.Runtime.Utils;
using System;


namespace Games.Module.Wars
{
	public class BBuildChangeCallHandler : MonoBehaviour
	{
		// 隐藏时间点
		public float hideAvatarTime = 0.02f;
		// 隐藏后间隔时间，显示
		public float showAvatarTime = 0.7f;


		public Action call;
		public float time = 0;
		private float _time = 0; 

		public void StopCall()
		{
			StopAllCoroutines();
			DestroyObject(this);
		}

		public void Play(float time, GameObject effect,  Action<object> call, object arg)
		{
			hideAvatarTime = time - showAvatarTime - 0.6f;
			if(hideAvatarTime <= 0)
			{
				hideAvatarTime = 0.02f;
			}
			_time = hideAvatarTime + 0.02f;
			BBuildChangeAvatar buildChangeAvatar = GetComponent<BBuildChangeAvatar>();
			buildChangeAvatar.Play(_time, hideAvatarTime, showAvatarTime, 0.01f, effect);

			StartCoroutine(DelayCallHandler(_time, call, arg));
		}

		IEnumerator DelayCallHandler(float time,  Action<object> call, object arg)
		{
			yield return new WaitForSeconds(time);
			call(arg);
			DestroyObject(this);
		}



	}
}
