using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class DOTweenLuaUtilsWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("OnUpdate", OnUpdate),
			new LuaMethod("OnSeqComplete", OnSeqComplete),
			new LuaMethod("AppendSeqCallback", AppendSeqCallback),
			new LuaMethod("SetDelay", SetDelay),
			new LuaMethod("SetEase", SetEase),
			new LuaMethod("SetLoop", SetLoop),
			new LuaMethod("OnTweenerComplete", OnTweenerComplete),
			new LuaMethod("OnTweenerUpdate", OnTweenerUpdate),
			new LuaMethod("TweenTo", TweenTo),
			new LuaMethod("PlayTween", PlayTween),
			new LuaMethod("PauseTween", PauseTween),
			new LuaMethod("New", _CreateDOTweenLuaUtils),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "DOTweenLuaUtils", typeof(DOTweenLuaUtils), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateDOTweenLuaUtils(IntPtr L)
	{
		LuaDLL.luaL_error(L, "DOTweenLuaUtils class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(DOTweenLuaUtils);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnUpdate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		DG.Tweening.Tweener arg0 = (DG.Tweening.Tweener)LuaScriptMgr.GetNetObject(L, 1, typeof(DG.Tweening.Tweener));
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 2);
		DG.Tweening.Tweener o = DOTweenLuaUtils.OnUpdate(arg0,arg1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnSeqComplete(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		DG.Tweening.Sequence arg0 = (DG.Tweening.Sequence)LuaScriptMgr.GetNetObject(L, 1, typeof(DG.Tweening.Sequence));
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 2);
		DG.Tweening.Sequence o = DOTweenLuaUtils.OnSeqComplete(arg0,arg1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AppendSeqCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		DG.Tweening.Sequence arg0 = (DG.Tweening.Sequence)LuaScriptMgr.GetNetObject(L, 1, typeof(DG.Tweening.Sequence));
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 2);
		DG.Tweening.Sequence o = DOTweenLuaUtils.AppendSeqCallback(arg0,arg1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetDelay(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		DG.Tweening.Tweener arg0 = (DG.Tweening.Tweener)LuaScriptMgr.GetNetObject(L, 1, typeof(DG.Tweening.Tweener));
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
		DG.Tweening.Tweener o = DOTweenLuaUtils.SetDelay(arg0,arg1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetEase(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		DG.Tweening.Tweener arg0 = (DG.Tweening.Tweener)LuaScriptMgr.GetNetObject(L, 1, typeof(DG.Tweening.Tweener));
		DG.Tweening.Ease arg1 = (DG.Tweening.Ease)LuaScriptMgr.GetNetObject(L, 2, typeof(DG.Tweening.Ease));
		DG.Tweening.Tweener o = DOTweenLuaUtils.SetEase(arg0,arg1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetLoop(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		DG.Tweening.Tweener arg0 = (DG.Tweening.Tweener)LuaScriptMgr.GetNetObject(L, 1, typeof(DG.Tweening.Tweener));
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		DG.Tweening.Tweener o = DOTweenLuaUtils.SetLoop(arg0,arg1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnTweenerComplete(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		DG.Tweening.Tweener arg0 = (DG.Tweening.Tweener)LuaScriptMgr.GetNetObject(L, 1, typeof(DG.Tweening.Tweener));
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 2);
		DG.Tweening.Tweener o = DOTweenLuaUtils.OnTweenerComplete(arg0,arg1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnTweenerUpdate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		DG.Tweening.Tweener arg0 = (DG.Tweening.Tweener)LuaScriptMgr.GetNetObject(L, 1, typeof(DG.Tweening.Tweener));
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 2);
		DG.Tweening.Tweener o = DOTweenLuaUtils.OnTweenerUpdate(arg0,arg1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TweenTo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 1);
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
		DG.Tweening.Tweener o = DOTweenLuaUtils.TweenTo(arg0,arg1,arg2,arg3);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayTween(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		DG.Tweening.Tween arg0 = (DG.Tweening.Tween)LuaScriptMgr.GetNetObject(L, 1, typeof(DG.Tweening.Tween));
		DG.Tweening.Tween o = DOTweenLuaUtils.PlayTween(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PauseTween(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		DG.Tweening.Tween arg0 = (DG.Tweening.Tween)LuaScriptMgr.GetNetObject(L, 1, typeof(DG.Tweening.Tween));
		DG.Tweening.Tween o = DOTweenLuaUtils.PauseTween(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
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

