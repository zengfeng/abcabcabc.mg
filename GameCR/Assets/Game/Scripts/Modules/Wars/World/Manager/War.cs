using UnityEngine;
using System.Collections;
using CC.Runtime;
using System.Collections.Generic;
using CC.Module.LoadScenes;
using Games.Cores;
using CC.Runtime.Utils;
using CC.Runtime.signals;
using CC.Module.Menu;
using CC.Runtime.PB;
using System;
using Games.Manager;
using SimpleFramework;
using System.IO;
using ProtoBuf;


namespace Games.Module.Wars
{
	/** 战斗对外接口 （战斗门面） */
	public class War
	{
		/** 战斗版本号 */
		public static int version = 3001;
		/** 版本是否兼容 */
		public static bool GetVersionCompatible(int v)
		{
			return version / 1000 == v / 1000;
		}
		
		/** 是否是测试模式 */
		public 	static bool 		isTest = false;
		/** 是否是编辑器模式 */
		public 	static bool 		isEditor = false;
		
		#region 属性
		/** 观看录像玩家ID */
		public static int watchRoleId = 0;
		/** 是否是录像 */
		public static bool isRecord = false;
		/** 对战模式 */
		public static VSMode vsmode = VSMode.Dungeon;
		/** 战斗流程状态 */
		public static WarProcessState processState = WarProcessState.Exit;
		/** 是否游戏进行中 */
		public static bool isGameing {get {return War.processState == WarProcessState.Gameing;}}

		/** 是否需要同步加载 */
		public static bool requireSynch {get { return War.vsmode == VSMode.PVP && War.isRecord == false; } }
		/** 是否需要引导 */
		public static bool requireGuide {get { return War.isRecord == false && War.isEditor == false; } }
		
		/** 发兵数量比例 */
		public static float sendArmRate 		= 1;
		/** 战斗限制时间 */
		public static bool timeLimit 			= true;
		/** 战斗限制时间 */
		public static float timeMax 			= 120f;
		/** 战斗已过时间 */
		public static float time 				= 0;

		/** PVP时主机势力ID */
		public static int mainLegionID = 1;
		/** 自己势力ID */
		public static int ownLegionID = 1;
		/** 是否自动关闭加载面板 */
		public static bool isAutoCloseLoad = false;
		/** 战局类型 */
		public static OverType overType = OverType.Draw;
		public static bool isOverTime = false;
		/** 是否胜利 */
		public static bool isWin {get {return War.overType == OverType.Win;}}
		/** 是否是主机 */
		public static bool isMainLegion {get {return War.mainLegionID == War.ownLegionID;}}
		
		// 生成--真人的数量
		public static int realPlayerCount = 0;
		/** 是否需要发同步数据 */
		public static bool isSendSynchrService
		{
			get
			{
				if(War.requireSynch)
				{
//					if(War.realPlayerCount <= 1)
//					{
//						return false;
//					}

					return true;
				}

				return false;
			}
		}
		
		#endregion







		public static bool IsSendService(int legionId)
		{
			LegionData legionData = War.GetLegionData (legionId);
			return War.IsSendService (legionData);
		}


		public static bool IsSendService(LegionData legionData)
		{
			return War.IsSendService (legionData.legionId, legionData.type);
		}


		public static bool IsSendService(int legionId, LegionType legionType)
		{

			bool isSend = true;
			if(legionId != War.ownLegionID)
			{
				if(legionType == LegionType.Player)
				{
					isSend = false;
				}
				else if(!War.isMainLegion)
				{
					isSend = false;
				}
			}

			return isSend;
		}


		//---------------------------------------

		#region play and pause
		/** EntityMBBehaviour是否运行Update */
		public 	static bool 		isUpdateBehaviour = true;
		/** 是否正在运行 */
		public 	static bool 		isPlaying = true;
		/** 是否正在运行 */
		private static float 		_timeScale = Time.timeScale;

		/** 播放 */
		public static void Play()
		{
			War.isUpdateBehaviour = true;
			War.isPlaying = true;
			War.scene.Resume();
			//Time.timeScale = War._timeScale;
			War.signal.Resume();
		}
		
