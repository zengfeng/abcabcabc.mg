using System;
using System.Collections.Generic;
using LuaInterface;

public class Games_Module_Wars_WarEnterDataWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetSkillConfig", GetSkillConfig),
			new LuaMethod("ToString", ToString),
			new LuaMethod("CheckWatchRole", CheckWatchRole),
			new LuaMethod("Init", Init),
			new LuaMethod("FindMinLegionId", FindMinLegionId),
			new LuaMethod("HasEnterLegionData", HasEnterLegionData),
			new LuaMethod("GetSoliderProps", GetSoliderProps),
			new LuaMethod("GetSoliderLevel", GetSoliderLevel),
			new LuaMethod("GetSoliderAvatarId", GetSoliderAvatarId),
			new LuaMethod("GetHeroInitHP", GetHeroInitHP),
			new LuaMethod("GetTotalMaxHP", GetTotalMaxHP),
			new LuaMethod("GetTotalHP", GetTotalHP),
			new LuaMethod("GetMag", GetMag),
			new LuaMethod("GetEnterLegionData", GetEnterLegionData),
			new LuaMethod("GetRoleId", GetRoleId),
			new LuaMethod("CreateTest", CreateTest),
			new LuaMethod("New", _CreateGames_Module_Wars_WarEnterData),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__tostring", Lua_ToString),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("overMenuId", get_overMenuId, set_overMenuId),
			new LuaField("backMenuId", get_backMenuId, set_backMenuId),
			new LuaField("stageId", get_stageId, set_stageId),
			new LuaField("stageIndex", get_stageIndex, set_stageIndex),
			new LuaField("isRecord", get_isRecord, set_isRecord),
			new LuaField("vsmode", get_vsmode, set_vsmode),
			new LuaField("roomId", get_roomId, set_roomId),
			new LuaField("mainLegionId", get_mainLegionId, set_mainLegionId),
			new LuaField("ownRoleId", get_ownRoleId, set_ownRoleId),
			new LuaField("ownLegionId", get_ownLegionId, set_ownLegionId),
			new LuaField("rivalRoleId", get_rivalRoleId, set_rivalRoleId),
			new LuaField("legionList", get_legionList, set_legionList),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.WarEnterData", typeof(Games.Module.Wars.WarEnterData), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Wars_WarEnterData(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Wars.WarEnterData obj = new Games.Module.Wars.WarEnterData();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.WarEnterData.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Wars.WarEnterData);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_overMenuId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name overMenuId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index overMenuId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.overMenuId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_backMenuId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name backMenuId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index backMenuId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.backMenuId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stageId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stageId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stageId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.stageId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stageIndex(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stageIndex");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stageIndex on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.stageIndex);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isRecord(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isRecord");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isRecord on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isRecord);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_vsmode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name vsmode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index vsmode on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.vsmode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_roomId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roomId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roomId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.roomId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainLegionId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainLegionId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainLegionId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mainLegionId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ownRoleId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ownRoleId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ownRoleId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.ownRoleId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ownLegionId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ownLegionId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ownLegionId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.ownLegionId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rivalRoleId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rivalRoleId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rivalRoleId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.rivalRoleId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_legionList(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name legionList");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index legionList on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.legionList);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_overMenuId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name overMenuId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index overMenuId on a nil value");
			}
		}

		obj.overMenuId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_backMenuId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name backMenuId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index backMenuId on a nil value");
			}
		}

		obj.backMenuId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stageId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stageId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stageId on a nil value");
			}
		}

		obj.stageId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stageIndex(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stageIndex");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stageIndex on a nil value");
			}
		}

		obj.stageIndex = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isRecord(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isRecord");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isRecord on a nil value");
			}
		}

		obj.isRecord = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_vsmode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name vsmode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index vsmode on a nil value");
			}
		}

		obj.vsmode = (Games.Module.Wars.VSMode)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.VSMode));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_roomId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roomId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roomId on a nil value");
			}
		}

		obj.roomId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainLegionId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainLegionId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainLegionId on a nil value");
			}
		}

		obj.mainLegionId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ownRoleId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ownRoleId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ownRoleId on a nil value");
			}
		}

		obj.ownRoleId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ownLegionId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ownLegionId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ownLegionId on a nil value");
			}
		}

		obj.ownLegionId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rivalRoleId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rivalRoleId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rivalRoleId on a nil value");
			}
		}

		obj.rivalRoleId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_legionList(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name legionList");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index legionList on a nil value");
			}
		}

		obj.legionList = (List<Games.Module.Wars.WarEnterLegionData>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<Games.Module.Wars.WarEnterLegionData>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		object obj = LuaScriptMgr.GetLuaObject(L, 1);

		if (obj != null)
		{
			LuaScriptMgr.Push(L, obj.ToString());
		}
		else
		{
			LuaScriptMgr.Push(L, "Table: Games.Module.Wars.WarEnterData");
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSkillConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterData");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.ISkillConfig o = obj.GetSkillConfig(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterData");
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CheckWatchRole(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterData");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.CheckWatchRole(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterData");
		obj.Init();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindMinLegionId(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterData");
		int o = obj.FindMinLegionId();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HasEnterLegionData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterData");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		bool o = obj.HasEnterLegionData(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSoliderProps(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterData");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Props.Prop[] o = obj.GetSoliderProps(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSoliderLevel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterData");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int o = obj.GetSoliderLevel(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSoliderAvatarId(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterData");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int o = obj.GetSoliderAvatarId(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHeroInitHP(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterData");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		float o = obj.GetHeroInitHP(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTotalMaxHP(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterData");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		float o = obj.GetTotalMaxHP(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTotalHP(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterData");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		float o = obj.GetTotalHP(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMag(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterData");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		float o = obj.GetMag(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEnterLegionData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterData");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Games.Module.Wars.WarEnterLegionData o = obj.GetEnterLegionData(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRoleId(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Wars.WarEnterData obj = (Games.Module.Wars.WarEnterData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterData");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int o = obj.GetRoleId(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateTest(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		int[][] objs2 = LuaScriptMgr.GetArrayObject<int[]>(L, 3);
		int[][] objs3 = LuaScriptMgr.GetArrayObject<int[]>(L, 4);
		Games.Module.Wars.WarEnterData o = Games.Module.Wars.WarEnterData.CreateTest(arg0,arg1,objs2,objs3);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}
}

