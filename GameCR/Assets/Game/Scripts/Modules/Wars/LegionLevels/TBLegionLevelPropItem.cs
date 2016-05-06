using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using UnityEngine.UI;
using DG.Tweening;


namespace Games.Module.Wars
{

	public class TBLegionLevelPropItem : MonoBehaviour 
	{
		public LerpIntText attack;
		public LerpIntText produceSpeed;
		public LerpIntText moveSpeed;



		public LegionData legionDta;
		public LegionLevelData legionLevelData;

		void Start () 
		{

		}

		private int _level = -1;
		void Update () 
		{
			if(legionLevelData == null) return;



			if(_level != legionLevelData.Level)
			{
				_level 			= legionLevelData.Level;

				OnSet();
			}

		}


		void OnSet()
		{
			attack.Value 			= legionLevelData.atk;
			produceSpeed.Value 		= legionLevelData.produceSpeed;
			moveSpeed.Value 		= legionLevelData.moveSpeed;

		}



		public void SetData(LegionData legionDta)
		{
			if(legionDta != null)
			{
				this.legionDta 			= legionDta;
				this.legionLevelData 	= legionDta.levelData;
			}
		}


	}
}