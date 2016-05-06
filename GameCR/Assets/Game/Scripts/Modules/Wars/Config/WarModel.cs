using UnityEngine;
using System.Collections;
using CC.Runtime;
using System.Collections.Generic;
using CC.Runtime.Utils;
using Games.Cores;
using Games.Manager;
using Games.conf;

namespace Games.Module.Wars
{
	public class WarModel : Model 
	{
		/*------------stage config--------------*/
		public Dictionary<int, StageConfig> stageConfigs_Index = new Dictionary<int, StageConfig>();

		public override void LoadConfig ()
		{
			base.LoadConfig ();
			LoadConfig<int, NeutralExpConfig>();

			LoadConfig<int, BuildWallConfig>();
			LoadConfig<int, BuildBasepropConfig>();
			LoadConfig<int, BuildProduceConfig>();
			LoadConfig<int, BuildTurretConfig>();
			LoadConfig<int, BuildSpotConfig>();
			LoadConfig<int, BuildLevelConfig>();
			LoadConfig<int, StagePositionConfig>();
			LoadConfig<int, StageWeightConfig>();




			LoadConfig<int, MapConfig>();
			LoadConfig<int, AIConfig>();
			LoadConfig<int, WinConfig>();
			LoadConfig<int, StarConfig>();
			LoadConfig<int, StageConfig>();
			LoadConfig<int, MonsterConfig>();

			LoadConfig<int, SkillWarDisplayConf>();
            LoadConfig<int, SkillWarEffectConf>();
            LoadConfig<int, SkillWarConf>();


			
			LoadConfig<int, LegionLevelConfig>();
			LoadConfig<int, LegionLevelSoliderExpConfig>();
			LoadConfig<int, LegionLevelHeroExpConfig>();

			
//			LoadConfig<int, SkillConfig>();
//          LoadConfig<int, SkillData>();
//			LoadConfig<int, BuffData>();
//			LoadConfig<int, DamageData>();
//			LoadConfig<int, FallData>();
//			LoadConfig<int, FastArmData>();
//			LoadConfig<int, FxData>();
//			LoadConfig<int, HealData>();
//			LoadConfig<int, ProjectileData>();
//			LoadConfig<int, ShieldData>();
//			LoadConfig<int, StateEffectData>();
//			LoadConfig<int, SummonData>();
//			LoadConfig<int, PropertyEffectData>();
//			LoadConfig<int, PropertyToDamageEffectData>();
//			LoadConfig<int, RoraEffectData>();
			Coo.configManager.GetConfig<int, ConstConfig>();

//			CallUtil.Instance.AddFrameOnce(OnFrame);

		}

		void OnFrame()
		{
			CallUtil.Instance.RemoveFrameOnce(OnFrame);
			
//			SettingEffectDatas();
//			SettingSkillDatas();
		}

		/*------------prop weight config--------------*/
		public Dictionary<int, StageWeightConfig> weightConfigs = new Dictionary<int, StageWeightConfig>();
		public void AddWeightConfig(StageWeightConfig config)
		{
			weightConfigs.Add(config.id, config);
		}

		public bool HasWeightConfig(int id)
		{
			return weightConfigs.ContainsKey (id);
		}

		public StageWeightConfig GetWeightConfig(int id)
		{
			StageWeightConfig config;
			if(weightConfigs.TryGetValue(id, out config))
			{
				return config;
			}
			return null;
		}

		
		/*------------map config--------------*/
		public Dictionary<int, MapConfig> mapConfigs = new Dictionary<int, MapConfig>();
		public void AddMapConfig(MapConfig config)
		{
			mapConfigs.Add(config.id, config);
		}
		
		public MapConfig GetMapConfig(int id)
		{
			MapConfig config;
			if(mapConfigs.TryGetValue(id, out config))
			{
				return config;
			}
			return null;
		}
		
		/*------------ai config--------------*/
		public Dictionary<int, AIConfig> aiConfigs = new Dictionary<int, AIConfig>();
		public void AddAIConfig(AIConfig config)
		{
			aiConfigs.Add(config.id, config);
		}
		
		public AIConfig GetAIConfig(int id)
		{
			AIConfig config;
			if(aiConfigs.TryGetValue(id, out config))
			{
				return config;
			}
			return null;
		}
		
		/*------------win config--------------*/
		public Dictionary<int, WinConfig> winConfigs = new Dictionary<int, WinConfig>();
		public void AddWinConfig(WinConfig config)
		{
			winConfigs.Add(config.id, config);
		}
		
