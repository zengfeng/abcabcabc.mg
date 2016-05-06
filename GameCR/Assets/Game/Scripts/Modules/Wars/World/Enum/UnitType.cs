using UnityEngine;
using System.Collections;



namespace Games.Module.Wars
{
	[HelpAttribute("单位类型")]
	public enum UnitType
	{
		[HelpAttribute("玩家")]
		Player,
		
		[HelpAttribute("建筑")]
		Build,
		
		[HelpAttribute("士兵")]
		Solider,
		
		[HelpAttribute("英雄")]
		Hero,
		
		[HelpAttribute("墙")]
		Wall,
		
		[HelpAttribute("组")]
		Group
	}

}