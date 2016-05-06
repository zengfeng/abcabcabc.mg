using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class ScrollZoomContainerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateScrollZoomContainer),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("target", get_target, set_target),
			new LuaField("ui", get_ui, set_ui),
			new LuaField("touchTexture", get_touchTexture, set_touchTexture),
			new LuaField("scaleToDrawDeltaTime", get_scaleToDrawDeltaTime, set_scaleToDrawDeltaTime),
			new LuaField("easeType", get_easeType, set_easeType),
			new LuaField("switchEaseType", get_switchEaseType, set_switchEaseType),
			new LuaField("dragAndZoomDivide", get_dragAndZoomDivide, set_dragAndZoomDivide),
			new LuaField("moveScale", get_moveScale, set_moveScale),
			new LuaField("zoomScale", get_zoomScale, set_zoomScale),
			new LuaField("tweenTime", get_tweenTime, set_tweenTime),
			new LuaField("minScale", get_minScale, set_minScale),
			new LuaField("maxScale", get_maxScale, set_maxScale),
			new LuaField("maxScaleCushion", get_maxScaleCushion, set_maxScaleCushion),
			new LuaField("sceneChangeDivide", get_sceneChangeDivide, set_sceneChangeDivide),
			new LuaField("sceneMoveTime", get_sceneMoveTime, set_sceneMoveTime),
			new LuaField("sceneScaleTime", get_sceneScaleTime, set_sceneScaleTime),
			new LuaField("zoomScaleOffset", get_zoomScaleOffset, set_zoomScaleOffset),
			new LuaField("uiDivide", get_uiDivide, set_uiDivide),
			new LuaField("uiScaleFactor", get_uiScaleFactor, set_uiScaleFactor),
		};

		LuaScriptMgr.RegisterLib(L, "ScrollZoomContainer", typeof(ScrollZoomContainer), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateScrollZoomContainer(IntPtr L)
	{
		LuaDLL.luaL_error(L, "ScrollZoomContainer class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(ScrollZoomContainer);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_target(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name target");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index target on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.target);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ui(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ui");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ui on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.ui);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_touchTexture(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name touchTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index touchTexture on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.touchTexture);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_scaleToDrawDeltaTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scaleToDrawDeltaTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scaleToDrawDeltaTime on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.scaleToDrawDeltaTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_easeType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name easeType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index easeType on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.easeType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_switchEaseType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name switchEaseType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index switchEaseType on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.switchEaseType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dragAndZoomDivide(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dragAndZoomDivide");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dragAndZoomDivide on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.dragAndZoomDivide);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_moveScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name moveScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index moveScale on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.moveScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_zoomScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name zoomScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index zoomScale on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.zoomScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tweenTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tweenTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tweenTime on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.tweenTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_minScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name minScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index minScale on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.minScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxScale on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.maxScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxScaleCushion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxScaleCushion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxScaleCushion on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.maxScaleCushion);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sceneChangeDivide(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sceneChangeDivide");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sceneChangeDivide on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.sceneChangeDivide);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sceneMoveTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sceneMoveTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sceneMoveTime on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.sceneMoveTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sceneScaleTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sceneScaleTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sceneScaleTime on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.sceneScaleTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_zoomScaleOffset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name zoomScaleOffset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index zoomScaleOffset on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.zoomScaleOffset);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uiDivide(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uiDivide");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uiDivide on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.uiDivide);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uiScaleFactor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uiScaleFactor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uiScaleFactor on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.uiScaleFactor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_target(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name target");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index target on a nil value");
			}
		}

		obj.target = (RectTransform)LuaScriptMgr.GetUnityObject(L, 3, typeof(RectTransform));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ui(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ui");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ui on a nil value");
			}
		}

		obj.ui = (RectTransform)LuaScriptMgr.GetUnityObject(L, 3, typeof(RectTransform));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_touchTexture(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name touchTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index touchTexture on a nil value");
			}
		}

		obj.touchTexture = (Texture2D)LuaScriptMgr.GetUnityObject(L, 3, typeof(Texture2D));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_scaleToDrawDeltaTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scaleToDrawDeltaTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scaleToDrawDeltaTime on a nil value");
			}
		}

		obj.scaleToDrawDeltaTime = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_easeType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name easeType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index easeType on a nil value");
			}
		}

		obj.easeType = (DG.Tweening.Ease)LuaScriptMgr.GetNetObject(L, 3, typeof(DG.Tweening.Ease));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_switchEaseType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name switchEaseType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index switchEaseType on a nil value");
			}
		}

		obj.switchEaseType = (DG.Tweening.Ease)LuaScriptMgr.GetNetObject(L, 3, typeof(DG.Tweening.Ease));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_dragAndZoomDivide(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dragAndZoomDivide");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dragAndZoomDivide on a nil value");
			}
		}

		obj.dragAndZoomDivide = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_moveScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name moveScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index moveScale on a nil value");
			}
		}

		obj.moveScale = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_zoomScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name zoomScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index zoomScale on a nil value");
			}
		}

		obj.zoomScale = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tweenTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tweenTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tweenTime on a nil value");
			}
		}

		obj.tweenTime = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_minScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name minScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index minScale on a nil value");
			}
		}

		obj.minScale = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxScale on a nil value");
			}
		}

		obj.maxScale = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxScaleCushion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxScaleCushion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxScaleCushion on a nil value");
			}
		}

		obj.maxScaleCushion = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sceneChangeDivide(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sceneChangeDivide");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sceneChangeDivide on a nil value");
			}
		}

		obj.sceneChangeDivide = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sceneMoveTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sceneMoveTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sceneMoveTime on a nil value");
			}
		}

		obj.sceneMoveTime = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sceneScaleTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sceneScaleTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sceneScaleTime on a nil value");
			}
		}

		obj.sceneScaleTime = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_zoomScaleOffset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name zoomScaleOffset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index zoomScaleOffset on a nil value");
			}
		}

		obj.zoomScaleOffset = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uiDivide(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uiDivide");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uiDivide on a nil value");
			}
		}

		obj.uiDivide = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uiScaleFactor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ScrollZoomContainer obj = (ScrollZoomContainer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uiScaleFactor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uiScaleFactor on a nil value");
			}
		}

		obj.uiScaleFactor = (float)LuaScriptMgr.GetNumber(L, 3);
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

