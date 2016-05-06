using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class ImageSetMaterialWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("SetMaterial", SetMaterial),
			new LuaMethod("New", _CreateImageSetMaterial),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("images", get_images, set_images),
			new LuaField("materials", get_materials, set_materials),
			new LuaField("materialIndex", get_materialIndex, set_materialIndex),
			new LuaField("isUpdate", get_isUpdate, set_isUpdate),
		};

		LuaScriptMgr.RegisterLib(L, "ImageSetMaterial", typeof(ImageSetMaterial), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateImageSetMaterial(IntPtr L)
	{
		LuaDLL.luaL_error(L, "ImageSetMaterial class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(ImageSetMaterial);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_images(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ImageSetMaterial obj = (ImageSetMaterial)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name images");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index images on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.images);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_materials(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ImageSetMaterial obj = (ImageSetMaterial)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name materials");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index materials on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.materials);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_materialIndex(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ImageSetMaterial obj = (ImageSetMaterial)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name materialIndex");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index materialIndex on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.materialIndex);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isUpdate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ImageSetMaterial obj = (ImageSetMaterial)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isUpdate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isUpdate on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isUpdate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_images(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ImageSetMaterial obj = (ImageSetMaterial)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name images");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index images on a nil value");
			}
		}

		obj.images = LuaScriptMgr.GetArrayObject<UnityEngine.UI.Image>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_materials(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ImageSetMaterial obj = (ImageSetMaterial)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name materials");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index materials on a nil value");
			}
		}

		obj.materials = LuaScriptMgr.GetArrayObject<Material>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_materialIndex(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ImageSetMaterial obj = (ImageSetMaterial)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name materialIndex");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index materialIndex on a nil value");
			}
		}

		obj.materialIndex = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isUpdate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		ImageSetMaterial obj = (ImageSetMaterial)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isUpdate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isUpdate on a nil value");
			}
		}

		obj.isUpdate = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetMaterial(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ImageSetMaterial obj = (ImageSetMaterial)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ImageSetMaterial");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.SetMaterial(arg0);
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