		/** 暂停 */
		public static void Pause()
		{
//			War._timeScale = Time.timeScale;
			War.isPlaying = false;
			War.isUpdateBehaviour = false;
			War.scene.Pause();
			//Time.timeScale = 0F;
			War.signal.Pause();
		}
		#endregion

		public static S_BattleEnd_0x830 endProto;


        /** 东路--技能管理 */
        public static SkillWarManager skillWarManager { get { return Instance._skillWarManager; } set { Instance._skillWarManager = value; } }

		/** 消息 */
		public static WarSignal 				signal = new WarSignal();
		/** 战斗环境配置 */
		public static WarConfig					config = new WarConfig();
		/** 战斗数据IO接口 */
		public static WarRecordIO				record = new WarRecordIO();

		/** 战场数据 */
		public static SceneData 			sceneData;
		/** 执行 */
		public static WarExe 				exe 			{	get { return Instance._exe; 			} 			set { Instance._exe = value; 			} 	}
		/** 服务器协议 */
		public static WarService 			service 		{	get { return Instance._service; 		} 	}
		/** 操作状态管理 */
		public static WarInput 				input 			{	get { return Instance._input; 			} 	}
		/** 配置数据 */
		public static WarModel 				model 			{	get { return Instance._warModel; 		} 	}
		/** 战斗流程管理 */
		public static WarManager 			manager			{	get { return Instance._manager; 			} 		set { Instance._manager = value; 		} 	}
		/** 战斗PVP 处理协议 */
		public static WarPVP 				pvp 			{	get { return Instance._pvp; 			} 			set { Instance._pvp = value; 			} 	}
		/** PVE远征 */
		public static WarPVEExpedition 		pveExpedition 	{	get { return Instance._pveExpedition; 	} 			set { Instance._pveExpedition = value; 			} 	}
		/** 战场管理 */
		public static WarScene 				scene			{	get { return Instance._scene; 			} 			set { Instance._scene = value; 			} 	}
		/** 地图管理 */
		public static WarMap 				map				{	get { return Instance._map; 			} 			set { Instance._map = value; 			} 	}
		/** 战场建造 */
		public static WarSceneCreate 		sceneCreate		{	get { return Instance._sceneCreate; 	} 			set { Instance._sceneCreate = value; 	} 	}
		/** 战斗资源预加载 */
		public static WarPreload 			preload 				{	get { return Instance._preload; 		} 			set { Instance._preload = value; 		}	}
		public static WarFactory 			factory 				{	get { return Instance._factory; 		} 			set { Instance._factory = value; 		}	}
		public static SkillOperateSelect 	skillOperateSelect 		{	get { return Instance._skillOperateSelect; 		} 			set { Instance._skillOperateSelect = value; 		}	}
		public static SkillUse 				skillUse 				{	get { return Instance._skillUse; 		} 			set { Instance._skillUse = value; 		}	}
		public static SkillCreater 			skillCreater			{	get { return Instance._skillCreater; 	} 			set { Instance._skillCreater = value; 	}	}
		public static StarManager 			starManager		{	get { return Instance._starManager; 	} 			set { Instance._starManager = value; 	}	}
		public static StarPVPManager 		starPVPManager	{	get { return Instance._starPVPManager; 	} 			set { Instance._starPVPManager = value; 	}	}
		public static WinManager 			winManager		{	get { return Instance._winManager; 	} 				set { Instance._winManager = value; 	}	}
		public static PathManagerComponent 	pathManager		{	get { return Instance._pathManager; 	} 			set { Instance._pathManager = value; 	}	}
		public static MsgBox 			msgBox	{	get { return Instance._msgBox; 	} 			set { Instance._msgBox = value; 	}	}
		public static TextEffectManager 	textEffect		{	get { return Instance._textEffect; 	} 				set { Instance._textEffect = value; 	}	}
		public static HunManager 			hunManager		{	get { return Instance._hunManager; 	} 				set { Instance._hunManager = value; 	}	}
		public static WarSoliderPool 		soliderPool		{	get { return Instance._soliderPool; 	} 			set { Instance._soliderPool = value; 	}	}
		public static WarPoolManager 		pool			{	get { return Instance._pool; 	} 					set { Instance._pool = value; 	}	}
		public static LegionLevelViewManager 				legionLevelManager			{	get { return Instance._legionLevelManager; 	} 					set { Instance._legionLevelManager = value; 	}	}
		public static LegionExpEffect						legionExpEffect				{	get { return Instance._legionExpEffect; 	} 					set { Instance._legionExpEffect = value; 	}	}
		public static WarRecord								recordManager						{	get { return Instance._recordManager; 	} 								set { Instance._recordManager = value; 	}	}
		public static WarCamera								camera						{	get { return Instance._camera; 	} 								set { Instance._camera = value; 	}	}
		public static WarMaterials							materials					{	get { return Instance._materials; 	} 							set { Instance._materials = value; 	}	}
		public static WarIcons								icons						{	get { return Instance._icons; 	} 							set { Instance._icons = value; 	}	}

