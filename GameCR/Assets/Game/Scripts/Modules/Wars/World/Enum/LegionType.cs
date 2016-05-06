using UnityEngine;
using System.Collections;



namespace Games.Module.Wars
{
	
	/// <summary>
	/// <c>LegionType</c> 势力类型
	/// </summary>
	public enum LegionType 
	{
		/** 野外 */
		[HelpAttribute("野外")]
		Neutral = 0,


		/** 玩家 */
		[HelpAttribute("玩家")]
		Player = 1,


		/** 电脑 */
		[HelpAttribute("电脑")]
		Computer = 2,
	}
}