using System;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

namespace Games.Module.Props
{
    public class PropConfig
    {
        public int id ;
		public string name;
		public float displayMultiplier=1;
        public string format;
        public string mapping;         //mapping to creature property
        public int priority;    
		public int additive = 0;
		public PropType type;
		public float limitMinValue = float.MinValue;
		public float limitMaxValue = float.MaxValue;
		public string commentName;

		
		public float Limit(float val)
		{
			return Math.Max(Math.Min(val, limitMaxValue), limitMinValue);
		}


        internal static PropConfig[] _propConfigs;

        public static void Initialize(PropConfig[] propConfigs)
        {
            _propConfigs = propConfigs;
        }

        public static PropConfig GetInstance(int id)
        {
            return _propConfigs[id];
        }

		public static float Limit(int id, float val)
		{
			PropConfig config = GetInstance(id);
			if(config != null)
			{
				return config.Limit(val);
			}
			return val;
		}

    }


}

