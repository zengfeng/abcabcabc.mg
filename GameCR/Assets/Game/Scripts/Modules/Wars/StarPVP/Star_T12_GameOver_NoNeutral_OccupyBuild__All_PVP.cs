using UnityEngine;
using System.Collections;
using CC.Runtime.signals;

namespace Games.Module.Wars
{
	/** 星星--游戏结束--不包含中立--占领所有城池 */
	public class Star_T12_GameOver_NoNeutral_OccupyBuild__All_PVP : StarProcessor 
	{
		



		override public void OnGameOver()
		{

			int count = War.scene.GetBuildCount(legionData.legionId, 0.REnemy(true), false);
			if (count <= 0)
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