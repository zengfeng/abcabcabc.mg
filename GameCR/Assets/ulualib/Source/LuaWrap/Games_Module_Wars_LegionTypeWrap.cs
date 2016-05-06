using System;
using LuaInterface;

public class Games_Module_Wars_LegionTypeWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("Neutral", GetNeutral),
		new LuaMethod("Player", GetPlayer),
		new LuaMethod("Computer", GetComputer),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.LegionType", typeof(Games.Module.Wars.LegionType), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNeutral(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.LegionType.Neutral);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPlayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.LegionType.Player);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComputer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.LegionType.Computer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		Games.Module.Wars.LegionType o = (Games.Module.Wars.LegionType)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

