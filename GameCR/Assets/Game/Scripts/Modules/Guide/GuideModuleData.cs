using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Guides
{
	public class GuideModuleData :GuideGroupData
	{
		/** 引导模块ID */
		public int 		moduleId;

		public GuideModuleData()
		{
			SetData(0, GuideGroupType.Sequence, GuideStepType.Module, "模块");
		}

		public GuideModuleData(int moduleId, string describe)
		{
			SetData(moduleId, GuideGroupType.Sequence, GuideStepType.Module, describe);
		}

		public virtual void SetData(int moduleId, GuideGroupType groupType, GuideStepType stepType, string describe)
		{
			this.moduleId = moduleId;
			SetData(groupType, stepType, describe);
		}

		public void Init()
		{
			Init (0);
		}

		public List<string> GetCsv ()
		{
			List<string> list = new List<string>();
			return base.GetCsv (moduleId, list);
		}

	}
}