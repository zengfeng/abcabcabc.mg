using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideStepAction_War_UseSkill : GuideStepAction
	{
		public GuideStepData_UseSkill mdata;
		public override void SetData (GuideStepData data)
		{
			mdata = (GuideStepData_UseSkill) data;
			base.SetData (data);
		}

		/** 进入 */
		public override void Enter ()
		{
			Guide.view.useSkill.Set(this, mdata.skillId, mdata.buildId);
			base.Enter ();

			Guide.warConfig.EnterSkill (mdata.skillId, mdata.buildId);
		}

		public override void Close ()
		{
			Guide.warConfig.CloseSkill();
			base.Close ();
		}


	}
}