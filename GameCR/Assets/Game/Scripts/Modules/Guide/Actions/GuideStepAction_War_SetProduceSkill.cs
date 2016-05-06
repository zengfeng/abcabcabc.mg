using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideStepAction_War_SetProduceSkill : GuideStepAction
	{
		public GuideStepData_ProduceSkill mdata;
		public int skillUid = -1;
		public override void SetData (GuideStepData data)
		{
			mdata = (GuideStepData_ProduceSkill) data;
			base.SetData (data);
		}

		/** 进入 */
		private float mageSpeed;
		public override void Enter ()
		{
			base.Enter ();
			SetProduceSkillUid();
		}

		void SetProduceSkillUid()
		{
			War.sceneData.enableProduceSkill = true;
			SkillOperateData skillData = War.ownLegionData.GetSkillDataBySkillId(mdata.skillId);
			if (skillData != null) {
				skillUid = skillData.uid;
				if (War.ownLegionData.barSkillUids.IndexOf (skillData.uid) == -1) {
					War.ownLegionData.produceSkillUid = skillData.uid;

				}
			} else {
				NextFrameEnd ();
			}
		}

	

	}
}