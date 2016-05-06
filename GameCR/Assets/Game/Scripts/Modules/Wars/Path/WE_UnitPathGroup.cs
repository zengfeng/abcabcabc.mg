#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using zfpaths;
using Games.Module.Wars;
using System;

namespace RayPaths
{
	public class WE_UnitPathGroup : MonoBehaviour 
	{
		
		public Action<int, int, Vector3[]> sPathFinded;

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

			RaycastHit hitInfo;
			if (Physics.Linecast(from.position, to.position, out hitInfo, layerMask_Obstacle.value)) 
			{
				StartCoroutine(DelayMoveTo());
			}
			else
			{
				Vector3[] paths = new Vector3[]{from.position, to.position};
				SetPath(paths);
			}
		}

		IEnumerator DelayMoveTo()
		{
			yield return new WaitForSeconds(0.03f);
			navigationAgent.sFinded += SetPath;
			navigationAgent.MoveToPosition(to.position);
		}




		public void SetPath(Vector3[] paths)
		{
			List<Vector3> points = new List<Vector3>();
			// 删除一些两个离得太近中的一个点
			if(paths.Length>2)
			{
				for(int i = 0; i < paths.Length; i ++)
				{
					if(i == 0)
					{
						points.Add(paths[i]);
					}
					else 
					{
						if(Vector3.Distance( paths[i], points[points.Count - 1]) < 2f)
						{
							if(i == paths.Length - 1)
							{
								points.RemoveAt(points.Count - 1);
								points.Add(paths[i]);
							}
						}
						else
						{
							points.Add(paths[i]);
						}
					}
				}
			}
			else
			{
				foreach(Vector3 p in paths)
				{
					points.Add(p);
				}
			}


			// 删除A*寻路多出的没必要的点
			if(points.Count == 3)
			{
				if (!Physics.Linecast (from.position, to.position, layerMask_Obstacle.value)) 
				{
					List<Vector3> listr = new List<Vector3>();
					listr.Add(points[0]);
					listr.Add(points[2]);
					points = listr;
				}
			}


			if(sPathFinded != null)
			{
				sPathFinded(fromUnitCtl.unitData.uid, toUnitCtl.unitData.uid, points.ToArray());
			}
		
		}

	

	}
}
#endif
