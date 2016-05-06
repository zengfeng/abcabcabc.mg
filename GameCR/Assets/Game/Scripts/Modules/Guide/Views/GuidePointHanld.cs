using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;


namespace Games.Guides
{
	public class GuidePointHanld : AbstractGuidePanelView
	{
		public enum HanldType
		{
			/** 点击 */
			Click,
			/** 双击 */
			DoubleClick
		}


		public HanldType 		hanldType;
		public Image 			image;
		public Sprite[] 		sprites;

		public Vector2 from = new Vector2(100, 100);
		
		public float pointInTime = 0.5f;
		public float pointGapTime = 0.3f;
		public float pointEndTime = 0.2f;
		public float pointOutTime = 0.5f;
		public float pointWaitTime = 0.5f;

		private int frameIndex = 0;
		private int	frameCount = 0;
		private bool isPlaying = false;

		void Awake ()
		{
			frameCount = sprites.Length;
		}


		void OnEnable()
		{
			if(frameCount > 0)
			{
				Play();
			}
		}

		void OnDisable()
		{
			Stop();
		}

		public void Play()
		{
			Stop();
			isPlaying = true;
			StartCoroutine(OnPlay());
		}

		public void Stop()
		{
			isPlaying = false;
			StopAllCoroutines();
		}

		IEnumerator OnPlay()
		{
			int pointCount = hanldType == HanldType.Click ? 1 : 2;
			while(isPlaying)
			{
				image.gameObject.SetActive(true);
				image.rectTransform.DOAnchorPos(new Vector2(0, 0), pointInTime, true);
				image.DOFade(1, pointInTime);
				yield return new WaitForSeconds(pointInTime);
				for(int i = 0; i < pointCount; i ++)
				{
					for(int frameIndex = 0; frameIndex < frameCount; frameIndex ++)
					{
						image.sprite = sprites[frameIndex];
						yield return new WaitForSeconds(pointGapTime);
					}
				}

				yield return new WaitForSeconds(pointEndTime);
				image.rectTransform.DOAnchorPos(from,pointOutTime, true);
				image.DOFade(0, pointOutTime);
				yield return new WaitForSeconds(pointOutTime + pointWaitTime);
				image.sprite = sprites[0];
			}
		}


		public void Set(HanldType handlType, Vector2 anchorPos)
		{
			this.hanldType = handlType;
			(transform as RectTransform).anchoredPosition = anchorPos;
			Play();
		}
		
		public void SetWorld(HanldType handlType, Vector3 position)
		{
			SetWorld(handlType, position, Camera.main);
		}

		public void SetWorld(HanldType handlType, Vector3 position, Camera camera)
		{
			Set(handlType, position.WorldPosToAnchorPos(camera));
		}


	}
}
