using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class Games_Module_Sound_SoundManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Awake", Awake),
			new LuaMethod("Init", Init),
			new LuaMethod("UnloadRuntimeClips", UnloadRuntimeClips),
			new LuaMethod("PlaySound", PlaySound),
			new LuaMethod("PlayMusicBg", PlayMusicBg),
			new LuaMethod("ChangeMusicBg", ChangeMusicBg),
			new LuaMethod("New", _CreateGames_Module_Sound_SoundManager),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("mCurMusicName", get_mCurMusicName, set_mCurMusicName),
			new LuaField("Instance", get_Instance, null),
			new LuaField("CurrentAudioSource", get_CurrentAudioSource, set_CurrentAudioSource),
			new LuaField("CurrentAudioSourceBg", get_CurrentAudioSourceBg, set_CurrentAudioSourceBg),
		};

		LuaScriptMgr.RegisterLib(L, "Games.Module.Sound.SoundManager", typeof(Games.Module.Sound.SoundManager), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGames_Module_Sound_SoundManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Games.Module.Sound.SoundManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(Games.Module.Sound.SoundManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mCurMusicName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Sound.SoundManager obj = (Games.Module.Sound.SoundManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mCurMusicName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mCurMusicName on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mCurMusicName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, Games.Module.Sound.SoundManager.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CurrentAudioSource(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Sound.SoundManager obj = (Games.Module.Sound.SoundManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name CurrentAudioSource");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index CurrentAudioSource on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.CurrentAudioSource);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CurrentAudioSourceBg(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Sound.SoundManager obj = (Games.Module.Sound.SoundManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name CurrentAudioSourceBg");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index CurrentAudioSourceBg on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.CurrentAudioSourceBg);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mCurMusicName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Sound.SoundManager obj = (Games.Module.Sound.SoundManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mCurMusicName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mCurMusicName on a nil value");
			}
		}

		obj.mCurMusicName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CurrentAudioSource(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Sound.SoundManager obj = (Games.Module.Sound.SoundManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name CurrentAudioSource");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index CurrentAudioSource on a nil value");
			}
		}

		obj.CurrentAudioSource = (AudioSource)LuaScriptMgr.GetUnityObject(L, 3, typeof(AudioSource));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CurrentAudioSourceBg(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Games.Module.Sound.SoundManager obj = (Games.Module.Sound.SoundManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name CurrentAudioSourceBg");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index CurrentAudioSourceBg on a nil value");
			}
		}

		obj.CurrentAudioSourceBg = (AudioSource)LuaScriptMgr.GetUnityObject(L, 3, typeof(AudioSource));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Awake(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Sound.SoundManager obj = (Games.Module.Sound.SoundManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Games.Module.Sound.SoundManager");
		obj.Awake();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Sound.SoundManager obj = (Games.Module.Sound.SoundManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Games.Module.Sound.SoundManager");
		obj.Init();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnloadRuntimeClips(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Games.Module.Sound.SoundManager obj = (Games.Module.Sound.SoundManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Games.Module.Sound.SoundManager");
		obj.UnloadRuntimeClips();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlaySound(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Sound.SoundManager obj = (Games.Module.Sound.SoundManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Games.Module.Sound.SoundManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.PlaySound(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayMusicBg(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Sound.SoundManager obj = (Games.Module.Sound.SoundManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Games.Module.Sound.SoundManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.PlayMusicBg(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ChangeMusicBg(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Games.Module.Sound.SoundManager obj = (Games.Module.Sound.SoundManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Games.Module.Sound.SoundManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.ChangeMusicBg(arg0);
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

