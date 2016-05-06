using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Games;


public class PathUtil
{


	private static Dictionary<RuntimePlatform, string> _PlatformDirector;
	public static Dictionary<RuntimePlatform, string> PlatformDirector
	{
		get
		{
			if(_PlatformDirector == null)
			{
				_PlatformDirector = new Dictionary<RuntimePlatform, string>();
				_PlatformDirector.Add(RuntimePlatform.Android, "Android");
				_PlatformDirector.Add(RuntimePlatform.BlackBerryPlayer, "BlackBerry");
				_PlatformDirector.Add(RuntimePlatform.IPhonePlayer, "IOS");
				_PlatformDirector.Add(RuntimePlatform.PS3, "PS3");
				_PlatformDirector.Add(RuntimePlatform.PS4, "PS4");
				_PlatformDirector.Add(RuntimePlatform.OSXPlayer, "OSX");
				_PlatformDirector.Add(RuntimePlatform.OSXDashboardPlayer, "OSX");
				_PlatformDirector.Add(RuntimePlatform.OSXEditor, "OSX");
				_PlatformDirector.Add(RuntimePlatform.WindowsPlayer, "Windows");
				_PlatformDirector.Add(RuntimePlatform.WSAPlayerX86, "Windows");
				_PlatformDirector.Add(RuntimePlatform.WSAPlayerX64, "Windows");
				_PlatformDirector.Add(RuntimePlatform.WSAPlayerARM, "Windows");
				_PlatformDirector.Add(RuntimePlatform.WindowsEditor, "Windows");
				_PlatformDirector.Add(RuntimePlatform.WP8Player, "WP8");
			}
			return _PlatformDirector;
		}
	}

	
	
	public static string GetPlatformDirectoryName(RuntimePlatform platform, bool editor = false)
	{
		if(editor == false)
		{
			#if UNITY_STANDALONE_OSX
			platform = RuntimePlatform.OSXPlayer;
			#elif UNITY_STANDALONE_WIN
			platform = RuntimePlatform.WindowsPlayer;
			#elif UNITY_ANDROID
			platform = RuntimePlatform.Android;
			#elif UNITY_IOS || UNITY_IPHONE
			platform = RuntimePlatform.IPhonePlayer;
			#endif
		}
		
		string directory = "";
		PlatformDirector.TryGetValue(platform, out directory);
		return directory;
	}
	
	public static string GetPlatformDirectory(RuntimePlatform platform, bool editor = false)
	{
		return "Platform/" + GetPlatformDirectoryName(platform, editor);
	}


	public static void DeleteDirectory(string path)
	{
		if (Directory.Exists (path))
		{
			return;
		}

		string[] names = Directory.GetFiles(path);
		string[] dirs = Directory.GetDirectories(path);

		
		foreach (string dir in dirs) {
			DeleteDirectory(dir);
		}


		foreach (string filename in names) {
			File.Delete(filename);
		}

		
		Directory.Delete(path);
	}

	public static string GetDirectoryName(string path, int upCount = 0)
	{
		for(int i = 0; i < upCount; i ++)
		{
			path = Path.GetDirectoryName(path);
		}
		return Path.GetFileName(Path.GetDirectoryName(path));
	}



	public static void CheckPath(string path, bool isFile = true)
	{
		if(isFile) path = path.Substring(0, path.LastIndexOf('/'));
		string[] dirs = path.Split('/');
		string target = "";
		
		bool first = true;
		foreach(string dir in dirs)
		{
			if(first)
			{
				first = false;
				target += dir;
				continue;
			}
			
			if(string.IsNullOrEmpty(dir)) continue;
			target +="/"+ dir;
			if(!Directory.Exists(target))
			{
				Directory.CreateDirectory(target);
			}
		}
	}

