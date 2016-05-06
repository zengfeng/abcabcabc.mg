using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	/** 引导步奏数据--美女教师说话 */
	public class GuideStepData_TeacherSay : GuideStepData
	{
		/** 内容 */
		public string 				content;

		public GuideStepData_TeacherSay()
		{
			content = "...";
			SetData(GuideStepType.War_SetTeacherSay, "美女说话");
		}

		public GuideStepData_TeacherSay(string content)
		{
			this.content = content;
			SetData(GuideStepType.War_SetTeacherSay, "美女说话");
		}

		
		public GuideStepData_TeacherSay(string content, float completeWaitSecond)
		{
			this.content = content;
			SetData(GuideStepType.War_SetTeacherSay, GuideStepCompleteType.WaitSecond, completeWaitSecond, "美女说话");
		}
		
		
		public GuideStepData_TeacherSay(string content, GuideStepCompleteType completeType)
		{
			this.content = content;
			SetData(GuideStepType.War_SetTeacherSay, completeType, 0, "美女说话");
		}
		
		public GuideStepData_TeacherSay(string content, GuideStepCompleteType completeType, float completeWaitSecond)
		{
			this.content = content;
			SetData(GuideStepType.War_SetTeacherSay, completeType, completeWaitSecond, "美女说话");
		}



	}
}