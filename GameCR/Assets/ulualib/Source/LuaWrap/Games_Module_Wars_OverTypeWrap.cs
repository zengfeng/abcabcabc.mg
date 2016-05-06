using System;
using LuaInterface;

public class Games_Module_Wars_OverTypeWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("Lose", GetLose),
		new LuaMethod("Draw", GetDraw),
		new LuaMethod("Win", GetWin),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.OverType", typeof(Games.Module.Wars.OverType), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLose(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.OverType.Lose);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDraw(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.OverType.Draw);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWin(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.OverType.Win);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		Games.Module.Wars.OverType o = (Games.Module.Wars.OverType)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

