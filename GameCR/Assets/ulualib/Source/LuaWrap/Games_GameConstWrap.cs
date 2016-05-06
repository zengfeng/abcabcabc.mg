using System;
using LuaInterface;

public class Games_GameConstWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateGames_GameConst),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("WarDevelopMode", get_WarDevelopMode, set_WarDevelopMode),
			new LuaField("OfflineTest", get_OfflineTest, set_OfflineTest),
			new LuaField("CleanupDataPath", get_CleanupDataPath, set_CleanupDataPath),
			new LuaField("DebugMode", get_DebugMode, set_DebugMode),
			new LuaField("DevelopMode", get_DevelopMode, set_DevelopMode),
			new LuaField("TimerInterval", get_TimerInterval, set_TimerInterval),
			new LuaField("GameFrameRate", get_GameFrameRate, set_GameFrameRate),
			new LuaField("VisiableFPS", get_VisiableFPS, set_VisiableFPS),
			new LuaField("UsePbc", get_UsePbc, set_UsePbc),
			new LuaField("UseLpeg", get_UseLpeg, set_UseLpeg),
			new LuaField("UsePbLua", get_UsePbLua, set_UsePbLua),
			new LuaField("UseCJson", get_UseCJson, set_UseCJson),
			new LuaField("UseSproto", get_UseSproto, set_UseSproto),
			new LuaField("LuaEncode", get_LuaEncode, set_LuaEncode),
			new LuaField("UserId", get_UserId, set_UserId),
			new LuaField("AppName", get_AppName, set_AppName),
			new LuaField("AppPrefix", get_AppPrefix, set_AppPrefix),
			new LuaField("ExtName", get_ExtName, set_ExtName),
			new LuaField("AssetDirname", get_AssetDirname, set_AssetDirname),
			new LuaField("BytesExt", get_BytesExt, set_BytesExt),
			new LuaField("WebUrl", get_WebUrl, set_WebUrl),
			new LuaField("SocketPort", get_SocketPort, set_SocketPort),
			new LuaField("SocketAddress", get_SocketAddress, set_SocketAddress),
			new LuaField("Host_Upload_Release", get_Host_Upload_Release, set_Host_Upload_Release),
			new LuaField("Host_Upload_Develop", get_Host_Upload_Develop, set_Host_Upload_Develop),
			new LuaField("LuaBytesRoot", get_LuaBytesRoot, set_LuaBytesRoot),
			new LuaField("SourcePath", get_SourcePath, set_SourcePath),
			new LuaField("LuaWrapPath", get_LuaWrapPath, set_LuaWrapPath),
			new LuaField("LuaBinderPath", get_LuaBinderPath, set_LuaBinderPath),
			new LuaField("DelegateFactoryPath", get_DelegateFactoryPath, set_DelegateFactoryPath),
			new LuaField("GameConstFileName", get_GameConstFileName, set_GameConstFileName),
			new LuaField("AssetlistNameForResource", get_AssetlistNameForResource, set_AssetlistNameForResource),
			new LuaField("ResolutionProgressive", get_ResolutionProgressive, set_ResolutionProgressive),
			new LuaField("NetWorkTimeOut", get_NetWorkTimeOut, set_NetWorkTimeOut),
			new LuaField("CenterName", get_CenterName, set_CenterName),
			new LuaField("Host_Upload", get_Host_Upload, null),
			new LuaField("Platform_ServerFileName", get_Platform_ServerFileName, null),
			new LuaField("Platform_VersionFileName", get_Platform_VersionFileName, null),
			new LuaField("Platform_AssetlistNameForStreaming", get_Platform_AssetlistNameForStreaming, null),
			new LuaField("AppVersion", get_AppVersion, set_AppVersion),
			new LuaField("Version", get_Version, set_Version),
			new LuaField("ServerID", get_ServerID, set_ServerID),
		};

		LuaScriptMgr.RegisterLib(L, "Games.GameConst", typeof(Games.GameConst), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_GameConst(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.GameConst obj = new Games.GameConst();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.GameConst.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.GameConst);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_WarDevelopMode(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.WarDevelopMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OfflineTest(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.OfflineTest);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CleanupDataPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.CleanupDataPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DebugMode(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.DebugMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DevelopMode(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.DevelopMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TimerInterval(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.TimerInterval);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GameFrameRate(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.GameFrameRate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_VisiableFPS(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.VisiableFPS);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UsePbc(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.UsePbc);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UseLpeg(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.UseLpeg);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UsePbLua(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.UsePbLua);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UseCJson(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.UseCJson);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UseSproto(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.UseSproto);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaEncode(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.LuaEncode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UserId(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.UserId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppName(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.AppName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppPrefix(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.AppPrefix);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ExtName(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.ExtName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AssetDirname(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.AssetDirname);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BytesExt(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.BytesExt);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_WebUrl(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.WebUrl);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SocketPort(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.SocketPort);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SocketAddress(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.SocketAddress);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Host_Upload_Release(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.Host_Upload_Release);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Host_Upload_Develop(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.Host_Upload_Develop);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaBytesRoot(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.LuaBytesRoot);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SourcePath(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.SourcePath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaWrapPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.LuaWrapPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaBinderPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.LuaBinderPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DelegateFactoryPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.DelegateFactoryPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GameConstFileName(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.GameConstFileName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AssetlistNameForResource(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.AssetlistNameForResource);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ResolutionProgressive(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.ResolutionProgressive);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NetWorkTimeOut(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.NetWorkTimeOut);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CenterName(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.CenterName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Host_Upload(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.Host_Upload);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Platform_ServerFileName(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.Platform_ServerFileName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Platform_VersionFileName(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.Platform_VersionFileName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Platform_AssetlistNameForStreaming(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.Platform_AssetlistNameForStreaming);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppVersion(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.AppVersion);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Version(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.Version);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ServerID(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.GameConst.ServerID);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_WarDevelopMode(IntPtr L)
	{
		Games.GameConst.WarDevelopMode = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OfflineTest(IntPtr L)
	{
		Games.GameConst.OfflineTest = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CleanupDataPath(IntPtr L)
	{
		Games.GameConst.CleanupDataPath = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_DebugMode(IntPtr L)
	{
		Games.GameConst.DebugMode = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_DevelopMode(IntPtr L)
	{
		Games.GameConst.DevelopMode = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_TimerInterval(IntPtr L)
	{
		Games.GameConst.TimerInterval = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_GameFrameRate(IntPtr L)
	{
		Games.GameConst.GameFrameRate = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_VisiableFPS(IntPtr L)
	{
		Games.GameConst.VisiableFPS = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_UsePbc(IntPtr L)
	{
		Games.GameConst.UsePbc = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_UseLpeg(IntPtr L)
	{
		Games.GameConst.UseLpeg = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_UsePbLua(IntPtr L)
	{
		Games.GameConst.UsePbLua = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_UseCJson(IntPtr L)
	{
		Games.GameConst.UseCJson = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_UseSproto(IntPtr L)
	{
		Games.GameConst.UseSproto = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_LuaEncode(IntPtr L)
	{
		Games.GameConst.LuaEncode = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_UserId(IntPtr L)
	{
		Games.GameConst.UserId = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AppName(IntPtr L)
	{
		Games.GameConst.AppName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AppPrefix(IntPtr L)
	{
		Games.GameConst.AppPrefix = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ExtName(IntPtr L)
	{
		Games.GameConst.ExtName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AssetDirname(IntPtr L)
	{
		Games.GameConst.AssetDirname = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_BytesExt(IntPtr L)
	{
		Games.GameConst.BytesExt = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_WebUrl(IntPtr L)
	{
		Games.GameConst.WebUrl = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SocketPort(IntPtr L)
	{
		Games.GameConst.SocketPort = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SocketAddress(IntPtr L)
	{
		Games.GameConst.SocketAddress = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Host_Upload_Release(IntPtr L)
	{
		Games.GameConst.Host_Upload_Release = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Host_Upload_Develop(IntPtr L)
	{
		Games.GameConst.Host_Upload_Develop = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_LuaBytesRoot(IntPtr L)
	{
		Games.GameConst.LuaBytesRoot = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SourcePath(IntPtr L)
	{
		Games.GameConst.SourcePath = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_LuaWrapPath(IntPtr L)
	{
		Games.GameConst.LuaWrapPath = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_LuaBinderPath(IntPtr L)
	{
		Games.GameConst.LuaBinderPath = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_DelegateFactoryPath(IntPtr L)
	{
		Games.GameConst.DelegateFactoryPath = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_GameConstFileName(IntPtr L)
	{
		Games.GameConst.GameConstFileName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AssetlistNameForResource(IntPtr L)
	{
		Games.GameConst.AssetlistNameForResource = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ResolutionProgressive(IntPtr L)
	{
		Games.GameConst.ResolutionProgressive = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_NetWorkTimeOut(IntPtr L)
	{
		Games.GameConst.NetWorkTimeOut = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CenterName(IntPtr L)
	{
		Games.GameConst.CenterName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AppVersion(IntPtr L)
	{
		Games.GameConst.AppVersion = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Version(IntPtr L)
	{
		Games.GameConst.Version = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ServerID(IntPtr L)
	{
		Games.GameConst.ServerID = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

