using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideStepAction_War_ScreenMaskDraw : GuideStepAction
	{
		public GuideStepData_ScreenMaskDraw mdata;
		public override void SetData (GuideStepData data)
		{
			mdata = (GuideStepData_ScreenMaskDraw) data;
			base.SetData (data);
		}

		/** 进入 */
		public override void Enter ()
		{
			switch(mdata.drawType)
			{
			case GuideScreenMaskDrawType.Build:
				Guide.view.screenMask.DrawBuild (mdata.buildId);
				break;
			case GuideScreenMaskDrawType.SendArm:
				Guide.view.screenMask.DrawSendArm (mdata.fromBuildId, mdata.toBuildId);
				break;
			case GuideScreenMaskDrawType.Position:
				Guide.view.screenMask.DrawCircle (mdata.worldPosition);
				break;
			case GuideScreenMaskDrawType.Hide:
				Guide.view.screenMask.Hide();
				break;
			case GuideScreenMaskDrawType.ResetAndShow:
				Guide.view.screenMask.ResetAndShow();
				break;
			}


			base.Enter ();
		}

		public override void Close ()
		{
			base.Close ();
		}


	}
}