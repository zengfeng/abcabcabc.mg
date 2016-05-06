using UnityEngine;
using System.Collections;
using System.IO;

namespace Games
{
	public class GameConstConfig 
	{
		
		public bool OfflineTest = false;					  //离线测试
		public bool CleanupDataPath = false;
		public bool DebugMode = true;                       //调试模式-用于内部测试
		public bool DevelopMode = true;					//开发模式

		
		public int TimerInterval = 1;
		public int GameFrameRate = 30;                       //游戏帧频
		public bool VisiableFPS = false;

		
		
		public bool UsePbc = true;                           //PBC
		public bool UseLpeg = true;                          //LPEG
		public bool UsePbLua = true;                         //Protobuff-lua-gen
		public bool UseCJson = true;                         //CJson
		public bool UseSproto = true;                        //Sproto
		public bool LuaEncode = false;                        //使用LUA编码

	
		public string AppName = "mbsg";           			//应用程序名称
		public string AppPrefix = "mbsg_";             //应用程序前缀
		public string ExtName = ".assetbundle";              //素材扩展名

		public string 	WebUrl = "http://112.126.75.68/client/StreamingAssets/";  	//更新地址
		public int 		SocketPort = 0;                           					//Socket服务器端口
		public string 	SocketAddress = string.Empty;          						//Socket服务器地址

		public string 	Host_Upload_Release = "http://www.qqpard.com";     //上传地址--战斗视频--发布模式
		public string 	Host_Upload_Develop = "http://www.qqpard.com";     //上传地址--战斗视频--开发模式


		public string 	GameConstFileName = "game_const.json";		//game_const.json 配置文件
		public string	ServerFileName = "Server.txt";				//
		public string	VersionFileName = "VERSION.txt";			//服务器版本号文件
		public string	AssetlistNameForStreaming = "files.csv";	//资源列表
		public string	AssetlistNameForResource = "files";			//资源列表

        public int ResolutionProgressive = 720;
		public float NetWorkTimeOut = 999.0f;

		public string 	Version = "0.0.0";									//游戏版本号

		public string CenterName = "NoCenter"; 				//平台名字

		public void Set()
		{

			GameConst.OfflineTest = OfflineTest;
			GameConst.CleanupDataPath = CleanupDataPath;
			GameConst.DebugMode = DebugMode;
			GameConst.DevelopMode = DevelopMode;

			GameConst.TimerInterval = TimerInterval;
			GameConst.GameFrameRate = GameFrameRate;
			GameConst.VisiableFPS = VisiableFPS;

			
			GameConst.UsePbc = UsePbc;
			GameConst.UseLpeg = UseLpeg;
			GameConst.UsePbLua = UsePbLua;
			GameConst.UseCJson = UseCJson;
			GameConst.UseSproto = UseSproto;
			GameConst.LuaEncode = LuaEncode;

			
			GameConst.AppName = AppName;
			GameConst.AppPrefix = AppPrefix;
			GameConst.ExtName = ExtName;

			
			GameConst.WebUrl = WebUrl;
			GameConst.SocketPort = SocketPort;
			GameConst.SocketAddress = SocketAddress;


			GameConst.Host_Upload_Release = Host_Upload_Release;
			GameConst.Host_Upload_Develop = Host_Upload_Develop;

			GameConst.GameConstFileName = GameConstFileName;
			GameConst.ServerFileName = ServerFileName;
			GameConst.VersionFileName = VersionFileName;
			GameConst.AssetlistNameForStreaming = AssetlistNameForStreaming;
			GameConst.AssetlistNameForResource = AssetlistNameForResource;

            GameConst.ResolutionProgressive = ResolutionProgressive;
			GameConst.NetWorkTimeOut = NetWorkTimeOut;
			GameConst.CenterName = CenterName;
		}


	}
}