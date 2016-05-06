using UnityEngine;
using System.Collections;



namespace Games.Module.Wars
{
	[HelpAttribute("关系类型")]
	public enum RelationType
	{
		[HelpAttribute("所有")]
		All = -1,
		
		[HelpAttribute("未知")]
		None = 0,
		
		[HelpAttribute("仅自己")]
		Own,
		
		[HelpAttribute("仅队友")]
		Friendly,
		
		[HelpAttribute("仅敌人")]
		Enemy
	}
}