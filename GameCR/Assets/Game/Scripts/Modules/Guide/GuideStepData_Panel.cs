using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	/** 引导步奏数据--面板(打开/关闭) */
	public class GuideStepData_Panel : GuideStepData
	{
		/** 面板ID */
		public GuidePanelID 				panelId;

		public GuideStepData_Panel()
		{
			SetData(GuideStepType.War_OpenPanel, GuideStepCompleteType.NextFrame, "打开面板");
		}
		
		public GuideStepData_Panel(GuidePanelID panelId, GuideStepType stepType, string describe)
		{
			this.panelId = panelId;
			SetData(stepType, GuideStepCompleteType.NextFrame, describe);
		}

		
		public GuideStepData_Panel(GuidePanelID panelId, GuideStepType stepType, GuideStepCompleteType completeType, string describe)
		{
			this.panelId = panelId;
			SetData(stepType, completeType, 0, describe);
		}
		
		public GuideStepData_Panel(GuidePanelID panelId, GuideStepType stepType, GuideStepCompleteType completeType, float completeWaitSecond, string describe)
		{
			this.panelId = panelId;
			SetData(stepType, completeType, completeWaitSecond, describe);
		}
	}
}