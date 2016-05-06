using UnityEngine;
using System.Collections;
using CC.Runtime.Pools;

namespace Games.Module.Wars
{
	public class WarPoolManager : MonoBehaviour 
	{
		public WarLegionExpPool		legionExpPool = new WarLegionExpPool();

		public PrefabPool 			stateBuffMoveSpeedUp;
		public PrefabPool 			stateBuffAtkUp;
		public PrefabPool 			stateBuffProduceSpeedUp;

		public PrefabPool 			spotChange;
		private bool isInit = false;


		void Awake()
		{
			War.pool = this;
		}

		public void Init()
		{
			if(isInit) return;
			isInit = true;

			PrefabPool pool = null;
			pool = new PrefabPool();
			pool.cullAbove = 100;
			pool.cullDelay = 5;
			pool.cullMaxPerPass = 5;
			pool.manager = this;
			pool.prefab = WarRes.GetPrefab(WarRes.e_buffstate_movespeed_up);
			pool.group = new GameObject("StateBuffMoveSpeedUp").transform;
			pool.group.SetParent(transform);
			stateBuffMoveSpeedUp = pool;

			pool = new PrefabPool();
			pool.cullAbove = 100;
			pool.cullDelay = 5;
			pool.cullMaxPerPass = 5;
			pool.manager = this;
			pool.prefab = WarRes.GetPrefab(WarRes.e_buffstate_atk_up);
			pool.group = new GameObject("StateBuffAtkUp").transform;
			pool.group.SetParent(transform);
			stateBuffAtkUp = pool;
			
			pool = new PrefabPool();
			pool.cullAbove = 100;
			pool.cullDelay = 5;
			pool.cullMaxPerPass = 5;
			pool.manager = this;
			pool.prefab = WarRes.GetPrefab(WarRes.e_buffstate_producespeed_up);
			pool.group = new GameObject("StateBuffProduceSpeedUp").transform;
			pool.group.SetParent(transform);
			stateBuffProduceSpeedUp = pool;

			
			
			pool = new PrefabPool();
			pool.cullAbove = 10;
			pool.cullDelay = 5;
			pool.cullMaxPerPass = 5;
			pool.manager = this;
			pool.prefab = WarRes.GetPrefab(WarRes.e_spot_change);
			pool.group = new GameObject("SpotChange").transform;
			pool.group.SetParent(transform);
			spotChange = pool;

			legionExpPool.Init(this);

		}

		public void Destroy()
		{
			StopAllCoroutines();

			stateBuffMoveSpeedUp.Clear();
			stateBuffAtkUp.Clear();
			stateBuffProduceSpeedUp.Clear();
			spotChange.Clear();
			
			legionExpPool.Clear();

			
			isInit = false;

		}


	}
}