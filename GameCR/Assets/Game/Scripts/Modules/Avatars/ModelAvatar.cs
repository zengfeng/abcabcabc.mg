using UnityEngine;
using System.Collections;

namespace Games.Module.Avatars
{
	public class ModelAvatar : Avatara 
	{
		public Animator animator;
		void Awake()
		{
			animator = GetComponent<Animator>();
			
			if (animator != null)
			{
				animator = GetComponentInParent<Animator>();
			}
		}

		void Start()
		{
			Update();
		}
		public AnimatorStateInfo stateInfo;

		public float actionTime = 0f;
		
		virtual protected void Update()
		{
			base.Update();

			if (action != lastAction)
			{
				UpdateClip();
			}

			if(angle != lastAngle)
			{
				lastAngle = angle;
				transform.localRotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
			}

			if(!stateInfo.IsName(action))
			{
				stateInfo = animator.GetCurrentAnimatorStateInfo(0);

			}

			if(stateInfo.IsName(action))
			{
				if(!stateInfo.loop && isPlaying)
				{
					actionTime += Time.deltaTime;
					if(actionTime >= stateInfo.length)
					{
						isActionComplete = true;
					}
				}
			}


			if(speed != lastSpeed)
			{
				lastSpeed = speed;
				animator.speed = speed;
			}
		}

		public void UpdateClip(bool force = false)
		{
			if (!animator)
			{
				lastAction = action;
				return;
			}

			animator.Play(action);
			lastAction = action;
			actionTime = 0f;
			isActionComplete = false;
		}

		
		void LateUpdate()
		{
			if(isActionComplete)
			{
				if(action != "idle1")
				{
					action = "idle1";
				}
			}
		}




		/** 暂停 */
		override public void Pause()
		{
			base.Pause();
			if(animator != null)
			{
				animator.enabled = false;
			}
		}
		
		/** 继续播放 */
		override public void Resume()
		{
			base.Resume();

			if(animator != null)
			{
				animator.enabled = true;
			}
		}

		void PrintAnimatorStateInfo(AnimatorStateInfo stateInfo)
		{
			Debug.Log(string.Format("AnimatorStateInfo fullPathHash={0}, length={1}, loop={2}, normalizedTime={3}, shortNameHash={4}, tagHash={5}, IsName({6})={7}",

			          stateInfo.fullPathHash,
			          stateInfo.length,
			          stateInfo.loop,
			          stateInfo.normalizedTime,
			          stateInfo.shortNameHash,
			          stateInfo.tagHash,
			          action, stateInfo.IsName(action)
			        
			                        ) );
		}

		void PrintAnimatorClipInfo(AnimatorClipInfo info)
		{
			Debug.Log(string.Format("AnimatorClipInfo clip={0}, weight={1}",  info.clip, info.weight  ) );
			if(info.clip != null)
			{
				PrintAnimationClip(info.clip);
			}
		}

		void PrintAnimationClip(AnimationClip clip)
		{
			Debug.Log(string.Format("AnimationClip frameRate={0}, humanMotion={1}, legacy={2}, length={3}, localBounds={4}, wrapMode={5}, isLooping={6}", 
			                        clip.frameRate,
			                        clip.humanMotion,  
			                        clip.legacy,
			                        clip.length,
			                        clip.localBounds,
			                        clip.wrapMode,
			                        clip.isLooping
			                        ) );
		}

	}
}