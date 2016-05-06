using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Games.Module.Wars
{
	public class TBLegionHPItem : MonoBehaviour
	{
		public Image 	color;
		public Text 	text;



		public void SetData(float val, float max)
		{
			text.text = Mathf.FloorToInt (val) + "" ;
//			text.text = Mathf.FloorToInt (val) + "/" +  Mathf.FloorToInt (max) ;
			color.fillAmount = max > 0 ? Mathf.Max(Mathf.Min(val / max, 1), 0) : 0;
		}

	}
}