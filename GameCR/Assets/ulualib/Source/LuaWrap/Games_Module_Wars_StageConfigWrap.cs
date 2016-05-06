using System;
using System.Collections.Generic;
using LuaInterface;

public class Games_Module_Wars_StageConfigWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Clone", Clone),
			new LuaMethod("ParseCsv", ParseCsv),
			new LuaMethod("GenerationPositionData", GenerationPositionData),
			new LuaMethod("ToCsv", ToCsv),
			new LuaMethod("New", _CreateGames_Module_Wars_StageConfig),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("id", get_id, set_id),
			new LuaField("level", get_level, set_level),
			new LuaField("name", get_name, set_name),
			new LuaField("description", get_description, set_description),
			new LuaField("type", get_type, set_type),
			new LuaField("nextStageId", get_nextStageId, set_nextStageId),
			new LuaField("resource", get_resource, set_resource),
			new LuaField("winId", get_winId, set_winId),
			new LuaField("lua", get_lua, set_lua),
			new LuaField("costStrength", get_costStrength, set_costStrength),
			new LuaField("time", get_time, set_time),
			new LuaField("sos", get_sos, set_sos),
			new LuaField("showHP", get_showHP, set_showHP),
			new LuaField("neutralRoleLevel", get_neutralRoleLevel, set_neutralRoleLevel),
			new LuaField("stars", get_stars, set_stars),
			new LuaField("dropId", get_dropId, set_dropId),
			new LuaField("legionGroups", get_legionGroups, set_legionGroups),
			new LuaField("legionDict", get_legionDict, set_legionDict),
			new LuaField("buildDict", get_buildDict, set_buildDict),
			new LuaField("wallDict", get_wallDict, set_wallDict),
			new LuaField("defaultMyTeam", get_defaultMyTeam, set_defaultMyTeam),
			new LuaField("winConfig", get_winConfig, null),
			new LuaField("mapConfig", get_mapConfig, null),
			new LuaField("Key", get_Key, null),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.StageConfig", typeof(Games.Module.Wars.StageConfig), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Wars_StageConfig(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Wars.StageConfig obj = new Games.Module.Wars.StageConfig();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.StageConfig.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Wars.StageConfig);

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
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

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
	static int get_level(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

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
	static int get_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

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
	static int get_description(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

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
	static int get_type(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

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
	static int get_nextStageId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name nextStageId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index nextStageId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.nextStageId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_resource(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name resource");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index resource on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.resource);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_winId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name winId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index winId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.winId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lua(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lua");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lua on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.lua);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_costStrength(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name costStrength");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index costStrength on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.costStrength);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_time(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

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
	static int get_sos(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sos");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sos on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.sos);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_showHP(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name showHP");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index showHP on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.showHP);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_neutralRoleLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name neutralRoleLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index neutralRoleLevel on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.neutralRoleLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stars(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stars");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stars on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.stars);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dropId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dropId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dropId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.dropId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_legionGroups(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name legionGroups");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index legionGroups on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.legionGroups);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_legionDict(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name legionDict");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index legionDict on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.legionDict);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_buildDict(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildDict");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildDict on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.buildDict);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_wallDict(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name wallDict");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index wallDict on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.wallDict);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_defaultMyTeam(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name defaultMyTeam");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index defaultMyTeam on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.defaultMyTeam);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_winConfig(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name winConfig");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index winConfig on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.winConfig);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mapConfig(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mapConfig");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mapConfig on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.mapConfig);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Key(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

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
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

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
	static int set_level(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

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
	static int set_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

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
	static int set_description(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

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
	static int set_type(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

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

		obj.type = (Games.Module.Wars.StageType)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.StageType));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_nextStageId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name nextStageId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index nextStageId on a nil value");
			}
		}

		obj.nextStageId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_resource(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name resource");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index resource on a nil value");
			}
		}

		obj.resource = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_winId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name winId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index winId on a nil value");
			}
		}

		obj.winId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lua(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lua");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lua on a nil value");
			}
		}

		obj.lua = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_costStrength(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name costStrength");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index costStrength on a nil value");
			}
		}

		obj.costStrength = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_time(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

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

		obj.time = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sos(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sos");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sos on a nil value");
			}
		}

		obj.sos = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_showHP(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name showHP");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index showHP on a nil value");
			}
		}

		obj.showHP = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_neutralRoleLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name neutralRoleLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index neutralRoleLevel on a nil value");
			}
		}

		obj.neutralRoleLevel = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stars(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stars");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stars on a nil value");
			}
		}

		obj.stars = LuaScriptMgr.GetArrayNumber<int>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_dropId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dropId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dropId on a nil value");
			}
		}

		obj.dropId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_legionGroups(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name legionGroups");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index legionGroups on a nil value");
			}
		}

		obj.legionGroups = (List<Games.Module.Wars.StageLegionGroupConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<Games.Module.Wars.StageLegionGroupConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_legionDict(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name legionDict");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index legionDict on a nil value");
			}
		}

		obj.legionDict = (Dictionary<int,Games.Module.Wars.StageLegionConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.StageLegionConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_buildDict(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildDict");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildDict on a nil value");
			}
		}

		obj.buildDict = (Dictionary<int,Games.Module.Wars.StagePositionConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.StagePositionConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_wallDict(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name wallDict");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index wallDict on a nil value");
			}
		}

		obj.wallDict = (Dictionary<int,Games.Module.Wars.StagePositionConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.StagePositionConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_defaultMyTeam(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name defaultMyTeam");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index defaultMyTeam on a nil value");
			}
		}

		obj.defaultMyTeam = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clone(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.StageConfig");
		Games.Module.Wars.StageConfig o = obj.Clone();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ParseCsv(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.StageConfig");
		string[] objs0 = LuaScriptMgr.GetArrayString(L, 2);
		obj.ParseCsv(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GenerationPositionData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.StageConfig");
		obj.GenerationPositionData();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToCsv(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.StageConfig obj = (Games.Module.Wars.StageConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.StageConfig");
		string o = obj.ToCsv();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

