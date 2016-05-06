using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

namespace CC.Editors
{
	public class BatchSettingMaterialShader : EditorWindow {

		[MenuItem ("CC/批量设置材质Shader", false, 11)]
		static void ShowWindow () {
			BatchSettingMaterialShader tm = EditorWindow.GetWindow<BatchSettingMaterialShader>("批量设置材质Shader");
		}

		public Material templateMaterial;
		void OnGUI()
		{
			EditorGUILayout.BeginVertical();
			templateMaterial = EditorGUILayout.ObjectField("Template Material", templateMaterial, typeof(Material), false) as Material;
			if (templateMaterial != null)
			{
				if (GUILayout.Button("Reset all Material"))
				{
					string root = AssetDatabase.GetAssetPath(Selection.activeObject);
					if (Directory.Exists(root))
					{


						List<string> pathList = new List<string>();
						FindAssetsInDirectory<Material>(root, pathList);

						int  numFiles = pathList.Count;

						for(int i = 0; i < numFiles; i ++)
						{
							
							if (EditorUtility.DisplayCancelableProgressBar("Setting Material", i + "/" + numFiles, (float)i/(float)numFiles))
								break;

							Material asset = AssetDatabase.LoadAssetAtPath(pathList[i], typeof(Material)) as Material;
							if(asset == templateMaterial) continue;

							asset.shader = templateMaterial.shader;
						}
						
						EditorUtility.ClearProgressBar();
					}
				}
			}
			EditorGUILayout.EndVertical();
		}

		
		private void FindAssetsInDirectory<T>(string root, List<string> assets) where T : class
		{
			string[] files = Directory.GetFiles(root);
			foreach(string file in files)
			{
				if (CheckAsset<T>(file))
				{
					assets.Add(file);
				}
			}
			
			string[] subs = Directory.GetDirectories(root);
			foreach(string subDir in subs)
			{
				FindAssetsInDirectory<T>(subDir, assets);
			}
		}

		
		private bool CheckAsset<T>(string path)
		{
			UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath(path, typeof(T));
			if (asset is T)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

	}
}
