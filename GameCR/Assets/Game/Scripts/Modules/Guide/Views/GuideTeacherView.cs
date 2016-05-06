using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

namespace Games.Guides
{
	public class GuideTeacherView : MonoBehaviour
	{
		public GameObject 	dialog;
		public Text 		text;
		public RectTransform rectTransform;
		private bool isHideing = false;

		void Awake()
		{
			rectTransform =(RectTransform) transform;
		}

		public void Show()
		{
			if(gameObject.activeSelf == false || isHideing)
			{
				isHideing = false;
				rectTransform.DOKill();
				gameObject.SetActive(true);
				rectTransform.anchoredPosition = new Vector2(-600, 0);
				rectTransform.DOAnchorPos(new Vector2(0, 0), 0.25f, true);
			}
		}

		public void Hide()
		{
			isHideing = true;
			rectTransform.DOKill();
			rectTransform.DOAnchorPos(new Vector2(-600, 0), 0.25f, true).OnComplete(()=>{
				gameObject.SetActive(false);
				dialog.SetActive(false);
				isHideing = false;
			});
		}


		public void Say(string msg)
		{
			dialog.SetActive(false);
			text.text = msg;
			dialog.SetActive(true);
		}

	}
}