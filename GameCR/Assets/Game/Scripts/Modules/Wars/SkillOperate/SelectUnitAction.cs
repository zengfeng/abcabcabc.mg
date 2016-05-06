using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Games.Module.Wars
{
	
	public class SelectUnitAction : OperateAction
	{
		public List<UnitCtl> entitys = new List<UnitCtl>();
		public override void Enter ()
		{
//			War.input.Skill();
			updateDealyTime = 0.2F;
			AddToUpdateList();
			AddToVOOperatorList();
			skillData.receiveList.Clear();
		} 
		
		
		public override void OnExecute ()
		{
			List<UnitCtl> entityList = new List<UnitCtl>();


			List<UnitCtl> buildList = War.scene.buildList;
			foreach(UnitCtl entity in buildList)
			{
				if(skillData.EnableUse(entity))
				{
					bool isEnemy = skillData.GetRelation(entity.unitData.legionId) == RelationType.Enemy;
					entity.unitAgent.skillOperateSelectUnitView.Show(skillData.GetSelectUnitIconType(entity, isEnemy), isEnemy, entity.unitData.level);
					entityList.Add(entity);
				}
				else
				{
					entity.unitAgent.skillOperateSelectUnitView.Hide();
				}
			}
			
			entitys = entityList;
			skillData.candidateReceiveCount = entitys.Count;
			skillData.candidateReceiveList = entitys;

//			if(entitys.Count == 0)
//			{
//				Cancel();
//				return;
//			}
		}
		
//		public override void OnExecuteFixed ()
//		{
//			UnitCtl select = CheckMouseDown();
//			if(select != null)
//			{
//				skillData.receiveList.Add(select);
//				Exit();
//			}
//		}
		
		public override void Exit ()
		{
//			War.input.Normal();
			RemoveFromUpdateList();
			RemoveFromVOOperatorList();
			
			foreach(UnitCtl entity in entitys)
			{
				entity.unitAgent.skillOperateSelectUnitView.Hide();
			}
			
			entitys.Clear();
			skillData.OnUse();
		}
		
		public override void Cancel ()
		{
//			War.input.Normal();
			RemoveFromUpdateList();
			RemoveFromVOOperatorList();
			
			foreach(UnitCtl entity in entitys)
			{
				entity.unitAgent.skillOperateSelectUnitView.Hide();
			}
			
			entitys.Clear();
		}
		
		UnitCtl CheckMouseDown()
		{
			if(entitys.Count == 0) return null;
			
			if(Input.GetMouseButtonDown(0))
			{
//				if (EventSystem.current == null || !EventSystem.current.IsPointerOverGameObject())
//				{
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					RaycastHit hit;
					if (Physics.Raycast(ray, out hit))
					{
						foreach(UnitCtl entity in entitys)
						{
							if(entity.gameObject == hit.collider.gameObject)
							{
								return entity;
							}
						}
					}
//				}
			}
			
			return null;
		}
	}
}
