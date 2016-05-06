using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.Utils;

namespace RayPaths
{
	public class RayPath : MonoBehaviour {
		public LayerMask layerMask;
		public Transform target;
		public UnitPathGroup pathGroup;
		public UnitNavigationAgentComponent navigationAgent;
		void Awake ()
		{
			if(pathGroup == null) pathGroup = GetComponent<UnitPathGroup>();
			if(navigationAgent == null) navigationAgent = GetComponent<UnitNavigationAgentComponent>();
		}
		
		List<Vector3> paths;

		public void MoveTo(Transform target)
		{
			List<Vector3> paths;
			if(To(target, out paths))
			{
				pathGroup.SetPath(paths.ToArray(), true);
			}
			else
			{
				navigationAgent.MoveToPosition(target.position);
			}
			this.paths = paths;
		}
		
		private Transform _target;
		private Vector3 _begin;
		private Vector3 _end;
		private bool To(Transform target, out List<Vector3> paths)
		{
			_target = target;
			_begin = transform.position;
			_end = target.position;

			List<Vector3> points ;

			if(Find(_begin, out points))
			{
				paths = new List<Vector3>();
				paths.Add(_begin);

				for(int i = 0; i < points.Count; i ++)
				{
					paths.Add(points[i]);
				}
				return true;
			}
			else
			{
				paths = null;
				return false;
			}
		}

		private bool Find(Vector3 from, out List<Vector3> paths)
		{
			bool enable = true;
			paths = new List<Vector3>();
			RayAgentData data = new RayAgentData ();
			data.Position = from;
			RayAgentHitInfo hitInfo;
			RayAgentHitInfo hitInfo2;
			RayAgentHitInfo hitInfo3;
			if(FindNearestObstade(data, _end, out hitInfo, 100F, false))
			{
				Vector3 hitPoint = Extended(hitInfo.hitpoint, _begin);
				int index;
				Vector3 obstacleAnchor = hitInfo.obstacle.FindAnchor(hitPoint, out index);
				
				bool hasAnchor = false;
				Vector3 anchor = obstacleAnchor;
				int anchorIndex = index;
				
				int index2 = -1;
				if(AnchorHit(hitPoint, obstacleAnchor))
				{
					Vector3 obstacleAnchor2 = hitInfo.obstacle.FindAnchor2(hitPoint, index, out index2);
					if(AnchorHit(hitPoint, obstacleAnchor2))
					{
						hasAnchor = false;
						//A*
						enable = false;
						return enable;
					}
					else
					{
						anchorIndex = index2;
						anchor = obstacleAnchor2;
						hasAnchor = true;
					}
					
	//				Gizmos.color = Color.cyan * 0.5F;
	//				Gizmos.DrawWireSphere(obstacleAnchor2, 0.2F);

				}
				else
				{
					anchor = obstacleAnchor;
					hasAnchor = true;
				}
				
	//			Gizmos.color = Color.green * 0.5F;
	//			Gizmos.DrawWireSphere(hitInfo.hitpoint, 0.1F);
	//			
	//			Gizmos.color = Color.green;
	//			Gizmos.DrawWireSphere(hitPoint, 0.1F);
	//
	//			
	//			Gizmos.color = Color.cyan;
	//			Gizmos.DrawWireSphere(obstacleAnchor, 0.2F);
				
				if(hasAnchor)
				{
					data.Position = anchor;
					if(FindNearestObstade(data, _end, out hitInfo2, 100F, false))
					{
						if(hitInfo2.hit.transform == hitInfo.hit.transform)
						{
							Vector3 obstacleAnchor3 = hitInfo.obstacle.FindAnchor3(hitPoint, anchorIndex);
							
							
							data.Position = obstacleAnchor3;
							if(FindNearestObstade(data, _end, out hitInfo3, 100F, true))
							{
								if(hitInfo3.hit.transform != hitInfo.hit.transform)
								{
									
									paths.Add(hitPoint);
									paths.Add(anchor);
									paths.Add(obstacleAnchor3);

									List<Vector3> points;
									if(Find(obstacleAnchor3, out points))
									{
										for(int i = 0; i < points.Count; i ++)
										{
											paths.Add(points[i]);
										}
									}
									else
									{
										enabled = false;
										return enabled;
									}
								}
								else
								{
									enabled = false;
									return enabled;
	//								paths.Add(hitPoint);
	//								paths.Add(anchor);
	//								paths.Add(obstacleAnchor3);
									//A*
								}
							}
							else
							{
								paths.Add(hitPoint);
								paths.Add(anchor);
								paths.Add(obstacleAnchor3);
								paths.Add(_end);
							}
							
						}
						else
						{
							paths.Add(hitPoint);
							paths.Add(anchor);

							List<Vector3> points;
							if(Find(anchor, out points))
							{
								for(int i = 0; i < points.Count; i ++)
								{
									paths.Add(points[i]);
								}
							}
							else
							{
								enabled = false;
								return enabled;
							}
						}
					}
					else
					{
						paths.Add(hitPoint);
						paths.Add(anchor);
						paths.Add(_end);
					}
				}
				
			}
			else
			{
				paths.Add(_end);
			}

			
			return enabled;
		}



