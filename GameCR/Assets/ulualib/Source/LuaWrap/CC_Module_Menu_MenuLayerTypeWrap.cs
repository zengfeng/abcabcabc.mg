using System;
using LuaInterface;

public class CC_Module_Menu_MenuLayerTypeWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("Layer_PreInstance", GetLayer_PreInstance),
		new LuaMethod("Layer_DefaultBG", GetLayer_DefaultBG),
		new LuaMethod("Layer_Home", GetLayer_Home),
		new LuaMethod("Layer_BlurBG", GetLayer_BlurBG),
		new LuaMethod("Layer_Module", GetLayer_Module),
		new LuaMethod("Layer_MainUI", GetLayer_MainUI),
		new LuaMethod("Layer_Dialog", GetLayer_Dialog),
		new LuaMethod("Layer_Guide", GetLayer_Guide),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "CC.Module.Menu.MenuLayerType", typeof(CC.Module.Menu.MenuLayerType), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLayer_PreInstance(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Module.Menu.MenuLayerType.Layer_PreInstance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLayer_DefaultBG(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Module.Menu.MenuLayerType.Layer_DefaultBG);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLayer_Home(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Module.Menu.MenuLayerType.Layer_Home);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLayer_BlurBG(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Module.Menu.MenuLayerType.Layer_BlurBG);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLayer_Module(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Module.Menu.MenuLayerType.Layer_Module);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLayer_MainUI(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Module.Menu.MenuLayerType.Layer_MainUI);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLayer_Dialog(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Module.Menu.MenuLayerType.Layer_Dialog);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLayer_Guide(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Module.Menu.MenuLayerType.Layer_Guide);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		CC.Module.Menu.MenuLayerType o = (CC.Module.Menu.MenuLayerType)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

