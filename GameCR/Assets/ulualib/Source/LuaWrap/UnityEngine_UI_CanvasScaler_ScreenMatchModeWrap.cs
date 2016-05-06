using System;
using LuaInterface;

public class UnityEngine_UI_CanvasScaler_ScreenMatchModeWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("MatchWidthOrHeight", GetMatchWidthOrHeight),
		new LuaMethod("Expand", GetExpand),
		new LuaMethod("Shrink", GetShrink),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.UI.CanvasScaler.ScreenMatchMode", typeof(UnityEngine.UI.CanvasScaler.ScreenMatchMode), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMatchWidthOrHeight(IntPtr L)
	{
		LuaScriptMgr.Push(L, UnityEngine.UI.CanvasScaler.ScreenMatchMode.MatchWidthOrHeight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetExpand(IntPtr L)
	{
		LuaScriptMgr.Push(L, UnityEngine.UI.CanvasScaler.ScreenMatchMode.Expand);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetShrink(IntPtr L)
	{
		LuaScriptMgr.Push(L, UnityEngine.UI.CanvasScaler.ScreenMatchMode.Shrink);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		UnityEngine.UI.CanvasScaler.ScreenMatchMode o = (UnityEngine.UI.CanvasScaler.ScreenMatchMode)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

