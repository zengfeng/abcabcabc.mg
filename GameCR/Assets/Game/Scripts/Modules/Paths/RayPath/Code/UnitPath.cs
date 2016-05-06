using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using System.Collections.Generic;
using zfpaths;
using Games.Module.Wars;

namespace RayPaths
{
	public enum UnitPathState
	{
		None,
		/** 移动 */
		Moveing,
		/** 围城 */
		Around,
		AroundAtk,
		/** 进城 */
		Ining,
		/** 进城 */
		Die
	}

	public class UnitPath : EBehaviour 
	{
		public bool needAround = false;
		public UnitPathState state;
		public int index = 0;
		public float maxSpeed = 2F;
		public Path path;
		public float aroundRadius = 4f;
		public float aroundAtkRadius = 1.5f;
		public Vector3 aroundPoint;
		
		public float dieTimeMax = 3f;
		public float dieTime = 0f;
		
		public Rigidbody rigibody;
		public PathAgentComponent 				m_pathAgent;
		public SteeringAgentComponent 			m_steeringAgent;
		private float _moveSpeed;
		private bool _freezed;
		private float _distanceFrom = 0f;
		public UnitCtl from;
		public UnitCtl to;

		protected override void OnAwake ()
		{
			base.OnAwake ();
			
			m_pathAgent = GetComponent<PathAgentComponent>();
			m_steeringAgent = GetComponent<SteeringAgentComponent>();
			rigibody = GetComponent<Rigidbody>();
		}

	

		public void OnSpeedChange()
		{
			if(_moveSpeed == 0 || path == null) return;

			float timeTotal0 = path.s0 / _moveSpeed;
			float speed = path.s / timeTotal0;

			m_steeringAgent.m_maxSpeed = speed;
//			m_steeringAgent.m_slowingDistance = speed * 0.5f ;
//			if(m_steeringAgent.m_slowingDistance < 0.5f) m_steeringAgent.m_slowingDistance = 0.5f;

//			m_steeringAgent.m_arrivalDistance = 0.5F * speed / 2F > 2f ? 2F : 0.5F * speed / 2F;
//			if(m_steeringAgent.m_arrivalDistance < 1f) m_steeringAgent.m_arrivalDistance = 1F;

//			m_steeringAgent.m_slowingDistance = 0.5f;
//			m_steeringAgent.m_arrivalDistance = 1f;

			aroundAtkRadius = speed * 1.2f;
		}

		public void SetPath(Path path)
		{
			if(unitData== null)
			{
//				OnRelease();
//				SoliderPoolItem soliderPoolItem = GetComponent<SoliderPoolItem>();
//
//				Debug.LogErrorFormat("<color=red>SetPath unitData=null  gameObject={0},  gameObject.activeSelf={1}  isRelease={2}, isPut={3}, needRest={4}</color>", gameObject, gameObject.activeSelf, soliderPoolItem.isRelease, soliderPoolItem.isPut, soliderPoolItem.needRest);
				return;
			}

			
			if(m_steeringAgent == null)
			{
				m_pathAgent = GetComponent<PathAgentComponent>();
				m_steeringAgent = GetComponent<SteeringAgentComponent>();
				rigibody = GetComponent<Rigidbody>();
			}

			from = unitData.from.unit;
			to = unitData.to.unit;

			state = UnitPathState.Moveing;
			this.path = path;
			path.unitPath = this;

//			float timeTotal0 = path.s0 / maxSpeed;
//			float speed = path.s / timeTotal0;
			
			_moveSpeed = unitData.moveSpeed;

//			m_steeringAgent.m_maxSpeed = speed;
//			m_steeringAgent.m_slowingDistance = speed / 2F;
//			m_steeringAgent.m_arrivalDistance = 0.5F * speed / 2F > 2f ? 2F : 0.5F * speed / 2F;
//			if(m_steeringAgent.m_arrivalDistance < 0.5) m_steeringAgent.m_arrivalDistance = 0.5F;

			//TODO
			OnSpeedChange();


//			m_steeringAgent.SteerAlongPath( path.points.ToArray(), m_pathAgent.PathManager.PathTerrain );
			m_steeringAgent.SteerAlongPath( path.points.ToArray(), null );
		}

		public void SetAroundPoint(Vector3 point, Vector3 buildPoint)
		{
			state = UnitPathState.Around;
			aroundPoint = point;
			Vector3 d1 = point - buildPoint;
			Vector3 d2 = transform.position - buildPoint;
			float d = Vector3.Dot(d1.normalized, d2.normalized);
//			Debug.Log("SetAroundPoint point=" + point + "  d=" + d);

			Vector3[] points = null;
			if(d < 0)
			{
				Vector3 inPoint = HMath.IntersectionPoint(buildPoint, transform.position, point);
				Vector3 p = buildPoint + (inPoint - buildPoint).normalized * aroundRadius;
				points = new Vector3[]{transform.position, p, point}; 
			}
			else
			{
				points = new Vector3[]{transform.position, point}; 
			}
			aroundPoints = points;


//			m_steeringAgent.SteerAlongPath(points, m_pathAgent.PathManager.PathTerrain );
			m_steeringAgent.SteerAlongPath(points, null );
		}

		public void  BackHome()
		{
			if(state == UnitPathState.Die) return;

			state = UnitPathState.Moveing;
			Vector3[] points = new Vector3[]{transform.position, unitData.from.unit.transform.position};
			state = UnitPathState.Ining;
			if(unitData.to.aroundList.Contains(unitData))
			{
				unitData.to.aroundList.Remove(unitData);
			}
			
			if(unitData.to != null) unitData.to.RemoveFromLegionUnit(unitData.legionId, 1);

			unitData.to = unitData.from;
			unitData.to.AddFromLegionUnit(unitData.legionId, 1);
//			m_steeringAgent.SteerAlongPath(points, m_pathAgent.PathManager.PathTerrain );
			m_steeringAgent.SteerAlongPath(points, null );
		}

