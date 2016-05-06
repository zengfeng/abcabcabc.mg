using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	/** 引导步奏数据--发兵 */
	public class GuideStepData_SendArm : GuideStepData
	{
		public int from;
		public int to;

		public GuideStepData_SendArm()
		{
			SetData(GuideStepType.War_SendArm, "发兵");
		}

		public GuideStepData_SendArm(int from, int to)
		{
			this.from = from;
			this.to = to;

			SetData(GuideStepType.War_SendArm, "发兵");
		}

		
		public GuideStepData_SendArm(int from, int to, string describe)
		{
			this.from = from;
			this.to = to;
			
			SetData(GuideStepType.War_SendArm, describe);
		}
	}
}