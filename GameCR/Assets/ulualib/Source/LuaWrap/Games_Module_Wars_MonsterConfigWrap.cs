using System;
using LuaInterface;

public class Games_Module_Wars_MonsterConfigWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetPropValue", GetPropValue),
			new LuaMethod("ParseCsv", ParseCsv),
			new LuaMethod("ToString", ToString),
			new LuaMethod("New", _CreateGames_Module_Wars_MonsterConfig),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__tostring", Lua_ToString),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("id", get_id, set_id),
			new LuaField("name", get_name, set_name),
			new LuaField("avatarId", get_avatarId, set_avatarId),
			new LuaField("buildType", get_buildType, set_buildType),
			new LuaField("skillId", get_skillId, set_skillId),
			new LuaField("skillLevel", get_skillLevel, set_skillLevel),
			new LuaField("skillId2", get_skillId2, set_skillId2),
			new LuaField("skillLevel2", get_skillLevel2, set_skillLevel2),
			new LuaField("props", get_props, set_props),
			new LuaField("Key", get_Key, null),
			new LuaField("avatarConfig", get_avatarConfig, null),
			new LuaField("battlePoint", get_battlePoint, null),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.MonsterConfig", typeof(Games.Module.Wars.MonsterConfig), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Wars_MonsterConfig(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Wars.MonsterConfig obj = new Games.Module.Wars.MonsterConfig();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.MonsterConfig.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Wars.MonsterConfig);

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
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

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
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

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
	static int get_avatarId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name avatarId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index avatarId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.avatarId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_buildType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildType on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.buildType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skillId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.skillId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skillLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillLevel on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.skillLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skillId2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillId2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillId2 on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.skillId2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skillLevel2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillLevel2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillLevel2 on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.skillLevel2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_props(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name props");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index props on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.props);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Key(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

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
	static int get_avatarConfig(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name avatarConfig");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index avatarConfig on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.avatarConfig);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_battlePoint(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name battlePoint");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index battlePoint on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.battlePoint);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_id(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

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
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

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
	static int set_avatarId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name avatarId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index avatarId on a nil value");
			}
		}

		obj.avatarId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_buildType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildType on a nil value");
			}
		}

		obj.buildType = (Games.Module.Wars.BuildType)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.BuildType));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skillId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillId on a nil value");
			}
		}

		obj.skillId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skillLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillLevel on a nil value");
			}
		}

		obj.skillLevel = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skillId2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillId2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillId2 on a nil value");
			}
		}

		obj.skillId2 = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skillLevel2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillLevel2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillLevel2 on a nil value");
			}
		}

		obj.skillLevel2 = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_props(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name props");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index props on a nil value");
			}
		}

		obj.props = LuaScriptMgr.GetArrayObject<Games.Module.Props.Prop>(L, 3);
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
			LuaScriptMgr.Push(L, "Table: Games.Module.Wars.MonsterConfig");
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPropValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.MonsterConfig");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		float o = obj.GetPropValue(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ParseCsv(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.MonsterConfig");
		string[] objs0 = LuaScriptMgr.GetArrayString(L, 2);
		obj.ParseCsv(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.MonsterConfig obj = (Games.Module.Wars.MonsterConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.MonsterConfig");
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