		public static bool  				darkScreenVisible 	= false;


        public static WarEnterData 		enterData;
		public static WRTimeLineData	timeLineData;
		public static ProtoBattleVideoInfo videoInfo;

		//----------------------------------- war class  -------------------------------------------------//
		private static War _Instance;
		public static War Instance
		{
			get
			{
				if(_Instance == null)
				{
					_Instance = new War();
				}
				return _Instance;
			}
		}

		private WarExe 					_exe;
		private WarService 				_service;
		private WarModel 				_warModel;
		private WarInput 				_input;

        private SkillWarManager         _skillWarManager;
		private WarSceneCreate 			_sceneCreate;
		private WarPVP 					_pvp;
		private WarPVEExpedition 		_pveExpedition;
		private WarManager 				_manager;
		private WarScene 				_scene;
		private WarMap 					_map;
		private WarPreload 				_preload;
		private WarFactory 				_factory;
		private SkillOperateSelect 		_skillOperateSelect;
		private SkillUse 				_skillUse;
		private SkillCreater 			_skillCreater;
		private StarManager 			_starManager;
		private StarPVPManager 			_starPVPManager;
		private WinManager 				_winManager;
		private PathManagerComponent 	_pathManager;
		private MsgBox 					_msgBox;
		private TextEffectManager 		_textEffect;
		private HunManager 				_hunManager;
		private WarSoliderPool 			_soliderPool;
		private WarPoolManager 			_pool;
		private LegionExpEffect 		_legionExpEffect;
		private LegionLevelViewManager 	_legionLevelManager;
		private WarRecord 				_recordManager;
		private WarCamera 				_camera;
		private WarMaterials 			_materials;
		private WarIcons 				_icons;

		public War()
		{
			_Instance = this;
			_warModel = new WarModel();
			_input = new WarInput();
			_service = new WarService();
			_soliderPool = new WarSoliderPool();

		}

		public void Destory()
		{

			War.service.Clear ();
			_skillWarManager = null;
			_sceneCreate = null;
			_exe = null;
			_pvp = null;
			_pveExpedition = null;
			_manager = null;
			_scene = null;
			_map = null;
			_preload = null;
			_factory = null;
			_skillOperateSelect = null;
			_skillUse = null;
			_skillCreater = null;
			_starManager = null;
			_starPVPManager = null;
			_winManager = null;
			_pathManager = null;
			_msgBox = null;
			_msgBox = null;
			_textEffect = null;
			_hunManager = null;
			_legionExpEffect = null;
			_legionLevelManager = null;
			_soliderPool.Clear();

			_materials = null;
			_icons = null;









			War.signal.Destory ();

		}

		
		
		//-------------- static get data method -------------------------
		/** 自己势力数据 */
		public static LegionData ownLegionData
		{
			get
			{
				if(sceneData == null) return null;
				return sceneData.ownLegion;
			}
		}
		
		/** 获取势力数据 */
		public static LegionData GetLegionData(int legionId)
		{
			return sceneData.legionDict[legionId];
		}

		
		/** 获取势力数据 */
		public static LegionData GetLegionDataByRoleId(int roleId)
		{
			if(sceneData.roleDict.ContainsKey(roleId))
			{
				return sceneData.roleDict[roleId];
			}
			else
			{
				return null;
			}
		}
		
