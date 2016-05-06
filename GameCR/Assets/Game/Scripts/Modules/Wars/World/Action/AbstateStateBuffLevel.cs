using UnityEngine;
using System.Collections;
using CC.Runtime.Pools;


namespace Games.Module.Wars
{
	public class AbstateStateBuffLevel : MonoBehaviour
	{
		public virtual void SetLevel(int level, int colorId)
		{
		}


		PrefabPoolItem poolItem;
		public virtual void Release()
		{
			if(poolItem == null) poolItem = GetComponent<PrefabPoolItem>();
			poolItem.Release();
		}
	}
}