	public static string ChangeExtension(string path, string ext)
	{
		string e = Path.GetExtension(path);
		if(string.IsNullOrEmpty(e))
		{
			return path + ext;
		}

		bool backDSC = path.IndexOf('\\') != -1;
		path = path.Replace('\\', '/');
		if(path.IndexOf('/') == -1)
		{
			return path.Substring(0, path.LastIndexOf('.')) + ext;
		}

		string dir = path.Substring(0, path.LastIndexOf('/'));
		string name = path.Substring(path.LastIndexOf('/'), path.Length - path.LastIndexOf('/'));
		name = name.Substring(0, name.LastIndexOf('.')) + ext;
		path = dir + name;

		if (backDSC)
		{
			path = path.Replace('/', '\\');
		}
		return path;
	}


	
	/// <summary>
	/// 计算字符串的MD5值
	/// </summary>
	public static string md5(string source) {
		MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
		byte[] data = System.Text.Encoding.UTF8.GetBytes(source);
		byte[] md5Data = md5.ComputeHash(data, 0, data.Length);
		md5.Clear();
		
		string destString = "";
		for (int i = 0; i < md5Data.Length; i++) {
			destString += System.Convert.ToString(md5Data[i], 16).PadLeft(2, '0');
		}
		destString = destString.PadLeft(32, '0');
		return destString;
	}
	
	/// <summary>
	/// 计算文件的MD5值
	/// </summary>
	public static string md5file(string file) {
		try {
			FileStream fs = new FileStream(file, FileMode.Open);
			System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
			byte[] retVal = md5.ComputeHash(fs);
			fs.Close();
			
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < retVal.Length; i++) {
				sb.Append(retVal[i].ToString("x2"));
			}
			return sb.ToString();
		} catch (Exception ex) {
			throw new Exception("md5file() fail, error:" + ex.Message);
		}
	}
	
	
	
	
	
	
	public static string AppDataPath
	{
		get
		{
//			return Application.streamingAssetsPath + "/" + GetPlatformDirectory(Application.platform) + "/";
			return Application.streamingAssetsPath + "/" ;
		}
	}

	public static string DataPath
	{
		get
		{
			if(Application.isEditor)
			{
				if(GameConst.DebugMode)
				{
					return AppDataPath;
				}
				else
				{
					return Application.dataPath + "/../res/";
				}
			}

			if(Application.isMobilePlatform || Application.isConsolePlatform)
			{
				return Application.persistentDataPath + "/" + GameConst.AppName + "/" ;
			}

			switch(Application.platform)
			{
			case RuntimePlatform.WindowsPlayer:
				return Application.dataPath + "/../assets/" ;
				break;
			case RuntimePlatform.OSXPlayer:
				return Application.dataPath + "/assets/" ;
				break;
			}
			
			return Application.persistentDataPath + "/" + GameConst.AppName + "/" ;
		}
	}

	public static string UserDataPath
	{
		get
		{
			if (string.IsNullOrEmpty (GameConst.UserId)) 
			{
				return DataPath +  "users/empty/";
			}
			else
			{
				return DataPath + "users/" + GameConst.UserId + "/";
			}
		}
	}

	public static string AppDataUrl
	{
		get
		{
			if (Application.platform == RuntimePlatform.Android) 
			{
				return PathUtil.AppDataPath;
			}
			else
			{
				return "file:///" + PathUtil.AppDataPath;
			}
		}
	}

	public static string DataUrl
	{
		get
		{
			return "file:///" + DataPath;
		}
	}

	public static string UserDataUrl
	{
		get 
		{
			return "file:///" + UserDataPath;
		}
	}



	private static string _ServerUrl;
	public static string ServerUrl
	{
		get
		{
			if(_ServerUrl == null)
			{
				_ServerUrl = GameConst.WebUrl;

//				if(PlayerPrefsUtil.HasKey("ServerUrl"))
//				{
//					_ServerUrl = PlayerPrefsUtil.GetString("ServerUrl");
//				}
//				else
//				{
////					_ServerUrl = GameConst.WebUrl + GetPlatformDirectory(Application.platform) + "/";
//					_ServerUrl = GameConst.WebUrl;
//				}
			}

			return _ServerUrl;
		}
	}

	public static string[] FindDirectory(string path)
	{
		return System.IO.Directory.GetFileSystemEntries(Application.dataPath + "/" + path);
	}
}
