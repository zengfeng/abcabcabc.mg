using UnityEngine;
using System.Collections;


namespace Games.Module.Wars
{
	public enum DamageFromType {
		[HelpAttribute("技能")]
		Skill,

		[HelpAttribute("箭塔")]
		Turret,

		
		[HelpAttribute("士兵攻击")]
		Solider,
	}
}