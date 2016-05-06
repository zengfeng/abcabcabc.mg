using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideStepAction_War_Teacher : GuideStepAction
	{
		public GuideStepData_TeacherSay sayData;
		public override void SetData (GuideStepData data)
		{
			sayData = (GuideStepData_TeacherSay) data;
			base.SetData (data);
		}

		/** 进入 */
		public override void Enter ()
		{
			Guide.view.teacher.Say(sayData.content);
			base.Enter ();
		}


	}
}