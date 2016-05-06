using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CC.Editors
{

	public class BuildAssets
	{

		//不同平台下StreamingAssets的路径是不同的，这里需要注意一下。
		public static readonly string RootURL =
			#if UNITY_ANDROID
			"jar:file://" + Application.dataPath + "!/assets/";
			#elif UNITY_IPHONE
			Application.dataPath + "/Raw/";
			#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
			"file://" + Application.dataPath + "/StreamingAssets/";
			#else
			string.Empty;
			#endif

		
		[MenuItem("Assets/CC/Select")]
		[CanEditMultipleObjects]
		public static void Select()
		{
			Object[] list = Selection.objects;
			foreach(Object obj in list)
			{
				Debug.Log(obj);
			}
		}

		//菜单项目将会失去效用，如果没有事物被选择。
		[MenuItem ("Assets/CC/Select", true)]
		static bool ValidateSelection () {
			return Selection.objects.Length > 0;
		}

//		//----------------------------------------------------
//		
//		[MenuItem ("CONTEXT/Rigidbody/Do Something")]
//		static void DoSomething (MenuCommand command) {
//			Rigidbody body = (Rigidbody)command.context;
//			body.mass = 5;
//			Debug.Log(command.context);
//		}

		
		public static string GetBunldPath(Object obj, BuildTarget buildTarget)
		{
			string path = AssetDatabase.GetAssetPath(obj);
			return GetBunldPath(path, buildTarget);
		}

		public static string GetBunldPath(string path, BuildTarget buildTarget)
		{
			Debug.Log(path);
			if(path.IndexOf("Assets/Prefabs") == 0)
			{
				path = path.Replace("Assets/Prefabs", "Assets/StreamingAssets/" + GetPlatformDirectory(buildTarget) + "/Prefabs");
			}
			else if(path.IndexOf("Assets/Game/Prefabs") == 0)
			{
				path = path.Replace("Assets/Game/Prefabs", "Assets/StreamingAssets/" + GetPlatformDirectory(buildTarget) + "/Prefabs");
			}
			//
			else if(path.IndexOf("Assets/Data") == 0)
			{
				path = path.Replace("Assets/Data", "Assets/StreamingAssets/" + GetPlatformDirectory(buildTarget) + "/Data");
			}
			else if(path.IndexOf("Assets/Game/Data") == 0)
			{
				path = path.Replace("Assets/Game/Data", "Assets/StreamingAssets/" + GetPlatformDirectory(buildTarget) + "/Data");
			}
			//
			else
			{
				path = path.Replace("_Assets", "Bundles/" + GetPlatformDirectory(buildTarget));
			}

			path = path.Replace("\\", "/");
			if(path.LastIndexOf('.') > 0)path = path.Substring(0, path.LastIndexOf('.'));
			path += ".bun";
			return path;
		}

		private static Dictionary<BuildTarget, string> _PlatformDirector;
		public static Dictionary<BuildTarget, string> PlatformDirector
		{
			get
			{
				if(_PlatformDirector == null)
				{
					_PlatformDirector = new Dictionary<BuildTarget, string>();
					_PlatformDirector.Add(BuildTarget.Android, "Android");
					_PlatformDirector.Add(BuildTarget.BlackBerry, "BlackBerry");
					_PlatformDirector.Add(BuildTarget.iOS, "IOS");
					_PlatformDirector.Add(BuildTarget.PS3, "PS3");
					_PlatformDirector.Add(BuildTarget.PS4, "PS4");
					_PlatformDirector.Add(BuildTarget.StandaloneOSXUniversal, "OSX");
					_PlatformDirector.Add(BuildTarget.StandaloneOSXIntel64, "OSX");
					_PlatformDirector.Add(BuildTarget.StandaloneOSXIntel, "OSX");
					_PlatformDirector.Add(BuildTarget.StandaloneWindows, "Windows");
					_PlatformDirector.Add(BuildTarget.StandaloneWindows64, "Windows");
					_PlatformDirector.Add(BuildTarget.WebPlayer, "Web");
					_PlatformDirector.Add(BuildTarget.WebPlayerStreamed, "Web");
				}
				return _PlatformDirector;
			}
		}

		public static string GetPlatformDirectory(BuildTarget buildTarget)
		{
			string directory = "";
			PlatformDirector.TryGetValue(buildTarget, out directory);
			return directory;
		}


		public static void CheckPath(string path, bool isFile = true)
		{
			if(isFile) path = path.Substring(0, path.LastIndexOf('/'));
//			path = path.Replace("Assets", "");
			string[] dirs = path.Split('/');
//			string target = Application.dataPath;
			string target = "Assets";
			string parent = "Assets";

			bool first = true;
			foreach(string dir in dirs)
			{
				if(first)
				{
					first = false;
					continue;
				}

				if(string.IsNullOrEmpty(dir)) continue;
				target +="/"+ dir;
				if(!Directory.Exists(target))
				{
					AssetDatabase.CreateFolder(parent, dir);
				}
				parent += "/"+ dir;
			}

		}


		//-----------------------------------
		public static void BuildSelectObject(BuildTarget buildTarget)
		{
			Object obj = Selection.activeObject;
			BuildSelectObject(obj, buildTarget);
		}

		public static void BuildSelectObject(Object obj, BuildTarget buildTarget)
		{
			string path = BuildAssets.GetBunldPath(obj, buildTarget);
			BuildAssets.CheckPath(path);
			Debug.Log("[BuildSelectObject]" + path);
			
			var options = BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets  ;
//			var options = BuildAssetBundleOptions.CollectDependencies;
			BuildPipeline.BuildAssetBundle(obj, null, path, options, buildTarget);
			AssetDatabase.Refresh();
		}

		public static void BuildSelectObjects(BuildTarget buildTarget)
		{
			Object[] list = Selection.objects;
			if(list.Length == 0)
			{
				Debug.Log("[BuildSelectObjects] Selection.objects.Length=0");
				return;
			}
			
			string path = AssetDatabase.GetAssetPath(list[0]);
			path = Path.GetDirectoryName(path);
			
			string buildPath = BuildAssets.GetBunldPath(path, buildTarget);
			BuildAssets.CheckPath(buildPath);
			Debug.Log("[BuildSelectObject]" + buildPath);
			
			var options = BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets;
			BuildPipeline.BuildAssetBundle(null, list, buildPath, options, buildTarget);
			AssetDatabase.Refresh();
		}
		
		public static void BuildSelectFolder(BuildTarget buildTarget)
		{
			Object obj = Selection.activeObject;
			BuildSelectFolder(obj, buildTarget);
		}

		public static void BuildSelectFolder(Object obj, BuildTarget buildTarget)
		{

			string path = AssetDatabase.GetAssetPath(obj);
			
			string root = Application.dataPath.Replace("Assets", "");
			string absolutePath = root + path;
			
			Debug.Log(absolutePath);
			List<Object> list = new List<Object>();
			if((File.GetAttributes(absolutePath) & FileAttributes.Directory) == FileAttributes.Directory)
			{
				foreach(string file in Directory.GetFiles(absolutePath))
				{
					if(Path.GetExtension(file) == ".meta") continue;
					if(Path.GetFileName(file).IndexOf(".") == 0) continue;
					string assetPath = file.Replace(root, "");
					Object asset = AssetDatabase.LoadMainAssetAtPath(assetPath);
					list.Add(asset);
					Debug.Log(assetPath + "\t" + asset);
				}
			}
			else
			{
				Debug.Log("Select is not Directory");
				return;
			}
			
			if(list.Count > 0)
			{
				string bunldPath = BuildAssets.GetBunldPath(obj, buildTarget);
				BuildAssets.CheckPath(bunldPath);
				
				Debug.Log("[BuildSelectFolder] Source=" + path);
				Debug.Log("[BuildSelectFolder] Target=" + bunldPath);
				
				var options = BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets;
				BuildPipeline.BuildAssetBundle(null, list.ToArray(), bunldPath, options, buildTarget);
				AssetDatabase.Refresh();
			}
			else
			{
				Debug.Log("[BuildSelectFolder] list.Count="+list.Count );
			}
		}
		
		//-----------------------------------
		public static void BuildSelectObjectBatch(BuildTarget buildTarget)
		{
			Object[] list = Selection.objects;
			if(list.Length == 0)
			{
				Debug.Log("[BuildSelectObjectBatch] Selection.objects.Length=0");
				return;
			}

			foreach(Object obj in list)
			{
				BuildSelectObject(obj, buildTarget);
			}
		}


		public static void BuildSelectFolderBatch(BuildTarget buildTarget)
		{
			Object[] list = Selection.objects;
			if(list.Length == 0)
			{
				Debug.Log("[BuildSelectFolderBatch] Selection.objects.Length=0");
				return;
			}

			foreach(Object obj in list)
			{
				BuildSelectFolder(obj, buildTarget);
			}

		}

		public static void BuildSelectFolderOfFilesBatch(BuildTarget buildTarget)
		{
			Object[] list = Selection.objects;
			if(list.Length == 0)
			{
				Debug.Log("[BuildSelectFolderOfFilesBatch] Selection.objects.Length=0");
				return;
			}


			
			foreach(Object obj in list)
			{
				string path = AssetDatabase.GetAssetPath(obj);
				BuildSelectFolderOfFilesBatch(path, buildTarget);
			}
		}

		public static void BuildSelectFolderOfFilesBatch(string path, BuildTarget buildTarget)
		{

			if((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory)
			{
				foreach(string file in Directory.GetFiles(path))
				{
					if(Path.GetExtension(file) == ".meta") continue;
					if(Path.GetFileName(file).IndexOf(".") == 0) continue;
					Debug.Log(file);
					
					Object asset = AssetDatabase.LoadMainAssetAtPath(file);
					BuildSelectObject(asset, buildTarget);
				}

				foreach(string dir in Directory.GetDirectories(path))
				{
					if(Path.GetFileName(dir).IndexOf(".") == 0) continue;
					BuildSelectFolderOfFilesBatch(dir, buildTarget);
				}
			}
			else
			{
				Debug.Log(path);
				Object asset = AssetDatabase.LoadMainAssetAtPath(path);
				BuildSelectObject(asset, buildTarget);
			}
		}


	}
	
	public class BuildAssetsForOSX
	{
		[MenuItem("Assets/CC/Bundle4/OSX/BuildSelectObject", false, 210)]
		public static void BuildSelectObject()
		{
			BuildAssets.BuildSelectObject(BuildTarget.StandaloneOSXUniversal);
		}

		
		[MenuItem("Assets/CC/Bundle4/OSX/BuildSelectObjects", false, 210)]
		public static void BuildSelectObjects()
		{
			BuildAssets.BuildSelectObjects(BuildTarget.StandaloneOSXUniversal);
		}

		
		[MenuItem("Assets/CC/Bundle4/OSX/BuildSelectFolder", false, 210)]
		public static void BuildSelectFolder()
		{
			BuildAssets.BuildSelectFolder(BuildTarget.StandaloneOSXUniversal);
		}

		
		[MenuItem("Assets/CC/Bundle4/OSX/BuildSelectObjectBatch", false, 211)]
		public static void BuildSelectObjectBatch()
		{
			BuildAssets.BuildSelectObjectBatch(BuildTarget.StandaloneOSXUniversal);
		}

		
		[MenuItem("Assets/CC/Bundle4/OSX/BuildSelectFolderBatch", false, 211)]
		public static void BuildSelectFolderBatch()
		{
			BuildAssets.BuildSelectFolderBatch(BuildTarget.StandaloneOSXUniversal);
		}
		
		[MenuItem("Assets/CC/Bundle4/OSX/遍历目录所有文件 生成一一对应", false, 212)]
		public static void BuildSelectFolderOfFilesBatch()
		{
			BuildAssets.BuildSelectFolderOfFilesBatch(BuildTarget.StandaloneOSXUniversal);
		}
	}

	
	
	public class BuildAssetsForWindows
	{
		[MenuItem("Assets/CC/Bundle4/Windows/BuildSelectObject", false, 220)]
		public static void BuildSelectObject()
		{
			BuildAssets.BuildSelectObject(BuildTarget.StandaloneWindows);
		}
		
		
		[MenuItem("Assets/CC/Bundle4/Windows/BuildSelectObjects", false, 220)]
		public static void BuildSelectObjects()
		{
			BuildAssets.BuildSelectObjects(BuildTarget.StandaloneWindows);
		}
		
		
		[MenuItem("Assets/CC/Bundle4/Windows/BuildSelectFolder", false, 220)]
		public static void BuildSelectFolder()
		{
			BuildAssets.BuildSelectFolder(BuildTarget.StandaloneWindows);
		}
		
		
		[MenuItem("Assets/CC/Bundle4/Windows/BuildSelectObjectBatch", false, 221)]
		public static void BuildSelectObjectBatch()
		{
			BuildAssets.BuildSelectObjectBatch(BuildTarget.StandaloneWindows);
		}
		
		
		[MenuItem("Assets/CC/Bundle4/Windows/BuildSelectFolderBatch", false, 221)]
		public static void BuildSelectFolderBatch()
		{
			BuildAssets.BuildSelectFolderBatch(BuildTarget.StandaloneWindows);
		}

		
		[MenuItem("Assets/CC/Bundle4/Windows/遍历目录所有文件 生成一一对应", false, 222)]
		public static void BuildSelectFolderOfFilesBatch()
		{
			BuildAssets.BuildSelectFolderOfFilesBatch(BuildTarget.StandaloneWindows);
		}
	}

	
	public class BuildAssetsForAndroid
	{
		[MenuItem("Assets/CC/Bundle4/Android/BuildSelectObject", false, 230)]
		public static void BuildSelectObject()
		{
			BuildAssets.BuildSelectObject(BuildTarget.Android);
		}
		
		
		[MenuItem("Assets/CC/Bundle4/Android/BuildSelectObjects", false, 230)]
		public static void BuildSelectObjects()
		{
			BuildAssets.BuildSelectObjects(BuildTarget.Android);
		}
		
		
		[MenuItem("Assets/CC/Bundle4/Android/BuildSelectFolder", false, 230)]
		public static void BuildSelectFolder()
		{
			BuildAssets.BuildSelectFolder(BuildTarget.Android);
		}
		
		
		[MenuItem("Assets/CC/Bundle4/Android/BuildSelectObjectBatch", false, 231)]
		public static void BuildSelectObjectBatch()
		{
			BuildAssets.BuildSelectObjectBatch(BuildTarget.Android);
		}
		
		
		[MenuItem("Assets/CC/Bundle4/Android/BuildSelectFolderBatch", false, 231)]
		public static void BuildSelectFolderBatch()
		{
			BuildAssets.BuildSelectFolderBatch(BuildTarget.Android);
		}

		
		[MenuItem("Assets/CC/Bundle4/Android/遍历目录所有文件 生成一一对应", false, 232)]
		public static void BuildSelectFolderOfFilesBatch()
		{
			BuildAssets.BuildSelectFolderOfFilesBatch(BuildTarget.Android);
		}
	}

	
	public class BuildAssetsForIOS
	{
		[MenuItem("Assets/CC/Bundle4/IOS/BuildSelectObject", false, 240)]
		public static void BuildSelectObject()
		{
			BuildAssets.BuildSelectObject(BuildTarget.iOS);
		}
		
		
		[MenuItem("Assets/CC/Bundle4/IOS/BuildSelectObjects", false, 240)]
		public static void BuildSelectObjects()
		{
			BuildAssets.BuildSelectObjects(BuildTarget.iOS);
		}
		
		
		[MenuItem("Assets/CC/Bundle4/IOS/BuildSelectFolder", false, 240)]
		public static void BuildSelectFolder()
		{
			BuildAssets.BuildSelectFolder(BuildTarget.iOS);
		}
		
		
		[MenuItem("Assets/CC/Bundle4/IOS/BuildSelectObjectBatch", false, 241)]
		public static void BuildSelectObjectBatch()
		{
			BuildAssets.BuildSelectObjectBatch(BuildTarget.iOS);
		}
		
		
		[MenuItem("Assets/CC/Bundle4/IOS/BuildSelectFolderBatch", false, 241)]
		public static void BuildSelectFolderBatch()
		{
			BuildAssets.BuildSelectFolderBatch(BuildTarget.iOS);
		}

		
		
		[MenuItem("Assets/CC/Bundle4/IOS/遍历目录所有文件 生成一一对应", false, 242)]
		public static void BuildSelectFolderOfFilesBatch()
		{
			BuildAssets.BuildSelectFolderOfFilesBatch(BuildTarget.iOS);
		}
	}


	public class BuildAssetsForAll
	{
		
		[MenuItem("Assets/CC/Bundle4/BuildSelectObject", false, 100)]
		public static void BuildSelectObject()
		{
			BuildAssets.BuildSelectObject(BuildTarget.StandaloneOSXUniversal);
			BuildAssets.BuildSelectObject(BuildTarget.Android);
			BuildAssets.BuildSelectObject(BuildTarget.iOS);
			BuildAssets.BuildSelectObject(BuildTarget.StandaloneWindows);
		}
		
		
		[MenuItem("Assets/CC/Bundle4/BuildSelectObjects", false, 100)]
		public static void BuildSelectObjects()
		{
			BuildAssets.BuildSelectObjects(BuildTarget.StandaloneOSXUniversal);
			BuildAssets.BuildSelectObjects(BuildTarget.Android);
			BuildAssets.BuildSelectObjects(BuildTarget.iOS);
			BuildAssets.BuildSelectObjects(BuildTarget.StandaloneWindows);
		}
		
		
		[MenuItem("Assets/CC/Bundle4/BuildSelectFolder", false, 100)]
		public static void BuildSelectFolder()
		{
			BuildAssets.BuildSelectFolder(BuildTarget.StandaloneOSXUniversal);
			BuildAssets.BuildSelectFolder(BuildTarget.Android);
			BuildAssets.BuildSelectFolder(BuildTarget.iOS);
			BuildAssets.BuildSelectFolder(BuildTarget.StandaloneWindows);
		}
		
		
		[MenuItem("Assets/CC/Bundle4/BuildSelectObjectBatch", false, 100)]
		public static void BuildSelectObjectBatch()
		{
			BuildAssets.BuildSelectObjectBatch(BuildTarget.StandaloneOSXUniversal);
			BuildAssets.BuildSelectObjectBatch(BuildTarget.Android);
			BuildAssets.BuildSelectObjectBatch(BuildTarget.iOS);
			BuildAssets.BuildSelectObjectBatch(BuildTarget.StandaloneWindows);
		}
		
		
		[MenuItem("Assets/CC/Bundle4/BuildSelectFolderBatch", false, 100)]
		public static void BuildSelectFolderBatch()
		{
			BuildAssets.BuildSelectFolderBatch(BuildTarget.StandaloneOSXUniversal);
			BuildAssets.BuildSelectFolderBatch(BuildTarget.Android);
			BuildAssets.BuildSelectFolderBatch(BuildTarget.iOS);
			BuildAssets.BuildSelectFolderBatch(BuildTarget.StandaloneWindows);
		}
		
		
		[MenuItem("Assets/CC/Bundle4/遍历目录所有文件 生成一一对应", false, 100)]
		public static void BuildSelectFolderOfFilesBatch()
		{
			BuildAssets.BuildSelectFolderOfFilesBatch(BuildTarget.StandaloneOSXUniversal);
			BuildAssets.BuildSelectFolderOfFilesBatch(BuildTarget.Android);
			BuildAssets.BuildSelectFolderOfFilesBatch(BuildTarget.iOS);
			BuildAssets.BuildSelectFolderOfFilesBatch(BuildTarget.StandaloneWindows);
		}
	}
}
