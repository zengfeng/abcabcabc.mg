using UnityEngine;
using System.Collections;
using CC.Runtime.signals;

namespace Games.Module.Wars
{
	/** 星星--游戏结束--不包含中立--我方城池大于敌方城池数量 */
	public class Star_T13_GameOver_NoNeutral_OccupyBuild__OwnFriend_Greater_Enemy_PVP : StarProcessor 
	{
		



		override public void OnGameOver()
		{

			int ownfriendCount = War.scene.GetBuildCount(legionData.legionId, 0.ROwn(true).RFriendly(true), false);
			int enemyCount = War.scene.GetBuildCount(legionData.legionId, 0.REnemy(true), false);
			if (ownfriendCount > enemyCount)
			{
				state = StarState.Success;
			}


			if(state != StarState.Success)
			{
				state = StarState.Fail;
			}
		}


	}
}