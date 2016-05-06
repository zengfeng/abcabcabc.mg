using UnityEngine;
using System.Collections;

namespace Games.Module.Wars
{
	/** 星星--全程手动 */
	public class Star_T1_FullManual : StarProcessor 
	{

		override protected void OnLateUpdate()
		{
			if(War.ownLegionData.aiSendArm)
			{
				state = StarState.Fail;
			}
		}

		override public void OnGameOver()
		{
			if(state != StarState.Success)
			{
				state = StarState.Fail;
			}
		}

	}
}