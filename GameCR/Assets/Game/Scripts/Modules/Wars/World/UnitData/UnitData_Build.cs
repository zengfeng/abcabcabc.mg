using UnityEngine;
using System.Collections;
using Games.Module.Props;
using System.Collections.Generic;
using CC.Runtime.Utils;
using CC.Runtime.signals;
using System;
using Games.Module.Avatars;
using Games.Cores;

namespace Games.Module.Wars
{
	public partial class UnitData
	{
		#region 建筑功能
		public bool isProduceing;


		public bool build_uplevel;
		public bool build_produce;
		public bool build_turret;
		public bool build_spot;
		public int build_addMaxLevel = 0;
		#endregion

		public BuildConfig 			buildConfig;
		public BuildLevelConfig 	buildLevelConfig
		{
			get
			{
				return buildConfig.GetLevelConfig(level);
			}
		}

		public float GetBuildUplevelRequireHp(float per)
		{
			return buildLevelConfig.uplevelRequireHP * per;
		}

		public void BuildSkillCostHP(float costHP)
		{
			if(costHP > 0)
			{
				hp = hp - costHP;
				if(hp < 0) hp = 0;
			}
		}
		
		public void BuildSkillCostHPPer(float costHPPer)
		{
			if(costHPPer > 0)
			{
				hp = hp- GetBuildUplevelRequireHp(costHPPer);
				if(hp < 0) hp = 0;
			}
		}




		public void BuildInit()
		{
			avatarConfig = buildLevelConfig.avatarConfig;


			// 势力--战前属性
			this.AppProps(legionData.buildInitAttachPropData);
			
			AddBuildModule(buildLevelConfig.basepropConfig);
			AddBuildModule(buildLevelConfig.produceConfig);
			AddBuildModule(buildLevelConfig.turretConfig);
			AddBuildModule(buildLevelConfig.spotConfig);
			
			// 势力--附加建筑属性
			legionData.buildPropContainer.UnitApp(this);
			
			// 建筑第一次初始化属性  HpAdd
			this.AppProps(War.sceneData.GetBuildFistProps(id));
			// 建筑初始属性  InitHP
			this.AppProps(War.sceneData.GetBuildInitProps(id), true);
		}

		public void BuildUplevel(int level)
		{
//			Debug.LogFormat("<color=green>BuildSkillUplevel level={0}, this.level={1}</color>", level, this.level);

			BuildLevelConfig buildLevelConfig = buildConfig.GetLevelConfig(this.level);
			
			RemoveBuildModule(buildLevelConfig.basepropConfig);
			RemoveBuildModule(buildLevelConfig.produceConfig);
			RemoveBuildModule(buildLevelConfig.turretConfig);
			RemoveBuildModule(buildLevelConfig.spotConfig);

			
			buildLevelConfig = buildConfig.GetLevelConfig(level);
			AddBuildModule(buildLevelConfig.basepropConfig);
			AddBuildModule(buildLevelConfig.produceConfig);
			AddBuildModule(buildLevelConfig.turretConfig);
			AddBuildModule(buildLevelConfig.spotConfig);
			
			this.Props.Calculate();
			avatarConfig = buildLevelConfig.avatarConfig;
//			Debug.Log(avatarConfig);
//			Debug.Log(avatarConfig.Model);

			if(unit != null)
			{
				if(legionId == War.ownLegionID)
				{
					War.textEffect.PlayImage(TextEffectImageType.Uplevel, unit.transform);
				}
			}
		}

		public void BuildChangeLegion(int legionId)
		{
			RevokeBuildSpotConfig();
			if (buildLevelConfig != null) 
			{
				RemoveBuildModule (buildLevelConfig.basepropConfig);
				RemoveBuildModule (buildLevelConfig.produceConfig);
				RemoveBuildModule (buildLevelConfig.turretConfig);
				RemoveBuildModule (buildLevelConfig.spotConfig);
			}

			int preLegionId = this.legionId;

			float hp = this.hp;
			this.legionId = legionId;
			this.RevokeAll();
			SignalFactory.GetInstance<WarBuildChangeLegion>().Dispatch(this, preLegionId, this.legionId);
			this.changeTeaming = true;
			if(this.level > 1) this.level -= 1;
			build_addMaxLevel = 0;
			
			avatarConfig = buildLevelConfig.avatarConfig;

			// 势力--战前属性
			this.AppProps(legionData.buildInitAttachPropData);
			// 势力--附加建筑属性
			legionData.buildPropContainer.UnitApp(this);

			AppBuildModules();

			AddBuildModule(buildLevelConfig.basepropConfig);
			AddBuildModule(buildLevelConfig.produceConfig);
			AddBuildModule(buildLevelConfig.turretConfig);
			AddBuildModule(buildLevelConfig.spotConfig);

			// 建筑初始属性  InitHP
			this.AppProps(War.sceneData.GetBuildInitProps(id), true);
			
			this.hp = hp;
			if(float.IsNaN(hp))
			{
				Debug.Log(string.Format("<color=red>hp={0}</color>", hp));
			}
			
			sos = false;
		}


