using System;
using LuaInterface;

public class DG_Tweening_ScrambleModeWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("None", GetNone),
		new LuaMethod("All", GetAll),
		new LuaMethod("Uppercase", GetUppercase),
		new LuaMethod("Lowercase", GetLowercase),
		new LuaMethod("Numerals", GetNumerals),
		new LuaMethod("Custom", GetCustom),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "DG.Tweening.ScrambleMode", typeof(DG.Tweening.ScrambleMode), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNone(IntPtr L)
	{
		LuaScriptMgr.Push(L, DG.Tweening.ScrambleMode.None);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAll(IntPtr L)
	{
		LuaScriptMgr.Push(L, DG.Tweening.ScrambleMode.All);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetUppercase(IntPtr L)
	{
		LuaScriptMgr.Push(L, DG.Tweening.ScrambleMode.Uppercase);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLowercase(IntPtr L)
	{
		LuaScriptMgr.Push(L, DG.Tweening.ScrambleMode.Lowercase);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNumerals(IntPtr L)
	{
		LuaScriptMgr.Push(L, DG.Tweening.ScrambleMode.Numerals);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetCustom(IntPtr L)
	{
		LuaScriptMgr.Push(L, DG.Tweening.ScrambleMode.Custom);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		DG.Tweening.ScrambleMode o = (DG.Tweening.ScrambleMode)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

