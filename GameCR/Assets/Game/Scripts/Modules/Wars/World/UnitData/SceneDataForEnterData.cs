using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games.Cores;
using Games.Module.Props;
using System.Linq;
using CC.Runtime.Utils;
using CC.Runtime.PB;

namespace Games.Module.Wars
{
	/** 战场数据--同步对战 */
	public class SceneDataForEnterData : SceneData
	{
		public WarEnterData enterData;

		/** 是否存在该势力数据 */
		bool HasEnterLegionData(int legionId)
		{
			return enterData.HasEnterLegionData(legionId);
		}

		/** 获取士兵模块属性 */
		Prop[] GetSoliderProps(int legionId)
		{
			return enterData.GetSoliderProps(legionId);
		}

		/** 获取士兵等级 */
		int GetSoliderLevel(int legionId)
		{
			return enterData.GetSoliderLevel(legionId);
		}
		
		/** 获取士兵AvatarId */
		int GetSoliderAvatarId(int legionId)
		{
			return enterData.GetSoliderAvatarId(legionId);
		}
		
		/** 获取roleId */
		int GetRoleId(int legionId)
		{
			return enterData.GetRoleId(legionId);
		}


		
		public void Generation(WarEnterData enterData)
		{
			enterData.Init();
			this.enterData = enterData;
			this.ownLegionID = enterData.ownLegionId;
#if UNITY_EDITOR
			
			Debug.Log("War.isEditor=" + War.isEditor);
			if(War.isEditor)
			{
				this.stageConfig = War.model.Editor_GetStage(enterData.stageId);
				if(this.stageConfig == null)
				{
					this.stageConfig = War.model.GetStage(enterData.stageId).Clone();
					War.model.Editor_stageConfigs.Add(this.stageConfig.id, this.stageConfig);
				}
			}
			else
			{
				this.stageConfig = War.model.GetStage(enterData.stageId);
			}
#else
			this.stageConfig = War.model.GetStage(enterData.stageId);
#endif
			
			Debug.Log("stageConfig=" + stageConfig);
			Debug.Log("stageConfig.resource=" + stageConfig.resource);
			Debug.Log("stageConfig.mapConfig=" + stageConfig.mapConfig);
			Debug.Log("enterData.ownLegionId=" + enterData.ownLegionId);
			this.mapConfig = stageConfig.mapConfig;
			War.ownLegionID = enterData.ownLegionId;
			War.mainLegionID = enterData.mainLegionId = enterData.FindMinLegionId();
			War.service.roomId = enterData.roomId;
			War.service.roleId = enterData.ownRoleId;
			War.service.ownLegionId = enterData.ownLegionId;

			
			this.id = stageConfig.id;
			this.showHP = stageConfig.showHP;

			if (War.model.HasWeightConfig (this.id)) 
			{
				this.weight = War.model.GetWeightConfig (this.id);
			}
			
			War.timeMax = stageConfig.time;

			begionDelayTime = War.vsmode == VSMode.PVP ? 2 : 0;


			if(War.isEditor)
			{
				War.timeMax = 0;
			}

//			War.timeMax = 20;

			War.timeLimit = War.timeMax > 0f;
//			if(War.isTest) showHP = false;
			GenerationLegions();
			GenerationSoliders();
			GenerationHeros();
			GenerationBuilds();
			GenerationWalls();

			foreach(KeyValuePair<int, LegionData> kvp  in legionDict)
			{
				kvp.Value.Init();
			}
			InitAttachPropData();
			InitUseSkillBuildId();
		}

