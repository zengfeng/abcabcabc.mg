using UnityEngine;
using System;
using System.IO;
using System.Collections;
using CC.Module.Menu;
using CC.Module.DebugLog;
using CC.Runtime.Utils;
using CC.Runtime.PB;
using CC.Module.Loads;
using Games.Cores;
using Games.Module.Sound;
using Games.Manager;
using Games;
using Games.Module.Wars;
using Games.Module.Props;
using Games.conf;
using Games.Module.Sysmsgs;
using UnityEngine.UI;

namespace CC.Runtime
{
	public class Coo : MonoBehaviour 
	{
		private static int ID = 0;
		public static GameObject go;
		public static MonoBehaviour monoBehaviour;
		public static DebugLogManager debugLogManager;
		public static AssetManager assetManager;
		public static ConfigManager configManager;
		public static PacketManager packetManager;
		public static LoadManager loadManager;
		public static MenuManager menuManager;
		public static LuaScriptMgr luaManager;
        public static SoundManager soundManager;
		public static NativeCodeManager nativeManager;
        //public static PlotTalkManager plotTalkManager;
		public static CallUtil callUtil;
		public static HUDFPS fps;
        public static CrashReporter crashReporter;
		public static Camera	uiCamera;

        bool isQuitMsg = false;
		void Awake()
		{
			Debug.Log("Coo.Awake");
			if(Coo.ID > 0)
			{
				Destroy(base.gameObject);
				return;
			}

			ID ++;
			Coo.go = base.gameObject;
			Coo.monoBehaviour = this;
			
			GameObject cameraGO = GameObject.FindWithTag("UICamera");
			if(cameraGO != null)
			{
				uiCamera = cameraGO.GetComponent<Camera>();
			}

			debugLogManager = DebugLogManager.Instance;
			assetManager = AssetManager.Instance;
			configManager = ConfigManager.Instance;
			packetManager = PacketManager.Instance;
            soundManager = SoundManager.Instance;
			nativeManager = NativeCodeManager.Instance;
            //plotTalkManager = PlotTalkManager.Instance;
            callUtil = CallUtil.Instance;
            crashReporter = CrashReporter.Instance;
			luaManager = new LuaScriptMgr();
			loadManager = gameObject.AddComponent<LoadManager>();
			menuManager = gameObject.AddComponent<MenuManager>();
			fps = gameObject.AddComponent<HUDFPS>();
			fps.enabled = GameConst.VisiableFPS;

			ShakePhoneEvent shakePhoneEvent = GetComponent<ShakePhoneEvent>();
			if(shakePhoneEvent == null)
			{
				shakePhoneEvent = base.gameObject.AddComponent<ShakePhoneEvent>();
			}
			shakePhoneEvent.OnShake += OpenDebugLogPanel;

			GameObject.DontDestroyOnLoad(base.gameObject);
		}

		void OpenDebugLogPanel()
		{
//			menuManager.OpenMenu(MenuType.DebugLog);
		}

		void Update()
		{
			if(Input.GetKeyDown(KeyCode.F2))
			{
				OpenDebugLogPanel();
			}
            //if (Application.platform == RuntimePlatform.Android && (Input.GetKeyDown(KeyCode.Escape)))
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //Application.Quit();
                Debug.Log("================");
                if(isQuitMsg == false)
                {
                    isQuitMsg = true;
                    Coo.assetManager.Load("module/common/msgwindow", OnLoadMsgPanel);
                }
                
            }
        }

        void OnLoadMsgPanel(string filename, System.Object obj)
        {
            //Debug.Log("=============filename: " + filename);
            GameObject prefab = (GameObject)obj;
            GameObject msg = GameObject.Instantiate<GameObject>(prefab);
            msg.transform.SetParent(GameObject.Find("Canvas").transform);
            msg.transform.localScale = Vector3.one;
            msg.transform.localPosition = new Vector3(0, 0, -100);
            RectTransform rectTransform = (RectTransform)msg.transform;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;

            GameObject title = msg.transform.FindChild("Bg/SubTitle").gameObject;
            title.SetActive(false);

            Text textDes = msg.transform.FindChild("Bg/Desc/Text").GetComponent<Text>();
            textDes.text = "你确定要退出游戏吗？";

            Button btnClickNo = msg.transform.FindChild("Bg/YesNo/ButtonNo").GetComponent<Button>();
            btnClickNo.onClick.AddListener(delegate ()
            {
                isQuitMsg = false;
                Destroy(msg);
            });

            Button btnClickYes = msg.transform.FindChild("Bg/YesNo/ButtonYes").GetComponent<Button>();
            btnClickYes.onClick.AddListener(delegate ()
            {
                Application.Quit();
            });
        }


        public static void InitPreloadCall()
		{
			menuManager.AddPreloadCall(MenuType.WarScene, War.GetPreloadFiles, War.OnPreloadFile);

		}

		public static void InitConfig()
		{
			Debug.Log("<color=green>Coo.InitConfig</color>");
            PropConfig.Initialize(Coo.configManager.GetCustomConfig<PropConfigLoader>().propConfigs);

            Coo.configManager.GetConfig<int, ConstConfig>();
            Coo.configManager.GetConfig<int, MsgData>();
            Formula.LoadConfig();
            Goo.avatar.LoadConfig();
            War.model.LoadConfig();
            Coo.configManager.GetConfig<int, PlotWarStartConf>();
            Coo.configManager.GetConfig<string, PlotWarHeroConf>();
        }
	}
}
