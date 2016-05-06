using UnityEngine;
using System.Collections;
using Games.Module.Wars;
using CC.Runtime;

namespace Games.Guides
{
	public class GuideSkillButtonDrag : MonoBehaviour
	{
		public SkillBar skillBar;
		public int skillId;
		public int buildId;
		public SkillOperateController select;
		public GuideStepAction stepAction;
		public int moveId = 1111;


		public void Set(GuideStepAction stepAction, int skillId, int buildId)
		{
			if (War.ownLegionData.GetSkillDataBySkillId (skillId) == null)
			{
				stepAction.NextFrameEnd ();
				return;
			}

			this.stepAction = stepAction;
			this.skillId = skillId;
			this.buildId = buildId;
			this.moveId = skillId;
			gameObject.SetActive(true);
			StopAllCoroutines();
			StartCoroutine(Check());
		}

		public IEnumerator Check()
		{
			while(true)
			{
				yield return new WaitForSeconds(0.5f);
				select = null;
				foreach(SkillOperateController item in skillBar.skillControllers)
				{
					if(item.data != null && item.data.skillId == skillId)
					{
						select = item;
						break;
					}
				}

				if(select != null)
				{
					SetMove();
					yield break;
				}
			}
		}

		public UnitCtl build;
		public void SetMove()
		{
			Vector3 from = select.transform.position;
			build =  War.scene.GetBuild(buildId);
			Vector3 to = build.transform.position.WorldPosToAnchorPos();
			(transform as RectTransform).anchoredPosition = to;
			to = transform.position;


			Guide.view.screenMask.DrawDragSkillBuild (from, buildId);
			Guide.view.moveToPanel.Move(moveId, from, to, GuideMoveToPanel.ViewType.Drag);
		}

		void OnDisable()
		{
			War.signal.sSkillUse -= OnSkillUse;
			StopAllCoroutines();
			Guide.view.moveToPanel.CloseMoveTo(moveId);
		}

		
		
		void OnEnable()
		{
			War.signal.sSkillUse += OnSkillUse;
		}
		
		
		/** 事件--使用技能 */
		void OnSkillUse(SkillOperateData skillOperateData)
		{
			if(select == null || select.data == null) return;

			if(skillOperateData.uid == select.data.uid)
			{
				stepAction.End();
				gameObject.SetActive(false);
			}
		}
	
	}
}