		/** 生成数据--势力 */
		public void GenerationLegions()
		{
			// 占用自己颜色的势力
			LegionData occupyMainLegionData = null;

			War.realPlayerCount = 0;

			// 创建势力数据LegionData
			foreach(KeyValuePair<int, StageLegionConfig> kvp in stageConfig.legionDict)
			{
				StageLegionConfig legionConfig = kvp.Value;
				LegionData legionData;
				if(legionConfig.type == LegionType.Player)
				{
					legionData = new LegionData(legionConfig.legionId, "Player-"+legionConfig.legionId, LegionType.Player, legionConfig.aiSendArm, legionConfig.aiUplevel, legionConfig.aiSkill, legionConfig.produce);
					if(enterData.vsmode == VSMode.PVP && legionData.legionId != ownLegionID)
					{
						legionData.aiSendArm = false;
						legionData.aiSkill = false;
						legionData.aiUplevel = false;
					}
				}
				else if(legionConfig.type == LegionType.Computer)
				{
					legionData = new LegionData(legionConfig.legionId, "Player-"+legionConfig.legionId, LegionType.Computer, legionConfig.aiSendArm, legionConfig.aiUplevel, legionConfig.aiSkill, legionConfig.produce);
					if(enterData.vsmode == VSMode.PVP && !War.isMainLegion)
					{
						legionData.aiSendArm = false;
						legionData.aiSkill = false;
						legionData.aiUplevel = false;
					}
				}
				else
				{
					legionData = new LegionData(legionConfig.legionId, "Player-"+legionConfig.legionId, LegionType.Neutral, legionConfig.aiSendArm, legionConfig.aiUplevel, legionConfig.aiSkill, legionConfig.produce);
					if(enterData.vsmode == VSMode.PVP && !War.isMainLegion)
					{
						legionData.aiSendArm = false;
						legionData.aiSkill = false;
						legionData.aiUplevel = false;
					}
				}





				legionData.produceLimit = legionConfig.produceLimit;
				legionData.colorId = legionConfig.color;
				legionDict.Add(legionData.legionId , legionData);

				if(legionData.colorId == War.config.ownDefaultColor)
				{
					occupyMainLegionData = legionData;
				}
				
				legionData.roleId = enterData.GetRoleId(legionData.legionId);
				if(!roleDict.ContainsKey(legionData.roleId)) roleDict.Add(legionData.roleId, legionData);

				legionData.expeditionTotalMaxHP = enterData.GetTotalMaxHP(legionData.legionId);
				legionData.expeditionTotalHP = enterData.GetTotalHP(legionData.legionId);
				legionData.expeditionInitHP = legionData.expeditionTotalHP;
				legionData.expeditionLeftHP = legionData.expeditionTotalHP;


				WarEnterLegionData enterLegionData = enterData.GetEnterLegionData(legionData.legionId);
				if(enterLegionData != null)
				{
					legionData.name = enterLegionData.name;
					legionData.headAvatarId = enterLegionData.headAvatarId;
					legionData.levelData.intBattleForce = enterLegionData.totalAtk; 
					legionData.levelData.intProduceSpeed = enterLegionData.totalProduceSpeed; 
					legionData.levelData.intMoveSpeed = enterLegionData.totalMoveSpeed;
					legionData.levelData.initHP = enterLegionData.initHP;

					legionData.levelData.maxBattleForce = enterLegionData.maxAtk; 
					legionData.levelData.maxProduceSpeed = enterLegionData.maxProduceSpeed; 
					legionData.levelData.maxMoveSpeed = enterLegionData.maxMovespeed;

					
					legionData.levelData.subBattleForce = enterLegionData.subAtk; 
					legionData.levelData.subProduceSpeed = enterLegionData.subProduceSpeed; 
					legionData.levelData.subMoveSpeed = enterLegionData.subMoveSpeed;

					legionData.sendArmRate = enterLegionData.sendArmRate;

					if(enterLegionData.isRobot)
					{
						if(enterData.vsmode == VSMode.PVP && War.isMainLegion && legionData.colorId != 0)
						{
							legionData.aiSendArm = true;
							legionData.aiSkill = true;
							legionData.aiUplevel = true;
						}
						legionData.type = LegionType.Computer;

						if(legionData.colorId == 0)
						{
							legionData.type = LegionType.Neutral;
						}
					}
					else
					{
						legionData.type = LegionType.Player;
						legionData.aiSendArm = false;
						legionData.aiSkill = false;
						legionData.aiUplevel = false;
					}


					if(enterLegionData.ai > 0)
					{
						legionData.aiConfig = War.model.GetAIConfig(enterLegionData.ai); ;
					}
				}
				else
				{
					NeutralExpConfig roleExpConfig = War.model.GetNeutralExpConfig(stageConfig.neutralRoleLevel);

					legionData.levelData.intBattleForce = roleExpConfig.props[PropId.BattleForceAdd]; 
					legionData.levelData.intProduceSpeed = roleExpConfig.props[PropId.ProduceSpeedAdd]; 
					legionData.levelData.intMoveSpeed = roleExpConfig.props[PropId.MoveSpeedAdd]; 
					legionData.levelData.initHP = roleExpConfig.props[PropId.HpAdd]; 


					if(legionData.colorId == 0)
					{
						legionData.type = LegionType.Neutral;
					}
					else
					{
						legionData.type = LegionType.Computer;
					}
				}

				if(legionConfig.type == LegionType.Player)
				{
					War.realPlayerCount ++;
				}


				if(War.isEditor)
				{
					legionData.aiSendArm = false;
					legionData.aiSkill = false;
					legionData.produce = false;
					legionData.aiUplevel = false;
				}


				if(War.isTest)
				{
					if (legionData.type == LegionType.Computer || (legionData.type == LegionType.Player && legionData.legionId != War.ownLegionID))
					{
						legionData.aiSendArm = true;
						legionData.aiSkill = true;
						legionData.produce = true;
						legionData.aiUplevel = true;
						legionData.aiConfig = stageConfig.id >= 71 && stageConfig.id <= 80 ? War.model.GetAIConfig(102) : War.model.GetAIConfig(302);
					}
				}

				if (War.isRecord)
				{
					legionData.aiSendArm = false;
					legionData.aiSkill = false;
					legionData.aiUplevel = false;
				}


				int id = GetPlayerUID(legionData.legionId);

				// 势力单位数据
				UnitData unitData = new UnitData();
				unitData.id = id;
				unitData.legionId = legionData.legionId;
				unitData.unitType = UnitType.Player;
				float x = 5 * Mathf.FloorToInt((legionData.legionId + 1) / 2) * (legionData.legionId % 2 == 0 ? 1 : -1);
				unitData.position = new Vector3(x, 0f, -11F);
				legionData.unitData = unitData;

				/** 战前势力--怒气上限 */
				legionData.legionInitProp[PropId.InitMaxMage] = WarFormula.WF_Legion_MaxMage();
				/** 战前势力--怒气 */
				legionData.legionInitProp[PropId.MagAdd] = legionData.legionInitProp[PropId.InitMag] = enterData.vsmode != VSMode.PVE_Expedition ? WarFormula.WF_Legion_Mage() : enterData.GetMag(legionData.legionId);
				/** 战前势力--怒气 */
				legionData.legionInitProp[PropId.InitMageSpeed] = ConstConfig.GetFloat(ConstConfig.ID.War_DV_Mag_Recovery_Ratio);



                //TODO Test
                //legionData.aiSendArm = true;
               	//legionData.aiSkill = true;
                //legionData.aiConfig = War.model.GetAIConfig(302);
            }

            // 获取自己势力数据
            ownLegion = legionDict[ownLegionID];


			// 交换势力颜色
			if(occupyMainLegionData != null && occupyMainLegionData != ownLegion)
			{
				int tempColorId = ownLegion.colorId;
				ownLegion.colorId = occupyMainLegionData.colorId;
				occupyMainLegionData.colorId = tempColorId;
			}
			else
			{
				ownLegion.colorId = War.config.ownDefaultColor;
			}


			// 创建势力联盟数据LegionGroupData
			foreach(StageLegionGroupConfig groupConfig in stageConfig.legionGroups)
			{
				LegionGroupData groupData = new LegionGroupData(groupConfig.id);
				legionGroupDict.Add(groupData.id, groupData);

				foreach(StageLegionConfig legionConfig in groupConfig.list)
				{
					groupData.AddLegion(legionDict[legionConfig.legionId]);
				}
			}

			
			List<int> colorIdList = new List<int>();
			foreach(KeyValuePair<int, LegionData> legionKVP in War.sceneData.legionDict)
			{
				colorIdList.Add(legionKVP.Value.colorId);
			}
			
			colorIds = colorIdList.ToArray();
		}
		
