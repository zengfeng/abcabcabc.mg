using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Games.Module.Wars
{
	public class TSkillConfig : ISkillConfig 
	{


		public int 		skillId			{get;set;}
		public int 		skillLevel		{get;set;}



		/** 名称 */
		public string 					name			{get;set;}
		/** 描述 */
		public string 					description		{get;set;}
		
				
		/** 图标 */
		public	string 	icon				{get;set;}
	
		/** 操作方式 */
		public	SkillOperateType 		operate			{get;set;}
	
		/** 目标--单位类型 */
		public	int 					unitType		{get;set;}
		/** 目标--建筑类型 */
		public	BuildType 				targetBuildType		{get;set;}
			/** 目标--目标--敌我关系 */
		public	int 					relation		{get;set;}
	
			/** 攻击--圆半径/直线宽度 */
		public	float 					radius		{get;set;}
			/** 攻击--直线长度 */
		public	float 					distance	{get;set;}
		
		/** ai--使用技能优先级 */
		public int 					aiPriority	{get;set;}
		/** 使用次数 */
		public int 					useCount	{get;set;}
		/** CD */
		public float 				cd			{get;set;}
		
		
		/** 技能类型 */
		public SkillType 			skillType			{get;set;}
		/** 添加建筑等级上限 */
		public int 					addBuildMaxLevel	{get;set;}
		/** 替换建筑ID */
		public int 					buildId				{get;set;}
		/** 附加建筑功能ID */
		public int 					buildModuleId		{get;set;}
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
				return skillType == SkillType.Build_Attach || skillType == SkillType.Build_Replace;
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

		}
		
		
		/** 判断该技能是否能应用到某个单位 */
		public bool EnableUse(UnitCtl unit, RelationType unitRelation)
		{
			if(isSettledBuild && unit.heroData != null)
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
			if(list == null)
			{
				list = new List<string>();
			}

			if(skillType == SkillType.Build_Replace)
			{
				if(buildId > 0)
				{
					Debug.Log(buildId);
					War.model.GetBuildConfig(buildId).GetResList(list, War.sceneData.colorIds);
				}
			}

			return list;
		}

	}
}
