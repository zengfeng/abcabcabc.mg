using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class ActiveGroupWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("SelectByUid", SelectByUid),
			new LuaMethod("AddActiveButton", AddActiveButton),
			new LuaMethod("SetChangeCallback", SetChangeCallback),
			new LuaMethod("New", _CreateActiveGroup),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Select", get_Select, set_Select),
		};

		LuaScriptMgr.RegisterLib(L, "ActiveGroup", typeof(ActiveGroup), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateActiveGroup(IntPtr L)
	{
		LuaDLL.luaL_error(L, "ActiveGroup class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(ActiveGroup);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Select(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ActiveGroup obj = (ActiveGroup)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Select");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Select on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.Select);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Select(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ActiveGroup obj = (ActiveGroup)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Select");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Select on a nil value");
			}
		}

		obj.Select = (ActiveButton)LuaScriptMgr.GetUnityObject(L, 3, typeof(ActiveButton));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SelectByUid(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ActiveGroup obj = (ActiveGroup)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ActiveGroup");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.SelectByUid(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddActiveButton(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ActiveGroup obj = (ActiveGroup)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ActiveGroup");
		ActiveButton arg0 = (ActiveButton)LuaScriptMgr.GetUnityObject(L, 2, typeof(ActiveButton));
		obj.AddActiveButton(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetChangeCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ActiveGroup obj = (ActiveGroup)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ActiveGroup");
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 2);
		obj.SetChangeCallback(arg0);
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

