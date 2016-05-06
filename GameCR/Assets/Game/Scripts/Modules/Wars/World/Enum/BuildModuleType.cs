using UnityEngine;
using System.Collections;



namespace Games.Module.Wars
{
	/** 建筑类型 */
	public enum BuildModuleType
	{
		[HelpAttribute("布置盗")]
		None,

		[HelpAttribute("生产")]
		Produce = 1,
		
		[HelpAttribute("箭塔")]
		Turret,
		
		[HelpAttribute("据点")]
		Spot,

		[HelpAttribute("升级")]
		Uplevel,
	}
}