using UnityEngine;
using System.Collections;
using CC.Runtime;
using Games.Module.Props;
using CC.Runtime.Utils;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	[ConfigPath("Config/morale_hero_get",ConfigType.CSV)]
	public class LegionLevelHeroExpConfig : IParseCsv, IKey<int>
	{
		
		public static Dictionary<int, float> dict = new Dictionary<int, float>();
		public static float GetLevelExp(int level)
		{
			if(dict.ContainsKey(level)) return dict[level];
			return 0;
		}



		public int level;
		public float exp;


		public void ParseCsv(string[] csv)
		{
			int i = 0;
			
			level 	=  csv.GetInt32(i ++ );
			exp		=  csv.GetSingle(i ++ );

			dict.Add(level, exp);
		}

		
		public int Key
		{
			get
			{
				return level;
			}
		}


	}
}