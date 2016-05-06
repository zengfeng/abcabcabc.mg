using System;
using System.Collections.Generic;
using LuaInterface;

public class Games_Module_Wars_WarModelWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("LoadConfig", LoadConfig),
			new LuaMethod("AddWeightConfig", AddWeightConfig),
			new LuaMethod("HasWeightConfig", HasWeightConfig),
			new LuaMethod("GetWeightConfig", GetWeightConfig),
			new LuaMethod("AddMapConfig", AddMapConfig),
			new LuaMethod("GetMapConfig", GetMapConfig),
			new LuaMethod("AddAIConfig", AddAIConfig),
			new LuaMethod("GetAIConfig", GetAIConfig),
			new LuaMethod("AddWinConfig", AddWinConfig),
			new LuaMethod("GetWinConfig", GetWinConfig),
			new LuaMethod("AddStarConfig", AddStarConfig),
			new LuaMethod("GetStarConfig", GetStarConfig),
			new LuaMethod("AddStageConfig", AddStageConfig),
			new LuaMethod("GetStage", GetStage),
			new LuaMethod("GetRobotId", GetRobotId),
			new LuaMethod("AddStagePositionConfig", AddStagePositionConfig),
			new LuaMethod("GetStagePositionConfigList", GetStagePositionConfigList),
			new LuaMethod("AddMonsterConfig", AddMonsterConfig),
			new LuaMethod("GetMonster", GetMonster),
			new LuaMethod("AddSkillWarDisplayConf", AddSkillWarDisplayConf),
			new LuaMethod("GetSkillWarDisplayConf", GetSkillWarDisplayConf),
			new LuaMethod("AddSkillWarConf", AddSkillWarConf),
			new LuaMethod("GetSkillWarConf", GetSkillWarConf),
			new LuaMethod("GetEffectValueBySkillId", GetEffectValueBySkillId),
			new LuaMethod("AddSkillWarEffectConf", AddSkillWarEffectConf),
			new LuaMethod("GetSkillWarEffectConf", GetSkillWarEffectConf),
			new LuaMethod("Editor_GetStage", Editor_GetStage),
			new LuaMethod("AddBuildLevelConfig", AddBuildLevelConfig),
			new LuaMethod("GetBuildConfig", GetBuildConfig),
			new LuaMethod("AddBuildBasepropConfig", AddBuildBasepropConfig),
			new LuaMethod("GetBuildBasepropConfig", GetBuildBasepropConfig),
			new LuaMethod("AddBuildProduceConfig", AddBuildProduceConfig),
			new LuaMethod("GetBuildProduceConfig", GetBuildProduceConfig),
			new LuaMethod("AddBuildTurretConfig", AddBuildTurretConfig),
			new LuaMethod("GetBuildTurretConfig", GetBuildTurretConfig),
			new LuaMethod("AddBuildSpotConfig", AddBuildSpotConfig),
			new LuaMethod("GetBuildSpotConfig", GetBuildSpotConfig),
			new LuaMethod("AddBuildWallConfig", AddBuildWallConfig),
			new LuaMethod("GetBuildWallConfigg", GetBuildWallConfigg),
			new LuaMethod("GetBuildModuleType", GetBuildModuleType),
			new LuaMethod("GetBuildModuleConfig", GetBuildModuleConfig),
			new LuaMethod("AddLegionLevelConfig", AddLegionLevelConfig),
			new LuaMethod("GetLegionLevelConfig", GetLegionLevelConfig),
			new LuaMethod("AddNeutralExpConfig", AddNeutralExpConfig),
			new LuaMethod("GetNeutralExpConfig", GetNeutralExpConfig),
			new LuaMethod("New", _CreateGames_Module_Wars_WarModel),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("stageConfigs_Index", get_stageConfigs_Index, set_stageConfigs_Index),
			new LuaField("weightConfigs", get_weightConfigs, set_weightConfigs),
			new LuaField("mapConfigs", get_mapConfigs, set_mapConfigs),
			new LuaField("aiConfigs", get_aiConfigs, set_aiConfigs),
			new LuaField("winConfigs", get_winConfigs, set_winConfigs),
			new LuaField("starConfigs", get_starConfigs, set_starConfigs),
			new LuaField("stagePositionConfigs", get_stagePositionConfigs, set_stagePositionConfigs),
			new LuaField("monsterConfigs", get_monsterConfigs, set_monsterConfigs),
			new LuaField("skillWarDisplayConfs", get_skillWarDisplayConfs, set_skillWarDisplayConfs),
			new LuaField("skillWarConfDic", get_skillWarConfDic, set_skillWarConfDic),
			new LuaField("skillWarEffectConfDic", get_skillWarEffectConfDic, set_skillWarEffectConfDic),
			new LuaField("Editor_stageConfigs", get_Editor_stageConfigs, set_Editor_stageConfigs),
			new LuaField("buildConfigs", get_buildConfigs, set_buildConfigs),
			new LuaField("buildBasepropConfigs", get_buildBasepropConfigs, set_buildBasepropConfigs),
			new LuaField("buildProduceConfigs", get_buildProduceConfigs, set_buildProduceConfigs),
			new LuaField("buildTurretConfigs", get_buildTurretConfigs, set_buildTurretConfigs),
			new LuaField("buildSpotConfigs", get_buildSpotConfigs, set_buildSpotConfigs),
			new LuaField("buildWallConfigs", get_buildWallConfigs, set_buildWallConfigs),
			new LuaField("legionLevelConfigs", get_legionLevelConfigs, set_legionLevelConfigs),
			new LuaField("neutralExpConfigs", get_neutralExpConfigs, set_neutralExpConfigs),
			new LuaField("stagePaths", get_stagePaths, set_stagePaths),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.WarModel", typeof(Games.Module.Wars.WarModel), regs, fields, typeof(CC.Runtime.Model));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Wars_WarModel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Wars.WarModel obj = new Games.Module.Wars.WarModel();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.WarModel.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Wars.WarModel);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stageConfigs_Index(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stageConfigs_Index");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stageConfigs_Index on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.stageConfigs_Index);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_weightConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name weightConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index weightConfigs on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.weightConfigs);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mapConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mapConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mapConfigs on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.mapConfigs);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_aiConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name aiConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index aiConfigs on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.aiConfigs);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_winConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name winConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index winConfigs on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.winConfigs);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_starConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name starConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index starConfigs on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.starConfigs);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stagePositionConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stagePositionConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stagePositionConfigs on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.stagePositionConfigs);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_monsterConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name monsterConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index monsterConfigs on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.monsterConfigs);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skillWarDisplayConfs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillWarDisplayConfs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillWarDisplayConfs on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.skillWarDisplayConfs);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skillWarConfDic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillWarConfDic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillWarConfDic on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.skillWarConfDic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skillWarEffectConfDic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillWarEffectConfDic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillWarEffectConfDic on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.skillWarEffectConfDic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Editor_stageConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Editor_stageConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Editor_stageConfigs on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.Editor_stageConfigs);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_buildConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildConfigs on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.buildConfigs);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_buildBasepropConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildBasepropConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildBasepropConfigs on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.buildBasepropConfigs);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_buildProduceConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildProduceConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildProduceConfigs on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.buildProduceConfigs);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_buildTurretConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildTurretConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildTurretConfigs on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.buildTurretConfigs);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_buildSpotConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildSpotConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildSpotConfigs on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.buildSpotConfigs);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_buildWallConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildWallConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildWallConfigs on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.buildWallConfigs);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_legionLevelConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name legionLevelConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index legionLevelConfigs on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.legionLevelConfigs);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_neutralExpConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name neutralExpConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index neutralExpConfigs on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.neutralExpConfigs);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stagePaths(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stagePaths");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stagePaths on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.stagePaths);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stageConfigs_Index(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stageConfigs_Index");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stageConfigs_Index on a nil value");
			}
		}

		obj.stageConfigs_Index = (Dictionary<int,Games.Module.Wars.StageConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.StageConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_weightConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name weightConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index weightConfigs on a nil value");
			}
		}

		obj.weightConfigs = (Dictionary<int,Games.Module.Wars.StageWeightConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.StageWeightConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mapConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mapConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mapConfigs on a nil value");
			}
		}

		obj.mapConfigs = (Dictionary<int,Games.Module.Wars.MapConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.MapConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_aiConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name aiConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index aiConfigs on a nil value");
			}
		}

		obj.aiConfigs = (Dictionary<int,Games.Module.Wars.AIConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.AIConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_winConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name winConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index winConfigs on a nil value");
			}
		}

		obj.winConfigs = (Dictionary<int,Games.Module.Wars.WinConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.WinConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_starConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name starConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index starConfigs on a nil value");
			}
		}

		obj.starConfigs = (Dictionary<int,Games.Module.Wars.StarConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.StarConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stagePositionConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stagePositionConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stagePositionConfigs on a nil value");
			}
		}

		obj.stagePositionConfigs = (Dictionary<int,List<Games.Module.Wars.StagePositionConfig>>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,List<Games.Module.Wars.StagePositionConfig>>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_monsterConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name monsterConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index monsterConfigs on a nil value");
			}
		}

		obj.monsterConfigs = (Dictionary<int,Games.Module.Wars.MonsterConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.MonsterConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skillWarDisplayConfs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillWarDisplayConfs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillWarDisplayConfs on a nil value");
			}
		}

		obj.skillWarDisplayConfs = (Dictionary<int,Games.Module.Wars.SkillWarDisplayConf>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.SkillWarDisplayConf>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skillWarConfDic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillWarConfDic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillWarConfDic on a nil value");
			}
		}

		obj.skillWarConfDic = (Dictionary<int,Games.Module.Wars.SkillWarConf>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.SkillWarConf>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skillWarEffectConfDic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name skillWarEffectConfDic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index skillWarEffectConfDic on a nil value");
			}
		}

		obj.skillWarEffectConfDic = (Dictionary<int,Games.Module.Wars.SkillWarEffectConf>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.SkillWarEffectConf>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Editor_stageConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Editor_stageConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Editor_stageConfigs on a nil value");
			}
		}

		obj.Editor_stageConfigs = (Dictionary<int,Games.Module.Wars.StageConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.StageConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_buildConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildConfigs on a nil value");
			}
		}

		obj.buildConfigs = (Dictionary<int,Games.Module.Wars.BuildConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.BuildConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_buildBasepropConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildBasepropConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildBasepropConfigs on a nil value");
			}
		}

		obj.buildBasepropConfigs = (Dictionary<int,Games.Module.Wars.BuildBasepropConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.BuildBasepropConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_buildProduceConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildProduceConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildProduceConfigs on a nil value");
			}
		}

		obj.buildProduceConfigs = (Dictionary<int,Games.Module.Wars.BuildProduceConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.BuildProduceConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_buildTurretConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildTurretConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildTurretConfigs on a nil value");
			}
		}

		obj.buildTurretConfigs = (Dictionary<int,Games.Module.Wars.BuildTurretConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.BuildTurretConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_buildSpotConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildSpotConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildSpotConfigs on a nil value");
			}
		}

		obj.buildSpotConfigs = (Dictionary<int,Games.Module.Wars.BuildSpotConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.BuildSpotConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_buildWallConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name buildWallConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index buildWallConfigs on a nil value");
			}
		}

		obj.buildWallConfigs = (Dictionary<int,Games.Module.Wars.BuildWallConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.BuildWallConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_legionLevelConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name legionLevelConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index legionLevelConfigs on a nil value");
			}
		}

		obj.legionLevelConfigs = (Dictionary<int,Games.Module.Wars.LegionLevelConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.LegionLevelConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_neutralExpConfigs(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name neutralExpConfigs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index neutralExpConfigs on a nil value");
			}
		}

		obj.neutralExpConfigs = (Dictionary<int,Games.Module.Wars.NeutralExpConfig>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.NeutralExpConfig>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stagePaths(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stagePaths");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stagePaths on a nil value");
			}
		}

		obj.stagePaths = (Dictionary<int,Games.Module.Wars.StagePathData>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<int,Games.Module.Wars.StagePathData>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		obj.LoadConfig();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddWeightConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.StageWeightConfig arg0 = (Games.Module.Wars.StageWeightConfig)LuaScriptMgr.GetUnityObject(L, 2, typeof(Games.Module.Wars.StageWeightConfig));
		obj.AddWeightConfig(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HasWeightConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		bool o = obj.HasWeightConfig(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWeightConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.StageWeightConfig o = obj.GetWeightConfig(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddMapConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.MapConfig arg0 = (Games.Module.Wars.MapConfig)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.MapConfig));
		obj.AddMapConfig(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMapConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.MapConfig o = obj.GetMapConfig(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddAIConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.AIConfig arg0 = (Games.Module.Wars.AIConfig)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.AIConfig));
		obj.AddAIConfig(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAIConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.AIConfig o = obj.GetAIConfig(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddWinConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.WinConfig arg0 = (Games.Module.Wars.WinConfig)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.WinConfig));
		obj.AddWinConfig(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWinConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.WinConfig o = obj.GetWinConfig(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddStarConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.StarConfig arg0 = (Games.Module.Wars.StarConfig)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.StarConfig));
		obj.AddStarConfig(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetStarConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.StarConfig o = obj.GetStarConfig(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddStageConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.StageConfig arg0 = (Games.Module.Wars.StageConfig)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.StageConfig));
		obj.AddStageConfig(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetStage(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.StageConfig o = obj.GetStage(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRobotId(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		int o = obj.GetRobotId(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddStagePositionConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.StagePositionConfig arg0 = (Games.Module.Wars.StagePositionConfig)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.StagePositionConfig));
		obj.AddStagePositionConfig(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetStagePositionConfigList(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		List<Games.Module.Wars.StagePositionConfig> o = obj.GetStagePositionConfigList(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddMonsterConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.MonsterConfig arg0 = (Games.Module.Wars.MonsterConfig)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.MonsterConfig));
		obj.AddMonsterConfig(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMonster(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.MonsterConfig o = obj.GetMonster(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddSkillWarDisplayConf(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.SkillWarDisplayConf arg0 = (Games.Module.Wars.SkillWarDisplayConf)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.SkillWarDisplayConf));
		obj.AddSkillWarDisplayConf(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSkillWarDisplayConf(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.SkillWarDisplayConf o = obj.GetSkillWarDisplayConf(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddSkillWarConf(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.SkillWarConf arg0 = (Games.Module.Wars.SkillWarConf)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.SkillWarConf));
		obj.AddSkillWarConf(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSkillWarConf(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.SkillWarConf o = obj.GetSkillWarConf(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEffectValueBySkillId(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Dictionary<int,float> o = obj.GetEffectValueBySkillId(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddSkillWarEffectConf(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.SkillWarEffectConf arg0 = (Games.Module.Wars.SkillWarEffectConf)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.SkillWarEffectConf));
		obj.AddSkillWarEffectConf(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSkillWarEffectConf(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.SkillWarEffectConf o = obj.GetSkillWarEffectConf(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Editor_GetStage(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.StageConfig o = obj.Editor_GetStage(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddBuildLevelConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.BuildLevelConfig arg0 = (Games.Module.Wars.BuildLevelConfig)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.BuildLevelConfig));
		obj.AddBuildLevelConfig(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBuildConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.BuildConfig o = obj.GetBuildConfig(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddBuildBasepropConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.BuildBasepropConfig arg0 = (Games.Module.Wars.BuildBasepropConfig)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.BuildBasepropConfig));
		obj.AddBuildBasepropConfig(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBuildBasepropConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.BuildBasepropConfig o = obj.GetBuildBasepropConfig(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddBuildProduceConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.BuildProduceConfig arg0 = (Games.Module.Wars.BuildProduceConfig)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.BuildProduceConfig));
		obj.AddBuildProduceConfig(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBuildProduceConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.BuildProduceConfig o = obj.GetBuildProduceConfig(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddBuildTurretConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.BuildTurretConfig arg0 = (Games.Module.Wars.BuildTurretConfig)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.BuildTurretConfig));
		obj.AddBuildTurretConfig(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBuildTurretConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.BuildTurretConfig o = obj.GetBuildTurretConfig(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddBuildSpotConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.BuildSpotConfig arg0 = (Games.Module.Wars.BuildSpotConfig)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.BuildSpotConfig));
		obj.AddBuildSpotConfig(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBuildSpotConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.BuildSpotConfig o = obj.GetBuildSpotConfig(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddBuildWallConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.BuildWallConfig arg0 = (Games.Module.Wars.BuildWallConfig)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.BuildWallConfig));
		obj.AddBuildWallConfig(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBuildWallConfigg(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.BuildWallConfig o = obj.GetBuildWallConfigg(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBuildModuleType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.BuildType o = obj.GetBuildModuleType(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBuildModuleConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.AbstractBuildConfig o = obj.GetBuildModuleConfig(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddLegionLevelConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.LegionLevelConfig arg0 = (Games.Module.Wars.LegionLevelConfig)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.LegionLevelConfig));
		obj.AddLegionLevelConfig(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLegionLevelConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.LegionLevelConfig o = obj.GetLegionLevelConfig(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddNeutralExpConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		Games.Module.Wars.NeutralExpConfig arg0 = (Games.Module.Wars.NeutralExpConfig)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.NeutralExpConfig));
		obj.AddNeutralExpConfig(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNeutralExpConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarModel obj = (Games.Module.Wars.WarModel)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarModel");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.NeutralExpConfig o = obj.GetNeutralExpConfig(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}
}