		public void BuildChangeBuildConfig(int buildId)
		{
			RemoveBuildModule(buildLevelConfig.basepropConfig);
			RemoveBuildModule(buildLevelConfig.produceConfig);
			RemoveBuildModule(buildLevelConfig.turretConfig);
			RemoveBuildModule(buildLevelConfig.spotConfig);
			
			buildConfig = War.model.GetBuildConfig(buildId);
			levelData.CheckLevel();
			
			AddBuildModule(buildLevelConfig.basepropConfig);
			AddBuildModule(buildLevelConfig.produceConfig);
			AddBuildModule(buildLevelConfig.turretConfig);
			AddBuildModule(buildLevelConfig.spotConfig);
			
			this.Props.Calculate();
			avatarConfig = buildLevelConfig.avatarConfig;
		}



		public void BuildAttachModule(AbstractBuildConfig config)
		{
			AddBuildModule(config);
			this.Props.Calculate();
		}



		public List<AbstractBuildConfig> buildModules = new List<AbstractBuildConfig>();
		public BuildProduceConfig lastBuildProduceConfig;
		public BuildSpotConfig lastBuildSpotConfig;
		public BuildTurretConfig lastBuildTurretConfig;
		public void AddBuildModule(AbstractBuildConfig config, bool calculate = false)
		{
			if(config == null) return;

			buildModules.Add(config);
			config.App(uid, this, calculate);

			switch(config.buildModuleType)
			{
			case BuildModuleType.Produce:
				lastBuildProduceConfig = (BuildProduceConfig) config;
				build_produce = true;
				break;
			case BuildModuleType.Turret:
				lastBuildTurretConfig = (BuildTurretConfig) config;
				build_turret = true;
				break;
			case BuildModuleType.Spot:
				lastBuildSpotConfig = (BuildSpotConfig) config;
				build_spot = true;
				break;
			}
		}

		public void RemoveBuildModule(AbstractBuildConfig config, bool calculate = false)
		{
			if(config == null) return;

			buildModules.Remove(config);
			config.Revoke(uid, this, calculate);

			switch(config.buildModuleType)
			{
			case BuildModuleType.Produce:
				if(lastBuildProduceConfig == config)
				{
					lastBuildProduceConfig = null;
					build_produce = false;
				}
				break;
			case BuildModuleType.Turret:
				if(lastBuildTurretConfig == config)
				{
					lastBuildTurretConfig = null;
					build_turret = false;
				}
				break;
			case BuildModuleType.Spot:
				if(lastBuildSpotConfig == config)
				{
					lastBuildSpotConfig = null;
					build_spot = false;
				}
				break;
			}
		}

		public void AppBuildModules(bool calculate = false)
		{
			int count = buildModules.Count;

			bool c = calculate;
			for(int i = 0; i < count; i ++)
			{
				c = !calculate || i == count - 1;
				
				buildModules[i].App(uid, this, c);
			}
		}

		public void RevokeBuildSpotConfig()
		{
			int count = buildModules.Count;
			List<AbstractBuildConfig> list;
			for(int i = 0; i < count; i ++)
			{
				if(buildModules[i].buildModuleType == BuildModuleType.Spot)
				{
					buildModules[i].Revoke(uid, this, true);
				}
			}
		}
		
		public void AppBuildSpotConfig()
		{
			int count = buildModules.Count;
			
			for(int i = 0; i < count; i ++)
			{
				if(buildModules[i].buildModuleType == BuildModuleType.Spot)
				{
					buildModules[i].App(uid, this);
				}
			}
		}


		/** 被攻打状态持久时间 */
		public float changeBuildConfigTime = 0.3F;
		/** 被攻打状态时间 */
		public float _changeBuildTime = 0;
		public float changeBuildTime
		{
			get
			{
				return _changeBuildTime;
			}
			
			set
			{
				_changeBuildTime = value;
			}
		}
		
		/** 是否被攻打 */
		public bool changeBuilding
		{
			get
			{
				return _changeBuildTime > 0;
			}
			
			set
			{
				if(value)
				{
					_changeBuildTime = changeBuildConfigTime;
				}
				else
				{
					_changeBuildTime = 0f;
				}
			}
		}

	}
	

}
