using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideStepAction_War_UseSkillDragToCircle : GuideStepAction
	{
		public GuideStepData_UseSkillDragToCircle mdata;
		public override void SetData (GuideStepData data)
		{
			mdata = (GuideStepData_UseSkillDragToCircle) data;
			base.SetData (data);
		}

		/** 进入 */
		public override void Enter ()
		{
			Guide.view.useSkillDragToCircle.Set(this);
			base.Enter ();

			Guide.warConfig.EnterSkill (mdata.skillId, -1);
		}

		public override void Close ()
		{
			Guide.warConfig.CloseSkill();
			base.Close ();
		}


	}
}