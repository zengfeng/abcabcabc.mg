using System;
using LuaInterface;

public class CC_Runtime_PB_ProtoBattleVideoInfoWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateCC_Runtime_PB_ProtoBattleVideoInfo),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("stageId", get_stageId, set_stageId),
			new LuaField("fight_roles", get_fight_roles, null),
			new LuaField("create_time", get_create_time, set_create_time),
			new LuaField("create_timeSpecified", get_create_timeSpecified, set_create_timeSpecified),
			new LuaField("uuid", get_uuid, set_uuid),
			new LuaField("uuidSpecified", get_uuidSpecified, set_uuidSpecified),
			new LuaField("video_data", get_video_data, set_video_data),
			new LuaField("video_dataSpecified", get_video_dataSpecified, set_video_dataSpecified),
			new LuaField("share_time", get_share_time, set_share_time),
			new LuaField("share_timeSpecified", get_share_timeSpecified, set_share_timeSpecified),
			new LuaField("war_version", get_war_version, set_war_version),
			new LuaField("war_versionSpecified", get_war_versionSpecified, set_war_versionSpecified),
			new LuaField("uid_local", get_uid_local, set_uid_local),
			new LuaField("uid_localSpecified", get_uid_localSpecified, set_uid_localSpecified),
			new LuaField("view_count", get_view_count, set_view_count),
			new LuaField("view_countSpecified", get_view_countSpecified, set_view_countSpecified),
		};

		LuaScriptMgr.RegisterLib(L, "CC.Runtime.PB.ProtoBattleVideoInfo", typeof(CC.Runtime.PB.ProtoBattleVideoInfo), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCC_Runtime_PB_ProtoBattleVideoInfo(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			CC.Runtime.PB.ProtoBattleVideoInfo obj = new CC.Runtime.PB.ProtoBattleVideoInfo();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.Runtime.PB.ProtoBattleVideoInfo.New");
		}

		return 0;
	}

	static Type classType = typeof(CC.Runtime.PB.ProtoBattleVideoInfo);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stageId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

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
	static int get_fight_roles(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fight_roles");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fight_roles on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.fight_roles);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_create_time(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name create_time");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index create_time on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.create_time);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_create_timeSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name create_timeSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index create_timeSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.create_timeSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uuid(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uuid");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uuid on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.uuid);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uuidSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uuidSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uuidSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.uuidSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_video_data(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name video_data");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index video_data on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.video_data);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_video_dataSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name video_dataSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index video_dataSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.video_dataSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_share_time(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name share_time");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index share_time on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.share_time);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_share_timeSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name share_timeSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index share_timeSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.share_timeSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_war_version(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name war_version");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index war_version on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.war_version);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_war_versionSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name war_versionSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index war_versionSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.war_versionSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uid_local(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uid_local");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uid_local on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.uid_local);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uid_localSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uid_localSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uid_localSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.uid_localSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_view_count(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name view_count");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index view_count on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.view_count);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_view_countSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name view_countSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index view_countSpecified on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.view_countSpecified);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stageId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

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
	static int set_create_time(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name create_time");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index create_time on a nil value");
			}
		}

		obj.create_time = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_create_timeSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name create_timeSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index create_timeSpecified on a nil value");
			}
		}

		obj.create_timeSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uuid(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uuid");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uuid on a nil value");
			}
		}

		obj.uuid = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uuidSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uuidSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uuidSpecified on a nil value");
			}
		}

		obj.uuidSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_video_data(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name video_data");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index video_data on a nil value");
			}
		}

		obj.video_data = LuaScriptMgr.GetArrayNumber<byte>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_video_dataSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name video_dataSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index video_dataSpecified on a nil value");
			}
		}

		obj.video_dataSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_share_time(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name share_time");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index share_time on a nil value");
			}
		}

		obj.share_time = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_share_timeSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name share_timeSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index share_timeSpecified on a nil value");
			}
		}

		obj.share_timeSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_war_version(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name war_version");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index war_version on a nil value");
			}
		}

		obj.war_version = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_war_versionSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name war_versionSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index war_versionSpecified on a nil value");
			}
		}

		obj.war_versionSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uid_local(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uid_local");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uid_local on a nil value");
			}
		}

		obj.uid_local = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uid_localSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uid_localSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uid_localSpecified on a nil value");
			}
		}

		obj.uid_localSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_view_count(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name view_count");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index view_count on a nil value");
			}
		}

		obj.view_count = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_view_countSpecified(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.Runtime.PB.ProtoBattleVideoInfo obj = (CC.Runtime.PB.ProtoBattleVideoInfo)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name view_countSpecified");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index view_countSpecified on a nil value");
			}
		}

		obj.view_countSpecified = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}
}

