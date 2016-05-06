using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using CC.Runtime.signals;

namespace Games.Module.Wars
{
	public class ClockView : MonoBehaviour
	{
		public Image 	colorImage;
		public Image 	needleImage;

		public float progress;

		public float time= 10;
		public float timeleft = 0;
		public bool autoHide;

		void Update()
		{
			timeleft -= Time.deltaTime;


			if(timeleft <= 0)
			{
				timeleft = 0;
			}

			progress = 1 - timeleft / time;
			SetProgress();

			if(autoHide && timeleft <= 0)
			{
				Hide();
			}
		}

		public void SetProgress()
		{
			colorImage.fillAmount = progress;
			needleImage.transform.eulerAngles = new Vector3(0, 0, progress * -360f);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}

		public void Show()
		{
			gameObject.SetActive(true);
		}
		
		public void Show(float time)
		{
			this.time = time;
			this.timeleft = time;
			this.progress = 0;
			SetProgress();

			gameObject.SetActive(true);
		}



	}
}