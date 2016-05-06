using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CC.Runtime.Utils;
using DG.Tweening;

namespace Games.Module.Wars
{
	public class SkillBar : AbstractGuidePanelView 
	{
		public SkillOperateController[] skillControllers;

		public RectTransform produceSkillButton;
		public RectTransform skillBar;
		public CanvasGroup canvasGroup;

		void Start()
		{
			if (canvasGroup == null)
				canvasGroup = GetComponent<CanvasGroup> ();
			
			War.signal.sSkillProduceOwn += OnSkillProduce;

			if(War.isGameing)
			{
				OnWarStarted();
			}
			else
			{
				gameObject.SetActive(false);
				War.signal.sGameBegin += OnWarStarted;
			}
		}

		
		void OnWarStarted()
		{
			if (!War.isRecord)
			{
				gameObject.SetActive (War.ownLegionData.skillDatas.Count > 0);
			}

			canvasGroup.interactable = !War.isRecord;
			canvasGroup.blocksRaycasts = !War.isRecord;
		}


		void OnDestroy()
		{
			War.signal.sSkillProduceOwn -= OnSkillProduce;
			War.signal.sGameBegin -= OnWarStarted;
		}

		void OnSkillProduce(SkillOperateData skillOperateData)
		{
			Debug.Log("skillOperateData.grooveIndex=" + skillOperateData.grooveIndex);
			SkillOperateController skillController = skillControllers[skillOperateData.grooveIndex];
			skillController.SetData(skillOperateData);
		}


		public override void Show ()
		{
			gameObject.SetActive(true);
//			produceSkillButton.DOAnchorPos(new Vector2(-230, 0), 1f, true);
			skillBar.DOAnchorPos(new Vector2(0, 0), 1f, true);
			StartCoroutine(DelayShow());
		}

		IEnumerator DelayShow()
		{
			yield return new WaitForSeconds(1f);
			produceSkillButton.anchoredPosition = new Vector2(-230, 0);
		}

		public override void Hide ()
		{
			produceSkillButton.DOAnchorPos(new Vector2(-230, -300), 0.5f, true);
			skillBar.DOAnchorPos(new Vector2(0, -300), 0.5f, true);
		}

	}
}