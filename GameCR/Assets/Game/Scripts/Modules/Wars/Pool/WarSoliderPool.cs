using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.Pools;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	

	public class WarSoliderPool 
	{
		public Queue<GameObject> pool = new Queue<GameObject>();


		public GameObject Get()
		{
			GameObject go ;
			SoliderPoolItem t;
//			Debug.Log("pool.Count=" + pool.Count);
			if (pool.Count > 0)
			{
				go = pool.Dequeue();
				t = go.GetComponent<SoliderPoolItem>();
				go.SetActive(true);
				t.isPut = false;
			}
			else
			{
				go = Factory();
				t = go.GetComponent<SoliderPoolItem>();
				if(t == null)
				{
					t = go.AddComponent<SoliderPoolItem>();
				}
				t.Pool = this;
//				t.Rest();
			}


			return go;
		}

		
		public void Put(GameObject go)
		{
//			Debug.Log("Put " + go.name + " pool.Count=" + pool.Count);
			pool.Enqueue(go);
		}


		public GameObject Factory()
		{
			GameObject prefab = WarRes.GetPrefab(WarRes.Unit_Prefab_Solider);
			GameObject go = GameObject.Instantiate(prefab);
			go.transform.SetParent(War.scene.rootSoliders);
			return go;
		}


		public void Clear()
		{

			pool.Clear();
		}
	}
}