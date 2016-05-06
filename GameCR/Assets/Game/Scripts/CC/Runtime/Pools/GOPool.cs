using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace CC.Runtime.Pools
{
	
	/**
	 * IGOPoolItem
	 */
	public interface IGOPoolItem { 
		GOPool Pool{
			set;
		}
		
		void Release();
	}
	
	/**
	 * GOPoolItem
	 */
	public class GOPoolItem : MonoBehaviour, IGOPoolItem
	{
		private GOPool pool;
		public GOPool Pool
		{
			set
			{
				pool = value;
			}
		}
		
		public void Release()
		{
			pool.Put(gameObject);
		}
	}

	/**
	 * GOPool
	 */
	public class GOPool
	{
		
		//field public
		//----------------
		public bool isLimit = false;
		public int limitAcount = 100;

		//field private
		//----------------
		private Stack<GameObject> pool;
		private Func<GameObject> factory;
		private int count = 0;

		//protoperty
		//----------------
		public Func<GameObject> Factory
		{
			get
			{
				return factory;
			}
			set
			{
				factory = value;
			}
		}


		public GOPool()
		{
			pool = new Stack<GameObject>();
		}
		
		//method
		//----------------
		public GameObject Get()
		{
				if (pool.Count > 0)
				{
					return pool.Pop();
				}
				else
				{
					GameObject go = factory();
					IGOPoolItem t = go.GetComponent<IGOPoolItem>();
					if(t == null)
					{
						t = go.AddComponent<GOPoolItem>();
					}
					t.Pool = this;
					return go;
				}
		}
		
		public void Put(GameObject item)
		{
			pool.Push(item);

		}
	}
}
