using System;
using LuaInterface;

public class Games_Module_Wars_WinTypeWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("T0_None", GetT0_None),
		new LuaMethod("T1_Occupy", GetT1_Occupy),
		new LuaMethod("T2_Defend", GetT2_Defend),
		new LuaMethod("T3_Attack", GetT3_Attack),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.WinType", typeof(Games.Module.Wars.WinType), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetT0_None(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.WinType.T0_None);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetT1_Occupy(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.WinType.T1_Occupy);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetT2_Defend(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.WinType.T2_Defend);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetT3_Attack(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.WinType.T3_Attack);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		Games.Module.Wars.WinType o = (Games.Module.Wars.WinType)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

