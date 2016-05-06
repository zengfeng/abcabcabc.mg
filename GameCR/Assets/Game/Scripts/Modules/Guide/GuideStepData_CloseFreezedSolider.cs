using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	/** 引导步奏数据--解除冻结士兵 */
	public class GuideStepData_CloseFreezedSolider : GuideStepData
	{
		public int relation;

		public GuideStepData_CloseFreezedSolider()
		{
			SetData(GuideStepType.War_CloseFreezedSolider,  GuideStepCompleteType.NextFrame, "解除冻结士兵");
		}

		public GuideStepData_CloseFreezedSolider(int relation)
		{
			this.relation = relation;
			SetData(GuideStepType.War_CloseFreezedSolider,  GuideStepCompleteType.NextFrame, "解除冻结士兵");
		}

		public GuideStepData_CloseFreezedSolider(int relation,  string describe)
		{
			this.relation = relation;
			SetData(GuideStepType.War_CloseFreezedSolider,  GuideStepCompleteType.NextFrame, describe);
		}

	
	}
}