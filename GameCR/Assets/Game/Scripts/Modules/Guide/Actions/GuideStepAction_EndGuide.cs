using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideStepAction_EndGuide : GuideStepAction
	{

		/** 进入 */
		public override void Enter ()
		{
			base.Enter ();

			War.sceneData.enableAISendArm = true;
			War.sceneData.enableAIUplevel = true;
			War.sceneData.enableAISkill = true;
			War.sceneData.enableProduceSkill = true;
			War.sceneData.enableProduce = true;
			War.sceneData.enableTime = true;
			Guide.warConfig.guide = false;
			Guide.warConfig.EndGuide ();
			Guide.view.screenMask.Hide ();
		}



	}
}