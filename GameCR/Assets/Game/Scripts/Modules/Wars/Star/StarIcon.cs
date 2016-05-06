using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	public class StarIcon : MonoBehaviour 
	{



		public GameObject unactiveIcon;
		public GameObject activeIcon;

		public bool isActive;
		private bool _isActive;
		private Vector3 position;
		private Vector3 beginPosition;
		void Start () 
		{
		}

		void Update () 
		{
			if(_isActive != isActive)
			{
				SetState(isActive);
			}
		}

		void SetState(bool isActive)
		{


			_isActive = isActive;
			if(isActive == false)
			{
				unactiveIcon.SetActive(true);
				activeIcon.SetActive(false);
			}
			else
			{
				
				position = activeIcon.transform.position;
				beginPosition = activeIcon.transform.parent.position + Vector3.up * 10;

				unactiveIcon.SetActive(true);
				activeIcon.SetActive(true);

				activeIcon.transform.localScale = Vector3.one * 3;
				iTween.ScaleTo(activeIcon,iTween.Hash(
														"delay", 0.01f,
														"scale", Vector3.one,  
				                                      "time",0.3F,
				                                      "easetype", iTween.EaseType.easeOutBounce,
				                                      "oncomplete", "OnActived", "oncompletetarget", gameObject) );



				activeIcon.transform.position = beginPosition;
				iTween.MoveTo(activeIcon, iTween.Hash("delay", 0f,
				                                      "time", 0.2f,
				                                      "islocal", false,
				                                      "position", position,
				                                      "easetype", iTween.EaseType.easeOutBack
				                                      ));

			}
		}

		public void OnActived()
		{
			unactiveIcon.SetActive(false);
			activeIcon.SetActive(true);
			activeIcon.transform.localScale = Vector3.one;
		}
	}
}