using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Guides
{
	/** 引导步奏数据 */
	public class GuideStepData : ScriptableObject
	{

		/** 父组 */
		public GuideGroupData 	parent;
		public GuideStepAction		action;

		/** 备注 */
		public string			describe;
		/** 步骤编号 */
		public int 				stepIndex;
		/** 步骤类型 */
		public GuideStepType 	stepType; 

		/** 自动完成步骤 */
		public GuideStepCompleteType 	completeType;
		/** 等待完成时间 */
		public float 					completeWaitSecond;


		public GuideStepData()
		{
		}
		
		public GuideStepData(GuideStepType stepType)
		{
			SetData(stepType, "");
		}

		public GuideStepData(GuideStepType stepType, string describe)
		{
			SetData(stepType, describe);
		}

		
		public GuideStepData(GuideStepType stepType, GuideStepCompleteType completeType, string describe)
		{
			SetData(stepType, completeType, 0, describe);
		}
		
		
		public GuideStepData(GuideStepType stepType, GuideStepCompleteType completeType, float completeWaitSecond, string describe)
		{
			SetData(stepType, completeType, completeWaitSecond, describe);
		}

		public virtual void SetData(GuideStepType stepType, string describe)
		{
			this.stepType = stepType;
			this.describe = describe;
		}
		
		public virtual void SetData(GuideStepType stepType, GuideStepCompleteType completeType,  string describe)
		{
			this.stepType = stepType;
			this.completeType = completeType;
			this.describe = describe;
		}

		public virtual void SetData(GuideStepType stepType, GuideStepCompleteType completeType, float completeWaitSecond, string describe)
		{
			this.stepType = stepType;
			this.completeType = completeType;
			this.completeWaitSecond = completeWaitSecond;
			this.describe = describe;
		}

		public virtual GuideStepData SetCompleteType(GuideStepCompleteType completeType)
		{
			this.completeType = completeType;
			return this;
		}

		public virtual GuideStepData SetCompleteType(GuideStepCompleteType completeType, float completeWaitSecond)
		{
			this.completeType = completeType;
			this.completeWaitSecond = completeWaitSecond;
			return this;
		}

		public virtual int Init(int id)
		{
			stepIndex = id + 1;
			return stepIndex;
		}

		public virtual string ToCsv(int stageId)
		{
			string csv = "";
			csv += stageId + ";";
			csv += stepIndex 	+ ";";
			csv += describe 	+ ";";
			csv += GuideUtil.GetId(stepType) 		+ " " 	+ 	GuideUtil.GetName(stepType) + ";";
			csv += GuideUtil.GetId(completeType) 	+ " " 	+ 	GuideUtil.GetName(completeType) + ";";
			csv += completeWaitSecond + ";";

			return csv;
		}

		public virtual List<string> GetCsv(int stageId, List<string> list)
		{
			if (list == null)
				list = new List<string> ();
			
			list.Add (ToCsv(stageId));

			return list;
		}

	}
}