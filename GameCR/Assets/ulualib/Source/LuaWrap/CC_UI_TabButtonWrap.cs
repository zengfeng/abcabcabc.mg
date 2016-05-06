using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CC_UI_TabButtonWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("OnPointerEnter", OnPointerEnter),
			new LuaMethod("OnPointerDown", OnPointerDown),
			new LuaMethod("OnPointerUp", OnPointerUp),
			new LuaMethod("OnPointerClick", OnPointerClick),
			new LuaMethod("OnPointerExit", OnPointerExit),
			new LuaMethod("GetData", GetData),
			new LuaMethod("SetData", SetData),
			new LuaMethod("GetID", GetID),
			new LuaMethod("SetID", SetID),
			new LuaMethod("SetGroup", SetGroup),
			new LuaMethod("SetInteractable", SetInteractable),
			new LuaMethod("SetIsSelect", SetIsSelect),
			new LuaMethod("AddClick", AddClick),
			new LuaMethod("ClearClick", ClearClick),
			new LuaMethod("New", _CreateCC_UI_TabButton),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("uid", get_uid, set_uid),
			new LuaField("data", get_data, set_data),
			new LuaField("Interactable", get_Interactable, set_Interactable),
			new LuaField("group", get_group, set_group),
			new LuaField("image", get_image, set_image),
			new LuaField("text", get_text, set_text),
			new LuaField("mark", get_mark, set_mark),
			new LuaField("useColor", get_useColor, set_useColor),
			new LuaField("colorNormal", get_colorNormal, set_colorNormal),
			new LuaField("colorHighlighted", get_colorHighlighted, set_colorHighlighted),
			new LuaField("colorPressed", get_colorPressed, set_colorPressed),
			new LuaField("colorDisabled", get_colorDisabled, set_colorDisabled),
			new LuaField("selectColorNormal", get_selectColorNormal, set_selectColorNormal),
			new LuaField("selectColorHighlighted", get_selectColorHighlighted, set_selectColorHighlighted),
			new LuaField("selectColorPressed", get_selectColorPressed, set_selectColorPressed),
			new LuaField("useSprite", get_useSprite, set_useSprite),
			new LuaField("spriteNormal", get_spriteNormal, set_spriteNormal),
			new LuaField("spriteHighlighted", get_spriteHighlighted, set_spriteHighlighted),
			new LuaField("spritePressed", get_spritePressed, set_spritePressed),
			new LuaField("spriteDisabled", get_spriteDisabled, set_spriteDisabled),
			new LuaField("selectSpriteNormal", get_selectSpriteNormal, set_selectSpriteNormal),
			new LuaField("selectSpriteHighlighted", get_selectSpriteHighlighted, set_selectSpriteHighlighted),
			new LuaField("selectSpritePressed", get_selectSpritePressed, set_selectSpritePressed),
			new LuaField("selectSpriteDisabled", get_selectSpriteDisabled, set_selectSpriteDisabled),
			new LuaField("useTextColor", get_useTextColor, set_useTextColor),
			new LuaField("textColorNormal", get_textColorNormal, set_textColorNormal),
			new LuaField("textColorHighlighted", get_textColorHighlighted, set_textColorHighlighted),
			new LuaField("textColorPressed", get_textColorPressed, set_textColorPressed),
			new LuaField("textColorDisabled", get_textColorDisabled, set_textColorDisabled),
			new LuaField("textSelectColorNormal", get_textSelectColorNormal, set_textSelectColorNormal),
			new LuaField("textSelectColorHighlighted", get_textSelectColorHighlighted, set_textSelectColorHighlighted),
			new LuaField("textSelectColorPressed", get_textSelectColorPressed, set_textSelectColorPressed),
			new LuaField("disableShowText", get_disableShowText, set_disableShowText),
			new LuaField("operationDown", get_operationDown, set_operationDown),
			new LuaField("_isSelect", get__isSelect, set__isSelect),
			new LuaField("onValueChanged", get_onValueChanged, set_onValueChanged),
			new LuaField("IsSelect", get_IsSelect, set_IsSelect),
			new LuaField("onClick", get_onClick, null),
		};

		LuaScriptMgr.RegisterLib(L, "CC.UI.TabButton", typeof(CC.UI.TabButton), regs, fields, typeof(CC.UI.BaseUI));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCC_UI_TabButton(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CC.UI.TabButton class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CC.UI.TabButton);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uid(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uid");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uid on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.uid);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_data(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name data");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index data on a nil value");
			}
		}

		LuaScriptMgr.PushVarObject(L, obj.data);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Interactable(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Interactable");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Interactable on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.Interactable);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_group(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name group");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index group on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.group);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_image(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

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

		LuaScriptMgr.Push(L, obj.image);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_text(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name text");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index text on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.text);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mark(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mark");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mark on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mark);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useColor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useColor on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.useColor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_colorNormal(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colorNormal");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colorNormal on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.colorNormal);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_colorHighlighted(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colorHighlighted");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colorHighlighted on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.colorHighlighted);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_colorPressed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colorPressed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colorPressed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.colorPressed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_colorDisabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colorDisabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colorDisabled on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.colorDisabled);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_selectColorNormal(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectColorNormal");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectColorNormal on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.selectColorNormal);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_selectColorHighlighted(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectColorHighlighted");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectColorHighlighted on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.selectColorHighlighted);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_selectColorPressed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectColorPressed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectColorPressed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.selectColorPressed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useSprite(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useSprite");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useSprite on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.useSprite);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spriteNormal(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteNormal");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteNormal on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.spriteNormal);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spriteHighlighted(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteHighlighted");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteHighlighted on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.spriteHighlighted);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spritePressed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spritePressed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spritePressed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.spritePressed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spriteDisabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteDisabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteDisabled on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.spriteDisabled);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_selectSpriteNormal(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectSpriteNormal");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectSpriteNormal on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.selectSpriteNormal);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_selectSpriteHighlighted(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectSpriteHighlighted");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectSpriteHighlighted on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.selectSpriteHighlighted);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_selectSpritePressed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectSpritePressed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectSpritePressed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.selectSpritePressed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_selectSpriteDisabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectSpriteDisabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectSpriteDisabled on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.selectSpriteDisabled);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useTextColor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useTextColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useTextColor on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.useTextColor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_textColorNormal(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name textColorNormal");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index textColorNormal on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.textColorNormal);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_textColorHighlighted(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name textColorHighlighted");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index textColorHighlighted on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.textColorHighlighted);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_textColorPressed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name textColorPressed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index textColorPressed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.textColorPressed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_textColorDisabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name textColorDisabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index textColorDisabled on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.textColorDisabled);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_textSelectColorNormal(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name textSelectColorNormal");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index textSelectColorNormal on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.textSelectColorNormal);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_textSelectColorHighlighted(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name textSelectColorHighlighted");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index textSelectColorHighlighted on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.textSelectColorHighlighted);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_textSelectColorPressed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name textSelectColorPressed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index textSelectColorPressed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.textSelectColorPressed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_disableShowText(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name disableShowText");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index disableShowText on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.disableShowText);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_operationDown(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name operationDown");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index operationDown on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.operationDown);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get__isSelect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name _isSelect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index _isSelect on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj._isSelect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onValueChanged(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onValueChanged");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onValueChanged on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.onValueChanged);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsSelect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name IsSelect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index IsSelect on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.IsSelect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onClick(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onClick");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onClick on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.onClick);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uid(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uid");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uid on a nil value");
			}
		}

		obj.uid = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_data(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name data");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index data on a nil value");
			}
		}

		obj.data = LuaScriptMgr.GetVarObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Interactable(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Interactable");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Interactable on a nil value");
			}
		}

		obj.Interactable = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_group(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name group");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index group on a nil value");
			}
		}

		obj.group = (CC.UI.TabGroup)LuaScriptMgr.GetUnityObject(L, 3, typeof(CC.UI.TabGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_image(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

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

		obj.image = (UnityEngine.UI.Image)LuaScriptMgr.GetUnityObject(L, 3, typeof(UnityEngine.UI.Image));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_text(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name text");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index text on a nil value");
			}
		}

		obj.text = (UnityEngine.UI.Text)LuaScriptMgr.GetUnityObject(L, 3, typeof(UnityEngine.UI.Text));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mark(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mark");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mark on a nil value");
			}
		}

		obj.mark = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useColor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useColor on a nil value");
			}
		}

		obj.useColor = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_colorNormal(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colorNormal");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colorNormal on a nil value");
			}
		}

		obj.colorNormal = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_colorHighlighted(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colorHighlighted");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colorHighlighted on a nil value");
			}
		}

		obj.colorHighlighted = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_colorPressed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colorPressed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colorPressed on a nil value");
			}
		}

		obj.colorPressed = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_colorDisabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colorDisabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colorDisabled on a nil value");
			}
		}

		obj.colorDisabled = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_selectColorNormal(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectColorNormal");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectColorNormal on a nil value");
			}
		}

		obj.selectColorNormal = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_selectColorHighlighted(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectColorHighlighted");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectColorHighlighted on a nil value");
			}
		}

		obj.selectColorHighlighted = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_selectColorPressed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectColorPressed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectColorPressed on a nil value");
			}
		}

		obj.selectColorPressed = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useSprite(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useSprite");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useSprite on a nil value");
			}
		}

		obj.useSprite = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_spriteNormal(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteNormal");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteNormal on a nil value");
			}
		}

		obj.spriteNormal = (Sprite)LuaScriptMgr.GetUnityObject(L, 3, typeof(Sprite));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_spriteHighlighted(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteHighlighted");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteHighlighted on a nil value");
			}
		}

		obj.spriteHighlighted = (Sprite)LuaScriptMgr.GetUnityObject(L, 3, typeof(Sprite));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_spritePressed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spritePressed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spritePressed on a nil value");
			}
		}

		obj.spritePressed = (Sprite)LuaScriptMgr.GetUnityObject(L, 3, typeof(Sprite));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_spriteDisabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteDisabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteDisabled on a nil value");
			}
		}

		obj.spriteDisabled = (Sprite)LuaScriptMgr.GetUnityObject(L, 3, typeof(Sprite));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_selectSpriteNormal(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectSpriteNormal");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectSpriteNormal on a nil value");
			}
		}

		obj.selectSpriteNormal = (Sprite)LuaScriptMgr.GetUnityObject(L, 3, typeof(Sprite));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_selectSpriteHighlighted(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectSpriteHighlighted");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectSpriteHighlighted on a nil value");
			}
		}

		obj.selectSpriteHighlighted = (Sprite)LuaScriptMgr.GetUnityObject(L, 3, typeof(Sprite));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_selectSpritePressed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectSpritePressed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectSpritePressed on a nil value");
			}
		}

		obj.selectSpritePressed = (Sprite)LuaScriptMgr.GetUnityObject(L, 3, typeof(Sprite));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_selectSpriteDisabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectSpriteDisabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectSpriteDisabled on a nil value");
			}
		}

		obj.selectSpriteDisabled = (Sprite)LuaScriptMgr.GetUnityObject(L, 3, typeof(Sprite));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useTextColor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useTextColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useTextColor on a nil value");
			}
		}

		obj.useTextColor = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_textColorNormal(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name textColorNormal");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index textColorNormal on a nil value");
			}
		}

		obj.textColorNormal = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_textColorHighlighted(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name textColorHighlighted");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index textColorHighlighted on a nil value");
			}
		}

		obj.textColorHighlighted = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_textColorPressed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name textColorPressed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index textColorPressed on a nil value");
			}
		}

		obj.textColorPressed = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_textColorDisabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name textColorDisabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index textColorDisabled on a nil value");
			}
		}

		obj.textColorDisabled = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_textSelectColorNormal(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name textSelectColorNormal");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index textSelectColorNormal on a nil value");
			}
		}

		obj.textSelectColorNormal = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_textSelectColorHighlighted(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name textSelectColorHighlighted");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index textSelectColorHighlighted on a nil value");
			}
		}

		obj.textSelectColorHighlighted = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_textSelectColorPressed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name textSelectColorPressed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index textSelectColorPressed on a nil value");
			}
		}

		obj.textSelectColorPressed = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_disableShowText(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name disableShowText");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index disableShowText on a nil value");
			}
		}

		obj.disableShowText = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_operationDown(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name operationDown");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index operationDown on a nil value");
			}
		}

		obj.operationDown = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set__isSelect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name _isSelect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index _isSelect on a nil value");
			}
		}

		obj._isSelect = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onValueChanged(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onValueChanged");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onValueChanged on a nil value");
			}
		}

		obj.onValueChanged = (CC.UI.TabButton.TabEvent)LuaScriptMgr.GetNetObject(L, 3, typeof(CC.UI.TabButton.TabEvent));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_IsSelect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name IsSelect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index IsSelect on a nil value");
			}
		}

		obj.IsSelect = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerEnter(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.TabButton obj = (CC.UI.TabButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabButton");
		UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
		obj.OnPointerEnter(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerDown(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.TabButton obj = (CC.UI.TabButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabButton");
		UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
		obj.OnPointerDown(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerUp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.TabButton obj = (CC.UI.TabButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabButton");
		UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
		obj.OnPointerUp(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.TabButton obj = (CC.UI.TabButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabButton");
		UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
		obj.OnPointerClick(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerExit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.TabButton obj = (CC.UI.TabButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabButton");
		UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
		obj.OnPointerExit(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabButton");
		object o = obj.GetData();
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.TabButton obj = (CC.UI.TabButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabButton");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		obj.SetData(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetID(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabButton");
		int o = obj.GetID();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetID(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.TabButton obj = (CC.UI.TabButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabButton");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.SetID(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetGroup(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.TabButton obj = (CC.UI.TabButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabButton");
		CC.UI.TabGroup arg0 = (CC.UI.TabGroup)LuaScriptMgr.GetUnityObject(L, 2, typeof(CC.UI.TabGroup));
		obj.SetGroup(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetInteractable(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.TabButton obj = (CC.UI.TabButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabButton");
		bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
		obj.SetInteractable(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetIsSelect(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			CC.UI.TabButton obj = (CC.UI.TabButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabButton");
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			obj.SetIsSelect(arg0);
			return 0;
		}
		else if (count == 3)
		{
			CC.UI.TabButton obj = (CC.UI.TabButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabButton");
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			obj.SetIsSelect(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CC.UI.TabButton.SetIsSelect");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CC.UI.TabButton obj = (CC.UI.TabButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabButton");
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 2);
		obj.AddClick(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CC.UI.TabButton obj = (CC.UI.TabButton)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CC.UI.TabButton");
		obj.ClearClick();
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

