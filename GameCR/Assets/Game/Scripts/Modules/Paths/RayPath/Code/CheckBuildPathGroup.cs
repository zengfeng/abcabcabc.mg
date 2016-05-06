using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.Utils;
using Games.Module.Wars;
using RayPaths;


namespace zfpaths
{
	
	public class Path
	{
		public PathGroup group;
		public UnitPath unitPath;
		public int index = 0;
		public float gap = 1;
		public float turnGap = 1;
		public float lengthRadius = 2f;
		public List<Vector3> points = new List<Vector3>();
		public List<Vector3> list = new List<Vector3>();
		public GameObject hit;
		
		public float s0 = 0;
		
		private float _s = -1;
		public float s
		{
			get
			{
				if(_s <=0)
				{
					_s = 0;
					for(int i = 0; i < points.Count - 1; i ++)
					{
						_s += Vector3.Distance(points[i], points[i + 1]);
					}
				}
				return _s;
			}
		}


		
		public Path Clone()
		{
			Path path = new Path();
			path.index = index;
			path.gap = gap;
			path.turnGap = turnGap;
			path.lengthRadius = lengthRadius;
			path.points = points;
			path._s = _s;
			path.s0 = s0;

			return path;
		}
		
		public void SetPath(List<Vector3> paths)
		{
			List<Vector3> list = new List<Vector3>();
			
			if(paths.Count >= 2)
			{
				Vector3 p1 = paths[0];
				Vector3 p2 = paths[1];
				float distance = Vector3.Distance(p1, p2);
				Vector3 p3 = Vector3.zero;
				int add = 0;
				bool begin = false;
				bool end = false;
				if(distance > 1F)
				{
					p3.x = HMath.directionPointX(p1.x, p1.z, p2.x, p2.z, lengthRadius);
					p3.z = HMath.directionPointY(p1.x, p1.z, p2.x, p2.z, lengthRadius);
					add +=1;
					begin = true;
				}
				
				p1 = paths[paths.Count - 1];
				p2 = paths[paths.Count - 2];
				distance = Vector3.Distance(p1, p2);
				Vector3 p4 = Vector3.zero;
				if(distance > 1F)
				{
					p4.x = HMath.directionPointX(p1.x, p1.z, p2.x, p2.z, lengthRadius);
					p4.z = HMath.directionPointY(p1.x, p1.z, p2.x, p2.z, lengthRadius);
					add +=1;
					end = true;
				}
				

				for(int i = 0; i < paths.Count; i ++)
				{
					list.Add(paths[i]);
					if(add > 0)
					{
						if(i == 0 && begin)
						{
							list.Add(p3);
						}
						
						if(i == paths.Count - 2 && end)
						{
							list.Add(p4);
						}
					}
				}

				
				
			}


			for(int i = 0; i < list.Count; i ++)
			{
				Vector3 source = list[i];
				Vector3 pos = new Vector3(source.x, source.y, source.z);

				if(i != 0 && i != list.Count -1 )
				{
					float myGap = gap;
//					if(i > 1 && i < list.Count - 2)
//					{
//						myGap = turnGap;
//					}

					if(list.Count > 4 && i < list.Count - 1)
					{
						myGap = turnGap;
					}

					Vector3 d1 = pos - list[i - 1];
					Vector3 d2 = list[i + 1] - pos;
					Vector3 d = d1.normalized + d2.normalized;
					float radian = HMath.radian(0, 0, d.x, d.z);
					radian += Mathf.PI * 0.5F;
					
					float x = HMath.radianPointX(radian,myGap * index, pos.x);
					float z = HMath.radianPointY(radian, myGap * index, pos.z);
					pos.x = x;
					pos.z = z;
					
				}
				this.list.Add(pos);
			}
			
			

		}


		public void OnDestroy()
		{
			group.Remove(this);
		}



		public void OnDrawGizmos()
		{
			for(int i = 0; i < list.Count; i ++)
			{
				Gizmos.color = Color.white;
				Gizmos.DrawWireSphere(list[i], 0.1f);
				
				if(i < list.Count - 1)
				{
					Gizmos.color = Color.white;
					Gizmos.DrawLine(list[i], list[i + 1] );
				}
			}

			for(int i = 0; i < points.Count; i ++)
			{
				Gizmos.color = Color.yellow;
				Gizmos.DrawWireSphere(points[i], 0.1f);
				
				if(i < points.Count - 1)
				{
					Gizmos.color = Color.yellow;
					Gizmos.DrawLine(points[i], points[i + 1] );
				}
			}
		}
	}

	public class PathGroup
	{
		
		public float gap = 1f;
		public int pathNum = 8;
		public float lengthRadius = 2f;
		public float hitRadiusMultiply = 1.5f;
		public float hitRadiusMultiplyVertical = 1f;
		public LayerMask buildLayer;
		public List<Vector3> points = new List<Vector3>();
		public List<Path> paths = new List<Path>();
		public bool hasSetAround = false;
		public float aroundRadius= 6f;
		public AroundPart aroundPart;

		
		
