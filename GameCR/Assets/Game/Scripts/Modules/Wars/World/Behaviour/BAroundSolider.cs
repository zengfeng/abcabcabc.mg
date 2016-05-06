using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using System.Collections.Generic;
using RayPaths;

namespace Games.Module.Wars
{
	public class BAroundSolider : EBehaviour
	{
		public UnitPath unitPath;
		public float aroundRadius = 5f;

		protected override void OnStart ()
		{
			base.OnStart ();
			
			unitPath = GetComponent<UnitPath>();
		}

//		protected override void OnUpdate ()
//		{
//			base.OnUpdate ();
//
//			if(unitPath.path == null) return;
//			
//			RelationType relation = unitData.GetRelation(unitData.to.legionId);
//			if(relation == RelationType.Enemy)
//			{
//				unitPath.path.group.Around(unitData, transform.position);
//			}
//
//
//		}
	}
}
