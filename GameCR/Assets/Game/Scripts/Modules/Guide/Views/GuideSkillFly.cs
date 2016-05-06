using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace Games.Guides
{
	public class GuideSkillFly : MonoBehaviour 
	{
		public RectTransform icon;
		public RectTransform targetIcon;

		void OnEnable()
		{
			icon.anchoredPosition = new Vector2(0, 140);
		}


		public void Play(GuideStepAction action)
		{
			icon.DOMove(targetIcon.position, 1f).OnComplete(()=>{action.End();});
		}
	}
}
