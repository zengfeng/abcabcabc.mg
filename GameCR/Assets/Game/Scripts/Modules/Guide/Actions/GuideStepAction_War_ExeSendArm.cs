using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideStepAction_War_ExeSendArm : GuideStepAction
	{
		public GuideStepData_ExeSendArm sendData;
		public override void SetData (GuideStepData data)
		{
			sendData = (GuideStepData_ExeSendArm) data;
			base.SetData (data);
		}

		/** 进入 */
		public override void Enter ()
		{
			base.Enter ();

			UnitCtl fromUnit = War.scene.GetBuild (sendData.from);
			UnitCtl toUnit = War.scene.GetBuild (sendData.to);

			if (fromUnit != null && toUnit != null) 
			{
				BSendArming sendArming = fromUnit.GetComponent<BSendArming> ();
				sendArming.Send (toUnit, sendData.count);
			}

		}

		public override void Close ()
		{
			base.Close ();
		}


	}
}