using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	public class GuideParallelGroupAction : GuideGroupAction
	{
		public int childEndCount = 0;
		override public void OnChildEnd(GuideStepData childData)
		{
			childEndCount ++;
			if(childEndCount == groupData.stepList.Count)
			{
				End();
			}
		}
		
		override public void CheckChild()
		{
			if(groupData.stepList.Count == 0)
			{
				End();
			}
			else
			{
				for(int i = 0; i < groupData.stepList.Count; i ++)
				{
					PlayChild(groupData.stepList[i]);
				}
			}
		}

	}
}