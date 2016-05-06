using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using Games;
using Newtonsoft.Json;

public class CenterSwitcher : EditorWindow {

	class CenterItem{
		public string name;
		public int typeID;
		public string bundleId;
		public string pathName;
		public string[] fileList;

		public CenterItem(string name, string bundleId, int typeID, string pathName, string[] fileList){
			this.name = name;
			this.typeID = typeID;
			this.bundleId = bundleId;
			this.pathName = pathName;
			this.fileList = fileList;
		}
	}

	[MenuItem ("CC/平台切换", false, 6)]
	static void OpenWindow()
	{
		EditorWindow.GetWindow<CenterSwitcher>("平台切换");
	}

	private CenterItem[] _centerItemList = {
		new CenterItem("NoCenter", "com.mb.mbsgcr", 0, "NoCenter", new string[]{
			"AndroidManifest.xml",
		}),
		new CenterItem("M4399", "com.mbgame.sdk.m4399", 1, "4399", new string[]{
			"res",
			"libs",
			"bin/4399.jar",
			"AndroidManifest.xml"
		}),
		new CenterItem("XiaoMi", "com.mbsgcr.mi", 2, "Mi", new string[]{
//			"res",
			"libs",
			"bin/mi.jar",
			"AndroidManifest.xml",
			"assets",
		})
	};

	private CenterItem defaultItem = new CenterItem("Default", "", -1, "Default", new string[]{
		"libs"
	});

	private CenterItem commonItem = new CenterItem("Common", "", -1, "Common", new string[]{
		"bin/common.jar"
	});

	private int _centerIndex = 0;
	private GameConstConfig _constConfig;

	void OnGUI() 
	{
		EditorGUILayout.Space();
		EditorGUILayout.LabelField("选择切换的平台");

		string[] list = new string[_centerItemList.Length];
		for (int i=0; i<list.Length; i++)
		{
			list[i] = _centerItemList[i].name;
		}
		_centerIndex = EditorGUILayout.Popup(_centerIndex, list);
		if (GUILayout.Button("切换平台"))
		{
			Directory.Delete("Assets/Plugins/Android/", true);
			Directory.CreateDirectory("Assets/Plugins/Android/");

			var centerItem = _centerItemList[_centerIndex];
			CopyCenterFile(centerItem);
			CopyCenterFile(defaultItem);
			CopyCenterFile(commonItem);
			CopyIconSplash(centerItem);

			PlayerSettings.bundleIdentifier = centerItem.bundleId;
			_constConfig.CenterName = centerItem.name;
			Game.Editors.GameConstJsonGenerator.GenerateByGameConsConfig(_constConfig);
		}
	}

	void CopyCenterFile(CenterItem centerItem)
	{
		var allFileList = new List<string>();
		var dict = new DirectoryInfo("CenterProj/" + centerItem.pathName);
		for (int k=0; k<centerItem.fileList.Length; k++)
		{
			var path = dict.FullName + "/" + centerItem.fileList[k];
			if (Directory.Exists(path))
			{
				var kdict = new DirectoryInfo(dict.FullName + "/" + centerItem.fileList[k]);
				for (int i=0; i<kdict.GetFiles().Length; i++)
				{
					if (kdict.GetFiles()[i].Name != ".DS_Store")
						allFileList.Add(kdict.GetFiles()[i].FullName);
				}
				for (int i=0; i<kdict.GetDirectories().Length; i++)
				{
					var dict2 = kdict.GetDirectories()[i];
					for (int j=0; j<dict2.GetFiles().Length; j++)
					{
						if (dict2.GetFiles()[j].Name != ".DS_Store")
							allFileList.Add(dict2.GetFiles()[j].FullName);
					}
				}
			}
			else
			{
				allFileList.Add(path);
			}
		}

		foreach(string str in allFileList)
		{
			FileInfo f = new FileInfo(str);
			var pluginDir = new DirectoryInfo("Assets/Plugins/Android/");
            var centerProjPath = f.DirectoryName.Replace("\\", "/");
            var split = centerProjPath.Split(new string[]{"CenterProj/" + centerItem.pathName + "/"}, System.StringSplitOptions.None);
			if (split.Length > 1)
			{
				var dest = split[1];
				if (dest == "bin")
				{
					File.Copy(str, pluginDir.FullName + f.Name);
				}
				else
				{
					var destsub = pluginDir.FullName + dest;
					if (!Directory.Exists(destsub))
					{
						Directory.CreateDirectory(destsub);
					}
					File.Copy(str, destsub + "/" + f.Name);
				}
			}
			else
			{
				File.Copy(str, pluginDir.FullName + f.Name);
			}
		}
	}

	void CopyIconSplash(CenterItem centerItem)
	{
		var dict = new DirectoryInfo("CenterProj/" + centerItem.pathName);
		var settingPath = "Assets/Game/PlayerSettings";
		var filePath = dict.FullName + "/icon.png";
		if (File.Exists(filePath))
		{
			File.Copy(filePath, settingPath + "/icon.png", true);
		}
		filePath = dict.FullName + "/splash.jpg";
		if (File.Exists(filePath))
		{
			File.Copy(filePath, settingPath + "/splash.jpg", true);
		}
	}

	void OnFocus()
	{
		var f = new FileInfo("Assets/StreamingAssets/" + GameConst.GameConstFileName);
		var sr = f.OpenText();
		var str = sr.ReadToEnd();
		sr.Close();

		_constConfig = JsonConvert.DeserializeObject(str, typeof(GameConstConfig)) as GameConstConfig;

		foreach (CenterItem item in _centerItemList)
		{
			if (item.name == _constConfig.CenterName)
			{
				_centerIndex = item.typeID;
				break;
			}
		}
	}
}
