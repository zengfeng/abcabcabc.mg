using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideStepAction_War_Uplevel : GuideStepAction
	{
		public GuideStepData_Uplevel mdata;
		public MoveTo_SendArm moveTo;
		public override void SetData (GuideStepData data)
		{
			mdata = (GuideStepData_Uplevel) data;
			base.SetData (data);
		}

		/** 进入 */
		public override void Enter ()
		{
			Guide.view.screenMask.DrawUplevel (mdata.buildId);
			UnitCtl unitCtl = War.scene.GetBuild(mdata.buildId);
			Guide.view.SetHanldWorld(GuidePointHanld.HanldType.DoubleClick, unitCtl.transform.position + Vector3.up * 1.5f);

			War.signal.sHandUplevel += OnHandUplevel;
			base.Enter ();


			Guide.warConfig.EnterUplevel (mdata.buildId);
		}

		void OnHandUplevel(int buildId)
		{
			if(War.scene.GetBuild(buildId).unitData.relation == RelationType.Own)
			{
				Guide.view.CloseHanld();
				End();
			}
		}

		public override void Close ()
		{
			Guide.warConfig.CloseUplevel();
			War.signal.sHandUplevel -= OnHandUplevel;
			base.Close ();
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();
			
			War.signal.sHandUplevel -= OnHandUplevel;
		}



	}
}