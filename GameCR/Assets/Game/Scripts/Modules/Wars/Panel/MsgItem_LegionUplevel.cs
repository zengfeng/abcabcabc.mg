using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Games.Module.Wars
{
	public class MsgItem_LegionUplevel : MonoBehaviour 
	{
		public Text levelText;

		public void Set(int level)
		{
			levelText.text = level + "";
		}



	}
}