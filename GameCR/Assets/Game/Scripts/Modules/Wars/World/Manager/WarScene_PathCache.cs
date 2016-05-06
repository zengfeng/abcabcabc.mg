using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.signals;
using Games.Module.Wars;
using Games.Module.Props;
using zfpaths;
using RayPaths;
using SimpleFramework;


namespace Games.Module.Wars
{
	public partial class WarScene : EntityMBBehaviour 
	{
		public Dictionary<int, Dictionary<Transform, Dictionary<Transform, PathGroup>>> pathCache 
			= new Dictionary<int, Dictionary<Transform, Dictionary<Transform, PathGroup>>>();

		private bool _initPathCache;
		public IEnumerator InitPathCache()
		{
			if(_initPathCache) yield break;
			_initPathCache = true;

			Dictionary<int, bool> onceCountHas = new Dictionary<int, bool>();
			
			int count = buildList.Count;
			float totalCount = count * count * War.sceneData.legionDict.Count;
			float totalIndex = 0;
			float rate = 0;
			foreach(KeyValuePair<int, LegionData> legionKVP in  War.sceneData.legionDict)
			{
				LegionData legionData = legionKVP.Value;
				if(legionData.type != LegionType.Player && !legionData.aiSendArm)
				{
					totalIndex += count * count;

					
					rate = totalIndex / totalCount;
					War.sceneCreate.SetSceneLoaderProgress(rate);
					yield return new WaitForSeconds(count * 0.2f);
					continue;
				}

				float radius = legionData.soliderData.radius;
				float gap = radius * 2;
				int onceCount = Mathf.FloorToInt(8 / gap);
				if(onceCountHas.ContainsKey(onceCount))
				{
					totalIndex += count * count;

					
					rate = totalIndex / totalCount;
					War.sceneCreate.SetSceneLoaderProgress(rate);
					yield return new WaitForSeconds(count * 0.2f);
					continue;
				}
				onceCountHas.Add(onceCount, true);


				
//				Debug.Log(string.Format("<color=yellow>legionData.legionId={0}, buildList.Count={1}, onceCount={2}</color>", legionData.legionId, count, onceCount));
				for(int i = 0; i < count; i ++)
				{
					Transform from = buildList[i].transform;

					for(int j = 0; j < count; j ++)
					{
						totalIndex ++;
						if(i == j) continue;
						
						Transform to = buildList[j].transform;
						
						GameObject groupGO = War.factory.CreatePathGroup();
						UnitPathGroup pathGroup = groupGO.GetComponent<UnitPathGroup>();
						PathAgentComponent pathAgent = groupGO.GetComponent<PathAgentComponent>();
						pathAgent.m_pathManager = War.pathManager;

						groupGO.transform.position = from.position;
						pathGroup.isInitCache = true;
						pathGroup.gap = gap;
						pathGroup.onceCount = onceCount;
						pathGroup.MoveTo(from, to);
//						Debug.Log(string.Format("<color=yellow>i={0}, j={1}, onceCount={2}</color>", i, j, onceCount));

						rate = totalIndex / totalCount;
						
						yield return new WaitForEndOfFrame();
						War.sceneCreate.SetSceneLoaderProgress(rate);
//						Debug.Log("rate=" + rate);
						yield return new WaitForEndOfFrame();
					}
				}
				
				rate = totalIndex / totalCount;
				War.sceneCreate.SetSceneLoaderProgress(rate);
				yield return new WaitForEndOfFrame();
			}

			War.sceneCreate.OnInitPathCacheComplete();


		}



		public void AddPathCache(int onceCount, Transform from, Transform to, PathGroup pathGroup)
		{
			Dictionary<Transform, Dictionary<Transform, PathGroup>> onceCountDict = null;
			if(!pathCache.TryGetValue(onceCount, out onceCountDict))
			{
				onceCountDict = new Dictionary<Transform, Dictionary<Transform, PathGroup>>();
				pathCache.Add(onceCount, onceCountDict);
			}

			Dictionary<Transform, PathGroup> fromDict = null;
			if(!onceCountDict.TryGetValue(from, out fromDict))
			{
				fromDict = new Dictionary<Transform, PathGroup>();
				onceCountDict.Add(from, fromDict);
			}

		

			if(fromDict.ContainsKey(to))
			{
				fromDict[to] = pathGroup;
			}
			else
			{
				fromDict.Add(to, pathGroup);
			}
		}

		public PathGroup GetPathCache(int onceCount, Transform from, Transform to)
		{
			
			Dictionary<Transform, Dictionary<Transform, PathGroup>> onceCountDict;
			if(pathCache.TryGetValue(onceCount, out onceCountDict))
			{
				
				Dictionary<Transform, PathGroup> fromDict;
				if(onceCountDict.TryGetValue(from, out fromDict))
				{
					PathGroup pathGroup;
					if(fromDict.TryGetValue(to, out pathGroup))
					{
						return pathGroup;
					}
				}
			}

			return null;
		}

		public void CearPathCache()
		{
			Dictionary<Transform, Dictionary<Transform, PathGroup>> onceCountDict;
			foreach(KeyValuePair<int, Dictionary<Transform, Dictionary<Transform, PathGroup>>> onceCountDictKVP in pathCache)
			{
				foreach(KeyValuePair<Transform, Dictionary<Transform, PathGroup>> formDictKVP in onceCountDictKVP.Value)
				{
					formDictKVP.Value.Clear();
				}
				onceCountDictKVP.Value.Clear();
			}

			pathCache.Clear();
		}

	}
}
	
