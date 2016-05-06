using UnityEngine;
using System.Collections;
using CC.Runtime;

namespace Games.Module.Localizations
{
	
	[ConfigPath("Config/localization",ConfigType.CSV)]
	public class LocalizationConfig :  IKey<string>
	{
		[CsvField(0)]
		public string key;
		[CsvField(1)]
		public string content;


		public string Key
		{
			get
			{
				return key;
			}
		}
	}
}