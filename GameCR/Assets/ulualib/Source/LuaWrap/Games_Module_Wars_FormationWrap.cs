using System;
using System.Collections.Generic;
using LuaInterface;

public class Games_Module_Wars_FormationWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateGames_Module_Wars_Formation),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("roldId", get_roldId, set_roldId),
			new LuaField("legionId", get_legionId, set_legionId),
			new LuaField("positions", get_positions, set_positions),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.Formation", typeof(Games.Module.Wars.Formation), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Wars_Formation(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Wars.Formation obj = new Games.Module.Wars.Formation();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			Games.Module.Wars.Formation obj = new Games.Module.Wars.Formation(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 2)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			Games.Module.Wars.Formation obj = new Games.Module.Wars.Formation(arg0,arg1);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.Formation.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Wars.Formation);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_roldId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.Formation obj = (Games.Module.Wars.Formation)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roldId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roldId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.roldId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_legionId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.Formation obj = (Games.Module.Wars.Formation)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name legionId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index legionId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.legionId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_positions(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.Formation obj = (Games.Module.Wars.Formation)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name positions");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index positions on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.positions);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_roldId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.Formation obj = (Games.Module.Wars.Formation)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roldId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roldId on a nil value");
			}
		}

		obj.roldId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_legionId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.Formation obj = (Games.Module.Wars.Formation)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name legionId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index legionId on a nil value");
			}
		}

		obj.legionId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_positions(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.Formation obj = (Games.Module.Wars.Formation)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name positions");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index positions on a nil value");
			}
		}

		obj.positions = (List<Games.Module.Wars.FormationPosition>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<Games.Module.Wars.FormationPosition>));
		return 0;
	}
}

