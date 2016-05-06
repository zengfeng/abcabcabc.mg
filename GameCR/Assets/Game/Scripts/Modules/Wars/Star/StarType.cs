using UnityEngine;
using System.Collections;

namespace Games.Module.Wars
{
	/** 星星类型 */
	public enum StarType 
	{
		/** 全程手动 */
		[HelpAttribute("全程手动")]
		T1_FullManual 	= 1,


		/** 初始自己城池不占领 */
		[HelpAttribute("初始自己城池不占领")]
		T2_InitOwnCasernNoOccupy = 2,


		/** 初始有武将的城池不被占领 */
		[HelpAttribute("初始有武将的城池不被占领")]
		T3_InitOwnCasernNoOccupy_HasHero = 3,
		

		/** 整场战斗只死{0}个兵 */
		[HelpAttribute("整场战斗只死x个兵")]
		T4_OnlyDeathSoliderXNum = 4,


		/** 同时拥有{0}个{1}级城池 */
		[HelpAttribute("同时拥有x个y级城池")]
		T5_AlsoOwnsCasern = 5,


		/** 开战{0}秒内攻下{1}次城池 */
		[HelpAttribute("开战x秒内攻下y次城池")]
		T6_LimitTimeOccupyXCansern = 6,


		/** 开战{0}秒内攻下{1}次有武将城池 */
		[HelpAttribute("开战x秒内攻下y次有武将城池")]
		T7_LimitTimeOccupyXCansern_HasHero = 7,


		/** {0}秒内过关 */
		[HelpAttribute("x秒内过关")]
		T8_LimitTimePass = 8,


		/** 占领城池数量百分比{0} */
		[HelpAttribute("占领城池数量百分比x")]
		T9_CasernOccupyPercent = 9,
		
		
		/** 战斗结束至少占领{0}个城池 */
		[HelpAttribute("星星--游戏结束--至少占领x个城池")]
		T10_CasernOccupyLatest = 10,

		/** 星星--游戏结束 占领城池数量百分比{0} */
		[HelpAttribute("星星--游戏结束 占领城池数量百分比x")]
		T11_CasernOccupyPercent_GameOver = 11,

		[HelpAttribute("星星--游戏结束--不包含中立--占领所有城池")]
		T12_GameOver_NoNeutral_OccupyBuild__All = 12,

		[HelpAttribute("星星--游戏结束--不包含中立--我方城池大于敌方城池数量")]
		T13_GameOver_NoNeutral_OccupyBuild__OwnFriend_Greater_Enemy = 13,
	}
}