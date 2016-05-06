using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class SkillUse : EntityMBBehaviour 
	{
		
		public List<OperateAction> operateActionList = new List<OperateAction>();
		public List<OperateAction> waitRemoveOperateActionList = new List<OperateAction>();
		public Transform selectImmediatelyView;
		public SkillOperateSelectCircleView selectCircleView;
		public Transform selectDirectionView;
		public LayerMask terrianLayer;
		public LayerMask uiLayer;

		protected override void OnAwake ()
		{
			base.OnAwake ();
			War.skillUse = this;
		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			UpdateOperate();

			if(Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
			{
//				if(operateActionList.Count > 0)
//				{
					War.sceneData.ownLegion.CancelSkillOperator();
//				}
			}
		}


		void UpdateOperate()
		{
			foreach(OperateAction action in waitRemoveOperateActionList)
			{
				if(operateActionList.Contains(action))
				{
					operateActionList.Remove(action);
				}
			}
			waitRemoveOperateActionList.Clear();
			
			foreach(OperateAction action in operateActionList)
			{
				action.Execute();
			}
		}


		
		public void UseSkill(SkillOperateData skillData)
		{
			if(skillData.relation == RelationType.Own)
			{
				skillData.heroData.legionData.CancelSkillOperator(skillData);

				OperateAction action = null;

				switch(skillData.skillConfig.operate)
				{
				case SkillOperateType.Immediately:
					skillData.OnUse();
					break;
				case SkillOperateType.Passive:
					skillData.OnUse();
					break;
				case SkillOperateType.SelectUnit:
					action = new SelectUnitAction();
					break;
				case SkillOperateType.SelectCircle:
					action = new SelectCircleAction();
					break;
				case SkillOperateType.SelectDirection:
					action = new SelectDirectionAction();
					break;
				}

				
				if(action != null)
				{
					action.skillUse = this;
					action.skillData = skillData;
					action.Enter();
				}
			}
		}

		public void ShowHelp(SkillOperateData skillData)
		{
			if(skillData.relation == RelationType.Own)
			{
				skillData.heroData.legionData.CancelSkillOperator(skillData);
//				skillData.operateState = SkillOperateState.Selected;

				OperateAction action = null;
				
				switch(skillData.skillConfig.operate)
				{
				case SkillOperateType.SelectUnit:
					action = new SelectUnitAction();
					break;
				case SkillOperateType.SelectCircle:
//					action = new SelectCircleAction();
					break;
				case SkillOperateType.SelectDirection:
					action = new SelectDirectionAction();
					break;
				}

				
				if(action != null)
				{
					action.skillUse = this;
					action.skillData = skillData;
					action.Enter();
				}
			}
		}
	}
}
