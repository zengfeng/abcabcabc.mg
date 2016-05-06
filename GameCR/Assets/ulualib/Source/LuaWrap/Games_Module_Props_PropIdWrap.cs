using System;
using System.Collections.Generic;
using LuaInterface;

public class Games_Module_Props_PropIdWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetPropListA", GetPropListA),
			new LuaMethod("GetPropListB", GetPropListB),
			new LuaMethod("GetPropListC", GetPropListC),
			new LuaMethod("GetPropListState", GetPropListState),
			new LuaMethod("New", _CreateGames_Module_Props_PropId),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("MAX", get_MAX, null),
			new LuaField("HpAdd", get_HpAdd, null),
			new LuaField("HpPer", get_HpPer, null),
			new LuaField("Hp", get_Hp, null),
			new LuaField("MaxHpAdd", get_MaxHpAdd, null),
			new LuaField("MaxHpPer", get_MaxHpPer, null),
			new LuaField("MaxHp", get_MaxHp, null),
			new LuaField("UnitNum", get_UnitNum, null),
			new LuaField("MaxUnitNum", get_MaxUnitNum, null),
			new LuaField("Hp2UnitRate", get_Hp2UnitRate, null),
			new LuaField("AtkAdd", get_AtkAdd, null),
			new LuaField("AtkPer", get_AtkPer, null),
			new LuaField("Atk", get_Atk, null),
			new LuaField("MoveSpeedAdd", get_MoveSpeedAdd, null),
			new LuaField("MoveSpeedPer", get_MoveSpeedPer, null),
			new LuaField("MoveSpeed", get_MoveSpeed, null),
			new LuaField("ProduceSpeedAdd", get_ProduceSpeedAdd, null),
			new LuaField("ProduceSpeedPer", get_ProduceSpeedPer, null),
			new LuaField("ProduceSpeed", get_ProduceSpeed, null),
			new LuaField("MagAdd", get_MagAdd, null),
			new LuaField("MagPer", get_MagPer, null),
			new LuaField("Mag", get_Mag, null),
			new LuaField("DefAdd", get_DefAdd, null),
			new LuaField("DefPer", get_DefPer, null),
			new LuaField("Def", get_Def, null),
			new LuaField("AttackDamageAdd", get_AttackDamageAdd, null),
			new LuaField("AttackDamagePer", get_AttackDamagePer, null),
			new LuaField("AttackDamage", get_AttackDamage, null),
			new LuaField("AttackRadiusAdd", get_AttackRadiusAdd, null),
			new LuaField("AttackRadiusPer", get_AttackRadiusPer, null),
			new LuaField("AttackRadius", get_AttackRadius, null),
			new LuaField("AttackSpeedAdd", get_AttackSpeedAdd, null),
			new LuaField("AttackSpeedPer", get_AttackSpeedPer, null),
			new LuaField("AttackSpeed", get_AttackSpeed, null),
			new LuaField("KillHeroAdd", get_KillHeroAdd, null),
			new LuaField("KillHeroPer", get_KillHeroPer, null),
			new LuaField("KillHero", get_KillHero, null),
			new LuaField("DefKillHeroAdd", get_DefKillHeroAdd, null),
			new LuaField("DefKillHeroPer", get_DefKillHeroPer, null),
			new LuaField("DefKillHero", get_DefKillHero, null),
			new LuaField("KillHeroRateAdd", get_KillHeroRateAdd, null),
			new LuaField("KillHeroRatePer", get_KillHeroRatePer, null),
			new LuaField("KillHeroRate", get_KillHeroRate, null),
			new LuaField("MaxMagAdd", get_MaxMagAdd, null),
			new LuaField("MaxMagPer", get_MaxMagPer, null),
			new LuaField("MaxMag", get_MaxMag, null),
			new LuaField("MageSpeedAdd", get_MageSpeedAdd, null),
			new LuaField("MageSpeedPer", get_MageSpeedPer, null),
			new LuaField("MageSpeed", get_MageSpeed, null),
			new LuaField("BattleForceAdd", get_BattleForceAdd, null),
			new LuaField("BattleForcePer", get_BattleForcePer, null),
			new LuaField("BattleForce", get_BattleForce, null),
			new LuaField("SpeedAtkAdd", get_SpeedAtkAdd, null),
			new LuaField("SpeedAtkPer", get_SpeedAtkPer, null),
			new LuaField("SpeedAtk", get_SpeedAtk, null),
			new LuaField("InitHpPer", get_InitHpPer, null),
			new LuaField("InitMaxHpPer", get_InitMaxHpPer, null),
			new LuaField("InitAtkPer", get_InitAtkPer, null),
			new LuaField("InitMoveSpeedPer", get_InitMoveSpeedPer, null),
			new LuaField("InitProduceSpeedPer", get_InitProduceSpeedPer, null),
			new LuaField("InitMagPer", get_InitMagPer, null),
			new LuaField("InitDefPer", get_InitDefPer, null),
			new LuaField("InitAttackDamagePer", get_InitAttackDamagePer, null),
			new LuaField("InitAttackRadiusPer", get_InitAttackRadiusPer, null),
			new LuaField("InitAttackSpeedPer", get_InitAttackSpeedPer, null),
			new LuaField("InitKillHeroPer", get_InitKillHeroPer, null),
			new LuaField("InitDefKillHeroPer", get_InitDefKillHeroPer, null),
			new LuaField("InitKillHeroRatePer", get_InitKillHeroRatePer, null),
			new LuaField("InitMaxMagePer", get_InitMaxMagePer, null),
			new LuaField("InitMageSpeedPer", get_InitMageSpeedPer, null),
			new LuaField("InitBattleForcePer", get_InitBattleForcePer, null),
			new LuaField("InitSpeedAtkPer", get_InitSpeedAtkPer, null),
			new LuaField("InitHp", get_InitHp, null),
			new LuaField("InitMaxHp", get_InitMaxHp, null),
			new LuaField("InitAtk", get_InitAtk, null),
			new LuaField("InitMoveSpeed", get_InitMoveSpeed, null),
			new LuaField("InitProduceSpeed", get_InitProduceSpeed, null),
			new LuaField("InitMag", get_InitMag, null),
			new LuaField("InitDef", get_InitDef, null),
			new LuaField("InitAttackDamage", get_InitAttackDamage, null),
			new LuaField("InitAttackRadius", get_InitAttackRadius, null),
			new LuaField("InitAttackSpeed", get_InitAttackSpeed, null),
			new LuaField("InitKillHero", get_InitKillHero, null),
			new LuaField("InitDefKillHero", get_InitDefKillHero, null),
			new LuaField("InitKillHeroRate", get_InitKillHeroRate, null),
			new LuaField("InitMaxMage", get_InitMaxMage, null),
			new LuaField("InitMageSpeed", get_InitMageSpeed, null),
			new LuaField("InitBattleForce", get_InitBattleForce, null),
			new LuaField("InitSpeedAtk", get_InitSpeedAtk, null),
			new LuaField("StateFreezedMoveSpeed", get_StateFreezedMoveSpeed, null),
			new LuaField("StateFreezedSendArm", get_StateFreezedSendArm, null),
			new LuaField("StateFreezedProduce", get_StateFreezedProduce, null),
			new LuaField("StateSilence", get_StateSilence, null),
			new LuaField("StateInvincible", get_StateInvincible, null),
			new LuaField("StateShowHP", get_StateShowHP, null),
			new LuaField("StateBurn", get_StateBurn, null),
			new LuaField("StateMoveSpeedUp", get_StateMoveSpeedUp, null),
			new LuaField("StateAtkUp", get_StateAtkUp, null),
			new LuaField("StateProduceSpeedUp", get_StateProduceSpeedUp, null),
			new LuaField("LegionID", get_LegionID, null),
			new LuaField("BattlePower", get_BattlePower, null),
			new LuaField("HpGroup", get_HpGroup, set_HpGroup),
			new LuaField("MaxHpGroup", get_MaxHpGroup, set_MaxHpGroup),
			new LuaField("AtkGroup", get_AtkGroup, set_AtkGroup),
			new LuaField("MoveSpeedGroup", get_MoveSpeedGroup, set_MoveSpeedGroup),
			new LuaField("ProduceSpeedGroup", get_ProduceSpeedGroup, set_ProduceSpeedGroup),
			new LuaField("MagGroup", get_MagGroup, set_MagGroup),
			new LuaField("DefGroup", get_DefGroup, set_DefGroup),
			new LuaField("AttackDamageGroup", get_AttackDamageGroup, set_AttackDamageGroup),
			new LuaField("AttackRadiusGroup", get_AttackRadiusGroup, set_AttackRadiusGroup),
			new LuaField("AttackSpeedGroup", get_AttackSpeedGroup, set_AttackSpeedGroup),
			new LuaField("KillHeroGroup", get_KillHeroGroup, set_KillHeroGroup),
			new LuaField("DefKillHeroGroup", get_DefKillHeroGroup, set_DefKillHeroGroup),
			new LuaField("KillHeroRateGroup", get_KillHeroRateGroup, set_KillHeroRateGroup),
			new LuaField("MaxMageGroup", get_MaxMageGroup, set_MaxMageGroup),
			new LuaField("MageSpeedGroup", get_MageSpeedGroup, set_MageSpeedGroup),
			new LuaField("BattleForceGroup", get_BattleForceGroup, set_BattleForceGroup),
			new LuaField("SpeedAtkGroup", get_SpeedAtkGroup, set_SpeedAtkGroup),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Props.PropId", typeof(Games.Module.Props.PropId), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Props_PropId(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Props.PropId obj = new Games.Module.Props.PropId();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Props.PropId.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Props.PropId);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MAX(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.MAX);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_HpAdd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.HpAdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_HpPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.HpPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Hp(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.Hp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MaxHpAdd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.MaxHpAdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MaxHpPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.MaxHpPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MaxHp(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.MaxHp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UnitNum(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.UnitNum);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MaxUnitNum(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.MaxUnitNum);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Hp2UnitRate(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.Hp2UnitRate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AtkAdd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.AtkAdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AtkPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.AtkPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Atk(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.Atk);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MoveSpeedAdd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.MoveSpeedAdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MoveSpeedPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.MoveSpeedPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MoveSpeed(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.MoveSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ProduceSpeedAdd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.ProduceSpeedAdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ProduceSpeedPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.ProduceSpeedPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ProduceSpeed(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.ProduceSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MagAdd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.MagAdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MagPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.MagPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Mag(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.Mag);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DefAdd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.DefAdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DefPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.DefPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Def(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.Def);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AttackDamageAdd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.AttackDamageAdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AttackDamagePer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.AttackDamagePer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AttackDamage(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.AttackDamage);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AttackRadiusAdd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.AttackRadiusAdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AttackRadiusPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.AttackRadiusPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AttackRadius(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.AttackRadius);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AttackSpeedAdd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.AttackSpeedAdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AttackSpeedPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.AttackSpeedPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AttackSpeed(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.AttackSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_KillHeroAdd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.KillHeroAdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_KillHeroPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.KillHeroPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_KillHero(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.KillHero);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DefKillHeroAdd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.DefKillHeroAdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DefKillHeroPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.DefKillHeroPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DefKillHero(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.DefKillHero);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_KillHeroRateAdd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.KillHeroRateAdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_KillHeroRatePer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.KillHeroRatePer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_KillHeroRate(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.KillHeroRate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MaxMagAdd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.MaxMagAdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MaxMagPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.MaxMagPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MaxMag(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.MaxMag);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MageSpeedAdd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.MageSpeedAdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MageSpeedPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.MageSpeedPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MageSpeed(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.MageSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BattleForceAdd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.BattleForceAdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BattleForcePer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.BattleForcePer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BattleForce(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.BattleForce);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SpeedAtkAdd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.SpeedAtkAdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SpeedAtkPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.SpeedAtkPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SpeedAtk(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.SpeedAtk);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitHpPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitHpPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitMaxHpPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitMaxHpPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitAtkPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitAtkPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitMoveSpeedPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitMoveSpeedPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitProduceSpeedPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitProduceSpeedPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitMagPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitMagPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitDefPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitDefPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitAttackDamagePer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitAttackDamagePer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitAttackRadiusPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitAttackRadiusPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitAttackSpeedPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitAttackSpeedPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitKillHeroPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitKillHeroPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitDefKillHeroPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitDefKillHeroPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitKillHeroRatePer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitKillHeroRatePer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitMaxMagePer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitMaxMagePer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitMageSpeedPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitMageSpeedPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitBattleForcePer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitBattleForcePer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitSpeedAtkPer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitSpeedAtkPer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitHp(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitHp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitMaxHp(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitMaxHp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitAtk(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitAtk);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitMoveSpeed(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitMoveSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitProduceSpeed(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitProduceSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitMag(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitMag);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitDef(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitDef);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitAttackDamage(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitAttackDamage);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitAttackRadius(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitAttackRadius);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitAttackSpeed(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitAttackSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitKillHero(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitKillHero);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitDefKillHero(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitDefKillHero);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitKillHeroRate(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitKillHeroRate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitMaxMage(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitMaxMage);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitMageSpeed(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitMageSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitBattleForce(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitBattleForce);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitSpeedAtk(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.InitSpeedAtk);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_StateFreezedMoveSpeed(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.StateFreezedMoveSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_StateFreezedSendArm(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.StateFreezedSendArm);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_StateFreezedProduce(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.StateFreezedProduce);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_StateSilence(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.StateSilence);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_StateInvincible(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.StateInvincible);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_StateShowHP(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.StateShowHP);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_StateBurn(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.StateBurn);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_StateMoveSpeedUp(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.StateMoveSpeedUp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_StateAtkUp(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.StateAtkUp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_StateProduceSpeedUp(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.StateProduceSpeedUp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LegionID(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.LegionID);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BattlePower(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Props.PropId.BattlePower);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_HpGroup(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Props.PropId.HpGroup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MaxHpGroup(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Props.PropId.MaxHpGroup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AtkGroup(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Props.PropId.AtkGroup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MoveSpeedGroup(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Props.PropId.MoveSpeedGroup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ProduceSpeedGroup(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Props.PropId.ProduceSpeedGroup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MagGroup(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Props.PropId.MagGroup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DefGroup(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Props.PropId.DefGroup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AttackDamageGroup(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Props.PropId.AttackDamageGroup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AttackRadiusGroup(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Props.PropId.AttackRadiusGroup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AttackSpeedGroup(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Props.PropId.AttackSpeedGroup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_KillHeroGroup(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Props.PropId.KillHeroGroup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DefKillHeroGroup(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Props.PropId.DefKillHeroGroup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_KillHeroRateGroup(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Props.PropId.KillHeroRateGroup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MaxMageGroup(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Props.PropId.MaxMageGroup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MageSpeedGroup(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Props.PropId.MageSpeedGroup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BattleForceGroup(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Props.PropId.BattleForceGroup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SpeedAtkGroup(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Props.PropId.SpeedAtkGroup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_HpGroup(IntPtr L)
	{
		Games.Module.Props.PropId.HpGroup = (Games.Module.Props.PropIdGroup)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropIdGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_MaxHpGroup(IntPtr L)
	{
		Games.Module.Props.PropId.MaxHpGroup = (Games.Module.Props.PropIdGroup)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropIdGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AtkGroup(IntPtr L)
	{
		Games.Module.Props.PropId.AtkGroup = (Games.Module.Props.PropIdGroup)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropIdGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_MoveSpeedGroup(IntPtr L)
	{
		Games.Module.Props.PropId.MoveSpeedGroup = (Games.Module.Props.PropIdGroup)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropIdGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ProduceSpeedGroup(IntPtr L)
	{
		Games.Module.Props.PropId.ProduceSpeedGroup = (Games.Module.Props.PropIdGroup)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropIdGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_MagGroup(IntPtr L)
	{
		Games.Module.Props.PropId.MagGroup = (Games.Module.Props.PropIdGroup)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropIdGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_DefGroup(IntPtr L)
	{
		Games.Module.Props.PropId.DefGroup = (Games.Module.Props.PropIdGroup)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropIdGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AttackDamageGroup(IntPtr L)
	{
		Games.Module.Props.PropId.AttackDamageGroup = (Games.Module.Props.PropIdGroup)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropIdGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AttackRadiusGroup(IntPtr L)
	{
		Games.Module.Props.PropId.AttackRadiusGroup = (Games.Module.Props.PropIdGroup)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropIdGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AttackSpeedGroup(IntPtr L)
	{
		Games.Module.Props.PropId.AttackSpeedGroup = (Games.Module.Props.PropIdGroup)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropIdGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_KillHeroGroup(IntPtr L)
	{
		Games.Module.Props.PropId.KillHeroGroup = (Games.Module.Props.PropIdGroup)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropIdGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_DefKillHeroGroup(IntPtr L)
	{
		Games.Module.Props.PropId.DefKillHeroGroup = (Games.Module.Props.PropIdGroup)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropIdGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_KillHeroRateGroup(IntPtr L)
	{
		Games.Module.Props.PropId.KillHeroRateGroup = (Games.Module.Props.PropIdGroup)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropIdGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_MaxMageGroup(IntPtr L)
	{
		Games.Module.Props.PropId.MaxMageGroup = (Games.Module.Props.PropIdGroup)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropIdGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_MageSpeedGroup(IntPtr L)
	{
		Games.Module.Props.PropId.MageSpeedGroup = (Games.Module.Props.PropIdGroup)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropIdGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_BattleForceGroup(IntPtr L)
	{
		Games.Module.Props.PropId.BattleForceGroup = (Games.Module.Props.PropIdGroup)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropIdGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SpeedAtkGroup(IntPtr L)
	{
		Games.Module.Props.PropId.SpeedAtkGroup = (Games.Module.Props.PropIdGroup)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropIdGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPropListA(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		List<Games.Module.Props.PropIdGroup> o = Games.Module.Props.PropId.GetPropListA();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPropListB(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		List<Games.Module.Props.PropIdGroup> o = Games.Module.Props.PropId.GetPropListB();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPropListC(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		List<Games.Module.Props.PropIdGroup> o = Games.Module.Props.PropId.GetPropListC();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPropListState(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		List<int> o = Games.Module.Props.PropId.GetPropListState();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}
}

