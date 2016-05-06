using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games.Module.Avatars;
using Games.Cores;
namespace Games.Module.Wars
{
	public class HSkillConfig : ISkillConfig 
	{
		
		public List<SkillWarConf> 	skillWarConfigList = new List<SkillWarConf>();
		public SkillWarConf 		skillWarConfig;

		
		public int 		skillId			{get;set;}
		public int 		skillLevel		{get;set;}



		/** 名称 */
		public string name			
		{
			get
			{
				return skillWarConfig.skillName;
			}

			set
			{
			}
		}

		/** 描述 */
		public string description		
		{
			get
			{
				return skillWarConfig.skillDescribe;
			}

			set
			{
			}
		}


        /** 图标 */
        public AvatarConfig GetAvatarConf(int avatarId)
        {
            AvatarConfig avatarConfig = null;
            avatarConfig = Goo.avatar.GetConfig(avatarId);

            if (avatarConfig == null)
			{
				Debug.LogErrorFormat("skillId={0}, avatarConfig={1}, avatarId={2} ", skillId, avatarConfig, avatarId);
                avatarConfig = Goo.avatar.GetConfig(20001);
            }

            return avatarConfig;

        }

        public string icon				
		{
			get
            {
				AvatarConfig aratarConf = GetAvatarConf(skillWarConfig.skillAvatar);
                if (aratarConf == null)
                {
					Debug.LogErrorFormat("skillId={0}, avatarConfig={1}, avatarId={2} ", skillId, aratarConf, skillWarConfig.skillAvatar);
                    return "Image/SkillIcon/skill_50003";
                }
                return aratarConf.icon;
            }
			set
			{
			}
		}
		
		/** 操作方式 */
		public SkillOperateType operate			
		{
			get
			{
				switch ((eSkillWarEffectOperation)skillWarConfig.mainEffectData.operation)
				{
				case eSkillWarEffectOperation.eEffectAuto:
					return SkillOperateType.Immediately;
					break;
				case eSkillWarEffectOperation.eEffectManualTarget:
					return SkillOperateType.SelectUnit;
					break;
				case eSkillWarEffectOperation.eEffectmanualRange:
					return SkillOperateType.SelectCircle;
					break;
				default:
					return SkillOperateType.Immediately;
					break;
				}
			}

			set
			{
			}
		}

		
		/** 目标--单位类型 */
		public int unitType		
		{
			get
			{
				eSkillWarTargetType t = (eSkillWarTargetType)skillWarConfig.mainEffectData.target;
				//Debug.Log ("t=" + t);
				switch(t)
				{
				case eSkillWarTargetType.eEffectTargetBuild:
				case eSkillWarTargetType.eEffectTargetEmptyBuild:
				case eSkillWarTargetType.eEffectTargetHeroBuild:
				case eSkillWarTargetType.eEffectTargetBuildMinSolder:
				case eSkillWarTargetType.eEffectTargetBuildMaxSolder:
				case eSkillWarTargetType.eEffectTargetBuildFullMax:
				case eSkillWarTargetType.eEffectTargetSoilder:
				case eSkillWarTargetType.eEffectTargetBuildBeHitMinHp:
				case eSkillWarTargetType.eEffectTargetSoliderMaxNotAtk:
				case eSkillWarTargetType.eEffectTargetSoliderMaxLevel:
					
					return 0.UBuild (true);
					break;

				case eSkillWarTargetType.eEffectTargetSoilderOnWay:

				case eSkillWarTargetType.eEffectTargetSoliderMax:
					return 0.USolider (true);
					break;
				case eSkillWarTargetType.eEffectTargetHero:
					return 0.UHero (true);
					break;
				case eSkillWarTargetType.eEffectTargetSoliderAndBuild:
				case eSkillWarTargetType.eEffectTargetSoliderAndBuildRangeAll:
					return 0.USolider (true).UBuild(true);
					break;
				}



				if (operate == SkillOperateType.SelectCircle) 
				{
					return 0.USolider (true);
				} 
				else if(operate == SkillOperateType.SelectUnit)
				{
					return 0.UBuild (true);
				}



				return skillWarConfig.mainEffectData.target;
			}

			set
			{
			}
		}


		/** 目标--建筑类型 */
		public BuildType targetBuildType		
		{
			get
			{
				return (BuildType) skillWarConfig.buildType;
			}
			
			set
			{
			}
		}

