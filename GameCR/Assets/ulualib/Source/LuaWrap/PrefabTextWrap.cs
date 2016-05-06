using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class PrefabTextWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("SetTextColor", SetTextColor),
			new LuaMethod("SetToOriginColor", SetToOriginColor),
			new LuaMethod("RemoveComponent", RemoveComponent),
			new LuaMethod("New", _CreatePrefabText),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("usePrefab", get_usePrefab, set_usePrefab),
			new LuaField("prefabText", get_prefabText, set_prefabText),
		};

		LuaScriptMgr.RegisterLib(L, "PrefabText", typeof(PrefabText), regs, fields, typeof(UnityEngine.UI.Text));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreatePrefabText(IntPtr L)
	{
		LuaDLL.luaL_error(L, "PrefabText class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(PrefabText);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_usePrefab(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PrefabText obj = (PrefabText)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name usePrefab");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index usePrefab on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.usePrefab);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_prefabText(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PrefabText obj = (PrefabText)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name prefabText");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index prefabText on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.prefabText);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_usePrefab(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PrefabText obj = (PrefabText)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name usePrefab");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index usePrefab on a nil value");
			}
		}

		obj.usePrefab = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_prefabText(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PrefabText obj = (PrefabText)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name prefabText");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index prefabText on a nil value");
			}
		}

		obj.prefabText = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTextColor(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		PrefabText obj = (PrefabText)LuaScriptMgr.GetUnityObjectSelf(L, 1, "PrefabText");
		Color arg0 = LuaScriptMgr.GetColor(L, 2);
		obj.SetTextColor(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetToOriginColor(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		PrefabText obj = (PrefabText)LuaScriptMgr.GetUnityObjectSelf(L, 1, "PrefabText");
		obj.SetToOriginColor();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveComponent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		PrefabText obj = (PrefabText)LuaScriptMgr.GetUnityObjectSelf(L, 1, "PrefabText");
		obj.RemoveComponent();
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

