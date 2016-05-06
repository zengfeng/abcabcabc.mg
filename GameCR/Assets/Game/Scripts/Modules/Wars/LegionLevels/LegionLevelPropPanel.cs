using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using UnityEngine.UI;
using DG.Tweening;

namespace Games.Module.Wars
{
	public class LegionLevelPropPanel : MonoBehaviour 
	{
		public LegionLevelPropItem atkItem;
		public LegionLevelPropItem defItem;
		public LegionLevelPropItem moveSpeedItem;

		public LegionLevelData data;
		public CanvasGroup canvasGroup;

		public void SetData()
		{
			if(data == null) return;

			atkItem.max 		= data.maxBattleForce;
			atkItem.init 		= data.displayIntBattleForce;
			atkItem.val 		= data.atk;
			atkItem.Set();
			
			defItem.max 		= data.maxProduceSpeed;
			defItem.init 		= data.displayIntProduceSpeed;
			defItem.val 		= data.produceSpeed;
			defItem.Set();
			
			moveSpeedItem.max 		= data.maxMoveSpeed;
			moveSpeedItem.init 		= data.displayIntMoveSpeed;
			moveSpeedItem.val 		= data.moveSpeed;
			moveSpeedItem.Set();
		}

		public void Show()
		{
			SetData();
			
			canvasGroup.DOKill();
			canvasGroup.alpha = 0;
			gameObject.SetActive(true);
			canvasGroup.DOFade(1, 0.5f);
		}


		public void Hide()
		{
			canvasGroup.DOKill();
			canvasGroup.DOFade(0, 0.5f).OnComplete(()=>{
				gameObject.SetActive(false);
			});

		}

	}
}