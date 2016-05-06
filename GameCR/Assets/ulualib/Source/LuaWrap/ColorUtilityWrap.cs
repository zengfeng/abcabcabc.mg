using System;
using UnityEngine;
using LuaInterface;

public class ColorUtilityWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("TryParseHtmlString", TryParseHtmlString),
			new LuaMethod("ToHtmlStringRGB", ToHtmlStringRGB),
			new LuaMethod("ToHtmlStringRGBA", ToHtmlStringRGBA),
			new LuaMethod("New", _CreateColorUtility),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "UnityEngine.ColorUtility", typeof(ColorUtility), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateColorUtility(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			ColorUtility obj = new ColorUtility();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ColorUtility.New");
		}

		return 0;
	}

	static Type classType = typeof(ColorUtility);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TryParseHtmlString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Color arg1;
		bool o = ColorUtility.TryParseHtmlString(arg0,out arg1);
		LuaScriptMgr.Push(L, o);
		LuaScriptMgr.Push(L, arg1);
		return 2;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToHtmlStringRGB(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Color arg0 = LuaScriptMgr.GetColor(L, 1);
		string o = ColorUtility.ToHtmlStringRGB(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToHtmlStringRGBA(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Color arg0 = LuaScriptMgr.GetColor(L, 1);
		string o = ColorUtility.ToHtmlStringRGBA(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

