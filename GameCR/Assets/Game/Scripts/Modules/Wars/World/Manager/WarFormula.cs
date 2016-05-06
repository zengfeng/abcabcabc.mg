using UnityEngine;
using System.Collections;
using Games;
using System;

namespace Games.Module.Wars
{
	public class WarFormula  
	{
		
		#region 战前属性算法--势力
		/** 战前势力--斩将率
		 * 斩杀率=士兵模块--斩杀等级*参数;//参数默认为0.01
		 */
		public static float WF_Legion_KillHero(float solider_KillHero)
		{
			return solider_KillHero * ConstConfig.GetFloat(ConstConfig.ID.War_DV_Team_KillHero_Ratio);
		}



		/** 战前势力--怒气上限
		 * 	最大怒气=（默认最小值）*参数;//参数默认为0.01
		 */
		public static float WF_Legion_MaxMage()
		{
			return ConstConfig.GetFloat(ConstConfig.ID.War_DV_Team_MaxMage_Default) * ConstConfig.GetFloat(ConstConfig.ID.War_DV_Team_MaxMage_Ratio);
		}

		/** 战前势力--怒气
		 * 	初始怒气=（默认最小值）*参数//参数默认为0.01
		 */
		public static float WF_Legion_Mage()
		{
			return ConstConfig.GetFloat(ConstConfig.ID.War_DV_Team_Mage_Default) * ConstConfig.GetFloat(ConstConfig.ID.War_DV_Team_Mage_Ratio);
		}



		#endregion

		#region 战前属性算法--城池
		//=========================================================
		// 战前属性算法--玩家城池
		//---------------------------------------------------------

		/** 战前兵营--产兵速度--玩家：
		 * 	产兵速度=（默认最小值+武将模块--参战武将总产兵速度）*参数;//默认参数为1
		 */
		public static float WF_Casern_ProduceSpeed(float legionInitProduce,float totalHero_ProduceSpeed)
		{
//			return (ConstConfig.GetFloat(ConstConfig.ID.War_DV_Casern_ProduceSpeed_DefaultMin) +  totalHero_ProduceSpeed) * ConstConfig.GetFloat(ConstConfig.ID.War_DV_Casern_ProduceSpeed_Ratio);
//			return legionInitProduce +  totalHero_ProduceSpeed;
			return legionInitProduce;
		}


		
		/** 战前兵营--防御--玩家
		 *  防御=（主公模块--战力+武将模块--上阵武将总战力）*战力转换防御参数
		 */
		public static float WF_Casern_Def(float legionInitBattleForce, float totalHero_Def)
		{
//			return totalHero_Def + legionInitBattleForce * ConstConfig.GetFloat(ConstConfig.ID.War_DV_BattleForce2Defence_Ratio);
			return legionInitBattleForce * ConstConfig.GetFloat(ConstConfig.ID.War_DV_BattleForce2Defence_Ratio);
		}
		
		public static float WF_Casern_BattleForce(float legionInitBattleForce)
		{
			return legionInitBattleForce;
		}
		
		/** 战前兵营--兵力上限--玩家：
		 *  兵力上限=（城池模块--默认兵力上限+武将模块--兵力上限之和）*参数A；
		 */
		public static float WF_Casern_MaxHP(float totalHero_MaxHP)
		{
			return (ConstConfig.GetFloat(ConstConfig.ID.War_DV_Casern_MaxHp_DefaultMin) +  totalHero_MaxHP) * ConstConfig.GetFloat(ConstConfig.ID.War_DV_Casern_MaxHp_Ratio);
		}
		
		
		/** 战前兵营--速攻：
		 *  速攻值=（默认最小值+武将模块--参战武将总速攻值）*参数;//默认参数为1；
		 */
		public static float WF_Casern_SpeedAtk(float legionInitSpeedAtk, float totalHero_InitSpeedAtk)
		{
			return (legionInitSpeedAtk +  legionInitSpeedAtk) * ConstConfig.GetFloat(ConstConfig.ID.War_DV_Casern_SpeedAtk_Ratio);
		}

//		public static float WF_Casern_SpeedAtk(float totalHero_InitSpeedAtk)
//		{
//			return (ConstConfig.GetFloat(ConstConfig.ID.War_DV_Casern_SpeedAtk_DefaultMin) +  totalHero_InitSpeedAtk) * ConstConfig.GetFloat(ConstConfig.ID.War_DV_Casern_SpeedAtk_Ratio);
//		}



