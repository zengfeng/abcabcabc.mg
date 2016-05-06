using UnityEngine;
using System.Collections;
using CC.Runtime;


namespace Games.Module.Avatars
{
	public class AvatarModel : Model 
	{
		ConfigSet<int, AvatarConfig> _configSet;
		private ConfigSet<int, AvatarConfig> configSet
		{
			get
			{
				if(_configSet == null)
					_configSet = Coo.configManager.GetConfig<int, AvatarConfig>();
				return _configSet;
			}


		}

		public override void LoadConfig ()
		{
			base.LoadConfig ();
			LoadConfig<int, AvatarConfig>();
		}

		public AvatarConfig GetConfig(int id)
		{
			return configSet[id];
		}

	}
}
