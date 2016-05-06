using UnityEngine;
using System.Collections;
using CC.Runtime;
using Games.Module.Props;
using Newtonsoft.Json;
using Games.Cores;
using System.Collections.Generic;


namespace Games.Module.Wars
{
	public class TestWarManager : MonoBehaviour 
	{

		private static TestWarManager _Instance;
		public static TestWarManager Instance
		{
			get
			{
				if(_Instance == null)
				{
					GameObject go = GameObject.Find("WarManager");
					if(go == null) go = new GameObject("WarManager");
					
					_Instance = go.GetComponent<TestWarManager>();
					if(_Instance == null) _Instance = go.AddComponent<TestWarManager>();
				}
				return _Instance;
			}
		}


		public bool IsTest = false;
		public GameObject GameManagers;
		void Awake()
		{
			_Instance = this;


		}

		void Start()
		{
			Test();
//			if(IsTest)
//			{
//				GameManagers.SetActive(true);
//				Test();
//			}
//			else
//			{
//				if(GameManagers != null) GameManagers.SetActive(false);
//			}
		}

		[ContextMenu("Test")]
		void Test()
		{
			War.isTest = true;
			
			TestInit();
		}

		public void TestInit()
		{
			
			if(Coo.assetManager.isPrepare)
			{
				OnPreloadConfig();
			}
			else
			{
				Coo.assetManager.prepareFinal.AddOnce(OnPreloadConfig);
			}
		}
		
		private int preloadCount = 21; 
		private int preloadNum = 0;
		
		public void OnPreloadConfig()
		{
			List<string> prelist = new List<string>();
			string[] str = {
				"Config/property",
				"Config/exp_neutral",
				"Config/menu",
				"Config/sysmsg",
				"Config/soldier",
				"Config/item",
				"Config/stage_map",
				"Config/stage_ai",
				"Config/stage_win",
				"Config/stage_star",
				"Config/stage",
				"Config/stage_position",
				"Config/stage_weight",
				"Config/build",
				"Config/build_baseprop",
				"Config/build_produce",
				"Config/build_spot",
				"Config/build_turret",
				"Config/build_wall",
				"Config/morale_consume",
				"Config/morale_hero_get",
				"Config/morale_solider_get",

				"Config/monster",
				"Config/avatar",
				"Config/const_vars",
//				"Config/skill",
//				"Config/skill_data",
//				"Config/skill_data_buff",
//				"Config/skill_data_damage",
//				"Config/skill_data_fall",
//				"Config/skill_data_fastarm",
//				"Config/skill_data_fx",
//				"Config/skill_data_heal",
//				"Config/skill_data_projectile",
//				"Config/skill_data_shield",
//				"Config/skill_data_state",
//				"Config/skill_data_summon",
//				"Config/skill_data_property",
//				"Config/skill_data_propertytodamage",
//				"Config/skill_data_rora",
				"Config/skill_war_attri",
				"Config/skill_war_effect",

			};
			
			prelist.AddRange(str);
			preloadCount = prelist.Count;
			preloadNum = 0;
			preloadCount = prelist.Count;
			
			foreach(string name in prelist)
			{
				Coo.assetManager.Load(name, OnPreloadConfigEnd);
			}
		}

		void OnPreloadConfigEnd(string name, System.Object obj)
		{
			preloadNum ++;
			if(preloadNum == preloadCount)
			{
				InitConfig();
			}
		}
		
		public void InitConfig()
		{

			Coo.InitConfig();

			InitTSkillConfig();
			
			if(!GameScene.IsWarEditor())
			{
				Test_StartGame();
			}
		}