		/** 生成数据--士兵 */
		public void GenerationSoliders()
		{
			// 创建士兵UnitData
			foreach(KeyValuePair<int, StageLegionConfig> kvp in stageConfig.legionDict)
			{
				StageLegionConfig legionConfig = kvp.Value;
				UnitData unitData = new UnitData();
				unitData.unitType = UnitType.Solider;
				unitData.legionId = legionConfig.legionId;
				unitData.avatarId = 30101;
				
				LegionData legionData = legionDict[legionConfig.legionId];



				// 电脑士兵属性
				if(!HasEnterLegionData(unitData.legionId))
				{
					Prop[] soliderModuleProps = WarTestData.GetSoliderProps();

					float[] props = soliderModuleProps.PropsToInit_Float();
					props[PropId.HpAdd] = props[PropId.InitHp] = props[PropId.InitMaxHp];
					legionData.soliderInitProp = props;

//					Debug.Log("Comupter soldierMonsterId= " + legionConfig.soldierMonsterId + " " +   props.ToStrProp());
				}
				// 玩家士兵属性
				else
				{
					float[] props = GetSoliderProps(legionConfig.legionId).PropsToInit_Float();
					props[PropId.HpAdd] = props[PropId.InitHp] = props[PropId.InitMaxHp];
					legionData.soliderInitProp = props;
					unitData.level = GetSoliderLevel(unitData.legionId);
					unitData.avatarId = GetSoliderAvatarId(unitData.legionId);

//					Debug.Log("soliderProps=" + props.ToStrProp());
				}

				// 把“士兵数据”保存到“势力数据"里
				legionData.soliderData = unitData;

//				Debug.Log(string.Format("<color=green>legionId={0}</color>", legionConfig.legionId));

				// 复制士兵斩将率到势力数据
				legionData.legionInitProp[PropId.InitKillHero] = WarFormula.WF_Legion_KillHero(legionData.soliderInitProp[PropId.InitKillHero]);
//				Debug.Log(string.Format("<color=green>legionId={0}, legionData.legionInitProp[PropId.InitKillHero]={1}</color>", legionConfig.legionId, legionData.legionInitProp[PropId.InitKillHero]));
			}
		}

		
		
