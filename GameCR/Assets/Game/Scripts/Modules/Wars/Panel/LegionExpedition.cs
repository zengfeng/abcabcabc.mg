using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	public class LegionExpedition : MonoBehaviour 
	{
		public LegionData attack;
		public LegionData defense;

		public LegionExpeditionItem attackItem;
		public LegionExpeditionItem defenseItem;
		void Start () 
		{
			War.signal.sBuildComplete += OnBuildComplete;
		}
		
		void OnDestroy()
		{
			War.signal.sBuildComplete -= OnBuildComplete;
		}
		
		void OnBuildComplete()
		{
			if(War.vsmode != VSMode.PVE_Expedition)
			{
				gameObject.SetActive(false);
			}

			attack = War.GetLegionData(1);
			defense = War.GetLegionData(2);
		}

		void Update()
		{
			if(attack == null) return;

			attackItem.SetHP(attack.expeditionTotalHP, attack.expeditionTotalMaxHP, attack.expeditionLeftHP);
			defenseItem.SetHP(defense.expeditionTotalHP, defense.expeditionTotalMaxHP, defense.expeditionLeftHP);
		}

	

	}
}