		public WinConfig GetWinConfig(int winId)
		{
			WinConfig config;
			if(winConfigs.TryGetValue(winId, out config))
			{
				return config;
			}
			return null;
		}

		/*------------star config--------------*/
		public Dictionary<int, StarConfig> starConfigs = new Dictionary<int, StarConfig>();
		public void AddStarConfig(StarConfig config)
		{
			starConfigs.Add(config.id, config);
		}
		
		public StarConfig GetStarConfig(int starId)
		{
			StarConfig config;
			if(starConfigs.TryGetValue(starId, out config))
			{
				return config;
			}
			return null;
		}

		/*------------stage config--------------*/
		public void AddStageConfig(StageConfig stageConfig)
		{
			stageConfigs_Index.Add(stageConfig.id, stageConfig);
		}

		
		
		public StageConfig GetStage(int stageId)
		{
			StageConfig stageConfig;
			if(stageConfigs_Index.TryGetValue(stageId, out stageConfig))
			{
				return stageConfig;
			}
			return null;
		}

		/** 获取关卡机器势力机器人ID */
		public int GetRobotId(int stageId, int legionId)
		{
			StageConfig stageConfig = GetStage (stageId);
			if (stageConfig == null) 
			{
				Debug.LogFormat ("<color=red> WarModel.GetRobotId stageId={0}  legionId={1} 关卡配置没找到</color>", stageId, legionId);
				return -1;
			}

			StageLegionConfig legionConfig;
			if (stageConfig.legionDict.TryGetValue (legionId, out legionConfig)) 
			{
				return legionConfig.robotId;
			} 
			else 
			{
				//Debug.LogFormat ("<color=red> WarModel.GetRobotId stageId={0}  legionId={1} 关卡没找到该势力配置</color>", stageId, legionId);
				return -1;
			}
		}

		
		/*------------stage position config--------------*/
		public Dictionary<int, List<StagePositionConfig>> stagePositionConfigs = new Dictionary<int, List<StagePositionConfig>>();
		public void AddStagePositionConfig(StagePositionConfig config)
		{
			List<StagePositionConfig> list = null;
			if(!stagePositionConfigs.TryGetValue(config.stageId, out list))
			{
				list = new List<StagePositionConfig>();
				stagePositionConfigs.Add(config.stageId, list);
			}
//			Debug.Log(string.Format("<color=yellow>config={0}</color>",config ));
			list.Add(config);
		}

		public List<StagePositionConfig> GetStagePositionConfigList(int stageId)
		{
			List<StagePositionConfig> list = null;
			if(!stagePositionConfigs.TryGetValue(stageId, out list))
			{
				Debug.Log(string.Format("<color=red>没有找到关卡建筑坐标配置 stageId={0}</color>", stageId));
				list = new List<StagePositionConfig>();
			}
			return list;
		}

		
		/*------------monster config--------------*/
		public Dictionary<int, MonsterConfig> monsterConfigs = new Dictionary<int, MonsterConfig>();
		public void AddMonsterConfig(MonsterConfig monsterConfig)
		{
			monsterConfigs.Add(monsterConfig.id, monsterConfig);
		}

		public MonsterConfig GetMonster(int monsterId)
		{
			MonsterConfig config;
			if(monsterConfigs.TryGetValue(monsterId, out config))
			{
				return config;
			}
			return null;
		}


        /*------------skill war--------------*/
		public Dictionary<int, SkillWarDisplayConf> skillWarDisplayConfs = new Dictionary<int, SkillWarDisplayConf>();
		public void AddSkillWarDisplayConf(SkillWarDisplayConf skillWarConf)
		{
			skillWarDisplayConfs.Add(skillWarConf.skillId, skillWarConf);
		}

		public SkillWarDisplayConf GetSkillWarDisplayConf(int skillId)
		{
			SkillWarDisplayConf skillWarConfig;
			if (skillWarDisplayConfs.TryGetValue(skillId, out skillWarConfig))
			{
				return skillWarConfig;
			}

			return null;
		}


        public Dictionary<int, SkillWarConf> skillWarConfDic = new Dictionary<int, SkillWarConf>();
        public void AddSkillWarConf(SkillWarConf skillWarConf)
        {
            skillWarConfDic.Add(skillWarConf.id, skillWarConf);
        }

        public SkillWarConf GetSkillWarConf(int skillId)
        {
            SkillWarConf skillWarConfig;
            if (skillWarConfDic.TryGetValue(skillId, out skillWarConfig))
            {
                return skillWarConfig;
            }

            return null;
        }

