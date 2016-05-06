using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

namespace CC.Editors
{
	public class BatchSettingTexturePackingTag : EditorWindow {

		[MenuItem ("CC/批量设置贴图 Packing Tag", false, 10)]
		static void ShowWindow () {
			BatchSettingTexturePackingTag tm = EditorWindow.GetWindow<BatchSettingTexturePackingTag>("批量设置贴图 Packing Tag");
		}

		[MenuItem ("Assets/批量设置PackingTag用文件夹名")]
		static void SetTagUseFoliderName_0 () {
			SetSelectFoliders(0);
		}
		
		[MenuItem ("Assets/批量设置PackingTag用上2级文件夹名")]
		static void SetTagUseFoliderName_1 () {
			SetSelectFoliders(1);
		}
		
		
		[MenuItem ("Assets/批量设置PackingTag用上3级文件夹名")]
		static void SetTagUseFoliderName_2 () {
			SetSelectFoliders(2);
		}

		[MenuItem ("CC/批量设置PackingTag 士兵", false, 10)]
		static void SetSolider () {
			SetFolider("Assets/Game/Res/unit_texture/soldier", 2);
		}



		private string[] platformNames = new string[] {
			"Default",
			"Web",
			"Standalone",
			"iPhone",
			"Android",
			"BlackBerry",
			"FlashPlayer",
		};

		public string packingTag;


		void OnGUI()
		{
			EditorGUILayout.BeginVertical();
			GUILayout.Space(20);
			packingTag = EditorGUILayout.TextField("Packing Tag:", packingTag);


			if (GUILayout.Button("Reset all textures"))
			{
				foreach(UnityEngine.Object obj in Selection.objects)
				{
					string path = AssetDatabase.GetAssetPath(obj);
					if (Directory.Exists(path))
					{
						List<string> urls = new List<string>();
						WalkThroughAssetsInDirectory<Texture>(path, urls);
						int numFiles = urls.Count;


						for(int i = 0; i < numFiles; i++)
						{
							if (EditorUtility.DisplayCancelableProgressBar("Setting texture", i + "/" + numFiles, (float)i/(float)numFiles))
								break;
						
							string url = urls[i];

							Set(url, packingTag);
						}
						EditorUtility.ClearProgressBar();

					}
				}
			}

			GUILayout.Space(30);

			if (GUILayout.Button("用文件夹名 设置Tag"))
			{
				SetSelectFoliders(0);
			}

			if (GUILayout.Button("用上2级文件夹名 设置Tag"))
			{
				SetSelectFoliders(1);
			}
			
			if (GUILayout.Button("用上3级文件夹名 设置Tag"))
			{
				SetSelectFoliders(2);
			}

			EditorGUILayout.EndVertical();
		}

		
		public static void Set(List<string> urlList, string tag)
		{
			foreach(string url in urlList)
			{
				Set(url, tag);
			}
		}

		public static void Set(string url, string tag)
		{
			TextureImporter importer = TextureImporter.GetAtPath(url) as TextureImporter;
			if (importer == null)
				return;
			

//			TextureImporterSettings settings = new TextureImporterSettings();
//			importer.ReadTextureSettings(settings);
			importer.spritePackingTag = tag;
//			importer.SetTextureSettings(settings);
			AssetDatabase.ImportAsset(url);
		}


		public static void SetTagUseFoliderName(string path, int up = 0)
		{
			string directoryName = PathUtil.GetDirectoryName(path, up);
			Set(path, directoryName);
		}

		public static void SetFolider(string path, int up)
		{
			if (Directory.Exists(path))
			{
				List<string> urls = new List<string>();
				WalkThroughAssetsInDirectory<Texture>(path, urls);
				int numFiles = urls.Count;
				
				
				for(int i = 0; i < numFiles; i++)
				{
					if (EditorUtility.DisplayCancelableProgressBar("Setting texture", i + "/" + numFiles, (float)i/(float)numFiles))
						break;
					
					string url = urls[i];
					
					SetTagUseFoliderName(url, up);
				}
				EditorUtility.ClearProgressBar();
				
			}
		}

		public static void SetSelectFoliders(int up)
		{
			foreach(UnityEngine.Object obj in Selection.objects)
			{
				string path = AssetDatabase.GetAssetPath(obj);
				SetFolider(path, up);
			}
		}

		private static void WalkThroughAssetsInDirectory<T>(string root, List<string> assets) where T : class
		{
	//		Resources.UnloadUnusedAssets();
			string[] files = Directory.GetFiles(root);
			
			foreach(string file in files)
			{
				//if (CheckAsset<T>(file))
				{
					assets.Add(file);
				}
			}

			string[] subs = Directory.GetDirectories(root);
			foreach(string subDir in subs)
			{
				WalkThroughAssetsInDirectory<T>(subDir, assets);
			}
		}

		private bool CheckAsset<T>(string url)
		{
			UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath(url, typeof(T));
			if (asset is T)
			{
				return true;
			}
			else
			{
				return false;
			}
			AssetDatabase.SaveAssets();
			Debug.Log ("Resources.UnloadUnusedAssets() TextureMaster!");
			Resources.UnloadUnusedAssets();
		}
	}
}
