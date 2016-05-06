using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Runtime
{
    public enum ConfigType {
        CSV,
        JSON,
    }

    public class ConfigPathAttribute : Attribute
    {
        public ConfigPathAttribute(string name, ConfigType typ, bool stable = true)
        {
            assetName = name;
            isStable = stable;
            configType = typ;
        }

        public bool isStable = false;
        public string assetName;
        public ConfigType configType;

    }
}
