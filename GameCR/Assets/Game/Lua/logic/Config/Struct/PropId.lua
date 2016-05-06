PropId = class("PropId",
{
		--属性最多数量，用于创建属性列表
       MAX = 111,
		
		--兵力【血量】
       HpAdd = 1,
       HpPer = 2,
       Hp = 3,
		
		--兵力上限【血量上限】
		MaxHpAdd = 4,
		MaxHpPer = 5,
		MaxHp = 6,
		
		--人口【人口】
		UnitNum = 7,
		--人口上限【人口上限】
		MaxUnitNum = 8,
		
		--兵力转人口比例数值
		Hp2UnitRate = 9,

		
		--攻击
       AtkAdd = 10,
       AtkPer = 11,
       Atk = 12,
		
		--移动速度
		MoveSpeedAdd = 13,
		MoveSpeedPer = 14,
		MoveSpeed = 15,
		
		--生产速度
		ProduceSpeedAdd = 16,
		ProduceSpeedPer = 17,
		ProduceSpeed = 18,
		
		--怒气
		MagAdd = 19,
		MagPer = 20,
		Mag = 21,

		
		--防御
		DefAdd = 23,
		DefPer = 24,
		Def = 25,
		
		
		--普攻
		AttackDamageAdd = 26,
		AttackDamagePer = 27,
		AttackDamage = 28,
		
		
		--普攻范围
		AttackRadiusAdd = 29,
		AttackRadiusPer = 30,
		AttackRadius = 31,
		
		
		--普攻速度
		AttackSpeedAdd = 32,
		AttackSpeedPer = 33,
		AttackSpeed = 34,
		
		
		--斩将值
		KillHeroAdd = 35,
		KillHeroPer = 36,
		KillHero = 37,

		
		--防斩将值
		DefKillHeroAdd = 38,
		DefKillHeroPer = 39,
		DefKillHero = 40,

		
		
		--斩将率
		KillHeroRateAdd = 41,
		KillHeroRatePer = 42,
		KillHeroRate = 43,

		
		
		--怒气上限
		MaxMagAdd = 44,
		MaxMagPer = 45,
		MaxMag = 46,

		--怒气恢复速度
		MageSpeedAdd = 47,
		MageSpeedPer = 48,
		MageSpeed = 49,
		
		--战力
		BattleForceAdd = 50,
		BattleForcePer = 51,
		BattleForce = 52,
		
		--速攻
		SpeedAtkAdd = 53,
		SpeedAtkPer = 54,
		SpeedAtk = 55,



		
		--附加初始兵力
		InitHpPer = 60,
		--附加初始兵力上限
		InitMaxHpPer = 61,
		--附加初始攻击
		InitAtkPer = 62,
		--附加初始移动速度
		InitMoveSpeedPer = 63,
		--附加初始生产速度
		InitProduceSpeedPer = 64,
		--附加初始怒气
		InitMagPer = 65,
		--附加初始防御
		InitDefPer = 66,
		--附加初始普攻
		InitAttackDamagePer = 67,
		--附加初始普攻范围
		InitAttackRadiusPer = 68,
		--附加初始普攻速度
		InitAttackSpeedPer = 69,
		--附加初始必杀（斩将值）
		InitKillHeroPer = 70,
		--附加初始运气（防斩将值）
		InitDefKillHeroPer = 71,
		--附加初始斩将率
		InitKillHeroRatePer = 72,
		--附加初始怒气上限
		InitMaxMagePer = 73,
		--附加初始怒气恢复速度
		InitMageSpeedPer = 74,
		--附加初始战力
		InitBattleForcePer = 75,
		--附加初始速攻
		InitSpeedAtkPer = 76,



		--初始兵力
		InitHp = 80,
		--初始兵力上限
		InitMaxHp = 81,
		--初始攻击
		InitAtk = 82,
		--初始移动速度
		InitMoveSpeed = 83,
		--初始生产速度
		InitProduceSpeed = 84,
		--初始怒气
		InitMag = 85,
		--初始防御
		InitDef = 86,
		--初始普攻
		InitAttackDamage = 87,
		--初始普攻范围
		InitAttackRadius = 88,
		--初始普攻速度
		InitAttackSpeed = 89,
		--初始必杀（斩将值）
		InitKillHero = 90,
		--初始运气（防斩将值）
		InitDefKillHero = 91,
		--初始斩将率
		InitKillHeroRate = 92,
		--初始怒气上限
		InitMaxMage = 93,
		--初始怒气恢复速度
		InitMageSpeed = 94,
		--初始战力
		InitBattleForce = 95,
		--初始攻速
		InitSpeedAtk = 96,





			
		--状态--冰冻移动速度
		StateFreezedMoveSpeed = 100,
		--状态--冰冻发兵
		StateFreezedSendArm = 101,
		--状态--冰冻生产兵
		StateFreezedProduce = 102,
		--状态--沉默
		StateSilence = 103,
		--状态--无敌
		StateInvincible = 104,
		--状态--显示血量
		StateShowHP = 105,
		--状态--灼烧
		StateBurn = 106,


		
		--势力ID
		LegionID = 109,
		--战斗力
		BattlePower = 110
})