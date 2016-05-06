using System;
using LuaInterface;

public class Games_Module_Props_PropConfigWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Limit", Limit),
			new LuaMethod("Initialize", Initialize),
			new LuaMethod("GetInstance", GetInstance),
			new LuaMethod("New", _CreateGames_Module_Props_PropConfig),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("id", get_id, set_id),
			new LuaField("name", get_name, set_name),
			new LuaField("displayMultiplier", get_displayMultiplier, set_displayMultiplier),
			new LuaField("format", get_format, set_format),
			new LuaField("mapping", get_mapping, set_mapping),
			new LuaField("priority", get_priority, set_priority),
			new LuaField("additive", get_additive, set_additive),
			new LuaField("type", get_type, set_type),
			new LuaField("limitMinValue", get_limitMinValue, set_limitMinValue),
			new LuaField("limitMaxValue", get_limitMaxValue, set_limitMaxValue),
			new LuaField("commentName", get_commentName, set_commentName),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Props.PropConfig", typeof(Games.Module.Props.PropConfig), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Props_PropConfig(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Props.PropConfig obj = new Games.Module.Props.PropConfig();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Props.PropConfig.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Props.PropConfig);

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
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

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
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

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
	static int get_displayMultiplier(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name displayMultiplier");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index displayMultiplier on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.displayMultiplier);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_format(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name format");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index format on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.format);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mapping(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mapping");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mapping on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mapping);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_priority(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name priority");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index priority on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.priority);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_additive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name additive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index additive on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.additive);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_type(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name type");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index type on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.type);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_limitMinValue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name limitMinValue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index limitMinValue on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.limitMinValue);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_limitMaxValue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name limitMaxValue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index limitMaxValue on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.limitMaxValue);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_commentName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name commentName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index commentName on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.commentName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_id(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

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
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

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
	static int set_displayMultiplier(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name displayMultiplier");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index displayMultiplier on a nil value");
			}
		}

		obj.displayMultiplier = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_format(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name format");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index format on a nil value");
			}
		}

		obj.format = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mapping(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mapping");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mapping on a nil value");
			}
		}

		obj.mapping = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_priority(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name priority");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index priority on a nil value");
			}
		}

		obj.priority = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_additive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name additive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index additive on a nil value");
			}
		}

		obj.additive = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_type(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name type");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index type on a nil value");
			}
		}

		obj.type = (Games.Module.Props.PropType)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropType));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_limitMinValue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name limitMinValue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index limitMinValue on a nil value");
			}
		}

		obj.limitMinValue = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_limitMaxValue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name limitMaxValue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index limitMaxValue on a nil value");
			}
		}

		obj.limitMaxValue = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_commentName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name commentName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index commentName on a nil value");
			}
		}

		obj.commentName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Limit(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(float)))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			float o = Games.Module.Props.PropConfig.Limit(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Games.Module.Props.PropConfig), typeof(float)))
		{
			Games.Module.Props.PropConfig obj = (Games.Module.Props.PropConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Props.PropConfig");
			float arg0 = (float)LuaDLL.lua_tonumber(L, 2);
			float o = obj.Limit(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Props.PropConfig.Limit");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Initialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Props.PropConfig[] objs0 = LuaScriptMgr.GetArrayObject<Games.Module.Props.PropConfig>(L, 1);
		Games.Module.Props.PropConfig.Initialize(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInstance(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		Games.Module.Props.PropConfig o = Games.Module.Props.PropConfig.GetInstance(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}
}

