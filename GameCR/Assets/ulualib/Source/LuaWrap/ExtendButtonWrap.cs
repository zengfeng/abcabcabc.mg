using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class ExtendButtonWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("PlayAnimatorDown", PlayAnimatorDown),
			new LuaMethod("PlayAnimatorUp", PlayAnimatorUp),
			new LuaMethod("New", _CreateExtendButton),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("animator", get_animator, set_animator),
			new LuaField("autoPlayAnimator", get_autoPlayAnimator, set_autoPlayAnimator),
			new LuaField("touchCallback", get_touchCallback, set_touchCallback),
		};

		LuaScriptMgr.RegisterLib(L, "ExtendButton", typeof(ExtendButton), regs, fields, typeof(UnityEngine.UI.Button));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateExtendButton(IntPtr L)
	{
		LuaDLL.luaL_error(L, "ExtendButton class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(ExtendButton);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_animator(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ExtendButton obj = (ExtendButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animator");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animator on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.animator);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_autoPlayAnimator(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ExtendButton obj = (ExtendButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name autoPlayAnimator");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index autoPlayAnimator on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.autoPlayAnimator);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_touchCallback(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ExtendButton obj = (ExtendButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name touchCallback");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index touchCallback on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.touchCallback);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_animator(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ExtendButton obj = (ExtendButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animator");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animator on a nil value");
			}
		}

		obj.animator = (Animator)LuaScriptMgr.GetUnityObject(L, 3, typeof(Animator));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_autoPlayAnimator(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ExtendButton obj = (ExtendButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name autoPlayAnimator");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index autoPlayAnimator on a nil value");
			}
		}

		obj.autoPlayAnimator = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_touchCallback(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ExtendButton obj = (ExtendButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name touchCallback");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index touchCallback on a nil value");
			}
		}

		obj.touchCallback = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayAnimatorDown(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ExtendButton obj = (ExtendButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ExtendButton");
		obj.PlayAnimatorDown();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayAnimatorUp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ExtendButton obj = (ExtendButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ExtendButton");
		obj.PlayAnimatorUp();
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

