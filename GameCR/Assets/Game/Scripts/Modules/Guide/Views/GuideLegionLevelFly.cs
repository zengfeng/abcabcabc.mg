using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace Games.Guides
{
	public class GuideLegionLevelFly : MonoBehaviour 
	{
		public RectTransform icon;
		public RectTransform targetIcon;
		public GameObject dialog;

		void OnEnable()
		{
//			icon.anchoredPosition = new Vector2(0, 72);
			dialog.SetActive(true);
		}


		public void Play(GuideStepAction action)
		{
			dialog.SetActive(false);
			icon.DOMove(targetIcon.position, 1.5f).OnComplete(()=>{action.End();});
			icon.DOScale (Vector3.one, 1.5f);
		}
	}
}
