using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FindReferencesInAllPrefab_Font : EditorWindow
{
	
	[MenuItem ("CC/查找引用--字体", false, 10)]
	static void ShowWindow ()
	{
		FindReferencesInAllPrefab_Font tm = EditorWindow.GetWindow<FindReferencesInAllPrefab_Font>("查找应用--字体");
	}

	void OnGUI()
	{
		EditorGUILayout.BeginVertical();



		EditorGUILayout.EndVertical();
	}



}
