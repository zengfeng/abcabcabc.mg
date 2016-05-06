using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CC_Runtime_SocketManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Awake", Awake),
			new LuaMethod("Stop", Stop),
			new LuaMethod("StopAll", StopAll),
			new LuaMethod("Close", Close),
			new LuaMethod("CloseAll", CloseAll),
			new LuaMethod("Connect", Connect),
			new LuaMethod("Reconnect", Reconnect),
			new LuaMethod("AddConnectedCallback", AddConnectedCallback),
			new LuaMethod("AddLuaConnectedCallback", AddLuaConnectedCallback),
			new LuaMethod("AddLuaDisconnectCallback", AddLuaDisconnectCallback),
			new LuaMethod("AddLuaReconnectCallback", AddLuaReconnectCallback),
			new LuaMethod("isServerConnect", isServerConnect),
			new LuaMethod("Offline", Offline),
			new LuaMethod("Update", Update),
			new LuaMethod("SendProtoMessage", SendProtoMessage),
			new LuaMethod("SendEmptyMessage", SendEmptyMessage),
			new LuaMethod("New", _CreateCC_Runtime_SocketManager),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("OFFLINE", get_OFFLINE, null),
			new LuaField("connectedCallback", get_connectedCallback, set_connectedCallback),
			new LuaField("handler", get_handler, set_handler),
			new LuaField("Instance", get_Instance, null),
		};

		LuaScriptMgr.RegisterLib(L, "CC.Runtime.SocketManager", typeof(CC.Runtime.SocketManager), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCC_Runtime_SocketManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CC.Runtime.SocketManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CC.Runtime.SocketManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OFFLINE(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.SocketManager.OFFLINE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_connectedCallback(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name connectedCallback");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index connectedCallback on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.connectedCallback);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_handler(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name handler");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index handler on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.handler);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.SocketManager.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_connectedCallback(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name connectedCallback");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index connectedCallback on a nil value");
			}
		}

		LuaTypes funcType = LuaDLL.lua_type(L, 3);

		if (funcType != LuaTypes.LUA_TFUNCTION)
		{
			obj.connectedCallback = (Action<CC.Runtime.SocketId>)LuaScriptMgr.GetNetObject(L, 3, typeof(Action<CC.Runtime.SocketId>));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			obj.connectedCallback = (param0) =>
			{
				int top = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				func.PCall(top, 1);
				func.EndPCall(top);
			};
		}
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_handler(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name handler");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index handler on a nil value");
			}
		}

		LuaTypes funcType = LuaDLL.lua_type(L, 3);

		if (funcType != LuaTypes.LUA_TFUNCTION)
		{
			obj.handler = (Action<CC.Runtime.ReadData>)LuaScriptMgr.GetNetObject(L, 3, typeof(Action<CC.Runtime.ReadData>));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			obj.handler = (param0) =>
			{
				int top = func.BeginPCall();
				LuaScriptMgr.PushObject(L, param0);
				func.PCall(top, 1);
				func.EndPCall(top);
			};
		}
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Awake(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.SocketManager");
		obj.Awake();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Stop(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.SocketManager");
		CC.Runtime.SocketId arg0 = (CC.Runtime.SocketId)LuaScriptMgr.GetNetObject(L, 2, typeof(CC.Runtime.SocketId));
		obj.Stop(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopAll(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.SocketManager");
		obj.StopAll();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Close(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.SocketManager");
		CC.Runtime.SocketId arg0 = (CC.Runtime.SocketId)LuaScriptMgr.GetNetObject(L, 2, typeof(CC.Runtime.SocketId));
		obj.Close(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CloseAll(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.SocketManager");
		obj.CloseAll();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Connect(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.SocketManager");
			CC.Runtime.SocketId arg0 = (CC.Runtime.SocketId)LuaScriptMgr.GetNetObject(L, 2, typeof(CC.Runtime.SocketId));
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			obj.Connect(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.SocketManager");
			CC.Runtime.SocketId arg0 = (CC.Runtime.SocketId)LuaScriptMgr.GetNetObject(L, 2, typeof(CC.Runtime.SocketId));
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			obj.Connect(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.Runtime.SocketManager.Connect");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Reconnect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.SocketManager");
		CC.Runtime.SocketId arg0 = (CC.Runtime.SocketId)LuaScriptMgr.GetNetObject(L, 2, typeof(CC.Runtime.SocketId));
		obj.Reconnect(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddConnectedCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.SocketManager");
		Action<CC.Runtime.SocketId> arg0 = null;
		LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

		if (funcType2 != LuaTypes.LUA_TFUNCTION)
		{
			 arg0 = (Action<CC.Runtime.SocketId>)LuaScriptMgr.GetNetObject(L, 2, typeof(Action<CC.Runtime.SocketId>));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
			arg0 = (param0) =>
			{
				int top = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				func.PCall(top, 1);
				func.EndPCall(top);
			};
		}

		obj.AddConnectedCallback(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddLuaConnectedCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.SocketManager");
		LuaTable arg0 = LuaScriptMgr.GetLuaTable(L, 2);
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		obj.AddLuaConnectedCallback(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddLuaDisconnectCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.SocketManager");
		CC.Runtime.SocketId arg0 = (CC.Runtime.SocketId)LuaScriptMgr.GetNetObject(L, 2, typeof(CC.Runtime.SocketId));
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		obj.AddLuaDisconnectCallback(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddLuaReconnectCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.SocketManager");
		CC.Runtime.SocketId arg0 = (CC.Runtime.SocketId)LuaScriptMgr.GetNetObject(L, 2, typeof(CC.Runtime.SocketId));
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		obj.AddLuaReconnectCallback(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int isServerConnect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.SocketManager");
		CC.Runtime.SocketId arg0 = (CC.Runtime.SocketId)LuaScriptMgr.GetNetObject(L, 2, typeof(CC.Runtime.SocketId));
		bool o = obj.isServerConnect(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Offline(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.SocketManager");
		CC.Runtime.SocketId arg0 = (CC.Runtime.SocketId)LuaScriptMgr.GetNetObject(L, 2, typeof(CC.Runtime.SocketId));
		obj.Offline(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Update(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.SocketManager");
		obj.Update();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendProtoMessage(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.SocketManager");
		CC.Runtime.SocketId arg0 = (CC.Runtime.SocketId)LuaScriptMgr.GetNetObject(L, 2, typeof(CC.Runtime.SocketId));
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		System.IO.Stream arg2 = (System.IO.Stream)LuaScriptMgr.GetNetObject(L, 4, typeof(System.IO.Stream));
		obj.SendProtoMessage(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendEmptyMessage(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CC.Runtime.SocketManager obj = (CC.Runtime.SocketManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.SocketManager");
		CC.Runtime.SocketId arg0 = (CC.Runtime.SocketId)LuaScriptMgr.GetNetObject(L, 2, typeof(CC.Runtime.SocketId));
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.SendEmptyMessage(arg0,arg1);
		return 0;
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

