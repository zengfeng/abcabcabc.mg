using UnityEngine;
using System.Collections;

namespace Games.Module.Avatars
{
	
	[RequireComponent ( typeof(SpriteRenderer) ) ]
	[ExecuteInEditMode]
	public class SpriteAnimation : MonoBehaviour
	{
		public SpriteAnimationClip clip;
		
		private SpriteAnimation lastClip;
		
		public bool IsPlaying
		{
			get { return isPlaying; }
		}
		
		public bool isComplete = false;
		
		public float frameTime = 0.083333f;
		public bool playOnAwake = true;
		
		//public bool loop = true;
		private int      currentFrame = -1;
		[SerializeField]
		private float    currentTime = 0;
		[SerializeField]
		private bool     isPlaying = false;
		private SpriteRenderer renderer;
		
		void Awake()
		{
			renderer = GetComponent<SpriteRenderer>(); 
		}
		
		void Start()
		{
			if (playOnAwake)
			{
				currentFrame = -1;
				currentTime = frameTime;
				Play();
				Update();
			}
			
		}
		
		public void Play()
		{      
			isPlaying = true;
			isComplete = false;

			if(clip == null  || clip.loop == false)
			{
				currentFrame = -1;
				currentTime = frameTime;
			}
		}
		
		void Update()
		{
			if (clip == null || clip.frames.Length == 0)
			{
				renderer.sprite = null;
				return;
			}

			
			if (isPlaying)
			{
				currentTime += Time.deltaTime;

				if (currentTime >= frameTime)
				{
					currentFrame++;
					currentTime =0;//-= frameTime;
					
					if (currentFrame < clip.frames.Length)
					{
						renderer.sprite = clip.frames [currentFrame];
					} else if (clip.loop)
					{
						currentFrame = 0;
						renderer.sprite = clip.frames[0];
					} else
					{
						isPlaying = false;
						isComplete = true;
					}
				}
				
				//			Debug.Log("SpriteAnimation No end Send === >>>"+clip.name + "    CurrentFrame===>>>"+currentFrame + "  clip.loop===>>"+ clip.loop);
			}
		}

		public void ClearData()
		{
			clip = null;
			lastClip = null;
			renderer.sprite = null;

			isPlaying = false;
			isComplete = true;

		}

		public void ResetData()
		{
			
			currentFrame = 0;
			currentTime = 0;
			isPlaying = false;
			isComplete = false;
		}

		public void Synchronous()
		{
			currentFrame = 0;
			currentTime = 0;
		}
	}
}