using UnityEngine;
using System.Collections;
using CC.Runtime;
using Games.Module.Props;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	[ConfigPath("Config/morale_solider_get",ConfigType.CSV)]
	public class LegionLevelSoliderExpConfig : IParseCsv, IKey<int>
	{
		public int key;
		public float exp;

//		1=进攻时，杀死对方士兵数，获得经验
//		2=防守时，杀死对方士兵数，获得经验
//		3=释放技能时，杀死对方士兵数，获得经验
//		4=占领非将城时，获得经验
// 		5=箭塔攻击

		public static float SoliderAtkExp = 50;
		public static float SoliderDefExp = 50;
		public static float SoliderSkillExp = 50;
		public static float BuildExp = 50;
		public static float SoliderTurretExp = 50;

		public void ParseCsv(string[] csv)
		{
			int i = 0;
			
			key 	=  csv.GetInt32(i ++ );
			exp		=  csv.GetSingle(i ++ );

			switch(key)
			{
			case 1:
				SoliderAtkExp = exp;
				break;
			case 2:
				SoliderDefExp = exp;
				break;
			case 3:
				SoliderSkillExp = exp;
				break;
			case 4:
				BuildExp = exp;
				break;
			case 5:
				SoliderTurretExp = exp;
				break;
			}
		}

		
		public int Key
		{
			get
			{
				return key;
			}
		}


	}
}