		/** 目标--目标--敌我关系 */
		public int relation		
		{
			get
			{
				int relation = 0;
				//Debug.Log ("skillWarConfig.mainEffectData.camp=" + skillWarConfig.mainEffectData.camp);
				if (skillWarConfig.mainEffectData.camp == (int)eSkillWarEffectCamp.eEffectCampEnemy)
				{
					relation = relation.REnemy(true);
				}
				else if (skillWarConfig.mainEffectData.camp == (int)eSkillWarEffectCamp.eEffectCampfriend)
				{
					relation = relation.ROwn(true);
					relation = relation.RFriendly(true);
				}
				else if (skillWarConfig.mainEffectData.camp == (int)eSkillWarEffectCamp.eEffectCampSelf)
				{
					relation = relation.ROwn(true);
				}
				else
				{
					relation = relation.RAll(true);
				}
				
				return relation;
			}
			
			set
			{
			}
		}
		
		/** 攻击--圆半径/直线宽度 */
		public float radius		
		{
			get
			{
				return skillWarConfig.mainEffectData.range;
			}

			set
			{
			}
		}
		/** 攻击--直线长度 */
		public float distance		
		{
			get
			{
				return 5;
			}
			
			set
			{
			}
		}

		
		/** ai--使用技能优先级 */
		public int aiPriority	
		{
			get
			{
				return skillWarConfig.aiPriority;
			}
			
			set
			{
			}
		}

		
		/** 使用次数 */
		public int 					useCount		
		{
			get
			{
				return skillWarConfig.useCount;
			}
			
			set
			{
			}
		}

		/** CD */
		public float 				cd				
		{
			get
			{
				return skillWarConfig.skillCd;
			}
			
			set
			{
			}
		}

		
		/** 技能类型 */
		public SkillType 			skillType {get;set;}

		void SetSkillType()
		{
			switch((eSKillWarEffectType)skillWarConfig.getBuildSkillType())
			{
			case eSKillWarEffectType.eEffectLevelUp:
				skillType = SkillType.Build_Uplevel;
				break;
			case eSKillWarEffectType.eEffectReplace:
				skillType = SkillType.Build_Replace;
				break;
			case eSKillWarEffectType.eEffectAttach:
				skillType = SkillType.Build_Attach;
				break;
			default:
				skillType = SkillType.Normal;
				break;
				
			}
		}

       

		/** 添加建筑等级上限 */
		public int 					addBuildMaxLevel	
		{
			get
			{
				return skillWarConfig.getBuildLvlUpValue();
			}

			set
			{

			}
		}

		/** 替换建筑ID */
		public int 					buildId				
		{
			get
			{
				if(skillType == SkillType.Normal)
				{
					return 0;
				}

				return (int)skillWarConfig.mainEffectData.data;
			}

			set
			{
			}
		}

		/** 附加建筑功能ID */
		public int 					buildModuleId					
		{
			get
			{
				if(skillType == SkillType.Normal)
				{
					return 0;
				}
				
				return (int)skillWarConfig.mainEffectData.data;
			}
			
			set
			{
			}
		}

		
		/** 建筑类型 */
		public BuildType 			buildType					
		{
			get
			{
				switch(skillType)
				{
				case SkillType.Build_Replace:
					return War.model.GetBuildConfig(buildId).buildType;
					break;
				case SkillType.Build_Attach:
					return War.model.GetBuildModuleType(buildModuleId);
					break;
				}
				
				return BuildType.None;
			}
			
			set
			{
				
			}
		}
		
		
		/** 附加建筑功能配置 */
		public AbstractBuildConfig	buildModuleConfig   				
		{
			get
			{
				return War.model.GetBuildModuleConfig(buildModuleId);
			}
			
			set
			{
				
			}
		}

		/** 是否入驻建筑 */
		public	bool 				isSettledBuild		
		{
			get
			{
				return skillWarConfig.isSettledBuild || skillId == War.config.roleSkillId;
			}
			
			set
			{
				
			}
		}

		
		
		/** 是否用建筑处理器 */
		public	bool 				isUseBuildProcessor	
		{
			get
			{
				return skillType != SkillType.Normal;
			}
			
			set
			{
				
			}
		}
		
		
		
		/** 消耗兵力 */
		public float					costHP   		{get;set;}
		/** 消耗兵力百分比 */
		public float					costHPPer   	{get;set;}
		