        public Dictionary<int, float> GetEffectValueBySkillId(int skillId)
        {
            Dictionary<int, float> effectValueDic = new Dictionary<int, float>();
            SkillWarConf skillWarConfig;
            if (skillWarConfDic.TryGetValue(skillId, out skillWarConfig))
            {
                effectValueDic = skillWarConfig.getEffectValue();
            }
            return effectValueDic;
        }


        /*------------skill war effect--------------*/
        public Dictionary<int, SkillWarEffectConf> skillWarEffectConfDic = new Dictionary<int, SkillWarEffectConf>();
        public void AddSkillWarEffectConf(SkillWarEffectConf skillWarEffectConf)
        {
            skillWarEffectConfDic.Add(skillWarEffectConf.id, skillWarEffectConf);
        }
        
        public SkillWarEffectConf GetSkillWarEffectConf(int effectId)
        {
            SkillWarEffectConf skillWarEffectConfig;
            if (skillWarEffectConfDic.TryGetValue(effectId, out skillWarEffectConfig))
            {
                return skillWarEffectConfig;
            }

            return null;
        }

		
		/*------------skill config--------------*/
//		public Dictionary<int, SkillConfig> skillConfigs = new Dictionary<int, SkillConfig>();
//		public void AddSkillConfig(SkillConfig skillConfig)
//		{
//			skillConfigs.Add(skillConfig.id, skillConfig);
//		}
//		
//		public SkillConfig GetSkillConfig(int skillId)
//		{
//			SkillConfig skillConfig;
//			if(skillConfigs.TryGetValue(skillId, out skillConfig))
//			{
//				return skillConfig;
//			}
//			
//			return null;
//		}

		/*------------skill data--------------*/
		
		/*
		public Dictionary<int, SkillData> skillDatas = new Dictionary<int, SkillData>();
		public Dictionary<int, EffectData> effectDatas = new Dictionary<int, EffectData>();

		public void AddSkillData(SkillData skillData)
		{
			skillDatas.Add(skillData.id, skillData);
		}

		public SkillData GetSkillData(int skillId)
		{
			SkillData skillData;
			if(skillDatas.TryGetValue(skillId, out skillData))
			{
				return skillData;
			}
			
			return null;
		}

		public void SettingSkillDatas()
		{
			foreach(KeyValuePair<int, SkillData> kvp in skillDatas)
			{
				kvp.Value.SettingDatas();
			}
		}

		//---------------------
		public void AddEffectData(EffectData effectData)
		{
			effectDatas.Add(effectData.id, effectData);

//			if(effectData is PropertyToDamageEffectData)
//			{
//				Debug.Log(string.Format("<color=green>AddEffectData effectData.id={0} effectData={1}</color>", effectData.id, effectData));
//			}
		}
		
		public EffectData GetEffectData(int effectId)
		{
			EffectData effectData;
			if(effectDatas.TryGetValue(effectId, out effectData))
			{
				return effectData;
			}
			
			return null;
		}
		
		public void SettingEffectDatas()
		{
			
			foreach(KeyValuePair<int, EffectData> kvp in effectDatas)
			{
				kvp.Value.SettingDatas();
			}

		} 
		*/


		public Dictionary<int, StageConfig> Editor_stageConfigs = new Dictionary<int, StageConfig>(); 
		public StageConfig Editor_GetStage(int stageId)
		{
			StageConfig stageConfig;
			if(Editor_stageConfigs.TryGetValue(stageId, out stageConfig))
			{
				return stageConfig;
			}
			return null;
		}













		
		/*------------build config--------------*/
		public Dictionary<int, BuildConfig> buildConfigs = new Dictionary<int, BuildConfig>();
		public void AddBuildLevelConfig(BuildLevelConfig buildLevelConfig)
		{
			BuildConfig buildConfig;
			if(!buildConfigs.TryGetValue(buildLevelConfig.id, out buildConfig))
			{
				buildConfig = new BuildConfig();
				buildConfig.id = buildLevelConfig.id;
				buildConfig.buildType = buildLevelConfig.buildType;
				buildConfigs.Add(buildConfig.id, buildConfig);
			}

			buildConfig.AddLevelConfig(buildLevelConfig);
		}

	
		public BuildConfig GetBuildConfig(int id)
		{
			BuildConfig buildConfig;
			if(buildConfigs.TryGetValue(id, out buildConfig))
			{
				return buildConfig;
			}
			return null;
		}
		
		
		/*------------build baseprop config--------------*/
		public Dictionary<int, BuildBasepropConfig> buildBasepropConfigs = new Dictionary<int, BuildBasepropConfig>();
		public void AddBuildBasepropConfig(BuildBasepropConfig config)
		{
			buildBasepropConfigs.Add(config.id, config);
		}
		
