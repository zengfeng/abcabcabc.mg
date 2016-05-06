using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Games.Enters
{
	public class EnterPanel : MonoBehaviour 
	{
		public Action OnVersionFinal;
		public Action OnFinal;

		public enum PanelName
		{
			LoadBar,
			DownVersionPanel,
			LoginPanel,
			ServerListPanel,
			None
		}

		public LoadBar loadBar;
		public DownVersionPanel downVersionPanel;
		public LoginPanel loginPanel;
		public ServerListPanel serverListPanel;
		public GameObject skipButton;
		private GameObject[] panels;
		private bool isSkipServerVersion = false;
		private Coroutine serverVersionCoroutiner;

		void Awake()
		{
			panels = new GameObject[]{
				loadBar.gameObject,
				downVersionPanel.gameObject,
//				loginPanel.gameObject,
//				serverListPanel.gameObject
			};

			OpenPanel(PanelName.None);
		}

		public void OpenPanel(PanelName panelName)
		{
			for(int i = 0; i < panels.Length; i ++)
			{
				panels[i].SetActive(false);
			}

			if(panelName != PanelName.None) panels[(int)panelName].SetActive(true);
		}

		
		/** 开始运行 */
		public void Run()
		{
			StartCoroutine(ReadConst(false));
		}
		
		/** 读取配置  */
		IEnumerator ReadConst(bool final)
		{
			string url = "";
			
			string file = PathUtil.DataPath + GameConst.GameConstFileName;
//			if(Application.isEditor)
//			{
//				file = Application.dataPath + "/../res/" + GameConst.GameConstFileName;
//			}

			Debug.Log("File.Exists("+file+")=" + File.Exists(file));
			if(File.Exists(file))
			{
				url = PathUtil.DataUrl + GameConst.GameConstFileName;
			}
			else
			{
				url = PathUtil.AppDataUrl + GameConst.GameConstFileName;
			}
			
			WWW www = new WWW(url);
			yield return www;

			if(string.IsNullOrEmpty(www.error))
			{
				Debug.Log(url);
				Debug.Log(www.text);
				GameConstConfig obj = JsonConvert.DeserializeObject(www.text, typeof(GameConstConfig)) as GameConstConfig;
				obj.Set();
			}
			else
			{
				
				Debug.Log(string.Format("<color=red>[EnterPanel.ReadConst] 读取game_const.json失败 url={0} error={1}  text={2}</color>", url, www.error, www.text));
			}

			www.Dispose();
			www = null;

			if(final)
			{
				VersionFinal();
			}
			else
			{
				CheckConst();
			}
		}


		/** 检查配置  */
		public void CheckConst()
		{
			//if(Application.isEditor)
			//{
			//	if(GameConst.DebugMode)
			//	{
			//		VersionFinal();
			//		return;
			//	}
			//}
			
			if(GameConst.CleanupDataPath)
			{
				PathUtil.DeleteDirectory(PathUtil.DataPath);
			}

			
			//获取版本号
			StartCoroutine(GetAppVersion());
			
		}



		
		private byte[] nowVersionBytes;
		private string nowVersion;
		private string nowUrl;

		
		/** 获取版本号 */
		IEnumerator GetAppVersion()
		{
			OpenPanel(PanelName.LoadBar);
			loadBar.State = "检测版本";
			loadBar.showFileBar = false;

			string file = PathUtil.AppDataUrl + GameConst.Platform_VersionFileName;
		
			
			loadBar.SetProgress(0f/3f, file);
			
			WWW www = new WWW(file);
			yield return www;

			
			string versionInfoStr = www.text.Split('\n')[0];
			string[] versionInfo = versionInfoStr.Split(';');
			GameConst.AppVersion = versionInfo[0];
			www.Dispose();
			www = null;


			
			file = PathUtil.DataPath + GameConst.Platform_VersionFileName;
			if(File.Exists(file))
			{
				StreamReader sr = new StreamReader(file);
				string line = sr.ReadLine();
				versionInfo = line.Split(';');
				GameConst.Version = versionInfo[0];
				sr.Close();
			}
			else
			{
				GameConst.Version = GameConst.AppVersion;
			}
			
			loadBar.SetProgress(2f/3f, file);

			
			//获取版本号
			serverVersionCoroutiner = StartCoroutine(GetServerVersion());
		}

		void UpdateVersion()
		{
			string file = PathUtil.DataPath + GameConst.Platform_VersionFileName;
			if(File.Exists(file))
			{
				StreamReader sr = new StreamReader(file);
				string line = sr.ReadLine();
				string[] versionInfo = line.Split(';');
				GameConst.Version = versionInfo[0];
				sr.Close();
			}
		}

		/** 获取服务器版本号 */
		IEnumerator GetServerVersion()
		{
			nowVersion = null;
			SkipButtonVisiable = false;
			
			SkipServerVersion ();
			yield break;

			string random = DateTime.Now.ToString("yyyymmddhhmmss");
			string file = PathUtil.ServerUrl + GameConst.Platform_VersionFileName + "?v=" + random;
			WWW www = new WWW(file);
			yield return www;
			if(isSkipServerVersion)
			{
				www.Dispose();
				www = null;
				yield break;
			}
			
			
			OpenPanel(PanelName.None);
			
			if(!string.IsNullOrEmpty(www.error))
			{
				Debug.Log(string.Format("<color={0}>{1}</color>", "red", "[Error] 获取版本号" + file + "\n" + www.error));
				
				
				www.Dispose();
				www = null;
				CheckInitRecource();
				yield break;
			}
			
			loadBar.SetProgress(3f/3f, file);
			nowVersionBytes = www.bytes;
			string versionInfoStr = www.text.Split('\n')[0];
			string[] nowVersionInfo = versionInfoStr.Split(';');
			nowVersion = nowVersionInfo[0];
			nowUrl =  nowVersionInfo[1];
			
			Debug.Log("Server nowVersion=" + nowVersion);
			Debug.Log("Server versionInfoStr=" + versionInfoStr);
			
			www.Dispose();
			www = null;

			
			OpenPanel(PanelName.None);
			CheckInstanceVersion(nowVersion, nowUrl);
			SkipButtonVisiable = false;
			
		}

		public bool SkipButtonVisiable
		{
			set
			{
//				skipButton.SetActive(value);
			}

			get
			{
				return skipButton.activeSelf;
			}
		}

		public void SkipServerVersion()
		{
			SkipButtonVisiable = false;
			isSkipServerVersion = true;
			if(serverVersionCoroutiner != null) StopCoroutine(serverVersionCoroutiner);

			
			OpenPanel(PanelName.None);
			CheckInitRecource();
		}
		
		/** 检查版本号 */
		void CheckInstanceVersion(string nowVersion, string nowUrl)
		{
			
			string[] nowVersions = nowVersion.Split('.');
			string[] appVersions = GameConst.AppVersion.Split('.');
			string[] versions = GameConst.Version.Split('.');
			if(nowVersions[0] == appVersions[0] && nowVersions[0] != versions[0])
			{
				PathUtil.DeleteDirectory(PathUtil.DataPath);
			}
			
			CheckInitRecource();
		}

		
		/** 检测是否初始化 */
		void CheckInitRecource() 
		{
			
			bool isExist = Directory.Exists(PathUtil.DataPath);
			if(isExist) isExist = File.Exists(PathUtil.DataPath + GameConst.Platform_AssetlistNameForStreaming);
			if(!isExist)
			{
				StartCoroutine(CopyAppData());    		//初始化资源 
			}
			else
			{
				CheckVersion(); 						//检测版本
			}
		}
		
		/** 初始化资源,复制游戏自带资源到数据目录 */
		IEnumerator CopyAppData() 
		{
			string dataPath = PathUtil.DataPath;  //数据目录
			string resPath = PathUtil.AppDataPath; //游戏包资源目录
			
			if (Directory.Exists(dataPath)) PathUtil.DeleteDirectory(dataPath);
			Directory.CreateDirectory(dataPath);
			
			string infile = resPath + GameConst.Platform_AssetlistNameForStreaming;
			string outfile = dataPath + GameConst.Platform_AssetlistNameForStreaming;
			if (File.Exists(outfile)) File.Delete(outfile);

			OpenPanel(PanelName.LoadBar);
			loadBar.State = "正在解包文件";
			loadBar.totalProgress = 0;
			loadBar.showFileBar = false;
			
			loadBar.File = GameConst.Platform_AssetlistNameForStreaming;
			Debug.Log(infile);
			Debug.Log(outfile);
			PathUtil.CheckPath(outfile);
			if (Application.platform == RuntimePlatform.Android) 
			{
				WWW www = new WWW(infile);
				yield return www;
				
				if(!string.IsNullOrEmpty(www.error))
				{
					//释放完成，开始启动更新资源
					serverVersionCoroutiner = StartCoroutine(GetServerVersion());
					yield break;
				}
				
				if (www.isDone) {
					File.WriteAllBytes(outfile, www.bytes);
				}
				yield return 0;
			} 
			else
			{
				if (!File.Exists(infile))
				{
					//释放完成，开始启动更新资源
					serverVersionCoroutiner = StartCoroutine(GetServerVersion());
					yield break;
				}
				File.Copy(infile, outfile, true);
			}
			yield return new WaitForEndOfFrame();
			
			//释放所有文件到数据目录
			string[] files = File.ReadAllLines(outfile);
			float i = 0;
			float count = files.Length;
			foreach (string f in files) {
				string file = f.Split(';')[0];
				if(i == 0 && file=="URL")
				{
					i++;
					continue;
				}

				if(GameConst.DevelopMode == false)
				{
					if(file.IndexOf("Config/") == 0)
					{
						continue;
					}
				}

				file = string.Format(file, PathUtil.GetPlatformDirectory(Application.platform));
				infile = resPath + file;  //
				outfile = dataPath + file;
				//				Debug.Log("正在解包文件:>" + infile);
				
				i++;
				loadBar.File = file;
				loadBar.totalProgress = i / count;
				
				PathUtil.CheckPath(outfile);
				
				
				
				if (Application.platform == RuntimePlatform.Android) {
					WWW www = new WWW(infile);
					yield return www;
					
					if (www.isDone) {
						File.WriteAllBytes(outfile, www.bytes);
					}

					www.Dispose();
					www = null;
					yield return 0;
				} else File.Copy(infile, outfile, true);
				yield return new WaitForEndOfFrame();
			}
			
			loadBar.totalProgress = 1;
			loadBar.State = "解包完成!!!";
			yield return new WaitForSeconds(0.1f);

			
			UpdateVersion();
			//检查版本号
			CheckVersion();
		}


		
		/** 检查版本号 */
		void CheckVersion()
		{

			if(string.IsNullOrEmpty(nowVersion) ||  nowVersion == GameConst.Version)
			{
				VersionFinal();
			}
			else
			{
				string[] nowVersions = nowVersion.Split('.');
				string[] versions = GameConst.Version.Split('.');
				if(nowVersions[0] != versions[0])
				{
					downVersionPanel.currentVersion = GameConst.Version;
					downVersionPanel.nowVersion = nowVersion;
					downVersionPanel.url = nowUrl;
					OpenPanel(PanelName.DownVersionPanel);
				}
				else
				{
					//更新服务器资源
					StartCoroutine(UpdateResource());
				}
			}
		}
		
		/** 更新服务器资源 */
		IEnumerator UpdateResource()
		{
			OpenPanel(PanelName.LoadBar);
			loadBar.State = "更新服务器资源";
			loadBar.showFileBar = false;
			loadBar.totalProgress = 0;
			string random = DateTime.Now.ToString("yyyymmddhhmmss");
			
			string dataPath = PathUtil.DataPath;  //数据目录
			string url = PathUtil.ServerUrl;
			
			string filesUrl = url + GameConst.Platform_AssetlistNameForStreaming + "?v=" +random;
			WWW www = new WWW(filesUrl);
			yield return www;
			
			if(!string.IsNullOrEmpty(www.error))
			{
				Debug.Log(string.Format("<color={0}>{1}</color>", "red", "[Error] 更新服务器资源" + filesUrl + "\n" + www.error));

				www.Dispose();
				www = null;
				VersionFinal();
				yield break;
			}
			
			
			PathUtil.CheckPath(dataPath, false);
			File.WriteAllBytes(dataPath + GameConst.Platform_AssetlistNameForStreaming, www.bytes);
			
			string filesText = www.text;
			string[] files = filesText.Split('\n');
			www.Dispose();
			www = null;
			
			List<string[]> fileList = new List<string[]>();
			
			for (int i = 0; i < files.Length; i++) 
			{
				if (string.IsNullOrEmpty(files[i])) continue;
				string[] keyValue = files[i].Split(';');

				//				string f = keyValue[0].Remove(0, 1);
				string f = keyValue[0];
				
				f = string.Format(f, PathUtil.GetPlatformDirectory(Application.platform));
				string localfile = (dataPath + f).Trim();

				
				if(i == 0 && f=="URL") continue;
				if(f == GameConst.Platform_VersionFileName) continue;

				if(GameConst.DevelopMode == false)
				{
					if(f.IndexOf("Config/") == 0)
					{
						continue;
					}
				}



				bool canUpdate = !File.Exists(localfile);
				if (!canUpdate) {
					string remoteMd5 = keyValue[1].Trim();
					string localMd5 = PathUtil.md5file(localfile);
					canUpdate = !remoteMd5.Equals(localMd5);
					if (canUpdate) File.Delete(localfile);
				}

				if (canUpdate) {   //本地缺少文件
					fileList.Add(keyValue);
				}
			}

			int count = fileList.Count;
			for(int i = 0; i < count; i ++)
			{
				string[] keyValue = fileList[i];
				string f = keyValue[0];
				f = string.Format(f, PathUtil.GetPlatformDirectory(Application.platform));
				string localfile = (dataPath + f).Trim();
				string fileUrl = url + f + "?v=" + random;
				loadBar.File = f;
				loadBar.totalProgress = (float)(i + 1) / (float)count;

				www = new WWW(fileUrl); 

				yield return www;
				if (www.error != null) 
				{
					OnUpdateFailed(fileUrl);

					www.Dispose();
					www = null;
					continue;
				}

				PathUtil.CheckPath(localfile, true);
				File.WriteAllBytes(localfile, www.bytes);

				www.Dispose();
				www = null;
			}


			string versionFile = dataPath + GameConst.Platform_VersionFileName;
			PathUtil.CheckPath(versionFile, true);
			File.WriteAllBytes(versionFile, nowVersionBytes);
			nowVersionBytes = null;
			
			yield return new WaitForEndOfFrame();
			loadBar.State = "更新完成!!";
			loadBar.totalProgress = 1;
			
			StartCoroutine(ReadConst(true));
		}

		
		/** 更新失败文件 */
		void OnUpdateFailed(string url)
		{
			Debug.Log(string.Format("<color={0}>{1}</color>", "red", "[Error] 更新服务器资源" + url));
		}


		void VersionFinal()
		{
			OpenPanel(PanelName.None);
			if(OnVersionFinal != null) OnVersionFinal();

		}

		/** 打开登陆面板 */
		public void ShowLoginPanel()
		{
			OpenPanel(PanelName.LoginPanel);
			loginPanel.OnLogin += ShowServerPanel;
		}

		
		/** 打开服务器选择面板 */
		void ShowServerPanel()
		{
			loginPanel.OnLogin -= ShowServerPanel;
			OpenPanel(PanelName.ServerListPanel);
			serverListPanel.OnSelect += LoadResource;
		}

		
		/** 加载资源 */
		void LoadResource()
		{
			
			serverListPanel.OnSelect -= LoadResource;

			OpenPanel(PanelName.LoadBar);
			loadBar.State = "加载资源";
			loadBar.showFileBar = false;
			loadBar.totalProgress = 0;

			Final();
		}

		
		/** 初始化游戏 */
		void Final()
		{
			OpenPanel(PanelName.None);
			if(OnFinal != null) OnFinal();
		}

	}
}