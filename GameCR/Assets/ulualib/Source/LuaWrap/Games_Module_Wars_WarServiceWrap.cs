using System;
using System.Collections.Generic;
using LuaInterface;

public class Games_Module_Wars_WarServiceWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("PropToProtoPropInfoList", PropToProtoPropInfoList),
			new LuaMethod("ProtoPropInfoToPropList", ProtoPropInfoToPropList),
			new LuaMethod("To__S_SyncSkill_0x822", To__S_SyncSkill_0x822),
			new LuaMethod("AddStoC", AddStoC),
			new LuaMethod("S_BattleStart_0x812", S_BattleStart_0x812),
			new LuaMethod("C_RecordSubGuideStep_0x119", C_RecordSubGuideStep_0x119),
			new LuaMethod("C_BattleLeave_0x813", C_BattleLeave_0x813),
			new LuaMethod("C_BattleEnd_0x830", C_BattleEnd_0x830),
			new LuaMethod("C_UploadBattleVideo_0x550", C_UploadBattleVideo_0x550),
			new LuaMethod("C_LoadProgress", C_LoadProgress),
			new LuaMethod("C_BattleLoad_0x811", C_BattleLoad_0x811),
			new LuaMethod("C_SyncSendArm_0x820", C_SyncSendArm_0x820),
			new LuaMethod("C_SyncSkill_0x822", C_SyncSkill_0x822),
			new LuaMethod("C_SyncUplevel_0x825", C_SyncUplevel_0x825),
			new LuaMethod("C_SyncTurret_0x826", C_SyncTurret_0x826),
			new LuaMethod("C_SyncBuild_0x827", C_SyncBuild_0x827),
			new LuaMethod("C_SyncHeroBackstage_0x828", C_SyncHeroBackstage_0x828),
			new LuaMethod("Clear", Clear),
			new LuaMethod("New", _CreateGames_Module_Wars_WarService),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("PROP_FLOAT_MULTIPLIER", get_PROP_FLOAT_MULTIPLIER, set_PROP_FLOAT_MULTIPLIER),
			new LuaField("backMenuId", get_backMenuId, set_backMenuId),
			new LuaField("stageId", get_stageId, set_stageId),
			new LuaField("roomId", get_roomId, set_roomId),
			new LuaField("roleId", get_roleId, set_roleId),
			new LuaField("ownLegionId", get_ownLegionId, set_ownLegionId),
			new LuaField("sendArmUid", get_sendArmUid, set_sendArmUid),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.WarService", typeof(Games.Module.Wars.WarService), regs, fields, typeof(CC.Runtime.Service));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Wars_WarService(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Wars.WarService obj = new Games.Module.Wars.WarService();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.WarService.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Wars.WarService);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_PROP_FLOAT_MULTIPLIER(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.WarService.PROP_FLOAT_MULTIPLIER);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_backMenuId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name backMenuId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index backMenuId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.backMenuId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stageId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stageId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stageId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.stageId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_roomId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roomId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roomId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.roomId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_roleId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roleId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roleId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.roleId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ownLegionId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ownLegionId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ownLegionId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.ownLegionId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sendArmUid(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sendArmUid");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sendArmUid on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.sendArmUid);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_PROP_FLOAT_MULTIPLIER(IntPtr L)
	{
		Games.Module.Wars.WarService.PROP_FLOAT_MULTIPLIER = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_backMenuId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name backMenuId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index backMenuId on a nil value");
			}
		}

		obj.backMenuId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stageId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stageId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stageId on a nil value");
			}
		}

		obj.stageId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_roomId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roomId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roomId on a nil value");
			}
		}

		obj.roomId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_roleId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roleId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roleId on a nil value");
			}
		}

		obj.roleId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ownLegionId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ownLegionId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ownLegionId on a nil value");
			}
		}

		obj.ownLegionId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sendArmUid(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sendArmUid");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sendArmUid on a nil value");
			}
		}

		obj.sendArmUid = (Dictionary<int,bool>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,bool>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PropToProtoPropInfoList(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Games.Module.Props.Prop[]), typeof(List<CC.Runtime.PB.ProtoPropInfo>)))
		{
			Games.Module.Props.Prop[] objs0 = LuaScriptMgr.GetArrayObject<Games.Module.Props.Prop>(L, 1);
			List<CC.Runtime.PB.ProtoPropInfo> arg1 = (List<CC.Runtime.PB.ProtoPropInfo>)LuaScriptMgr.GetLuaObject(L, 2);
			Games.Module.Wars.WarService.PropToProtoPropInfoList(objs0,arg1);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(float[]), typeof(List<CC.Runtime.PB.ProtoPropInfo>)))
		{
			float[] objs0 = LuaScriptMgr.GetArrayNumber<float>(L, 1);
			List<CC.Runtime.PB.ProtoPropInfo> arg1 = (List<CC.Runtime.PB.ProtoPropInfo>)LuaScriptMgr.GetLuaObject(L, 2);
			Games.Module.Wars.WarService.PropToProtoPropInfoList(objs0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.WarService.PropToProtoPropInfoList");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ProtoPropInfoToPropList(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		List<CC.Runtime.PB.ProtoPropInfo> arg0 = (List<CC.Runtime.PB.ProtoPropInfo>)LuaScriptMgr.GetNetObject(L, 1, typeof(List<CC.Runtime.PB.ProtoPropInfo>));
		Games.Module.Props.Prop[] o = Games.Module.Wars.WarService.ProtoPropInfoToPropList(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int To__S_SyncSkill_0x822(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.Runtime.PB.C_SyncSkill_0x822 arg0 = (CC.Runtime.PB.C_SyncSkill_0x822)LuaScriptMgr.GetNetObject(L, 1, typeof(CC.Runtime.PB.C_SyncSkill_0x822));
		CC.Runtime.PB.S_SyncSkill_0x822 o = Games.Module.Wars.WarService.To__S_SyncSkill_0x822(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddStoC(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarService");
		obj.AddStoC();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int S_BattleStart_0x812(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarService");
		CC.Runtime.PB.S_BattleStart_0x812 arg0 = (CC.Runtime.PB.S_BattleStart_0x812)LuaScriptMgr.GetNetObject(L, 2, typeof(CC.Runtime.PB.S_BattleStart_0x812));
		obj.S_BattleStart_0x812(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int C_RecordSubGuideStep_0x119(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarService");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.C_RecordSubGuideStep_0x119(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int C_BattleLeave_0x813(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarService");
		obj.C_BattleLeave_0x813();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int C_BattleEnd_0x830(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarService");
		List<CC.Runtime.PB.ProtoRoleFightResult> arg0 = (List<CC.Runtime.PB.ProtoRoleFightResult>)LuaScriptMgr.GetNetObject(L, 2, typeof(List<CC.Runtime.PB.ProtoRoleFightResult>));
		obj.C_BattleEnd_0x830(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int C_UploadBattleVideo_0x550(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarService");
		CC.Runtime.PB.ProtoBattleVideoInfo arg0 = (CC.Runtime.PB.ProtoBattleVideoInfo)LuaScriptMgr.GetNetObject(L, 2, typeof(CC.Runtime.PB.ProtoBattleVideoInfo));
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
		obj.C_UploadBattleVideo_0x550(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int C_LoadProgress(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarService");
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		obj.C_LoadProgress(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int C_BattleLoad_0x811(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarService");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.C_BattleLoad_0x811(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int C_SyncSendArm_0x820(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarService");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
		int arg3 = (int)LuaScriptMgr.GetNumber(L, 5);
		obj.C_SyncSendArm_0x820(arg0,arg1,arg2,arg3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int C_SyncSkill_0x822(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarService");
		CC.Runtime.PB.C_SyncSkill_0x822 arg0 = (CC.Runtime.PB.C_SyncSkill_0x822)LuaScriptMgr.GetNetObject(L, 2, typeof(CC.Runtime.PB.C_SyncSkill_0x822));
		obj.C_SyncSkill_0x822(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int C_SyncUplevel_0x825(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarService");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		obj.C_SyncUplevel_0x825(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int C_SyncTurret_0x826(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarService");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.C_SyncTurret_0x826(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int C_SyncBuild_0x827(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarService");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.C_SyncBuild_0x827(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int C_SyncHeroBackstage_0x828(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarService");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.C_SyncHeroBackstage_0x828(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clear(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.WarService obj = (Games.Module.Wars.WarService)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarService");
		obj.Clear();
		return 0;
	}
}

