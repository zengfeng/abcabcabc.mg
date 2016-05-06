using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CC.Runtime.Pools
{
	public class PrefabPoolItem : MonoBehaviour
	{
		private PrefabPool pool;
		public PrefabPool Pool
		{
			set
			{
				pool = value;
			}
		}
		
		public void Release()
		{
			gameObject.SetActive(false);
			pool.Put(gameObject);
		}

		public void Rest()
		{

		}

		public void OnRest()
		{
		}
	}


	public class PrefabPool 
	{
		//开启自动清理池子
		public bool cullDespawned = true;
		//最终保留
		public int cullAbove = 10;
		//多久清理一次
		public int cullDelay = 5;
		//每次清理几个
		public int cullMaxPerPass =5;
		//清理激活
		private bool cullingActive;
		
		public MonoBehaviour manager;
		public GameObject prefab;
		public Transform group;
		private Stack<GameObject> pool;
		
		public PrefabPool()
		{
			pool = new Stack<GameObject>();
		}

		
		public GameObject Factory()
		{
			return GameObject.Instantiate(prefab);
		}

		public GameObject Get()
		{
			if (pool.Count > 0)
			{
				return pool.Pop();
			}
			else
			{
				GameObject go = Factory();
				if(group != null)
				{
					go.transform.SetParent(group);
				}

				PrefabPoolItem t = go.GetComponent<PrefabPoolItem>();
				if(t == null)
				{
					t = go.AddComponent<PrefabPoolItem>();
				}
				t.Pool = this;
				return go;
			}
		}
		
		public void Put(GameObject item)
		{
			pool.Push(item);

			if (!this.cullingActive &&   // Cheap & Singleton. Only trigger once!
			    this.cullDespawned &&    // Is the feature even on? Cheap too.
			    this.totalCount > this.cullAbove)   // Criteria met?
			{
				this.cullingActive = true;
				this.manager.StartCoroutine(CullDespawned());
			}

			if(group != null && item.transform.parent != group)
			{
				item.transform.SetParent(group);
			}
		}


		public int totalCount
		{
			get
			{
				return pool.Count;
			}
		}

		internal IEnumerator CullDespawned()
		{
			yield return new WaitForSeconds(this.cullDelay);
			
			while (this.totalCount > this.cullAbove)
			{
				for (int i = 0; i < this.cullMaxPerPass; i++)
				{
					if (this.totalCount <= this.cullAbove)
						break;

					if (pool.Count > 0)
					{
						GameObject.Destroy(pool.Pop());
					}
				}

				yield return new WaitForSeconds(this.cullDelay);
			}

			this.cullingActive = false;
			yield return null;
		}

		public void Clear()
		{
			prefab = null;
			pool.Clear();
		}


	}
}