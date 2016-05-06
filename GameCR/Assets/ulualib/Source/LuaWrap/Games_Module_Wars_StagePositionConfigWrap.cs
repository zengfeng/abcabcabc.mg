using System;
using LuaInterface;

public class Games_Module_Wars_StagePositionConfigWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Clone", Clone),
			new LuaMethod("ParseCsv", ParseCsv),
			new LuaMethod("ToString", ToString),
			new LuaMethod("ToCsv", ToCsv),
			new LuaMethod("New", _CreateGames_Module_Wars_StagePositionConfig),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__tostring", Lua_ToString),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("stageId", get_stageId, set_stageId),
			new LuaField("index", get_index, set_index),
			new LuaField("position", get_position, set_position),
			new LuaField("hp", get_hp, set_hp),
			new LuaField("legionId", get_legionId, set_legionId),
			new LuaField("unitType", get_unitType, set_unitType),
			new LuaField("buildType", get_buildType, set_buildType),
			new LuaField("level", get_level, set_level),
			new LuaField("buildUid", get_buildUid, set_buildUid),
			new LuaField("settledPriority", get_settledPriority, set_settledPriority),
			new LuaField("name", get_name, set_name),
			new LuaField("stageName", get_stageName, set_stageName),
			new LuaField("buildConfig", get_buildConfig, null),
			new LuaField("avatarId", get_avatarId, null),
			new LuaField("Key", get_Key, null),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.StagePositionConfig", typeof(Games.Module.Wars.StagePositionConfig), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Wars_StagePositionConfig(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Wars.StagePositionConfig obj = new Games.Module.Wars.StagePositionConfig();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.StagePositionConfig.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Wars.StagePositionConfig);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stageId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

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
	static int get_index(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name index");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index index on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.index);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_position(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name position");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index position on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.position);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hp on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.hp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_legionId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

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
	static int get_unitType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name unitType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index unitType on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.unitType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_buildType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

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
	static int get_level(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

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
	static int get_buildUid(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildUid");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildUid on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.buildUid);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_settledPriority(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name settledPriority");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index settledPriority on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.settledPriority);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

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
	static int get_stageName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stageName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stageName on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.stageName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_buildConfig(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildConfig");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildConfig on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.buildConfig);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_avatarId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

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
	static int get_Key(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

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
	static int set_stageId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

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
	static int set_index(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name index");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index index on a nil value");
			}
		}

		obj.index = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_position(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name position");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index position on a nil value");
			}
		}

		obj.position = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_hp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hp on a nil value");
			}
		}

		obj.hp = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_legionId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

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
	static int set_unitType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name unitType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index unitType on a nil value");
			}
		}

		obj.unitType = (Games.Module.Wars.UnitType)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.UnitType));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_buildType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

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
	static int set_level(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

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
	static int set_buildUid(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildUid");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildUid on a nil value");
			}
		}

		obj.buildUid = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_settledPriority(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name settledPriority");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index settledPriority on a nil value");
			}
		}

		obj.settledPriority = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

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
	static int set_stageName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stageName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stageName on a nil value");
			}
		}

		obj.stageName = LuaScriptMgr.GetString(L, 3);
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
			LuaScriptMgr.Push(L, "Table: Games.Module.Wars.StagePositionConfig");
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clone(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.StagePositionConfig");
		Games.Module.Wars.StagePositionConfig o = obj.Clone();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ParseCsv(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.StagePositionConfig");
		string[] objs0 = LuaScriptMgr.GetArrayString(L, 2);
		obj.ParseCsv(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.StagePositionConfig");
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToCsv(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.StagePositionConfig obj = (Games.Module.Wars.StagePositionConfig)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.StagePositionConfig");
		string o = obj.ToCsv();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

