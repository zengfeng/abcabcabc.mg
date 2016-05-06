using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class FindScene : Editor
{
	[MenuItem("Assets/Find Scene")]
	private static void OnSearch()
	{


		string[] guids = AssetDatabase.FindAssets ("t:scene", new string[] {"Assets/Game/Arts_Modules", "Assets/Game/Scenes"});
		foreach (string guid in guids)
			Debug.Log (AssetDatabase.GUIDToAssetPath(guid));
	}
}