		/** 生成数据--英雄 */
		public void GenerationHeros()
		{
			LegionData legionData;

			int itemLegionId;
			int itemHeroId;
			int itemAvatarId;
			string itemName;
			int quality = 1;
			int skillId;
			int skillLevel;
			int skillId2;
			int skillLevel2;
			float[] hero2BuildProps;
			float[] props;

			// 生成英雄数据UnitData
			foreach(WarEnterLegionData enterLegionData in enterData.legionList)
			{
				itemLegionId = enterLegionData.legionId;

				legionData = legionDict[itemLegionId];

				foreach(WarEnterHeroData enterHeroData in enterLegionData.heroList)
				{
					itemHeroId = enterHeroData.heroId;
					itemAvatarId = enterHeroData.avatarId;
					itemName = enterHeroData.name;
					skillId = enterHeroData.skillId;
					skillLevel = enterHeroData.level;
					quality = enterHeroData.quality;
					skillId2 = 0;
					skillLevel2 = 0;


					// 获取玩家英雄属性
					hero2BuildProps = new float[PropId.MAX];
					hero2BuildProps = hero2BuildProps.PropAdd( enterHeroData.props);

					props = enterHeroData.props.PropsToInit_Float();
					props[PropId.InitDefKillHero] = WarFormula.WF_Hero_DefKillHero_Player(props[PropId.InitDefKillHero]);

					CreateHero(itemLegionId, itemHeroId, itemAvatarId, itemName, quality,
					           skillId, skillLevel,
					           hero2BuildProps, props
					           );

				}
			}

			foreach(var kvp in legionDict)
			{
				legionData = kvp.Value;
				itemLegionId = legionData.legionId;

				if(legionData.type != LegionType.Neutral)
				{
					itemHeroId = 1;
					itemAvatarId = legionData.headAvatarId;
					itemName = legionData.name;
					skillId = War.config.roleSkillId;
					skillLevel = 1;
					skillId2 = 0;
					skillLevel2 = 0;
					
					
					// 获取玩家英雄属性
					hero2BuildProps = new float[PropId.MAX];
					props = new float[PropId.MAX];
					
					CreateHero(itemLegionId, itemHeroId, itemAvatarId, itemName, quality,
					           skillId, skillLevel,
					           hero2BuildProps, props
					           );
					legionData.initUseSkillId = skillId;
				}
			}

		}

