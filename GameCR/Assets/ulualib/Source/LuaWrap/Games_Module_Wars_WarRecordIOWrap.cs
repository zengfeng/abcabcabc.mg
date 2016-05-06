using System;
using System.Collections.Generic;
using LuaInterface;

public class Games_Module_Wars_WarRecordIOWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Save", Save),
			new LuaMethod("GetVideo", GetVideo),
			new LuaMethod("Upload", Upload),
			new LuaMethod("GetList", GetList),
			new LuaMethod("SetWatchCount", SetWatchCount),
			new LuaMethod("Delete", Delete),
			new LuaMethod("Clear", Clear),
			new LuaMethod("New", _CreateGames_Module_Wars_WarRecordIO),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.WarRecordIO", typeof(Games.Module.Wars.WarRecordIO), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Wars_WarRecordIO(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Wars.WarRecordIO obj = new Games.Module.Wars.WarRecordIO();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.WarRecordIO.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Wars.WarRecordIO);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Save(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarRecordIO obj = (Games.Module.Wars.WarRecordIO)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarRecordIO");
		Games.Module.Wars.WarOverData arg0 = (Games.Module.Wars.WarOverData)LuaScriptMgr.GetNetObject(L, 2, typeof(Games.Module.Wars.WarOverData));
		obj.Save(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetVideo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarRecordIO obj = (Games.Module.Wars.WarRecordIO)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarRecordIO");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		CC.Runtime.PB.ProtoBattleVideoInfo o = obj.GetVideo(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Upload(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Games.Module.Wars.WarRecordIO), typeof(CC.Runtime.PB.ProtoBattleVideoInfo), typeof(int), typeof(int)))
		{
			Games.Module.Wars.WarRecordIO obj = (Games.Module.Wars.WarRecordIO)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarRecordIO");
			CC.Runtime.PB.ProtoBattleVideoInfo arg0 = (CC.Runtime.PB.ProtoBattleVideoInfo)LuaScriptMgr.GetLuaObject(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			obj.Upload(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Games.Module.Wars.WarRecordIO), typeof(int), typeof(int), typeof(int)))
		{
			Games.Module.Wars.WarRecordIO obj = (Games.Module.Wars.WarRecordIO)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarRecordIO");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			obj.Upload(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.WarRecordIO.Upload");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetList(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.WarRecordIO obj = (Games.Module.Wars.WarRecordIO)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarRecordIO");
		List<CC.Runtime.PB.ProtoBattleVideoInfo> o = obj.GetList();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetWatchCount(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Games.Module.Wars.WarRecordIO obj = (Games.Module.Wars.WarRecordIO)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarRecordIO");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.SetWatchCount(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Delete(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarRecordIO obj = (Games.Module.Wars.WarRecordIO)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarRecordIO");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.Delete(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clear(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.WarRecordIO obj = (Games.Module.Wars.WarRecordIO)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarRecordIO");
		obj.Clear();
		return 0;
	}
}

