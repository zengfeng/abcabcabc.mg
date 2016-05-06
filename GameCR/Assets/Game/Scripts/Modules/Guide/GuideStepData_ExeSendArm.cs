using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	/** 引导步奏数据--执行发兵 */
	public class GuideStepData_ExeSendArm : GuideStepData
	{
		public int from;
		public int to;
		public int count;

		public GuideStepData_ExeSendArm()
		{
			SetData(GuideStepType.War_ExeSendArm, "执行发兵");
		}

		public GuideStepData_ExeSendArm(int from, int to, int count)
		{
			this.from = from;
			this.to = to;
			this.count = count;

			SetData(GuideStepType.War_ExeSendArm, GuideStepCompleteType.NextFrame, "执行发兵");
		}

		
		public GuideStepData_ExeSendArm(int from, int to, int count, string describe)
		{
			this.from = from;
			this.to = to;
			this.count = count;
			
			SetData(GuideStepType.War_ExeSendArm,  GuideStepCompleteType.NextFrame, describe);
		}
	}
}