		public void In(bool isEnemy = true)
		{
			if(unitData == null) return;
			if(unitData.to.aroundList.Contains(unitData))
			{
				unitData.to.aroundList.Remove(unitData);
			}
			
			state = UnitPathState.Ining;


			if(isEnemy == false)
			{
//				m_steeringAgent.SteerAlongPath(new Vector3[]{transform.position, unitData.to.unit.transform.position}, m_pathAgent.PathManager.PathTerrain );
				m_steeringAgent.SteerAlongPath(new Vector3[]{transform.position, unitData.to.unit.transform.position}, null );
			}
			else
			{
				HitFly();
			}

		}

		public void HitFly()
		{
			state = UnitPathState.Die;
			//unitData.isHitFly = true;
//			unitData.hitFlyPoint = unitData.to.unit.transform.position;
//			unitAgent.HitFly();
			GetComponent<BMoveArrived>().Die();
		}


		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			if (state == UnitPathState.None) 
			{
				return;
			}

			if(needAround)
			{
				if(state == UnitPathState.Moveing)
				{
					RelationType relation = unitData.GetRelation(unitData.to.legionId);
					if(relation == RelationType.Enemy)
					{
						path.group.Around(unitData, transform.position);
					}
				}
				else if(state == UnitPathState.Around)
				{
					
					if(Vector3.Distance(transform.position, aroundPoint) < aroundAtkRadius)
					{
						state = UnitPathState.AroundAtk;
						unitAgent.action = "attack";
						
						unitData.to.aroundList.Add(unitData);
					}
				}
			}


			if(_freezed == false)
			{
				if(_distanceFrom <= 5)
				{
					_distanceFrom = Vector3.Distance(transform.position, unitData.from.unit.transform.position);
				}

				if(_distanceFrom > 5)
				{
					unitAgent.angel = HMath.AngleBetweenForward2Vector(rigibody.velocity);
				}
			}


			if(state == UnitPathState.Moveing || state == UnitPathState.Around)
			{
				unitAgent.anchorAngle.eulerAngles = new Vector3(0f, unitAgent.angel, 0f);
			}
			else if(state == UnitPathState.AroundAtk)
			{
				Vector3 pos = transform.position;
				Vector3 o = unitData.to.unit.transform.position;
				unitAgent.angel = HMath.angle(pos.z, pos.x, o.z, o.x);
			}

			if(state == UnitPathState.Around || state == UnitPathState.AroundAtk)
			{
				RelationType relation = unitData.GetRelation(unitData.to.legionId);
				if(relation != RelationType.Enemy)
				{
					In(false);
				}
			}

			if(unitData != null)
			{
				
				if(_moveSpeed != unitData.moveSpeed)
				{
					_moveSpeed = unitData.moveSpeed;
					//TODO 查询路线BUG
					OnSpeedChange();
				}

				if(_freezed != unitData.freezedMoveSpeed)
				{
					_freezed = unitData.freezedMoveSpeed;

					if(_freezed)
					{
						m_steeringAgent.enabled = false;
						rigibody.velocity = Vector3.zero;
					}
					else
					{
						m_steeringAgent.enabled = true;
					}
				}

				if(_freezed)
				{
					if(unitAgent.action != "die")
					{
						unitAgent.speed = 0;
					}
					else
					{
						unitAgent.speed = 1;
					}
				}
				else
				{
					if(unitAgent.action == "walk" && unitData.moveSpeed <= 0)
					{
						unitAgent.speed = 0;
					}
					else
					{
						unitAgent.speed = 1;
					}
				}

			}


			if(state == UnitPathState.Die)
			{
				dieTime += Time.deltaTime;
				if(transform.position.y < -1 || dieTime > dieTimeMax)
				{
					War.hunManager.Play(unitCtl.unitData.colorId, transform.position.SetY(0));
					
					SoliderPoolItem soliderPoolItem = GetComponent<SoliderPoolItem>();
					if(soliderPoolItem != null)
					{
						soliderPoolItem.Release();
					}
					else
					{
						DestroyObject(gameObject);
					}
				}
			}
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();
			OnRelease();
		}

		
		public override void OnRelease ()
		{
			base.OnRelease ();
			state = UnitPathState.None;
			_freezed = false;

			if(rigibody != null)
			{
				rigibody.velocity = Vector3.zero;
				rigibody.useGravity = false;
				m_steeringAgent.StopSteering();
				m_steeringAgent.enabled = true;
			}

			if(path != null) path.OnDestroy();
			path = null;
			dieTime = 0;
			_distanceFrom = 0;
			
			transform.position = new Vector3(-1000, 0f, -1000);
		}
		
		public void OnRest ()
		{
			if(rigibody != null)
			{
				path = null;
				_freezed = false;
				rigibody.velocity = Vector3.zero;
				rigibody.useGravity = false;
				m_steeringAgent.enabled = true;
				m_steeringAgent.StopSteering();
			}
			
		}

		public Vector3[] aroundPoints;
		public void OnDrawGizmos()
		{
			
			for(int i = 0; i < aroundPoints.Length; i ++)
			{
				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere(aroundPoints[i], 0.1f);
				
				if(i < aroundPoints.Length - 1)
				{
					Gizmos.color = Color.red;
					Gizmos.DrawLine(aroundPoints[i], aroundPoints[i + 1] );
				}
			}
		}

	}
}
