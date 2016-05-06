using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using Games;
using System.Security.Cryptography;
using System.Text;

namespace Game.Editors
{
	public partial class AB 
	{
		public static string EXT = ".assetbundle";
		public static bool isStreamAssetsPath = true;
		public static string GetOutRoot(RuntimePlatform platform, bool isStreamAssetsPath = false)
		{
			if(isStreamAssetsPath)
			{
				return Application.streamingAssetsPath + "/" + PathUtil.GetPlatformDirectory(platform, true) + "/";
			}
			else
			{
				return "/Users/zengfeng/workspaces/www/u3d/mbsg/StreamingAssets/" + PathUtil.GetPlatformDirectory(platform, true) + "/";
			}
		}

		
		public static byte[] EncryptBytes(byte[] data, string Skey)  
		{  
			DESCryptoServiceProvider DES = new DESCryptoServiceProvider();  
			DES.Key = ASCIIEncoding.ASCII.GetBytes(Skey);  
			DES.IV = ASCIIEncoding.ASCII.GetBytes(Skey);  
			ICryptoTransform desEncrypt = DES.CreateEncryptor();  
			byte[] result = desEncrypt.TransformFinalBlock(data, 0, data.Length);  
			return result;
		}


		
		/// <summary>
		/// 遍历目录及其子目录
		/// </summary>
		static void Recursive(string path, List<string> fileList) {
			string[] names = Directory.GetFiles(path);
			string[] dirs = Directory.GetDirectories(path);
			foreach (string filename in names) 
			{
				string ext = Path.GetExtension(filename);
				if (ext.Equals(".meta")) continue;
				
				
				string fn = Path.GetFileName(filename);
				if(fn.Equals(".DS_Store")) continue;

				string file = filename.Replace('\\', '/');
				fileList.Add(file);
			}

			foreach (string dir in dirs) 
			{
				Recursive(dir, fileList);
			}
		}

		static void FindPrefab(string path, List<string> fileList)
		{
			string[] names = Directory.GetFiles(path);
			foreach (string filename in names) 
			{
				string ext = Path.GetExtension(filename);
				if (!ext.Equals(".prefab")) continue;
				
				
				string fn = Path.GetFileName(filename);
				if(fn.Equals(".DS_Store")) continue;
				
				string file = filename.Replace('\\', '/');
				fileList.Add(file);
			}
		}

		static void RecursivePrefab(string path, List<string> fileList) {
			string[] names = Directory.GetFiles(path);
			string[] dirs = Directory.GetDirectories(path);
			foreach (string filename in names) 
			{
				string ext = Path.GetExtension(filename);
				if (!ext.Equals(".prefab")) continue;
				
				
				string fn = Path.GetFileName(filename);
				if(fn.Equals(".DS_Store")) continue;
				
				string file = filename.Replace('\\', '/');
				fileList.Add(file);
			}
			
			foreach (string dir in dirs) 
			{
				RecursivePrefab(dir, fileList);
			}
		}

		
		static void RecursiveLua(string path, List<string> fileList) {
			string[] names = Directory.GetFiles(path);
			string[] dirs = Directory.GetDirectories(path);
			foreach (string filename in names) 
			{
				string ext = Path.GetExtension(filename);
				if (!ext.Equals(".lua")) continue;
				
				string fn = Path.GetFileName(filename);
				if(fn.Equals(".DS_Store")) continue;
				
				string file = filename.Replace('\\', '/');
				fileList.Add(file);
			}
			
			foreach (string dir in dirs) 
			{
				RecursiveLua(dir, fileList);
			}
		}

		
		static void RecursiveLuaBytes(string path, List<string> fileList) {
			string[] names = Directory.GetFiles(path);
			string[] dirs = Directory.GetDirectories(path);
			foreach (string filename in names) 
			{
				string ext = Path.GetExtension(filename);
				if (!ext.Equals(GameConst.BytesExt)) continue;
				
				string fn = Path.GetFileName(filename);
				if(fn.Equals(".DS_Store")) continue;
				
				string file = filename.Replace('\\', '/');
				fileList.Add(file);
			}
			
			foreach (string dir in dirs) 
			{
				RecursiveLuaBytes(dir, fileList);
			}
		}

