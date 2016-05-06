using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


namespace Games.Module.Wars
{
	public class BegionPanel : MonoBehaviour
	{
		public GameObject colorImage;
		public Color   colorB;
		public float time = 1;

		public float cloudDelayTime=0.5f;
		public float cloudTime=1f;
		public Transform cloudLeftLayer;
		public Transform cloudRightLayer;
		public bool autoClose;

		private Color clolorInit;
		private List<Vector3> cloundLeftInitPos = new List<Vector3>();
		private List<Vector3> cloundRightInitPos = new List<Vector3>();

		
		private List<Vector3> cloundLeftEndPos = new List<Vector3>();
		private List<Vector3> cloundRightEndPos = new List<Vector3>();
		void Start()
		{
			clolorInit = colorImage.GetComponent<Image>().color;

			for(int i =0; i < cloudLeftLayer.childCount; i ++)
			{
				RectTransform child = cloudLeftLayer.GetChild(i) as RectTransform;
				cloundLeftInitPos.Add(child.localPosition);

				child.anchoredPosition3D = new Vector3(-1800f, 0f, 0f);
				cloundLeftEndPos.Add(child.localPosition);
				child.localPosition = cloundLeftInitPos[i];
			}

			
			for(int i =0; i < cloudRightLayer.childCount; i ++)
			{
				RectTransform child = cloudRightLayer.GetChild(i) as RectTransform;
				cloundRightInitPos.Add(child.localPosition);

				
				child.anchoredPosition3D = new Vector3(1300f, 0f, 0f);
				cloundRightEndPos.Add(child.localPosition);
				child.localPosition = cloundRightInitPos[i];
			}

			
			StartCoroutine(OnPlayEnter());
		}


		[ContextMenu("PlayEnter")]
		public void PlayEnter()
		{
			
			colorImage.GetComponent<Image>().color = clolorInit;

			for(int i =0; i < cloudLeftLayer.childCount; i ++)
			{
				Transform child = cloudLeftLayer.GetChild(i);
				child.localPosition = cloundLeftInitPos[i];
			}
			
			
			for(int i =0; i < cloudRightLayer.childCount; i ++)
			{
				Transform child = cloudRightLayer.GetChild(i);
				child.localPosition = cloundRightInitPos[i];
			}

			StartCoroutine(OnPlayEnter());
		}

		IEnumerator OnPlayEnter()
		{
			iTween.ColorTo(colorImage, colorB, time);

			yield return new WaitForSeconds(cloudDelayTime);
			
			for(int i =0; i < cloudLeftLayer.childCount; i ++)
			{
				Transform child = cloudLeftLayer.GetChild(i);
				iTween.MoveTo(child.gameObject, iTween.Hash(
					"delay", 0.3f - i * 0.1f,
					"time", cloudTime,
					"islocal", true,
					"position", cloundLeftEndPos[i]
					));
			}

			for(int i =0; i < cloudRightLayer.childCount; i ++)
			{
				Transform child = cloudRightLayer.GetChild(i);
				iTween.MoveTo(child.gameObject, iTween.Hash(
					"delay", 0.3f - i * 0.1f,
					"time", cloudTime,
					"islocal", true,
					"position", cloundRightEndPos[i]
					));
			}

			if(autoClose)
			{
				yield return new WaitForSeconds(cloudTime + 0.3f);
				DestroyImmediate(gameObject);
			}
		}


	}
}