using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime;
using CC.Runtime.signals;

namespace Games.Module.Wars
{
	public class WarFactory : EntityMBBehaviour 
	{

		public GameObject CreatePlayer(UnitData unitData)
		{
			GameObject prefab = WarRes.GetPrefab(WarRes.Unit_Player);
			
			GameObject go = GameObject.Instantiate(prefab);
			go.name = go.name.Replace("(Clone)", "") + "_" + unitData.id;
			go.AddEComponent(unitData);
			unitData.Init();

			
			go.transform.SetParent(War.scene.rootPlayers);
			go.transform.position = unitData.position;
			go.SetActive(true);
			return go;
		}

		public GameObject CreateHero(UnitData unitData, HeroData heroData)
		{
			
			GameObject prefab = WarRes.GetPrefab(WarRes.Unit_Hero);
			GameObject go = GameObject.Instantiate(prefab);
			go.name = go.name.Replace("(Clone)", "") + "_" + unitData.legionId + "-" + heroData.heroId;
			go.AddEComponent(unitData);
			go.AddEComponent(heroData);
			unitData.Init();
			heroData.isInstance = true;

			go.transform.SetParent(War.scene.rootHeros);
			go.SetActive(true);
			return go;

		}

		public GameObject CreateWall(UnitData unitData)
		{
			GameObject prefab = WarRes.GetPrefab(WarRes.Unit_Wall);
			
			GameObject go = GameObject.Instantiate(prefab);
			go.name = go.name.Replace("(Clone)", "") + "_" + unitData.id;
			go.AddEComponent(unitData);
			
			unitData.Init();
			
			go.transform.SetParent(War.scene.rootWalls);
			go.transform.position = unitData.position;
			go.SetActive(true);
			return go;
		}

		
		public GameObject CreateBuild(UnitData unitData)
		{
			GameObject prefab = WarRes.GetPrefab(WarRes.Unit_Build);
			GameObject go = GameObject.Instantiate(prefab);
			go.name = go.name.Replace("(Clone)", "") + "_" + unitData.id;
			go.AddEComponent(unitData);

			
			ProduceData produceData = new ProduceData();
			SendArmData sendArmData = new SendArmData();
			LevelData levelData = new LevelData();
			go.AddEComponent(levelData);
			go.AddEComponent(produceData);
			go.AddEComponent(sendArmData);
			
			
			unitData.Init();
			
			if(unitData.legionData.produceLimit)
			{
				produceData.produceLimitNum = unitData.hp;
			}
			
			go.transform.SetParent(War.scene.rootCaserns);
			go.transform.position = unitData.position;
			go.SetActive(true);
			return go;
		}

		public GameObject CreateCasern(UnitData unitData)
		{
			GameObject prefab = WarRes.GetPrefab(WarRes.Unit_Build_Casern);
			GameObject go = GameObject.Instantiate(prefab);
			go.name = go.name.Replace("(Clone)", "") + "_" + unitData.id;
			go.AddEComponent(unitData);

			// TODO NewWar
//			LevelData levelData = new LevelData();
//			levelData.buildConfig = War.model.GetBuildConfig(BuildType.Casern);

			ProduceData produceData = new ProduceData();
			SendArmData sendArmData = new SendArmData();

//			go.AddEComponent(levelData);
			go.AddEComponent(produceData);
			go.AddEComponent(sendArmData);


			unitData.Init();
			
			if(unitData.legionData.produceLimit)
			{
				produceData.produceLimitNum = unitData.hp;
			}

			go.transform.SetParent(War.scene.rootCaserns);
			go.transform.position = unitData.position;
			go.SetActive(true);
			return go;
		}

		
		public GameObject CreateTurret(UnitData unitData)
		{
			GameObject prefab = WarRes.GetPrefab(WarRes.Unit_Build_Turret);
			
			GameObject go = GameObject.Instantiate(prefab);
			go.name = go.name.Replace("(Clone)", "") + "_" + unitData.id;
			go.AddEComponent(unitData);


			SendArmData sendArmData = new SendArmData();

			go.AddEComponent(sendArmData);
			
			
			unitData.Init();

			
			go.transform.SetParent(War.scene.rootCaserns);
			go.transform.position = unitData.position;
			go.SetActive(true);
			return go;
		}

		
		public GameObject CreateSpot(UnitData unitData)
		{
			GameObject prefab = WarRes.GetPrefab(WarRes.Unit_Build_Spot);
			
			GameObject go = GameObject.Instantiate(prefab);
			go.name = go.name.Replace("(Clone)", "") + "_" + unitData.id;
			go.AddEComponent(unitData);
			
			
			SendArmData sendArmData = new SendArmData();
			
			go.AddEComponent(sendArmData);
			
			
			unitData.Init();
			
			
			go.transform.SetParent(War.scene.rootCaserns);
			go.transform.position = unitData.position;
			go.SetActive(true);
			return go;
		}

		public GameObject CreateSolider(int team)
		{
			GameObject prefab = WarRes.GetPrefab(WarRes.Unit_Prefab_Solider);
		
			GameObject go = GameObject.Instantiate(prefab);
			go.name = go.name.Replace("(Clone)", "") + "_" + team;
			go.transform.SetParent(War.scene.rootSoliders);
			return go;
		}

		
		public GameObject CreatePathGroup()
		{
			GameObject prefab = WarRes.GetPrefab(WarRes.Unit_Prefab_UnitPathGroup);
			
			GameObject go = GameObject.Instantiate(prefab);
			go.transform.SetParent(War.scene.rootSoliders);
			return go;
		}
	}
}
