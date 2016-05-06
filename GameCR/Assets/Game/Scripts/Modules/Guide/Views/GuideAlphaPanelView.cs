using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

namespace Games.Guides
{
	public class GuideAlphaPanelView : AbstractGuidePanelView
	{
		public CanvasGroup canvasGroup;
		void Awake()
		{
			if(canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
		}


		public override void Show ()
		{
			gameObject.SetActive(true);
			canvasGroup.DOFade(1f, 0.5f);
		}

		public override void Hide ()
		{
			canvasGroup.DOFade(0f, 0.5f).OnComplete(()=>{gameObject.SetActive(false);});
		}
	}
}