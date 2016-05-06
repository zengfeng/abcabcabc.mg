using System;
using System.Collections.Generic;
using LuaInterface;

public class Games_Module_Wars_WarEnterLegionDataWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("CheckProps", CheckProps),
			new LuaMethod("ToString", ToString),
			new LuaMethod("New", _CreateGames_Module_Wars_WarEnterLegionData),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__tostring", Lua_ToString),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("_prop1Factor", get__prop1Factor, set__prop1Factor),
			new LuaField("_prop2Factor", get__prop2Factor, set__prop2Factor),
			new LuaField("_prop3Factor", get__prop3Factor, set__prop3Factor),
			new LuaField("name", get_name, set_name),
			new LuaField("roleId", get_roleId, set_roleId),
			new LuaField("legionId", get_legionId, set_legionId),
			new LuaField("isRobot", get_isRobot, set_isRobot),
			new LuaField("headAvatarId", get_headAvatarId, set_headAvatarId),
			new LuaField("ai", get_ai, set_ai),
			new LuaField("solider", get_solider, set_solider),
			new LuaField("heroList", get_heroList, set_heroList),
			new LuaField("maxHP", get_maxHP, set_maxHP),
			new LuaField("hp", get_hp, set_hp),
			new LuaField("marale", get_marale, set_marale),
			new LuaField("head", get_head, set_head),
			new LuaField("initHP", get_initHP, set_initHP),
			new LuaField("atk", get_atk, set_atk),
			new LuaField("produceSpeed", get_produceSpeed, set_produceSpeed),
			new LuaField("movespeed", get_movespeed, set_movespeed),
			new LuaField("totalAtk", get_totalAtk, set_totalAtk),
			new LuaField("totalProduceSpeed", get_totalProduceSpeed, set_totalProduceSpeed),
			new LuaField("totalMoveSpeed", get_totalMoveSpeed, set_totalMoveSpeed),
			new LuaField("subAtk", get_subAtk, set_subAtk),
			new LuaField("subProduceSpeed", get_subProduceSpeed, set_subProduceSpeed),
			new LuaField("subMoveSpeed", get_subMoveSpeed, set_subMoveSpeed),
			new LuaField("maxAtk", get_maxAtk, set_maxAtk),
			new LuaField("maxProduceSpeed", get_maxProduceSpeed, set_maxProduceSpeed),
			new LuaField("maxMovespeed", get_maxMovespeed, set_maxMovespeed),
			new LuaField("prize", get_prize, set_prize),
			new LuaField("level", get_level, set_level),
			new LuaField("prop1Factor", get_prop1Factor, set_prop1Factor),
			new LuaField("prop2Factor", get_prop2Factor, set_prop2Factor),
			new LuaField("prop3Factor", get_prop3Factor, set_prop3Factor),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.WarEnterLegionData", typeof(Games.Module.Wars.WarEnterLegionData), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Wars_WarEnterLegionData(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Wars.WarEnterLegionData obj = new Games.Module.Wars.WarEnterLegionData();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.WarEnterLegionData.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Wars.WarEnterLegionData);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get__prop1Factor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name _prop1Factor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index _prop1Factor on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj._prop1Factor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get__prop2Factor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name _prop2Factor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index _prop2Factor on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj._prop2Factor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get__prop3Factor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name _prop3Factor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index _prop3Factor on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj._prop3Factor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name name");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index name on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.name);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_roleId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roleId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roleId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.roleId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_legionId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name legionId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index legionId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.legionId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isRobot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isRobot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isRobot on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isRobot);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_headAvatarId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name headAvatarId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index headAvatarId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.headAvatarId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ai(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ai");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ai on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.ai);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_solider(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name solider");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index solider on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.solider);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_heroList(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name heroList");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index heroList on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.heroList);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxHP(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxHP");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxHP on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.maxHP);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hp on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.hp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_marale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name marale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index marale on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.marale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_head(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name head");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index head on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.head);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_initHP(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name initHP");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index initHP on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.initHP);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_atk(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name atk");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index atk on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.atk);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_produceSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name produceSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index produceSpeed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.produceSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_movespeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name movespeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index movespeed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.movespeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_totalAtk(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name totalAtk");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index totalAtk on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.totalAtk);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_totalProduceSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name totalProduceSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index totalProduceSpeed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.totalProduceSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_totalMoveSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name totalMoveSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index totalMoveSpeed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.totalMoveSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_subAtk(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name subAtk");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index subAtk on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.subAtk);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_subProduceSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name subProduceSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index subProduceSpeed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.subProduceSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_subMoveSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name subMoveSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index subMoveSpeed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.subMoveSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxAtk(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxAtk");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxAtk on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.maxAtk);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxProduceSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxProduceSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxProduceSpeed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.maxProduceSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxMovespeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxMovespeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxMovespeed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.maxMovespeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_prize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name prize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index prize on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.prize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_level(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name level");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index level on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.level);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_prop1Factor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name prop1Factor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index prop1Factor on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.prop1Factor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_prop2Factor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name prop2Factor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index prop2Factor on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.prop2Factor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_prop3Factor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name prop3Factor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index prop3Factor on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.prop3Factor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set__prop1Factor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name _prop1Factor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index _prop1Factor on a nil value");
			}
		}

		obj._prop1Factor = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set__prop2Factor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name _prop2Factor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index _prop2Factor on a nil value");
			}
		}

		obj._prop2Factor = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set__prop3Factor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name _prop3Factor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index _prop3Factor on a nil value");
			}
		}

		obj._prop3Factor = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name name");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index name on a nil value");
			}
		}

		obj.name = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_roleId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roleId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roleId on a nil value");
			}
		}

		obj.roleId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_legionId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name legionId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index legionId on a nil value");
			}
		}

		obj.legionId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isRobot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isRobot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isRobot on a nil value");
			}
		}

		obj.isRobot = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_headAvatarId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name headAvatarId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index headAvatarId on a nil value");
			}
		}

		obj.headAvatarId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ai(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ai");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ai on a nil value");
			}
		}

		obj.ai = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_solider(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name solider");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index solider on a nil value");
			}
		}

		obj.solider = (Games.Module.Wars.WarEnterSoliderData)LuaScriptMgr.GetNetObject(L, 3, typeof(Games.Module.Wars.WarEnterSoliderData));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_heroList(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name heroList");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index heroList on a nil value");
			}
		}

		obj.heroList = (List<Games.Module.Wars.WarEnterHeroData>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<Games.Module.Wars.WarEnterHeroData>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxHP(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxHP");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxHP on a nil value");
			}
		}

		obj.maxHP = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_hp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hp on a nil value");
			}
		}

		obj.hp = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_marale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name marale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index marale on a nil value");
			}
		}

		obj.marale = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_head(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name head");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index head on a nil value");
			}
		}

		obj.head = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_initHP(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name initHP");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index initHP on a nil value");
			}
		}

		obj.initHP = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_atk(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name atk");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index atk on a nil value");
			}
		}

		obj.atk = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_produceSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name produceSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index produceSpeed on a nil value");
			}
		}

		obj.produceSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_movespeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name movespeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index movespeed on a nil value");
			}
		}

		obj.movespeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_totalAtk(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name totalAtk");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index totalAtk on a nil value");
			}
		}

		obj.totalAtk = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_totalProduceSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name totalProduceSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index totalProduceSpeed on a nil value");
			}
		}

		obj.totalProduceSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_totalMoveSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name totalMoveSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index totalMoveSpeed on a nil value");
			}
		}

		obj.totalMoveSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_subAtk(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name subAtk");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index subAtk on a nil value");
			}
		}

		obj.subAtk = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_subProduceSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name subProduceSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index subProduceSpeed on a nil value");
			}
		}

		obj.subProduceSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_subMoveSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name subMoveSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index subMoveSpeed on a nil value");
			}
		}

		obj.subMoveSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxAtk(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxAtk");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxAtk on a nil value");
			}
		}

		obj.maxAtk = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxProduceSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxProduceSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxProduceSpeed on a nil value");
			}
		}

		obj.maxProduceSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxMovespeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxMovespeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxMovespeed on a nil value");
			}
		}

		obj.maxMovespeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_prize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name prize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index prize on a nil value");
			}
		}

		obj.prize = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_level(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name level");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index level on a nil value");
			}
		}

		obj.level = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_prop1Factor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name prop1Factor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index prop1Factor on a nil value");
			}
		}

		obj.prop1Factor = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_prop2Factor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name prop2Factor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index prop2Factor on a nil value");
			}
		}

		obj.prop2Factor = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_prop3Factor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name prop3Factor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index prop3Factor on a nil value");
			}
		}

		obj.prop3Factor = (float)LuaScriptMgr.GetNumber(L, 3);
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
			LuaScriptMgr.Push(L, "Table: Games.Module.Wars.WarEnterLegionData");
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CheckProps(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterLegionData");
		obj.CheckProps();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Wars.WarEnterLegionData obj = (Games.Module.Wars.WarEnterLegionData)LuaScriptMgr.GetNetObjectSelf(L, 1, "Games.Module.Wars.WarEnterLegionData");
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

