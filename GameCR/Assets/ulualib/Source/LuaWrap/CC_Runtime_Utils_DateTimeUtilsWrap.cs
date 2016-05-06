using System;
using LuaInterface;

public class CC_Runtime_Utils_DateTimeUtilsWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("ConvertIntDatetime", ConvertIntDatetime),
			new LuaMethod("ConvertDateTimeInt", ConvertDateTimeInt),
			new LuaMethod("DateStringFromNow", DateStringFromNow),
			new LuaMethod("New", _CreateCC_Runtime_Utils_DateTimeUtils),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("CurrentTimestamp", get_CurrentTimestamp, null),
		};

		LuaScriptMgr.RegisterLib(L, "CC.Runtime.Utils.DateTimeUtils", typeof(CC.Runtime.Utils.DateTimeUtils), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCC_Runtime_Utils_DateTimeUtils(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CC.Runtime.Utils.DateTimeUtils class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CC.Runtime.Utils.DateTimeUtils);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CurrentTimestamp(IntPtr L)
	{
		LuaScriptMgr.Push(L, CC.Runtime.Utils.DateTimeUtils.CurrentTimestamp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ConvertIntDatetime(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		double arg0 = (double)LuaScriptMgr.GetNumber(L, 1);
		DateTime o = CC.Runtime.Utils.DateTimeUtils.ConvertIntDatetime(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ConvertDateTimeInt(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		DateTime arg0 = (DateTime)LuaScriptMgr.GetNetObject(L, 1, typeof(DateTime));
		int o = CC.Runtime.Utils.DateTimeUtils.ConvertDateTimeInt(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DateStringFromNow(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(DateTime)))
		{
			DateTime arg0 = (DateTime)LuaScriptMgr.GetLuaObject(L, 1);
			string o = CC.Runtime.Utils.DateTimeUtils.DateStringFromNow(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(int)))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			string o = CC.Runtime.Utils.DateTimeUtils.DateStringFromNow(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.Runtime.Utils.DateTimeUtils.DateStringFromNow");
		}

		return 0;
	}
}

