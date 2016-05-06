using UnityEngine;
using System.Collections;
using CC.Runtime;
using System.IO;
using System;

namespace Games.Module.Configs
{
	public abstract class ConfigReader : IConfig, IParseCsv
	{
		protected bool ready = false;
		public string file = "";
		
		private ConfigPathAttribute pathattr;
		public bool Ready
		{
			get
			{
				return ready;
			}
		}

		public void Load(AssetManager am)  {
			if(string.IsNullOrEmpty(file))
			{
				Type type = this.GetType();
				pathattr = type.GetCustomAttributes(typeof(ConfigPathAttribute), false)[0] as ConfigPathAttribute;
				file = pathattr.assetName;
			}
			am.Load (file, OnLoad);
		}

		virtual protected void OnLoad(string filename, System.Object data) {

			if(data == null) Debug.LogError("[Error] finelname=" + filename );
			string text = data as String;
			
			StringReader stringReader = new StringReader(text);
			stringReader.ReadLine();
			stringReader.ReadLine();
			while(true)
			{
				string line = stringReader.ReadLine();
				if (line == null)
				{
					break;
				}
				string[] csv = line.Split(';');
				if (csv.Length != 0 && !string.IsNullOrEmpty(csv[0]))
				{
					ParseCsv(csv);
				}
			}

			ParseComplete();
			ready = true ;
		}
		
		virtual protected void ParseComplete(){}

		public void ReLoad(AssetManager am){
			ready = false;
			Load (am);
			ready = true;
		}

		public abstract void ParseCsv(string[] csv);
	}
}

