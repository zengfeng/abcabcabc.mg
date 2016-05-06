using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CityControlWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("UpdateCity", UpdateCity),
			new LuaMethod("StartTween", StartTween),
			new LuaMethod("New", _CreateCityControl),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("city", get_city, set_city),
			new LuaField("province", get_province, set_province),
			new LuaField("cloud", get_cloud, set_cloud),
			new LuaField("defaultScale", get_defaultScale, set_defaultScale),
			new LuaField("maxStableScale", get_maxStableScale, set_maxStableScale),
			new LuaField("maxExtremeScale", get_maxExtremeScale, set_maxExtremeScale),
			new LuaField("maxExtremeBackTime", get_maxExtremeBackTime, set_maxExtremeBackTime),
			new LuaField("moveEndTime", get_moveEndTime, set_moveEndTime),
			new LuaField("space_1", get_space_1, set_space_1),
			new LuaField("cityMoveTime", get_cityMoveTime, set_cityMoveTime),
			new LuaField("provinceScaleTime", get_provinceScaleTime, set_provinceScaleTime),
			new LuaField("provinceStartScale", get_provinceStartScale, set_provinceStartScale),
		};

		LuaScriptMgr.RegisterLib(L, "CityControl", typeof(CityControl), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCityControl(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CityControl class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CityControl);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_city(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name city");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index city on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.city);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_province(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name province");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index province on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.province);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cloud(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cloud");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cloud on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.cloud);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_defaultScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name defaultScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index defaultScale on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.defaultScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxStableScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxStableScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxStableScale on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.maxStableScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxExtremeScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxExtremeScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxExtremeScale on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.maxExtremeScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxExtremeBackTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxExtremeBackTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxExtremeBackTime on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.maxExtremeBackTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_moveEndTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name moveEndTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index moveEndTime on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.moveEndTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_space_1(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name space_1");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index space_1 on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.space_1);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cityMoveTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cityMoveTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cityMoveTime on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.cityMoveTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_provinceScaleTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name provinceScaleTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index provinceScaleTime on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.provinceScaleTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_provinceStartScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name provinceStartScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index provinceStartScale on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.provinceStartScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_city(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name city");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index city on a nil value");
			}
		}

		obj.city = (ScrollZoomContainer)LuaScriptMgr.GetUnityObject(L, 3, typeof(ScrollZoomContainer));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_province(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name province");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index province on a nil value");
			}
		}

		obj.province = (ScrollZoomContainer)LuaScriptMgr.GetUnityObject(L, 3, typeof(ScrollZoomContainer));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cloud(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cloud");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cloud on a nil value");
			}
		}

		obj.cloud = (CloudControl)LuaScriptMgr.GetUnityObject(L, 3, typeof(CloudControl));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_defaultScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name defaultScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index defaultScale on a nil value");
			}
		}

		obj.defaultScale = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxStableScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxStableScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxStableScale on a nil value");
			}
		}

		obj.maxStableScale = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxExtremeScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxExtremeScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxExtremeScale on a nil value");
			}
		}

		obj.maxExtremeScale = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxExtremeBackTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxExtremeBackTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxExtremeBackTime on a nil value");
			}
		}

		obj.maxExtremeBackTime = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_moveEndTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name moveEndTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index moveEndTime on a nil value");
			}
		}

		obj.moveEndTime = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_space_1(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name space_1");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index space_1 on a nil value");
			}
		}

		obj.space_1 = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cityMoveTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cityMoveTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cityMoveTime on a nil value");
			}
		}

		obj.cityMoveTime = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_provinceScaleTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name provinceScaleTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index provinceScaleTime on a nil value");
			}
		}

		obj.provinceScaleTime = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_provinceStartScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CityControl obj = (CityControl)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name provinceStartScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index provinceStartScale on a nil value");
			}
		}

		obj.provinceStartScale = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UpdateCity(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CityControl obj = (CityControl)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CityControl");
		obj.UpdateCity();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartTween(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CityControl obj = (CityControl)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CityControl");
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 2);
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		obj.StartTween(arg0,arg1);
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

