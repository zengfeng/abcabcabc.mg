using System;
using UnityEngine;
using LuaInterface;

public class MiscLuaUtilWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("AssetToString", AssetToString),
			new LuaMethod("AnchoredPosNode1InNode2Local", AnchoredPosNode1InNode2Local),
			new LuaMethod("FullPathFromCanvas", FullPathFromCanvas),
			new LuaMethod("New", _CreateMiscLuaUtil),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "MiscLuaUtil", typeof(MiscLuaUtil), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMiscLuaUtil(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			MiscLuaUtil obj = new MiscLuaUtil();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MiscLuaUtil.New");
		}

		return 0;
	}

	static Type classType = typeof(MiscLuaUtil);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AssetToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		TextAsset arg0 = (TextAsset)LuaScriptMgr.GetUnityObject(L, 1, typeof(TextAsset));
		string o = MiscLuaUtil.AssetToString(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AnchoredPosNode1InNode2Local(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		RectTransform arg0 = (RectTransform)LuaScriptMgr.GetUnityObject(L, 1, typeof(RectTransform));
		RectTransform arg1 = (RectTransform)LuaScriptMgr.GetUnityObject(L, 2, typeof(RectTransform));
		Vector2 o = MiscLuaUtil.AnchoredPosNode1InNode2Local(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FullPathFromCanvas(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		string o = MiscLuaUtil.FullPathFromCanvas(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

