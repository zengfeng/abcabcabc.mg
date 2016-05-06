using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEditor;
using Games;
using Newtonsoft.Json;

namespace Game.Editors
{
	public class GameConstJsonGenerator 
	{
		
		[MenuItem("CC/生成game_const.json", false,100)]
		public static void Generator()
		{

			GameConstConfig obj = new GameConstConfig();
			GenerateByGameConsConfig(obj);
		}

		public static void GenerateByGameConsConfig(GameConstConfig config)
		{
			string str = JsonConvert.SerializeObject(config, Formatting.Indented);
			
			string filesPath = Application.streamingAssetsPath + "/" + GameConst.GameConstFileName;
			
			PathUtil.CheckPath(filesPath, true);
			if (File.Exists(filesPath)) File.Delete(filesPath);
			
			FileStream fs = new FileStream(filesPath, FileMode.CreateNew);
			StreamWriter sw = new StreamWriter(fs);
			sw.Write(str);
			sw.Close(); fs.Close();
			AssetDatabase.Refresh();
			Debug.Log("[GameConstJsonGenerator]" + filesPath);
		}
	}
}