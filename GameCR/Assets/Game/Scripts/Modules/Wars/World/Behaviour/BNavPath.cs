using UnityEngine;
using System.Collections;
using CC.Runtime;
using System.Collections.Generic;
using CC.Runtime.Utils;


namespace Games.Module.Wars
{
	public enum NavPathState
	{
		/** 出生 */
		Outing,
		/** 移动 */
		Moveing,
		/** 围城 */
		Around,
		/** 进城 */
		Ining
	}

	public class BNavPath : EBehaviour
	{
		public NavMeshAgent navMeshAgent;
		public int index = 0;
		public float maxSpeed = 2;
		public float gap = 1;
		public float beginDistance = 4f;
		public float endDistance = 4f;
		private float lengthRadius = 2F;
		public Transform from;
		public Transform to;

		public Vector3 begionTarget = Vector3.zero;
		public Vector3 endTarget = Vector3.zero;
		public NavPathState state;
		public UnitData fromUnitData;
		public UnitData toUnitData;

		public float checkObstacleRadius = 4F;
		public LayerMask obstacleLayer;

		protected override void OnAwake ()
		{
			base.OnAwake ();

			if(navMeshAgent == null) navMeshAgent = GetComponent<NavMeshAgent>();
		}

		protected override void OnStart ()
		{
			base.OnStart ();

		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();

			unitAgent.angel = transform.eulerAngles.y;

//			if(state == NavPathState.Outing)
//			{
//				if(Vector3.Distance(transform.position, begionTarget) < 0.5f)
//				{
//					state = NavPathState.Moveing;
//					navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
//					navMeshAgent.SetDestination(endTarget);
//				}
//			}
//			else if(state == NavPathState.Moveing)
//			{
//				if(Vector3.Distance(transform.position, endTarget) < 0.5f)
//				{
//					state = NavPathState.Around;
//					navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
//					navMeshAgent.SetDestination(to.position);
//				}
//			}

			if(state == NavPathState.Outing)
			{
				if(Vector3.Distance(transform.position, begionTarget) <= unitData.moveSpeed * 0.5f)
				{
					Move();
				}
			}
			else if(state == NavPathState.Moveing)
			{
				bool hasBuild = false;
				foreach(UnitCtl item in War.scene.buildList )
				{
					if(item.transform == from || item.transform == to) continue;

					if(Vector3.Distance(item.transform.position, transform.position) <= checkObstacleRadius)
					{
						hasBuild = true;
					}
				}

				if(hasBuild)
				{
					if(navMeshAgent.obstacleAvoidanceType != ObstacleAvoidanceType.HighQualityObstacleAvoidance)
					{
						navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
					}
				}
				else if(navMeshAgent.obstacleAvoidanceType == ObstacleAvoidanceType.HighQualityObstacleAvoidance)
				{
					navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
				}

//				Vector3 fwd = transform.TransformDirection(Vector3.forward);
//				if (Physics.Raycast(transform.position, fwd, checkObstacleRadius, obstacleLayer))
//				{
//					Debug.Log("Raycast");
//					navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
//				}
//				else
//				{
////					navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
//				}

				if(Vector3.Distance(transform.position, endTarget) <= unitData.moveSpeed * 0.5f)
				{
					if(toUnitData.GetRelation(unitData.legionId) == RelationType.Enemy)
					{
						Around();
					}
					else
					{
						In();
					}
				}
			}
			else if(state == NavPathState.Around)
			{
				if(toUnitData.GetRelation(unitData.legionId) != RelationType.Enemy)
				{
					In();
				}
			}
		}




		public void MoveTo(UnitCtl fromCtl, UnitCtl toCtl)
		{
			fromUnitData = fromCtl.unitData;
			toUnitData = toCtl.unitData;
			this.from = fromCtl.transform;
			this.to = toCtl.transform;
			navMeshAgent.SetDestination(to.position);
			Vector3 fromPoint = from.position;
			Vector3 toPoint = to.position;


			Vector3 direction = (toPoint - fromPoint).normalized * beginDistance;
			
			float radian = HMath.radian(0, 0, direction.x, direction.z);
			radian += Mathf.PI * 0.5F;

			
			direction += fromPoint;
			float x = HMath.radianPointX(radian,gap * index, direction.x);
			float z = HMath.radianPointY(radian, gap * index, direction.z);
			begionTarget.x = x;
			begionTarget.z = z;

			direction = (toPoint - fromPoint).normalized * endDistance;
			radian = HMath.radian(0, 0, direction.x, direction.z);
			radian += Mathf.PI * 0.5F;

			direction = toPoint - direction;
			x = HMath.radianPointX(radian,gap * index, direction.x);
			z = HMath.radianPointY(radian, gap * index, direction.z);
			
			endTarget.x = x;
			endTarget.z = z;

			Out();

		}

		void Out()
		{
			
			state = NavPathState.Outing;
			navMeshAgent.enabled = true;
			navMeshAgent.speed = unitData.moveSpeed;
			navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
			navMeshAgent.SetDestination(begionTarget);

//			iTween.MoveTo(gameObject,iTween.Hash("islocal", false, "position", begionTarget,"time", (unitData.moveSpeed > 0 ? beginDistance / unitData.moveSpeed * 3f : 2F),
//			                                     "oncomplete", "OnOutComplete", "oncompletetarget", gameObject));
		}

		void OnOutComplete()
		{
			Move();
		}

		void Move()
		{
			
			state = NavPathState.Moveing;
			navMeshAgent.enabled = true;
			navMeshAgent.speed = unitData.moveSpeed;
			navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
			navMeshAgent.SetDestination(endTarget);
		}

		void Around()
		{
			state = NavPathState.Around;
			navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
			navMeshAgent.SetDestination(to.position);
			toUnitData.aroundList.Add(unitData);
		}

		public void In()
		{
			if(toUnitData.aroundList.Contains(unitData))
			{
				toUnitData.aroundList.Remove(unitData);
			}
			
			state = NavPathState.Ining;
			navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
			navMeshAgent.SetDestination(to.position);
//			navMeshAgent.enabled = false;
//			iTween.MoveTo(gameObject,iTween.Hash("islocal", false, "position", to.position,"time", (unitData.moveSpeed > 0 ? endDistance / unitData.moveSpeed : 2F),
//			                                     "oncomplete", "OnOInComplete", "oncompletetarget", gameObject));
		}

		void OnOInComplete()
		{
//			BMoveArrived moveArrive = GetComponent<BMoveArrived>();
//			moveArrive.OnSteeringRequestSucceeded();
		}

		void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			Gizmos.DrawRay(transform.position, fwd);
		}
	}
}