		private Dictionary<int, ISkillConfig> skillConfigs = new Dictionary<int, ISkillConfig>();
		void InitTSkillConfig()
		{
			int id = 100000;

			// 100000
			TSkillConfig config = new TSkillConfig();
			config.skillId = id ++;
			config.skillLevel = 1;
			config.name = "区域选择A";
			config.skillType = SkillType.Normal;
			config.buildId = 1;
			config.operate = SkillOperateType.SelectCircle;
			config.unitType = config.unitType.USolider(true);
			config.relation = config.relation.REnemy(true);
			config.radius = 10;
			config.icon = "Image/SkillIcon/skill_50302";
			skillConfigs.Add(config.skillId, config);

			
			// 100001
			config = new TSkillConfig();
			config.skillId = id ++;
			config.skillLevel = 1;
			config.name = "区域选择B";
			config.skillType = SkillType.Normal;
			config.buildId = 1;
			config.operate = SkillOperateType.SelectCircle;
			config.unitType = config.unitType.USolider(true);
			config.relation = config.relation.REnemy(true);
			config.radius = 5;
			config.icon = "Image/SkillIcon/skill_50003";
			skillConfigs.Add(config.skillId, config);

			
			// 100002
			config = new TSkillConfig();
			config.skillId = id ++;
			config.skillLevel = 1;
			config.name = "攻击建筑";
			config.skillType = SkillType.Normal;
			config.buildId = 1;
			config.operate = SkillOperateType.SelectUnit;
			config.unitType = config.unitType.UBuild(true);
			config.relation = config.relation.REnemy(true);
			config.icon = "Image/SkillIcon/skill_50204";
			skillConfigs.Add(config.skillId, config);
			
			
			// 100003
			config = new TSkillConfig();
			config.skillId = id ++;
			config.skillLevel = 1;
			config.name = "建筑加血";
			config.skillType = SkillType.Normal;
			config.buildId = 1;
			config.operate = SkillOperateType.SelectUnit;
			config.unitType = config.unitType.UBuild(true);
			config.relation = config.relation.ROwn(true);
			config.icon = "Image/SkillIcon/skill_52303";
			skillConfigs.Add(config.skillId, config);
			
			// 100004
			config = new TSkillConfig();
			config.skillId = id ++;
			config.skillLevel = 1;
			config.name = "替换1";
			config.skillType = SkillType.Build_Replace;
			config.buildId = 1;
			config.addBuildMaxLevel = 1;
			config.operate = SkillOperateType.SelectUnit;
			config.unitType = config.unitType.UBuild(true);
			config.relation = config.relation.ROwn(true);
			config.icon = "Image/SkillIcon/skill_50109";
			skillConfigs.Add(config.skillId, config);

			
			// 100005
			config = new TSkillConfig();
			config.skillId = id ++;
			config.skillLevel = 1;
			config.name = "替换2";
			config.skillType = SkillType.Build_Replace;
			config.buildId = 2;
			config.operate = SkillOperateType.SelectUnit;
			config.unitType = config.unitType.UBuild(true);
			config.relation = config.relation.ROwn(true);
			config.icon = "Image/SkillIcon/skill_50010";
			skillConfigs.Add(config.skillId, config);

			
			
			// 100006
			config = new TSkillConfig();
			config.skillId = id ++;
			config.skillLevel = 1;
			config.name = "附箭201";
			config.skillType = SkillType.Build_Attach;
			config.buildModuleId = 201;
			config.operate = SkillOperateType.SelectUnit;
			config.unitType = config.unitType.UBuild(true);
			config.relation = config.relation.ROwn(true);
			config.icon = "Image/SkillIcon/skill_50205";
			skillConfigs.Add(config.skillId, config);
			
			
			// 100007
			config = new TSkillConfig();
			config.skillId = id ++;
			config.skillLevel = 1;
			config.name = "附据301";
			config.skillType = SkillType.Build_Attach;
			config.buildModuleId = 301;
			config.operate = SkillOperateType.SelectUnit;
			config.unitType = config.unitType.UBuild(true);
			config.relation = config.relation.ROwn(true);
			config.icon = "Image/SkillIcon/skill_50304";
			skillConfigs.Add(config.skillId, config);

			
			// 100008
			config = new TSkillConfig();
			config.skillId = id ++;
			config.skillLevel = 1;
			config.name = "升级";
			config.skillType = SkillType.Build_Uplevel;
			config.addBuildMaxLevel = 1;
			config.operate = SkillOperateType.SelectUnit;
			config.unitType = config.unitType.UBuild(true);
			config.relation = config.relation.ROwn(true);
			config.icon = "Image/SkillIcon/skill_50301";
			skillConfigs.Add(config.skillId, config);
		}


