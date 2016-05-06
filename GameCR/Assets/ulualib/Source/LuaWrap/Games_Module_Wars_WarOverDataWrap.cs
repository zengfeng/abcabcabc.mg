using System;
using System.Collections.Generic;
using LuaInterface;

public class Games_Module_Wars_WarOverDataWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateGames_Module_Wars_WarOverData),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("isRecord", get_isRecord, set_isRecord),
			new LuaField("enterData", get_enterData, set_enterData),
			new LuaField("overType", get_overType, set_overType),
			new LuaField("stageId", get_stageId, set_stageId),
			new LuaField("vsmode", get_vsmode, set_vsmode),
			new LuaField("time", get_time, set_time),
			new LuaField("isOverTime", get_isOverTime, set_isOverTime),
			new LuaField("legionDatas", get_legionDatas, set_legionDatas),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.WarOverData", typeof(Games.Module.Wars.WarOverData), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Wars_WarOverData(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Wars.WarOverData obj = new Games.Module.Wars.WarOverData();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.WarOverData.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Wars.WarOverData);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isRecord(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverData obj = (Games.Module.Wars.WarOverData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isRecord");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isRecord on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isRecord);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enterData(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverData obj = (Games.Module.Wars.WarOverData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enterData");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enterData on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.enterData);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_overType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverData obj = (Games.Module.Wars.WarOverData)o;

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
	static int get_stageId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverData obj = (Games.Module.Wars.WarOverData)o;

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
	static int get_vsmode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverData obj = (Games.Module.Wars.WarOverData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name vsmode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index vsmode on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.vsmode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_time(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverData obj = (Games.Module.Wars.WarOverData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name time");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index time on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.time);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isOverTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverData obj = (Games.Module.Wars.WarOverData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isOverTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isOverTime on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isOverTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_legionDatas(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverData obj = (Games.Module.Wars.WarOverData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name legionDatas");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index legionDatas on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.legionDatas);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isRecord(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverData obj = (Games.Module.Wars.WarOverData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isRecord");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isRecord on a nil value");
			}
		}

		obj.isRecord = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enterData(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverData obj = (Games.Module.Wars.WarOverData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enterData");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enterData on a nil value");
			}
		}

		obj.enterData = (Games.Module.Wars.WarEnterData)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.WarEnterData));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_overType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverData obj = (Games.Module.Wars.WarOverData)o;

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

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stageId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverData obj = (Games.Module.Wars.WarOverData)o;

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
	static int set_vsmode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverData obj = (Games.Module.Wars.WarOverData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name vsmode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index vsmode on a nil value");
			}
		}

		obj.vsmode = (Games.Module.Wars.VSMode)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.VSMode));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_time(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverData obj = (Games.Module.Wars.WarOverData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name time");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index time on a nil value");
			}
		}

		obj.time = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isOverTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverData obj = (Games.Module.Wars.WarOverData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isOverTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isOverTime on a nil value");
			}
		}

		obj.isOverTime = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_legionDatas(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarOverData obj = (Games.Module.Wars.WarOverData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name legionDatas");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index legionDatas on a nil value");
			}
		}

		obj.legionDatas = (List<Games.Module.Wars.WarOverLegionData>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<Games.Module.Wars.WarOverLegionData>));
		return 0;
	}
}

