using UnityEngine;
using System.Collections;
using CC.Runtime;
using System;
using CC.Module.Menu;
using LuaInterface;


namespace Games.Module.Sysmsgs
{
	public class SysmsgButtonType
	{
		public static int NO = 0;
		public static int YES = 1;
	}

	public class SysmsgManager
	{
		internal static SysmsgManager _Instance;
		internal static SysmsgManager Instance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new SysmsgManager();
				}
				return _Instance;
			}
		}

		internal SysmsgManager()
		{

		}

		internal void execute(int messageId,object[] args, Action<int> action)
		{
			ConfigSet<int, MsgData> configSet = Coo.configManager.GetConfig<int, MsgData>();
			MsgData config = configSet[messageId];
			if(config == null)
			{
				Debug.LogError("[SysmsgManager] 系统消息没有找到对应ID配置 messageId=" + messageId);
			}

			/** 滚屏 */
			if(config.Type == 0)
			{
				Coo.menuManager.OpenMenu(MenuType.MsgScroll, new MsgMenuData(config.Format(args)));
			}
			else if(config.Type == 1)
			{
				Coo.menuManager.OpenMenu(MenuType.MsgAlert, new MsgMenuData(config, config.Format(args), action));
			}
			else if(config.Type == 2)
			{
				Coo.menuManager.OpenMenu(MenuType.MsgAlert, new MsgMenuData(config, config.Format(args), action));
			}
			else if(config.Type == 3)
			{
				Coo.menuManager.OpenMenu(MenuType.MsgAlert, new MsgMenuData(config, config.Format(args), action));
			}
		}

		internal void executeLua(int type, object[] args, Action<int> action)
		{
			string content = (string)args[0];
			if (type == 0)
			{
				Coo.menuManager.OpenMenu(MenuType.MsgScroll, new MsgMenuData(content));
			}
			else
			{
				MsgData data = new MsgData();
				if (args.Length > 1)
				{
					data.Type = Convert.ToInt32(args[1]);
				}
				else
				{
					data.Type = 2;
				}
				Coo.menuManager.OpenMenu(MenuType.MsgAlert, new MsgMenuData(data, content, action));
			}
		}

		//================================================
		public static void Execute(int id,object[] args,Action<int> action)
		{
			Instance.execute(id, args, action);
		}
		
		public static void Execute(int id,object[] args)
		{
			Execute(id,args,Empty);
		}
		
		public static void Execute(int id,Action<int> action)
		{
			Execute(id,new object[0],action);
		}
		
		public static void Execute(int id)
		{
			Execute(id,new object[0],Empty);
		}

		
		public static void LuaExecute(int type,object[] args, LuaFunction func)
		{
			Action<int> action = (param0) =>
			{
				func.Call(param0);
			};
			Instance.executeLua(type, args, action);
		}

		public static void LuaExecute(int type,object[] args)
		{
			Instance.executeLua(type, args, Empty);
		}

		public static void LoadConfig()
		{
			Coo.configManager.GetConfig<int, MsgData>();
		}

		private static void Empty(int id)
		{
		}
	}
}