		public static float WF_Casern_Hp(float configHp, float legionInitHP)
		{
			if(configHp != -1)
			{
				return configHp;
			}
			
			return legionInitHP;
		}
		
		/** 战前兵营--初始兵力：
		 * 有武将驻守
		 * 初始兵力=（战前--玩家城池--速攻值+战前--玩家武将--速攻值*参数A）*参数B;
		 * //参数A=武将城池额外附加最大兵力比例
		 * //参数B=有武将城池初始兵力比例
		 * 
		 * 
		 * 无武将驻守
		 * 初始兵力=战前--玩家城池--速攻值*参数C;
		 * //参数C=无武将城池初始兵力比例
		 */
		public static float WF_Casern_Hp2(float configHp, float casern_InitSpeedAtk, bool hasHero, float hero_InitSpeedAtk)
		{
			if(configHp != -1)
			{
				return configHp;
			}

			if(hasHero)
			{
				return (casern_InitSpeedAtk + hero_InitSpeedAtk * ConstConfig.GetFloat(ConstConfig.ID.War_DV_Casern_Hp_RatioA)) * ConstConfig.GetFloat(ConstConfig.ID.War_DV_Casern_Hp_RatioB) + ConstConfig.GetFloat(ConstConfig.ID.War_DV_Casern_Hp_RatioD);
			}
			else
			{
				return casern_InitSpeedAtk * ConstConfig.GetFloat(ConstConfig.ID.War_DV_Casern_Hp_RatioC) + ConstConfig.GetFloat(ConstConfig.ID.War_DV_Casern_Hp_RatioD);
			}
		}
		
		/** 兵营升级所需兵力 */
		public static float WF_UplevelCostHp(float maxHp, float levelRate)
		{
			return maxHp * levelRate;
		}

		#endregion




		#region 战前属性算法--英雄

		/** 战前英雄--防斩杀值--玩家：
		 * 防斩杀值=武将模块--防斩杀值*参数;//参数默认为1
		 */
		public static float WF_Hero_DefKillHero_Player(float defKillHero)
		{
			return defKillHero * ConstConfig.GetFloat(ConstConfig.ID.War_DV_Hero_Player_DefKillHero_Ratio);
		}

		#endregion


		
		
		#region 战前属性算法--士兵

		public static float WF_Solider_BattleForce(float legionInitBattleForce)
		{
			return legionInitBattleForce;
		}

		/** 战前士兵--攻击：
		 * 攻击=（主公模块--战力+武将模块--上阵武将总战力）*战力转换攻击参数
		*/
		public static float WF_Solider_Atk(float legionInitBattleForce, float totalHero_atk)
		{
//			return totalHero_atk + legionInitBattleForce * ConstConfig.GetFloat(ConstConfig.ID.War_DV_BattleForce2Atk_Ratio);
			return legionInitBattleForce * ConstConfig.GetFloat(ConstConfig.ID.War_DV_BattleForce2Atk_Ratio);
		}
		
		/** 战前士兵--初始移动速度：
		 * 速度= 主公模块--速度+武将模块--上阵武将总速攻 *速攻转速度参数
		*/
		public static float WF_Solider_MoveSpeed(float legionInitMoveSpeed, float totalHero_moveSpeed)
		{
//			return  totalHero_moveSpeed + legionInitMoveSpeed;
			return  legionInitMoveSpeed;
		}

		#endregion


		
		#region 战斗中

		
		
		
		/** 斩杀率
		 * 斩杀概率=1-(3*B势力防斩杀值/(3*B势力防斩杀值+A势力斩杀值)) 
		 */
		public static float WD_KillHeroRate(float d_defKillHero, float a_killHero)
		{
			float a = ConstConfig.GetFloat(ConstConfig.ID.War_DV_KillHeroRate_Ratio);
			return 1 - (a * d_defKillHero / (a * d_defKillHero + a_killHero));
		}

