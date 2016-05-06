using System;
using UnityEngine;
using LuaInterface;

public class TextAnchorWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("UpperLeft", GetUpperLeft),
		new LuaMethod("UpperCenter", GetUpperCenter),
		new LuaMethod("UpperRight", GetUpperRight),
		new LuaMethod("MiddleLeft", GetMiddleLeft),
		new LuaMethod("MiddleCenter", GetMiddleCenter),
		new LuaMethod("MiddleRight", GetMiddleRight),
		new LuaMethod("LowerLeft", GetLowerLeft),
		new LuaMethod("LowerCenter", GetLowerCenter),
		new LuaMethod("LowerRight", GetLowerRight),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.TextAnchor", typeof(UnityEngine.TextAnchor), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetUpperLeft(IntPtr L)
	{
		LuaScriptMgr.Push(L, TextAnchor.UpperLeft);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetUpperCenter(IntPtr L)
	{
		LuaScriptMgr.Push(L, TextAnchor.UpperCenter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetUpperRight(IntPtr L)
	{
		LuaScriptMgr.Push(L, TextAnchor.UpperRight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMiddleLeft(IntPtr L)
	{
		LuaScriptMgr.Push(L, TextAnchor.MiddleLeft);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMiddleCenter(IntPtr L)
	{
		LuaScriptMgr.Push(L, TextAnchor.MiddleCenter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMiddleRight(IntPtr L)
	{
		LuaScriptMgr.Push(L, TextAnchor.MiddleRight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLowerLeft(IntPtr L)
	{
		LuaScriptMgr.Push(L, TextAnchor.LowerLeft);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLowerCenter(IntPtr L)
	{
		LuaScriptMgr.Push(L, TextAnchor.LowerCenter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLowerRight(IntPtr L)
	{
		LuaScriptMgr.Push(L, TextAnchor.LowerRight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		TextAnchor o = (TextAnchor)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

