using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

namespace Game.Editors
{
	public partial class AB 
	{
		
		public static void Map(RuntimePlatform platform, BuildTarget buildTarget)
		{
			string prefabRoot = "Assets/Game/Res/map";
			List<string> prefabList = new List<string>();
			FindPrefab(prefabRoot, prefabList);

			
			string[] dependencies = AssetDatabase.GetDependencies(prefabList.ToArray());


			List<string> imageExts = new List<string>(new string[]{".jpg", ".png", ".tga", ".psd"});
			List<string> filterExts = new List<string>(new string[]{".cs", ".js", ".shader"});

			Dictionary<string, List<string>> packerDict = new Dictionary<string, List<string>>();
			List<string> otherList = new List<string>();
			for(int i = 0; i < dependencies.Length; i ++)
			{
				string item = dependencies[i];
				if(prefabList.IndexOf(item) == -1)
				{

					string ext = Path.GetExtension(item);
					if(imageExts.IndexOf(ext) != -1)
					{
						TextureImporter importer = TextureImporter.GetAtPath(item) as TextureImporter;
						if(importer.textureType == TextureImporterType.Sprite && !string.IsNullOrEmpty(importer.spritePackingTag))
						{
							List<string> list = new List<string>();
							if(!packerDict.TryGetValue(importer.spritePackingTag, out list))
							{
								list = new List<string>();
								packerDict.Add(importer.spritePackingTag, list);
							}
							list.Add(item);
						}
						else
						{
							otherList.Add(item);
						}
					}
					else if(filterExts.IndexOf(ext) == -1)
					{
						otherList.Add(item);
					}
				}
			}

			
			AssetBundleBuild[] builds = new AssetBundleBuild[prefabList.Count + otherList.Count + packerDict.Count ];
			int index = 0;
			for(int i = 0; i < prefabList.Count; i ++)
			{
				builds[index] = new AssetBundleBuild();
				
				string assetBundleName =  prefabList[i].Replace(prefabRoot + "/", "").ToLower();
				assetBundleName = PathUtil.ChangeExtension(assetBundleName, EXT);
				builds[index].assetBundleName = assetBundleName;
				builds[index].assetNames = new string[]{prefabList[i]};
				index ++;
			}

			for(int i = 0; i < otherList.Count; i ++)
			{
				builds[index] = new AssetBundleBuild();
				string assetBundleName =  otherList[i].Replace(prefabRoot + "/", "").ToLower();
				assetBundleName = PathUtil.ChangeExtension(assetBundleName, EXT);
				builds[index].assetBundleName = assetBundleName;
				builds[index].assetNames = new string[]{otherList[i]};
				index ++;
			}

			foreach(KeyValuePair<string, List<string>> kvp in  packerDict)
			{
				builds[index] = new AssetBundleBuild();
				string assetBundleName =  kvp.Key.ToLower();
				assetBundleName = PathUtil.ChangeExtension(assetBundleName, EXT);
				builds[index].assetBundleName = assetBundleName;
				builds[index].assetNames = kvp.Value.ToArray();
				index ++;
			}



			
			string outPath = GetOutRoot(platform, isStreamAssetsPath) + "map";
			PathUtil.CheckPath(outPath, false);
			BuildPipeline.BuildAssetBundles(outPath, builds, BuildAssetBundleOptions.None, buildTarget);
			AssetDatabase.Refresh();
		}
	}

	

}