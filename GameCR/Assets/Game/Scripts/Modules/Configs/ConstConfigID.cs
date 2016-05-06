using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using CC.Runtime;

namespace Games
{
	
	public partial class ConstConfig
	{
		
		public enum ID
		{
			/** 战斗--城池出兵每波最大数量 */
			War_Arm_OnceCount = 1,
			/** 战斗--城池出兵时间间隔 */
			War_Arm_OnceTime,

			/** 战斗--城池最大等级 */
			War_CanseraMaxLevel,
			/** 战斗--地图MinX */
			War_StageSizeMinX,
			/** 战斗--地图MaxZ */
			War_StageSizeMaxX,
			/** 战斗--地图MinZ */
			War_StageSizeMinZ ,
			/** 战斗--地图MaxZ */
			War_StageSizeMaxZ ,
			/** 战斗--AI出兵初始时间 */
			War_AI_FirstSendArmTime,
			/** 战斗--AI出兵时间间隔 */
			War_AI_SendArmTime,
			/** 战斗--AI升级时间间隔 */
			War_AI_UplevelTime,
			/** 战斗--AI出兵最小数量 */
			War_AI_SendArmMinNum,
			/** 战斗--操作--电脑上用电脑的操作 */
			War_PCOperater,

			/** 战斗--怒气--CD */
			War_MageAdd_CD,
			/** 战斗--怒气--敌人士兵入侵 */
			War_MageAdd_Behit,
			/** 战斗--怒气--士兵攻打敌方城池系数 */
			War_MageAdd_Atk,
			/** 战斗--怒气--城池被占领 */
			War_MageAdd_Beoccupy,
			/** 战斗--游戏最大时间 */
			War_Time_Max,




			//-------------------------------------

			/** 战斗--数值--战前--玩家势力--斩杀率--参数 */
			War_DV_Team_KillHero_Ratio = 151,

			/** 战斗--数值--战前--玩家势力--怒气上限--默认值 */
			War_DV_Team_MaxMage_Default,
			/** 战斗--数值--战前--玩家势力--怒气上限--参数 */
			War_DV_Team_MaxMage_Ratio,

			/** 战斗--数值--战前--玩家势力--怒气上限--默认值 */
			War_DV_Team_Mage_Default,
			/** 战斗--数值--战前--玩家势力--怒气上限--参数 */
			War_DV_Team_Mage_Ratio,

			
			//-------------

			/** 战斗--数值---战前--玩家城池--产兵速度--默认最小值 */
			War_DV_Casern_ProduceSpeed_DefaultMin,
			/** 战斗--数值---战前--玩家城池--产兵速度--参数 */
			War_DV_Casern_ProduceSpeed_Ratio,

			

			/** 战斗--数值---战前--玩家城池--防御-参数 */
			War_DV_Casern_Def_Ratio,
			
			/** 战斗--数值---战前--玩家城池--初始兵力--参数A=武将城池额外附加最大兵力比例 */
			War_DV_Casern_Hp_RatioA,
			/** 战斗--数值---战前--玩家城池--初始兵力--参数B=有武将城池初始兵力比例 */
			War_DV_Casern_Hp_RatioB,
			/** 战斗--数值---战前--玩家城池--初始兵力--参数C=无武将城池初始兵力比例 */
			War_DV_Casern_Hp_RatioC,
			/** 战斗--数值---战前--玩家城池--初始兵力--参数D */
			War_DV_Casern_Hp_RatioD,


			/** 战斗--数值---战前--玩家城池--兵力上限--默认最小值 */
			War_DV_Casern_MaxHp_DefaultMin,
			/** 战斗--数值---战前--玩家城池--兵力上限--参数A */
			War_DV_Casern_MaxHp_Ratio,

			
			/** 战斗--数值---战前--玩家城池--速攻--默认最小值 */
			War_DV_Casern_SpeedAtk_DefaultMin,
			/** 战斗--数值---战前--玩家城池--速攻--参数A */
			War_DV_Casern_SpeedAtk_Ratio,

			//-----------------

			
			/** 战斗--数值---战前--玩家英雄--防斩杀值--参数 */
			War_DV_Hero_Player_DefKillHero_Ratio,
			
			//-----------------
			
			
			/** 战斗--数值---战前--玩家士兵--攻击--参数 */
			War_DV_Solider_Atk_Ratio,
			/** 战斗--数值---战前--玩家士兵--初始移动速度--默认最值 */
			War_DV_Solider_InitMoveSpeed_Default,
			/** 战斗--数值---战前--玩家士兵--初始移动速度--参数 */
			War_DV_Solider_InitMoveSpeed_Ratio,

			
			//-------------------------------------
			
			/** 战斗--数值---战中--防守损兵比--参数A */
			War_DV_DefCostRate_RatioA = 201,
			/** 战斗--数值---战中--防守损兵比--参数B */
			War_DV_DefCostRate_RatioB,
			/** 战斗--数值---战中--防守损兵比--参数C = 最小值 */
			War_DV_DefCostRate_RatioC,
			/** 战斗--数值---战中--防守损兵比--参数D = 最大值 */
			War_DV_DefCostRate_RatioD,

			
			/** 战斗--数值---战中--斩杀率--参数 */
			War_DV_KillHeroRate_Ratio,

			
			/** 战斗--数值---战中--怒气增长 */
			War_DV_Mag_Recovery_Ratio,
			
			//-------------------------------------
			/**	战斗--数值---战中--战力转攻击比例 */
			War_DV_BattleForce2Atk_Ratio = 220,
			/**	战斗--数值---战中--战力转防御比例 */
			War_DV_BattleForce2Defence_Ratio,
			/**	战斗--数值---战中--攻速转移动速度比例 */
			War_DV_SpeedAtk2MoveSpeed_Ratio,

			
			//-------------------------------------
			/** 建筑升第3级--最低需要士兵数量 */
			War_BuildUplevel_RequireMinHp = 450,
			/** 建筑升第3级--最高低需要士兵数量 */
			War_BuildUplevel_RequireMaxHp,
			/** 建筑升第3级--最高消耗时间 */
			War_BuildUplevel_RequireMaxTime,
			/** 建筑升第3级--士兵转时间比例 */
			War_BuildUplevel_Hp2Time,
			
			/** 技能改变建筑时间 */
			War_SkillChangeBuildTime = 460,

			/** 计算关卡势力总兵力--乘数--兵营 */
			War_StageLegionTotalMaxHP_Ratio_Casern = 465,
			/** 计算关卡势力总兵力--乘数--箭塔 */
			War_StageLegionTotalMaxHP_Ratio_Turret,
			/** 计算关卡势力总兵力--乘数--据点 */
			War_StageLegionTotalMaxHP_Ratio_Spot,
		}
    }
}

