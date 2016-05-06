using System;
using LuaInterface;

public class Games_Module_Wars_WinConfigWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("ParseCsv", ParseCsv),
			new LuaMethod("ToString", ToString),
			new LuaMethod("New", _CreateGames_Module_Wars_WinConfig),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__tostring", Lua_ToString),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("id", get_id, set_id),
			new LuaField("winType", get_winType, set_winType),
			new LuaField("description", get_description, set_description),
			new LuaField("processDescription", get_processDescription, set_processDescription),
			new LuaField("itemId", get_itemId, set_itemId),
			new LuaField("parametersA", get_parametersA, set_parametersA),
			new LuaField("parametersB", get_parametersB, set_parametersB),
			new LuaField("parametersC", get_parametersC, set_parametersC),
			new LuaField("t1_builds", get_t1_builds, set_t1_builds),
			new LuaField("t1_time", get_t1_time, set_t1_time),
			new LuaField("paramA", get_paramA, set_paramA),
			new LuaField("paramB", get_paramB, set_paramB),
			new LuaField("avatar", get_avatar, set_avatar),
			new LuaField("Key", get_Key, null),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.WinConfig", typeof(Games.Module.Wars.WinConfig), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Wars_WinConfig(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Wars.WinConfig obj = new Games.Module.Wars.WinConfig();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.WinConfig.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Wars.WinConfig);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_id(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name id");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index id on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.id);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_winType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name winType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index winType on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.winType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_description(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name description");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index description on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.description);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_processDescription(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name processDescription");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index processDescription on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.processDescription);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_itemId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name itemId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index itemId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.itemId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_parametersA(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name parametersA");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index parametersA on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.parametersA);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_parametersB(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name parametersB");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index parametersB on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.parametersB);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_parametersC(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name parametersC");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index parametersC on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.parametersC);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_t1_builds(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name t1_builds");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index t1_builds on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.t1_builds);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_t1_time(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name t1_time");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index t1_time on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.t1_time);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_paramA(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name paramA");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index paramA on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.paramA);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_paramB(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name paramB");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index paramB on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.paramB);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_avatar(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name avatar");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index avatar on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.avatar);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Key(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Key");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Key on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.Key);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_id(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name id");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index id on a nil value");
			}
		}

		obj.id = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_winType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name winType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index winType on a nil value");
			}
		}

		obj.winType = (Games.Module.Wars.WinType)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.WinType));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_description(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name description");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index description on a nil value");
			}
		}

		obj.description = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_processDescription(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name processDescription");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index processDescription on a nil value");
			}
		}

		obj.processDescription = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_itemId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name itemId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index itemId on a nil value");
			}
		}

		obj.itemId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_parametersA(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name parametersA");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index parametersA on a nil value");
			}
		}

		obj.parametersA = LuaScriptMgr.GetArrayNumber<float>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_parametersB(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name parametersB");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index parametersB on a nil value");
			}
		}

		obj.parametersB = LuaScriptMgr.GetArrayNumber<float>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_parametersC(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name parametersC");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index parametersC on a nil value");
			}
		}

		obj.parametersC = LuaScriptMgr.GetArrayNumber<float>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_t1_builds(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name t1_builds");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index t1_builds on a nil value");
			}
		}

		obj.t1_builds = LuaScriptMgr.GetArrayNumber<int>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_t1_time(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name t1_time");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index t1_time on a nil value");
			}
		}

		obj.t1_time = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_paramA(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name paramA");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index paramA on a nil value");
			}
		}

		obj.paramA = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_paramB(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name paramB");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index paramB on a nil value");
			}
		}

		obj.paramB = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_avatar(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name avatar");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index avatar on a nil value");
			}
		}

		obj.avatar = LuaScriptMgr.GetArrayNumber<int>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		object obj = LuaScriptMgr.GetLuaObject(L, 1);

		if (obj != null)
		{
			LuaScriptMgr.Push(L, obj.ToString());
		}
		else
		{
			LuaScriptMgr.Push(L, "Table: Games.Module.Wars.WinConfig");
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ParseCsv(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WinConfig");
		string[] objs0 = LuaScriptMgr.GetArrayString(L, 2);
		obj.ParseCsv(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.WinConfig obj = (Games.Module.Wars.WinConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WinConfig");
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