		//--------------------
		public static void FolderForOnce(string root, string dirname, RuntimePlatform platform, BuildTarget buildTarget)
		{

			List<string> fileList = new List<string>();
			Recursive(root, fileList);
			
			int count = fileList.Count;
			
			AssetBundleBuild[] builds = new AssetBundleBuild[count];
			for(int i = 0; i < count; i ++)
			{
				string filePath = fileList[i];
				string assetBundleName = PathUtil.ChangeExtension(filePath.Replace("Assets/Game/Res/", "").Replace("Assets/Game/Resources/", ""), EXT).ToLower();
				Debug.Log(string.Format("filePath={0}, assetBundleName={1}", filePath, assetBundleName));
				builds[i].assetBundleName = assetBundleName;
				builds[i].assetNames = new string[]{filePath.ToLower()};
			}

			
			string outPath = GetOutRoot(platform, isStreamAssetsPath);
			Debug.Log(outPath);
			PathUtil.CheckPath(outPath, false);
			BuildPipeline.BuildAssetBundles(outPath, builds, BuildAssetBundleOptions.None, buildTarget);

			if(isStreamAssetsPath)
			{
				File.Copy(outPath+"/" + PathUtil.GetPlatformDirectoryName(platform, isStreamAssetsPath), outPath+"/"+dirname+"/assetbundlemanifest", true);
				File.Copy(outPath+"/" + PathUtil.GetPlatformDirectoryName(platform, isStreamAssetsPath) + ".manifest", outPath+"/"+dirname+"/assetbundlemanifest.manifest", true);
				File.Delete(outPath+"/" + PathUtil.GetPlatformDirectoryName(platform, isStreamAssetsPath));
				File.Delete(outPath+"/" + PathUtil.GetPlatformDirectoryName(platform, isStreamAssetsPath) + ".manifest");
			}
			AssetDatabase.Refresh();
		}

		
		public static void UIPrefab(Object obj, RuntimePlatform platform, BuildTarget buildTarget)
		{
			
			string path = AssetDatabase.GetAssetPath(obj);
			Debug.Log(path);
			string[] dependencies = AssetDatabase.GetDependencies(new string[]{path});
			
			string[] filterExt = new string[]{".cs", ".js"};
			Dictionary<string, bool> filterExtDict = new Dictionary<string, bool>();
			foreach(string ext in filterExt)
			{
				filterExtDict.Add(ext, true);
			}
			
			
			string[] replaceName = new string[]{"Game/Resources/", "Game/Res/"};
			string[] filterDir = new string[]{"Assets/Game/Res/UI", "Assets/Game/Res/Image","Assets/Game/Res/Texture","Assets/Game/Res/Prefab","Assets/Game/Res/Data","Assets/Game/Res/Sound"};
			
			
			
			List<string> list = new List<string>();
			list.Add(path);
			for(int i = 0; i < dependencies.Length; i ++)
			{
				if(dependencies[i] == path)
				{
					continue;
				}
				
				string ext = Path.GetExtension(dependencies[i]);
				if(filterExtDict.ContainsKey(ext))
				{
					continue;
				}
				
				bool isFilter = false;
				foreach(string filter in filterDir)
				{
					if(dependencies[i].IndexOf(filter) != -1)
					{
						isFilter = true;
						break;
					}
				}
				
				if(isFilter)
				{
					continue;
				}
				
				Debug.Log(string.Format("\tdependencies[{0}] = {1}    ext={2}", i, dependencies[i], ext));
				list.Add(dependencies[i]);
			}
			
			
			string mainPath = new FileInfo(path).DirectoryName.Replace(Application.dataPath + "/", "");
			foreach(string r in replaceName)
			{
				mainPath = mainPath.Replace(r, "");
			}
			mainPath = mainPath.ToLower();
			Debug.Log(mainPath);
			
			
			AssetBundleBuild[] builds = new AssetBundleBuild[1];
			builds[0].assetBundleName = PathUtil.ChangeExtension(Path.GetFileName(path), EXT).ToLower();
			builds[0].assetNames = list.ToArray();
			
			Debug.Log("builds[0].assetBundleName=" + builds[0].assetBundleName);
			
			string outPath = GetOutRoot(platform, isStreamAssetsPath) + mainPath;
			PathUtil.CheckPath(outPath, false);
			Debug.Log(outPath);
			BuildPipeline.BuildAssetBundles(outPath, builds, BuildAssetBundleOptions.None, buildTarget);
			AssetDatabase.Refresh();
		}
		


		public static void ImageFolder(RuntimePlatform platform, BuildTarget buildTarget)
		{
			FolderForOnce("Assets/Game/Res/Image", "image", platform, buildTarget);
		}

		
		
		public static void SoundFolder(RuntimePlatform platform, BuildTarget buildTarget)
		{
			FolderForOnce("Assets/Game/Res/Sound", "sound", platform, buildTarget);
		}

		
		//--------------------
		public static void Avatar(Object obj, RuntimePlatform platform, BuildTarget buildTarget)
		{
			
			string path = AssetDatabase.GetAssetPath(obj);
			Debug.Log(path);
			string[] dependencies = AssetDatabase.GetDependencies(new string[]{path});
			
			string[] filterExt = new string[]{".cs", ".js"};
			filterExt = new string[]{};

			Dictionary<string, bool> filterExtDict = new Dictionary<string, bool>();
			foreach(string ext in filterExt)
			{
				filterExtDict.Add(ext, true);
			}
			
			
			string[] replaceName = new string[]{"Game/Resources/", "Game/Res/"};
			string[] filterDir = new string[]{};
			
			
			
			List<string> list = new List<string>();
//			list.Add(path);
			for(int i = 0; i < dependencies.Length; i ++)
			{
				string ext = Path.GetExtension(dependencies[i]);
				if(filterExtDict.ContainsKey(ext))
				{
					continue;
				}
				
				bool isFilter = false;
				foreach(string filter in filterDir)
				{
					if(dependencies[i].IndexOf(filter) != -1)
					{
						isFilter = true;
						break;
					}
				}
				
				if(isFilter)
				{
					continue;
				}
				
				Debug.Log(string.Format("\tdependencies[{0}] = {1}    ext={2}", i, dependencies[i], ext));
				list.Add(dependencies[i]);
			}
			
			
			string mainPath = new FileInfo(path).DirectoryName.Replace(Application.dataPath + "/", "");
			foreach(string r in replaceName)
			{
				mainPath = mainPath.Replace(r, "");
			}
			mainPath = mainPath.ToLower();
			Debug.Log(mainPath);
			
			
			AssetBundleBuild[] builds = new AssetBundleBuild[1];
			builds[0].assetBundleName = PathUtil.ChangeExtension(Path.GetFileName(path), EXT).ToLower();
			builds[0].assetNames = list.ToArray();
			
			Debug.Log("builds[0].assetBundleName=" + builds[0].assetBundleName);
			
			string outPath = GetOutRoot(platform, isStreamAssetsPath) + mainPath;
			PathUtil.CheckPath(outPath, false);
			Debug.Log(outPath);
			BuildPipeline.BuildAssetBundles(outPath, builds, BuildAssetBundleOptions.None, buildTarget);
			AssetDatabase.Refresh();
		}

	}

}