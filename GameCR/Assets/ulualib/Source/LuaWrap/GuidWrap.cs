using System;
using LuaInterface;

public class GuidWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("CompareTo", CompareTo),
			new LuaMethod("Equals", Equals),
			new LuaMethod("GetHashCode", GetHashCode),
			new LuaMethod("NewGuid", NewGuid),
			new LuaMethod("ToByteArray", ToByteArray),
			new LuaMethod("ToString", ToString),
			new LuaMethod("New", _CreateGuid),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__tostring", Lua_ToString),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Empty", get_Empty, null),
		};

		LuaScriptMgr.RegisterLib(L, "System.Guid", typeof(Guid), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGuid(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			Guid obj = new Guid(arg0);
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(byte[])))
		{
			byte[] objs0 = LuaScriptMgr.GetArrayNumber<byte>(L, 1);
			Guid obj = new Guid(objs0);
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else if (count == 4)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			short arg1 = (short)LuaScriptMgr.GetNumber(L, 2);
			short arg2 = (short)LuaScriptMgr.GetNumber(L, 3);
			byte[] objs3 = LuaScriptMgr.GetArrayNumber<byte>(L, 4);
			Guid obj = new Guid(arg0,arg1,arg2,objs3);
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else if (count == 11 && LuaScriptMgr.CheckTypes(L, 1, typeof(uint), typeof(ushort), typeof(ushort), typeof(byte), typeof(byte), typeof(byte), typeof(byte), typeof(byte), typeof(byte), typeof(byte), typeof(byte)))
		{
			uint arg0 = (uint)LuaScriptMgr.GetNumber(L, 1);
			ushort arg1 = (ushort)LuaScriptMgr.GetNumber(L, 2);
			ushort arg2 = (ushort)LuaScriptMgr.GetNumber(L, 3);
			byte arg3 = (byte)LuaScriptMgr.GetNumber(L, 4);
			byte arg4 = (byte)LuaScriptMgr.GetNumber(L, 5);
			byte arg5 = (byte)LuaScriptMgr.GetNumber(L, 6);
			byte arg6 = (byte)LuaScriptMgr.GetNumber(L, 7);
			byte arg7 = (byte)LuaScriptMgr.GetNumber(L, 8);
			byte arg8 = (byte)LuaScriptMgr.GetNumber(L, 9);
			byte arg9 = (byte)LuaScriptMgr.GetNumber(L, 10);
			byte arg10 = (byte)LuaScriptMgr.GetNumber(L, 11);
			Guid obj = new Guid(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7,arg8,arg9,arg10);
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else if (count == 11 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(short), typeof(short), typeof(byte), typeof(byte), typeof(byte), typeof(byte), typeof(byte), typeof(byte), typeof(byte), typeof(byte)))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			short arg1 = (short)LuaScriptMgr.GetNumber(L, 2);
			short arg2 = (short)LuaScriptMgr.GetNumber(L, 3);
			byte arg3 = (byte)LuaScriptMgr.GetNumber(L, 4);
			byte arg4 = (byte)LuaScriptMgr.GetNumber(L, 5);
			byte arg5 = (byte)LuaScriptMgr.GetNumber(L, 6);
			byte arg6 = (byte)LuaScriptMgr.GetNumber(L, 7);
			byte arg7 = (byte)LuaScriptMgr.GetNumber(L, 8);
			byte arg8 = (byte)LuaScriptMgr.GetNumber(L, 9);
			byte arg9 = (byte)LuaScriptMgr.GetNumber(L, 10);
			byte arg10 = (byte)LuaScriptMgr.GetNumber(L, 11);
			Guid obj = new Guid(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7,arg8,arg9,arg10);
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else if (count == 0)
		{
			Guid obj = new Guid();
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Guid.New");
		}

		return 0;
	}

	static Type classType = typeof(Guid);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Empty(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Guid.Empty);
		return 1;
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
			LuaScriptMgr.Push(L, "Table: System.Guid");
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CompareTo(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Guid), typeof(Guid)))
		{
			Guid obj = (Guid)LuaScriptMgr.GetNetObjectSelf(L, 1, "Guid");
			Guid arg0 = (Guid)LuaScriptMgr.GetLuaObject(L, 2);
			int o = obj.CompareTo(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Guid), typeof(object)))
		{
			Guid obj = (Guid)LuaScriptMgr.GetNetObjectSelf(L, 1, "Guid");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			int o = obj.CompareTo(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Guid.CompareTo");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Guid), typeof(Guid)))
		{
			Guid obj = (Guid)LuaScriptMgr.GetVarObject(L, 1);
			Guid arg0 = (Guid)LuaScriptMgr.GetLuaObject(L, 2);
			bool o = obj.Equals(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Guid), typeof(object)))
		{
			Guid obj = (Guid)LuaScriptMgr.GetVarObject(L, 1);
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			bool o = obj.Equals(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Guid.Equals");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Guid obj = (Guid)LuaScriptMgr.GetNetObjectSelf(L, 1, "Guid");
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int NewGuid(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Guid o = Guid.NewGuid();
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToByteArray(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Guid obj = (Guid)LuaScriptMgr.GetNetObjectSelf(L, 1, "Guid");
		byte[] o = obj.ToByteArray();
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Guid obj = (Guid)LuaScriptMgr.GetNetObjectSelf(L, 1, "Guid");
			string o = obj.ToString();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Guid obj = (Guid)LuaScriptMgr.GetNetObjectSelf(L, 1, "Guid");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			string o = obj.ToString(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Guid obj = (Guid)LuaScriptMgr.GetNetObjectSelf(L, 1, "Guid");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			IFormatProvider arg1 = (IFormatProvider)LuaScriptMgr.GetNetObject(L, 3, typeof(IFormatProvider));
			string o = obj.ToString(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Guid.ToString");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Guid arg0 = (Guid)LuaScriptMgr.GetVarObject(L, 1);
		Guid arg1 = (Guid)LuaScriptMgr.GetVarObject(L, 2);
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

