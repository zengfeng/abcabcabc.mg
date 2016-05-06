using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideStepAction_War_SendArm : GuideStepAction
	{
		public GuideStepData_SendArm sendData;
		public MoveTo_SendArm moveTo;
		public override void SetData (GuideStepData data)
		{
			sendData = (GuideStepData_SendArm) data;
			base.SetData (data);
		}

		/** 进入 */
		public override void Enter ()
		{
			Guide.view.screenMask.DrawSendArm (sendData.from, sendData.to);

			moveTo = new MoveTo_SendArm(sendData.stepIndex, sendData.from, sendData.to, Guide.view.moveToPanel, this);
			moveTo.Init();
			base.Enter ();

			Guide.warConfig.EnterSendArm (sendData.from, sendData.to);
		}

		public override void Close ()
		{
			Guide.warConfig.CloseSendArm ();
			base.Close ();
		}


	}
}