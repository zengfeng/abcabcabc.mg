using UnityEngine;
using System.Collections;
using CC.Runtime;
using CC.Module.Menu;
using SimpleFramework;
using Games.Module.Avatars;

namespace Games.Cores
{
	public class Goo 
	{

		public static AvatarModel avatar
		{
			get
			{
				return InstanceUtil.Get<AvatarModel>();
			}
		}

		public static GameSave save = new GameSave();


	}
}