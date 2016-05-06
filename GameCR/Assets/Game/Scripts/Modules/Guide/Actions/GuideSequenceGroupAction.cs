using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	public class GuideSequenceGroupAction : GuideGroupAction
	{
	
		override public void OnChildEnd(GuideStepData childData)
		{
			CheckChild();
		}
		
		override public void CheckChild()
		{
			if(index < groupData.stepList.Count)
			{
				GuideStepData stepData = groupData.stepList[index];
				PlayChild(stepData);
				index ++;
			}
			else
			{
				End();
			}
		}

	}
}