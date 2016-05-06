using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class FindReferencesInAllScene_Texture : Editor
{
	
	[MenuItem ("Assets/Find References In All Scene For Texture", true)]
	static bool ValidateLogSelectedTransformName () {
		if(Selection.activeObject == null)
		{
			return false;
		}
		
		
		Type type = Selection.activeObject.GetType();
		if(type != typeof(Texture2D) && type != typeof(Sprite))
		{
			return false;
		}

		return true;

	}


	[MenuItem("Assets/Find References In All Scene For Texture")]
	private static void OnSearchForReferences()
	{
		//确保鼠标右键选择的是一个Texture
		if(Selection.activeObject == null)
		{
			return;
		}

		
		Type type = Selection.activeObject.GetType();
		if(type != typeof(Texture2D) && type != typeof(Sprite))
		{
			return;
		}
		
		if(!EditorApplication.SaveCurrentSceneIfUserWantsTo()) return;
		string editorScenePath = EditorApplication.currentScene;



		string[] guids = AssetDatabase.FindAssets ("t:scene", new string[] {"Assets/Game/Arts_Modules", "Assets/Game/Scenes"});
		foreach (string guid in guids)
		{
			string scenePath = AssetDatabase.GUIDToAssetPath(guid);
			//打开场景
			EditorApplication.OpenScene(scenePath);
			//获取场景中的所有游戏对象
			Image[] images = (Image[])FindObjectsOfTypeAll(typeof(Image));

			string activePath = AssetDatabase.GetAssetPath(Selection.activeObject);
			foreach(Image image  in images)
			{
				if(image.sprite == null) continue;

				string path = AssetDatabase.GetAssetPath(image.sprite);
				if(path == activePath)
				{
					
					Debug.Log(scenePath  + "  " + GetGameObjectPath(image.gameObject));
				}
			}
		}

		if(!string.IsNullOrEmpty(editorScenePath))
			EditorApplication.OpenScene(editorScenePath);
	}



	public static string GetGameObjectPath(GameObject obj)
	{
		string path = "/" + obj.name;
		while (obj.transform.parent != null)
		{
			obj = obj.transform.parent.gameObject;
			path = "/" + obj.name + path;
		}
		return path;
	}
}
