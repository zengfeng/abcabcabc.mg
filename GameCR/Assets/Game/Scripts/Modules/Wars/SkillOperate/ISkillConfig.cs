using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Games.Module.Wars
{
	public interface ISkillConfig 
	{
		
		int 		skillId			{get;set;}
		int 		skillLevel		{get;set;}



		/** 名称 */
		string 					name			{get;set;}
		/** 描述 */
		string 					description		{get;set;}

		
		/** 图标 */
		string 	icon				{get;set;}

		/** 操作方式 */
		SkillOperateType 		operate			{get;set;}

		/** 目标--单位类型 */
		int 					unitType		{get;set;}
		/** 目标--建筑类型 */
		BuildType 				targetBuildType		{get;set;}
		/** 目标--目标--敌我关系 */
		int 					relation		{get;set;}

		/** 攻击--圆半径/直线宽度 */
		float 					radius		{get;set;}
		/** 攻击--直线长度 */
		float 					distance	{get;set;}

		
		/** ai--使用技能优先级 */
		int 					aiPriority	{get;set;}
		/** 使用次数 */
		int 					useCount	{get;set;}
		/** CD */
		float 					cd			{get;set;}

		/** 技能类型 */
		SkillType 				skillType			{get;set;}
		/** 添加建筑等级上限 */
		int 					addBuildMaxLevel	{get;set;}
		/** 建筑类型 */
		BuildType 				buildType			{get;set;}
		/** 替换建筑ID */
		int 					buildId				{get;set;}
		/** 附加建筑功能ID */
		int 					buildModuleId		{get;set;}
		/** 是否入驻建筑 */
		bool 					isSettledBuild		{get;set;}
		/** 是否用建筑处理器 */
		bool 				isUseBuildProcessor		{get;set;}
		/** 附加建筑功能配置 */
		AbstractBuildConfig		buildModuleConfig   {get;set;}

		/** 消耗兵力 */
		float					costHP   		{get;set;}
		/** 消耗兵力百分比 */
		float					costHPPer   	{get;set;}

		/** 初始化 */
		void Init();
		void Init(int skillId, int skillLevel);

		
		/** 判断该技能是否能应用到某个单位 */
		bool EnableUse(UnitCtl unit, RelationType unitRelation);
		
		/** 获取资源列表 */
		List<string> GetRes(List<string> list);

	}
}
