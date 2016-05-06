using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class ActiveButtonWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("OnUnActive", OnUnActive),
			new LuaMethod("OnActive", OnActive),
			new LuaMethod("New", _CreateActiveButton),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("uid", get_uid, set_uid),
			new LuaField("activeButton", get_activeButton, set_activeButton),
			new LuaField("unactiveButton", get_unactiveButton, set_unactiveButton),
			new LuaField("group", get_group, set_group),
		};

		LuaScriptMgr.RegisterLib(L, "ActiveButton", typeof(ActiveButton), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateActiveButton(IntPtr L)
	{
		LuaDLL.luaL_error(L, "ActiveButton class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(ActiveButton);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uid(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ActiveButton obj = (ActiveButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uid");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uid on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.uid);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_activeButton(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ActiveButton obj = (ActiveButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name activeButton");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index activeButton on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.activeButton);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_unactiveButton(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ActiveButton obj = (ActiveButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name unactiveButton");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index unactiveButton on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.unactiveButton);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_group(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ActiveButton obj = (ActiveButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name group");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index group on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.group);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uid(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ActiveButton obj = (ActiveButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uid");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uid on a nil value");
			}
		}

		obj.uid = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_activeButton(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ActiveButton obj = (ActiveButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name activeButton");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index activeButton on a nil value");
			}
		}

		obj.activeButton = (UnityEngine.UI.Button)LuaScriptMgr.GetUnityObject(L, 3, typeof(UnityEngine.UI.Button));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_unactiveButton(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ActiveButton obj = (ActiveButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name unactiveButton");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index unactiveButton on a nil value");
			}
		}

		obj.unactiveButton = (UnityEngine.UI.Button)LuaScriptMgr.GetUnityObject(L, 3, typeof(UnityEngine.UI.Button));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_group(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ActiveButton obj = (ActiveButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name group");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index group on a nil value");
			}
		}

		obj.group = (ActiveGroup)LuaScriptMgr.GetUnityObject(L, 3, typeof(ActiveGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnUnActive(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ActiveButton obj = (ActiveButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ActiveButton");
		obj.OnUnActive();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnActive(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ActiveButton obj = (ActiveButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ActiveButton");
		obj.OnActive();
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