		void InitUseSkillBuildId()
		{

			Dictionary<int, int> legionMaxBuild = new Dictionary<int, int>();
			Dictionary<int, int> legionMaxLevel = new Dictionary<int, int>();

			foreach(var item in buildDict)
			{
				int legionId = item.Value.legionId;
				int buildId = item.Value.uid;
				int buildLevel = stageConfig.buildDict[buildId].settledPriority;

				if( legionMaxLevel.ContainsKey( legionId))
				{
					if(legionMaxLevel[legionId] < buildLevel)
					{
						legionMaxLevel[legionId] = buildLevel;
						legionMaxBuild[legionId] = buildId;
					}

				}
				else
				{
					legionMaxBuild.Add( legionId, buildId);
					legionMaxLevel.Add( legionId, buildLevel);
				}
			}


			foreach(var item in legionMaxBuild)
			{
				LegionData legionData = legionDict[item.Key];
				if(legionData.type != LegionType.Neutral)
				{
					legionData.initUseSkillBuildId = item.Value;
				}
			}
		}

		void CreateHero(int itemLegionId, int itemHeroId, int avatarId, string name, int quality, int skillId, int skillLevel,  float[] hero2BuildProps, float[] props)
		{
			
			// 创建英雄单位数据UnitData
			UnitData unitData = new UnitData();
			unitData.unitType = UnitType.Hero;
			unitData.id = GetHeroUID(itemHeroId, itemLegionId);
			
			// 将“英雄单位数据UnitData”保存到”势力数据LegionData“里
			LegionData legionData = legionDict[itemLegionId];
			legionData.heroUnitDatas.Add(itemHeroId, unitData);
			
			unitData.legionId = legionData.legionId;
			
			// 创建英雄数据HeroData
			HeroData heroData = new HeroData();
			heroData.heroUid = unitData.id;
			heroData.heroId = itemHeroId;
			heroData.name = name;
			heroData.quality = quality;
			heroData.avatarId = avatarId;
			heroData.originalLegion = legionData.legionId;
			legionData.heroDatas.Add(heroData.heroId, heroData);
			legionData.heroInitProp.Add(heroData.heroId, props);
			legionData.hero2BuildProp.Add(heroData.heroId, hero2BuildProps);
			
			
			
			
			// 如果英雄技能激活了，生成英雄技能操作数据
			if(skillId > 0)
			{
				SkillOperateData skillData = new SkillOperateData();
				skillData.skillId = skillId;
				skillData.uid = GetSkillUID(skillData.skillId, legionData.legionId, heroData.heroId);
				skillData.skillLevel = skillLevel;
				skillData.heroData = heroData;
				skillData.skillConfig = enterData.GetSkillConfig(skillData.skillId);
				skillData.Init();
				heroData.skillOperateData = skillData;
				legionData.skillDatas.Add(skillData.uid, skillData);
				skillOperateDataForUID.Add(skillData.uid, skillData);
			}
		}
		
