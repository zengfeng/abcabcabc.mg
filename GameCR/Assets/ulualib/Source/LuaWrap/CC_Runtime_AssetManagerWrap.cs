using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CC_Runtime_AssetManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetRealURL", GetRealURL),
			new LuaMethod("Init", Init),
			new LuaMethod("Update", Update),
			new LuaMethod("UnloadUnusedAssets", UnloadUnusedAssets),
			new LuaMethod("Unload", Unload),
			new LuaMethod("LuaLoadAsync", LuaLoadAsync),
			new LuaMethod("LoadAsync", LoadAsync),
			new LuaMethod("LuaLoad", LuaLoad),
			new LuaMethod("Load", Load),
			new LuaMethod("LoadConfig", LoadConfig),
			new LuaMethod("New", _CreateCC_Runtime_AssetManager),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("configFileAB", get_configFileAB, set_configFileAB),
			new LuaField("isPrepare", get_isPrepare, set_isPrepare),
			new LuaField("prepareFinal", get_prepareFinal, set_prepareFinal),
			new LuaField("Instance", get_Instance, null),
		};

		LuaScriptMgr.RegisterLib(L, "CC.Runtime.AssetManager", typeof(CC.Runtime.AssetManager), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCC_Runtime_AssetManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CC.Runtime.AssetManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CC.Runtime.AssetManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_configFileAB(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name configFileAB");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index configFileAB on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.configFileAB);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPrepare(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isPrepare");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isPrepare on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isPrepare);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_prepareFinal(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name prepareFinal");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index prepareFinal on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.prepareFinal);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.AssetManager.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_configFileAB(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name configFileAB");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index configFileAB on a nil value");
			}
		}

		obj.configFileAB = (AssetBundle)LuaScriptMgr.GetUnityObject(L, 3, typeof(AssetBundle));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isPrepare(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isPrepare");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isPrepare on a nil value");
			}
		}

		obj.isPrepare = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_prepareFinal(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name prepareFinal");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index prepareFinal on a nil value");
			}
		}

		obj.prepareFinal = (CC.Runtime.signals.HSignal)LuaScriptMgr.GetNetObject(L, 3, typeof(CC.Runtime.signals.HSignal));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRealURL(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		string o = obj.GetRealURL(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
		obj.Init();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Update(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
		obj.Update();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnloadUnusedAssets(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
		obj.UnloadUnusedAssets();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Unload(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.Unload(arg0);
			return 0;
		}
		else if (count == 3)
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			obj.Unload(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.Runtime.AssetManager.Unload");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaLoadAsync(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4)
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			LuaTable arg0 = LuaScriptMgr.GetLuaTable(L, 2);
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			LuaFunction arg2 = LuaScriptMgr.GetLuaFunction(L, 4);
			obj.LuaLoadAsync(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 5)
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			LuaTable arg0 = LuaScriptMgr.GetLuaTable(L, 2);
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			LuaFunction arg2 = LuaScriptMgr.GetLuaFunction(L, 4);
			object arg3 = LuaScriptMgr.GetVarObject(L, 5);
			obj.LuaLoadAsync(arg0,arg1,arg2,arg3);
			return 0;
		}
		else if (count == 6)
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			LuaTable arg0 = LuaScriptMgr.GetLuaTable(L, 2);
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			LuaFunction arg2 = LuaScriptMgr.GetLuaFunction(L, 4);
			object arg3 = LuaScriptMgr.GetVarObject(L, 5);
			Type arg4 = LuaScriptMgr.GetTypeObject(L, 6);
			obj.LuaLoadAsync(arg0,arg1,arg2,arg3,arg4);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.Runtime.AssetManager.LuaLoadAsync");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAsync(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(CC.Runtime.AssetManager), typeof(string), typeof(Action<string,object,object>)))
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Action<string,object,object> arg1 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg1 = (Action<string,object,object>)LuaScriptMgr.GetLuaObject(L, 3);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg1 = (param0, param1, param2) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					LuaScriptMgr.PushVarObject(L, param1);
					LuaScriptMgr.PushVarObject(L, param2);
					func.PCall(top, 3);
					func.EndPCall(top);
				};
			}

			obj.LoadAsync(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(CC.Runtime.AssetManager), typeof(string), typeof(Action<string,object>)))
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Action<string,object> arg1 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg1 = (Action<string,object>)LuaScriptMgr.GetLuaObject(L, 3);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg1 = (param0, param1) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					LuaScriptMgr.PushVarObject(L, param1);
					func.PCall(top, 2);
					func.EndPCall(top);
				};
			}

			obj.LoadAsync(arg0,arg1);
			return 0;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(CC.Runtime.AssetManager), typeof(string), typeof(Action<string,object,object>), typeof(Type)))
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Action<string,object,object> arg1 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg1 = (Action<string,object,object>)LuaScriptMgr.GetLuaObject(L, 3);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg1 = (param0, param1, param2) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					LuaScriptMgr.PushVarObject(L, param1);
					LuaScriptMgr.PushVarObject(L, param2);
					func.PCall(top, 3);
					func.EndPCall(top);
				};
			}

			Type arg2 = LuaScriptMgr.GetTypeObject(L, 4);
			obj.LoadAsync(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(CC.Runtime.AssetManager), typeof(string), typeof(Action<string,object>), typeof(Type)))
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Action<string,object> arg1 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg1 = (Action<string,object>)LuaScriptMgr.GetLuaObject(L, 3);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg1 = (param0, param1) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					LuaScriptMgr.PushVarObject(L, param1);
					func.PCall(top, 2);
					func.EndPCall(top);
				};
			}

			Type arg2 = LuaScriptMgr.GetTypeObject(L, 4);
			obj.LoadAsync(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(CC.Runtime.AssetManager), typeof(string), typeof(Action<string,object,object>), typeof(object)))
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Action<string,object,object> arg1 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg1 = (Action<string,object,object>)LuaScriptMgr.GetLuaObject(L, 3);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg1 = (param0, param1, param2) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					LuaScriptMgr.PushVarObject(L, param1);
					LuaScriptMgr.PushVarObject(L, param2);
					func.PCall(top, 3);
					func.EndPCall(top);
				};
			}

			object arg2 = LuaScriptMgr.GetVarObject(L, 4);
			obj.LoadAsync(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 5)
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			Action<string,object,object> arg1 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg1 = (Action<string,object,object>)LuaScriptMgr.GetNetObject(L, 3, typeof(Action<string,object,object>));
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg1 = (param0, param1, param2) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					LuaScriptMgr.PushVarObject(L, param1);
					LuaScriptMgr.PushVarObject(L, param2);
					func.PCall(top, 3);
					func.EndPCall(top);
				};
			}

			object arg2 = LuaScriptMgr.GetVarObject(L, 4);
			Type arg3 = LuaScriptMgr.GetTypeObject(L, 5);
			obj.LoadAsync(arg0,arg1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.Runtime.AssetManager.LoadAsync");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaLoad(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4)
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			LuaTable arg0 = LuaScriptMgr.GetLuaTable(L, 2);
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			LuaFunction arg2 = LuaScriptMgr.GetLuaFunction(L, 4);
			obj.LuaLoad(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 5)
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			LuaTable arg0 = LuaScriptMgr.GetLuaTable(L, 2);
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			LuaFunction arg2 = LuaScriptMgr.GetLuaFunction(L, 4);
			object arg3 = LuaScriptMgr.GetVarObject(L, 5);
			obj.LuaLoad(arg0,arg1,arg2,arg3);
			return 0;
		}
		else if (count == 6)
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			LuaTable arg0 = LuaScriptMgr.GetLuaTable(L, 2);
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			LuaFunction arg2 = LuaScriptMgr.GetLuaFunction(L, 4);
			object arg3 = LuaScriptMgr.GetVarObject(L, 5);
			Type arg4 = LuaScriptMgr.GetTypeObject(L, 6);
			obj.LuaLoad(arg0,arg1,arg2,arg3,arg4);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.Runtime.AssetManager.LuaLoad");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Load(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(CC.Runtime.AssetManager), typeof(string), typeof(Action<string,object,object>)))
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Action<string,object,object> arg1 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg1 = (Action<string,object,object>)LuaScriptMgr.GetLuaObject(L, 3);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg1 = (param0, param1, param2) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					LuaScriptMgr.PushVarObject(L, param1);
					LuaScriptMgr.PushVarObject(L, param2);
					func.PCall(top, 3);
					func.EndPCall(top);
				};
			}

			obj.Load(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(CC.Runtime.AssetManager), typeof(string), typeof(Action<string,object>)))
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Action<string,object> arg1 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg1 = (Action<string,object>)LuaScriptMgr.GetLuaObject(L, 3);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg1 = (param0, param1) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					LuaScriptMgr.PushVarObject(L, param1);
					func.PCall(top, 2);
					func.EndPCall(top);
				};
			}

			obj.Load(arg0,arg1);
			return 0;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(CC.Runtime.AssetManager), typeof(string), typeof(Action<string,object,object>), typeof(Type)))
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Action<string,object,object> arg1 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg1 = (Action<string,object,object>)LuaScriptMgr.GetLuaObject(L, 3);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg1 = (param0, param1, param2) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					LuaScriptMgr.PushVarObject(L, param1);
					LuaScriptMgr.PushVarObject(L, param2);
					func.PCall(top, 3);
					func.EndPCall(top);
				};
			}

			Type arg2 = LuaScriptMgr.GetTypeObject(L, 4);
			obj.Load(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(CC.Runtime.AssetManager), typeof(string), typeof(Action<string,object>), typeof(Type)))
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Action<string,object> arg1 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg1 = (Action<string,object>)LuaScriptMgr.GetLuaObject(L, 3);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg1 = (param0, param1) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					LuaScriptMgr.PushVarObject(L, param1);
					func.PCall(top, 2);
					func.EndPCall(top);
				};
			}

			Type arg2 = LuaScriptMgr.GetTypeObject(L, 4);
			obj.Load(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(CC.Runtime.AssetManager), typeof(string), typeof(Action<string,object,object>), typeof(object)))
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Action<string,object,object> arg1 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg1 = (Action<string,object,object>)LuaScriptMgr.GetLuaObject(L, 3);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg1 = (param0, param1, param2) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					LuaScriptMgr.PushVarObject(L, param1);
					LuaScriptMgr.PushVarObject(L, param2);
					func.PCall(top, 3);
					func.EndPCall(top);
				};
			}

			object arg2 = LuaScriptMgr.GetVarObject(L, 4);
			obj.Load(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 5)
		{
			CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			Action<string,object,object> arg1 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg1 = (Action<string,object,object>)LuaScriptMgr.GetNetObject(L, 3, typeof(Action<string,object,object>));
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg1 = (param0, param1, param2) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					LuaScriptMgr.PushVarObject(L, param1);
					LuaScriptMgr.PushVarObject(L, param2);
					func.PCall(top, 3);
					func.EndPCall(top);
				};
			}

			object arg2 = LuaScriptMgr.GetVarObject(L, 4);
			Type arg3 = LuaScriptMgr.GetTypeObject(L, 5);
			obj.Load(arg0,arg1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.Runtime.AssetManager.Load");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CC.Runtime.AssetManager obj = (CC.Runtime.AssetManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Runtime.AssetManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Action<string,object,object> arg1 = null;
		LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

		if (funcType3 != LuaTypes.LUA_TFUNCTION)
		{
			 arg1 = (Action<string,object,object>)LuaScriptMgr.GetNetObject(L, 3, typeof(Action<string,object,object>));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
			arg1 = (param0, param1, param2) =>
			{
				int top = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				LuaScriptMgr.PushVarObject(L, param1);
				LuaScriptMgr.PushVarObject(L, param2);
				func.PCall(top, 3);
				func.EndPCall(top);
			};
		}

		object arg2 = LuaScriptMgr.GetVarObject(L, 4);
		obj.LoadConfig(arg0,arg1,arg2);
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

