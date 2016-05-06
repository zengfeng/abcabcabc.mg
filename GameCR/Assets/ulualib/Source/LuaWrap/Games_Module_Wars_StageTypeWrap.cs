using System;
using LuaInterface;

public class Games_Module_Wars_StageTypeWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("Dungeon", GetDungeon),
		new LuaMethod("Dungeon_Hard", GetDungeon_Hard),
		new LuaMethod("Treasure", GetTreasure),
		new LuaMethod("Arena", GetArena),
		new LuaMethod("Expedition", GetExpedition),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.StageType", typeof(Games.Module.Wars.StageType), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDungeon(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.StageType.Dungeon);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDungeon_Hard(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.StageType.Dungeon_Hard);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTreasure(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.StageType.Treasure);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetArena(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.StageType.Arena);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetExpedition(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Wars.StageType.Expedition);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		Games.Module.Wars.StageType o = (Games.Module.Wars.StageType)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

