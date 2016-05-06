using System;
using LuaInterface;

public class CC_Runtime_PB_ProtoRoleBaseInfoWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateCC_Runtime_PB_ProtoRoleBaseInfo),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("roleId", get_roleId, set_roleId),
			new LuaField("roleIdSpecified", get_roleIdSpecified, set_roleIdSpecified),
			new LuaField("name", get_name, set_name),
			new LuaField("nameSpecified", get_nameSpecified, set_nameSpecified),
			new LuaField("icon", get_icon, set_icon),
			new LuaField("iconSpecified", get_iconSpecified, set_iconSpecified),
			new LuaField("level", get_level, set_level),
			new LuaField("levelSpecified", get_levelSpecified, set_levelSpecified),
			new LuaField("level_exp", get_level_exp, set_level_exp),
			new LuaField("level_expSpecified", get_level_expSpecified, set_level_expSpecified),
			new LuaField("prize", get_prize, set_prize),
			new LuaField("prizeSpecified", get_prizeSpecified, set_prizeSpecified),
		};

		LuaScriptMgr.RegisterLib(L, "CC.Runtime.PB.ProtoRoleBaseInfo", typeof(CC.Runtime.PB.ProtoRoleBaseInfo), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCC_Runtime_PB_ProtoRoleBaseInfo(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			CC.Runtime.PB.ProtoRoleBaseInfo obj = new CC.Runtime.PB.ProtoRoleBaseInfo();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.Runtime.PB.ProtoRoleBaseInfo.New");
		}

		return 0;
	}

	static Type classType = typeof(CC.Runtime.PB.ProtoRoleBaseInfo);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_roleId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

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
	static int get_roleIdSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roleIdSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roleIdSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.roleIdSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

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
	static int get_nameSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name nameSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index nameSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.nameSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_icon(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name icon");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index icon on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.icon);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_iconSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name iconSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index iconSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.iconSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_level(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

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
	static int get_levelSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name levelSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index levelSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.levelSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_level_exp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name level_exp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index level_exp on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.level_exp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_level_expSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name level_expSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index level_expSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.level_expSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_prize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

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
	static int get_prizeSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name prizeSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index prizeSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.prizeSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_roleId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

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
	static int set_roleIdSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roleIdSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roleIdSpecified on a nil value");
			}
		}

		obj.roleIdSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

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
	static int set_nameSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name nameSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index nameSpecified on a nil value");
			}
		}

		obj.nameSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_icon(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name icon");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index icon on a nil value");
			}
		}

		obj.icon = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_iconSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name iconSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index iconSpecified on a nil value");
			}
		}

		obj.iconSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_level(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

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
	static int set_levelSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name levelSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index levelSpecified on a nil value");
			}
		}

		obj.levelSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_level_exp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name level_exp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index level_exp on a nil value");
			}
		}

		obj.level_exp = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_level_expSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name level_expSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index level_expSpecified on a nil value");
			}
		}

		obj.level_expSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_prize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

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
	static int set_prizeSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoRoleBaseInfo obj = (CC.Runtime.PB.ProtoRoleBaseInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name prizeSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index prizeSpecified on a nil value");
			}
		}

		obj.prizeSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}
}

