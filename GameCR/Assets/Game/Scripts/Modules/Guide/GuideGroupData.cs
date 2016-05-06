using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Guides
{
	public class GuideGroupData : GuideStepData
	{
		/** 组类型 */
		public GuideGroupType 		groupType;
		/** 步骤列表 */
		public List<GuideStepData> 	stepList = new List<GuideStepData>();

		public GuideGroupData()
		{
			SetData(GuideGroupType.Sequence, GuideStepType.Group, "组");
		}
		
		public GuideGroupData(GuideGroupType groupType, string describe)
		{
			SetData(groupType, GuideStepType.Group, describe);
		}

		public virtual void SetData(GuideGroupType groupType, GuideStepType stepType, string describe)
		{
			this.groupType = groupType;
			SetData(stepType, describe);
		}

		public GuideGroupData Add(GuideStepData stepData)
		{
			stepList.Add(stepData);
			return this;
		}


		public override int Init(int id)
		{

			int count = stepList.Count;
			for(int i = 0; i < count; i ++)
			{
				stepList[i].parent = this;
				id = stepList[i].Init(id);
			}

			id = base.Init (id);

			return id;

		}

		public override List<string> GetCsv (int stageId, List<string> list)
		{
			int count = stepList.Count;
			for(int i = 0; i < count; i ++)
			{
				list = stepList[i].GetCsv(stageId, list);
			}

			list = base.GetCsv (stageId, list);

			return list;
		}

	}
}
