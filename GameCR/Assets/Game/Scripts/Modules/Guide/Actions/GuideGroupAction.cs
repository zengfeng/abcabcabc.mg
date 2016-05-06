using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	public class GuideGroupAction : GuideStepAction
	{
		public int index = 0;
		public GuideGroupData groupData;

		public override void SetData (GuideStepData data)
		{
			this.groupData =(GuideGroupData) data;
			base.SetData (data);
		}

		public override void Enter ()
		{
			CheckChild();
			base.Enter ();
		}

		public override void End ()
		{
			base.End ();
		}


		public virtual void CheckChild()
		{

		}

		public virtual void PlayChild(GuideStepData stepData)
		{
			GuideStepAction action = Guide.actionManager.CreateAction(stepData);
			action.SetData(stepData);
			action.Enter();
		}

	}
}