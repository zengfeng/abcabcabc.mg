using System;
using LuaInterface;

public class Games_Module_Sysmsgs_SysmsgManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Execute", Execute),
			new LuaMethod("LuaExecute", LuaExecute),
			new LuaMethod("LoadConfig", LoadConfig),
			new LuaMethod("New", _CreateGames_Module_Sysmsgs_SysmsgManager),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Sysmsgs.SysmsgManager", typeof(Games.Module.Sysmsgs.SysmsgManager), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Sysmsgs_SysmsgManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Games.Module.Sysmsgs.SysmsgManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(Games.Module.Sysmsgs.SysmsgManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Execute(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			Games.Module.Sysmsgs.SysmsgManager.Execute(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Action<int>)))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			Action<int> arg1 = null;
			LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

			if (funcType2 != LuaTypes.LUA_TFUNCTION)
			{
				 arg1 = (Action<int>)LuaScriptMgr.GetLuaObject(L, 2);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
				arg1 = (param0) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					func.PCall(top, 1);
					func.EndPCall(top);
				};
			}

			Games.Module.Sysmsgs.SysmsgManager.Execute(arg0,arg1);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(object[])))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			object[] objs1 = LuaScriptMgr.GetArrayObject<object>(L, 2);
			Games.Module.Sysmsgs.SysmsgManager.Execute(arg0,objs1);
			return 0;
		}
		else if (count == 3)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			object[] objs1 = LuaScriptMgr.GetArrayObject<object>(L, 2);
			Action<int> arg2 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg2 = (Action<int>)LuaScriptMgr.GetNetObject(L, 3, typeof(Action<int>));
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg2 = (param0) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					func.PCall(top, 1);
					func.EndPCall(top);
				};
			}

			Games.Module.Sysmsgs.SysmsgManager.Execute(arg0,objs1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Sysmsgs.SysmsgManager.Execute");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaExecute(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			object[] objs1 = LuaScriptMgr.GetArrayObject<object>(L, 2);
			Games.Module.Sysmsgs.SysmsgManager.LuaExecute(arg0,objs1);
			return 0;
		}
		else if (count == 3)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			object[] objs1 = LuaScriptMgr.GetArrayObject<object>(L, 2);
			LuaFunction arg2 = LuaScriptMgr.GetLuaFunction(L, 3);
			Games.Module.Sysmsgs.SysmsgManager.LuaExecute(arg0,objs1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Sysmsgs.SysmsgManager.LuaExecute");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Games.Module.Sysmsgs.SysmsgManager.LoadConfig();
		return 0;
	}
}

