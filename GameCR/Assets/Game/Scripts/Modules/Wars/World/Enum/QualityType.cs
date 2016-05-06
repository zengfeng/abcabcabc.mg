using UnityEngine;
using System.Collections;
using ProtoBuf;

namespace Games.Module.Wars
{
	/** 品质类型 */
	[ProtoContract(Name=@"QualityType")]
	public enum QualityType 
	{
		/** 未知 */
		[ProtoEnum(Name=@"None", Value=0)]
		None,

		/** 白 */
		[ProtoEnum(Name=@"White", Value=1)]
		White,
		/** 蓝 */
		[ProtoEnum(Name=@"Blue", Value=2)]
		Blue,
		/** 紫 */
		[ProtoEnum(Name=@"Purple", Value=3)]
		Purple
	}
}