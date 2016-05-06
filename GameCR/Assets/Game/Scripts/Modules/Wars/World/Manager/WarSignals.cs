using UnityEngine;
using System.Collections;
using CC.Runtime.signals;
using Games.Module.Wars;

namespace Games.Module.Wars
{
	/* arges(UnitData, preTeam, targetTeam) */
	public class WarBuildChangeLegion			: HSignal<UnitData, int, int>	{}
	/* arges(UnitData soliderUnitData, targetTeam) */
	public class WarSoliderArrivedEnemy     : HSignal<UnitData>				{}

	public class WarDarkScreenVisible				:HSignal<bool>					{}


}