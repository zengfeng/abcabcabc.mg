using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideStepAction_UnloackGuide : GuideStepAction
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
				War.sceneData.enableAISendArm = true;
				War.sceneData.enableAIUplevel = true;
				War.sceneData.enableAISkill = true;
				War.sceneData.enableProduceSkill = true;
				War.sceneData.enableProduce = true;
				War.sceneData.enableTime = true;
				Guide.warConfig.lockGuide = false;
				Guide.warConfig.enableSendArm = true;
				Guide.warConfig.enableUplevel = true;
				Guide.warConfig.enableSkill = true;

				Guide.view.screenMask.Hide ();
			} 
			else 
			{

				if (mdata.loackLevel.GLLTime ()) 
				{
					War.sceneData.enableTime = true;
				}


				if (mdata.loackLevel.GLLProduceSkill ()) 
				{
					War.sceneData.enableProduceSkill = true;
				}

				if (mdata.loackLevel.GLLProduce ()) 
				{
					War.sceneData.enableProduce = true;
				}

				if (mdata.loackLevel.GLLHanld ()) 
				{
					Guide.warConfig.lockGuide = false;
					Guide.warConfig.enableSendArm = true;
					Guide.warConfig.enableUplevel = true;
					Guide.warConfig.enableSkill = true;


					Guide.view.screenMask.Hide ();
				}



				if (mdata.loackLevel.GLLAi ())
				{
					War.sceneData.enableAISendArm = true;
					War.sceneData.enableAIUplevel = true;
					War.sceneData.enableAISkill = true;
				}
				else 
				{
					if(mdata.loackLevel.GLLAiSendArm ())
						War.sceneData.enableAISendArm = true;


					if(mdata.loackLevel.GLLAiUplevel ())
						War.sceneData.enableAIUplevel = true;

					if(mdata.loackLevel.GLLAiSkill ())
						War.sceneData.enableAISkill = true;
				}
			}
		}



	}
}