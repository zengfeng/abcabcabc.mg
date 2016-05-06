using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.Pools;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{

	public class WarLegionExpPool 
	{
		public Dictionary<LegionExpEffectType, PrefabPool> poolDict = new Dictionary<LegionExpEffectType, PrefabPool>();

		public void Init(MonoBehaviour manager)
		{
			LegionExpEffectType[] types = new LegionExpEffectType[]{LegionExpEffectType.L, LegionExpEffectType.M, LegionExpEffectType.S};
			string[] names = new string[]{"LegionExpEffect_L", "LegionExpEffect_M", "LegionExpEffect_S"};
			string[] res = new string[]{WarRes.e_legionexp_l, WarRes.e_legionexp_m, WarRes.e_legionexp_s};
			
			Transform transform = manager.transform;
			PrefabPool pool = null;
			for(int i = 0; i < types.Length; i ++)
			{
				pool = new PrefabPool();
				pool.cullAbove = 30;
				pool.cullDelay = 5;
				pool.cullMaxPerPass = 5;
				pool.manager = manager;
				pool.prefab = WarRes.GetPrefab(res[i]);
				pool.group = new GameObject(names[i]).transform;
				pool.group.SetParent(transform);
				poolDict.Add(types[i], pool);
			}
		}

		public void Clear()
		{
			foreach(var item in poolDict)
			{
				item.Value.Clear();
			}

			poolDict.Clear();
		}

		public GameObject Get(LegionExpEffectType type)
		{
			return poolDict[type].Get();
		}

	}
}