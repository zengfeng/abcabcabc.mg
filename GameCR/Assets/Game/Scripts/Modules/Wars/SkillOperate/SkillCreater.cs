using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class SkillCreater : EntityMBBehaviour 
	{
		public HeroSkillClipManager heroSkillClipManager;
		public float delayUseTime = 0.5f;
		protected override void Awake ()
		{
			base.Awake ();

			War.skillCreater = this;
			heroSkillClipManager = GetComponent<HeroSkillClipManager>();
		}



		public void OnUse(SkillOperateData operateData)
		{
			UnitCtl caster = operateData.caster != null ? operateData.caster : operateData.heroData.unit.GetComponent<UnitCtl>();
			operateData.caster = caster;


			if(operateData.isRoleSkill)
			{
				War.skillWarManager.DealSkill(operateData);
			}
			else
			{
				heroSkillClipManager.OnUse(operateData);
				StartCoroutine(DelayUse(operateData));
			}
		}

		public void SetUse(SkillOperateData operateData)
		{
			heroSkillClipManager.OnUse(operateData);
		}



		IEnumerator DelayUse(SkillOperateData operateData)
		{
			yield return new WaitForSeconds(delayUseTime);

//			if(operateData.skillConfig.isUseBuildProcessor)
//			{
//				OnUseBuild(operateData);
//			}
//			else
//			{
				War.skillWarManager.DealSkill(operateData);
//			}
		}


//		public void OnUseBuild(SkillOperateData data)
//		{
//			UnitCtl buildUnitCtl = data.GetReceiveUnitCtl();
//			
//			switch(data.skillConfig.skillType)
//			{
//			case SkillType.Build_Replace:
//				if(buildUnitCtl.unitData.buildConfig.id == data.skillConfig.buildId)
//				{
//					buildUnitCtl.unitData.BuildSkillUplevel();
//				}
//				else
//				{
//					buildUnitCtl.unitData.BuildChangeBuildConfig(data.skillConfig.buildId);
//				}
//				break;
//			case SkillType.Build_Attach:
//				buildUnitCtl.unitData.BuildAttachModule(data.skillConfig.buildModuleConfig);
//				break;
//			case SkillType.Build_Uplevel:
//				buildUnitCtl.unitData.BuildSkillUplevel();
//				break;
//			}
//			
//			if(data.skillConfig.addBuildMaxLevel > 0)
//			{
//				buildUnitCtl.unitData.build_addMaxLevel = data.skillConfig.addBuildMaxLevel;
//			}
//		}

	}
}