		public PathGroup Clone(int pathNum)
		{
			PathGroup group = new PathGroup();
			group.gap = gap;
			group.pathNum = pathNum;
			group.lengthRadius = lengthRadius;
			group.hitRadiusMultiply = hitRadiusMultiply;
			group.buildLayer = buildLayer;
			group.points = points;
			float s0 = 0;
			for(int i = 0; i < pathNum; i ++)
			{
				Path path = paths[i].Clone();
				if(i == 0) s0 = path.s;

				path.group = group;
				path.s0 = s0;
				group.paths.Add(path);
			}

			return group;
		}

		public void Remove(Path path)
		{
			if(aroundPart != null)aroundPart.Remove(1);
			if(paths.Contains(path)) paths.Remove(path);
		}

		public Vector3 GetAroundPoint()
		{
			return paths[0].points[points.Count - 2];
		}

		public void Around(UnitData soliderUnitData, Vector3 position)
		{
			if(hasSetAround) return;

			
			UnitCtl build = soliderUnitData.to.unit;
			BAroundBuild aroundBuild = build.GetComponent<BAroundBuild>();
			Vector3 buildPosition = build.transform.position;
			float distance = Vector3.Distance(position, buildPosition);
			if(distance <= aroundRadius)
			{
				Vector3 p = GetAroundPoint();
				List<Vector3> aroundPoints = aroundBuild.FindPoints(p, paths.Count, out aroundPart);
				float dot = Vector3.Dot((aroundPart.center - buildPosition).normalized, (position - buildPosition).normalized);


				paths.Sort(delegate(Path a, Path b) { return dot > 0 ? a.index - b.index : b.index - a.index; }); 

				for(int i = 0; i < paths.Count; i ++)
				{
					if(paths[i].unitPath != null) paths[i].unitPath.SetAroundPoint(aroundPoints[i], buildPosition);
				}
				hasSetAround = true;
			}
		}

		public void Synchronous(float delayTime, MonoBehaviour mono)
		{
			mono.StartCoroutine(OnSynchronous(delayTime));
		}

		
		IEnumerator OnSynchronous(float delayTime)
		{
			yield return new WaitForSeconds(delayTime);
			for(int i = 0; i < paths.Count; i ++)
			{
				if(paths[i].unitPath != null)
				{
					paths[i].unitPath.unitAgent.Synchronous();
				}
				else
				{
					Debug.LogFormat("paths[{0}].unitPath=null", i);
				}
			}
		}

		
//		/** 检测寻路点在建筑位置的 */
//		public void CheckPathInBuild()
//		{
//			List<UnitCtl> buildList = War.scene.buildList;
//			int buildCount = 0;
//
//			for(int i = 1; i < points.Count - 1; i ++)
//			{
//				Vector3 p = points[i];
//				for(int buildIndex = 0; buildIndex < buildCount; buildIndex ++)
//				{
//					float distance = Vector3.Distance(p, buildList[buildIndex]);
//					if(distance < 2f)
//					{
//						Vector3 p1 = list[i -1];
//						Vector3 p2 = list[i];
//
//						p = p2 - (p2 - p1).normalized * 2f;
//					}
//				}
//
//			}
//		}

		/** 生成子路线 */
		public void GenerationSubPaths()
		{
			paths.Clear();

			for(int i = 0; i < pathNum; i ++)
			{
				int pathIndex = (int)((i + 1) / 2) * (i % 2 == 0 ? 1 : -1);
				Path path = new Path();
				path.index = pathIndex;
				path.gap = gap;
				path.turnGap = 4f / pathNum;
				path.lengthRadius = lengthRadius;
				path.SetPath(points);
				path.group = this;
				paths.Add(path);
			}
		}

