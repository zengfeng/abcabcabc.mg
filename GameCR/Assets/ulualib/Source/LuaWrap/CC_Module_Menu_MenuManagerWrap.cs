using System;
using UnityEngine;
using System.Collections.Generic;
using LuaInterface;
using Object = UnityEngine.Object;

public class CC_Module_Menu_MenuManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetRoot", GetRoot),
			new LuaMethod("AddPreloadCall", AddPreloadCall),
			new LuaMethod("OpenMenu", OpenMenu),
			new LuaMethod("LuaOpenMenuPreInstance", LuaOpenMenuPreInstance),
			new LuaMethod("OpenMenuPreInstance", OpenMenuPreInstance),
			new LuaMethod("OpenMenuBack", OpenMenuBack),
			new LuaMethod("GetBackId", GetBackId),
			new LuaMethod("Back", Back),
			new LuaMethod("CloseMenu", CloseMenu),
			new LuaMethod("OnOpenHandler", OnOpenHandler),
			new LuaMethod("OnCloseHandler", OnCloseHandler),
			new LuaMethod("GetPreloadFiles", GetPreloadFiles),
			new LuaMethod("OnPreloadFile", OnPreloadFile),
			new LuaMethod("CheckMenuOpen", CheckMenuOpen),
			new LuaMethod("CloseCurrent", CloseCurrent),
			new LuaMethod("CloseAll", CloseAll),
			new LuaMethod("Clear", Clear),
			new LuaMethod("New", _CreateCC_Module_Menu_MenuManager),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("forceDestroyAll", get_forceDestroyAll, set_forceDestroyAll),
			new LuaField("activeFullScreenWindowCount", get_activeFullScreenWindowCount, set_activeFullScreenWindowCount),
			new LuaField("blurBG", get_blurBG, null),
			new LuaField("currentWindowId", get_currentWindowId, null),
			new LuaField("currentWindow", get_currentWindow, null),
		};

		LuaScriptMgr.RegisterLib(L, "CC.Module.Menu.MenuManager", typeof(CC.Module.Menu.MenuManager), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCC_Module_Menu_MenuManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CC.Module.Menu.MenuManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CC.Module.Menu.MenuManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_forceDestroyAll(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name forceDestroyAll");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index forceDestroyAll on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.forceDestroyAll);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_activeFullScreenWindowCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name activeFullScreenWindowCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index activeFullScreenWindowCount on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.activeFullScreenWindowCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_blurBG(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name blurBG");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index blurBG on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.blurBG);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_currentWindowId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name currentWindowId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index currentWindowId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.currentWindowId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_currentWindow(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name currentWindow");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index currentWindow on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.currentWindow);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_forceDestroyAll(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name forceDestroyAll");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index forceDestroyAll on a nil value");
			}
		}

		obj.forceDestroyAll = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_activeFullScreenWindowCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name activeFullScreenWindowCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index activeFullScreenWindowCount on a nil value");
			}
		}

		obj.activeFullScreenWindowCount = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRoot(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
		CC.Module.Menu.MenuLayerType arg0 = (CC.Module.Menu.MenuLayerType)LuaScriptMgr.GetNetObject(L, 2, typeof(CC.Module.Menu.MenuLayerType));
		Transform o = obj.GetRoot(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddPreloadCall(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Func<int,object,List<string>> arg1 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg1 = (Func<int,object,List<string>>)LuaScriptMgr.GetNetObject(L, 3, typeof(Func<int,object,List<string>>));
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
					object[] objs = func.PopValues(top);
					func.EndPCall(top);
					return (List<string>)objs[0];
				};
			}

			obj.AddPreloadCall(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Func<int,object,List<string>> arg1 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg1 = (Func<int,object,List<string>>)LuaScriptMgr.GetNetObject(L, 3, typeof(Func<int,object,List<string>>));
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
					object[] objs = func.PopValues(top);
					func.EndPCall(top);
					return (List<string>)objs[0];
				};
			}

			Action<string,object> arg2 = null;
			LuaTypes funcType4 = LuaDLL.lua_type(L, 4);

			if (funcType4 != LuaTypes.LUA_TFUNCTION)
			{
				 arg2 = (Action<string,object>)LuaScriptMgr.GetNetObject(L, 4, typeof(Action<string,object>));
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 4);
				arg2 = (param0, param1) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					LuaScriptMgr.PushVarObject(L, param1);
					func.PCall(top, 2);
					func.EndPCall(top);
				};
			}

			obj.AddPreloadCall(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.Module.Menu.MenuManager.AddPreloadCall");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OpenMenu(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			obj.OpenMenu(arg0);
			return 0;
		}
		else if (count == 3)
		{
			CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			obj.OpenMenu(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			CC.Module.Menu.LoadType arg2 = (CC.Module.Menu.LoadType)LuaScriptMgr.GetNetObject(L, 4, typeof(CC.Module.Menu.LoadType));
			obj.OpenMenu(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.Module.Menu.MenuManager.OpenMenu");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpenMenuPreInstance(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4)
		{
			CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			LuaTable arg1 = LuaScriptMgr.GetLuaTable(L, 3);
			LuaFunction arg2 = LuaScriptMgr.GetLuaFunction(L, 4);
			obj.LuaOpenMenuPreInstance(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 5)
		{
			CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			LuaTable arg2 = LuaScriptMgr.GetLuaTable(L, 4);
			LuaFunction arg3 = LuaScriptMgr.GetLuaFunction(L, 5);
			obj.LuaOpenMenuPreInstance(arg0,arg1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.Module.Menu.MenuManager.LuaOpenMenuPreInstance");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OpenMenuPreInstance(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			obj.OpenMenuPreInstance(arg0);
			return 0;
		}
		else if (count == 3)
		{
			CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Action<int> arg1 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg1 = (Action<int>)LuaScriptMgr.GetNetObject(L, 3, typeof(Action<int>));
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg1 = (param0) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					func.PCall(top, 1);
					func.EndPCall(top);
				};
			}

			obj.OpenMenuPreInstance(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			Action<int> arg2 = null;
			LuaTypes funcType4 = LuaDLL.lua_type(L, 4);

			if (funcType4 != LuaTypes.LUA_TFUNCTION)
			{
				 arg2 = (Action<int>)LuaScriptMgr.GetNetObject(L, 4, typeof(Action<int>));
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 4);
				arg2 = (param0) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					func.PCall(top, 1);
					func.EndPCall(top);
				};
			}

			obj.OpenMenuPreInstance(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.Module.Menu.MenuManager.OpenMenuPreInstance");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OpenMenuBack(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			obj.OpenMenuBack(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			object arg2 = LuaScriptMgr.GetVarObject(L, 4);
			obj.OpenMenuBack(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 5)
		{
			CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			object arg2 = LuaScriptMgr.GetVarObject(L, 4);
			CC.Module.Menu.LoadType arg3 = (CC.Module.Menu.LoadType)LuaScriptMgr.GetNetObject(L, 5, typeof(CC.Module.Menu.LoadType));
			obj.OpenMenuBack(arg0,arg1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.Module.Menu.MenuManager.OpenMenuBack");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBackId(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int o = obj.GetBackId(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Back(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			obj.Back(arg0);
			return 0;
		}
		else if (count == 3)
		{
			CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			obj.Back(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			obj.Back(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.Module.Menu.MenuManager.Back");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CloseMenu(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.CloseMenu(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnOpenHandler(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
		CC.Runtime.IModule arg0 = (CC.Runtime.IModule)LuaScriptMgr.GetNetObject(L, 2, typeof(CC.Runtime.IModule));
		obj.OnOpenHandler(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnCloseHandler(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
		CC.Runtime.IModule arg0 = (CC.Runtime.IModule)LuaScriptMgr.GetNetObject(L, 2, typeof(CC.Runtime.IModule));
		obj.OnCloseHandler(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPreloadFiles(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		object arg1 = LuaScriptMgr.GetVarObject(L, 3);
		List<string> o = obj.GetPreloadFiles(arg0,arg1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPreloadFile(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		object arg2 = LuaScriptMgr.GetVarObject(L, 4);
		obj.OnPreloadFile(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CheckMenuOpen(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		bool o = obj.CheckMenuOpen(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CloseCurrent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
		obj.CloseCurrent();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CloseAll(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
		obj.CloseAll();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clear(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.Module.Menu.MenuManager obj = (CC.Module.Menu.MenuManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.Module.Menu.MenuManager");
		obj.Clear();
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

