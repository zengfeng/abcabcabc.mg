using UnityEngine;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class RecordUI : MonoBehaviour 
	{
		public RectTransform[] leftBars;
		public RectTransform[] rightBars;
		public RectTransform[] bottomBars;

		private List<Vector3> init_leftPosList 		= new List<Vector3>();
		private List<Vector3> init_rightPosList 	= new List<Vector3>();
		private List<Vector3> init_bottomPosList 	= new List<Vector3>();


		private List<Vector3> out_leftPosList 		= new List<Vector3>();
		private List<Vector3> out_rightPosList 	= new List<Vector3>();
		private List<Vector3> out_bottomPosList 	= new List<Vector3>();


		void Start()
		{

			for(int i = 0; i < leftBars.Length; i ++)
			{
				init_leftPosList.Add (leftBars[i].anchoredPosition3D);
			}

			for(int i = 0; i < rightBars.Length; i ++)
			{
				init_rightPosList.Add (rightBars[i].anchoredPosition3D);
			}

			for(int i = 0; i < bottomBars.Length; i ++)
			{
				init_bottomPosList.Add (bottomBars[i].anchoredPosition3D);
			}
			//-------------
			for(int i = 0; i < init_leftPosList.Count; i ++)
			{
				out_leftPosList.Add (init_leftPosList[i] + Vector3.left * 200);
			}

			for(int i = 0; i < init_rightPosList.Count; i ++)
			{
				out_rightPosList.Add (init_rightPosList[i] + Vector3.right * 200);
			}

			for(int i = 0; i < init_bottomPosList.Count; i ++)
			{
				out_bottomPosList.Add (init_bottomPosList[i] + Vector3.down * 200);
			}


			SetOutScreen ();



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
			War.signal.sGameBegin -= Init;
		}

		void Init()
		{
			if (War.isRecord) 
			{
				InScreen ();
			}
		}

	

		public void SetOutScreen()
		{
			for(int i = 0; i < leftBars.Length; i ++)
			{
				leftBars[i].anchoredPosition3D = out_leftPosList[i];
			}

			for(int i = 0; i < rightBars.Length; i ++)
			{
				rightBars[i].anchoredPosition3D = out_rightPosList[i];
			}

			for(int i = 0; i < bottomBars.Length; i ++)
			{
				bottomBars[i].anchoredPosition3D = out_bottomPosList[i];
			}
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

			for(int i = 0; i < leftBars.Length; i ++)
			{
				leftBars [i].DOAnchorPos (init_leftPosList[i], duration + Random.Range(duration0ffsetMin, duration0ffsetMax), snapping).SetDelay(delay + Random.Range(delay0ffsetMin, delay0ffsetMax));
			}

			for(int i = 0; i < rightBars.Length; i ++)
			{
				rightBars [i].DOAnchorPos (init_rightPosList[i], duration + Random.Range(duration0ffsetMin, duration0ffsetMax), snapping).SetDelay(delay + Random.Range(delay0ffsetMin, delay0ffsetMax));
			}

			for(int i = 0; i < bottomBars.Length; i ++)
			{
				bottomBars [i].DOAnchorPos (init_bottomPosList[i], duration + Random.Range(duration0ffsetMin, duration0ffsetMax), snapping).SetDelay(delay + Random.Range(delay0ffsetMin, delay0ffsetMax));
			}
		}


	}

}