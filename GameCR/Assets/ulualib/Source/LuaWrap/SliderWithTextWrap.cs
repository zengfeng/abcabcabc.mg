using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class SliderWithTextWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("SetValue", SetValue),
			new LuaMethod("TweenTo", TweenTo),
			new LuaMethod("New", _CreateSliderWithText),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("text", get_text, set_text),
		};

		LuaScriptMgr.RegisterLib(L, "SliderWithText", typeof(SliderWithText), regs, fields, typeof(UnityEngine.UI.Slider));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSliderWithText(IntPtr L)
	{
		LuaDLL.luaL_error(L, "SliderWithText class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(SliderWithText);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_text(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SliderWithText obj = (SliderWithText)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name text");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index text on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.text);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_text(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SliderWithText obj = (SliderWithText)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name text");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index text on a nil value");
			}
		}

		obj.text = (UnityEngine.UI.Text)LuaScriptMgr.GetUnityObject(L, 3, typeof(UnityEngine.UI.Text));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SliderWithText obj = (SliderWithText)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SliderWithText");
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		obj.SetValue(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TweenTo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		SliderWithText obj = (SliderWithText)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SliderWithText");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		obj.TweenTo(arg0,arg1);
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

