using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Games.Module.Wars
{

	public class TBLegionLevelItem : MonoBehaviour
	{

		public Image 		colorImage;
		public Text  		levelText;
		public GameObject 	ps;

		public LegionData legionDta;
		public LegionLevelData legionLevelData;

		void Start () 
		{
		
		}

		private float _exp = -1;
		private int _level = -1;
		void Update () 
		{
			if(legionLevelData == null) return;

			if(_exp != legionLevelData.exp)
			{
				_exp 					= legionLevelData.exp;
				colorImage.fillAmount 	= legionLevelData.maxExp == 0 ? 1 : Mathf.Max(0, Mathf.Min(1, legionLevelData.exp / legionLevelData.maxExp));
			}

			
			if(_level != legionLevelData.Level)
			{
				_level 			= legionLevelData.Level;
				levelText.text 	= legionLevelData.Level + "";

				OnUplevel();
			}

		}



		bool _isFirst = true;
		void OnUplevel()
		{
			if(_isFirst)
			{
				_isFirst = false;
				return;
			}


			ps.SetActive (true);

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