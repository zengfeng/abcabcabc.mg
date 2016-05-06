using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using zfpaths;
using Games.Module.Wars;
using CC.Runtime.Utils;

namespace RayPaths
{
	public class UnitPathGroup : MonoBehaviour 
	{
		public LayerMask layerMask_Obstacle;
		public LayerMask layerMask_Build;
		public float gap = 1f;
		public int onceCount = 8;
		public int pathNum = 8;
		public float lengthRadius = 2f;
		public float hitRadiusMultiply = 1.5f;
		public float hitRadiusMultiplyVertical = 1f;

		public UnitNavigationAgentComponent navigationAgent;
		public UnitCtl fromUnitCtl;
		public UnitCtl toUnitCtl;
		public Transform from;
		public Transform to;
		public List<UnitPath> list = new List<UnitPath>();

		public PathGroup group;
		[HideInInspector]
		public bool isInitCache = false;

		void Awake ()
		{
			if(navigationAgent == null) navigationAgent = GetComponent<UnitNavigationAgentComponent>();
		}

		
		public void MoveTo(UnitCtl from, UnitCtl to)
		{
			fromUnitCtl = from;
			toUnitCtl = to;
			MoveTo(fromUnitCtl.transform, toUnitCtl.transform);
		}

		public void MoveTo(Transform from, Transform to)
		{
			this.from = from;
			this.to = to;


			PathGroup pathGroup = War.scene.GetPathCache(onceCount, from, to);
			if(pathGroup != null)
			{
				SetPathGroup(pathGroup);
			}
			else
			{
				Vector3[] paths = War.sceneData.pathData.GetPath(fromUnitCtl.unitData.uid, toUnitCtl.unitData.uid);

				SetPath(paths);

//				RaycastHit hitInfo;
//				if (Physics.Linecast(from.position, to.position, out hitInfo, layerMask_Obstacle.value)) 
//				{
//					StartCoroutine(DelayMoveTo());
//				}
//				else
//				{
//					Vector3[] paths = new Vector3[]{from.position, to.position};
//					SetPath(paths);
//				}
			}
		}

		IEnumerator DelayMoveTo()
		{
			yield return new WaitForSeconds(0.03f);
			navigationAgent.MoveToPosition(to.position);
		}


		public void SetPath(Vector3[] paths, bool isRay = false)
		{
			List<Vector3> points = new List<Vector3>();
			for(int i = 0; i < paths.Length; i ++)
			{
				points.Add(paths[i].Clone());
			}


			PathGroup group = new PathGroup();
			group.gap = gap;
			group.pathNum = 8;
			group.lengthRadius = lengthRadius;
			group.hitRadiusMultiply = hitRadiusMultiply;
			group.hitRadiusMultiplyVertical = hitRadiusMultiplyVertical;
			group.buildLayer = layerMask_Build;

			group.points = points;
			group.GenerationSubPaths();
			group.CheckBuild();
			
			for(int i = 0; i < group.paths.Count; i ++)
			{
				group.paths[i].s0 = group.paths[0].s;
			}


			War.scene.AddPathCache(onceCount, from, to, group);

			SetPathGroup(group);
		}

		public void SetPathGroup(PathGroup pathGroup)
		{
			if(isInitCache)
			{
				
				Destroy(gameObject);
				return;
			}

			int count = list.Count;
			group = pathGroup.Clone(count);

			for(int i = 0; i < count; i ++)
			{
				list[i].SetPath(group.paths[i]);
			}

			group.Synchronous(0.5f, War.scene);

			Destroy(gameObject);
		}


		void OnDrawGizmos()
		{
			if(group != null) group.OnDrawGizmos();
		}
	}
}
