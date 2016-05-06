using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class SimpleFramework_LuaBehaviourWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("AddClick", AddClick),
			new LuaMethod("ClearClick", ClearClick),
			new LuaMethod("AddFrameEndCall", AddFrameEndCall),
			new LuaMethod("New", _CreateSimpleFramework_LuaBehaviour),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "SimpleFramework.LuaBehaviour", typeof(SimpleFramework.LuaBehaviour), regs, fields, typeof(SimpleFramework.BehaviourBase));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSimpleFramework_LuaBehaviour(IntPtr L)
	{
		LuaDLL.luaL_error(L, "SimpleFramework.LuaBehaviour class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(SimpleFramework.LuaBehaviour);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddClick(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(SimpleFramework.LuaBehaviour), typeof(string), typeof(LuaInterface.LuaFunction)))
		{
			SimpleFramework.LuaBehaviour obj = (SimpleFramework.LuaBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SimpleFramework.LuaBehaviour");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			LuaFunction arg1 = LuaScriptMgr.ToLuaFunction(L, 3);
			obj.AddClick(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(SimpleFramework.LuaBehaviour), typeof(GameObject), typeof(LuaInterface.LuaFunction)))
		{
			SimpleFramework.LuaBehaviour obj = (SimpleFramework.LuaBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SimpleFramework.LuaBehaviour");
			GameObject arg0 = (GameObject)LuaScriptMgr.GetLuaObject(L, 2);
			LuaFunction arg1 = LuaScriptMgr.ToLuaFunction(L, 3);
			obj.AddClick(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SimpleFramework.LuaBehaviour.AddClick");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SimpleFramework.LuaBehaviour obj = (SimpleFramework.LuaBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SimpleFramework.LuaBehaviour");
		obj.ClearClick();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddFrameEndCall(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SimpleFramework.LuaBehaviour obj = (SimpleFramework.LuaBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SimpleFramework.LuaBehaviour");
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 2);
		obj.AddFrameEndCall(arg0);
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

