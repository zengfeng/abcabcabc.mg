using System;
using UnityEngine;
using LuaInterface;

public class DG_Tweening_ShortcutExtensions46Wrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("DOFade", DOFade),
			new LuaMethod("DOColor", DOColor),
			new LuaMethod("DOFillAmount", DOFillAmount),
			new LuaMethod("DOFlexibleSize", DOFlexibleSize),
			new LuaMethod("DOMinSize", DOMinSize),
			new LuaMethod("DOPreferredSize", DOPreferredSize),
			new LuaMethod("DOScale", DOScale),
			new LuaMethod("DOAnchorPos", DOAnchorPos),
			new LuaMethod("DOAnchorPos3D", DOAnchorPos3D),
			new LuaMethod("DOSizeDelta", DOSizeDelta),
			new LuaMethod("DOPunchAnchorPos", DOPunchAnchorPos),
			new LuaMethod("DOShakeAnchorPos", DOShakeAnchorPos),
			new LuaMethod("DOJumpAnchorPos", DOJumpAnchorPos),
			new LuaMethod("DOValue", DOValue),
			new LuaMethod("DOText", DOText),
			new LuaMethod("DOBlendableColor", DOBlendableColor),
			new LuaMethod("New", _CreateDG_Tweening_ShortcutExtensions46),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaScriptMgr.RegisterLib(L, "DG.Tweening.ShortcutExtensions46", regs);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateDG_Tweening_ShortcutExtensions46(IntPtr L)
	{
		LuaDLL.luaL_error(L, "DG.Tweening.ShortcutExtensions46 class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(DG.Tweening.ShortcutExtensions46);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOFade(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(UnityEngine.UI.Outline), typeof(float), typeof(float)))
		{
			UnityEngine.UI.Outline arg0 = (UnityEngine.UI.Outline)LuaScriptMgr.GetLuaObject(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOFade(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(UnityEngine.UI.Text), typeof(float), typeof(float)))
		{
			UnityEngine.UI.Text arg0 = (UnityEngine.UI.Text)LuaScriptMgr.GetLuaObject(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOFade(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(UnityEngine.UI.Image), typeof(float), typeof(float)))
		{
			UnityEngine.UI.Image arg0 = (UnityEngine.UI.Image)LuaScriptMgr.GetLuaObject(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOFade(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(CanvasGroup), typeof(float), typeof(float)))
		{
			CanvasGroup arg0 = (CanvasGroup)LuaScriptMgr.GetLuaObject(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOFade(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(UnityEngine.UI.Graphic), typeof(float), typeof(float)))
		{
			UnityEngine.UI.Graphic arg0 = (UnityEngine.UI.Graphic)LuaScriptMgr.GetLuaObject(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOFade(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: DG.Tweening.ShortcutExtensions46.DOFade");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOColor(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(UnityEngine.UI.Outline), typeof(LuaTable), typeof(float)))
		{
			UnityEngine.UI.Outline arg0 = (UnityEngine.UI.Outline)LuaScriptMgr.GetLuaObject(L, 1);
			Color arg1 = LuaScriptMgr.GetColor(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOColor(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(UnityEngine.UI.Text), typeof(LuaTable), typeof(float)))
		{
			UnityEngine.UI.Text arg0 = (UnityEngine.UI.Text)LuaScriptMgr.GetLuaObject(L, 1);
			Color arg1 = LuaScriptMgr.GetColor(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOColor(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(UnityEngine.UI.Graphic), typeof(LuaTable), typeof(float)))
		{
			UnityEngine.UI.Graphic arg0 = (UnityEngine.UI.Graphic)LuaScriptMgr.GetLuaObject(L, 1);
			Color arg1 = LuaScriptMgr.GetColor(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOColor(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(UnityEngine.UI.Image), typeof(LuaTable), typeof(float)))
		{
			UnityEngine.UI.Image arg0 = (UnityEngine.UI.Image)LuaScriptMgr.GetLuaObject(L, 1);
			Color arg1 = LuaScriptMgr.GetColor(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOColor(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: DG.Tweening.ShortcutExtensions46.DOColor");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOFillAmount(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UnityEngine.UI.Image arg0 = (UnityEngine.UI.Image)LuaScriptMgr.GetUnityObject(L, 1, typeof(UnityEngine.UI.Image));
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOFillAmount(arg0,arg1,arg2);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOFlexibleSize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		UnityEngine.UI.LayoutElement arg0 = (UnityEngine.UI.LayoutElement)LuaScriptMgr.GetUnityObject(L, 1, typeof(UnityEngine.UI.LayoutElement));
		Vector2 arg1 = LuaScriptMgr.GetVector2(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
		DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOFlexibleSize(arg0,arg1,arg2,arg3);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOMinSize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		UnityEngine.UI.LayoutElement arg0 = (UnityEngine.UI.LayoutElement)LuaScriptMgr.GetUnityObject(L, 1, typeof(UnityEngine.UI.LayoutElement));
		Vector2 arg1 = LuaScriptMgr.GetVector2(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
		DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOMinSize(arg0,arg1,arg2,arg3);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOPreferredSize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		UnityEngine.UI.LayoutElement arg0 = (UnityEngine.UI.LayoutElement)LuaScriptMgr.GetUnityObject(L, 1, typeof(UnityEngine.UI.LayoutElement));
		Vector2 arg1 = LuaScriptMgr.GetVector2(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
		DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOPreferredSize(arg0,arg1,arg2,arg3);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOScale(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UnityEngine.UI.Outline arg0 = (UnityEngine.UI.Outline)LuaScriptMgr.GetUnityObject(L, 1, typeof(UnityEngine.UI.Outline));
		Vector2 arg1 = LuaScriptMgr.GetVector2(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOScale(arg0,arg1,arg2);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOAnchorPos(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		RectTransform arg0 = (RectTransform)LuaScriptMgr.GetUnityObject(L, 1, typeof(RectTransform));
		Vector2 arg1 = LuaScriptMgr.GetVector2(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
		DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOAnchorPos(arg0,arg1,arg2,arg3);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOAnchorPos3D(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		RectTransform arg0 = (RectTransform)LuaScriptMgr.GetUnityObject(L, 1, typeof(RectTransform));
		Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
		DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOAnchorPos3D(arg0,arg1,arg2,arg3);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOSizeDelta(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		RectTransform arg0 = (RectTransform)LuaScriptMgr.GetUnityObject(L, 1, typeof(RectTransform));
		Vector2 arg1 = LuaScriptMgr.GetVector2(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
		DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOSizeDelta(arg0,arg1,arg2,arg3);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOPunchAnchorPos(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 6);
		RectTransform arg0 = (RectTransform)LuaScriptMgr.GetUnityObject(L, 1, typeof(RectTransform));
		Vector2 arg1 = LuaScriptMgr.GetVector2(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
		float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
		bool arg5 = LuaScriptMgr.GetBoolean(L, 6);
		DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOPunchAnchorPos(arg0,arg1,arg2,arg3,arg4,arg5);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOShakeAnchorPos(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 6 && LuaScriptMgr.CheckTypes(L, 1, typeof(RectTransform), typeof(float), typeof(LuaTable), typeof(int), typeof(float), typeof(bool)))
		{
			RectTransform arg0 = (RectTransform)LuaScriptMgr.GetLuaObject(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetVector2(L, 3);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 4);
			float arg4 = (float)LuaDLL.lua_tonumber(L, 5);
			bool arg5 = LuaDLL.lua_toboolean(L, 6);
			DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOShakeAnchorPos(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 6 && LuaScriptMgr.CheckTypes(L, 1, typeof(RectTransform), typeof(float), typeof(float), typeof(int), typeof(float), typeof(bool)))
		{
			RectTransform arg0 = (RectTransform)LuaScriptMgr.GetLuaObject(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 4);
			float arg4 = (float)LuaDLL.lua_tonumber(L, 5);
			bool arg5 = LuaDLL.lua_toboolean(L, 6);
			DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOShakeAnchorPos(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: DG.Tweening.ShortcutExtensions46.DOShakeAnchorPos");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOJumpAnchorPos(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 6);
		RectTransform arg0 = (RectTransform)LuaScriptMgr.GetUnityObject(L, 1, typeof(RectTransform));
		Vector2 arg1 = LuaScriptMgr.GetVector2(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
		float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
		bool arg5 = LuaScriptMgr.GetBoolean(L, 6);
		DG.Tweening.Sequence o = DG.Tweening.ShortcutExtensions46.DOJumpAnchorPos(arg0,arg1,arg2,arg3,arg4,arg5);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		UnityEngine.UI.Slider arg0 = (UnityEngine.UI.Slider)LuaScriptMgr.GetUnityObject(L, 1, typeof(UnityEngine.UI.Slider));
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
		DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOValue(arg0,arg1,arg2,arg3);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOText(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 6);
		UnityEngine.UI.Text arg0 = (UnityEngine.UI.Text)LuaScriptMgr.GetUnityObject(L, 1, typeof(UnityEngine.UI.Text));
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
		DG.Tweening.ScrambleMode arg4 = (DG.Tweening.ScrambleMode)LuaScriptMgr.GetNetObject(L, 5, typeof(DG.Tweening.ScrambleMode));
		string arg5 = LuaScriptMgr.GetLuaString(L, 6);
		DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOText(arg0,arg1,arg2,arg3,arg4,arg5);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOBlendableColor(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(UnityEngine.UI.Text), typeof(LuaTable), typeof(float)))
		{
			UnityEngine.UI.Text arg0 = (UnityEngine.UI.Text)LuaScriptMgr.GetLuaObject(L, 1);
			Color arg1 = LuaScriptMgr.GetColor(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOBlendableColor(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(UnityEngine.UI.Image), typeof(LuaTable), typeof(float)))
		{
			UnityEngine.UI.Image arg0 = (UnityEngine.UI.Image)LuaScriptMgr.GetLuaObject(L, 1);
			Color arg1 = LuaScriptMgr.GetColor(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOBlendableColor(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(UnityEngine.UI.Graphic), typeof(LuaTable), typeof(float)))
		{
			UnityEngine.UI.Graphic arg0 = (UnityEngine.UI.Graphic)LuaScriptMgr.GetLuaObject(L, 1);
			Color arg1 = LuaScriptMgr.GetColor(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			DG.Tweening.Tweener o = DG.Tweening.ShortcutExtensions46.DOBlendableColor(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: DG.Tweening.ShortcutExtensions46.DOBlendableColor");
		}

		return 0;
	}
}

