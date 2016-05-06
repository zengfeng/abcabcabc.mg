using System;
using LuaInterface;

public class Games_Module_Wars_WarEnterHeroDataWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("CheckProps", CheckProps),
			new LuaMethod("ToString", ToString),
			new LuaMethod("New", _CreateGames_Module_Wars_WarEnterHeroData),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__tostring", Lua_ToString),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("name", get_name, set_name),
			new LuaField("heroId", get_heroId, set_heroId),
			new LuaField("buildIndex", get_buildIndex, set_buildIndex),
			new LuaField("avatarId", get_avatarId, set_avatarId),
			new LuaField("skillId", get_skillId, set_skillId),
			new LuaField("level", get_level, set_level),
			new LuaField("props", get_props, set_props),
			new LuaField("initHP", get_initHP, set_initHP),
			new LuaField("quality", get_quality, set_quality),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.WarEnterHeroData", typeof(Games.Module.Wars.WarEnterHeroData), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Wars_WarEnterHeroData(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Wars.WarEnterHeroData obj = new Games.Module.Wars.WarEnterHeroData();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.WarEnterHeroData.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Wars.WarEnterHeroData);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)o;

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
	static int get_heroId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name heroId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index heroId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.heroId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_buildIndex(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildIndex");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildIndex on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.buildIndex);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_avatarId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)o;

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
	static int get_skillId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)o;

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
	static int get_level(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name level");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index level on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.level);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_props(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)o;

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
	static int get_initHP(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name initHP");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index initHP on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.initHP);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_quality(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name quality");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index quality on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.quality);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)o;

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
	static int set_heroId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name heroId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index heroId on a nil value");
			}
		}

		obj.heroId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_buildIndex(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildIndex");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildIndex on a nil value");
			}
		}

		obj.buildIndex = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_avatarId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)o;

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
	static int set_skillId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)o;

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
	static int set_level(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name level");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index level on a nil value");
			}
		}

		obj.level = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_props(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)o;

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
	static int set_initHP(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name initHP");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index initHP on a nil value");
			}
		}

		obj.initHP = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_quality(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name quality");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index quality on a nil value");
			}
		}

		obj.quality = (int)LuaScriptMgr.GetNumber(L, 3);
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
			LuaScriptMgr.Push(L, "Table: Games.Module.Wars.WarEnterHeroData");
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CheckProps(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterHeroData");
		obj.CheckProps();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.WarEnterHeroData obj = (Games.Module.Wars.WarEnterHeroData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterHeroData");
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