		/** 判断斩杀率是否斩杀 */
		public static bool WD_IsKillHero(float d_defKillHero, float a_killHero)
		{
			if(War.requireSynch)
			{
				return false;
			}
			float rate = UnityEngine.Random.Range(0f, 1f);
			float killHeroRate = WD_KillHeroRate(d_defKillHero, a_killHero);
			Debug.Log("WD_IsKillHero rate=" + rate + "  killHeroRate=" + killHeroRate);
			return rate <= killHeroRate;
		}




		/** 防守损兵比
		 * 防守损兵比 = 参数A*(参数B*城池模块--战中防御/(参数B*城池模块--战中防御+士兵模块--战中攻击))；
		 * 参数C≤防守损兵比≤参数D;
		 * //参数A 默认为2.2
		 * //参数B 默认为1.2
		 * //参数C 默认为0.5
		 * //参数D 默认为4
		 * //假设防守损兵比为0.8，则意味着防守方每1个士兵可以抵消攻击方0.8个士兵
		 */
		public static float WD_DefCostRate(float d_def, float a_atk)
		{
			//高方损兵比=（高/低-A）*B+C
			float r = d_def > a_atk ? d_def / a_atk : a_atk / d_def;

			if (r < 0) 
			{
				if (Application.isEditor)
				{
					Debug.LogErrorFormat ("hpbug WD_DefCostRate r={0}, a_atk={1}, d_def={2}", r, a_atk, d_def);
				}
			}


			float a =  ConstConfig.GetFloat(ConstConfig.ID.War_DV_DefCostRate_RatioA);
			float b =  ConstConfig.GetFloat(ConstConfig.ID.War_DV_DefCostRate_RatioB);
			float c =  ConstConfig.GetFloat(ConstConfig.ID.War_DV_DefCostRate_RatioC);
			float d =  ConstConfig.GetFloat(ConstConfig.ID.War_DV_DefCostRate_RatioD);

			float val = (r - a) * b + c;
			if(a_atk >= d_def ) val = 1 / val;

//			float val = a * (b * d_def / (b * d_def + a_atk));

//			if(val < c) val = c;
//			else if(val > d)  val = d;
			return val;
		}


		/** 计算士兵攻击兵营的伤害 */
		public static float WD_Solider2Casern_Damage(float d_def, float a_atk, float a_hp)
		{
			return WD_RelativelyHP_Atk2Def(d_def, a_atk, a_hp);
		}


		
		
		/** 获取相对兵力(防守方的兵力 -> 攻击方兵力) */
		public static float WD_RelativelyHP_Def2Atk(float d_def, float a_atk, float d_hp)
		{
			return WD_DefCostRate(d_def, a_atk) * d_hp;
		}

		
		/** 获取相对兵力(攻击方的兵力 -> 防守方的兵力) */
		public static float WD_RelativelyHP_Atk2Def(float d_def, float a_atk, float a_hp)
		{
			return 1 / WD_DefCostRate(d_def, a_atk) * a_hp;
		}

		
		/** 获取相对人口(防守方的人口 -> 攻击方的人口) */
		public static int WD_RelativelyUnitNum_Def2Atk(float d_def, float a_atk, float d_hp, float a_hp2UnitRate)
		{
			return Mathf.CeilToInt(WD_RelativelyHP_Def2Atk(d_def, a_atk, d_hp) / a_hp2UnitRate);
		}
		
		/** 获取相对人口(攻击方的人口 -> 防守方的人口) */
		public static int WD_RelativelyUnitNum_Atk2Def(float d_def, float a_atk, float a_hp, float d_hp2UnitRate)
		{
			return Mathf.CeilToInt(WD_RelativelyHP_Atk2Def(d_def, a_atk, a_hp) / d_hp2UnitRate);
		}

		#endregion
	}
}