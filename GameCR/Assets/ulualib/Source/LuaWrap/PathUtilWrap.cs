using System;
using UnityEngine;
using LuaInterface;

public class PathUtilWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetPlatformDirectoryName", GetPlatformDirectoryName),
			new LuaMethod("GetPlatformDirectory", GetPlatformDirectory),
			new LuaMethod("DeleteDirectory", DeleteDirectory),
			new LuaMethod("GetDirectoryName", GetDirectoryName),
			new LuaMethod("CheckPath", CheckPath),
			new LuaMethod("ChangeExtension", ChangeExtension),
			new LuaMethod("md5", md5),
			new LuaMethod("md5file", md5file),
			new LuaMethod("FindDirectory", FindDirectory),
			new LuaMethod("New", _CreatePathUtil),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("PlatformDirector", get_PlatformDirector, null),
			new LuaField("AppDataPath", get_AppDataPath, null),
			new LuaField("DataPath", get_DataPath, null),
			new LuaField("UserDataPath", get_UserDataPath, null),
			new LuaField("AppDataUrl", get_AppDataUrl, null),
			new LuaField("DataUrl", get_DataUrl, null),
			new LuaField("UserDataUrl", get_UserDataUrl, null),
			new LuaField("ServerUrl", get_ServerUrl, null),
		};

		LuaScriptMgr.RegisterLib(L, "PathUtil", typeof(PathUtil), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreatePathUtil(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			PathUtil obj = new PathUtil();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: PathUtil.New");
		}

		return 0;
	}

	static Type classType = typeof(PathUtil);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_PlatformDirector(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, PathUtil.PlatformDirector);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppDataPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, PathUtil.AppDataPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DataPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, PathUtil.DataPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UserDataPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, PathUtil.UserDataPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppDataUrl(IntPtr L)
	{
		LuaScriptMgr.Push(L, PathUtil.AppDataUrl);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DataUrl(IntPtr L)
	{
		LuaScriptMgr.Push(L, PathUtil.DataUrl);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UserDataUrl(IntPtr L)
	{
		LuaScriptMgr.Push(L, PathUtil.UserDataUrl);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ServerUrl(IntPtr L)
	{
		LuaScriptMgr.Push(L, PathUtil.ServerUrl);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPlatformDirectoryName(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		RuntimePlatform arg0 = (RuntimePlatform)LuaScriptMgr.GetNetObject(L, 1, typeof(RuntimePlatform));
		bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
		string o = PathUtil.GetPlatformDirectoryName(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPlatformDirectory(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		RuntimePlatform arg0 = (RuntimePlatform)LuaScriptMgr.GetNetObject(L, 1, typeof(RuntimePlatform));
		bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
		string o = PathUtil.GetPlatformDirectory(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DeleteDirectory(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		PathUtil.DeleteDirectory(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDirectoryName(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		string o = PathUtil.GetDirectoryName(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CheckPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
		PathUtil.CheckPath(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ChangeExtension(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		string o = PathUtil.ChangeExtension(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int md5(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = PathUtil.md5(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int md5file(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = PathUtil.md5file(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindDirectory(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string[] o = PathUtil.FindDirectory(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}
}

