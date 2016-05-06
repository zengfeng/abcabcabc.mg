using UnityEngine;
using System.Collections;



namespace Games.Module.Wars
{
	/** 建筑类型 */
	public enum BuildType
	{
		[HelpAttribute("不是建筑")]
		None,

		[HelpAttribute("兵营")]
		Casern = 1,
		
		[HelpAttribute("箭塔")]
		Turret,
		
		[HelpAttribute("据点")]
		Spot
	}
}