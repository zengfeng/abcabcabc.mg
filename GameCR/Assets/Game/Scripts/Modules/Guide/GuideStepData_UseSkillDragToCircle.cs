using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	/** 引导步奏数据--拖动技能A到到区域 */
	public class GuideStepData_UseSkillDragToCircle : GuideStepData
	{
		public int skillId;
		public Vector3 position;
		public bool autoPosition;
		public int relation;
		public int unitType;

		public GuideStepData_UseSkillDragToCircle()
		{
			SetData(GuideStepType.War_Skill_Use_DragToCircle, "拖动技能A到到区域");
		}

		public GuideStepData_UseSkillDragToCircle(int skillId, Vector3 position)
		{
			this.skillId = skillId;
			this.position = position;

			SetData(GuideStepType.War_Skill_Use_DragToCircle, "拖动技能A到到区域");
		}


		public GuideStepData_UseSkillDragToCircle(int skillId,  Vector3 position, string describe)
		{
			this.skillId = skillId;
			this.position = position;

			SetData(GuideStepType.War_Skill_Use_DragToCircle, describe);
		}

		public GuideStepData_UseSkillDragToCircle(int skillId, int relation, int unitType)
		{
			this.skillId = skillId;
			this.autoPosition = true;
			this.relation = relation;
			this.unitType = unitType;

			SetData(GuideStepType.War_Skill_Use_DragToCircle, "拖动技能A到到区域");
		}



		public GuideStepData_UseSkillDragToCircle(int skillId, int relation, int unitType,  string describe)
		{
			this.skillId = skillId;
			this.autoPosition = true;
			this.relation = relation;
			this.unitType = unitType;

			SetData(GuideStepType.War_Skill_Use_DragToCircle, describe);
		}


	}
}