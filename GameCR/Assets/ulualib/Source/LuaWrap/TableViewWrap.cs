using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class TableViewWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("ReloadData", ReloadData),
			new LuaMethod("Setup", Setup),
			new LuaMethod("SetLineHeightFunc", SetLineHeightFunc),
			new LuaMethod("New", _CreateTableView),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("itemPrefab", get_itemPrefab, set_itemPrefab),
			new LuaField("content", get_content, set_content),
			new LuaField("cellArrange", get_cellArrange, set_cellArrange),
			new LuaField("resizeToFit", get_resizeToFit, set_resizeToFit),
			new LuaField("cellVerticalGap", get_cellVerticalGap, set_cellVerticalGap),
			new LuaField("cellHorizontalGap", get_cellHorizontalGap, set_cellHorizontalGap),
			new LuaField("spacingX", get_spacingX, set_spacingX),
			new LuaField("spacingY", get_spacingY, set_spacingY),
			new LuaField("isNotifyWhenRemove", get_isNotifyWhenRemove, set_isNotifyWhenRemove),
			new LuaField("isMaxArrange", get_isMaxArrange, set_isMaxArrange),
			new LuaField("isDynamicLineHeight", get_isDynamicLineHeight, set_isDynamicLineHeight),
			new LuaField("cellHeight", get_cellHeight, null),
		};

		LuaScriptMgr.RegisterLib(L, "TableView", typeof(TableView), regs, fields, typeof(CC.UI.BaseUI));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTableView(IntPtr L)
	{
		LuaDLL.luaL_error(L, "TableView class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(TableView);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_itemPrefab(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name itemPrefab");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index itemPrefab on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.itemPrefab);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_content(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name content");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index content on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.content);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cellArrange(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cellArrange");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cellArrange on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.cellArrange);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_resizeToFit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name resizeToFit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index resizeToFit on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.resizeToFit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cellVerticalGap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cellVerticalGap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cellVerticalGap on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.cellVerticalGap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cellHorizontalGap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cellHorizontalGap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cellHorizontalGap on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.cellHorizontalGap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spacingX(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spacingX");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spacingX on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.spacingX);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spacingY(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spacingY");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spacingY on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.spacingY);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isNotifyWhenRemove(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isNotifyWhenRemove");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isNotifyWhenRemove on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isNotifyWhenRemove);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isMaxArrange(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isMaxArrange");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isMaxArrange on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isMaxArrange);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isDynamicLineHeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isDynamicLineHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isDynamicLineHeight on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isDynamicLineHeight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cellHeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cellHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cellHeight on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.cellHeight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_itemPrefab(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name itemPrefab");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index itemPrefab on a nil value");
			}
		}

		obj.itemPrefab = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_content(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name content");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index content on a nil value");
			}
		}

		obj.content = (RectTransform)LuaScriptMgr.GetUnityObject(L, 3, typeof(RectTransform));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cellArrange(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cellArrange");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cellArrange on a nil value");
			}
		}

		obj.cellArrange = (TableView.CellArrange)LuaScriptMgr.GetNetObject(L, 3, typeof(TableView.CellArrange));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_resizeToFit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name resizeToFit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index resizeToFit on a nil value");
			}
		}

		obj.resizeToFit = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cellVerticalGap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cellVerticalGap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cellVerticalGap on a nil value");
			}
		}

		obj.cellVerticalGap = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cellHorizontalGap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cellHorizontalGap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cellHorizontalGap on a nil value");
			}
		}

		obj.cellHorizontalGap = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_spacingX(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spacingX");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spacingX on a nil value");
			}
		}

		obj.spacingX = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_spacingY(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spacingY");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spacingY on a nil value");
			}
		}

		obj.spacingY = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isNotifyWhenRemove(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isNotifyWhenRemove");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isNotifyWhenRemove on a nil value");
			}
		}

		obj.isNotifyWhenRemove = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isMaxArrange(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isMaxArrange");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isMaxArrange on a nil value");
			}
		}

		obj.isMaxArrange = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isDynamicLineHeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TableView obj = (TableView)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isDynamicLineHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isDynamicLineHeight on a nil value");
			}
		}

		obj.isDynamicLineHeight = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReloadData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		TableView obj = (TableView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "TableView");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.ReloadData(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Setup(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		TableView obj = (TableView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "TableView");
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		bool arg2 = LuaScriptMgr.GetBoolean(L, 4);
		obj.Setup(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetLineHeightFunc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		TableView obj = (TableView)LuaScriptMgr.GetUnityObjectSelf(L, 1, "TableView");
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 2);
		obj.SetLineHeightFunc(arg0);
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

