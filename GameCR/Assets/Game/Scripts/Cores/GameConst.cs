using UnityEngine;
using System.Collections;
using System.IO;

namespace Games
{
	public class GameConst 
	{
		public static bool WarDevelopMode = false;					  //测试战斗模式
		public static bool OfflineTest = false;					  //离线测试
		public static bool CleanupDataPath = false;
		public static bool DebugMode = true;                       //调试模式-用于内部测试
		public static bool DevelopMode = true;					//开发模式

		
		public static int TimerInterval = 1;
		public static int GameFrameRate = 30;                       //游戏帧频
		public static bool VisiableFPS = true;

		
		
		public static bool UsePbc = true;                           //PBC
		public static bool UseLpeg = true;                          //LPEG
		public static bool UsePbLua = true;                         //Protobuff-lua-gen
		public static bool UseCJson = true;                         //CJson
		public static bool UseSproto = true;                        //Sproto
		public static bool LuaEncode = false;                        //使用LUA编码

		public static string UserId = string.Empty;                 //玩家ID
		public static string AppName = "crsg";           			//应用程序名称
		public static string AppPrefix = AppName + "_";             //应用程序前缀
		public static string ExtName = ".assetbundle";              //素材扩展名
		public static string AssetDirname = "StreamingAssets";      //素材目录 
		public static string BytesExt = ".txt";

		public static string 	WebUrl = "http://112.126.75.68/client/StreamingAssets/";  	//更新地址
		public static int 		SocketPort = 0;                           					//Socket服务器端口
		public static string 	SocketAddress = string.Empty;

		public static string 	Host_Upload_Release = "http://www.qqpard.com";     //上传地址--战斗视频--发布模式
		public static string 	Host_Upload_Develop = "http://www.qqpard.com";     //上传地址--战斗视频--开发模式
		public static string 	Host_Upload
		{
			get
			{
				return GameConst.DevelopMode ? Host_Upload_Develop : Host_Upload_Release;
			}
		}


		public static string LuaBytesRoot = "Assets/Game/LuaBytes/";
		
		public static string SourcePath = "/ulualib/Source/";
		public static string LuaWrapPath = "/ulualib/Source/LuaWrap/";
		public static string LuaBinderPath = "/ulualib/Source/Base/LuaBinder.cs";
		public static string DelegateFactoryPath = "/ulualib/Source/Base/DelegateFactory.cs";

		public static string 	GameConstFileName = "game_const.json";		//game_const.json 配置文件
		internal static string	ServerFileName = "Server.txt";				//
		internal static string	VersionFileName = "VERSION.txt";			//服务器版本号文件
		internal static string	AssetlistNameForStreaming = "files.csv";	//资源列表
		public static string	AssetlistNameForResource = "files";			//资源列表
		
		public static string	Platform_ServerFileName { get{ return PathUtil.GetPlatformDirectory(Application.platform) + "/" + ServerFileName;}}						//
		public static string	Platform_VersionFileName { get{ return PathUtil.GetPlatformDirectory(Application.platform)  + "/" + VersionFileName;}}						//服务器版本号文件
		public static string	Platform_AssetlistNameForStreaming { get{ return PathUtil.GetPlatformDirectory(Application.platform) + "/"  + AssetlistNameForStreaming;}}	//资源列表

        public static int ResolutionProgressive; //分辨率逐行值
		public static float NetWorkTimeOut = 7.0f; //网络超时时间

		public static string CenterName = "NoCenter";

		private static string 	instanceVersion = "0.0.1a";					//游戏安装版本号
		private static string 	_Version;									//游戏版本号
		private static string 	_AppVersion;								//游戏版本号

		public static string AppVersion
		{
			get
			{
				if(string.IsNullOrEmpty(_AppVersion))
				{
					string file = PathUtil.AppDataPath + Platform_VersionFileName;
					bool readFile = File.Exists(file);

					string version = instanceVersion;
					if(readFile)
					{
						StreamReader sr = new StreamReader(file);
						string line = sr.ReadLine();
						version = line.Split(';')[0];
						instanceVersion = version;
						sr.Close();
					}
					else
					{
						Debug.Log(string.Format("GameConst.AppVersion file no exists  file={0}", file));
					}
					Debug.Log("GameConst.AppVersion=" + version + "  file=" + file);
					_AppVersion = version;
				}
				return _AppVersion;
			}

			set
			{
				_AppVersion = value;
			}
		}

		public static string Version
		{
			get
			{
				if(string.IsNullOrEmpty(_Version))
				{
					string file = PathUtil.DataPath + Platform_VersionFileName;
					bool readFile = File.Exists(file);
					if(!readFile)
					{
						file = PathUtil.AppDataPath + Platform_VersionFileName;
						readFile = File.Exists(file);
					}

					if(readFile)
					{
						StreamReader sr = new StreamReader(file);
						string line = sr.ReadLine();
						_Version = line.Split(';')[0];
						sr.Close();
					}
					else
					{
						_Version = instanceVersion;
					}
				}

				Debug.Log("GameConst.Version=" + _Version);
				return _Version;
			}

			set
			{
				_Version = value;
			}
		}

		private static int _ServerID = -1;
		public static int ServerID
		{
			get
			{
				if(_ServerID < 0)
				{
					if(PlayerPrefsUtil.HasKey("ServerID"))
					{
						_ServerID = PlayerPrefsUtil.GetInt("ServerID");
					}
				}
				return _ServerID;
			}

			set
			{
				_ServerID = value;
				if(_ServerID > 0)
				{
					PlayerPrefsUtil.SetInt("ServerID", _ServerID);
				}
			}
		}
	}
}