		/** 获取势力关系 */
		public static RelationType GetRelationType(int team)
		{
			return sceneData.ownLegion.GetRelation(team);
		}


		
		//-------------- static process method -------------------------
		
		#region 战斗入口

		/** 初始化 */
		public static void Init()
		{
			War.endProto = null;

			// 发兵数量比例
			War.sendArmRate 		= Setting.SendArm / 100f;
			War.isOverTime 			= false;

			War.service.Clear ();
			War.config.Init();
		}

		/** 播放录像 */

		public static void Start(LuaStringBuffer msgContent, int watchRoleId, bool isLua)
		{
			Debug.Log ("播放录像 War.Start msgContent=" + msgContent + "  watchRoleId=" + watchRoleId);
			MemoryStream memStream = new MemoryStream(msgContent.buffer);
			memStream.Position = 0;
			S_GetEliteVideoList_0x551 videoList = Serializer.Deserialize<S_GetEliteVideoList_0x551>(memStream);
			memStream.Dispose ();

			if (videoList != null && videoList.share_videos.Count > 0)
			{
				ProtoBattleVideoInfo video = videoList.share_videos [0].video;
				Goo.save.record.Load (video, watchRoleId);
			}
		}

		public static void Start(ProtoBattleVideoInfo video, int watchRoleId)
		{
			War.videoInfo = video;
			if (video.uid_local > 0) 
			{
				War.record.SetWatchCount (video.uid_local, video.view_count ++);
			}
			WRTimeLineData timeLineData = WRTimeLineData.Create (video.video_data);
			Start (timeLineData, watchRoleId);
		}


		internal static void Start(WRTimeLineData timeLineData, int watchRoleId)
		{
			War.watchRoleId = watchRoleId;
			War.timeLineData = timeLineData;
			timeLineData.enterData.isRecord = true;
			if(timeLineData.overData != null) timeLineData.overData.isRecord = true;
			timeLineData.enterData.CheckWatchRole (watchRoleId);

//			Debug.Log ("timeLineDatastarCount Start 1=" + timeLineData.overData.legionDatas[0].starCount + "  "+ timeLineData.overData.legionDatas[0].buildCount);
//			Debug.Log ("timeLineDatastarCount Start 2=" + timeLineData.overData.legionDatas[1].starCount + "  "+ timeLineData.overData.legionDatas[1].buildCount);
			Start (timeLineData.enterData);
		}

		/// <summary>
		/// 进入战斗
		/// </summary>
		/// <param name="enterData">进入战斗数据</param>


		public static void Start(WarEnterData enterData)
        {
            Debug.Log("进入战斗数据 enterData=" + enterData);

			if(War.isTest)
			{
				War.Clear();
			}

			War.enterData = enterData;
			War.isRecord = enterData.isRecord;
			// 初始化
			War.Init();
			
			// 战斗流程状态--生成数据
			War.processState = WarProcessState.GenerateData;
			// 对战模式
			War.vsmode = enterData.vsmode;
			// 是否自动关闭加载面板
			War.isAutoCloseLoad =  !War.requireSynch ;
			// 自己势力ID
			War.ownLegionID = enterData.ownLegionId;

            Debug.LogFormat("type====={0}", enterData.vsmode);
			// 战斗已过时间
			War.time = 0;
			// 战斗环境配置--PC机是否开启PC操作模式
			War.config.PCOperater = ConstConfig.GetInt(ConstConfig.ID.War_PCOperater) == 1;
			
			// 生成战场数据
			War.sceneData = new SceneDataForEnterData();
			(War.sceneData as SceneDataForEnterData).Generation(enterData);
			
			// 生成预加载资源
			WarRes.GenerationPreloadList();
			
			// 战斗流程状态--加载中
			War.processState = WarProcessState.Loading;

			if(War.isEditor == false)
			{
				if(!War.isTest)
				{
					LoadType loadType = LoadType.None;
					switch(War.vsmode)
					{
					case VSMode.Dungeon:
					case VSMode.Train:
						loadType = LoadType.Scene_Dungeon;
						break;
					case VSMode.PVP:
						loadType = LoadType.Scene_PVP;
						break;
					case VSMode.PVE:
					case VSMode.PVE_Expedition:
					default:
						loadType = LoadType.Scene_Normal;
						break;
					}
					
					Coo.menuManager.OpenMenuBack(MenuType.WarScene, enterData.backMenuId, null, loadType);
				}
			}

			War.signal.GenerateDataComplete ();
            Debug.Log("	战斗数据生成完毕 War.sGenerateDataComplete.Dispatch();");

            LuaCallMethod("Start");
		}

