using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideStepAction_LoackGuide : GuideStepAction
	{
		public GuideStepData_LoackGuide mdata;
		public override void SetData (GuideStepData data)
		{
			mdata = (GuideStepData_LoackGuide)data;
			base.SetData (data);
		}

		/** 进入 */
		public override void Enter ()
		{
			base.Enter ();

			if (mdata.loackLevel.GLLAll ()) 
			{
				War.sceneData.enableAISendArm = false;
				War.sceneData.enableAIUplevel = false;
				War.sceneData.enableAISkill = false;
				War.sceneData.enableProduceSkill = false;
				War.sceneData.enableProduce = false;
				War.sceneData.enableTime = false;
				Guide.warConfig.lockGuide = true;
				Guide.warConfig.enableSendArm = false;
				Guide.warConfig.enableUplevel = false;
				Guide.warConfig.enableSkill = false;

				Guide.view.screenMask.DrawBG ();
			} 
			else 
			{
				if (mdata.loackLevel.GLLTime ()) 
				{
					War.sceneData.enableTime = false;
				}


				if (mdata.loackLevel.GLLProduceSkill ()) 
				{
					War.sceneData.enableProduceSkill = false;
				}

				if (mdata.loackLevel.GLLProduce ()) 
				{
					War.sceneData.enableProduce = false;
				}

				if (mdata.loackLevel.GLLHanld ()) 
				{
					Guide.warConfig.lockGuide = true;
					Guide.warConfig.enableSendArm = false;
					Guide.warConfig.enableUplevel = false;
					Guide.warConfig.enableSkill = false;

					Guide.view.screenMask.DrawBG ();
				}



				if (mdata.loackLevel.GLLAi ())
				{
					War.sceneData.enableAISendArm = false;
					War.sceneData.enableAIUplevel = false;
					War.sceneData.enableAISkill = false;
				}
				else 
				{
					if(mdata.loackLevel.GLLAiSendArm ())
						War.sceneData.enableAISendArm = false;


					if(mdata.loackLevel.GLLAiUplevel ())
						War.sceneData.enableAIUplevel = false;
					
					if(mdata.loackLevel.GLLAiSkill ())
						War.sceneData.enableAISkill = false;
				}
			}


		}



	}
}