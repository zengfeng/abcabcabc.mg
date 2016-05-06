using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using CC.Runtime;

namespace Games
{

	[ConfigPath("Config/const_vars",ConfigType.CSV)]
	public partial class ConstConfig : IKey<int>
	{
        [CsvField(0)]
		public int id;
        [CsvField(1)]
		public string name;
		[CsvField(2)]
		public float[] floatValue;
        [CsvField(3)]
		public int[] value;
        [CsvField(4)]
		public string[] strValue;
		
		public int Key
		{
			get { return id; }
		}

		
		public float[] GetFloatValues()
		{
			return floatValue;
		}

		public int[] GetIntValues()
		{
			return value;
		}
		
		public string[] GetStringValues()
		{
			return strValue;
		}
		
		public float GetFloatValue()
		{
			return floatValue != null && floatValue.Length > 0 ? floatValue[0] : 0f;
		}

		public int GetIntValue()
		{
			return value != null && value.Length > 0 ? value[0] : 0;
		}
		
		public string GetStringValue()
		{
			return strValue != null && strValue.Length > 0 ? strValue[0] : null;
		}



		//-------------static--------------------//
		private static ConfigSet<int, ConstConfig> _configSet;
		private static ConfigSet<int, ConstConfig> configSet
		{
			get
			{
				if(_configSet == null) _configSet = Coo.configManager.GetConfig<int, ConstConfig>();
				return _configSet;
			}
		}

		
		//-----------
		public static int GetInt(ID id)
		{
			ConstConfig config = configSet [(int)id];
			return config.GetIntValue();
		}
		
		
		public static int[] GetInts(ID id)
		{
			ConstConfig config = configSet [(int)id];
			return config.GetIntValues();
		}

		
		//-----------
		public static float GetFloat(ID id)
		{
			ConstConfig config = configSet [(int)id];
			return config.GetFloatValue();
		}
		
		public static float[] GetFloats(ID id)
		{
			ConstConfig config = configSet [(int)id];
			return config.GetFloatValues();
		}

		
		//-----------
		public static string GetString(ID id)
		{
			ConstConfig config = configSet [(int)id];
			return config.GetStringValue();
		}
		
		public static string[] GetStrings(ID id)
		{
			ConstConfig config = configSet [(int)id];
			return config.GetStringValues();
		}


    }
}

