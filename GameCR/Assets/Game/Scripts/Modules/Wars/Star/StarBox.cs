using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	public class StarBox : MonoBehaviour 
	{
		public float delayStarActive = 1f;
		public float openTimeConfig = 1f;
		private float _openTime = 0;
		public bool isOpening
		{
			get
			{
				return _openTime > 0;
			}

			set
			{
				_openTime = value ? openTimeConfig : 0;
			}
		}

		public StarIcon[] starIcons;
		int activeCount = 0;

		Queue starConfigs = new Queue();

		public bool isFinal
		{
			get
			{
				return !isOpening && starConfigs.Count == 0;
			}
		}

		public void Open(StarConfig config)
		{
			if (gameObject.activeSelf == false) return;

			starConfigs.Enqueue(config);
			CheckOpen();
		}

		
		private void CheckOpen()
		{
			if(starConfigs.Count > 0)
			{
				if(!isOpening)
				{
					Show();
				}
			}
		}

		public void Show()
		{
			if(starConfigs.Count > 0)
			{
				StarConfig config = starConfigs.Dequeue() as StarConfig;

				if(War.config.isShowStarMsg)
				{
					War.msgBox.Show_Text(config.Description);
				}

				if(activeCount < starIcons.Length)
				{
					StartCoroutine(DelayActiveIcon(starIcons[activeCount ++]));
				}

				isOpening = true;
			}
		}

		IEnumerator DelayActiveIcon(StarIcon starIcon)
		{
			yield return new WaitForSeconds(delayStarActive);
			starIcon.isActive = true;
		}

		void LateUpdate()
		{
			if(_openTime > 0)
			{
				_openTime -= Time.deltaTime;
			}
			else
			{
				if(starConfigs.Count > 0)
				{
					CheckOpen();
				}
			}
		}




	}
}