using System;
using LuaInterface;

public class Games_ConstConfig_IDWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("War_Arm_OnceCount", GetWar_Arm_OnceCount),
		new LuaMethod("War_Arm_OnceTime", GetWar_Arm_OnceTime),
		new LuaMethod("War_CanseraMaxLevel", GetWar_CanseraMaxLevel),
		new LuaMethod("War_StageSizeMinX", GetWar_StageSizeMinX),
		new LuaMethod("War_StageSizeMaxX", GetWar_StageSizeMaxX),
		new LuaMethod("War_StageSizeMinZ", GetWar_StageSizeMinZ),
		new LuaMethod("War_StageSizeMaxZ", GetWar_StageSizeMaxZ),
		new LuaMethod("War_AI_FirstSendArmTime", GetWar_AI_FirstSendArmTime),
		new LuaMethod("War_AI_SendArmTime", GetWar_AI_SendArmTime),
		new LuaMethod("War_AI_UplevelTime", GetWar_AI_UplevelTime),
		new LuaMethod("War_AI_SendArmMinNum", GetWar_AI_SendArmMinNum),
		new LuaMethod("War_PCOperater", GetWar_PCOperater),
		new LuaMethod("War_MageAdd_CD", GetWar_MageAdd_CD),
		new LuaMethod("War_MageAdd_Behit", GetWar_MageAdd_Behit),
		new LuaMethod("War_MageAdd_Atk", GetWar_MageAdd_Atk),
		new LuaMethod("War_MageAdd_Beoccupy", GetWar_MageAdd_Beoccupy),
		new LuaMethod("War_Time_Max", GetWar_Time_Max),
		new LuaMethod("War_DV_Team_KillHero_Ratio", GetWar_DV_Team_KillHero_Ratio),
		new LuaMethod("War_DV_Team_MaxMage_Default", GetWar_DV_Team_MaxMage_Default),
		new LuaMethod("War_DV_Team_MaxMage_Ratio", GetWar_DV_Team_MaxMage_Ratio),
		new LuaMethod("War_DV_Team_Mage_Default", GetWar_DV_Team_Mage_Default),
		new LuaMethod("War_DV_Team_Mage_Ratio", GetWar_DV_Team_Mage_Ratio),
		new LuaMethod("War_DV_Casern_ProduceSpeed_DefaultMin", GetWar_DV_Casern_ProduceSpeed_DefaultMin),
		new LuaMethod("War_DV_Casern_ProduceSpeed_Ratio", GetWar_DV_Casern_ProduceSpeed_Ratio),
		new LuaMethod("War_DV_Casern_Def_Ratio", GetWar_DV_Casern_Def_Ratio),
		new LuaMethod("War_DV_Casern_Hp_RatioA", GetWar_DV_Casern_Hp_RatioA),
		new LuaMethod("War_DV_Casern_Hp_RatioB", GetWar_DV_Casern_Hp_RatioB),
		new LuaMethod("War_DV_Casern_Hp_RatioC", GetWar_DV_Casern_Hp_RatioC),
		new LuaMethod("War_DV_Casern_Hp_RatioD", GetWar_DV_Casern_Hp_RatioD),
		new LuaMethod("War_DV_Casern_MaxHp_DefaultMin", GetWar_DV_Casern_MaxHp_DefaultMin),
		new LuaMethod("War_DV_Casern_MaxHp_Ratio", GetWar_DV_Casern_MaxHp_Ratio),
		new LuaMethod("War_DV_Casern_SpeedAtk_DefaultMin", GetWar_DV_Casern_SpeedAtk_DefaultMin),
		new LuaMethod("War_DV_Casern_SpeedAtk_Ratio", GetWar_DV_Casern_SpeedAtk_Ratio),
		new LuaMethod("War_DV_Hero_Player_DefKillHero_Ratio", GetWar_DV_Hero_Player_DefKillHero_Ratio),
		new LuaMethod("War_DV_Solider_Atk_Ratio", GetWar_DV_Solider_Atk_Ratio),
		new LuaMethod("War_DV_Solider_InitMoveSpeed_Default", GetWar_DV_Solider_InitMoveSpeed_Default),
		new LuaMethod("War_DV_Solider_InitMoveSpeed_Ratio", GetWar_DV_Solider_InitMoveSpeed_Ratio),
		new LuaMethod("War_DV_DefCostRate_RatioA", GetWar_DV_DefCostRate_RatioA),
		new LuaMethod("War_DV_DefCostRate_RatioB", GetWar_DV_DefCostRate_RatioB),
		new LuaMethod("War_DV_DefCostRate_RatioC", GetWar_DV_DefCostRate_RatioC),
		new LuaMethod("War_DV_DefCostRate_RatioD", GetWar_DV_DefCostRate_RatioD),
		new LuaMethod("War_DV_KillHeroRate_Ratio", GetWar_DV_KillHeroRate_Ratio),
		new LuaMethod("War_DV_Mag_Recovery_Ratio", GetWar_DV_Mag_Recovery_Ratio),
		new LuaMethod("War_DV_BattleForce2Atk_Ratio", GetWar_DV_BattleForce2Atk_Ratio),
		new LuaMethod("War_DV_BattleForce2Defence_Ratio", GetWar_DV_BattleForce2Defence_Ratio),
		new LuaMethod("War_DV_SpeedAtk2MoveSpeed_Ratio", GetWar_DV_SpeedAtk2MoveSpeed_Ratio),
		new LuaMethod("War_BuildUplevel_RequireMinHp", GetWar_BuildUplevel_RequireMinHp),
		new LuaMethod("War_BuildUplevel_RequireMaxHp", GetWar_BuildUplevel_RequireMaxHp),
		new LuaMethod("War_BuildUplevel_RequireMaxTime", GetWar_BuildUplevel_RequireMaxTime),
		new LuaMethod("War_BuildUplevel_Hp2Time", GetWar_BuildUplevel_Hp2Time),
		new LuaMethod("War_SkillChangeBuildTime", GetWar_SkillChangeBuildTime),
		new LuaMethod("War_StageLegionTotalMaxHP_Ratio_Casern", GetWar_StageLegionTotalMaxHP_Ratio_Casern),
		new LuaMethod("War_StageLegionTotalMaxHP_Ratio_Turret", GetWar_StageLegionTotalMaxHP_Ratio_Turret),
		new LuaMethod("War_StageLegionTotalMaxHP_Ratio_Spot", GetWar_StageLegionTotalMaxHP_Ratio_Spot),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Games.ConstConfig.ID", typeof(Games.ConstConfig.ID), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_Arm_OnceCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_Arm_OnceCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_Arm_OnceTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_Arm_OnceTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_CanseraMaxLevel(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_CanseraMaxLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_StageSizeMinX(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_StageSizeMinX);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_StageSizeMaxX(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_StageSizeMaxX);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_StageSizeMinZ(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_StageSizeMinZ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_StageSizeMaxZ(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_StageSizeMaxZ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_AI_FirstSendArmTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_AI_FirstSendArmTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_AI_SendArmTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_AI_SendArmTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_AI_UplevelTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_AI_UplevelTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_AI_SendArmMinNum(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_AI_SendArmMinNum);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_PCOperater(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_PCOperater);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_MageAdd_CD(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_MageAdd_CD);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_MageAdd_Behit(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_MageAdd_Behit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_MageAdd_Atk(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_MageAdd_Atk);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_MageAdd_Beoccupy(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_MageAdd_Beoccupy);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_Time_Max(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_Time_Max);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Team_KillHero_Ratio(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Team_KillHero_Ratio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Team_MaxMage_Default(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Team_MaxMage_Default);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Team_MaxMage_Ratio(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Team_MaxMage_Ratio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Team_Mage_Default(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Team_Mage_Default);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Team_Mage_Ratio(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Team_Mage_Ratio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Casern_ProduceSpeed_DefaultMin(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Casern_ProduceSpeed_DefaultMin);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Casern_ProduceSpeed_Ratio(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Casern_ProduceSpeed_Ratio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Casern_Def_Ratio(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Casern_Def_Ratio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Casern_Hp_RatioA(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Casern_Hp_RatioA);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Casern_Hp_RatioB(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Casern_Hp_RatioB);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Casern_Hp_RatioC(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Casern_Hp_RatioC);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Casern_Hp_RatioD(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Casern_Hp_RatioD);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Casern_MaxHp_DefaultMin(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Casern_MaxHp_DefaultMin);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Casern_MaxHp_Ratio(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Casern_MaxHp_Ratio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Casern_SpeedAtk_DefaultMin(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Casern_SpeedAtk_DefaultMin);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Casern_SpeedAtk_Ratio(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Casern_SpeedAtk_Ratio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Hero_Player_DefKillHero_Ratio(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Hero_Player_DefKillHero_Ratio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Solider_Atk_Ratio(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Solider_Atk_Ratio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Solider_InitMoveSpeed_Default(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Solider_InitMoveSpeed_Default);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Solider_InitMoveSpeed_Ratio(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Solider_InitMoveSpeed_Ratio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_DefCostRate_RatioA(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_DefCostRate_RatioA);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_DefCostRate_RatioB(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_DefCostRate_RatioB);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_DefCostRate_RatioC(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_DefCostRate_RatioC);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_DefCostRate_RatioD(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_DefCostRate_RatioD);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_KillHeroRate_Ratio(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_KillHeroRate_Ratio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_Mag_Recovery_Ratio(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_Mag_Recovery_Ratio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_BattleForce2Atk_Ratio(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_BattleForce2Atk_Ratio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_BattleForce2Defence_Ratio(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_BattleForce2Defence_Ratio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_DV_SpeedAtk2MoveSpeed_Ratio(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_DV_SpeedAtk2MoveSpeed_Ratio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_BuildUplevel_RequireMinHp(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_BuildUplevel_RequireMinHp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_BuildUplevel_RequireMaxHp(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_BuildUplevel_RequireMaxHp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_BuildUplevel_RequireMaxTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_BuildUplevel_RequireMaxTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_BuildUplevel_Hp2Time(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_BuildUplevel_Hp2Time);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_SkillChangeBuildTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_SkillChangeBuildTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_StageLegionTotalMaxHP_Ratio_Casern(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_StageLegionTotalMaxHP_Ratio_Casern);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_StageLegionTotalMaxHP_Ratio_Turret(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_StageLegionTotalMaxHP_Ratio_Turret);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWar_StageLegionTotalMaxHP_Ratio_Spot(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.ConstConfig.ID.War_StageLegionTotalMaxHP_Ratio_Spot);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		Games.ConstConfig.ID o = (Games.ConstConfig.ID)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

