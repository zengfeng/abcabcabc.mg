using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using CC.Runtime.Utils;
using UnityEngine.EventSystems;

namespace Games.Module.Wars
{
	public class WinInfoPanel : MonoBehaviour , IPointerClickHandler
	{
		public GameObject[] views;
	


		/** 本关卡处理器列表 */
		public WinProcessor winProcessor;
		public WinConfig winConfig;
		
		protected void Awake ()
		{
			gameObject.SetActive(true);
		}

		public void Show()
		{
			winProcessor = War.winManager.winProcessor;
			if(winProcessor == null) return;

			winConfig = winProcessor.winConfig;
			int index = ((int)winConfig.winType)-1;
			GameObject viewGO = null;
			if(index < views.Length)
			{
				viewGO = views[index];
			}

			if(viewGO != null) viewGO.SetActive(true);
			gameObject.SetActive(true);
			winProcessor.SetInfoPanel(viewGO);

			StartCoroutine(DelayPause());
		}

		IEnumerator DelayPause()
		{
			yield return new WaitForEndOfFrame();
			War.Pause();
		}


		public void Hide()
		{
			War.Play();
			gameObject.SetActive(false);
		}

		public void OnPointerClick (PointerEventData eventData)
		{
			Hide();
		}




	}
}