		/** 检测建筑障碍 */
		public void CheckBuild()
		{
			if(paths.Count == 0) return;

			int listCount = paths[0].list.Count;
			for(int i = 0; i < listCount; i ++)
			{

				bool hasHit = false;
				float minHitDistance = 9999;
				RaycastHit hitInfo = new RaycastHit();
				
				float radius = 1f;
				Vector3 pos = Vector3.zero;

				// 查找最近的碰撞体
				foreach(Path path in paths)
				{
					List<Vector3> list = path.list;
					List<Vector3> points = path.points;
					path.hit = null;
					
					points.Add(list[i]);
					if(i == 0) continue;
					
					
					
					if(i < listCount - 2)
					{
						Vector3 p1 = list[i];
						Vector3 p2 = list[i + 1];
						
						
						RaycastHit _hitInfo;
						if (Physics.Linecast(p1, p2, out _hitInfo, buildLayer.value)  ) 
						{
							path.hit = _hitInfo.collider.gameObject;
							pos = _hitInfo.collider.transform.position;
							float hitDistance = Vector3.Distance(paths[0].list[i], pos);
							
							radius = (_hitInfo.collider as SphereCollider).radius * _hitInfo.collider.transform.lossyScale.x;
							if(hitDistance <= radius * hitRadiusMultiply ||  Vector3.Distance(paths[0].list[i + 1], pos) <= radius * hitRadiusMultiply)
							{
								continue;
							}

							if(hasHit == false)
							{
								hasHit = true;
								hitInfo = _hitInfo;
								minHitDistance = hitDistance;
							}
							else if(hitDistance <= minHitDistance)
							{
								hitInfo = _hitInfo;
								minHitDistance = hitDistance;
							}
						}
					}
					
				}

				
				int hL = -100;
				int hR = 100;

				//查找hL、hR
				if(hasHit)
				{
					
					radius = (hitInfo.collider as SphereCollider).radius * hitInfo.collider.transform.lossyScale.x;
					pos = hitInfo.collider.transform.position;

					foreach(Path path in paths)
					{
						if(path.hit == null) continue;
						if(path.hit != hitInfo.collider.gameObject) continue;

						int index = path.index;
						int myIndex = index;

						
						List<Vector3> list = path.list;
						List<Vector3> points = path.points;
						
						
						Vector3 p1 = list[i];
						Vector3 p2 = list[i + 1];

						Vector3 d0 = p2 - p1;
						Vector3 d1 = pos - p1;
						Vector3 cross = Vector3.Cross(d1, d0);

						if(cross.y < 0)
						{
							if(myIndex <= hR) hR = myIndex;
						}
						else
						{
							if(myIndex >= hL) hL = myIndex;
						}
				
					}
				}

				if(hasHit)
				{

					if(hR == 100) hR = hL + 1;
					if(hL == -100) hL = hR - 1;

//					Debug.Log("hL=" + hL + "  hR=" + hR);
					foreach(Path path in paths)
					{
						
						int index = path.index;
						int myIndex = index;
						
						List<Vector3> list = path.list;
						List<Vector3> points = path.points;

						
						Vector3 p1 = list[i];
						Vector3 p2 = list[i + 1];

						int symbol = 1;
						int gapIndex = 0;
						if(myIndex <= hL)
						{
							gapIndex = myIndex - hL - 1;
							symbol = -1;
						}
						else
						{
							gapIndex = myIndex - hR + 1;
							symbol = 1;
						}

						
						Vector3 direction = (p2 - p1).normalized;
						float radian = HMath.radian(0, 0, direction.x, direction.z);
						radian += Mathf.PI * 0.5F;
						
						Vector3 ip = HMath.IntersectionPoint(pos,  p1, p2);
						float r = radius * symbol + gap * gapIndex;


//						Debug.Log("index="+index + "  gapIndex=" + gapIndex + " r=" + r);
					
						
						Vector3 p;

						if(Vector3.Distance(ip, p1) > radius * hitRadiusMultiply * hitRadiusMultiplyVertical)
						{
							p = ip - direction * radius * hitRadiusMultiply * hitRadiusMultiplyVertical;
							points.Add(p);
						}
						
						p = Vector3.zero;
						p.x = HMath.radianPointX(radian,r, pos.x);
						p.z = HMath.radianPointY(radian, r, pos.z);
						points.Add(p);
						
						if(Vector3.Distance(ip, p2) > radius * hitRadiusMultiply * hitRadiusMultiplyVertical)
						{
							p = ip + direction * radius * hitRadiusMultiply * hitRadiusMultiplyVertical;
							points.Add(p);
							list.Insert(i + 1, p);
						}
						else
						{
							list.Insert(i + 1, p2);
						}

						
						

					}

					
					listCount = paths[0].list.Count;
				}

			}
			


		}


		public void OnDrawGizmos()
		{
			for(int i = 0; i < points.Count; i ++)
			{
				Gizmos.color = Color.gray;
				Gizmos.DrawWireSphere(points[i], 0.1f);
				
				if(i < points.Count - 1)
				{
					Gizmos.color = Color.gray;
					Gizmos.DrawLine(points[i], points[i + 1] );
				}
			}

			foreach(Path path in paths)
			{
				path.OnDrawGizmos();
			}
		}
	}



	public class CheckBuildPathGroup : MonoBehaviour 
	{
		
		public float gap = 1f;
		public int pathNum = 8;
		public float lengthRadius = 2f;
		public float hitRadiusMultiply = 1.5f;
		public LayerMask buildLayer;

		public List<Transform> nodes = new List<Transform>();
		public PathGroup group = new PathGroup();
		public bool isUpdate = false;

		void Start () 
		{
			SetPath();
		}

		void Update () 
		{
			if(isUpdate)
			{
				SetPath();
			}

		}
		
		void SetPath () 
		{
			group.gap = gap;
			group.pathNum = pathNum;
			group.lengthRadius = lengthRadius;
			group.hitRadiusMultiply = hitRadiusMultiply;
			group.buildLayer = buildLayer;
			
			group.points.Clear();
			foreach(Transform node in nodes)
			{
				if(node != null) group.points.Add(node.position);
			}
			
			group.GenerationSubPaths();
			group.CheckBuild();
			
		}

		void OnDrawGizmos()
		{
			group.OnDrawGizmos();
		}
	}
}