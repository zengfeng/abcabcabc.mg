using System;
using LuaInterface;

public class Games_ConstConfigWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetFloatValues", GetFloatValues),
			new LuaMethod("GetIntValues", GetIntValues),
			new LuaMethod("GetStringValues", GetStringValues),
			new LuaMethod("GetFloatValue", GetFloatValue),
			new LuaMethod("GetIntValue", GetIntValue),
			new LuaMethod("GetStringValue", GetStringValue),
			new LuaMethod("GetInt", GetInt),
			new LuaMethod("GetInts", GetInts),
			new LuaMethod("GetFloat", GetFloat),
			new LuaMethod("GetFloats", GetFloats),
			new LuaMethod("GetString", GetString),
			new LuaMethod("GetStrings", GetStrings),
			new LuaMethod("New", _CreateGames_ConstConfig),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("id", get_id, set_id),
			new LuaField("name", get_name, set_name),
			new LuaField("floatValue", get_floatValue, set_floatValue),
			new LuaField("value", get_value, set_value),
			new LuaField("strValue", get_strValue, set_strValue),
			new LuaField("Key", get_Key, null),
		};

		LuaScriptMgr.RegisterLib(L, "Games.ConstConfig", typeof(Games.ConstConfig), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_ConstConfig(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.ConstConfig obj = new Games.ConstConfig();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.ConstConfig.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.ConstConfig);

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
		Games.ConstConfig obj = (Games.ConstConfig)o;

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
	static int get_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.ConstConfig obj = (Games.ConstConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name name");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index name on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.name);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_floatValue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.ConstConfig obj = (Games.ConstConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name floatValue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index floatValue on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.floatValue);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_value(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.ConstConfig obj = (Games.ConstConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name value");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index value on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.value);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_strValue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.ConstConfig obj = (Games.ConstConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name strValue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index strValue on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.strValue);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Key(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.ConstConfig obj = (Games.ConstConfig)o;

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
		Games.ConstConfig obj = (Games.ConstConfig)o;

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
	static int set_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.ConstConfig obj = (Games.ConstConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name name");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index name on a nil value");
			}
		}

		obj.name = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_floatValue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.ConstConfig obj = (Games.ConstConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name floatValue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index floatValue on a nil value");
			}
		}

		obj.floatValue = LuaScriptMgr.GetArrayNumber<float>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_value(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.ConstConfig obj = (Games.ConstConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name value");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index value on a nil value");
			}
		}

		obj.value = LuaScriptMgr.GetArrayNumber<int>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_strValue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.ConstConfig obj = (Games.ConstConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name strValue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index strValue on a nil value");
			}
		}

		obj.strValue = LuaScriptMgr.GetArrayString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFloatValues(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.ConstConfig obj = (Games.ConstConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.ConstConfig");
		float[] o = obj.GetFloatValues();
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetIntValues(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.ConstConfig obj = (Games.ConstConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.ConstConfig");
		int[] o = obj.GetIntValues();
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetStringValues(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.ConstConfig obj = (Games.ConstConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.ConstConfig");
		string[] o = obj.GetStringValues();
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFloatValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.ConstConfig obj = (Games.ConstConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.ConstConfig");
		float o = obj.GetFloatValue();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetIntValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.ConstConfig obj = (Games.ConstConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.ConstConfig");
		int o = obj.GetIntValue();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetStringValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.ConstConfig obj = (Games.ConstConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.ConstConfig");
		string o = obj.GetStringValue();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInt(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.ConstConfig.ID arg0 = (Games.ConstConfig.ID)LuaScriptMgr.GetNetObject(L, 1, typeof(Games.ConstConfig.ID));
		int o = Games.ConstConfig.GetInt(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInts(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.ConstConfig.ID arg0 = (Games.ConstConfig.ID)LuaScriptMgr.GetNetObject(L, 1, typeof(Games.ConstConfig.ID));
		int[] o = Games.ConstConfig.GetInts(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFloat(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.ConstConfig.ID arg0 = (Games.ConstConfig.ID)LuaScriptMgr.GetNetObject(L, 1, typeof(Games.ConstConfig.ID));
		float o = Games.ConstConfig.GetFloat(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFloats(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.ConstConfig.ID arg0 = (Games.ConstConfig.ID)LuaScriptMgr.GetNetObject(L, 1, typeof(Games.ConstConfig.ID));
		float[] o = Games.ConstConfig.GetFloats(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.ConstConfig.ID arg0 = (Games.ConstConfig.ID)LuaScriptMgr.GetNetObject(L, 1, typeof(Games.ConstConfig.ID));
		string o = Games.ConstConfig.GetString(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetStrings(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.ConstConfig.ID arg0 = (Games.ConstConfig.ID)LuaScriptMgr.GetNetObject(L, 1, typeof(Games.ConstConfig.ID));
		string[] o = Games.ConstConfig.GetStrings(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}
}

