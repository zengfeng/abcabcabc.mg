using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime;
using Games.Module.Localizations;

public partial class Local
{
	
	private static ConfigSet<string, LocalizationConfig> configSet;

	public static string Get(string key)
	{
		#if UNITY_EDITOR
		if (!Application.isPlaying) return key;
		#endif
		if(configSet == null) configSet = Coo.configManager.GetConfig<string, LocalizationConfig>();
		LocalizationConfig config = configSet[key];
		if(config != null)
		{
			return config.content;
		}
		return key;
	}

	public static string Get(string key, params object[] args)
	{
		string content = Get(key);
		return string.Format(content, args);
	}

	public static string Get(int key)
	{
		return Get(key + "");
	}

	public static string Get(int key, params object[] args)
	{
		return Get(key + "", args);
	}



	public static string Get(Key key)
	{
		return Get((int)key + "");
	}
	
	public static string Get(Key key, params object[] args)
	{
		return Get((int)key + "", args);
	}
	
}