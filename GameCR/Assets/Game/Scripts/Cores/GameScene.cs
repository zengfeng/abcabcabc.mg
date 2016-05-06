using UnityEngine;
using System.Collections;
using CC.Module.Menu;

public class GameScene : MonoBehaviour
{
	public static string Enter 				= "Enter";
	public static string Main 				= "Main";
	public static string War 				= "War";
	public static string War_Editor 		= "War-Editor";
	public static string War_Editor_MapIcon = "War-Editor-MapIcon";

	public static string Scene_Loader_Normal	= "Loader";
	public static string Scene_Loader_PVP		= "PVPLoader";
	public static string Scene_Loader_Dungeon	= "PVPLoader";

	public static bool IsEnter()
	{
		return Application.loadedLevelName == GameScene.Enter;
	}

	public static bool IsMain()
	{
		return Application.loadedLevelName == GameScene.Main;
	}

	public static bool IsMain(string sceneName)
	{
		return sceneName == GameScene.Main;
	}

	public static bool IsWar()
	{
		return IsWar(Application.loadedLevelName);
	}

	public static bool IsWar(string sceneName)
	{
		return sceneName == GameScene.War || sceneName == GameScene.War_Editor;
	}

	public static bool IsWarEditor()
	{
		return IsWarEditor(Application.loadedLevelName);
	}
	
	public static bool IsWarEditor(string sceneName)
	{
		return sceneName == GameScene.War_Editor;
	}

	public static string GetLoadSceneName(LoadType loadType)
	{
		switch(loadType)
		{
		case LoadType.Scene_Dungeon:
			return GameScene.Scene_Loader_Dungeon;
			break;
		case LoadType.Scene_PVP:
			return GameScene.Scene_Loader_PVP;
			break;
		default:
			return GameScene.Scene_Loader_Normal;
			break;
		}
	}

}
