using System;
using System.Collections.Generic;
using LuaInterface;

public class Games_Module_Wars_WarWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetVersionCompatible", GetVersionCompatible),
			new LuaMethod("IsSendService", IsSendService),
			new LuaMethod("Play", Play),
			new LuaMethod("Pause", Pause),
			new LuaMethod("Destory", Destory),
			new LuaMethod("GetLegionData", GetLegionData),
			new LuaMethod("GetLegionDataByRoleId", GetLegionDataByRoleId),
			new LuaMethod("GetRelationType", GetRelationType),
			new LuaMethod("Init", Init),
			new LuaMethod("Start", Start),
			new LuaMethod("ResetStart", ResetStart),
			new LuaMethod("Clear", Clear),
			new LuaMethod("S_Over", S_Over),
			new LuaMethod("Over", Over),
			new LuaMethod("Exit", Exit),
			new LuaMethod("GetPreloadFiles", GetPreloadFiles),
			new LuaMethod("OnPreloadFile", OnPreloadFile),
			new LuaMethod("OnReadyPVP", OnReadyPVP),
			new LuaMethod("New", _CreateGames_Module_Wars_War),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("version", get_version, set_version),
			new LuaField("isTest", get_isTest, set_isTest),
			new LuaField("isEditor", get_isEditor, set_isEditor),
			new LuaField("watchRoleId", get_watchRoleId, set_watchRoleId),
			new LuaField("isRecord", get_isRecord, set_isRecord),
			new LuaField("vsmode", get_vsmode, set_vsmode),
			new LuaField("processState", get_processState, set_processState),
			new LuaField("sendArmRate", get_sendArmRate, set_sendArmRate),
			new LuaField("timeLimit", get_timeLimit, set_timeLimit),
			new LuaField("timeMax", get_timeMax, set_timeMax),
			new LuaField("time", get_time, set_time),
			new LuaField("mainLegionID", get_mainLegionID, set_mainLegionID),
			new LuaField("ownLegionID", get_ownLegionID, set_ownLegionID),
			new LuaField("isAutoCloseLoad", get_isAutoCloseLoad, set_isAutoCloseLoad),
			new LuaField("overType", get_overType, set_overType),
			new LuaField("isOverTime", get_isOverTime, set_isOverTime),
			new LuaField("realPlayerCount", get_realPlayerCount, set_realPlayerCount),
			new LuaField("isUpdateBehaviour", get_isUpdateBehaviour, set_isUpdateBehaviour),
			new LuaField("isPlaying", get_isPlaying, set_isPlaying),
			new LuaField("endProto", get_endProto, set_endProto),
			new LuaField("signal", get_signal, set_signal),
			new LuaField("config", get_config, set_config),
			new LuaField("record", get_record, set_record),
			new LuaField("sceneData", get_sceneData, set_sceneData),
			new LuaField("darkScreenVisible", get_darkScreenVisible, set_darkScreenVisible),
			new LuaField("enterData", get_enterData, set_enterData),
			new LuaField("timeLineData", get_timeLineData, set_timeLineData),
			new LuaField("videoInfo", get_videoInfo, set_videoInfo),
			new LuaField("isGameing", get_isGameing, null),
			new LuaField("requireSynch", get_requireSynch, null),
			new LuaField("requireGuide", get_requireGuide, null),
			new LuaField("isWin", get_isWin, null),
			new LuaField("isMainLegion", get_isMainLegion, null),
			new LuaField("isSendSynchrService", get_isSendSynchrService, null),
			new LuaField("skillWarManager", get_skillWarManager, set_skillWarManager),
			new LuaField("exe", get_exe, set_exe),
			new LuaField("service", get_service, null),
			new LuaField("input", get_input, null),
			new LuaField("model", get_model, null),
			new LuaField("manager", get_manager, set_manager),
			new LuaField("pvp", get_pvp, set_pvp),
			new LuaField("pveExpedition", get_pveExpedition, set_pveExpedition),
			new LuaField("scene", get_scene, set_scene),
			new LuaField("map", get_map, set_map),
			new LuaField("sceneCreate", get_sceneCreate, set_sceneCreate),
			new LuaField("preload", get_preload, set_preload),
			new LuaField("factory", get_factory, set_factory),
			new LuaField("skillOperateSelect", get_skillOperateSelect, set_skillOperateSelect),
			new LuaField("skillUse", get_skillUse, set_skillUse),
			new LuaField("skillCreater", get_skillCreater, set_skillCreater),
			new LuaField("starManager", get_starManager, set_starManager),
			new LuaField("starPVPManager", get_starPVPManager, set_starPVPManager),
			new LuaField("winManager", get_winManager, set_winManager),
			new LuaField("pathManager", get_pathManager, set_pathManager),
			new LuaField("msgBox", get_msgBox, set_msgBox),
			new LuaField("textEffect", get_textEffect, set_textEffect),
			new LuaField("hunManager", get_hunManager, set_hunManager),
			new LuaField("soliderPool", get_soliderPool, set_soliderPool),
			new LuaField("pool", get_pool, set_pool),
			new LuaField("legionLevelManager", get_legionLevelManager, set_legionLevelManager),
			new LuaField("legionExpEffect", get_legionExpEffect, set_legionExpEffect),
			new LuaField("recordManager", get_recordManager, set_recordManager),
			new LuaField("camera", get_camera, set_camera),
			new LuaField("materials", get_materials, set_materials),
			new LuaField("icons", get_icons, set_icons),
			new LuaField("Instance", get_Instance, null),
			new LuaField("ownLegionData", get_ownLegionData, null),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.War", typeof(Games.Module.Wars.War), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Wars_War(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Wars.War obj = new Games.Module.Wars.War();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.War.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Wars.War);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_version(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.version);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isTest(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.isTest);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isEditor(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.isEditor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_watchRoleId(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.watchRoleId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isRecord(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.isRecord);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_vsmode(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.vsmode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_processState(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.processState);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sendArmRate(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.sendArmRate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_timeLimit(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.timeLimit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_timeMax(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.timeMax);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_time(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.time);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainLegionID(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.mainLegionID);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ownLegionID(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.ownLegionID);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isAutoCloseLoad(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.isAutoCloseLoad);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_overType(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.overType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isOverTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.isOverTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_realPlayerCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.realPlayerCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isUpdateBehaviour(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.isUpdateBehaviour);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPlaying(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.isPlaying);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_endProto(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Wars.War.endProto);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_signal(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Wars.War.signal);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_config(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Wars.War.config);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_record(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Wars.War.record);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sceneData(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Wars.War.sceneData);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_darkScreenVisible(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.darkScreenVisible);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enterData(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Wars.War.enterData);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_timeLineData(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Wars.War.timeLineData);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_videoInfo(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Wars.War.videoInfo);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isGameing(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.isGameing);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_requireSynch(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.requireSynch);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_requireGuide(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.requireGuide);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isWin(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.isWin);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isMainLegion(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.isMainLegion);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isSendSynchrService(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.isSendSynchrService);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skillWarManager(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.skillWarManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_exe(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.exe);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_service(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Wars.War.service);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_input(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Wars.War.input);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_model(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Wars.War.model);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_manager(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.manager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pvp(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.pvp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pveExpedition(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.pveExpedition);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_scene(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.scene);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_map(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.map);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sceneCreate(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.sceneCreate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_preload(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.preload);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_factory(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.factory);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skillOperateSelect(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.skillOperateSelect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skillUse(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.skillUse);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skillCreater(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.skillCreater);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_starManager(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.starManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_starPVPManager(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.starPVPManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_winManager(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.winManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pathManager(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.pathManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_msgBox(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.msgBox);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_textEffect(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.textEffect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hunManager(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.hunManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_soliderPool(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Wars.War.soliderPool);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pool(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.pool);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_legionLevelManager(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.legionLevelManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_legionExpEffect(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.legionExpEffect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_recordManager(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.recordManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_camera(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.camera);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_materials(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.materials);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_icons(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.War.icons);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Wars.War.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ownLegionData(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Games.Module.Wars.War.ownLegionData);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_version(IntPtr L)
	{
		Games.Module.Wars.War.version = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isTest(IntPtr L)
	{
		Games.Module.Wars.War.isTest = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isEditor(IntPtr L)
	{
		Games.Module.Wars.War.isEditor = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_watchRoleId(IntPtr L)
	{
		Games.Module.Wars.War.watchRoleId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isRecord(IntPtr L)
	{
		Games.Module.Wars.War.isRecord = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_vsmode(IntPtr L)
	{
		Games.Module.Wars.War.vsmode = (Games.Module.Wars.VSMode)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.VSMode));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_processState(IntPtr L)
	{
		Games.Module.Wars.War.processState = (Games.Module.Wars.WarProcessState)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.WarProcessState));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sendArmRate(IntPtr L)
	{
		Games.Module.Wars.War.sendArmRate = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_timeLimit(IntPtr L)
	{
		Games.Module.Wars.War.timeLimit = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_timeMax(IntPtr L)
	{
		Games.Module.Wars.War.timeMax = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_time(IntPtr L)
	{
		Games.Module.Wars.War.time = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainLegionID(IntPtr L)
	{
		Games.Module.Wars.War.mainLegionID = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ownLegionID(IntPtr L)
	{
		Games.Module.Wars.War.ownLegionID = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isAutoCloseLoad(IntPtr L)
	{
		Games.Module.Wars.War.isAutoCloseLoad = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_overType(IntPtr L)
	{
		Games.Module.Wars.War.overType = (Games.Module.Wars.OverType)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.OverType));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isOverTime(IntPtr L)
	{
		Games.Module.Wars.War.isOverTime = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_realPlayerCount(IntPtr L)
	{
		Games.Module.Wars.War.realPlayerCount = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isUpdateBehaviour(IntPtr L)
	{
		Games.Module.Wars.War.isUpdateBehaviour = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isPlaying(IntPtr L)
	{
		Games.Module.Wars.War.isPlaying = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_endProto(IntPtr L)
	{
		Games.Module.Wars.War.endProto = (CC.Runtime.PB.S_BattleEnd_0x830)LuaScriptMgr.GetNetObject(L, 3, typeof(CC.Runtime.PB.S_BattleEnd_0x830));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_signal(IntPtr L)
	{
		Games.Module.Wars.War.signal = (Games.Module.Wars.WarSignal)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.WarSignal));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_config(IntPtr L)
	{
		Games.Module.Wars.War.config = (Games.Module.Wars.WarConfig)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.WarConfig));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_record(IntPtr L)
	{
		Games.Module.Wars.War.record = (Games.Module.Wars.WarRecordIO)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.WarRecordIO));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sceneData(IntPtr L)
	{
		Games.Module.Wars.War.sceneData = (Games.Module.Wars.SceneData)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.SceneData));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_darkScreenVisible(IntPtr L)
	{
		Games.Module.Wars.War.darkScreenVisible = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enterData(IntPtr L)
	{
		Games.Module.Wars.War.enterData = (Games.Module.Wars.WarEnterData)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.WarEnterData));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_timeLineData(IntPtr L)
	{
		Games.Module.Wars.War.timeLineData = (Games.Module.Wars.WRTimeLineData)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.WRTimeLineData));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_videoInfo(IntPtr L)
	{
		Games.Module.Wars.War.videoInfo = (CC.Runtime.PB.ProtoBattleVideoInfo)LuaScriptMgr.GetNetObject(L, 3, typeof(CC.Runtime.PB.ProtoBattleVideoInfo));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skillWarManager(IntPtr L)
	{
		Games.Module.Wars.War.skillWarManager = (Games.Module.Wars.SkillWarManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.SkillWarManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_exe(IntPtr L)
	{
		Games.Module.Wars.War.exe = (Games.Module.Wars.WarExe)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.WarExe));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_manager(IntPtr L)
	{
		Games.Module.Wars.War.manager = (Games.Module.Wars.WarManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.WarManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pvp(IntPtr L)
	{
		Games.Module.Wars.War.pvp = (Games.Module.Wars.WarPVP)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.WarPVP));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pveExpedition(IntPtr L)
	{
		Games.Module.Wars.War.pveExpedition = (Games.Module.Wars.WarPVEExpedition)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.WarPVEExpedition));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_scene(IntPtr L)
	{
		Games.Module.Wars.War.scene = (Games.Module.Wars.WarScene)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.WarScene));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_map(IntPtr L)
	{
		Games.Module.Wars.War.map = (Games.Module.Wars.WarMap)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.WarMap));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sceneCreate(IntPtr L)
	{
		Games.Module.Wars.War.sceneCreate = (Games.Module.Wars.WarSceneCreate)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.WarSceneCreate));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_preload(IntPtr L)
	{
		Games.Module.Wars.War.preload = (Games.Module.Wars.WarPreload)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.WarPreload));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_factory(IntPtr L)
	{
		Games.Module.Wars.War.factory = (Games.Module.Wars.WarFactory)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.WarFactory));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skillOperateSelect(IntPtr L)
	{
		Games.Module.Wars.War.skillOperateSelect = (Games.Module.Wars.SkillOperateSelect)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.SkillOperateSelect));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skillUse(IntPtr L)
	{
		Games.Module.Wars.War.skillUse = (Games.Module.Wars.SkillUse)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.SkillUse));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skillCreater(IntPtr L)
	{
		Games.Module.Wars.War.skillCreater = (Games.Module.Wars.SkillCreater)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.SkillCreater));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_starManager(IntPtr L)
	{
		Games.Module.Wars.War.starManager = (Games.Module.Wars.StarManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.StarManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_starPVPManager(IntPtr L)
	{
		Games.Module.Wars.War.starPVPManager = (Games.Module.Wars.StarPVPManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.StarPVPManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_winManager(IntPtr L)
	{
		Games.Module.Wars.War.winManager = (Games.Module.Wars.WinManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.WinManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pathManager(IntPtr L)
	{
		Games.Module.Wars.War.pathManager = (PathManagerComponent)LuaScriptMgr.GetUnityObject(L, 3, typeof(PathManagerComponent));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_msgBox(IntPtr L)
	{
		Games.Module.Wars.War.msgBox = (Games.Module.Wars.MsgBox)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.MsgBox));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_textEffect(IntPtr L)
	{
		Games.Module.Wars.War.textEffect = (TextEffectManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(TextEffectManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_hunManager(IntPtr L)
	{
		Games.Module.Wars.War.hunManager = (HunManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(HunManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_soliderPool(IntPtr L)
	{
		Games.Module.Wars.War.soliderPool = (Games.Module.Wars.WarSoliderPool)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.WarSoliderPool));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pool(IntPtr L)
	{
		Games.Module.Wars.War.pool = (Games.Module.Wars.WarPoolManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.WarPoolManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_legionLevelManager(IntPtr L)
	{
		Games.Module.Wars.War.legionLevelManager = (Games.Module.Wars.LegionLevelViewManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.LegionLevelViewManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_legionExpEffect(IntPtr L)
	{
		Games.Module.Wars.War.legionExpEffect = (Games.Module.Wars.LegionExpEffect)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.LegionExpEffect));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_recordManager(IntPtr L)
	{
		Games.Module.Wars.War.recordManager = (Games.Module.Wars.WarRecord)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.WarRecord));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_camera(IntPtr L)
	{
		Games.Module.Wars.War.camera = (Games.Module.Wars.WarCamera)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.WarCamera));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_materials(IntPtr L)
	{
		Games.Module.Wars.War.materials = (Games.Module.Wars.WarMaterials)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.WarMaterials));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_icons(IntPtr L)
	{
		Games.Module.Wars.War.icons = (Games.Module.Wars.WarIcons)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Wars.WarIcons));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetVersionCompatible(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		bool o = Games.Module.Wars.War.GetVersionCompatible(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsSendService(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(Games.Module.Wars.LegionData)))
		{
			Games.Module.Wars.LegionData arg0 = (Games.Module.Wars.LegionData)LuaScriptMgr.GetLuaObject(L, 1);
			bool o = Games.Module.Wars.War.IsSendService(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(int)))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			bool o = Games.Module.Wars.War.IsSendService(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			Games.Module.Wars.LegionType arg1 = (Games.Module.Wars.LegionType)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.LegionType));
			bool o = Games.Module.Wars.War.IsSendService(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.War.IsSendService");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Play(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Games.Module.Wars.War.Play();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Pause(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Games.Module.Wars.War.Pause();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Destory(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.War obj = (Games.Module.Wars.War)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.War");
		obj.Destory();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLegionData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		Games.Module.Wars.LegionData o = Games.Module.Wars.War.GetLegionData(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLegionDataByRoleId(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		Games.Module.Wars.LegionData o = Games.Module.Wars.War.GetLegionDataByRoleId(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRelationType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		Games.Module.Wars.RelationType o = Games.Module.Wars.War.GetRelationType(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Games.Module.Wars.War.Init();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Start(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Games.Module.Wars.WarEnterData arg0 = (Games.Module.Wars.WarEnterData)LuaScriptMgr.GetNetObject(L, 1, typeof(Games.Module.Wars.WarEnterData));
			Games.Module.Wars.War.Start(arg0);
			return 0;
		}
		else if (count == 2)
		{
			CC.Runtime.PB.ProtoBattleVideoInfo arg0 = (CC.Runtime.PB.ProtoBattleVideoInfo)LuaScriptMgr.GetNetObject(L, 1, typeof(CC.Runtime.PB.ProtoBattleVideoInfo));
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			Games.Module.Wars.War.Start(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			LuaStringBuffer arg0 = LuaScriptMgr.GetStringBuffer(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
			Games.Module.Wars.War.Start(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.War.Start");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetStart(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Games.Module.Wars.War.ResetStart();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clear(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Games.Module.Wars.War.Clear();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int S_Over(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.WarOverData arg0 = (Games.Module.Wars.WarOverData)LuaScriptMgr.GetNetObject(L, 1, typeof(Games.Module.Wars.WarOverData));
		Games.Module.Wars.War.S_Over(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Over(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Games.Module.Wars.OverType arg0 = (Games.Module.Wars.OverType)LuaScriptMgr.GetNetObject(L, 1, typeof(Games.Module.Wars.OverType));
			Games.Module.Wars.War.Over(arg0);
			return 0;
		}
		else if (count == 2)
		{
			Games.Module.Wars.OverType arg0 = (Games.Module.Wars.OverType)LuaScriptMgr.GetNetObject(L, 1, typeof(Games.Module.Wars.OverType));
			bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
			Games.Module.Wars.War.Over(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.War.Over");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Exit(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Wars.War.Exit();
			return 0;
		}
		else if (count == 1)
		{
			bool arg0 = LuaScriptMgr.GetBoolean(L, 1);
			Games.Module.Wars.War.Exit(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.War.Exit");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPreloadFiles(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		List<string> o = Games.Module.Wars.War.GetPreloadFiles(arg0,arg1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPreloadFile(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		Games.Module.Wars.War.OnPreloadFile(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnReadyPVP(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Games.Module.Wars.War.OnReadyPVP();
		return 0;
	}
}

