using UnityEngine;
using System.Collections;
using UnityEditor;
using Games.Module.Wars;
using System.Collections.Generic;
using CC.Runtime;

namespace Game.Editors.Wars
{
	public class WarEditor 
	{
		public static string ScenePath = "Assets/Game/Scenes/War-Editor.unity";

		public static bool IsInEditeMode()
		{
			return EditorApplication.currentScene == WarEditor.ScenePath && EditorApplication.isPlaying;
		}

		public static bool InEditMode()
		{
			if(EditorApplication.currentScene != WarEditor.ScenePath)
			{
				if(EditorApplication.SaveCurrentSceneIfUserWantsTo())
				{
					EditorApplication.OpenScene(WarEditor.ScenePath);
				}
				else
				{
					return false;
				}
			}
			else
			{
				//				int option = EditorUtility.DisplayDialogComplex(
				//					"关卡有修改",
				//					"是否保存？",
				//					"保存且继续",
				//					"取消",
				//					"不保存且继续");
				//				
				//				switch(option)
				//				{
				//				case 0:
				//					break;
				//				case 1:
				//					return false;
				//					break;
				//				case 2:
				//					break;
				//				}
			}

			
			
			if(EditorApplication.isPlaying == false)
			{
				EditorApplication.isPlaying = true;

				
				War.isTest = true;
				War.isEditor = true;
			}
			
			return true;
		}


		
		private static Dictionary<string, bool> loadingDict = new Dictionary<string, bool>();
		public static void LoadRes(string file)
		{
			if(!loadingDict.ContainsKey(file))
			{
				loadingDict.Add(file, true);
				Coo.assetManager.Load(file, OnLoadRes);
			}
		}
		
		private static void OnLoadRes(string name, object obj)
		{
			WarRes.AddPrefab(name, obj);
		}

	}
}