using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	/** 引导步奏数据--冻结士兵 */
	public class GuideStepData_FreezedSolider : GuideStepData
	{
		public int relation;

		public GuideStepData_FreezedSolider()
		{
			SetData(GuideStepType.War_FreezedSolider,  GuideStepCompleteType.NextFrame, "冻结士兵");
		}

		public GuideStepData_FreezedSolider(int relation)
		{
			this.relation = relation;
			SetData(GuideStepType.War_FreezedSolider,  GuideStepCompleteType.NextFrame, "冻结士兵");
		}

		public GuideStepData_FreezedSolider(int relation,  string describe)
		{
			this.relation = relation;
			SetData(GuideStepType.War_FreezedSolider,  GuideStepCompleteType.NextFrame, describe);
		}

	
	}
}