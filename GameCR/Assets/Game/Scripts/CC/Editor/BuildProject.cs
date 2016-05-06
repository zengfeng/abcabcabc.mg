using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using Game.Editors;
using Games;
using UnityEditor.Callbacks;
using UnityEditor.XCodeEditor;
using System.IO;

public class BuildProject : Editor {

	static string[] GetBuildScenes()
	{
		List<string> names = new List<string>();
		foreach(EditorBuildSettingsScene e in EditorBuildSettings.scenes)
		{
			if(e==null)
				continue;
			if(e.enabled)
				names.Add(e.path);
		}
		return names.ToArray();
	}

	static string BeforeBuild()
	{
		GameConstConfig config = new GameConstConfig();
		config.DevelopMode = false;
		GameConstJsonGenerator.GenerateByGameConsConfig(config);

		LuaBinding.Binding();
		
		string exportPath = "";
		foreach (var arg in System.Environment.GetCommandLineArgs())
		{
			if (arg.StartsWith("path="))
			{
				exportPath = arg.Split("="[0])[1];
				break;
			}
		}
		if (exportPath == "")
		{
			Debug.LogError("<color=red>Build Error : export path is null</color>");
			return "";
		}
		return exportPath;
	}
	
	static void BuildForAndroid()
	{
		ABForAndroid.Lua();
		ABForAndroid.Config();
		ABForAndroid.Unit_Prefab();
		FilesGeneratorForResources.Generator();
		FilesGeneratorForStreamingAssets.GeneratorAndroid();

		string exportPath = BeforeBuild();
		if (exportPath == "")
			return;

		Debug.Log("<color=green>Build For Android And Path = " + exportPath + "</color>");

		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "USE_SHARE");
		BuildPipeline.BuildPlayer(GetBuildScenes(), exportPath, BuildTarget.Android, BuildOptions.None);
	}

	[MenuItem ("CC/BuildForIOS", false, 2)]
	static void BuildForIOS()
	{
		ABForIOS.Lua();
		ABForIOS.Config();
		ABForIOS.Unit_Prefab();
		FilesGeneratorForResources.Generator();
		FilesGeneratorForStreamingAssets.GeneratorIOS();

		string exportPath = BeforeBuild();
		if (exportPath == "")
			return;
		
		Debug.Log("<color=green>Build For iOS And Path = " + exportPath + "</color>");
		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, "USE_SHARE");
		BuildPipeline.BuildPlayer(GetBuildScenes(), exportPath, BuildTarget.iOS, BuildOptions.None);
	}

	[PostProcessBuild (100)]
	public static void OnAndroidPostProcessBuild (BuildTarget target, string pathToBuiltProject)
	{
		if (target != BuildTarget.Android) {
			return;
		}
	}

	[PostProcessBuild (100)]
	public static void OniPhonePostProcessBuild (BuildTarget target, string pathToBuiltProject)
	{
		if (target != BuildTarget.iOS) {
			return;
		}

		string path = Path.GetFullPath (pathToBuiltProject);
		XCProject project = new XCProject (pathToBuiltProject);
		project.overwriteBuildSetting ("CODE_SIGN_IDENTITY", "iPhone Distribution: chuan he (E4Y36DA565)", "Release");
		project.overwriteBuildSetting ("PROVISIONING_PROFILE", "32d6266b-fb8a-494f-953a-dc7fef350cad", "Release");
		project.Save();
	}
}
