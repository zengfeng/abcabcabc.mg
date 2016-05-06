using UnityEngine;
using System.Collections;
using System;

namespace Games.Module.Avatars
{
	public class Avatara : MonoBehaviour 
	{
		public Action<String>   sActionComplete;
		protected bool 			isSendActionComplete = false;
		/** 是否播放状态 */
		public bool isPlaying = true;
		protected bool _isPlaying = true;

		/** 播放速度 */
		public float 		speed = 1F;
		/** 方向 */
		public float 		angle;
		/** 动作 */
		public string 		action;
		/** 动作是否结束 */
		public bool 		isActionComplete;

		protected float 	lastAngle = float.NaN;
		protected string 	lastAction;
		protected float		lastSpeed = 1F;


		virtual protected void Update()
		{
			if(isPlaying != _isPlaying)
			{
				if(isPlaying)
				{
					Resume();
				}
				else
				{
					Pause();
				}
			}
		}


		/** 暂停 */
		virtual public void Pause()
		{
			isPlaying = false;
			_isPlaying = isPlaying;
		}
		
		/** 继续播放 */
		virtual public void Resume()
		{
			isPlaying = true;
			_isPlaying = isPlaying;
		}

		/** 动作播放完成事件 */
		virtual protected void OnActionComplete(string action)
		{
			if(isSendActionComplete) return;
			isSendActionComplete = true;
			if(sActionComplete != null) sActionComplete(action);
		}

	}
}