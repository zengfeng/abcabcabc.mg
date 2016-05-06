using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEditor;

namespace Game.Editors
{
	public class FilesGeneratorForResources 
	{
		
		[MenuItem("CC/生成files.csv(Resources)", false,40)]
		public static void Generator()
		{

			List<string> list = new List<string>();
			FindFolder(list, Application.dataPath);
			if(list.Count == 0) return;

			string filesPath = null;
			foreach(string file in list)
			{
				if(file.IndexOf("Assets/Game/Resources") != -1 || file.IndexOf("Assets\\Game\\Resources") != -1)
				{
					filesPath = file;
				}
			}

			if(string.IsNullOrEmpty(filesPath)) filesPath = list[0];

			if(Application.platform == RuntimePlatform.WindowsEditor)
			{
				filesPath += "\\files.csv";
			}
			else
			{
				filesPath += "/files.csv";
			}

			if (File.Exists(filesPath))
			{
				File.Delete(filesPath);
			}

			
			FileStream fs = new FileStream(filesPath, FileMode.CreateNew);
			StreamWriter sw = new StreamWriter(fs);
			foreach(string path in list)
			{
				List<string> fileList = new List<string>();
				Recursive(fileList, path, false, path + "/", "");

				for (int i = 0; i < fileList.Count; i++) 
				{
					string file = fileList[i];
					string ext = Path.GetExtension(file);
					if (ext.Equals(".meta")) continue;
					string filename = Path.GetFileName(file);
					if(filename.Equals(".DS_Store")) continue;
					if(filename.Equals("files.csv")) continue;
//					if(filename.Equals("VERSION.txt")) continue;
					
					string md5 = PathUtil.md5file(file);
					string mypath = path.Replace("\\", "/");
					string value = file.Replace(mypath + "/" , string.Empty);

					if(!string.IsNullOrEmpty(ext)) value = value.Replace(ext, string.Empty);
					value += ";" + md5;
					
					sw.WriteLine(value);
				}

			}

			sw.Close(); fs.Close();
			AssetDatabase.Refresh();
			Debug.Log("[FilesGeneratorForResources]" + filesPath);

		}


		public static void FindFolder(List<string> list, string path, string folderName="Resources", bool stopChild = true)
		{

			DirectoryInfo dir = new DirectoryInfo(path);
			if(dir.Name.Equals(folderName))
			{
				list.Add(dir.FullName);
				if(stopChild) return;
			}

			string[] dirs = Directory.GetDirectories(path);
			foreach(string item in dirs)
			{
				FindFolder(list, item, folderName, stopChild);
			}
		}


		
		/// <summary>
		/// 遍历目录及其子目录
		/// </summary>
		static void Recursive(List<string> fileList, string path, bool replaceRoot=false, string root="", string replace="") {
			string[] names = Directory.GetFiles(path);
			string[] dirs = Directory.GetDirectories(path);
			foreach (string filename in names) {
				string ext = Path.GetExtension(filename);
				if (ext.Equals(".meta")) continue;
				
				
				string fn = Path.GetFileName(filename);
				if(fn.Equals(".DS_Store")) continue;
				if(fn.IndexOf(".") == 0) continue;

				string filepath = filename;
				if(replaceRoot)
				{
					filepath = filepath.Replace(root, replace);
				}
				
				fileList.Add(filepath.Replace('\\', '/'));
			}
			foreach (string dir in dirs) {
				//paths.Add(dir.Replace('\\', '/'));
				
				string dirName = Path.GetFileName(dir);
				if(dirName.IndexOf(".") == 0) continue;
				Recursive(fileList, dir, replaceRoot, root, replace);
			}
		}





	}
}