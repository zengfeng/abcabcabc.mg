using UnityEngine;
using System.Collections;

namespace Games.Module.Wars
{
	/** 胜利条件类型 */
	public enum WinType 
	{
		[HelpAttribute("没有")]
		T0_None 	= 0,

		/** 占领指定建筑，持续{0}时间 */
		[HelpAttribute("占领")]
		T1_Occupy 	= 1,
		/** 关卡规定时间内，坚守时间越长，将领越丰厚 */
		
		[HelpAttribute("坚守")]
		T2_Defend 	= 2,
		/** 关卡规定时间内，敌军死亡兵力越多，奖励越丰厚 */

		
		[HelpAttribute("杀敌")]
		T3_Attack 	= 3,
	}
}