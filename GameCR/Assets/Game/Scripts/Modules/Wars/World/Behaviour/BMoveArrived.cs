using UnityEngine;
using System.Collections;
using CC.Runtime.Actions;
using CC.Runtime.signals;
using RayPaths;


namespace Games.Module.Wars
{
	public class BMoveArrived : EBehaviour
	{
		public DelayDestory delayDestory;
		public SteeringAgentComponent steeringAgentComponent;
		public Rigidbody rigibody;
		public UnitPath unitPath;
		public void OnSteeringRequestSucceeded()
		{
			if(unitPath && unitPath.state == UnitPathState.Die) return;
			RelationType relation = unitData.GetRelation(unitData.to.legionId);
			if(relation == RelationType.Enemy)
			{
				if(unitPath.needAround)
				{
					if(unitPath.state == UnitPathState.Ining)
					{
						unitPath.HitFly();
					}
				}
				else
				{
					unitData.to.unit.GetComponent<BBuildShake>().Play();
					Die();
				}
			}
			else
			{
				delayDestory = GetComponent<DelayDestory>();
				if(unitData != null && unitData.to != null)
				{
//					War.textEffect.PlayHP(unitData.hp, unitData.to.unit);
					unitData.to.hp += unitData.hp;
				}

				
				SoliderPoolItem soliderPoolItem = GetComponent<SoliderPoolItem>();
				if(soliderPoolItem != null)
				{
					soliderPoolItem.Release();
				}
				else
				{
					delayDestory.delayTime = 0F;
					delayDestory.enabled = true;
				}
			}

		}

		public void Die()
		{
			unitData.death = true;
			
			RelationType relation = unitData.GetRelation(unitData.to.legionId);
			if(relation != RelationType.Enemy)
			{
				
				unitData.to.hp += unitData.hp;
//				Debug.Log("<color=red>BMoveArrived.Die relation != RelationType.Enemy</color>");
			}
			else
			{
				unitData.to.BehitForUnit(unitData);
			}

//            GameObject effectPrefab = WarRes.GetPrefab(WarRes.effect_soldier_one_die);
//            GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
//            effectAnim.transform.position = unitData.unit.unitCtl.transform.position;
//            DelayDestory destoryTimer = effectAnim.GetComponent<DelayDestory>();
//            if (destoryTimer != null)
//            {
//                destoryTimer.DelayTime = 2.0f;
//            }
		}



		protected override void OnStart ()
		{
			base.OnStart ();

			unitPath = GetComponent<UnitPath>();
			steeringAgentComponent = GetComponent<SteeringAgentComponent>();
			rigibody = GetComponent<Rigidbody>();
			_moveSpeed = unitData.moveSpeed;
		}

		private bool _freezed;
		private float _moveSpeed;
		private bool _isArrived;
		protected override void OnUpdate ()
		{
			base.OnUpdate ();

//			if(_isArrived == false && Vector3.Distance(transform.position, unitData.to.position) < 1f)
//			{
//				OnSteeringRequestSucceeded();
//				_isArrived = true;
//			}

//			if(_freezed != unitData.freezedMoveSpeed)
//			{
//				_freezed = unitData.freezedMoveSpeed;
//				if(steeringAgentComponent != null)
//				{
//					if(_freezed)
//					{
//						steeringAgentComponent.enabled = false;
//						rigibody.velocity = Vector3.zero;
//					}
//					else
//					{
//						steeringAgentComponent.enabled = true;
//					}
//
//				}
//			}

//			if(_moveSpeed != unitData.moveSpeed)
//			{
//				_moveSpeed = unitData.moveSpeed;
//				steeringAgentComponent.m_maxSpeed = unitData.moveSpeed;
//			}
		}

		/** 继续 */
		public void Resume()
		{
			steeringAgentComponent.enabled = true;
		}
		
		/** 暂停 */
		public void Pause()
		{
			steeringAgentComponent.enabled = false;
			rigibody.velocity = Vector3.zero;
		}

	}
}