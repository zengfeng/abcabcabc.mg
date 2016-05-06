using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	/** 监听引导步奏数据--执行释放技能 */
	public class GuideStepListenerData_ExeUseSkill : GuideStepListenerData
	{
		public int legionId;
		public int skillId;



		public GuideStepListenerData_ExeUseSkill(int legionId, int skillId, string describe)
		{
			this.legionId = legionId;
			this.skillId = skillId;

			SetData(GuideStepType.War_Listener_ExeUseSkill, describe);
			SetCompleteType (GuideStepCompleteType.NextFrame);
		}


	}
}