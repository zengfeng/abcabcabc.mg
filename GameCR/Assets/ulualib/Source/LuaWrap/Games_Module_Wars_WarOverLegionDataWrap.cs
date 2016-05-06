using System;
using LuaInterface;

public class Games_Module_Wars_WarOverLegionDataWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateGames_Module_Wars_WarOverLegionData),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("roleId", get_roleId, set_roleId),
			new LuaField("legionId", get_legionId, set_legionId),
			new LuaField("starCount", get_starCount, set_starCount),
			new LuaField("buildCount", get_buildCount, set_buildCount),
			new LuaField("buildTotal", get_buildTotal, set_buildTotal),
			new LuaField("overType", get_overType, set_overType),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.WarOverLegionData", typeof(Games.Module.Wars.WarOverLegionData), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Wars_WarOverLegionData(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Wars.WarOverLegionData obj = new Games.Module.Wars.WarOverLegionData();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.WarOverLegionData.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Wars.WarOverLegionData);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_roleId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverLegionData obj = (Games.Module.Wars.WarOverLegionData)o;

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
	static int get_legionId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverLegionData obj = (Games.Module.Wars.WarOverLegionData)o;

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
	static int get_starCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverLegionData obj = (Games.Module.Wars.WarOverLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name starCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index starCount on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.starCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_buildCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverLegionData obj = (Games.Module.Wars.WarOverLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildCount on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.buildCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_buildTotal(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverLegionData obj = (Games.Module.Wars.WarOverLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildTotal");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildTotal on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.buildTotal);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_overType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverLegionData obj = (Games.Module.Wars.WarOverLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name overType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index overType on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.overType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_roleId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverLegionData obj = (Games.Module.Wars.WarOverLegionData)o;

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
	static int set_legionId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverLegionData obj = (Games.Module.Wars.WarOverLegionData)o;

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
	static int set_starCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverLegionData obj = (Games.Module.Wars.WarOverLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name starCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index starCount on a nil value");
			}
		}

		obj.starCount = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_buildCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverLegionData obj = (Games.Module.Wars.WarOverLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildCount on a nil value");
			}
		}

		obj.buildCount = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_buildTotal(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverLegionData obj = (Games.Module.Wars.WarOverLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildTotal");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildTotal on a nil value");
			}
		}

		obj.buildTotal = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_overType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverLegionData obj = (Games.Module.Wars.WarOverLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name overType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index overType on a nil value");
			}
		}

		obj.overType = (Games.Module.Wars.OverType)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.OverType));
		return 0;
	}
}

