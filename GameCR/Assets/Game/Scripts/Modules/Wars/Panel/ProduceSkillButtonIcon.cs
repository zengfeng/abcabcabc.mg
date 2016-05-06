using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Games.Module.Wars
{
	public class ProduceSkillButtonIcon : MonoBehaviour {

		public float progress = 0;



		public Image skillIconImage;
		public Image disableSkillIconImage;

		public RectTransform 	lineImage;
		public float			lineBegin 	= -9f;
		public float			lineEnd 	= 109f;
		public float			lineMax 	= 104f;


		public Image heroIconImage;
		public ProduceSkillButtonGlossy glossy;




		void Start () 
		{
			Progress = progress;
		}

		void Update()
		{
			Progress = progress;
		}


		private float _progress = 0;
		public float Progress
		{
			get
			{
				return progress;
			}

			set
			{
				progress = value;

				skillIconImage.fillAmount 	= progress;

				lineImage.anchoredPosition = new Vector2(0, Mathf.Min(lineMax, lineBegin + (lineEnd - lineBegin) * progress));

				if(progress <= 0 || progress >= 1)
				{
					if(lineImage.gameObject.activeSelf)
					{
						lineImage.gameObject.SetActive(false);
					}
				}
				else
				{
					if(!lineImage.gameObject.activeSelf)
					{
						lineImage.gameObject.SetActive(true);
					}
				}

				if(_progress != progress)
				{
					_progress = progress;
					if(_progress >= 1)
					{
						glossy.gameObject.SetActive(true);
					}
				}

			}
		}

		
		public bool Visiable
		{
			get
			{
				return gameObject.activeSelf;
			}

			set
			{
				gameObject.SetActive(value);
			}
		}

		public void SetSkillIcon(Sprite sprite)
		{
			skillIconImage.sprite 			= sprite;
			disableSkillIconImage.sprite 	= sprite;
		}

		
		
		public void SetHeroIcon(Sprite sprite)
		{
			heroIconImage.sprite 	= sprite;
		}


	}
}