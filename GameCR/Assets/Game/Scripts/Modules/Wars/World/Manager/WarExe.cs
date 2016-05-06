using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.signals;
using Games.Module.Wars;
using Games.Module.Props;
using CC.Runtime.PB;


namespace Games.Module.Wars
{
	public class WarExe : EntityMBBehaviour 
	{

		protected override void OnAwake ()
		{
			base.OnAwake ();
			War.exe = this;
		}


		protected override void OnDestroy ()
		{
			base.OnDestroy ();
		
			if(War.exe == this) War.exe = null;
		}

		
		/** 建筑升级 */
		public void ExeUplevel(int buildId, int level, float time)
		{
			UnitCtl unitCtl = War.scene.GetBuild(buildId);
			unitCtl.levelData.ExeUplevel();
		}

		
		/** 箭塔攻击 */
		public void ExeTurret(int buildId, int soliderId)
		{
			UnitCtl build = War.scene.GetUnitForUID(buildId);
			UnitCtl solider = War.scene.GetUnitForUID(soliderId);

			if(build != null && solider != null)
			{
				BTurret turret = build.GetComponent<BTurret>();
				turret.ExeAtk(solider);
			}
		}
		
		
		/** 建筑势力 */
		public void ExeBuildChangeLegion(int buildId, int legionId)
		{
			UnitCtl build = War.scene.GetUnitForUID(buildId);
			
			if(build != null)
			{
				if(build.unitData.legionId != legionId)
				{
					build.unitData.ExeChangeLegion(legionId);
				}
			}
		}


		
		/** 同步英雄下阵 */
		public void ExeHeroBackstag(int heroUid, int targetLegionId)
		{
			UnitCtl heroUnit = War.scene.GetUnitForUID(heroUid);
			LegionData targetLegionData = War.GetLegionData(targetLegionId);
			War.scene.KillHero(heroUnit, targetLegionData);
		}
		
		/** 发兵 */
		public void ExeSendArm(int from, int to, int count, int idBegin)
		{
			UnitCtl fromUnit = War.scene.GetBuild(from);
			UnitCtl toUnit = War.scene.GetBuild(to);
			BSendArming sendArming = fromUnit.GetComponent<BSendArming>();
			sendArming.ExeSend(toUnit, count, idBegin);

//			Debug.Log ("S_SendArm sendArming=" + sendArming);
		}
		
		/** 技能 */
		public void ExeSkill(int skillUID, List<int> unitIds, Vector3 position)
		{
			SkillOperateData skillOperateData = War.sceneData.GetSkillOperateData(skillUID);
			if(skillOperateData != null)
			{
				skillOperateData.receiveList.Clear();
				foreach(int uid in unitIds)
				{
					UnitCtl unit = War.scene.GetUnitForUID(uid);
					if(unit != null)
					{
						skillOperateData.receiveList.Add(unit);
					}
				}

				skillOperateData.receivePosition = position;
				skillOperateData.S_Use();
			}
			else
			{
				Debug.Log(string.Format("<color=red>WarPVP.S_Skill skillOperateData=null  skillUID={0} </color>", skillUID));
			}
		}


		/** 属性 */
		public void ExeProp(List<ProtoFightUnitInfo> list)
		{
			foreach(ProtoFightUnitInfo unitPropData in list)
			{
				UnitCtl unit = War.scene.GetUnitForUID(unitPropData.unit_id);
				if(unit == null) continue;

				ProtoPropInfo prop_team = null;
				foreach(ProtoPropInfo propData in unitPropData.props)
				{
					if(propData.id == PropId.LegionID)
					{
						prop_team = propData;
					}
					else
					{
						unit.unitData.Props[propData.id] = propData.value / WarService.PROP_FLOAT_MULTIPLIER;
					}
				}

//				if(prop_team != null && unit.unitData.unitType == UnitType.Build)
//				{
//					if(prop_team.value != unit.unitData.legionId)
//					{
//						unit.unitData.ChangeLegion((int)prop_team.value);
//
//						foreach(ProtoPropInfo propData in unitPropData.props)
//						{
//							if(propData.id != PropId.LegionID)
//							{
//								unit.unitData.Props[propData.id] = propData.value / WarService.PROP_FLOAT_MULTIPLIER;
//							}
//						}
//					}
//				}

			}

			War.signal.DoProp (list);
		}


		/** 设置生产技能 */
		public void ExeSetProduceSkill(int legionId, int skillUid, float speed)
		{
			LegionData legionData = War.GetLegionData (legionId);
			UnitCtl unitCtl = War.scene.GetUnitForUID (legionData.unitData.uid);
			BLegionSkillManager skillManager = unitCtl.GetComponent<BLegionSkillManager> ();
			skillManager.SetProduceSkill (skillUid, speed);
		}


		/** 技能 */
		public void ExeSkill(S_SyncSkill_0x822 msg)
		{
			War.skillWarManager.DealSkillForPvp(msg);
		}

		/** 技能 */
		public void ExeSkill(C_SyncSkill_0x822 msg)
		{
			SkillOperateData skillOperateData = War.sceneData.GetSkillOperateData (msg.uid);

			if (skillOperateData.isRoleSkill)
			{
				War.skillWarManager.DealSkillForPvp(WarService.To__S_SyncSkill_0x822 (msg));
			} 
			else 
			{
				if (skillOperateData != null) 
				{
					skillOperateData.SetUse ();
				}

				StartCoroutine (DelayPlaySkill(msg));
			}

		}

		IEnumerator DelayPlaySkill(C_SyncSkill_0x822 msg)
		{
			yield return new WaitForSeconds (0.5f);
			War.skillWarManager.DealSkillForPvp(WarService.To__S_SyncSkill_0x822 (msg));
		}


		/** 游戏结束 */
		public void ExeGameOver(WarOverData overData)
		{

//			Debug.Log ("timeLineDatastarCount WarExe ExeGameOver War.isGameing=" + War.isGameing);
			if (War.isGameing)
			{
				War.S_Over (overData);
			}
		}

	}
}