		public static void ResetStart()
		{
			// 战斗流程状态--加载中
			War.processState = WarProcessState.GameOver;
			// EntityMBBehaviour是否运行Update
			War.isUpdateBehaviour = false;
			War.manager.GetComponent<WarSceneDestory>().DestoryScene();
			
			// 战斗流程状态--生成数据
			War.processState = WarProcessState.GenerateData;
			
			// 战斗已过时间
			War.time = 0;
			// 生成战场数据
			War.sceneData = new SceneDataForEnterData();
			(War.sceneData as SceneDataForEnterData).Generation(enterData);
			
			War.isUpdateBehaviour = true;
			War.manager.BeginCreate();
			War.scene.MaskVisiable = false;
		}

		public static void Clear()
		{
			// 战斗流程状态--加载中
			War.processState = WarProcessState.None;
			// EntityMBBehaviour是否运行Update
			War.isUpdateBehaviour = false;
			War.scene.MaskVisiable = false;
			War.manager.GetComponent<WarSceneDestory>().DestoryScene();
			War.isUpdateBehaviour = true;
			War.soliderPool.Clear();

			
			// 关闭战斗结束面板
			Coo.menuManager.CloseMenu(CC.Module.Menu.MenuType.BattleEnd);
		}
		#endregion
		
		
		public static void S_Over(WarOverData overData)
		{
			Debug.Log("S_Over");

			// 战斗流程状态
			War.processState = WarProcessState.GameOver;

			if (War.scene != null) {

				War.scene.MaskVisiable = true;
				manager.StartCoroutine (DelayOpenEndPanel (overData));
				War.signal.DoGameOver ();
			} else {
				OpenEndPanel (overData);
			}
		}
		
		/// <summary>
		/// 游戏结束
		/// </summary>
		public static void Over(OverType overType)
		{
			War.Over(overType, false);
		}
		public static void Over(OverType overType, bool isOverTime)
		{
			Debug.Log(string.Format("<color=gray>Over overType={0} War.vsmode={1}</color>", overType, War.vsmode));
			War.overType = overType;
			War.isOverTime = isOverTime;
			War.scene.ExeUpdateHandle ();
			manager.StartCoroutine(OnOver());
		}

		
		static IEnumerator OnOver()
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();

			// 战斗流程状态
			War.processState = WarProcessState.GameOver;
			// 胜利条件
			War.winManager.OnGameOver();
			War.overType = War.winManager.GetGameOverType();
//			War.scene.Pause();
			War.scene.MaskVisiable = true;
			
			Debug.Log(string.Format("<color=gray>OnOver overType={0} War.vsmode={1}</color>", overType, War.vsmode));

//			// EntityMBBehaviour是否运行Update
//			War.isUpdateBehaviour = true;
			// 播放星级评价
			
			War.starPVPManager.OnGameOver();
			War.starManager.OnGameOver();
		}
		
		/** 打开战斗结束面板 */
		internal static void OnOverEnd()
		{
			War.endTime = Time.time;
			War.camera.PlayGameOver ();

			if(War.requireSynch)
			{
				if(War.isMainLegion)
				{
					War.service.C_BattleEnd_0x830(War.starPVPManager.GetServiceEndData());
				}
			}
			else
			{

				War.signal.DoGameOver ();
				War.OpenEndPanel();
			}
		}


