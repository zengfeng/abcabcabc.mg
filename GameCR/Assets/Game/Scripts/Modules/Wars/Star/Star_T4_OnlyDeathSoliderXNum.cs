using UnityEngine;
using System.Collections;
using CC.Runtime.signals;

namespace Games.Module.Wars
{
	public class Star_T4_OnlyDeathSoliderXNum : StarProcessor 
	{
		public float hpCost = 0f;
		public int soliderNum
		{
			get
			{
				return starConfig.parameters[0];
			}
		}

		public override void Init (StarConfig starConfig)
		{
			base.Init (starConfig);
			processParameters = new object[2];
			processParameters[0] = starConfig.parameters[0];
			processParameters[1] = hpCost;
		}
	


		void OnEnable()
		{
			if(state == StarState.Doing)
			{
				War.signal.sHPConst += OnHPCost;
			}
		}
		
		void OnDisable()
		{
			War.signal.sHPConst -= OnHPCost;
		}
		
		/** 兵营改变势力 */
		public void OnHPCost(int legionId, int casterLegionId, float hp)
		{
			if(legionId == War.ownLegionData.legionId)
			{
				hpCost += hp;
				processParameters[1] = hpCost;
				if(hpCost > soliderNum)
				{
					state = StarState.Fail;
//					SignalFactory.GetInstance<WarHPCost>().RemoveListener(OnHPCost);
				}
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