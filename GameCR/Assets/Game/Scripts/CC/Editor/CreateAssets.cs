using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using System.IO;

namespace CC.Editors
{
	public partial class CreateAssets 
	{

		public static void CreateAsset<T>() where T : ScriptableObject
		{
			Type type = typeof(T);

			UnityEngine.Object obj = Selection.activeObject;
			string path = AssetDatabase.GetAssetPath(obj);
			
		
			if(!string.IsNullOrEmpty(Path.GetExtension(path)))
			{
				path = path.Substring(0, path.LastIndexOf("/"));
			}
			string assetpath = path + "/" + type.Name + ".asset";
			int i = 1;
			while(File.Exists(Application.dataPath + "/../" +  assetpath))
			{
				
				Debug.Log(i+" " + assetpath);
				assetpath = path + "/" + type.Name + "_" + i + ".asset";
				if(i > 2000) break;
				i++;
			}
			Debug.Log(assetpath);

			T t = ScriptableObject.CreateInstance<T>();
			AssetDatabase.CreateAsset(t, assetpath);
		}
		
//		[MenuItem("Assets/CC/CreateAsset/TestMyData")]
//		public static void CreateAsset_()
//		{
//			CreateAsset<MyData>();
//		}
	}
}
