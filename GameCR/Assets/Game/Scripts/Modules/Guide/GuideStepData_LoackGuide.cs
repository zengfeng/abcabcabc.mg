using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	/** 引导步奏数据--使用技能 */
	public class GuideStepData_LoackGuide : GuideStepData
	{
		public int loackLevel;

		public GuideStepData_LoackGuide(int loackLevel, GuideStepType stepType)
		{
			this.loackLevel = loackLevel;
			SetData(stepType, "");
		}

		public GuideStepData_LoackGuide(int loackLevel, GuideStepType stepType, string describe)
		{
			this.loackLevel = loackLevel;
			SetData(stepType, describe);
		}


		public GuideStepData_LoackGuide(int loackLevel, GuideStepType stepType, GuideStepCompleteType completeType, string describe)
		{
			this.loackLevel = loackLevel;
			SetData(stepType, completeType, 0, describe);
		}


		public GuideStepData_LoackGuide(int loackLevel, GuideStepType stepType, GuideStepCompleteType completeType, float completeWaitSecond, string describe)
		{
			this.loackLevel = loackLevel;
			SetData(stepType, completeType, completeWaitSecond, describe);
		}

	}
}