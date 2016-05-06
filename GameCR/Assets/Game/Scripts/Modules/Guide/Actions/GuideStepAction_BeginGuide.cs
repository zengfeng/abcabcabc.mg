using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideStepAction_BeginGuide : GuideStepAction
	{

		/** 进入 */
		public override void Enter ()
		{
			base.Enter ();
			War.sceneData.enableAISendArm = false;
			War.sceneData.enableAIUplevel = false;
			War.sceneData.enableAISkill = false;
			War.sceneData.enableProduceSkill = false;
			War.sceneData.enableProduce = false;
			War.sceneData.enableTime = false;
			Guide.warConfig.guide = true;
			Guide.warConfig.SetAllDisable ();

//			Guide.view.screenMask.DrawBG ();
		}



	}
}