		bool AnchorHit(Vector3 from, Vector3 to)
		{
			
			bool hasHit = false;
			RayAgentData data = new RayAgentData ();
			data.Position = from;
			data.radius *= 0.9F;

			float distance = Vector3.Distance (from, to) + extended;

			RayAgentHitInfo hitInfo;
			if (FindNearestObstade (data, to,out hitInfo, distance, false)) 
			{
				hasHit = true;
			}
			return hasHit;
		}


		bool FindNearestObstade(RayAgentData data, Vector3 target, out RayAgentHitInfo hitInfo,  float distance, bool onlyCenter)
		{
			hitInfo = null;
			bool hasHit = false;
			float minDistance = Vector3.Distance (data.Position, target);
			Vector3 direction = target - data.Position;
			data.SetDirection (direction);

			Vector3[] anchors = data.Anchors;
			RaycastHit hit;
			for(int i = 0; i < anchors.Length; i ++)
			{
				if(onlyCenter)
				{
					if( i != (int)RayAgentPos.Center)
					{
						continue;
					}
				}

				if (Physics.Raycast (anchors[i], direction, out hit, distance, layerMask.value)) 
				{
					if(hit.transform == _target) continue;
					ObstacleBox obstacle = hit.transform.GetComponent<ObstacleBox>();
					if(obstacle != null)
					{
						if(hit.distance < minDistance)
						{
							minDistance = hit.distance;
							
							if(hitInfo == null) hitInfo = new RayAgentHitInfo();
							hitInfo.hit = hit;
							hitInfo.obstacle = obstacle;
							hitInfo.pos = (RayAgentPos) i;
							hitInfo.hitpoint = hit.point;
							if(hitInfo.pos == RayAgentPos.Right)
							{
								hitInfo.hitpoint += (data.Position - data.Right).normalized * data.radius;
							}
							else if(hitInfo.pos == RayAgentPos.Right)
							{
								hitInfo.hitpoint += (data.Position - data.Left).normalized * data.radius;
							}
							hasHit = true;
						}
					}
				}
			}

			return hasHit;
		}

		
		private float extended = 1F;
		Vector3 Extended(Vector3 from, Vector3 to)
		{
			Vector3 point = Vector3.zero;
			point.x = HMath.directionPointX(from.x, from.z, to.x, to.z, extended);
			point.z = HMath.directionPointY(from.x, from.z, to.x, to.z, extended);
			return point;
		}

		
		void OnDrawGizmos()
		{

			if(paths == null)
			{
				return;
			}

			for(int i = 0; i < paths.Count - 1; i++)
			{
				Gizmos.color = Color.yellow;
				Gizmos.DrawLine(paths[i], paths[i+1]);
			}
			
			for(int i = 1; i < paths.Count - 1; i++)
			{
				Gizmos.color = Color.gray;
				Gizmos.DrawWireSphere(paths[i], 0.2F);
			}
			
			if(paths.Count > 0)
			{
				Gizmos.color = Color.green;
				Gizmos.DrawWireSphere(paths[0], 0.2F);
			}
			
			
			if(paths.Count > 1)
			{
				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere(paths[paths.Count - 1], 0.2F);
			}
		}
	}
}