		/** 生成数据--兵营 */
		public void GenerationBuilds()
		{
			Dictionary<int, float[]> 	legionHeroTotals = new Dictionary<int, float[]>();
			Dictionary<int, int> 		legionHeroCounts = new Dictionary<int, int>();

			foreach(KeyValuePair<int, LegionData> legionKVP in legionDict)
			{
				LegionData legionData = legionKVP.Value;
				float[] heroTotals = new float[PropId.MAX];
				int heroCount = 0;
				foreach(KeyValuePair<int, float[]> heroKVP in  legionData.heroInitProp)
				{
					heroCount ++;
					heroTotals.PropAdd(heroKVP.Value);
				}
				
				legionHeroTotals.Add(legionData.legionId, heroTotals);
				legionHeroCounts.Add(legionData.legionId, heroCount);
			}



			foreach(KeyValuePair<int, StageLegionConfig> kvp in stageConfig.legionDict)
			{
				StageLegionConfig legionConfig = kvp.Value;
				LegionData legionData = legionDict[legionConfig.legionId];

				
				float[] soliderInitProp_Final = new float[PropId.MAX];
				soliderInitProp_Final.PropAdd(legionData.soliderInitProp);
				soliderInitProp_Final.Calculate();

				legionHeroTotals[legionData.legionId].Calculate();

				
				//------------------ 生成势力 士兵属性(士兵模块提供攻击+参战武将战前攻击之和) -----------------------//

			//	Debug.Log(legionData.legionId +  " <color=green>F legionData.soliderData.Props</color>" + legionData.soliderInitProp.ToStrProp());
//				legionData.soliderInitProp[PropId.InitAtk] = WarFormula.WF_Solider_Atk(legionData.levelData.intBattleForce, legionHeroTotals[legionData.legionId][PropId.Atk]);
				legionData.soliderInitProp[PropId.InitBattleForce] = WarFormula.WF_Solider_BattleForce(legionData.levelData.intBattleForce);
				legionData.soliderInitProp[PropId.InitMoveSpeed] = WarFormula.WF_Solider_MoveSpeed(legionData.levelData.intMoveSpeed, legionHeroTotals[legionData.legionId][PropId.MoveSpeed]);

			//	Debug.Log(legionData.legionId +  " <color=green>B legionData.soliderData.Props=</color>" + legionData.soliderInitProp.ToStrProp());

				//------------------ 生成势力 兵营属性(产兵速度, 防御, 兵力上限) -----------------------//
				
				float[] props = new float[PropId.MAX];
				
				// 战前兵营--产兵速度
				props[PropId.InitProduceSpeed] = WarFormula.WF_Casern_ProduceSpeed(legionData.levelData.intProduceSpeed, legionHeroTotals[legionData.legionId][PropId.ProduceSpeed]) ;
				// 战前兵营--防御
//				props[PropId.InitDef] = WarFormula.WF_Casern_Def(legionData.levelData.intBattleForce, legionHeroTotals[legionData.legionId][PropId.Def]);
				props[PropId.InitBattleForce] = WarFormula.WF_Casern_BattleForce(legionData.levelData.intBattleForce);

				// 战前兵营--兵力上限
				props[PropId.InitMaxHp] = WarFormula.WF_Casern_MaxHP(legionHeroTotals[legionData.legionId][PropId.MaxHp]);
//				// 战前兵营--速攻
//				props[PropId.InitSpeedAtk] = WarFormula.WF_Casern_SpeedAtk(legionData.levelData.intBattleForce, legionHeroTotals[legionData.legionId][PropId.SpeedAtk]);

				//Debug.Log ("legionData.legionId=" + legionData.legionId + "  " +  props.ToStrProp());

				// 设置势力--兵营战前属性
				legionData.buildInitProp = props;

			}


			// 兵营初始兵力（血量Hp）
			foreach(KeyValuePair<int, StagePositionConfig> kvp in stageConfig.buildDict)
			{
				
				StagePositionConfig buildConfig = kvp.Value;
				LegionData legionData = legionDict[buildConfig.legionId];


				
				float[] full = new float[PropId.MAX];
				full.PropAdd(legionData.buildInitProp);


				float hero_InitSpeedAtk = 0f;
//				HeroData heroData;
//				if(herosByBuild.TryGetValue(buildConfig.index, out heroData))
//				{
//					hero_InitSpeedAtk = legionData.heroInitProp[heroData.heroId][PropId.InitSpeedAtk];
//				}


				// 初始兵力--计算
//				Debug.Log(string.Format("<color=yellow>buildConfig.index={0}, buildConfig.hp={1}</color>, full[PropId.MaxHp]={2}, hasHero={3} heroMaxHp={4}", buildConfig.index, buildConfig.hp, full[PropId.MaxHp],herosByBuild.ContainsKey(buildConfig.index), heroMaxHp));
//				float hp = WarFormula.WF_Casern_Hp(buildConfig.hp, legionData.buildInitProp[PropId.InitMaxHp], herosByBuild.ContainsKey(buildConfig.index), heroMaxHp);
				float hp = WarFormula.WF_Casern_Hp(buildConfig.hp, legionData.levelData.initHP);

				float[] firstProp = new float[PropId.MAX];
				firstProp[PropId.HpAdd] = hp;

				
				// 兵营初始属性[Hp]
				float[] initProp = new float[PropId.MAX];
				initProp[PropId.InitHp] = hp;
				
				buildFirstProp.Add(buildConfig.index, firstProp);
				buildInitProp.Add(buildConfig.index, initProp);
			}

			int casernCount = 0;
			int turretCount = 0;
			int spotCount = 0;

			// 生成兵营UnitData
			foreach(KeyValuePair<int, StagePositionConfig> kvp in stageConfig.buildDict)
			{
				StagePositionConfig positionConfig = kvp.Value;
				
				UnitData unitData = new UnitData();
				unitData.id = positionConfig.index;
				unitData.legionId = positionConfig.legionId;
				unitData.unitType = UnitType.Build;
				unitData.buildType = positionConfig.buildType;
				unitData.level = positionConfig.level;
				unitData.position = positionConfig.position;
				unitData.buildConfig = positionConfig.buildConfig;
				unitData.we_BuildConfigData = new WE_BuildConfigData();
				unitData.we_BuildConfigData.hp = (int)positionConfig.hp;
				unitData.we_BuildConfigData.settledPriority = positionConfig.settledPriority;
				unitData.we_BuildConfigData.buildConfig = unitData.buildConfig;


				buildDict.Add(positionConfig.index, unitData);

				switch(unitData.buildType)
				{
				case BuildType.Casern:
					casernCount++;
					break;
				case BuildType.Turret:
					turretCount++;
					break;
				case BuildType.Spot:
					spotCount++;
					break;
				}
			}

			legionTotalMaxHP = casernCount * ConstConfig.GetFloat(ConstConfig.ID.War_StageLegionTotalMaxHP_Ratio_Casern) 
				+ turretCount * ConstConfig.GetFloat(ConstConfig.ID.War_StageLegionTotalMaxHP_Ratio_Turret) 
				+ spotCount * ConstConfig.GetFloat(ConstConfig.ID.War_StageLegionTotalMaxHP_Ratio_Spot) ;


			foreach(KeyValuePair<int, LegionData> kvp in legionDict)
			{
				kvp.Value.totalMaxHP = legionTotalMaxHP;
			}

		}

		
		/** 生成数据--墙 */
		public void GenerationWalls()
		{
			foreach(KeyValuePair<int, StagePositionConfig> kvp in stageConfig.wallDict)
			{
				StagePositionConfig buildConfig = kvp.Value;
				
				UnitData unitData = new UnitData();
				unitData.id = buildConfig.index;
				unitData.legionId = buildConfig.legionId;
				unitData.unitType = UnitType.Wall;
				unitData.level = buildConfig.level;
				unitData.position = buildConfig.position;
				unitData.positionConfig = buildConfig;
				unitData.wallConfig = War.model.GetBuildWallConfigg(buildConfig.buildUid);
				unitData.avatarId = unitData.wallConfig.avatarId;
				
				unitData.we_BuildConfigData = new WE_BuildConfigData();
				unitData.we_BuildConfigData.buildConfig = unitData.wallConfig;

//				Debug.Log("buildConfig.buildUid=" + buildConfig.buildUid+ " unitData.wallConfig=" + unitData.wallConfig);
				wallDict.Add(buildConfig.index, unitData);
			}
		}


	}
}