using System;
using LuaInterface;

public class CC_Runtime_PB_ProtoRoleBattleInfoWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateCC_Runtime_PB_ProtoRoleBattleInfo),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("battle_soldier", get_battle_soldier, set_battle_soldier),
			new LuaField("battle_soldierSpecified", get_battle_soldierSpecified, set_battle_soldierSpecified),
			new LuaField("battle_cards", get_battle_cards, null),
		};

		LuaScriptMgr.RegisterLib(L, "CC.Runtime.PB.ProtoRoleBattleInfo", typeof(CC.Runtime.PB.ProtoRoleBattleInfo), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCC_Runtime_PB_ProtoRoleBattleInfo(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			CC.Runtime.PB.ProtoRoleBattleInfo obj = new CC.Runtime.PB.ProtoRoleBattleInfo();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.Runtime.PB.ProtoRoleBattleInfo.New");
		}

		return 0;
	}

	static Type classType = typeof(CC.Runtime.PB.ProtoRoleBattleInfo);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_battle_soldier(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBattleInfo obj = (CC.Runtime.PB.ProtoRoleBattleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name battle_soldier");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index battle_soldier on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.battle_soldier);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_battle_soldierSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBattleInfo obj = (CC.Runtime.PB.ProtoRoleBattleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name battle_soldierSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index battle_soldierSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.battle_soldierSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_battle_cards(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBattleInfo obj = (CC.Runtime.PB.ProtoRoleBattleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name battle_cards");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index battle_cards on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.battle_cards);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_battle_soldier(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBattleInfo obj = (CC.Runtime.PB.ProtoRoleBattleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name battle_soldier");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index battle_soldier on a nil value");
			}
		}

		obj.battle_soldier = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_battle_soldierSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBattleInfo obj = (CC.Runtime.PB.ProtoRoleBattleInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name battle_soldierSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index battle_soldierSpecified on a nil value");
			}
		}

		obj.battle_soldierSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}
}

