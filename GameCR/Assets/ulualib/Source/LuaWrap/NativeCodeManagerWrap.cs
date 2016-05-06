using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class NativeCodeManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("AddNativeFunctionCallback", AddNativeFunctionCallback),
			new LuaMethod("SetAppInfo", SetAppInfo),
			new LuaMethod("InitCenter", InitCenter),
			new LuaMethod("LoginCenter", LoginCenter),
			new LuaMethod("AppendQQGroup", AppendQQGroup),
			new LuaMethod("GetUserInfo", GetUserInfo),
			new LuaMethod("New", _CreateNativeCodeManager),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", get_Instance, null),
		};

		LuaScriptMgr.RegisterLib(L, "NativeCodeManager", typeof(NativeCodeManager), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateNativeCodeManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "NativeCodeManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(NativeCodeManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, NativeCodeManager.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddNativeFunctionCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		NativeCodeManager obj = (NativeCodeManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "NativeCodeManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Action<string[]> arg1 = null;
		LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

		if (funcType3 != LuaTypes.LUA_TFUNCTION)
		{
			 arg1 = (Action<string[]>)LuaScriptMgr.GetNetObject(L, 3, typeof(Action<string[]>));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
			arg1 = (param0) =>
			{
				int top = func.BeginPCall();
				LuaScriptMgr.PushArray(L, param0);
				func.PCall(top, 1);
				func.EndPCall(top);
			};
		}

		obj.AddNativeFunctionCallback(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetAppInfo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		NativeCodeManager obj = (NativeCodeManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "NativeCodeManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		obj.SetAppInfo(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitCenter(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		NativeCodeManager obj = (NativeCodeManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "NativeCodeManager");
		obj.InitCenter();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoginCenter(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		NativeCodeManager obj = (NativeCodeManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "NativeCodeManager");
		obj.LoginCenter();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AppendQQGroup(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		NativeCodeManager obj = (NativeCodeManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "NativeCodeManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.AppendQQGroup(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetUserInfo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		NativeCodeManager obj = (NativeCodeManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "NativeCodeManager");
		string o = obj.GetUserInfo();
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

