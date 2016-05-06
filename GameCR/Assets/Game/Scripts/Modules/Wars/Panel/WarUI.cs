using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace Games.Module.Wars
{
	public class WarUI : MonoBehaviour 
	{
		public RectTransform topBar;
		public RectTransform sendArmRateBar;
		public RectTransform skillBar;
		public RectTransform pauseBar;

		public GameObject record;

		private Vector3 init_topPos;
		private Vector3 init_sendArmRatepPos;
		private Vector3 init_skillPos;
		private Vector3 init_pausePos;


		private Vector3 out_topPos;
		private Vector3 out_sendArmRatepPos;
		private Vector3 out_skillPos;
		private Vector3 out_pausePos;

		void Start()
		{
			init_topPos 			= topBar.anchoredPosition3D;
			init_sendArmRatepPos 	= sendArmRateBar.anchoredPosition3D;
			init_skillPos 			= skillBar.anchoredPosition3D;
			init_pausePos 			= pauseBar.anchoredPosition3D;

			out_topPos 				= init_topPos 			+ Vector3.up * 100;
			out_sendArmRatepPos 	= init_sendArmRatepPos 	+ Vector3.left * 200;
			out_skillPos 			= init_skillPos 		+ Vector3.down * 300;
			out_pausePos 			= init_pausePos 		+ new Vector3 (1, -1, 0) * 200;


			War.signal.sBuildComplete += OnBuildComplete;



			if(War.isGameing)
			{
				Init();
			}
			else
			{
				War.signal.sGameBegin += Init;
			}
		}

		void OnDestroy()
		{
			War.signal.sBuildComplete -= OnBuildComplete;
			War.signal.sGameBegin -= Init;
		}

		void Init()
		{
			if (War.vsmode == VSMode.Train)
				return;
			
			InScreen ();
		}

		public void OnBuildComplete()
		{
			if (War.isRecord) 
			{
				record.SetActive (true);
			}

			if (War.vsmode == VSMode.Train)
				return;
			
			SetOutScreen ();

			if (War.isRecord) 
			{
				RecordModel ();
			}
		}


		public void SetOutScreen()
		{
			topBar.anchoredPosition3D = out_topPos;
			sendArmRateBar.anchoredPosition3D = out_sendArmRatepPos;
			skillBar.anchoredPosition3D = out_skillPos;
			pauseBar.anchoredPosition3D = out_pausePos;
		}


		public float 	delay = 1.5f;
		public float 	delay0ffsetMin = 0f;
		public float 	delay0ffsetMax = 0.3f;

		public float 	duration = 1f;
		public float 	duration0ffsetMin = 0f;
		public float 	duration0ffsetMax = 0.3f;
		public void InScreen()
		{
//			float 	delay0ffsetMin = 0f;
//			float 	delay0ffsetMax = 0.3f;
//			float 	delay = 1.5f;
//			float 	duration = 1f;
			bool 	snapping = false;

			topBar.DOAnchorPos (init_topPos, duration + Random.Range(duration0ffsetMin, duration0ffsetMax), snapping).SetDelay(delay + Random.Range(delay0ffsetMin, delay0ffsetMax));
			sendArmRateBar.DOAnchorPos (init_sendArmRatepPos, duration + Random.Range(duration0ffsetMin, duration0ffsetMax), snapping).SetDelay(delay + Random.Range(delay0ffsetMin, delay0ffsetMax));
			skillBar.DOAnchorPos (init_skillPos, duration + Random.Range(duration0ffsetMin, duration0ffsetMax), snapping).SetDelay(delay + Random.Range(delay0ffsetMin, delay0ffsetMax));
			pauseBar.DOAnchorPos (init_pausePos, duration + Random.Range(duration0ffsetMin, duration0ffsetMax), snapping).SetDelay(delay + Random.Range(delay0ffsetMin, delay0ffsetMax));
		}

		public void NormalModel()
		{
			
		}

		public void RecordModel()
		{
			sendArmRateBar.gameObject.SetActive (false);
			skillBar.gameObject.SetActive (false);
			pauseBar.gameObject.SetActive (false);
		}


	}

}