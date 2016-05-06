using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.Utils;
using UnityEngine.EventSystems;


namespace Games.Module.Wars
{
	public class SelectDirectionAction : OperateAction
	{
		public bool isDown;
		public bool isUpdateDirection;
		public Vector3 point;
		public override void Enter ()
		{
			War.input.Skill();
			AddToVOOperatorList();
			AddToUpdateList();

			Vector3 point = skillData.heroData.unit.transform.position;
			point.y = 0.1F;
			skillUse.selectDirectionView.position = point;
//			skillUse.selectDirectionView.eulerAngles = Vector3.zero;
			skillUse.selectDirectionView.LookAt(Vector3.zero);
			skillUse.selectDirectionView.GetComponent<SkillOperateSelectDirectionView>().Width = skillData.skillConfig.radius;
			skillUse.selectDirectionView.GetComponent<SkillOperateSelectDirectionView>().Distance = skillData.skillConfig.distance;
			skillUse.selectDirectionView.gameObject.SetActive(true);

			isUpdateDirection = false;

			if(War.config.PCOperater)
			{
				#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX
				isUpdateDirection = true;
				SetDirection();
				#endif
			}
		}

		public override void OnExecuteFixed ()
		{
			base.OnExecuteFixed ();
			if(!isDown && Input.GetMouseButtonDown(0) )
			{
				if(!War.input.HitUI)
				{
					isDown = true;
					isUpdateDirection = true;
				}
			}

			if(isUpdateDirection)
			{
				SetDirection();

				if(isDown && Input.GetMouseButtonUp(0))
				{
					isDown = false;
					skillData.receivePosition = point;
					skillData.receiveDirection = point - skillUse.selectDirectionView.position;
					skillData.receiveDirection.Normalize();
					Exit();
				}
			}
		}

		void SetDirection()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 300, skillUse.terrianLayer.value))
			{
				point = hit.point;
				point.y = 0.1F;
				
				skillUse.selectDirectionView.LookAt(point);
			}

		}


		
		public override void Exit ()
		{
			War.input.Normal();
			skillData.OnUse();
			RemoveFromUpdateList();
			RemoveFromVOOperatorList();
			
			skillUse.selectDirectionView.gameObject.SetActive(false);
		}
		
		public override void Cancel ()
		{
			War.input.Normal();
			RemoveFromUpdateList();
			RemoveFromVOOperatorList();
			
			skillUse.selectDirectionView.gameObject.SetActive(false);
		}
	}
}