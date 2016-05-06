using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	/** 引导步奏数据--使用技能 */
	public class GuideStepData_UseSkill : GuideStepData
	{
		public int skillId;
		public int buildId;

		public GuideStepData_UseSkill()
		{
			SetData(GuideStepType.War_Skill_Use_DragToBuild, "使用技能");
		}

		public GuideStepData_UseSkill(int skillId, int buildId)
		{
			this.skillId = skillId;
			this.buildId = buildId;

			SetData(GuideStepType.War_Skill_Use_DragToBuild, "使用技能");
		}

		
		public GuideStepData_UseSkill(int skillId, int buildId, string describe)
		{
			this.skillId = skillId;
			this.buildId = buildId;
			
			SetData(GuideStepType.War_Skill_Use_DragToBuild, describe);
		}
	}
}