using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideSkillButtonDragToCircle : MonoBehaviour
	{
		public SkillBar skillBar;
		public int skillId;
		public SkillOperateController select;
		public GuideStepAction_War_UseSkillDragToCircle stepAction;


		public void Set(GuideStepAction_War_UseSkillDragToCircle stepAction)
		{
			if (War.ownLegionData.GetSkillDataBySkillId (stepAction.mdata.skillId) == null)
			{
				stepAction.NextFrameEnd ();
				return;
			}

			this.stepAction = stepAction;
			this.skillId = this.stepAction.mdata.skillId;
			gameObject.SetActive(true);
			StopAllCoroutines();
			StartCoroutine(Check());
		}

		public IEnumerator Check()
		{
			while(true)
			{
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
				yield return new WaitForSeconds(0.5f);
			}
		}

		public void SetMove()
		{
			Vector3 from = select.transform.position;

			Vector3 to = stepAction.mdata.position;
			if (stepAction.mdata.autoPosition) 
			{
				War.scene.SearchCirclePosition (select.data.skillConfig.radius, War.ownLegionID, stepAction.mdata.relation, out to);
			}
			to= to.WorldPosToAnchorPos();
			(transform as RectTransform).anchoredPosition = to;
			to = transform.position;

			Guide.view.screenMask.DrawDragSkillCircle (from, to, select.data.skillConfig.radius);

			Guide.view.moveToPanel.Move(skillId, from, to, select.data.skillConfig.radius, GuideMoveToPanel.ViewType.DragCircle);
		}

		void OnDisable()
		{
			War.signal.sSkillUse -= OnSkillUse;
			StopAllCoroutines();
			Guide.view.moveToPanel.CloseMoveTo(skillId);
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