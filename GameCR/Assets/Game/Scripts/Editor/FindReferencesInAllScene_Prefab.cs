using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class FindReferencesInAllScene_Prefab : Editor
{
	[MenuItem ("Assets/Find References In All Scene For Prefab", true)]
	static bool ValidateLogSelectedTransformName () {
		return Selection.activeGameObject != null;
	}

	[MenuItem("Assets/Find References In All Scene For Prefab")]
	private static void OnSearchForReferences()
	{
		//确保鼠标右键选择的是一个Prefab
		if(Selection.activeGameObject == null)
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
			GameObject []gos = (GameObject[])FindObjectsOfTypeAll(typeof(GameObject));

			Dictionary<GameObject, bool> has = new Dictionary<GameObject, bool>();
			string activePath = AssetDatabase.GetAssetPath(Selection.activeGameObject);
			foreach(GameObject go  in gos)
			{
				//判断GameObject是否为一个Prefab的引用
				if(PrefabUtility.GetPrefabType(go)  == PrefabType.PrefabInstance)
				{
					
					GameObject root = PrefabUtility.FindPrefabRoot(go);
					if(has.ContainsKey(root))
					{
						continue;
					}
					has.Add(root, true);

					UnityEngine.Object parentObject = PrefabUtility.GetPrefabParent(root); 

					string path = AssetDatabase.GetAssetPath(parentObject);

					//判断GameObject的Prefab是否和右键选择的Prefab是同一路径。
					if(path == activePath)
					{
						//输出场景名，以及Prefab引用的路径
						Debug.Log(scenePath  + "  " + GetGameObjectPath(root));
					}
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