		internal static WarOverData GetWarOverData()
		{
			WarOverData menuData = new WarOverData();
			menuData.overType = overType;
			menuData.legionDatas = War.starPVPManager.GetOverData();
			menuData.stageId = sceneData.id;
			menuData.time = (int)War.time;
			menuData.isOverTime = War.isOverTime;
			menuData.vsmode = War.enterData.vsmode;
			menuData.enterData = War.enterData;

			return menuData;
		}

		/** 打开战斗结束面板 */
		internal static float endTime = 0;
		internal static IEnumerator DelayOpenEndPanel(WarOverData overData)
		{
			float t = Time.time - War.endTime;

			t = 1.5f - t;
			if (t < 0)
				t = 0.001f;
			yield return new WaitForSeconds(t);
			if (overData.legionDatas.Count == 0)
			{
				overData.legionDatas = War.starPVPManager.GetOverData();
			}
			OpenEndPanel(overData);
		}


		/** 打开战斗结束面板 */
		internal static void OpenEndPanel()
		{
			WarOverData menuData = new WarOverData();
			menuData.overType = overType;

			if (War.isRecord) 
			{
				menuData = War.timeLineData.overData;
			}
			manager.StartCoroutine(DelayOpenEndPanel(menuData));
		}

		
		/** 打开战斗结束面板 */
		internal static void OpenEndPanel(WarOverData menuData)
		{

            Debug.Log("====OpenEndPanel===");
            Coo.soundManager.ChangeMusicBg("none");
//            Coo.soundManager.PlaySound(isWin ? "effect_btl_win" : "effect_btl_fail");


//			Debug.Log ("timeLineDatastarCount OpenEndPanel 1=" + menuData.legionDatas[0].starCount + "  buildCount=" + menuData.legionDatas[0].buildCount);
//			Debug.Log ("timeLineDatastarCount OpenEndPanel 2=" + menuData.legionDatas[1].starCount + "  buildCount=" + menuData.legionDatas[1].buildCount);


			if (War.isRecord) 
			{
				menuData = War.timeLineData.overData;
				menuData.isRecord = true;
			} 
			else
			{
				menuData.isRecord = War.isRecord;
				menuData.stageId = sceneData.id;
				menuData.time = (int)War.time;
				menuData.isOverTime = War.isOverTime;
				menuData.vsmode = War.enterData.vsmode;
				menuData.enterData = War.enterData;
			}

			Time.timeScale = 1;

			Coo.menuManager.OpenMenu(War.enterData.overMenuId, menuData);

			//War.record.timeLineData.overData = menuData;
			//War.record.timeLineData.SaveJSON ();

			if (War.isRecord == false && War.vsmode == VSMode.PVP) 
			{
				War.record.Save (menuData);

			}
		}
		
		/// <summary>
		/// 退出战斗
		/// </summary>

        public static void Exit()
        {
            Exit(false);
        }

		public static void Exit(bool isHandler)
		{
            LuaCallMethod("Exit", isHandler, sceneData.id);
			// 战斗流程状态
			War.processState = WarProcessState.Exit;
			// 关闭战斗结束面板
			Coo.menuManager.CloseMenu(CC.Module.Menu.MenuType.BattleEnd);
			// 播放
			War.Play();
			// 退出战斗 进入主场景
			Coo.menuManager.OpenMenu(MenuType.MainScene, 1);
			// 销毁战斗加载的资源
			WarRes.Destroy();
			War.Instance.Destory();
		}
		
		
		/// <summary>
		/// 获取预加载资源
		/// </summary>
		public static List<string> GetPreloadFiles(int menuId, object parameter)
		{
			return WarRes.preloadList;
		}

		public static void OnPreloadFile(string filename, System.Object obj)
		{
			WarRes.AddPrefab(filename, obj);
		}
		
		
		
		
		/// <summary>
		/// 准备完毕PVP
		/// </summary>
		public static void OnReadyPVP()
		{
			if(manager != null) manager.OnReadyPVP(); 
		}

        /// <summary>
        /// 执行Lua方法
        /// </summary>
        protected static object[] LuaCallMethod(string func, params object[] args)
        {
//            return Util.CallMethod("LuaWar", func, args);
			return null;
        }
		


	}
}