		void Test_StartGame()
		{

			int stageId = 1091;
			VSMode vsModel = VSMode.Dungeon;

			TestWarParameter parameter = GameObject.Find("GlobalGenerator").GetComponent<TestWarParameter>();
			if(parameter != null)
			{
				stageId = parameter.stageId;
				vsModel = parameter.vsMode;

				
				if (parameter.useJsonData)
				{
					StartCoroutine (OnUseJson ());
					return;
				} 
				else if (parameter.useRecrodJson) 
				{

					StartCoroutine (WRTimeLineData.OnUseJson (parameter.watchRoleId));
					return;
				}
				else if (parameter.useRecrodBinary) 
				{

					StartCoroutine (WRTimeLineData.OnUseBinary (parameter.watchRoleId));
					return;
				}
			}

			// heroSkill=[heroId, skillId, skillLevel, skillId2, skillLevel2]
//			WarEnterData enterData = WarEnterData.CreateTest(3004, 1, new int[][]{
//				new int[]{2, 20002, 1, 1, 101, 1},
//				new int[]{5, 20003, 2, 1, 102, 1}
//			});



			WarEnterData enterData;


				enterData = WarEnterData.CreateTest(stageId, 1,
				// 自己技能
				new int[][]{
					
//										new int[]{20003, 8, 1, 0, 1},
//										new int[]{20004, 8, 1, 0, 1},
//										new int[]{20010, 8, 1, 0, 0},
//										new int[]{20102, 8, 1, 0, 0},
//										new int[]{20107, 8, 1, 0, 0},
//										new int[]{20109, 8, 1, 0, 0},
//                    new int[]{20202, 17, 1, 0, 0},
				//				new int[]{20204, 19, 1, 0, 0},
//				new int[]{20104, 8, 1, 0, 0},
//				new int[]{20205, 8, 1, 0, 0},

//									new int[]{20104, 3, 1, 0, 0},
//									new int[]{20206, 3, 1, 0, 0},
//									new int[]{20205, 12, 1, 0, 0},

                    new int[]{20301, 19, 1, 0, 0},
                    new int[]{20302, 24, 1, 0, 0},
                    new int[]{20303, 25, 1, 0, 0},
                    new int[]{20304, 32, 1, 0, 0},
                    new int[]{20305, 33, 1, 0, 0},

//                    new int[]{20301, 8, 1, 0, 0},
//                    new int[]{20302, 32, 1, 0, 0},
//                    new int[]{20303, 32, 1, 0, 0},
//                    new int[]{20304, 3, 1, 0, 0},
//                    new int[]{20305, 32, 1, 0, 0},
                    //new int[]{20202, 100004, 1, 0, 0},
                    //new int[]{20204, 100005, 1, 0, 0},
                    //new int[]{20205, 100006, 1, 0, 0},
                    //new int[]{20301, 100007, 1, 0, 0},
                    //new int[]{20302, 100008, 1, 0, 0},
				},


				//电脑技能
				new int[][]{
//					new int[]{20301, 251001, 1, 0, 0},
//					new int[]{20302, 251001, 1, 0, 0},
					//					new int[]{20303, 251001, 1, 0, 0},
					new int[]{20301, 101001, 1, 0, 0},
					new int[]{20302, 191001, 1, 0, 0},
					new int[]{20303, 251001, 1, 0, 0},
					new int[]{20304, 311001, 1, 0, 0},


				}
			);

			enterData.skillConfigDict = skillConfigs;
			enterData.vsmode = vsModel;

			War.Start(enterData);
//			StartCoroutine(CloseSound());
		}

		IEnumerator OnUseJson()
		{
			string url = PathUtil.DataUrl + "test_WarEnterData.json";
			WWW www = new WWW(url);
			yield return www;
			
			if(string.IsNullOrEmpty(www.error))
			{
				Debug.Log(url);
				WarEnterData enterData = JsonConvert.DeserializeObject(www.text, typeof(WarEnterData)) as WarEnterData;

				War.Start(enterData);
			}
			else
			{
				Debug.Log(string.Format("<color=red>[WarEnterData] test_WarEnterData.json失败 url={0} error={1}  text={2}</color>", url, www.error, www.text));
			}
			
			www.Dispose();
			www = null;


//			StartCoroutine(CloseSound());
		}



		IEnumerator CloseSound()
		{
			yield return new WaitForSeconds(1);
			Coo.soundManager.gameObject.SetActive(false);
		}

	}
}