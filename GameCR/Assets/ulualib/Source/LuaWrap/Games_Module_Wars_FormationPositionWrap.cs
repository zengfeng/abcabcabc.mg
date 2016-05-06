using System;
using LuaInterface;

public class Games_Module_Wars_FormationPositionWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateGames_Module_Wars_FormationPosition),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("index", get_index, set_index),
			new LuaField("heroId", get_heroId, set_heroId),
			new LuaField("test_skillId", get_test_skillId, set_test_skillId),
			new LuaField("test_skillLevel", get_test_skillLevel, set_test_skillLevel),
			new LuaField("test_skillId2", get_test_skillId2, set_test_skillId2),
			new LuaField("test_skillLevel2", get_test_skillLevel2, set_test_skillLevel2),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Wars.FormationPosition", typeof(Games.Module.Wars.FormationPosition), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Wars_FormationPosition(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Games.Module.Wars.FormationPosition obj = new Games.Module.Wars.FormationPosition();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 2)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			Games.Module.Wars.FormationPosition obj = new Games.Module.Wars.FormationPosition(arg0,arg1);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 6)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			int arg5 = (int)LuaScriptMgr.GetNumber(L, 6);
			Games.Module.Wars.FormationPosition obj = new Games.Module.Wars.FormationPosition(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Games.Module.Wars.FormationPosition.New");
		}

		return 0;
	}

	static Type classType = typeof(Games.Module.Wars.FormationPosition);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_index(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.FormationPosition obj = (Games.Module.Wars.FormationPosition)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name index");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index index on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.index);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_heroId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.FormationPosition obj = (Games.Module.Wars.FormationPosition)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name heroId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index heroId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.heroId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_test_skillId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.FormationPosition obj = (Games.Module.Wars.FormationPosition)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name test_skillId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index test_skillId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.test_skillId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_test_skillLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.FormationPosition obj = (Games.Module.Wars.FormationPosition)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name test_skillLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index test_skillLevel on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.test_skillLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_test_skillId2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.FormationPosition obj = (Games.Module.Wars.FormationPosition)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name test_skillId2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index test_skillId2 on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.test_skillId2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_test_skillLevel2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.FormationPosition obj = (Games.Module.Wars.FormationPosition)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name test_skillLevel2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index test_skillLevel2 on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.test_skillLevel2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_index(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.FormationPosition obj = (Games.Module.Wars.FormationPosition)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name index");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index index on a nil value");
			}
		}

		obj.index = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_heroId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.FormationPosition obj = (Games.Module.Wars.FormationPosition)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name heroId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index heroId on a nil value");
			}
		}

		obj.heroId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_test_skillId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.FormationPosition obj = (Games.Module.Wars.FormationPosition)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name test_skillId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index test_skillId on a nil value");
			}
		}

		obj.test_skillId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_test_skillLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.FormationPosition obj = (Games.Module.Wars.FormationPosition)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name test_skillLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index test_skillLevel on a nil value");
			}
		}

		obj.test_skillLevel = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_test_skillId2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.FormationPosition obj = (Games.Module.Wars.FormationPosition)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name test_skillId2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index test_skillId2 on a nil value");
			}
		}

		obj.test_skillId2 = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_test_skillLevel2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Wars.FormationPosition obj = (Games.Module.Wars.FormationPosition)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name test_skillLevel2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index test_skillLevel2 on a nil value");
			}
		}

		obj.test_skillLevel2 = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

