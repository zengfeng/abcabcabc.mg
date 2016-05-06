using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class TargetOwnBuild : MonoBehaviour 
	{
		public GameObject prefab;
		public float delay = 1f;
		public float gap = 0.5f;
		void Start () 
		{
			if(War.vsmode != VSMode.PVP)
			{
				gameObject.SetActive(false);
				return;
			}

			delay = War.sceneData.begionDelayTime -1;
			if(delay < 1) delay = 1;



			if(War.isGameing)
			{
				Init();
			}
			else
			{
				War.signal.sGameBegin += Init;
			}
		}
		
		
		void OnDestroy()
		{
			StopAllCoroutines();
			War.signal.sGameBegin -= Init;
		}
		
		void Init()
		{
			prefab = WarRes.GetPrefab(WarRes.e_target_build_own);
			StartCoroutine(CreateEffects());
		}
		
		IEnumerator CreateEffects()
		{
			yield return new WaitForSeconds(delay);

			List<UnitCtl> list = War.scene.GetBuilds(War.ownLegionID);
			int count = list.Count;

			for(int i = 0; i < count; i ++)
			{
				yield return new WaitForSeconds(gap);
				CreateBuild(list[i]);
			}
		}

		public void CreateBuild(UnitCtl unit)
		{
			GameObject go = GameObject.Instantiate(prefab);
			go.transform.SetParent(transform, false);
			go.transform.localScale = Vector3.one;
			go.transform.position = unit.transform.position;
		}


	}
}