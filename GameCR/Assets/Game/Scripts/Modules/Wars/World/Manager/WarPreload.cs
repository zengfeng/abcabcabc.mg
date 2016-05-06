using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime;

namespace Games.Module.Wars
{
	/** 战斗预加载 */
	public class WarPreload : MonoBehaviour
	{
		
		private int 	resCount 	= 0;
		private int 	redLoaded 	= 0;
		private bool 	isLoaded 	= false;

		public void Load()
		{
			List<string> list =  WarRes.preloadList;
			resCount = list.Count;
			redLoaded = 0;
			isLoaded = false;

			
			foreach(string name in list)
			{
				Coo.assetManager.Load(name, OnLoadRes);
			}
		}
		
		protected void OnLoadRes(string name, object obj)
		{
            //Debug.Log(string.Format("<color=0x66FF44>name={0}  obj={1}</color>", name, obj));
			WarRes.AddPrefab(name, obj);
			
			redLoaded ++;
			if(redLoaded >= resCount && isLoaded == false)
			{
				isLoaded = true;
				War.signal.PreloadComplete ();
			}
		}
	}
}
