using UnityEngine;
using System.Collections;
using CC.Runtime;
using System;

namespace Games.Module.Sysmsgs
{
	public class MsgMenuData : IData 
	{
		public string content;
		public Action<int> handle;
		public MsgData config;

		public MsgMenuData()
		{
		}
		
		public MsgMenuData(string content)
		{
			this.content = content;
		}
		
		public MsgMenuData(MsgData config, string content)
		{
			this.config = config;
			this.content = content;
		}

		public MsgMenuData(MsgData config, string content, Action<int> handle)
		{
			this.config = config;
			this.content = content;
			this.handle = handle;
		}
	}
}
