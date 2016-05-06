using UnityEngine;
using System.Collections;
using System.IO;
using Games.Enters;
using System;
using CC.Runtime;
using SimpleFramework;
using Games.Module.Wars;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;


namespace Games
{
	public class GameManager : MonoBehaviour 
	{
		public EnterPanel enterPanel;
		void Awake () 
		{
            if (Application.platform == RuntimePlatform.Android)
            {
                //			Screen.SetResolution(Screen.resolutions[0].width, Screen.resolutions[0].height, true, Screen.resolutions[0].refreshRate);
                float ratio = Screen.width / (float)Screen.height;
                Screen.SetResolution((int)(GameConst.ResolutionProgressive * ratio), (int)(GameConst.ResolutionProgressive), true, 60);
            }

            GameObject enterPanelGO = GameObject.Find("EnterPanel");
			if(enterPanelGO != null) enterPanel = enterPanelGO.GetComponent<EnterPanel>();
			CheckVersion();
		}

		/** 妫娴嬬増鏈?*/
		void CheckVersion()
		{
			if(enterPanel != null)
			{
				enterPanel.OnVersionFinal += InitOO;
				enterPanel.Run();
			}
			else
			{
				InitOO();
			}
		}

		/** 鍒濆?鍖朞O */
		void InitOO()
		{

			if(enterPanel != null) enterPanel.OnVersionFinal -= InitOO;
			gameObject.AddComponent<Coo>();

			if(Coo.assetManager.isPrepare)
			{
				InitLoad();
			}
			else
			{
				Coo.assetManager.prepareFinal.AddOnce(InitLoad);
				Coo.assetManager.Init();
			}
		}

		
		/** 鍒濆?鍖朙oaderManager*/
		void InitLoad()
		{
			Coo.assetManager.prepareFinal.RemoveOnce(InitLoad);

			if(Coo.loadManager.isPrepare)
			{
				InitLua();
			}
			else
			{
				Coo.loadManager.prepareFinal += InitLua;
				Coo.loadManager.Init();
			}

		}


		private byte[] DecryptBytes(byte[] data, string sKey = null)  
		{  
			if(sKey == null) sKey = "zengfeng";

			DESCryptoServiceProvider DES = new DESCryptoServiceProvider();  
			DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);  
			DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);  
			ICryptoTransform desencrypt = DES.CreateDecryptor();
			byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);  
			return result;  
		}

		/** 鍒濆?鍖朙ua */
		void InitLua()
		{
			Coo.loadManager.prepareFinal -= InitLua;

			if(GameConst.DevelopMode == false)
			{
				InitLuaCode();
			}
			else
			{
				StartLua();
			}
		}
		
		/** 鍒濆?鍖朙ua浠ｇ爜 */
		void InitLuaCode()
		{
			StartCoroutine(OnInitLuaCode());
		}
		
		AssetBundleCreateRequest LoadFromMemoryAsync(byte[] bytes)
		{
			#if UNITY_5_2
			return AssetBundle.CreateFromMemory(bytes);
			#else
			return AssetBundle.LoadFromMemoryAsync (bytes);
			#endif
		}

		IEnumerator OnInitLuaCode()
		{
			
			string path = "{0}/luacode.assetbundle";
			path = string.Format(path, PathUtil.GetPlatformDirectory(Application.platform));
			path = PathUtil.DataPath + path;
			
			byte[] bytes = File.ReadAllBytes(path);
			bytes = DecryptBytes(bytes);

			AssetBundleCreateRequest assetBundleCreateRequest = LoadFromMemoryAsync (bytes);
			yield return assetBundleCreateRequest;
			AssetBundle assetBundle = assetBundleCreateRequest.assetBundle;
			Coo.luaManager.luaFileAB = assetBundle;


//			string[] assetNames = assetBundle.GetAllAssetNames();
//			for(int i = 0; i < assetNames.Length; i ++)
//			{
//				Debug.LogFormat("{0}\t{1}", i, assetNames[i]);
//			}


			StartCoroutine(OnInitConfig());
		}

		IEnumerator OnInitConfig()
		{
			string path = "{0}/config.assetbundle";
			path = string.Format(path, PathUtil.GetPlatformDirectory(Application.platform));
			path = PathUtil.DataPath + path;
			
			byte[] bytes = File.ReadAllBytes(path);
			bytes = DecryptBytes(bytes);

			AssetBundleCreateRequest assetBundleCreateRequest = LoadFromMemoryAsync (bytes);
			yield return assetBundleCreateRequest;
			AssetBundle assetBundle = assetBundleCreateRequest.assetBundle;
			Coo.assetManager.configFileAB = assetBundle;
			
			StartLua();
		}
		
		/** 鍒濆?鍖朙ua */
		void StartLua()
		{
			Coo.luaManager.Start();
			gameObject.AddComponent<LuaMB>();

			if(GameScene.IsWar())
			{
				GameConst.WarDevelopMode = true;
				GameConst.OfflineTest = true;

				//Coo.luaManager.DoFile("logic/Core/GameManager.lua");
				gameObject.AddComponent<TestWarManager>();
			}
			else
			{
				Coo.luaManager.DoFile("logic/Core/GameManager.lua");
				Util.CallMethod("GameManager", "SetLoadBar", enterPanel.loadBar);
			}
		}



		/** 閫鍑惯*/
		void Exit()
		{
			if (War.isTest == false)
			{
				Util.CallMethod ("GameManager", "Exit");
			}
		}

		void OnDestroy()
		{
			Exit();
		}
	}
}