		/** 初始化 */
		public void Init()
		{
			Init(skillId, skillLevel);
		}
		
		public void Init(int skillId, int skillLevel)
		{
			this.skillId 		= skillId;
			this.skillLevel 	= skillLevel;

			
			skillWarConfig = War.model.GetSkillWarConf(skillId);
			skillWarConfigList.Add(skillWarConfig);
			
			
			SetSkillType();

			costHP = skillWarConfig.getSkillCostHp();
			costHPPer = skillWarConfig.getSkillCostHPPer();
		}

		
		/** 判断该技能是否能应用到某个单位 */
		public bool EnableUse(UnitCtl unit, RelationType unitRelation)
		{
			if(isSettledBuild && unit.unitData.hasHero)
			{
				return false;
			}
			
			
			if(targetBuildType != BuildType.None && unit.unitData.buildType != targetBuildType)
			{
				return false;
			}
			
			if(costHP > 0 && unit.unitData.hp < costHP)
			{
				return false;
			}
			
			if(costHPPer > 0 && unit.unitData.hp < unit.unitData.GetBuildUplevelRequireHp(costHPPer))
			{
				return false;
			}
			
			bool isUplevel = false;
			switch(skillType)
			{
			case SkillType.Build_Uplevel:
				isUplevel = true;
				break;
//			case SkillType.Build_Replace:
//				if(buildId == unit.unitData.buildConfig.id)
//				{
//					isUplevel = true;
//				}
//				break;
			}
			
			if(isUplevel)
			{
				if(!unit.levelData.GetSkillEnableUpLevel(addBuildMaxLevel))
				{
					return false;
				}
			}
			
			if (skillWarConfig.mainEffectData.target == (int)eSkillWarTargetType.eEffectTargetBuild)
			{
				
			}
			else if (skillWarConfig.mainEffectData.target == (int)eSkillWarTargetType.eEffectTargetEmptyBuild)
			{
				if(unit.unitData.legionData.colorId == WarColor.Gray) return false;
			}
			else if (skillWarConfig.mainEffectData.target == (int)eSkillWarTargetType.eEffectTargetHeroBuild)
			{
				if(unit.heroData == null) return false;
			}





			switch(unitRelation)
			{
			case RelationType.Own:
				return relation.ROwn();
				break;
			case RelationType.Friendly:
				return relation.RFriendly();
				break;
			case RelationType.Enemy:
				if(unit.unitData.invincible) return false;
				return relation.REnemy();
				break;
			}
			
			return false;
		}

		/** 获取资源列表 */
		public List<string> GetRes(List<string> list)
		{
			if (list == null)
			{
				list = new List<string>();
			}


			string file;
			foreach (SkillWarConf skillWarConfig in skillWarConfigList)
			{
				foreach ( CSkillEffectDataItem effectDic in skillWarConfig.effectDataList)
				{
					if (skillWarConfig != null)
					{
						file = effectDic.animPathEnd;
						if (file != "temp" && !string.IsNullOrEmpty(file))
						{
							if (list.IndexOf(file) == -1)
							{
								list.Add(file);
							}
						}
						// Debug.Log(string.Format("res add====:{0}:{1}:{2}", effectDic.Value.animPathEnd,
						//                                                effectDic.Value.animPathStart, effectDic.Value.buffAnimPath));

						file = effectDic.animPathStart;
						if (file != "temp" && !string.IsNullOrEmpty(file))
						{
							if (list.IndexOf(file) == -1)
							{
								list.Add(file);
							}
						}


						file = effectDic.buffAnimPath;
						if (file != "temp" && !string.IsNullOrEmpty(file))
						{
							if (list.IndexOf(file) == -1)
							{
								list.Add(file);
							}
						}
					}

				}
			}

			if(skillType != SkillType.Normal)
			{
				if (buildId > 0)
				{
					//	Debug.Log("skillId=" + skillId + " buildId=" + buildId);
					BuildConfig buildConfig = War.model.GetBuildConfig(buildId);
					buildConfig.GetResList(list, War.sceneData.colorIds);
				}

				if(buildModuleConfig != null && buildModuleConfig.avatarConfig != null)
				{
					buildModuleConfig.avatarConfig.GetResList(list, War.sceneData.colorIds);
				}
			}



			return list;
		}



	}
}
