using System;
using System.Collections.Generic;
using LuaInterface;

public class Games_Module_Wars_SkillWarConfWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("ParseCsv", ParseCsv),
			new LuaMethod("getEffectDataById", getEffectDataById),
			new LuaMethod("getEffectValue", getEffectValue),
			new LuaMethod("getTargetType", getTargetType),
			new LuaMethod("getBuildLvlUpValue", getBuildLvlUpValue),
			new LuaMethod("getSkillCostHp", getSkillCostHp),
			new LuaMethod("getSkillCostHPPer", getSkillCostHPPer),
			new LuaMethod("getBuildSkillType", getBuildSkillType),
			new LuaMethod("New", _CreateGames_Module_Wars_SkillWarConf),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("displayConfig", get_displayConfig, set_displayConfig),
			new LuaField("id", get_id, set_id),
			new LuaField("aiPriority", get_aiPriority, set_aiPriority),
			new LuaField("aiTypeArray", get_aiTypeArray, set_aiTypeArray),
			new LuaField("useCount", get_useCount, set_useCount),
			new LuaField("isSettledBuild", get_isSettledBuild, set_isSettledBuild),
			new LuaField("buildType", get_buildType, set_buildType),
			new LuaField("mainEffectData", get_mainEffectData, set_mainEffectData),
			new LuaField("effectDataList", get_effectDataList, set_effectDataList),
			new LuaField("consume", get_consume, set_consume),
			new LuaField("skillCd", get_skillCd, set_skillCd),
			new LuaField("musicEffectPath", get_musicEffectPath, set_musicEffectPath),
			new LuaField("heroVoicePath", get_heroVoicePath, set_heroVoicePath),
			new LuaField("skillAvatar", get_skillAvatar, set_skillAvatar),
			new LuaField("skillName", get_skillName, set_skillName),
			new LuaField("skillDescribe", get_skillDescribe, set_skillDescribe),
			new LuaField("Key", get_Key, null),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.SkillWarConf", typeof(Games.Module.Wars.SkillWarConf), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Wars_SkillWarConf(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Wars.SkillWarConf obj = new Games.Module.Wars.SkillWarConf();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.SkillWarConf.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Wars.SkillWarConf);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_displayConfig(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name displayConfig");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index displayConfig on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.displayConfig);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_id(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

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
	static int get_aiPriority(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name aiPriority");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index aiPriority on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.aiPriority);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_aiTypeArray(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name aiTypeArray");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index aiTypeArray on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.aiTypeArray);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useCount on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.useCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isSettledBuild(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isSettledBuild");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isSettledBuild on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isSettledBuild);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_buildType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

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
	static int get_mainEffectData(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainEffectData");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainEffectData on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.mainEffectData);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_effectDataList(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name effectDataList");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index effectDataList on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.effectDataList);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_consume(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name consume");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index consume on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.consume);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skillCd(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillCd");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillCd on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.skillCd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_musicEffectPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name musicEffectPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index musicEffectPath on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.musicEffectPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_heroVoicePath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name heroVoicePath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index heroVoicePath on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.heroVoicePath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skillAvatar(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillAvatar");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillAvatar on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.skillAvatar);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skillName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillName on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.skillName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skillDescribe(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillDescribe");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillDescribe on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.skillDescribe);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Key(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

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
	static int set_displayConfig(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name displayConfig");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index displayConfig on a nil value");
			}
		}

		obj.displayConfig = (Games.Module.Wars.SkillWarDisplayConf)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.SkillWarDisplayConf));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_id(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

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
	static int set_aiPriority(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name aiPriority");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index aiPriority on a nil value");
			}
		}

		obj.aiPriority = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_aiTypeArray(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name aiTypeArray");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index aiTypeArray on a nil value");
			}
		}

		obj.aiTypeArray = LuaScriptMgr.GetArrayNumber<int>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useCount on a nil value");
			}
		}

		obj.useCount = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isSettledBuild(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isSettledBuild");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isSettledBuild on a nil value");
			}
		}

		obj.isSettledBuild = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_buildType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

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

		obj.buildType = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainEffectData(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainEffectData");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainEffectData on a nil value");
			}
		}

		obj.mainEffectData = (Games.Module.Wars.CSkillEffectDataItem)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.CSkillEffectDataItem));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_effectDataList(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name effectDataList");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index effectDataList on a nil value");
			}
		}

		obj.effectDataList = (List<Games.Module.Wars.CSkillEffectDataItem>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<Games.Module.Wars.CSkillEffectDataItem>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_consume(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name consume");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index consume on a nil value");
			}
		}

		obj.consume = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skillCd(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillCd");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillCd on a nil value");
			}
		}

		obj.skillCd = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_musicEffectPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name musicEffectPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index musicEffectPath on a nil value");
			}
		}

		obj.musicEffectPath = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_heroVoicePath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name heroVoicePath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index heroVoicePath on a nil value");
			}
		}

		obj.heroVoicePath = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skillAvatar(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillAvatar");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillAvatar on a nil value");
			}
		}

		obj.skillAvatar = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skillName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillName on a nil value");
			}
		}

		obj.skillName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skillDescribe(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillDescribe");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillDescribe on a nil value");
			}
		}

		obj.skillDescribe = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ParseCsv(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.SkillWarConf");
		string[] objs0 = LuaScriptMgr.GetArrayString(L, 2);
		obj.ParseCsv(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getEffectDataById(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.SkillWarConf");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.CSkillEffectDataItem o = obj.getEffectDataById(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getEffectValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.SkillWarConf");
		Dictionary<int,float> o = obj.getEffectValue();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getTargetType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.SkillWarConf");
		int o = obj.getTargetType();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getBuildLvlUpValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.SkillWarConf");
		int o = obj.getBuildLvlUpValue();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getSkillCostHp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.SkillWarConf");
		float o = obj.getSkillCostHp();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getSkillCostHPPer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.SkillWarConf");
		float o = obj.getSkillCostHPPer();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getBuildSkillType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.SkillWarConf obj = (Games.Module.Wars.SkillWarConf)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.SkillWarConf");
		int o = obj.getBuildSkillType();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

