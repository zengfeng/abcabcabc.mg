using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CC_UI_TabGroupWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("SetSelect", SetSelect),
			new LuaMethod("GetSelect", GetSelect),
			new LuaMethod("SetMustSelectOne", SetMustSelectOne),
			new LuaMethod("GetMustSelectOne", GetMustSelectOne),
			new LuaMethod("AddChange", AddChange),
			new LuaMethod("ClearChange", ClearChange),
			new LuaMethod("New", _CreateCC_UI_TabGroup),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("onChange", get_onChange, set_onChange),
			new LuaField("select", get_select, set_select),
			new LuaField("everySendEvent", get_everySendEvent, set_everySendEvent),
			new LuaField("mustSelectOne", get_mustSelectOne, set_mustSelectOne),
			new LuaField("onValueChange", get_onValueChange, null),
		};

		LuaScriptMgr.RegisterLib(L, "CC.UI.TabGroup", typeof(CC.UI.TabGroup), regs, fields, typeof(CC.UI.BaseUI));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCC_UI_TabGroup(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CC.UI.TabGroup class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CC.UI.TabGroup);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onChange(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabGroup obj = (CC.UI.TabGroup)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onChange");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onChange on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.onChange);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_select(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabGroup obj = (CC.UI.TabGroup)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name select");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index select on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.select);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_everySendEvent(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabGroup obj = (CC.UI.TabGroup)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name everySendEvent");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index everySendEvent on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.everySendEvent);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mustSelectOne(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabGroup obj = (CC.UI.TabGroup)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mustSelectOne");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mustSelectOne on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mustSelectOne);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onValueChange(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabGroup obj = (CC.UI.TabGroup)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onValueChange");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onValueChange on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.onValueChange);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onChange(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabGroup obj = (CC.UI.TabGroup)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onChange");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onChange on a nil value");
			}
		}

		LuaTypes funcType = LuaDLL.lua_type(L, 3);

		if (funcType != LuaTypes.LUA_TFUNCTION)
		{
			obj.onChange = (Action<CC.UI.TabButton>)LuaScriptMgr.GetNetObject(L, 3, typeof(Action<CC.UI.TabButton>));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			obj.onChange = (param0) =>
			{
				int top = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				func.PCall(top, 1);
				func.EndPCall(top);
			};
		}
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_select(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabGroup obj = (CC.UI.TabGroup)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name select");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index select on a nil value");
			}
		}

		obj.select = (CC.UI.TabButton)LuaScriptMgr.GetUnityObject(L, 3, typeof(CC.UI.TabButton));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_everySendEvent(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabGroup obj = (CC.UI.TabGroup)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name everySendEvent");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index everySendEvent on a nil value");
			}
		}

		obj.everySendEvent = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mustSelectOne(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabGroup obj = (CC.UI.TabGroup)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mustSelectOne");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mustSelectOne on a nil value");
			}
		}

		obj.mustSelectOne = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetSelect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.TabGroup obj = (CC.UI.TabGroup)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabGroup");
		CC.UI.TabButton arg0 = (CC.UI.TabButton)LuaScriptMgr.GetUnityObject(L, 2, typeof(CC.UI.TabButton));
		obj.SetSelect(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSelect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.UI.TabGroup obj = (CC.UI.TabGroup)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabGroup");
		CC.UI.TabButton o = obj.GetSelect();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetMustSelectOne(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.TabGroup obj = (CC.UI.TabGroup)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabGroup");
		bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
		obj.SetMustSelectOne(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMustSelectOne(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.UI.TabGroup obj = (CC.UI.TabGroup)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabGroup");
		bool o = obj.GetMustSelectOne();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddChange(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.TabGroup obj = (CC.UI.TabGroup)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabGroup");
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 2);
		obj.AddChange(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearChange(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.UI.TabGroup obj = (CC.UI.TabGroup)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabGroup");
		obj.ClearChange();
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

