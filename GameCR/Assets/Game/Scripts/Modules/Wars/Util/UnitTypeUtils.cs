using UnityEngine;
using System.Collections;

namespace Games.Module.Wars
{

	public static class UnitTypeUtils
	{
        public static void Test()
        {
            
            int unitType = 0;
            unitType = unitType.USolider(true);
            unitType = unitType.UBuild(true);
            unitType = unitType.USolider(false);
        }

		
		public static bool UValue(this int unitType, UnitType val)
		{
			return (unitType & (1 << ((int)val))) != 0;
		}



		/*----------Player--------------*/
		public static bool UPlayer(this int unitType)
		{
			return (unitType & (1 << ((int)UnitType.Player))) != 0;
		}
		
		
		public static int UPlayer(this int unitType, bool value)
		{
			if(value)
			{
				unitType |= (1 << ((int)UnitType.Player));
			}
			else if(UPlayer(unitType))
			{
				unitType ^= (1 << ((int)UnitType.Player));
			}
			return unitType;
		}

		/*----------Build--------------*/
		public static bool UBuild(this int unitType)
		{
			return (unitType & (1 << ((int)UnitType.Build))) != 0;
		}
		
		
		public static int UBuild(this int unitType, bool value)
		{
			if(value)
			{
				unitType |= (1 << ((int)UnitType.Build));
			}
			else if(UBuild(unitType))
			{
				unitType ^= (1 << ((int)UnitType.Build));
			}
			return unitType;
		}
		
		/*----------Solider--------------*/
		public static bool USolider(this int unitType)
		{
			return (unitType & (1 << ((int)UnitType.Solider))) != 0;
		}
		
		
		public static int USolider(this int unitType, bool value)
		{
			if(value)
			{
				unitType |= (1 << ((int)UnitType.Solider));
			}
			else if(USolider(unitType))
			{
				unitType ^= (1 << ((int)UnitType.Solider));
			}
			return unitType;
		}
		
		/*----------Hero--------------*/
		public static bool UHero(this int unitType)
		{
			return (unitType & (1 << ((int)UnitType.Hero))) != 0;
		}
		
		
		public static int UHero(this int unitType, bool value)
		{
			if(value)
			{
				unitType |= (1 << ((int)UnitType.Hero));
			}
			else if(UHero(unitType))
			{
				unitType ^= (1 << ((int)UnitType.Hero));
			}
			return unitType;
		}

	}
}
