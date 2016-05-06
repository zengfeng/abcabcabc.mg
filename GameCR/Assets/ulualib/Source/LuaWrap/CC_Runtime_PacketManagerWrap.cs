using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CC_Runtime_PacketManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("AddLuaProtoCallback", AddLuaProtoCallback),
			new LuaMethod("RemoveLuaProtoCallback", RemoveLuaProtoCallback),
			new LuaMethod("SendMessage", SendMessage),
			new LuaMethod("Awake", Awake),
			new LuaMethod("initialize", initialize),
			new LuaMethod("GetMessageId", GetMessageId),
			new LuaMethod("New", _CreateCC_Runtime_PacketManager),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", get_Instance, null),
			new LuaField("socketManager", get_socketManager, null),
			new LuaField("reconnectMessage", get_reconnectMessage, null),
		};

		LuaScriptMgr.RegisterLib(L, "CC.Runtime.PacketManager", typeof(CC.Runtime.PacketManager), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCC_Runtime_PacketManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CC.Runtime.PacketManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CC.Runtime.PacketManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.PacketManager.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_socketManager(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PacketManager obj = (CC.Runtime.PacketManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name socketManager");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index socketManager on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.socketManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_reconnectMessage(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PacketManager obj = (CC.Runtime.PacketManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reconnectMessage");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reconnectMessage on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.reconnectMessage);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddLuaProtoCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CC.Runtime.PacketManager obj = (CC.Runtime.PacketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.PacketManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		obj.AddLuaProtoCallback(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveLuaProtoCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.Runtime.PacketManager obj = (CC.Runtime.PacketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.PacketManager");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.RemoveLuaProtoCallback(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessage(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CC.Runtime.PacketManager obj = (CC.Runtime.PacketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.PacketManager");
		CC.Runtime.SocketId arg0 = (CC.Runtime.SocketId)LuaScriptMgr.GetNetObject(L, 2, typeof(CC.Runtime.SocketId));
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		LuaStringBuffer arg2 = LuaScriptMgr.GetStringBuffer(L, 4);
		obj.SendMessage(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Awake(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.Runtime.PacketManager obj = (CC.Runtime.PacketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.PacketManager");
		obj.Awake();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int initialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.Runtime.PacketManager obj = (CC.Runtime.PacketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.PacketManager");
		obj.initialize();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMessageId(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.Runtime.PacketManager obj = (CC.Runtime.PacketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.PacketManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int o = obj.GetMessageId(arg0);
		LuaScriptMgr.Push(L, o);
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

