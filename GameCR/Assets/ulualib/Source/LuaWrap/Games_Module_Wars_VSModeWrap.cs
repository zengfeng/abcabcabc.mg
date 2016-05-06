using System;
using LuaInterface;

public class Games_Module_Wars_VSModeWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("Dungeon", GetDungeon),
		new LuaMethod("Train", GetTrain),
		new LuaMethod("PVP", GetPVP),
		new LuaMethod("PVE", GetPVE),
		new LuaMethod("PVE_Expedition", GetPVE_Expedition),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.VSMode", typeof(Games.Module.Wars.VSMode), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDungeon(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.VSMode.Dungeon);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTrain(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.VSMode.Train);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPVP(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.VSMode.PVP);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPVE(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.VSMode.PVE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPVE_Expedition(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.VSMode.PVE_Expedition);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		Games.Module.Wars.VSMode o = (Games.Module.Wars.VSMode)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

