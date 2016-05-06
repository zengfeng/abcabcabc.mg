using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideStepListenerAction_War_ExeUseSkill : GuideStepListenerAction
	{
		public GuideStepListenerData_ExeUseSkill mdata;

		public override void SetData (GuideStepData data)
		{
			mdata = (GuideStepListenerData_ExeUseSkill) data;
			base.SetData (data);
		}

		public bool isExed;
		protected override void Exe ()
		{
			if (isExed)
				return;
			
			Debug.Log ("GuideStepListenerData_ExeUseSkill.Exe");
			LegionData legionData = War.GetLegionData (mdata.legionId);
			if (legionData != null)
			{
				UnitCtl unitCtl = War.scene.GetUnitForUID (legionData.unitData.uid);
				if (unitCtl != null) 
				{
					BLegionAI_Skill legionAI = unitCtl.GetComponent<BLegionAI_Skill> ();
					if (legionAI != null) 
					{
						legionAI.ExeSkill (mdata.skillId);
					}
				}
			}
			isExed = true;

			base.Exe ();
		}


	}
}