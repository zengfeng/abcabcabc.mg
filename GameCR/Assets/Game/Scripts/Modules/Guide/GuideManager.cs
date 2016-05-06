using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideManager: MonoBehaviour
	{

		/** 当前引导模块 */
		public GuideModuleData 	moduleData;
		/** 当前引导步骤 */
		public GuideStepData	stepData;
		/**  */
		public GuideModuleAction		moduleAction;

		/** 播放模块 */
		public void PlayModule(GuideModuleData moduleData)
		{
			this.moduleData = moduleData;
			moduleAction = (GuideModuleAction) Guide.actionManager.CreateAction(moduleData);
			moduleAction.SetData(moduleData);
			moduleAction.Enter();
		}
		
		/** 播放步奏 */
		public void PlayStep(int stepIndex)
		{
		}
		
		/** 播放步奏 */
		public void PlayStep(GuideStepData stepData)
		{
			this.stepData = stepData;
		}

		/** 播放下一步骤 */
		public void NextStep()
		{

		}

		/** 设置引导"步骤"完成 */
		public void SetStepComplete()
		{

		}
		
		/** 设置引导"模块"完成 */
		public void SetModuleComplete()
		{

		}
		
		/** 设置引导完成 */
		public void SetGuildComplete()
		{
		}

	}

}