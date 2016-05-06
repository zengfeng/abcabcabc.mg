using UnityEngine;
using System.Collections;
using Games.Module.Wars;
using System.Collections.Generic;

namespace Games.Guides
{
	public class GuideStepAction_War_FreezedSolider : GuideStepAction
	{
		public GuideStepData_FreezedSolider mdata;
		public override void SetData (GuideStepData data)
		{
			mdata = (GuideStepData_FreezedSolider) data;
			base.SetData (data);
		}

		/** 进入 */
		public override void Enter ()
		{
			base.Enter ();

			List<UnitCtl> list = null;
			list = War.scene.SearchUnit (0.USolider(true), War.ownLegionID, mdata.relation);
			foreach(UnitCtl unit in list)
			{
				unit.unitData.freezedMoveSpeed = true;
			}


			list = War.scene.SearchUnit (0.UBuild(true), War.ownLegionID, mdata.relation);
			foreach(UnitCtl unit in list)
			{
				unit.unitData.freezedSendArm = true;
			}
		}

		public override void Close ()
		{
			base.Close ();
		}


	}
}