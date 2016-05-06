using UnityEngine;
using System.Collections;
using CC.Runtime.signals;

namespace Games.Module.Wars
{
	/** 星星--初始有武将的城池不被占领 */
	public class Star_T3_InitOwnCasernNoOccupy_HasHero : StarProcessor 
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
			if(buildUnitData.initLegionId == War.ownLegionData.legionId && buildUnitData.heroData != null)
			{
				state = StarState.Fail;
				SignalFactory.GetInstance<WarBuildChangeLegion>().RemoveListener(OnBuildChangeTeam);
			}
		}




		override public void OnGameOver()
		{
			if(state != StarState.Fail)
			{
				if(War.sceneData.ownLegion.heroDatas.Count > 0)
				{
					SetSuccess();
				}
			}
		}

	}
}