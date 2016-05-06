using System;
using System.Collections;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CrashReporterWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("AppendLuaCrash", AppendLuaCrash),
			new LuaMethod("SendCrashReport", SendCrashReport),
			new LuaMethod("New", _CreateCrashReporter),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", get_Instance, null),
			new LuaField("filePath", get_filePath, null),
		};

		LuaScriptMgr.RegisterLib(L, "CrashReporter", typeof(CrashReporter), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCrashReporter(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CrashReporter class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CrashReporter);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, CrashReporter.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_filePath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CrashReporter obj = (CrashReporter)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name filePath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index filePath on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.filePath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AppendLuaCrash(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CrashReporter obj = (CrashReporter)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CrashReporter");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.AppendLuaCrash(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendCrashReport(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CrashReporter obj = (CrashReporter)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CrashReporter");
		IEnumerator o = obj.SendCrashReport();
		LuaScriptMgr.Push(L, o);
		return 1;
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

