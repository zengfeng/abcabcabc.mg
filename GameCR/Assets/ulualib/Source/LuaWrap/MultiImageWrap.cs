using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class MultiImageWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("SetImageIndex", SetImageIndex),
			new LuaMethod("SetImageSprite", SetImageSprite),
			new LuaMethod("New", _CreateMultiImage),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("image", get_image, set_image),
			new LuaField("imageIndex", get_imageIndex, set_imageIndex),
			new LuaField("target", get_target, set_target),
			new LuaField("setNativeSize", get_setNativeSize, set_setNativeSize),
		};

		LuaScriptMgr.RegisterLib(L, "MultiImage", typeof(MultiImage), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMultiImage(IntPtr L)
	{
		LuaDLL.luaL_error(L, "MultiImage class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(MultiImage);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_image(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MultiImage obj = (MultiImage)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name image");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index image on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.image);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_imageIndex(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MultiImage obj = (MultiImage)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name imageIndex");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index imageIndex on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.imageIndex);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_target(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MultiImage obj = (MultiImage)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name target");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index target on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.target);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_setNativeSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MultiImage obj = (MultiImage)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name setNativeSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index setNativeSize on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.setNativeSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_image(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MultiImage obj = (MultiImage)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name image");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index image on a nil value");
			}
		}

		obj.image = LuaScriptMgr.GetArrayObject<Sprite>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_imageIndex(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MultiImage obj = (MultiImage)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name imageIndex");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index imageIndex on a nil value");
			}
		}

		obj.imageIndex = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_target(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MultiImage obj = (MultiImage)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name target");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index target on a nil value");
			}
		}

		obj.target = (UnityEngine.UI.Image)LuaScriptMgr.GetUnityObject(L, 3, typeof(UnityEngine.UI.Image));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_setNativeSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MultiImage obj = (MultiImage)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name setNativeSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index setNativeSize on a nil value");
			}
		}

		obj.setNativeSize = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetImageIndex(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MultiImage obj = (MultiImage)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MultiImage");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.SetImageIndex(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetImageSprite(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MultiImage obj = (MultiImage)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MultiImage");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Sprite arg1 = (Sprite)LuaScriptMgr.GetUnityObject(L, 3, typeof(Sprite));
		obj.SetImageSprite(arg0,arg1);
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

