using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEditor;

namespace Game.Editors
{
	public class FilesGeneratorForStreamingAssets 
	{
		
//		[MenuItem("CC/生成files.csv(StreamingAssets)/默认", false, 1000)]

//		public static void GeneratorDefault()

//		{

//			Generator(Application.streamingAssetsPath);

//		}

		[MenuItem("CC/生成files.csv(StreamingAssets)/OSX", false, 1001)]
		public static void GeneratorOSX()
		{
			Generator(RuntimePlatform.OSXPlayer);
		}
		
		[MenuItem("CC/生成files.csv(StreamingAssets)/Windows", false, 1001)]
		public static void GeneratorWindows()
		{
			Generator(RuntimePlatform.WindowsPlayer);
		}

		
		[MenuItem("CC/生成files.csv(StreamingAssets)/Android", false, 1001)]
		public static void GeneratorAndroid()
		{
			Generator(RuntimePlatform.Android);
		}
		
		
		[MenuItem("CC/生成files.csv(StreamingAssets)/IOS", false, 1001)]
		public static void GeneratorIOS()
		{
			Generator(RuntimePlatform.IPhonePlayer);
		}

		
		
		[MenuItem("CC/生成files.csv(StreamingAssets)/所有", false, 1002)]
		public static void GeneratorAll()
		{
			GeneratorOSX();
			GeneratorWindows();
			GeneratorAndroid();
			GeneratorIOS();
		}


		static List<string> fileList = new List<string>();
		public static void Generator(RuntimePlatform runtimePlatform)
		{
			string platformDirectory = PathUtil.GetPlatformDirectory(runtimePlatform, true);
			string root = Application.streamingAssetsPath + "/" + platformDirectory;
			PathUtil.CheckPath(root, false);
			string filesPath = root + "/files.csv";
			if (File.Exists(filesPath)) File.Delete(filesPath);

			fileList.Clear();
			Recursive("Assets/Game/Config" , root, fileList);
			Recursive(Application.streamingAssetsPath , root, fileList);

			FileStream fs = new FileStream(filesPath, FileMode.CreateNew);
			StreamWriter sw = new StreamWriter(fs);
			for (int i = 0; i < fileList.Count; i++) 
			{
				string file = fileList[i];
				string ext = Path.GetExtension(file);
				if (ext.Equals(".meta")) continue;
				if (ext.Equals(".manifest")) continue;
				string filename = Path.GetFileName(file);
				if(filename.Equals(".DS_Store")) continue;
				if(filename.Equals("test_WarEnterData.json")) continue;
				if(filename.Equals("genMD5.py")) continue;
				if(filename.Equals("crash_report.log")) continue;
//				if(filename.Equals("VERSION.txt")) continue;
				
				string md5 = PathUtil.md5file(file);
				string value = file.Replace(root , "{0}");
				value = value.Replace(Application.streamingAssetsPath + "/", string.Empty);
				value = value.Replace("Assets/Game/", string.Empty);
				string filePath = value;
				value += ";" + md5;

				if(filePath.IndexOf("{0}/image") != -1)
				{
					
					string mainAsset="";
					if(filePath.IndexOf("assetbundlemanifest") != -1)
					{
						mainAsset = "assetbundlemanifest";
					}
					else
					{
						mainAsset = string.Format(filePath, "assets/game/res");
						mainAsset = Path.GetFileName(mainAsset);
						mainAsset = PathUtil.ChangeExtension(mainAsset, "");
					}
					value += ";" + mainAsset;
				}
				else if(filePath.IndexOf("{0}/unit_prefab")!= -1)
				{
					string mainAsset="";
					if(filePath.IndexOf("unit_prefab/unit_prefab") != -1)
					{
						mainAsset = "assetbundlemanifest";
					}
					else
					{
						mainAsset = string.Format(filePath, "assets/game/res");
						mainAsset = Path.GetFileName(mainAsset);
						mainAsset = PathUtil.ChangeExtension(mainAsset, ".prefab");
					}
					value += ";" + mainAsset;
				}
				else if(filePath.IndexOf("{0}/map")!= -1)
				{
					string mainAsset="";
					if(filePath == "{0}/map/map")
					{
						mainAsset = "assetbundlemanifest";
					}
					else
					{
						mainAsset = string.Format(filePath, "assets/game/res");
						mainAsset = Path.GetFileName(mainAsset);
						mainAsset = PathUtil.ChangeExtension(mainAsset, ".prefab");
					}
					value += ";" + mainAsset;

					string assetbundle = filePath.Replace("{0}/map/", "");
					value += ";" + assetbundle + ";map";

				}
				else if(filePath.IndexOf("{0}/ui") != -1)
				{
					string mainAsset="";
					if(filePath == "{0}/ui/ui")
					{
						mainAsset = "assetbundlemanifest";
					}
					else
					{
						mainAsset = string.Format(filePath, "assets/game/res");
						mainAsset = Path.GetFileName(mainAsset);
						mainAsset = PathUtil.ChangeExtension(mainAsset, ".prefab");
					}
					value += ";" + mainAsset;
					
					string assetbundle = filePath.Replace("{0}/ui/", "");
					value += ";" + assetbundle + ";ui";
				}
				else if(filePath.IndexOf("{0}/effect") != -1 || filePath.IndexOf("{0}/assets") != -1)
				{
					string mainAsset="";
					if(filePath == "{0}/effect")
					{
						mainAsset = "assetbundlemanifest";
					}
					else
					{
						mainAsset = string.Format(filePath, "assets/game/res");
						mainAsset = Path.GetFileName(mainAsset);
						mainAsset = PathUtil.ChangeExtension(mainAsset, ".prefab");
					}
					value += ";" + mainAsset;
					
					string assetbundle = filePath.Replace("{0}/", "");
					value += ";" + assetbundle + ";effect";
				}

				
				sw.WriteLine(value);
			}
			sw.Close(); fs.Close();
			AssetDatabase.Refresh();
			Debug.Log("[FilesGenerator]" + filesPath);
		}

		
		/// <summary>
		/// 遍历目录及其子目录
		/// </summary>
		static void Recursive(string path, string platform, List<string> fileList) {
			string[] names = Directory.GetFiles(path);
			string[] dirs = Directory.GetDirectories(path);
			foreach (string filename in names) {
				string ext = Path.GetExtension(filename);
				if (ext.Equals(".meta")) continue;
				
				
				string fn = Path.GetFileName(filename);
				if(fn.Equals(".DS_Store")) continue;
				if(fn.IndexOf(".") == 0) continue;
				
				fileList.Add(filename.Replace('\\', '/'));
			}
			foreach (string dir in dirs) {
				string dirName = Path.GetFileName(dir);
				if(dirName.IndexOf(".") == 0) continue;
				if(path == Application.streamingAssetsPath + "/Platform" && platform != Application.streamingAssetsPath)
				{
					if(dir == platform)
					{
						Recursive(dir, platform, fileList);
					}
				}
				else
				{
					Recursive(dir, platform, fileList);
				}
			}
		}

	}
}