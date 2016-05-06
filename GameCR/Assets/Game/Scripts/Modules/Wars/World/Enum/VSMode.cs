using UnityEngine;
using System.Collections;
using ProtoBuf;


namespace Games.Module.Wars
{
	[HelpAttribute("战斗模式")]
	[ProtoContract(Name=@"VSMode")]
	public enum VSMode
	{
		[HelpAttribute("副本模式")]
		[ProtoEnum(Name=@"Dungeon", Value=0)]
		Dungeon,

		[HelpAttribute("引导模式")]
		[ProtoEnum(Name=@"Train", Value=1)]
		Train,
		
		[HelpAttribute("对战模式")]
		[ProtoEnum(Name=@"PVP", Value=2)]
		PVP,
		
		[HelpAttribute("异步打玩家")]
		[ProtoEnum(Name=@"PVE", Value=3)]
		PVE,
		
		[HelpAttribute("异步打玩家--远征")]
		[ProtoEnum(Name=@"PVE_Expedition", Value=4)]
		PVE_Expedition
	}
}