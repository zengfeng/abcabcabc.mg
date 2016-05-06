using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.signals;
using Games.Module.Wars;
using Games.Module.Props;
using CC.Runtime.PB;


namespace Games.Module.Wars
{
	public class WarPVP : EntityMBBehaviour 
	{

		protected override void OnAwake ()
		{
			base.OnAwake ();
			War.pvp = this;
			if(War.vsmode != VSMode.PVP)
			{
				enabled = false;
			}
		}


		protected override void OnDestroy ()
		{
			base.OnDestroy ();
		
			if(War.pvp == this) War.pvp = null;
		}

		
		/** 建筑升级 */
		public void C_Uplevel(int buildId)
		{
			War.service.C_SyncUplevel_0x825(buildId, 0, 0);
		}

		
		/** 建筑升级 */
		public void C_Turret(UnitCtl build, UnitCtl solider)
		{
			War.service.C_SyncTurret_0x826(build.unitData.uid, solider.unitData.uid);
		}
		
		/** 建筑势力 */
		public void C_Build(int uid, int legionId)
		{
			War.service.C_SyncBuild_0x827(uid, legionId);
		}


		
		/** 同步英雄下阵 */
		public void C_HeroBackstag(int heroUid, int targetLegionId)
		{
			War.service.C_SyncHeroBackstage_0x828(heroUid, targetLegionId);
		}

		/** 发兵 */
		public void C_SendArm(UnitCtl from, UnitCtl to, int count, int idBegin)
		{
			War.service.C_SyncSendArm_0x820(from.unitData.id, to.unitData.id, count, idBegin);
		}

		
		/** 技能 */
		public void C_Skill(SkillOperateData skillOperateData)
		{
            War.skillWarManager.DealSkill(skillOperateData);
		}




		/** 属性 */
		private float prop_casern_time = 2f;
		override protected void OnUpdate () 
		{
			if(War.isGameing == false || War.mainLegionID != War.ownLegionID)
			{
				return;
			}

			prop_casern_time -= Time.deltaTime;
			if(prop_casern_time <= 0)
			{
				prop_casern_time = 2f;
				C_Prop_Build();
			}
		}


		public List<ProtoFightUnitInfo> GetUnitPropList()
		{
			List<ProtoFightUnitInfo> unitPropList = new List<ProtoFightUnitInfo>();
			foreach(UnitCtl unit in War.scene.buildList)
			{
				ProtoFightUnitInfo unitPropData = new ProtoFightUnitInfo();
				unitPropData.unit_id = unit.unitData.id;
				WarService.PropToProtoPropInfoList(unit.unitData.Props, unitPropData.props);
				unitPropList.Add(unitPropData);
			}

			return unitPropList;
		}


		void C_Prop_Build()
		{
			War.service.C_SyncProp_0x821(GetUnitPropList());
		}









	}
}
