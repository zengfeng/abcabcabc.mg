using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class UnityEngine_UI_CanvasScalerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateUnityEngine_UI_CanvasScaler),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("uiScaleMode", get_uiScaleMode, set_uiScaleMode),
			new LuaField("referencePixelsPerUnit", get_referencePixelsPerUnit, set_referencePixelsPerUnit),
			new LuaField("scaleFactor", get_scaleFactor, set_scaleFactor),
			new LuaField("referenceResolution", get_referenceResolution, set_referenceResolution),
			new LuaField("screenMatchMode", get_screenMatchMode, set_screenMatchMode),
			new LuaField("matchWidthOrHeight", get_matchWidthOrHeight, set_matchWidthOrHeight),
			new LuaField("physicalUnit", get_physicalUnit, set_physicalUnit),
			new LuaField("fallbackScreenDPI", get_fallbackScreenDPI, set_fallbackScreenDPI),
			new LuaField("defaultSpriteDPI", get_defaultSpriteDPI, set_defaultSpriteDPI),
			new LuaField("dynamicPixelsPerUnit", get_dynamicPixelsPerUnit, set_dynamicPixelsPerUnit),
		};

		LuaScriptMgr.RegisterLib(L, "UnityEngine.UI.CanvasScaler", typeof(UnityEngine.UI.CanvasScaler), regs, fields, typeof(UnityEngine.EventSystems.UIBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_UI_CanvasScaler(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UnityEngine.UI.CanvasScaler class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(UnityEngine.UI.CanvasScaler);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uiScaleMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uiScaleMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uiScaleMode on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.uiScaleMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_referencePixelsPerUnit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name referencePixelsPerUnit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index referencePixelsPerUnit on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.referencePixelsPerUnit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_scaleFactor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scaleFactor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scaleFactor on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.scaleFactor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_referenceResolution(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name referenceResolution");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index referenceResolution on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.referenceResolution);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_screenMatchMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name screenMatchMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index screenMatchMode on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.screenMatchMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_matchWidthOrHeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name matchWidthOrHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index matchWidthOrHeight on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.matchWidthOrHeight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_physicalUnit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name physicalUnit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index physicalUnit on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.physicalUnit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fallbackScreenDPI(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fallbackScreenDPI");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fallbackScreenDPI on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.fallbackScreenDPI);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_defaultSpriteDPI(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name defaultSpriteDPI");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index defaultSpriteDPI on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.defaultSpriteDPI);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dynamicPixelsPerUnit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dynamicPixelsPerUnit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dynamicPixelsPerUnit on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.dynamicPixelsPerUnit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uiScaleMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uiScaleMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uiScaleMode on a nil value");
			}
		}

		obj.uiScaleMode = (UnityEngine.UI.CanvasScaler.ScaleMode)LuaScriptMgr.GetNetObject(L, 3, typeof(UnityEngine.UI.CanvasScaler.ScaleMode));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_referencePixelsPerUnit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name referencePixelsPerUnit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index referencePixelsPerUnit on a nil value");
			}
		}

		obj.referencePixelsPerUnit = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_scaleFactor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scaleFactor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scaleFactor on a nil value");
			}
		}

		obj.scaleFactor = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_referenceResolution(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name referenceResolution");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index referenceResolution on a nil value");
			}
		}

		obj.referenceResolution = LuaScriptMgr.GetVector2(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_screenMatchMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name screenMatchMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index screenMatchMode on a nil value");
			}
		}

		obj.screenMatchMode = (UnityEngine.UI.CanvasScaler.ScreenMatchMode)LuaScriptMgr.GetNetObject(L, 3, typeof(UnityEngine.UI.CanvasScaler.ScreenMatchMode));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_matchWidthOrHeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name matchWidthOrHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index matchWidthOrHeight on a nil value");
			}
		}

		obj.matchWidthOrHeight = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_physicalUnit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name physicalUnit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index physicalUnit on a nil value");
			}
		}

		obj.physicalUnit = (UnityEngine.UI.CanvasScaler.Unit)LuaScriptMgr.GetNetObject(L, 3, typeof(UnityEngine.UI.CanvasScaler.Unit));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fallbackScreenDPI(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fallbackScreenDPI");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fallbackScreenDPI on a nil value");
			}
		}

		obj.fallbackScreenDPI = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_defaultSpriteDPI(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name defaultSpriteDPI");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index defaultSpriteDPI on a nil value");
			}
		}

		obj.defaultSpriteDPI = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_dynamicPixelsPerUnit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.CanvasScaler obj = (UnityEngine.UI.CanvasScaler)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dynamicPixelsPerUnit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dynamicPixelsPerUnit on a nil value");
			}
		}

		obj.dynamicPixelsPerUnit = (float)LuaScriptMgr.GetNumber(L, 3);
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

