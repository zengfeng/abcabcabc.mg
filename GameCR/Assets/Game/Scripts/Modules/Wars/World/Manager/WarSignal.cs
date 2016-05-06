using UnityEngine;
using System.Collections;
using System;
using CC.Runtime.signals;
using CC.Runtime.PB;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class WarSignal
	{
		#region On Signals
		/** On 被攻打 */
		public Action<int, int> 	sOnBehit;

		/** On 被攻打 */
		public void OnBehit(int buildUid, int hitLegionId)
		{
			if (sOnBehit != null) 
			{
				sOnBehit (buildUid, hitLegionId);
			}
		}

		#endregion


		#region DO Signals
		/** Do 发兵 */
		public Action<int, int, int, int> 	sDoSendArm;
		/** Do 升级 */
		public Action<int, int, float> 		sDoUplevel;
		/** Do 占领城池 */
		public Action<int, int> 			sDoBuildLegionChange;
		/** Do 英雄下阵 */
		public Action<int, int> 			sDoHeroBackstage;
		/** Do 箭塔攻击 */
		public Action<int, int> 			sDoTurretAtk;
		/** Do 设置生产技能 */
		public Action<int, int, float> 		sDoSetProductionSkill;
		/** Do 技能 */
		public Action<C_SyncSkill_0x822> 	sDoSkill;
		/** Do 技能 */
		public Action<List<ProtoFightUnitInfo>> 	sDoProp;
		/** Do 游戏结束 */
		public Action 								sDoGameOver;

		/** Do 发兵 */
		public void DoSendArm(int fromUid, int toUid, int count, int beginUid)
		{
			if (sDoSendArm != null) 
			{
				sDoSendArm (fromUid, toUid, count, beginUid);
			}
		}

		/** Do 升级 */
		public void DoUplevel(int uid, int level, float time)
		{
			if (sDoUplevel != null) 
			{
				sDoUplevel (uid, level, time);
			}
		}

		/** Do 占领城池 */
		public void DoBuildLegionChange(int uid, int legionId)
		{
			if (sDoBuildLegionChange != null) 
			{
				sDoBuildLegionChange (uid, legionId);
			}
		}

		/** Do 英雄下阵 */
		public void DoHeroBackstage(int uid, int legionId)
		{
			if (sDoHeroBackstage != null) 
			{
				sDoHeroBackstage (uid, legionId);
			}
		}

		/** Do 箭塔攻击 */
		public void DoTurretAtk(int buildUid, int soliderUid)
		{
			if (sDoTurretAtk != null) 
			{
				sDoTurretAtk (buildUid, soliderUid);
			}
		}

		/** Do 设置生产技能 */
		public void DoSetProductionSkill(int legionId, int skillUid, float speed)
		{
			if (sDoSetProductionSkill != null) 
			{
				sDoSetProductionSkill (legionId, skillUid, speed);
			}
		}


		/** Do 技能 */
		public void DoSkill(C_SyncSkill_0x822 msg)
		{
			if (sDoSkill != null) 
			{
				sDoSkill (msg);
			}
		}

		/** Do Prop */
		public void DoProp(List<ProtoFightUnitInfo> unitPropList)
		{
			if (sDoProp != null) 
			{
				sDoProp (unitPropList);
			}
		}

		/** Do 游戏结束 */
		public void DoGameOver()
		{
			if (sDoGameOver != null) 
			{
				sDoGameOver ();
			}
		}
		#endregion




		/** 数据生成完成 */
		public Action sGenerateDataComplete;
		public void GenerateDataComplete()
		{
			if (sGenerateDataComplete != null)
			{
				sGenerateDataComplete ();
			}
		}

		/** 预加载完成 */
		public Action sPreloadComplete;
		public void PreloadComplete()
		{
			if (sPreloadComplete != null)
			{
				sPreloadComplete ();
			}
		}

		/** 场景建造完成 */
		public Action sBuildComplete;
		public void BuildComplete()
		{
			if (sBuildComplete != null)
			{
				sBuildComplete ();
			}
		}

		/** 游戏开始 */
		public Action sGameBegin;
		public void GameBegin()
		{
			if (sGameBegin != null)
			{
				sGameBegin ();
			}
		}

		/** 建筑换阵营完成 */
		public Action sBuildChangeLegionComplete;
		public void BuildChangeLegionComplete()
		{
			if (sBuildChangeLegionComplete != null)
			{
				sBuildChangeLegionComplete ();
			}
		}




		/** 兵力消耗 args(beLegionId, casteLegionId, hpCost) */
		public Action<int, int, float> sHPConst;
		public void HPConst(int beLegionId, int castLegionId, float hpCost)
		{
			if (sHPConst != null)
			{
				sHPConst (beLegionId, castLegionId, hpCost);
			}
		}

		/** 添加兵力 args(beLegionId, casteLegionId, hpCost) */
		public Action<int, int, float> sHPAdd;
		public void HPAdd(int beLegionId, int castLegionId, float hpCost)
		{
			if (sHPAdd != null)
			{
				sHPAdd (beLegionId, castLegionId, hpCost);
			}
		}


		/** 重新生成寻路数据 */
		public Action					sPathGridRasterize;
		public void PathGridRasterize()
		{
			if (sPathGridRasterize != null)
			{
				sPathGridRasterize ();
			}
		}


		/** 手动按下建筑 arg=(buildId) */
		public Action<int>				sHandDownBuild;
		public void HandDownBuild(int buildId)
		{
			if (sHandDownBuild != null)
			{
				sHandDownBuild (buildId);
			}
		}

		/** 手动松开建筑 arg=(buildId) */
		public Action<int>				sHandUpBuild;
		public void HandUpBuild(int buildId)
		{
			if (sHandUpBuild != null)
			{
				sHandUpBuild (buildId);
			}
		}

		/** 手动发兵 arg(from, to)*/
		public Action<int, int>			sHandSendArm;
		public void HandSendArm(int fromBuildId, int toBuildId)
		{
			if (sHandSendArm != null)
			{
				sHandSendArm (fromBuildId, toBuildId);
			}
		}

		/** 手动升级 arg(buildId)*/
		public Action<int> sHandUplevel;
		public void HandUplevel(int buildId)
		{
			if (sHandUplevel != null)
			{
				sHandUplevel (buildId);
			}
		}





		/** 暂停 */
		public Action					sPause;
		public void Pause()
		{
			if (sPause != null)
			{
				sPause ();
			}
		}


		/** 继续播放 */
		public Action					sResume;
		public void Resume()
		{
			if (sResume != null)
			{
				sResume ();
			}
		}



		/** 技能生产了 */
		public Action<SkillOperateData>	sSkillProduceOwn;
		public void SkillProduceOwn(SkillOperateData operateData)
		{
			if (sSkillProduceOwn != null) 
			{
				sSkillProduceOwn (operateData);
			}
		}

		/** 技能使用了 */
		public Action<SkillOperateData>	sSkillUse;
		public void SkillUse(SkillOperateData operateData)
		{
			if (sSkillUse != null) 
			{
				sSkillUse (operateData);
			}
		}



		/** 英雄入驻建筑 args=[legionId, skillId, buildId] */
		public Action<int, int, int>	sHeroSettledBuild;
		public void HeroSettledBuild(int legionId, int skillUid, int buildId)
		{
			if(sHeroSettledBuild != null)
			{
				sHeroSettledBuild(legionId, skillUid, buildId);
			}
		}

		public void Destory()
		{

			sBuildChangeLegionComplete 	= null;

			sHPConst 	= null;
			sHPAdd 		= null;


			sPathGridRasterize 		= null;

			sHandDownBuild 		= null;
			sHandUpBuild 		= null;
			sHandSendArm 		= null;
			sHandUplevel 		= null;

			sPause = null;
			sResume = null;


			sSkillProduceOwn = null;
			sSkillUse = null;
			sHeroSettledBuild = null;
		}
	}
}
