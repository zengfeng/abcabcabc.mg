using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CC_Runtime_CooWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("InitPreloadCall", InitPreloadCall),
			new LuaMethod("InitConfig", InitConfig),
			new LuaMethod("New", _CreateCC_Runtime_Coo),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("go", get_go, set_go),
			new LuaField("monoBehaviour", get_monoBehaviour, set_monoBehaviour),
			new LuaField("debugLogManager", get_debugLogManager, set_debugLogManager),
			new LuaField("assetManager", get_assetManager, set_assetManager),
			new LuaField("configManager", get_configManager, set_configManager),
			new LuaField("packetManager", get_packetManager, set_packetManager),
			new LuaField("loadManager", get_loadManager, set_loadManager),
			new LuaField("menuManager", get_menuManager, set_menuManager),
			new LuaField("luaManager", get_luaManager, set_luaManager),
			new LuaField("soundManager", get_soundManager, set_soundManager),
			new LuaField("nativeManager", get_nativeManager, set_nativeManager),
			new LuaField("callUtil", get_callUtil, set_callUtil),
			new LuaField("fps", get_fps, set_fps),
			new LuaField("crashReporter", get_crashReporter, set_crashReporter),
			new LuaField("uiCamera", get_uiCamera, set_uiCamera),
		};

		LuaScriptMgr.RegisterLib(L, "CC.Runtime.Coo", typeof(CC.Runtime.Coo), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCC_Runtime_Coo(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CC.Runtime.Coo class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CC.Runtime.Coo);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_go(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.Coo.go);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_monoBehaviour(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.Coo.monoBehaviour);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_debugLogManager(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.Coo.debugLogManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_assetManager(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.Coo.assetManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_configManager(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.Coo.configManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_packetManager(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.Coo.packetManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_loadManager(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.Coo.loadManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_menuManager(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.Coo.menuManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_luaManager(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, CC.Runtime.Coo.luaManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_soundManager(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.Coo.soundManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_nativeManager(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.Coo.nativeManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_callUtil(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, CC.Runtime.Coo.callUtil);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fps(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.Coo.fps);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_crashReporter(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.Coo.crashReporter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uiCamera(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.Coo.uiCamera);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_go(IntPtr L)
	{
		CC.Runtime.Coo.go = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_monoBehaviour(IntPtr L)
	{
		CC.Runtime.Coo.monoBehaviour = (MonoBehaviour)LuaScriptMgr.GetUnityObject(L, 3, typeof(MonoBehaviour));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_debugLogManager(IntPtr L)
	{
		CC.Runtime.Coo.debugLogManager = (CC.Module.DebugLog.DebugLogManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(CC.Module.DebugLog.DebugLogManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_assetManager(IntPtr L)
	{
		CC.Runtime.Coo.assetManager = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(CC.Runtime.AssetManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_configManager(IntPtr L)
	{
		CC.Runtime.Coo.configManager = (CC.Runtime.ConfigManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(CC.Runtime.ConfigManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_packetManager(IntPtr L)
	{
		CC.Runtime.Coo.packetManager = (CC.Runtime.PacketManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(CC.Runtime.PacketManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_loadManager(IntPtr L)
	{
		CC.Runtime.Coo.loadManager = (CC.Module.Loads.LoadManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(CC.Module.Loads.LoadManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_menuManager(IntPtr L)
	{
		CC.Runtime.Coo.menuManager = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(CC.Module.Menu.MenuManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_luaManager(IntPtr L)
	{
		CC.Runtime.Coo.luaManager = (LuaScriptMgr)LuaScriptMgr.GetNetObject(L, 3, typeof(LuaScriptMgr));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_soundManager(IntPtr L)
	{
		CC.Runtime.Coo.soundManager = (Games.Module.Sound.SoundManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(Games.Module.Sound.SoundManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_nativeManager(IntPtr L)
	{
		CC.Runtime.Coo.nativeManager = (NativeCodeManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(NativeCodeManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_callUtil(IntPtr L)
	{
		CC.Runtime.Coo.callUtil = (CC.Runtime.Utils.CallUtil)LuaScriptMgr.GetNetObject(L, 3, typeof(CC.Runtime.Utils.CallUtil));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fps(IntPtr L)
	{
		CC.Runtime.Coo.fps = (CC.Runtime.Utils.HUDFPS)LuaScriptMgr.GetUnityObject(L, 3, typeof(CC.Runtime.Utils.HUDFPS));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_crashReporter(IntPtr L)
	{
		CC.Runtime.Coo.crashReporter = (CrashReporter)LuaScriptMgr.GetUnityObject(L, 3, typeof(CrashReporter));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uiCamera(IntPtr L)
	{
		CC.Runtime.Coo.uiCamera = (Camera)LuaScriptMgr.GetUnityObject(L, 3, typeof(Camera));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitPreloadCall(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		CC.Runtime.Coo.InitPreloadCall();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		CC.Runtime.Coo.InitConfig();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetLuaObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetLuaObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

