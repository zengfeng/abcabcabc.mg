using System;
using LuaInterface;

public class CC_Runtime_SocketIdWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("Login", GetLogin),
		new LuaMethod("Main", GetMain),
		new LuaMethod("Battle", GetBattle),
		new LuaMethod("Chat", GetChat),
		new LuaMethod("Max", GetMax),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "CC.Runtime.SocketId", typeof(CC.Runtime.SocketId), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLogin(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.SocketId.Login);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMain(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.SocketId.Main);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBattle(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.SocketId.Battle);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetChat(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.SocketId.Chat);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMax(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.SocketId.Max);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		CC.Runtime.SocketId o = (CC.Runtime.SocketId)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

