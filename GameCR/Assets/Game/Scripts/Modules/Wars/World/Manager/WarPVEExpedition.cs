using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.signals;
using Games.Module.Wars;
using Games.Module.Props;
using CC.Runtime.PB;


namespace Games.Module.Wars
{
	public class WarPVEExpedition : EntityMBBehaviour 
	{

		protected override void OnAwake ()
		{
			base.OnAwake ();
			War.pveExpedition = this;
			
			War.signal.sBuildComplete += OnBuildComplete;
		}
		
		void OnBuildComplete()
		{

			War.signal.sBuildComplete -= OnBuildComplete;

			if(War.vsmode != VSMode.PVE_Expedition)
			{
				this.enabled = false;
			}
			else
			{
				War.signal.sHPConst += OnHPConst;
				War.signal.sHPAdd += OnHPAdd;
			}
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();

			War.signal.sBuildComplete -= OnBuildComplete;
			War.signal.sHPConst -= OnHPConst;
			War.signal.sHPAdd -= OnHPAdd;
			
		}

		void OnHPConst(int legionId, int casterLegionId, float constHP)
		{
			LegionData legionData = War.GetLegionData(legionId);
			legionData.expeditionTotalHP -= constHP;
			if(legionData.expeditionTotalHP < 0) legionData.expeditionTotalHP = 0;
		}

		
		void OnHPAdd(int legionId, int casterLegionId, float addHP)
		{
			LegionData legionData = War.GetLegionData(legionId);
			legionData.expeditionTotalHP += addHP;
//			legionData.expeditionLeftHP += addHP;
		}

		
		
		public void SetWarOverData(WarOverData overData)
		{
//			for(int i = 1; i < 3; i ++)
//			{
//				bool isLose = i == 1 ? !overData.isWin : overData.isWin ;
//				
//				LegionData legionData = War.GetLegionData(i);
//				if(isLose)
//				{
//					if(legionData.expeditionLeftHP<=0)
//					{
//						if(legionData.expeditionTotalHP < 6)
//						{
//							legionData.expeditionTotalHP = 0;
//						}
//					}
//				}
//
//				WarOverLegionData overLegionData = new WarOverLegionData();
//				overLegionData.legionId = legionData.legionId;
//				overLegionData.marale = Mathf.FloorToInt(legionData.mage);
//
//				if(War.isOverTime)
//				{	
//					overLegionData.troops_lose = Mathf.FloorToInt(legionData.expeditionInitHP);
//					overLegionData.troops_add = 0;
//				}
//				else
//				{
//					if(legionData.expeditionTotalHP <= legionData.expeditionInitHP)
//					{
//						overLegionData.troops_lose = Mathf.FloorToInt(legionData.expeditionInitHP - legionData.expeditionTotalHP);
//					}
//					else
//					{
//						overLegionData.troops_add = Mathf.FloorToInt(legionData.expeditionTotalHP - legionData.expeditionInitHP);
//					}
//				}
//
//				List<int> fight_heros = new List<int>();
//				List<int> dead_heros = new List<int>();
//				foreach(KeyValuePair<int, HeroData> kvp in legionData.heroDatas)
//				{
//					fight_heros.Add(kvp.Value.heroId);
//
//					if(War.isOverTime)
//					{
//						dead_heros.Add(kvp.Value.heroId);
//					}
//					else
//					{
//						if(isLose)
//						{
//							dead_heros.Add(kvp.Value.heroId);
//						}
//						else if(kvp.Value.state == HeroState.Backstage)
//						{
//							dead_heros.Add(kvp.Value.heroId);
//						}
//					}
//				}
//				overLegionData.fight_heros = fight_heros.ToArray();
//				overLegionData.dead_heros = dead_heros.ToArray();
//
//
//				if(i == 1)
//				{
//					overData.attacker = overLegionData;
//				}
//				else
//				{
//					overData.defender = overLegionData;
//				}
//			}
		}



	}
}