		public BuildBasepropConfig GetBuildBasepropConfig(int id)
		{
			BuildBasepropConfig config;
			if(buildBasepropConfigs.TryGetValue(id, out config))
			{
				return config;
			}
			return null;
		}

		
		
		/*------------build produce config--------------*/
		public Dictionary<int, BuildProduceConfig> buildProduceConfigs = new Dictionary<int, BuildProduceConfig>();
		public void AddBuildProduceConfig(BuildProduceConfig config)
		{
			buildProduceConfigs.Add(config.id, config);
		}
		
		public BuildProduceConfig GetBuildProduceConfig(int id)
		{
			BuildProduceConfig config;
			if(buildProduceConfigs.TryGetValue(id, out config))
			{
				return config;
			}
			return null;
		}
		
		
		/*------------build turret config--------------*/
		public Dictionary<int, BuildTurretConfig> buildTurretConfigs = new Dictionary<int, BuildTurretConfig>();
		public void AddBuildTurretConfig(BuildTurretConfig config)
		{
			buildTurretConfigs.Add(config.id, config);
		}
		
		public BuildTurretConfig GetBuildTurretConfig(int id)
		{
			BuildTurretConfig config;
			if(buildTurretConfigs.TryGetValue(id, out config))
			{
				return config;
			}
			return null;
		}
		
		
		/*------------build spot config--------------*/
		public Dictionary<int, BuildSpotConfig> buildSpotConfigs = new Dictionary<int, BuildSpotConfig>();
		public void AddBuildSpotConfig(BuildSpotConfig config)
		{
			buildSpotConfigs.Add(config.id, config);
		}
		
		public BuildSpotConfig GetBuildSpotConfig(int id)
		{
			BuildSpotConfig config;
			if(buildSpotConfigs.TryGetValue(id, out config))
			{
				return config;
			}
			return null;
		}
		
		/*------------build wall config--------------*/
		public Dictionary<int, BuildWallConfig> buildWallConfigs = new Dictionary<int, BuildWallConfig>();
		public void AddBuildWallConfig(BuildWallConfig config)
		{
			buildWallConfigs.Add(config.id, config);
		}
		
		public BuildWallConfig GetBuildWallConfigg(int id)
		{
			BuildWallConfig config;
			if(buildWallConfigs.TryGetValue(id, out config))
			{
				return config;
			}
			return null;
		}

		
		/*------------build module--------------*/
		/** 建筑类型 */
		public BuildType GetBuildModuleType(int buildModuleId)				
		{
			if(buildModuleId > 200 && buildModuleId < 300)
			{
				return BuildType.Turret;
			}
			else if(buildModuleId > 300)
			{
				return BuildType.Spot;
			}
			
			return BuildType.Casern;
		}

		
		/** 建筑类型 */
		public AbstractBuildConfig GetBuildModuleConfig(int buildModuleId)				
		{
			BuildType buildType = GetBuildModuleType(buildModuleId);

			switch(buildType)
			{
			case BuildType.Casern:
				return War.model.GetBuildBasepropConfig(buildModuleId);
				break;
			case BuildType.Turret:
				return War.model.GetBuildTurretConfig(buildModuleId);
				break;
			case BuildType.Spot:
				return War.model.GetBuildSpotConfig(buildModuleId);
				break;
			}
			return null;
		}

		
		/*------------legion level--------------*/
		public Dictionary<int, LegionLevelConfig> legionLevelConfigs = new Dictionary<int, LegionLevelConfig>();

		public void AddLegionLevelConfig(LegionLevelConfig config)
		{
			legionLevelConfigs.Add(config.level, config);
		}
		
		public LegionLevelConfig GetLegionLevelConfig(int level)
		{
			LegionLevelConfig config;
			if(legionLevelConfigs.TryGetValue(level, out config))
			{
				return config;
			}
			return null;
		}


		/*------------Role Exp--------------*/
		public Dictionary<int, NeutralExpConfig> neutralExpConfigs = new Dictionary<int, NeutralExpConfig>();
		
		public void AddNeutralExpConfig(NeutralExpConfig config)
		{
			neutralExpConfigs.Add(config.level, config);
		}
		
		public NeutralExpConfig GetNeutralExpConfig(int level)
		{
			NeutralExpConfig config;
			if(neutralExpConfigs.TryGetValue(level, out config))
			{
				return config;
			}
			return null;
		}



		
		/*------------Path--------------*/
		public Dictionary<int, StagePathData> stagePaths = new Dictionary<int, StagePathData>();




	}
}
