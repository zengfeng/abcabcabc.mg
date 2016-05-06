using UnityEngine;
using System.Collections;

namespace Games.Module.Wars
{
	public class WarColorConfig : MonoBehaviour
	{
		public Color[] turretColors = new Color[]{Color.gray, Color.red, Color.blue, Color.green, Color.magenta,  Color.white};
		public Color[] unitHPColors = new Color[]{Color.gray, Color.red, Color.blue, Color.green, Color.magenta,  Color.white};
		public Color[] hunColors = new Color[]{Color.gray, Color.red, Color.blue, Color.green, Color.magenta,  Color.white};
		public Color[] hearHeadColors = new Color[]{Color.gray, Color.red, Color.blue, Color.green, Color.magenta,  Color.white};

		void Awake () 
		{
			WarColor.turretColor = turretColors;
			WarColor.unitHPColor = unitHPColors;
			WarColor.hunColor = hunColors;
			WarColor.heroHeadColor = hearHeadColors;

		}

	}

}