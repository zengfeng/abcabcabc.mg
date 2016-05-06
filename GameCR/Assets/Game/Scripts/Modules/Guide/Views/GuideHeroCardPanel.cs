using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games.Module.Wars;
using DG.Tweening;

namespace Games.Guides
{
	public class GuideHeroCardPanel : MonoBehaviour
	{
		public GameObject prefab;
		public float cardWidth = 327;
		public float gap = 50;
		public List<GuideHeroCard> cardList;
		public RectTransform box;

		public void Init()
		{
			foreach(var item in War.ownLegionData.skillDatas)
			{
				if(item.Value.isRoleSkill) continue;

				GameObject go = GameObject.Instantiate(prefab);
				go.transform.SetParent(transform, false);
				(go.transform as RectTransform).anchoredPosition = new Vector2(1600, 100);
				go.SetActive(true);
				GuideHeroCard card = go.GetComponent<GuideHeroCard>();
				card.SetHero(item.Value.heroData.heroId);
				cardList.Add(card);
			}
		}

		public void FlyScreen(GuideStepAction action)
		{
			gameObject.SetActive(true);
			int count = cardList.Count;

			float startX = (cardWidth + gap) * count - gap;
			startX = startX * -0.5f + cardWidth * 0.5f;

			for(int i = 0; i < count; i ++)
			{
				GuideHeroCard card = cardList[i];
				Vector2 pos = new Vector2(startX ,100);
				startX += cardWidth + gap;

//				if(i == count -1)
//				{
//					(card.transform as RectTransform).DOAnchorPos(pos, 0.5f).SetDelay(i * 0.2f).OnComplete(()=>{
//						action.End();
//					});
//				}
//				else
//				{
//					(card.transform as RectTransform).DOAnchorPos(pos, 0.5f).SetDelay(i * 0.2f);
//				}


				(card.transform as RectTransform).DOAnchorPos(pos, 0.5f).SetDelay(i * 0.2f);
			}




		}




		public void FlyBox()
		{
			int count = cardList.Count;

			Vector3 boxPos = box.position;
			for(int i = 0; i < count; i ++)
			{
				GuideHeroCard card = cardList[i];
				card.transform.DOMove(boxPos, 0.5f).SetDelay(i * 0.2f);

				if(i == count -1)
				{
					card.transform.DOScale(Vector3.zero, 0.5f).SetDelay(0.5f + i * 0.2f).OnComplete(()=>{
						gameObject.SetActive(false);
					});
				}
				else
				{
					card.transform.DOScale(Vector3.zero, 0.5f).SetDelay(0.5f + i * 0.2f);
				}


			}

			if(count == 0) gameObject.SetActive(false);
		}
	}
}