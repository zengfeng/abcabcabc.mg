using UnityEngine;
using System.Collections;
using ProtoBuf;

namespace Games.Module.Wars
{
	[ProtoContract(Name=@"WRActionType")]
	public enum WRActionType 
	{
		//发兵
		[ProtoEnum(Name=@"SendArm", Value=0)]
		SendArm,

		//升级
		[ProtoEnum(Name=@"Uplevel", Value=1)]
		Uplevel,

		//占领城池
		[ProtoEnum(Name=@"BuildLegionChange", Value=2)]
		BuildLegionChange,

		//英雄下阵
		[ProtoEnum(Name=@"HeroBackstage", Value=3)]
		HeroBackstage,

		//箭塔攻击
		[ProtoEnum(Name=@"TurretAtk", Value=4)]
		TurretAtk,

		//生产技能
		[ProtoEnum(Name=@"ProductionSkill", Value=5)]
		SetProductionSkill,

		//使用进能
		[ProtoEnum(Name=@"Skill", Value=6)]
		Skill,

		//属性
		[ProtoEnum(Name=@"Prop", Value=7)]
		Prop,

		//游戏结束
		[ProtoEnum(Name=@"GameOver", Value=8)]
		GameOver,

	}
}
