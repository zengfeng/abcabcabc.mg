using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.signals;
using Games.Module.Wars;
using Games.Module.Props;


namespace Games.Module.Wars
{
	public partial class WarScene : EntityMBBehaviour 
	{
		public Dictionary<int, Dictionary<int, float>>  buildDistanceDict = new Dictionary<int, Dictionary<int, float>>();

		public void GenerationBuildDistance()
		{
			int count = buildList.Count;
			for(int i = 0; i < count; i ++)
			{
				UnitCtl a = buildList[i];
				
				Dictionary<int, float> distanceDict = new Dictionary<int, float>();
				buildDistanceDict.Add(a.unitData.id, distanceDict);

				for(int j = 0; j < count; j ++)
				{
					UnitCtl b = buildList[j];
					float distance = Vector3.Distance(a.transform.position, b.transform.position);
					distanceDict.Add(b.unitData.id, distance);
				}
			}


//			foreach(UnitCtl a in buildList)
//			{
//				Dictionary<int, float> distanceDict = new Dictionary<int, float>();
//				buildDistanceDict.Add(a.unitData.id, distanceDict);
//				foreach(UnitCtl b in buildList)
//				{
//					float distance = Vector3.Distance(a.transform.position, b.transform.position);
//					distanceDict.Add(b.unitData.id, distance);
//				}
//			}
		}

		public float GetBuildDistance(int buildIdA, int buildIdB)
		{
			Dictionary<int, float> distanceDict = buildDistanceDict[buildIdA];
			return distanceDict[buildIdB];
		}

		public float GetBuildDistance(UnitCtl a, UnitCtl b)
		{
			return GetBuildDistance(a.unitData.id, b.unitData.id);
		}

	}
}
	
