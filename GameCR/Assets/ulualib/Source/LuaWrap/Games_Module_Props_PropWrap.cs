using System;
using LuaInterface;

public class Games_Module_Props_PropWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Clone", Clone),
			new LuaMethod("CreateInstance", CreateInstance),
			new LuaMethod("ParseField", ParseField),
			new LuaMethod("ToString", ToString),
			new LuaMethod("New", _CreateGames_Module_Props_Prop),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__tostring", Lua_ToString),
			new LuaMethod("__mul", Lua_Mul),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("ID", get_ID, set_ID),
			new LuaField("value", get_value, set_value),
			new LuaField("config", get_config, set_config),
			new LuaField("Name", get_Name, null),
			new LuaField("id", get_id, null),
			new LuaField("priority", get_priority, null),
			new LuaField("additive", get_additive, null),
			new LuaField("type", get_type, null),
			new LuaField("commentName", get_commentName, null),
			new LuaField("ValueStr", get_ValueStr, null),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Props.Prop", typeof(Games.Module.Props.Prop), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Props_Prop(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Props.Prop obj = new Games.Module.Props.Prop();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Props.Prop.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Props.Prop);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.Prop obj = (Games.Module.Props.Prop)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ID");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ID on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.ID);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_value(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.Prop obj = (Games.Module.Props.Prop)o;

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

		LuaScriptMgr.Push(L, obj.value);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_config(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.Prop obj = (Games.Module.Props.Prop)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name config");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index config on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.config);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.Prop obj = (Games.Module.Props.Prop)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Name");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Name on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.Name);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_id(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.Prop obj = (Games.Module.Props.Prop)o;

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
	static int get_priority(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.Prop obj = (Games.Module.Props.Prop)o;

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
		Games.Module.Props.Prop obj = (Games.Module.Props.Prop)o;

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
		Games.Module.Props.Prop obj = (Games.Module.Props.Prop)o;

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
	static int get_commentName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.Prop obj = (Games.Module.Props.Prop)o;

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
	static int get_ValueStr(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.Prop obj = (Games.Module.Props.Prop)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ValueStr");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ValueStr on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.ValueStr);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.Prop obj = (Games.Module.Props.Prop)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ID");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ID on a nil value");
			}
		}

		obj.ID = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_value(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.Prop obj = (Games.Module.Props.Prop)o;

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

		obj.value = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_config(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Props.Prop obj = (Games.Module.Props.Prop)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name config");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index config on a nil value");
			}
		}

		obj.config = (Games.Module.Props.PropConfig)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Props.PropConfig));
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
			LuaScriptMgr.Push(L, "Table: Games.Module.Props.Prop");
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clone(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Props.Prop obj = (Games.Module.Props.Prop)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Props.Prop");
		Games.Module.Props.Prop o = obj.Clone();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateInstance(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			Games.Module.Props.Prop o = Games.Module.Props.Prop.CreateInstance(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Games.Module.Props.PropConfig), typeof(float)))
		{
			Games.Module.Props.PropConfig arg0 = (Games.Module.Props.PropConfig)LuaScriptMgr.GetLuaObject(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			Games.Module.Props.Prop o = Games.Module.Props.Prop.CreateInstance(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(float)))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			Games.Module.Props.Prop o = Games.Module.Props.Prop.CreateInstance(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Props.Prop.CreateInstance");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ParseField(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Props.Prop obj = (Games.Module.Props.Prop)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Props.Prop");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.ParseField(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Props.Prop obj = (Games.Module.Props.Prop)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Props.Prop");
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Mul(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Props.Prop arg0 = (Games.Module.Props.Prop)LuaScriptMgr.GetNetObject(L, 1, typeof(Games.Module.Props.Prop));
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Props.Prop o = arg0 * arg1;
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}
}

