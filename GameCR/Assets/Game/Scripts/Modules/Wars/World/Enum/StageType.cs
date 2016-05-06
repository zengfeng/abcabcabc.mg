using UnityEngine;
using System.Collections;



namespace Games.Module.Wars
{
	/**关卡类型*/
	public enum StageType
	{
		[HelpAttribute("主线", "副本--主线")]
		Dungeon = 1,

		[HelpAttribute("精英", "副本--精英")]
		Dungeon_Hard = 2,

		[HelpAttribute("活动")]
		Treasure = 3,
		
		[HelpAttribute("竞技场")]
		Arena = 4,
		
		[HelpAttribute("远征")]
		Expedition = 5
	}
}