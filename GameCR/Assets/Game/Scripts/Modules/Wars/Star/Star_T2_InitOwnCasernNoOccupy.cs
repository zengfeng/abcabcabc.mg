using UnityEngine;
using System.Collections;
using CC.Runtime.signals;

namespace Games.Module.Wars
{
	/** 星星--初始自己城池不占领 */
	public class Star_T2_InitOwnCasernNoOccupy : StarProcessor 
	{

		void OnEnable()
		{
			if(state == StarState.Doing)
			{
				SignalFactory.GetInstance<WarBuildChangeLegion>().AddListener(OnBuildChangeTeam);
			}
		}

		void OnDisable()
		{
			SignalFactory.GetInstance<WarBuildChangeLegion>().RemoveListener(OnBuildChangeTeam);
		}

		/** 兵营改变势力 */
		public void OnBuildChangeTeam(UnitData buildUnitData, int preTeam, int targetTeam)
		{
			if(buildUnitData.initLegionId == War.ownLegionData.legionId)
			{
				state = StarState.Fail;
				SignalFactory.GetInstance<WarBuildChangeLegion>().RemoveListener(OnBuildChangeTeam);
			}
		}




		override public void OnGameOver()
		{
			if(state != StarState.Fail)
			{
				SetSuccess();
			}
		}

	}
}