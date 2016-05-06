using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	/** 引导步奏数据--升级 */
	public class GuideStepData_Uplevel : GuideStepData
	{
		public int buildId;

		public GuideStepData_Uplevel()
		{
			SetData(GuideStepType.War_Uplevel, "升级");
		}
		
		public GuideStepData_Uplevel(int buildId)
		{
			this.buildId = buildId;
			
			SetData(GuideStepType.War_Uplevel, "升级");
		}
		
		
		public GuideStepData_Uplevel(int buildId, string describe)
		{
			this.buildId = buildId;
			
			SetData(GuideStepType.War_Uplevel, describe);
		}
	}
}