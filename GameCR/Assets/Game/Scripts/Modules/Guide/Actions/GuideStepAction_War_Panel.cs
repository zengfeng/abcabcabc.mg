using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideStepAction_War_Panel : GuideStepAction
	{
		public GuideStepData_Panel panelData;
		public override void SetData (GuideStepData data)
		{
			panelData = (GuideStepData_Panel) data;
			base.SetData (data);
		}

		/** 进入 */
		public override void Enter ()
		{
			switch(panelData.stepType)
			{
				/** 打开面板 */
			case GuideStepType.War_OpenPanel:
				Guide.view.ShowPanel(panelData.panelId);
				break;
				/** 关闭面板 */
			case GuideStepType.War_ClosePanel:
				Guide.view.HidePanel(panelData.panelId);
				break;
				
			
			}
			base.Enter ();
		}


	}
}