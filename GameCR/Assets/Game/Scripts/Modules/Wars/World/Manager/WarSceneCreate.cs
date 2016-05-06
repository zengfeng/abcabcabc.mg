using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime;
using CC.Runtime.signals;
using System;
using SimpleFramework;
using Games.Module.Avatars;

namespace Games.Module.Wars
{
	public class WarSceneCreate : MonoBehaviour {

		private SceneData sceneData;



		public void CloseSceneLoader()
		{
			Coo.loadManager.CloseSceneLoader();
		}
		
		
		public void SetSceneLoaderState(string state)
		{
			Coo.loadManager.SetSceneLoaderState(state);
		}
		
		
		
		
		
		public void SetSceneLoaderProgress(float progress)
		{
			Coo.loadManager.SetSceneLoaderProgress(progress);
		}


		void OnDestroy()
		{
			StopAllCoroutines();
		}


		public void Generation()
		{
			sceneData = War.sceneData;

//			GenerationBuilds();
//			GenerationPlayers();
//			GenerationHeros();
//			GenerationSkillButtons();
			StartCoroutine(CallGenerationActions());

		}

		IEnumerator CallGenerationActions()
		{
			SetSceneLoaderState("初始化战斗场景中...");

			
			Action[] actions = new Action[]{
				sceneData.InitPathData,
				War.pool.Init, 
				GenerationWalls, GenerationBuilds, GenerationPlayers, GenerationHeros, SetSoliderAvatarInfo, 
				War.starManager.Generation, 
				War.starPVPManager.Generation, 
				War.map.Instance,
			};

			float index = 1f;
			float count = actions.Length;
			foreach(Action call in actions)
			{
				call();
				float rate = index ++ / count;
				if(rate >= 1) rate = 0.99f;
				SetSceneLoaderProgress( rate);
				yield return new WaitForEndOfFrame();
			}
			
//			SetSceneLoaderState("初始化寻路缓存...");
//			SetSceneLoaderProgress( 0f);
			War.signal.PathGridRasterize();

			yield return new WaitForEndOfFrame();

			//StartCoroutine(War.scene.InitPathCache());

			OnInitPathCacheComplete();
		}

		public void OnInitPathCacheComplete()
		{
			War.scene.weightConfig = War.sceneData.weight;

//			Debug.Log("War.isAutoCloseLoad=" + War.isAutoCloseLoad);
			if(War.isAutoCloseLoad)
			{
				CloseSceneLoader();
			}
			
			War.signal.BuildComplete();

			SetSceneLoaderProgress( 1);
		}


		
		void GenerationPlayers()
		{

			foreach(KeyValuePair<int, LegionData> kvp in sceneData.legionDict)
			{
				LegionData legionData = kvp.Value;
				legionData.legionInitPropContainer.UnitApp(legionData.unitData, true);
				War.factory.CreatePlayer(legionData.unitData);
			}
		}

		
		void GenerationHeros()
		{
			foreach(KeyValuePair<int, LegionData> kvp in sceneData.legionDict)
			{
				LegionData legionData = kvp.Value;
				foreach(KeyValuePair<int, HeroData> kv in legionData.heroDatas)
				{
					HeroData heroData = kv.Value;
					UnitData unitData = legionData.heroUnitDatas[heroData.heroId];
					War.factory.CreateHero(unitData ,heroData);
				}
			}
		}

		void GenerationWalls()
		{
			foreach(KeyValuePair<int, UnitData> kvp in sceneData.wallDict)
			{
				UnitData unitData = kvp.Value;

				GenerationWall(unitData);
			}
		}

		public GameObject GenerationWall(UnitData unitData)
		{
			
			GameObject go = War.factory.CreateWall(unitData);
			
			#if UNITY_EDITOR
			if(War.isEditor)
			{
				go.AddComponent<WE_UnitSelect>();
			}
			#endif
			return go;
		}

		void GenerationBuilds()
		{
			foreach(KeyValuePair<int, UnitData> kvp in sceneData.buildDict)
			{
				GenerationBuild(kvp.Value);
			}
		}

		public GameObject GenerationBuild(UnitData unitData)
		{
			unitData = unitData.Clone();
			GameObject go = null;

			go = War.factory.CreateBuild(unitData);

			// TODO NewWar
//			if(unitData.buildType == BuildType.Casern)
//			{
//				go = War.factory.CreateCasern(unitData);
//			}
//			else if(unitData.buildType == BuildType.Turret)
//			{
//				go = War.factory.CreateTurret(unitData);
//			}
//			else if(unitData.buildType == BuildType.Spot)
//			{
//				go = War.factory.CreateSpot(unitData);
//			}


			#if UNITY_EDITOR
			if(War.isEditor)
			{
				go.AddComponent<WE_UnitSelect>();
			}
			#endif

			return go;
		}

		void SetSoliderAvatarInfo()
		{
			foreach(KeyValuePair<int, LegionData> kvp in sceneData.legionDict)
			{
				LegionData legionData = kvp.Value;
				string file = legionData.soliderData.prefabFile;
				GameObject prefab = WarRes.GetPrefab(file);
				if(prefab != null)
				{
					AvatarInfo avatarInfo = prefab.GetComponent<AvatarInfo>();
					if(avatarInfo != null)
					{
						legionData.soliderData.armOnceWidth = avatarInfo.armOnceWidth;
						legionData.soliderData.radius = avatarInfo.armOnceWidth / avatarInfo.armOnceCount * 0.5f;
						legionData.soliderData.gapV = avatarInfo.gapV;

					}
				}
			}
		}

	}
}