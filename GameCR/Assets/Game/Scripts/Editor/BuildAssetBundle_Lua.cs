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

		
		public static void Lua(RuntimePlatform platform, BuildTarget buildTarget)
		{
			string luaRoot = "Assets/Game/Lua";
			string bytesRoot = "Assets/Game/LuaBytes";
			
			List<string> luaList = new List<string>();
			RecursiveLua(luaRoot, luaList);


			
			if (Directory.Exists(bytesRoot)) PathUtil.DeleteDirectory(bytesRoot);
			Directory.CreateDirectory(bytesRoot);

			for(int i = 0; i < luaList.Count; i ++)
			{
				string ext = Path.GetExtension(luaList[i]);
				if(ext.Equals(".lua"))
				{
					string sourcePath = luaList[i];
					string destPath = PathUtil.ChangeExtension(sourcePath.Replace(luaRoot, bytesRoot), GameConst.BytesExt);
					
					PathUtil.CheckPath(destPath, true);
					File.Copy(sourcePath, destPath, true);
				}
			}

			
			AssetDatabase.Refresh();
			
			List<string> luaBytesList = new List<string>();
			RecursiveLuaBytes(bytesRoot, luaBytesList);

			string assetBundleName =  "luacode" + EXT;

			AssetBundleBuild[] builds = new AssetBundleBuild[1];
			builds[0].assetBundleName =  assetBundleName;
			builds[0].assetNames = luaBytesList.ToArray();
			Debug.Log("luaBytesList.Count=" + luaBytesList.Count);
			
			string outPath = bytesRoot;
			PathUtil.CheckPath(outPath, false);
			BuildPipeline.BuildAssetBundles(outPath, builds, BuildAssetBundleOptions.None, buildTarget);
			AssetDatabase.Refresh();

			string inAssetBundlePath = bytesRoot + "/" + assetBundleName;
			string outBytesPath = GetOutRoot(platform, isStreamAssetsPath) + assetBundleName;
			byte[] bytes = File.ReadAllBytes(inAssetBundlePath);

			bytes = EncryptBytes(bytes, "zengfeng");

			PathUtil.CheckPath(outBytesPath, true);
			File.WriteAllBytes(outBytesPath, bytes);


//			builds = new AssetBundleBuild[1];
//			builds[0].assetBundleName =  assetBundleName;
//			builds[0].assetNames = new string[]{outBytesPath};
//
//
//			outPath = GetOutRoot(platform, isStreamAssetsPath) + "lua";
//			PathUtil.CheckPath(outPath, false);
//			BuildPipeline.BuildAssetBundles(outPath, builds, BuildAssetBundleOptions.None, buildTarget);

			
			if (Directory.Exists(bytesRoot)) PathUtil.DeleteDirectory(bytesRoot);
			AssetDatabase.Refresh();
		
		}




	}

	

}