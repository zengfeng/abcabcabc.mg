using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.signals;
using Games.Module.Wars;
using Games.Module.Props;


namespace Games.Module.Wars
{
	public class WarMap : EntityMBBehaviour 
	{

		public MeshRenderer meshRenderer;

		protected override void OnAwake ()
		{
			base.OnAwake ();
			War.map = this;
		}

		public void Instance()
		{
			MapConfig mapConfig = War.sceneData.mapConfig;
			if(mapConfig.id < 100)
			{
				meshRenderer.material.mainTexture = WarRes.GetRes<Texture2D>(mapConfig.terrain);
				meshRenderer.gameObject.SetActive(true);
				War.scene.rootTerrains.gameObject.SetActive(false);
			}
			else
			{
				GameObject prefab = WarRes.GetPrefab(mapConfig.terrain);
				GameObject go = GameObject.Instantiate(prefab);
				go.transform.SetParent(War.scene.rootTerrains);
				go.transform.position = Vector3.zero;
				meshRenderer.gameObject.SetActive(false);
				War.scene.rootTerrains.gameObject.SetActive(true);

				Transform map = go.transform.Find("Map");
				if(map != null)
				{
					MeshRenderer mapRenderer = map.GetComponent<MeshRenderer>();
					if(mapRenderer != null)
					{
						mapRenderer.sharedMaterial.shader = Shader.Find("ihaiu/Terrain_3Texture_1Shade");
					}
				}
			}
		}

		public void Clear()
		{
			HUnityUtil.DestroyImmediateChilds(War.scene.rootTerrains);
			meshRenderer.material.mainTexture = null;
			
			meshRenderer.gameObject.SetActive(true);
			War.scene.rootTerrains.gameObject.SetActive(false);
		}


	}


}
