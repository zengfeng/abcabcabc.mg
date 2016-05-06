using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideStepAction_War_ProduceSkill : GuideStepAction
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
			SetProduceSkillUid();

			mageSpeed = War.ownLegionData.unitData.mageSpeed;
			if(War.ownLegionData.barSkillUids.IndexOf(skillUid) == -1 || skillUid == -1)
			{
				War.ownLegionData.unitData.mageSpeed = 100;
			}
			StartCoroutine(OnCheckProduce());
			base.Enter ();
		}

		void SetProduceSkillUid()
		{
			SkillOperateData skillData = War.ownLegionData.GetSkillDataBySkillId(mdata.skillId);
			if(skillData != null)
			{
				skillUid = skillData.uid;
				if(War.ownLegionData.barSkillUids.IndexOf(skillData.uid) == -1)
				{
					War.ownLegionData.produceSkillUid = skillData.uid;
				}
			}
		}

		IEnumerator OnCheckProduce()
		{
			yield return new WaitForSeconds(0.1f);
			SetProduceSkillUid();

			while(true)
			{
				yield return new WaitForSeconds(0.1f);
				if(War.ownLegionData.barSkillUids.IndexOf(skillUid) != -1 || skillUid == -1)
				{
					End();
					break;
				}
			}
		}

		public override void End ()
		{
			War.ownLegionData.unitData.mageSpeed = mageSpeed;
			base.End ();
		}



	

	}
}