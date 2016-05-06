using UnityEngine;
using System.Collections;
using ProtoBuf;

namespace Games.Module.Wars
{
	/** 战局类型 */
	[ProtoContract(Name=@"OverType")]
	public enum OverType 
	{
		/** 失败 */
		[ProtoEnum(Name=@"Lose", Value=0)]
		Lose,
		/** 平局 */
		[ProtoEnum(Name=@"Draw", Value=1)]
		Draw,
		/** 胜利 */
		[ProtoEnum(Name=@"Win", Value=2)]
		Win
	}
}