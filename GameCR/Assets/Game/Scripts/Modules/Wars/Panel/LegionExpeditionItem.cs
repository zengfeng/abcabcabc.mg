using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	public class LegionExpeditionItem : MonoBehaviour 
	{
		public Text hpText;
		public RectTransform hpColor;
		public Image headImage;
		public float colorWidth = 470;
		void Start () 
		{
		}

		public void SetHP(float hp, float maxHP, float leftHP)
		{
			hpText.text = Mathf.FloorToInt(hp) + "/" + (int)maxHP + " (" + leftHP + ")";
			hpColor.sizeDelta = hpColor.sizeDelta.SetX(colorWidth * Mathf.Max(Mathf.Min((hp / maxHP), 1f), 0f));
		}

	}
}