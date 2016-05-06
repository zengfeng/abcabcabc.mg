using UnityEngine;
using System.Collections;


namespace Games.Module.Wars
{

	public class WarUtils  
	{
		public static string GetUnitTypeName(UnitType unitType)
		{
			switch(unitType)
			{
			case UnitType.Player:
				return "玩家";
				break;
			case UnitType.Build:
				return "建筑";
				break;
			case UnitType.Solider:
				return "士兵";
				break;
			case UnitType.Hero:
				return "英雄";
				break;
			case UnitType.Wall:
				return "墙";
				break;
			case UnitType.Group:
				return "组";
				break;
			default:
				return "单位";
				break;
			}
		}

		
		public static string GetBuildTypeName (BuildType buildType)
		{


			switch (buildType) {
			case BuildType.Casern:
				return "兵营";
				break;
			case BuildType.Turret:
				return "箭塔";
				break;
			case BuildType.Spot:
				return "据点";
				break;
			default:
				return "建筑";
				break;
			}
		}
	}

}