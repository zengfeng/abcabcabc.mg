using UnityEngine;
using System.Collections;
using Games.Module.Wars;
using System.Collections.Generic;
using Games.Module.Props;

namespace Games.Guides
{
	public class GuideStepAction_War_CloseFreezedSolider : GuideStepAction
	{
		public GuideStepData_CloseFreezedSolider mdata;
		public override void SetData (GuideStepData data)
		{
			mdata = (GuideStepData_CloseFreezedSolider) data;
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
				if (unit.unitData.Props [PropId.StateFreezedMoveSpeed] > 0) 
				{
					unit.unitData.Props [PropId.StateFreezedMoveSpeed] -= 1;
				}
			}


			list = War.scene.SearchUnit (0.UBuild(true), War.ownLegionID, mdata.relation);
			foreach(UnitCtl unit in list)
			{
				if (unit.unitData.Props [PropId.StateFreezedSendArm] > 0) 
				{
					unit.unitData.Props [PropId.StateFreezedSendArm] -= 1;
				}
			}
		}

		public override void Close ()
		{
			base.Close ();
		}


	}
}