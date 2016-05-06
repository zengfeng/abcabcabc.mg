using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CC_UI_BaseUIWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateCC_UI_BaseUI),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("rectTransform", get_rectTransform, set_rectTransform),
		};

		LuaScriptMgr.RegisterLib(L, "CC.UI.BaseUI", typeof(CC.UI.BaseUI), regs, fields, typeof(UnityEngine.EventSystems.UIBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCC_UI_BaseUI(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CC.UI.BaseUI class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CC.UI.BaseUI);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rectTransform(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.BaseUI obj = (CC.UI.BaseUI)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rectTransform");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rectTransform on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.rectTransform);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rectTransform(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.BaseUI obj = (CC.UI.BaseUI)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rectTransform");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rectTransform on a nil value");
			}
		}

		obj.rectTransform = (RectTransform)LuaScriptMgr.GetUnityObject(L, 3, typeof(RectTransform));
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

