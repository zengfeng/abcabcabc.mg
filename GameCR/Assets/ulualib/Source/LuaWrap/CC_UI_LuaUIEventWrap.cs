using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CC_UI_LuaUIEventWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("OnPointerDown", OnPointerDown),
			new LuaMethod("AddDown", AddDown),
			new LuaMethod("ClearDown", ClearDown),
			new LuaMethod("OnPointerUp", OnPointerUp),
			new LuaMethod("AddUp", AddUp),
			new LuaMethod("ClearUp", ClearUp),
			new LuaMethod("OnPointerClick", OnPointerClick),
			new LuaMethod("AddClick", AddClick),
			new LuaMethod("ClearClick", ClearClick),
			new LuaMethod("OnEnable", OnEnable),
			new LuaMethod("AddEnable", AddEnable),
			new LuaMethod("ClearEnable", ClearEnable),
			new LuaMethod("New", _CreateCC_UI_LuaUIEvent),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "CC.UI.LuaUIEvent", typeof(CC.UI.LuaUIEvent), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCC_UI_LuaUIEvent(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CC.UI.LuaUIEvent class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CC.UI.LuaUIEvent);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerDown(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.LuaUIEvent obj = (CC.UI.LuaUIEvent)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.LuaUIEvent");
		UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
		obj.OnPointerDown(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddDown(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.LuaUIEvent obj = (CC.UI.LuaUIEvent)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.LuaUIEvent");
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 2);
		obj.AddDown(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearDown(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.UI.LuaUIEvent obj = (CC.UI.LuaUIEvent)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.LuaUIEvent");
		obj.ClearDown();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerUp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.LuaUIEvent obj = (CC.UI.LuaUIEvent)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.LuaUIEvent");
		UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
		obj.OnPointerUp(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddUp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.LuaUIEvent obj = (CC.UI.LuaUIEvent)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.LuaUIEvent");
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 2);
		obj.AddUp(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearUp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.UI.LuaUIEvent obj = (CC.UI.LuaUIEvent)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.LuaUIEvent");
		obj.ClearUp();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.LuaUIEvent obj = (CC.UI.LuaUIEvent)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.LuaUIEvent");
		UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
		obj.OnPointerClick(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.LuaUIEvent obj = (CC.UI.LuaUIEvent)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.LuaUIEvent");
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 2);
		obj.AddClick(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.UI.LuaUIEvent obj = (CC.UI.LuaUIEvent)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.LuaUIEvent");
		obj.ClearClick();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnEnable(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.UI.LuaUIEvent obj = (CC.UI.LuaUIEvent)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.LuaUIEvent");
		obj.OnEnable();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddEnable(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.LuaUIEvent obj = (CC.UI.LuaUIEvent)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.LuaUIEvent");
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 2);
		obj.AddEnable(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearEnable(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.UI.LuaUIEvent obj = (CC.UI.LuaUIEvent)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.LuaUIEvent");
		obj.ClearEnable();
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

