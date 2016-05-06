using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

namespace Game.Editors
{
	public partial class AB 
	{
		
		public static void Unit_Prefab(RuntimePlatform platform, BuildTarget buildTarget)
		{
			string root = "Assets/Game/Res/unit_prefab";
			
			List<string> fileList = new List<string>();
			Recursive(root, fileList);
			
			string[] filterExt = new string[]{".cs", ".js"};
			//			filterExt = new string[]{};
			
			
			
			Dictionary<string, bool> filterExtDict = new Dictionary<string, bool>();
			foreach(string ext in filterExt)
			{
				filterExtDict.Add(ext, true);
			}
			
			string[] replaceName = new string[]{"Game/Resources/", "Game/Res/"};
			string[] filterDir = new string[]{};
			
			
			AssetBundleBuild[] builds = new AssetBundleBuild[fileList.Count];
			
			
			int index = 0;
			foreach(string file in  fileList)
			{
				
				//				Debug.Log(file);
				string[] dependencies = AssetDatabase.GetDependencies(new string[]{file});
				
				
				
				
				List<string> list = new List<string>();
				list.Add(file);
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
					
					if(dependencies[i] == file) continue;
					
					Debug.Log(string.Format("\tdependencies[{0}] = {1}    ext={2}", i, dependencies[i], ext));
					list.Add(dependencies[i]);
				}
				
				
				
				string assetBundleName = file.Replace(root + "/", "").ToLower();
				assetBundleName = PathUtil.ChangeExtension(assetBundleName, EXT);
				Debug.Log("assetBundleName=" + assetBundleName);
				
				builds[index].assetBundleName = assetBundleName;
				builds[index].assetNames = list.ToArray();
				index ++;
				
			}
			
			string outPath = GetOutRoot(platform, isStreamAssetsPath) + "unit_prefab";
			PathUtil.CheckPath(outPath, false);
			Debug.Log(outPath);
			BuildPipeline.BuildAssetBundles(outPath, builds, BuildAssetBundleOptions.None, buildTarget);
			AssetDatabase.Refresh();
			
		}
	}

	

}