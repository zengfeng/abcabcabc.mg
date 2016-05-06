using UnityEngine;
using System.Collections;



namespace Games.Module.Wars
{
	/** 据点类型 */
	public enum SpotType
	{
		
		[HelpAttribute("攻击")]
		Atk = 0,

		[HelpAttribute("速度")]
		Speed,
		
		[HelpAttribute("产兵")]
		Produce,
	}
}