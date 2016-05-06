using System;
using LuaInterface;

public class CC_Runtime_PB_ProtoBattleVideoRoleInfoWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateCC_Runtime_PB_ProtoBattleVideoRoleInfo),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("role_info", get_role_info, set_role_info),
			new LuaField("league_info", get_league_info, set_league_info),
			new LuaField("battle_info", get_battle_info, set_battle_info),
			new LuaField("end_type", get_end_type, set_end_type),
			new LuaField("change_prize", get_change_prize, set_change_prize),
			new LuaField("final_house", get_final_house, set_final_house),
			new LuaField("final_star", get_final_star, set_final_star),
			new LuaField("rank", get_rank, set_rank),
			new LuaField("rankSpecified", get_rankSpecified, set_rankSpecified),
		};

		LuaScriptMgr.RegisterLib(L, "CC.Runtime.PB.ProtoBattleVideoRoleInfo", typeof(CC.Runtime.PB.ProtoBattleVideoRoleInfo), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCC_Runtime_PB_ProtoBattleVideoRoleInfo(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = new CC.Runtime.PB.ProtoBattleVideoRoleInfo();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.Runtime.PB.ProtoBattleVideoRoleInfo.New");
		}

		return 0;
	}

	static Type classType = typeof(CC.Runtime.PB.ProtoBattleVideoRoleInfo);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_role_info(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = (CC.Runtime.PB.ProtoBattleVideoRoleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name role_info");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index role_info on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.role_info);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_league_info(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = (CC.Runtime.PB.ProtoBattleVideoRoleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name league_info");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index league_info on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.league_info);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_battle_info(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = (CC.Runtime.PB.ProtoBattleVideoRoleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name battle_info");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index battle_info on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.battle_info);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_end_type(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = (CC.Runtime.PB.ProtoBattleVideoRoleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name end_type");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index end_type on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.end_type);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_change_prize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = (CC.Runtime.PB.ProtoBattleVideoRoleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name change_prize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index change_prize on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.change_prize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_final_house(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = (CC.Runtime.PB.ProtoBattleVideoRoleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name final_house");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index final_house on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.final_house);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_final_star(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = (CC.Runtime.PB.ProtoBattleVideoRoleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name final_star");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index final_star on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.final_star);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rank(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = (CC.Runtime.PB.ProtoBattleVideoRoleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rank");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rank on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.rank);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rankSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = (CC.Runtime.PB.ProtoBattleVideoRoleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rankSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rankSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.rankSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_role_info(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = (CC.Runtime.PB.ProtoBattleVideoRoleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name role_info");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index role_info on a nil value");
			}
		}

		obj.role_info = (CC.Runtime.PB.ProtoRoleBaseInfo)LuaScriptMgr.GetNetObject(L, 3, typeof(CC.Runtime.PB.ProtoRoleBaseInfo));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_league_info(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = (CC.Runtime.PB.ProtoBattleVideoRoleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name league_info");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index league_info on a nil value");
			}
		}

		obj.league_info = (CC.Runtime.PB.ProtoLeagueInfo)LuaScriptMgr.GetNetObject(L, 3, typeof(CC.Runtime.PB.ProtoLeagueInfo));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_battle_info(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = (CC.Runtime.PB.ProtoBattleVideoRoleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name battle_info");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index battle_info on a nil value");
			}
		}

		obj.battle_info = (CC.Runtime.PB.ProtoRoleBattleInfo)LuaScriptMgr.GetNetObject(L, 3, typeof(CC.Runtime.PB.ProtoRoleBattleInfo));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_end_type(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = (CC.Runtime.PB.ProtoBattleVideoRoleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name end_type");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index end_type on a nil value");
			}
		}

		obj.end_type = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_change_prize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = (CC.Runtime.PB.ProtoBattleVideoRoleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name change_prize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index change_prize on a nil value");
			}
		}

		obj.change_prize = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_final_house(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = (CC.Runtime.PB.ProtoBattleVideoRoleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name final_house");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index final_house on a nil value");
			}
		}

		obj.final_house = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_final_star(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = (CC.Runtime.PB.ProtoBattleVideoRoleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name final_star");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index final_star on a nil value");
			}
		}

		obj.final_star = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rank(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = (CC.Runtime.PB.ProtoBattleVideoRoleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rank");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rank on a nil value");
			}
		}

		obj.rank = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rankSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoRoleInfo obj = (CC.Runtime.PB.ProtoBattleVideoRoleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rankSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rankSpecified on a nil value");
			}
		}

		obj.rankSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}
}

