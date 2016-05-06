using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	/** 引导步奏数据--快速生产一个技能 */
	public class GuideStepData_ProduceSkill : GuideStepData
	{
		public int skillId;

		public GuideStepData_ProduceSkill()
		{
			SetData(GuideStepType.War_Skill_Produce, "快速生产一个技能");
		}

		public GuideStepData_ProduceSkill(int skillId)
		{
			this.skillId = skillId;

			SetData(GuideStepType.War_Skill_Produce,  GuideStepCompleteType.Call, "快速生产一个技能");
		}

		
		public GuideStepData_ProduceSkill(int skillId, string describe)
		{
			this.skillId = skillId;
			
			SetData(GuideStepType.War_Skill_Produce,  GuideStepCompleteType.Call, describe);
		}


		public GuideStepData_ProduceSkill(GuideStepType type, GuideStepCompleteType completeType, int skillId, string describe)
		{
			this.skillId = skillId;

			SetData(type,  completeType, describe);
		}
	}
}