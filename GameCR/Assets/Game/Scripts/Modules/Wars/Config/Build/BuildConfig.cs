using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class BuildConfig : AbstractBuildConfig
	{
		public int maxLevel = 0;
		public Dictionary<int, BuildLevelConfig> levels = new Dictionary<int, BuildLevelConfig>(); 

		public BuildType buildType
		{
			get
			{
				return GetLevelConfig(1).buildType;
			}

			set
			{
				base.buildType = value;
			}
		}

		public void AddLevelConfig(BuildLevelConfig levelConfig)
		{
			levels.Add(levelConfig.level, levelConfig);

			if(maxLevel < levelConfig.level)
			{
				maxLevel = levelConfig.level;
			}
		}



		public BuildLevelConfig GetLevelConfig(int level)
		{
			level = Mathf.Min(level, maxLevel);
			return levels[level];
		}
		
		public List<string> GetResList(List<string> list, int[] colorIds)
		{
			foreach(var kvp in levels)
			{
				kvp.Value.GetResList(list, colorIds);
			}
			
			return list;
		}

	
	}

}