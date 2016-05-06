using System;
using LuaInterface;

public class CC_Runtime_PB_ProtoLeagueInfoWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateCC_Runtime_PB_ProtoLeagueInfo),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("leagueId", get_leagueId, set_leagueId),
			new LuaField("leagueIdSpecified", get_leagueIdSpecified, set_leagueIdSpecified),
			new LuaField("name", get_name, set_name),
			new LuaField("nameSpecified", get_nameSpecified, set_nameSpecified),
			new LuaField("icon", get_icon, set_icon),
			new LuaField("iconSpecified", get_iconSpecified, set_iconSpecified),
			new LuaField("prize", get_prize, set_prize),
			new LuaField("prizeSpecified", get_prizeSpecified, set_prizeSpecified),
			new LuaField("member_count", get_member_count, set_member_count),
			new LuaField("member_countSpecified", get_member_countSpecified, set_member_countSpecified),
			new LuaField("description", get_description, set_description),
			new LuaField("descriptionSpecified", get_descriptionSpecified, set_descriptionSpecified),
			new LuaField("type", get_type, set_type),
			new LuaField("typeSpecified", get_typeSpecified, set_typeSpecified),
			new LuaField("need_prize", get_need_prize, set_need_prize),
			new LuaField("need_prizeSpecified", get_need_prizeSpecified, set_need_prizeSpecified),
			new LuaField("location", get_location, set_location),
			new LuaField("locationSpecified", get_locationSpecified, set_locationSpecified),
			new LuaField("donate_card_weekly", get_donate_card_weekly, set_donate_card_weekly),
			new LuaField("donate_card_weeklySpecified", get_donate_card_weeklySpecified, set_donate_card_weeklySpecified),
			new LuaField("members", get_members, null),
		};

		LuaScriptMgr.RegisterLib(L, "CC.Runtime.PB.ProtoLeagueInfo", typeof(CC.Runtime.PB.ProtoLeagueInfo), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCC_Runtime_PB_ProtoLeagueInfo(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			CC.Runtime.PB.ProtoLeagueInfo obj = new CC.Runtime.PB.ProtoLeagueInfo();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.Runtime.PB.ProtoLeagueInfo.New");
		}

		return 0;
	}

	static Type classType = typeof(CC.Runtime.PB.ProtoLeagueInfo);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_leagueId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name leagueId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index leagueId on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.leagueId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_leagueIdSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name leagueIdSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index leagueIdSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.leagueIdSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

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
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

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
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

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
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

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
	static int get_prize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

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
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

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
	static int get_member_count(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name member_count");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index member_count on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.member_count);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_member_countSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name member_countSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index member_countSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.member_countSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_description(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name description");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index description on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.description);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_descriptionSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name descriptionSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index descriptionSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.descriptionSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_type(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name type");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index type on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.type);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_typeSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name typeSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index typeSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.typeSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_need_prize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name need_prize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index need_prize on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.need_prize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_need_prizeSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name need_prizeSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index need_prizeSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.need_prizeSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_location(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name location");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index location on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.location);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_locationSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name locationSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index locationSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.locationSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_donate_card_weekly(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name donate_card_weekly");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index donate_card_weekly on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.donate_card_weekly);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_donate_card_weeklySpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name donate_card_weeklySpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index donate_card_weeklySpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.donate_card_weeklySpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_members(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name members");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index members on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.members);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_leagueId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name leagueId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index leagueId on a nil value");
			}
		}

		obj.leagueId = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_leagueIdSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name leagueIdSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index leagueIdSpecified on a nil value");
			}
		}

		obj.leagueIdSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

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
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

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
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

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
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

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
	static int set_prize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

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
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

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

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_member_count(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name member_count");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index member_count on a nil value");
			}
		}

		obj.member_count = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_member_countSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name member_countSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index member_countSpecified on a nil value");
			}
		}

		obj.member_countSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_description(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name description");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index description on a nil value");
			}
		}

		obj.description = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_descriptionSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name descriptionSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index descriptionSpecified on a nil value");
			}
		}

		obj.descriptionSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_type(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name type");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index type on a nil value");
			}
		}

		obj.type = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_typeSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name typeSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index typeSpecified on a nil value");
			}
		}

		obj.typeSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_need_prize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name need_prize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index need_prize on a nil value");
			}
		}

		obj.need_prize = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_need_prizeSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name need_prizeSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index need_prizeSpecified on a nil value");
			}
		}

		obj.need_prizeSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_location(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name location");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index location on a nil value");
			}
		}

		obj.location = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_locationSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name locationSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index locationSpecified on a nil value");
			}
		}

		obj.locationSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_donate_card_weekly(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name donate_card_weekly");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index donate_card_weekly on a nil value");
			}
		}

		obj.donate_card_weekly = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_donate_card_weeklySpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoLeagueInfo obj = (CC.Runtime.PB.ProtoLeagueInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name donate_card_weeklySpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index donate_card_weeklySpecified on a nil value");
			}
		}

		obj.donate_card_weeklySpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}
}

