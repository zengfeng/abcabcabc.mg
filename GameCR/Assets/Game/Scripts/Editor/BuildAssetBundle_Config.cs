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
		
		public static void Config(RuntimePlatform platform, BuildTarget buildTarget)
		{
			string configRoot = "Assets/Game/Config";
			string bytesRoot = "Assets/Game/ConfigBytes";
			
			List<string> configList = new List<string>();
			Recursive(configRoot, configList);



			
			if (Directory.Exists(bytesRoot)) PathUtil.DeleteDirectory(bytesRoot);
			Directory.CreateDirectory(bytesRoot);

			for(int i = 0; i < configList.Count; i ++)
			{
				string sourcePath = configList[i];
				string destPath = PathUtil.ChangeExtension(sourcePath.Replace(configRoot, bytesRoot), ".txt");
				
				PathUtil.CheckPath(destPath, true);
				File.Copy(sourcePath, destPath, true);
			}

			
			
			AssetDatabase.Refresh();
			
			List<string> bytesList = new List<string>();
			Recursive(bytesRoot, bytesList);

//			bytesList = configList;
		
			string assetBundleName =  "config" + EXT;

			AssetBundleBuild[] builds = new AssetBundleBuild[1];
			builds[0].assetBundleName =  assetBundleName;
			builds[0].assetNames = bytesList.ToArray();
			Debug.Log("bytesList.Count=" + bytesList.Count);
			
			string outPath = bytesRoot;
			PathUtil.CheckPath(outPath, false);
			BuildPipeline.BuildAssetBundles(outPath, builds, BuildAssetBundleOptions.None, buildTarget);
			AssetDatabase.Refresh();

			string inAssetBundlePath = bytesRoot + "/" + assetBundleName;
			string outBytesPath = GetOutRoot(platform, isStreamAssetsPath) +  assetBundleName;
			byte[] bytes = File.ReadAllBytes(inAssetBundlePath);

			bytes = EncryptBytes(bytes, "zengfeng");

			PathUtil.CheckPath(outBytesPath, true);
			File.WriteAllBytes(outBytesPath, bytes);

			
			if (Directory.Exists(bytesRoot)) PathUtil.DeleteDirectory(bytesRoot);
			AssetDatabase.Refresh();
		
		}




	}

	

}