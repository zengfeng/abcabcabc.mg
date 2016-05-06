using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Module.Avatars
{
	[ExecuteInEditMode]
	public class SpriteAvatar : Avatara 
	{
		private AvatarData 		_avatarData;
		public AvatarData 		avatarData;
		public SpriteAvatar[] 	childAvatars;


		private AvatarAction 		avatarAction;
		private SpriteAnimation 	spriteAnimation;
		private Transform 			spriteTransform;
		private Isometric 			spriteIsometric;
		private Dictionary<string, List<SpriteAnimationClip>> actionClipsMap;


		void Awake()
		{
			_avatarData = avatarData;
			spriteAnimation = GetComponent<SpriteAnimation>();
			
			if (spriteAnimation != null)
			{
				spriteTransform = spriteAnimation.GetComponent<Transform>();
				spriteIsometric = spriteAnimation.GetComponent<Isometric>();
			}
			
			SpriteRenderer renderer = GetComponent<SpriteRenderer>();
			
			if (renderer != null)
			{
//				Debug.Log("SpriteRenderer " + renderer.sortingLayerName + " " + renderer.sortingLayerID + " " + renderer.sortingOrder);
				
			}
		}
		
		void Start()
		{
			Update();
		}
		
		virtual protected void Update()
		{
			base.Update();


			if (angle != lastAngle || action != lastAction)
			{
				if (childAvatars != null && childAvatars.Length > 0)
				{
					foreach (SpriteAvatar childAvatar in childAvatars)
					{
						childAvatar.action = action;
						childAvatar.angle = angle;
						childAvatar.UpdateClip(true);
					}
				}
				
				UpdateClip();
			}
			else if(_avatarData != avatarData)
			{
				_avatarData = avatarData;
				if(spriteAnimation != null) spriteAnimation.ResetData();
				UpdateClip(true);
			}

			if (spriteAnimation != null)
			{
				isActionComplete = spriteAnimation.isComplete;
			}
			else if (childAvatars !=null && childAvatars.Length >0)
			{
				isActionComplete = childAvatars[0].spriteAnimation.isComplete;
			}

			if(lastSpeed != speed)
			{
				lastSpeed = speed;

				if (childAvatars != null && childAvatars.Length > 0)
				{
					foreach (SpriteAvatar childAvatar in childAvatars)
					{
						childAvatar.speed = speed;
					}
				}

				if(spriteAnimation != null && avatarAction != null)
				{
					spriteAnimation.frameTime = avatarAction.frameTime *( 1f / speed );
				}
			}
		}

		void LateUpdate()
		{
			if(isActionComplete)
			{
				OnActionComplete(action);

				if(action != "die" && action.IndexOf("level") == -1)
				{
					action = "idle";
				}
			}
		}
		
		public void UpdateClip(bool force = false)
		{
			if (!avatarData || !spriteAnimation)
			{
				lastAngle = angle;
				lastAction = action;
				return;
			}
//			Debug.Log("UpdateClip");
			
			if (lastAction != action || force)
			{
				avatarAction = avatarData.GetAvatarAction(action);
			}

			if (avatarAction != null)
			{
//				if (force || lastAngle != angle || lastAction != action)
//				{
					SpriteAnimationClip clip = avatarAction.GetSpriteAnimationClip(angle);

					if (clip != null)
					{
						spriteAnimation.clip = clip;
						spriteAnimation.frameTime = avatarAction.frameTime;
						spriteIsometric.flip = clip.flip;
						
						if (!spriteAnimation.IsPlaying || lastAction != action)
						{
							spriteAnimation.Play();
						}
					} else
					{
						Debug.Log("<color=red> action=" + action + " angle=" + angle + "avatarAction is null"  + "</color>");
						spriteAnimation.clip = null;
						spriteIsometric.flip = false;
					}
//				}
			} 
			else
			{
				
//				Debug.Log("<color=red> action=" + action+ " is null"  + "</color>");
				spriteAnimation.clip = null;
				spriteIsometric.flip = false;
			}
			
			lastAction = action;
			lastAngle = angle;
			isSendActionComplete = false;
		}
		

		
		/** 暂停 */
		override public void Pause()
		{
			base.Pause();
			if (spriteAnimation != null)
				spriteAnimation.enabled = false;
			
			foreach (Avatara child in childAvatars)
			{
				child.Pause();
			}
		}
		
		/** 继续播放 */
		override public void Resume()
		{
			base.Resume();
			if (spriteAnimation != null)
				spriteAnimation.enabled = true;
			
			foreach (Avatara child in childAvatars)
			{
				child.Resume();
			}
		}

		public void ClearData()
		{
			avatarData = null;
			avatarAction = null;
			spriteAnimation.ClearData();
		}

		
		public void Synchronous()
		{
			spriteAnimation.Synchronous();
		}

	}
}