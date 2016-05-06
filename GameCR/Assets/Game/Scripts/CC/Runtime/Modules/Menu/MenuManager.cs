using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime;
using CC.Module.LoadScenes;
using CC.Module.Loads;
using Games.Module.Wars;
using System;
using SimpleFramework;
using CC.Runtime.Utils;
using LuaInterface;

namespace CC.Module.Menu
{
	public partial class MenuManager : MonoBehaviour
	{
		private ConfigManager configManager
		{
			get
			{
				return Coo.configManager;
			}
		}

		private AssetManager assetManager
		{
			get
			{
				return Coo.assetManager;
			}
		}

		
		
		private LoadManager loadManager
		{
			get
			{
				return Coo.loadManager;
			}
		}


		private ConfigSet<int, MenuConfig> _configSet;
		private ConfigSet<int, MenuConfig> configSet
		{
			get
			{
				if(_configSet == null)
				{
					_configSet = configManager.GetConfig<int, MenuConfig>();
				}
				return _configSet;
			}
		}

		private Transform root2d
		{
			get
			{
				return GameObject.Find("Canvas").transform;
			}
		}

		public Transform GetRoot(MenuLayerType layer)
		{
			GameObject go = null;
			Transform root;
			switch(layer)
			{
			case MenuLayerType.Layer_PreInstance:
				go = GameObject.Find("Layer-PreInstance");
				break;
			case MenuLayerType.Layer_DefaultBG:
				go = GameObject.Find("Canvas/Layer-DefaultBG");
				break;
			case MenuLayerType.Layer_Home:
				go = GameObject.Find("Canvas/Layer-Home");
				break;
			case MenuLayerType.Layer_BlurBG:
				go = GameObject.Find("Canvas/Layer-BlurBG");
				break;
			case MenuLayerType.Layer_Module:
				go = GameObject.Find("Canvas/Layer-Module");
				break;
			case MenuLayerType.Layer_MainUI:
				go = GameObject.Find("Canvas/Layer-MainUI");
				break;
			case MenuLayerType.Layer_Dialog:
				go = GameObject.Find("Canvas/Layer-Dialog");
				break;
			case MenuLayerType.Layer_Guide:
				go = GameObject.Find("Canvas/Layer-Guide");
				break;
			}

			if(go == null)
			{
				go = GameObject.Find("Canvas");
			}

			root = go.transform;


			return root;
		}

		public BlurBG blurBG
		{
			get
			{
				GameObject go = GameObject.Find("Canvas/Layer-BlurBG");
				if(go == null)
				{
					return null;
				}
				return go.GetComponent<BlurBG>();
			}
		}

		public bool forceDestroyAll = false;

		private Dictionary<int, Func<int, object, List<string>>> preloadFileCalls = new Dictionary<int, Func<int, object, List<string>>>(); 
		private Dictionary<int, Action<string, System.Object>> preloadFileCallbacks = new Dictionary<int, Action<string, object>>();

		/// <summary>
		/// 添加模块预加载回调
		/// </summary>
		/// <param name="menuId">模块ID.</param>
		/// <param name="call">获取预加载文件列表回调.</param>
		public void AddPreloadCall(int menuId, Func<int, object, List<string>> call)
		{
			if(preloadFileCalls.ContainsKey(menuId))
			{
				preloadFileCalls[menuId] = call;
			}
			else
			{
				preloadFileCalls.Add(menuId, call);
			}
		}

		/// <summary>
		/// 添加模块预加载回调
		/// </summary>
		/// <param name="menuId">模块ID.</param>
		/// <param name="call">获取预加载文件列表回调.</param>
		/// <param name="fileCallback">资源加载回调.</param>
		public void AddPreloadCall(int menuId, Func<int, object, List<string>> call, Action<string, System.Object> fileCallback)
		{
			AddPreloadCall(menuId, call);

			if(preloadFileCallbacks.ContainsKey(menuId))
			{
				preloadFileCallbacks[menuId] = fileCallback;
			}
			else
			{
				preloadFileCallbacks.Add(menuId, fileCallback);
			}
		}

		private Dictionary<int, IModule> modules = new Dictionary<int, IModule>();
		private Dictionary<int, MenuChangeVO> lastOpens = new Dictionary<int, MenuChangeVO>();
		private Dictionary<int, int> backs = new Dictionary<int, int>();
		/** 已经打开的全屏面板数量 */
		public int activeFullScreenWindowCount = 0;
		/** 已经打开的MenuId */
		private List<int> openedMenuIds = new List<int>();
        public int currentWindowId
		{
			get
			{
				if(openedMenuIds.Count > 0) return openedMenuIds[openedMenuIds.Count - 1];
				return  -1;
			}
		}

		public IModule currentWindow
		{
			get
			{
				int id = currentWindowId;
				if (id > 0 && modules.ContainsKey(id))
					return modules[id];

				return null;
			}
		}


		/**  打开模块 */
		public void OpenMenu(int menuId)
		{
			OpenMenu(menuId, null, LoadType.None);
		}

		
		/**  打开模块 */
		public void OpenMenu(int menuId, object parameter)
		{
			OpenMenu(menuId, parameter, LoadType.None);
		}

		/**  打开模块 */
		public void OpenMenu(int menuId, object parameter, LoadType loadType)
		{
			MenuChangeVO vo = new MenuChangeVO();
			vo.menuId = menuId;
			vo.loadType = loadType;
			vo.isToOpen = true;
			vo.parameter = parameter;
			
			Debug.Log(string.Format("<color=yellow>OpenMenu  menuId={0} </color>", menuId));
			if(lastOpens.ContainsKey(vo.menuId))
			{
				lastOpens[vo.menuId] = vo;
			}
			else
			{
				lastOpens.Add(vo.menuId, vo);
			}

			CheckMenuVO(vo);
		}


		/**  预打开模块 */
		public void LuaOpenMenuPreInstance(int menuId, LuaTable callTable, LuaFunction callback)
		{
			LuaOpenMenuPreInstance(menuId, null, callTable, callback);
		}

		/**  预打开模块 */
		public void LuaOpenMenuPreInstance(int menuId, object parameter, LuaTable callTable, LuaFunction callback)
		{
			LuaCallback luaCB = new LuaCallback(callTable, callback);
			OpenMenuPreInstance(menuId, parameter, luaCB.MenuInstanceCallback);
		}
		
		/**  预打开模块 */
		public void OpenMenuPreInstance(int menuId)
		{
			OpenMenuPreInstance(menuId, null, null);
		}

		/**  预打开模块 */
		public void OpenMenuPreInstance(int menuId, Action<int> callback)
		{
			OpenMenuPreInstance(menuId, null, callback);
		}
		
		/**  预打开模块 */
		public void OpenMenuPreInstance(int menuId, object parameter, Action<int> callback)
		{
			MenuChangeVO vo = new MenuChangeVO();
			vo.menuId = menuId;
			vo.isToOpen = true;
			vo.parameter = parameter;
			vo.isPreInstance = true;
			vo.instanceCallback = callback;
			CheckMenuVO(vo);
		}

		
		/**  打开模块 */
		public void OpenMenuBack(int menuId, int backId)
		{
			OpenMenuBack(menuId, backId, null, LoadType.None);
		}
		
		/**  打开模块 */
		public void OpenMenuBack(int menuId, int backId, object parameter)
		{
			OpenMenuBack(menuId, backId, parameter, LoadType.None);
		}

		/**  打开模块 */
		public void OpenMenuBack(int menuId, int backId, object parameter, LoadType loadType)
		{
			
			MenuChangeVO vo = new MenuChangeVO();
			vo.menuId = menuId;
			vo.loadType = loadType;
			vo.isToOpen = true;
			vo.parameter = parameter;
			vo.backId = backId;

			
			if(lastOpens.ContainsKey(vo.menuId))
			{
				lastOpens[vo.menuId] = vo;
			}
			else
			{
				lastOpens.Add(vo.menuId, vo);
			}
			Debug.Log(string.Format("<color=yellow>OpenMenuBack  menuId={0} backId={1}</color>", menuId, backId));
			if(backs.ContainsKey(menuId))
			{
				backs[menuId] = backId;
			}
			else
			{
				backs.Add(menuId, backId);
			}
			
			CheckMenuVO(vo);
		}

		public int GetBackId(int menuId)
		{
			int backId = 0;
			if(backs.TryGetValue(menuId, out backId))
				return backId;

			return backId;
		}

		public void Back(int menuId)
		{
			Back(menuId, 0);
		}

		
		public void Back(int menuId, int layer)
		{
			Back(menuId, layer, 0);
		}

		public void Back(int menuId, int layer, int preMenuId)
		{
			int backId;
			if(backs.TryGetValue(menuId, out backId))
			{
				if(layer > 0)
				{
					layer --;
					Back(backId, layer, backId);
					return;
				}

				Debug.Log("lastOpens[backId] ="  + lastOpens[backId]);
				MenuChangeVO vo;
				if(lastOpens.TryGetValue(backId, out vo))
				{
					vo.isBackState = true;
					Debug.Log("vo ="  + vo + " vo.parameter" + vo.parameter);
					CheckMenuVO(vo);
				}
				else
				{
					Debug.Log(string.Format("<color=red>Menu Back MenuChangeVO={0} backId={1}</color>", vo, backId));
					OpenMenu(menuId);
				}
			}
			else if(preMenuId > 0)
			{
				MenuChangeVO vo;
				if(lastOpens.TryGetValue(preMenuId, out vo))
				{
					
					Debug.Log("vo ="  + vo + " vo.parameter" + vo.parameter);
					CheckMenuVO(vo);
				}
				else
				{
					Debug.Log(string.Format("<color=red>Menu Back MenuChangeVO={0} preMenuId={1}</color>", vo, preMenuId));
					OpenMenu(preMenuId);
				}
			}
			else
			{
                if(menuId != MenuType.BattleArrange)
                {
                    Back(MenuType.BattleArrange);
                }
                else
                {
                    OpenMenu(MenuType.Home, 0);
                }
				Debug.Log(string.Format("<color=red>Menu Back menuId={0} backId={1}</color>", menuId, backId));
			}
		}

		
		/**  关闭模块 */
		public void CloseMenu(int menuId)
		{
			MenuChangeVO vo = new MenuChangeVO();
			vo.menuId = menuId;
			vo.isToOpen = false;
			CheckMenuVO(vo);
		}
		
		/**  收到打开模块 */
		public void OnOpenHandler(IModule module)
		{

		}
		
		/**  收到关闭模块 */
		public void OnCloseHandler(IModule module)
		{

		}
		
		/**  获取模块需要预加载的文件列表 */
		public List<string> GetPreloadFiles(int menuId, object parameter)
		{
			List<string> list = new List<string>();

			MenuConfig config = configSet [menuId];
			if(config != null && config.moduleType == ModuleType.Panel)
			{
				list.Add(config.path);
			}

			Func<int, object, List<string>> call;
			if(preloadFileCalls.TryGetValue(menuId, out call))
			{
				List<string> callList = call(menuId, parameter);
				foreach(string item in callList)
				{
					list.Add(item);
				}
			}

			object[] luaList =  Util.CallMethod("MenuPreloadFile", "GetPreloadFiles", menuId, parameter);
			if(luaList != null)
			{
				foreach(string item in luaList)
				{
					list.Add(item);
				}
			}
			
			
			return list;
		}

		public void OnPreloadFile(int menuId, string filename, System.Object obj)
		{
			Action<string, System.Object> call;
			if(preloadFileCallbacks.TryGetValue(menuId, out call))
			{
				call(filename, obj);
			}

			//Util.CallMethod("MenuPreloadFile", "OnPreloadFile", menuId, filename, obj);

		}

		/**  检测窗口是否打开 */
		public bool CheckMenuOpen(int menuId)
		{
			if (modules.ContainsKey(menuId))
			{
				IModule module = modules[menuId];
				return module.IsActive;
			}
			else
			{
				return false;
			}
		}

		
		private void CheckMenuVO(MenuChangeVO vo)
		{

			if (vo.isToOpen)
			{
				OpenMenu(vo);
			}
			else
			{
				CloseMenu(vo);
			}
		}

		private void OpenMenu(MenuChangeVO vo)
		{
			MenuConfig config = configSet [vo.menuId];
			
			if(config == null)
			{
				Debug.Log(string.Format("<color=red>[MenuManager.OpenMenu(MenuVO vo)] 没有获取到配置 menuId={0} config=null</color>",  vo.menuId));
				return;
			}

			if(config.moduleType == ModuleType.Panel)
			{
				if(vo.menuId != MenuType.Home && config.showType != ShowType.Screen)
				{
//					if (activeFullScreenWindowCount <= 0)
//					{
//						if(GameScene.IsMain())
//						{
//							MenuChangeVO menuVO = null;
//							
//							if(!lastOpens.TryGetValue(MenuType.Home, out menuVO))
//							{
//								menuVO = new MenuChangeVO();
//								menuVO.menuId = MenuType.Home;
//								menuVO.isToOpen = true;
//								menuVO.isCloseOthers = false;
//							}
//							CheckMenuVO(menuVO);
//						}
//					}
				}
				
				IModule module;
				if(modules.TryGetValue(vo.menuId, out module))
				{
					if(module.IsActive)
					{
						SetModuleParameter(config, vo, module);
					}
					else
					{
						OpenWindow(vo, module);
					}
				}
				else
				{
					loadManager.LoadPanel(vo.isPreInstance, vo.loadType == LoadType.None ? config.loadType : vo.loadType, GetPreloadFiles(vo.menuId, vo.parameter),OnModuleLoadDone,OnModuleLoadCancel, config.menuId, vo);
				}
			}
			else if(config.moduleType == ModuleType.Scene)
			{
				loadManager.LoadScene(config.path,  config.menuId != MenuType.WarScene, config.menuId, vo.parameter, vo.loadType);
			}
		}
		
		private void OnModuleLoadCancel(Loader loader)
		{

		}

		private void OnModuleLoadDone(Loader loader)
		{
			MenuChangeVO vo = loader.bindData as MenuChangeVO;
			MenuConfig config = configSet [vo.menuId];
			Debug.Log("MenuManager.OpenWindow config.name="+config.name + "  config.menuId=" + config.menuId);
			
			assetManager.Load(config.path, (string path, System.Object o) => 
			                  {
				UnityEngine.Object obj  = o as UnityEngine.Object;
				if(obj == null)
				{
					Debug.Log(string.Format("<color=red>MenuManager.OnModuleLoadDone obj=null path={0}</color>", path));
				}

				GameObject go = GameObject.Instantiate(obj) as GameObject;
				go.name = config.prefabName;
				go.transform.SetParent(GetRoot(vo.isPreInstance ? MenuLayerType.Layer_PreInstance : config.layer), false);
				
				RectTransform rectTransform = go.transform as RectTransform;
				rectTransform.localScale = Vector3.one;


				if(config.layoutType == LayoutType.PositionZero)
				{
					rectTransform.anchoredPosition = Vector2.zero;
				}
				else
				{
					rectTransform.offsetMin = Vector2.zero;
					rectTransform.offsetMax = Vector2.zero;
				}

				IModule module = go.GetComponent<IModule>();
				module.MenuId = vo.menuId;


				OpenWindow(vo, module);

//				UpdateLayerZ();
			});
		}

		private void UpdateLayerZ()
		{
			RectTransform root = (RectTransform) root2d;
			int count = root.childCount;
			int z = 0;
			for(int i = 0; i < count; i ++)
			{
				RectTransform layer = (RectTransform)root.GetChild(i);
				layer.anchoredPosition3D =layer.anchoredPosition3D.SetZ(z);

				int itemCount = layer.childCount;
				int localZ = 0;
				for(int j = 0; j < itemCount; j ++)
				{
					RectTransform item = (RectTransform)layer.GetChild(j);
					if(item.gameObject.activeSelf)
					{
						item.anchoredPosition3D =item.anchoredPosition3D.SetZ(localZ);
						localZ += -100;
						z += -100;
					}
				}

			}
		}

		private void SetModuleParameter(MenuConfig config, MenuChangeVO vo, IModule module)
		{
			module.SetParameter(vo.parameter);
			
			module.rectTransform.SetParent(GetRoot(vo.isPreInstance ? MenuLayerType.Layer_PreInstance : config.layer), false);

			if(vo.isPreInstance)
			{
				module.rectTransform.SetAsFirstSibling();
			}
			else
			{
				module.rectTransform.SetAsLastSibling();
			}

		}

		private void OpenWindow(MenuChangeVO vo, IModule module)
		{
			MenuConfig config = configSet [vo.menuId];
			//Debug.Log("MenuManager.OpenWindow config.name="+config.name+ " module=" + module + "  module.MenuId=" + module.MenuId );

			if(vo.isCloseOthers)
			{
				Queue<IModule> closeWinQueue = new Queue<IModule>();


				if (config.showType == ShowType.Screen)
				{
					foreach (var item in modules)
					{
						if(!item.Value.IsActive) continue;
						MenuConfig itemConfig = configSet [item.Value.MenuId];
						
						if (itemConfig != null && config.menuId != itemConfig.menuId)
						{
							closeWinQueue.Enqueue(item.Value);
						}
					}
				}
				else if (config.showType == ShowType.Popup)
				{
					foreach (var item in modules)
					{
						if(!item.Value.IsActive) continue;
						MenuConfig itemConfig = configSet [item.Value.MenuId];
						
						if (itemConfig != null && config.menuId != itemConfig.menuId && config.showIndex == itemConfig.showIndex)
						{
							closeWinQueue.Enqueue(item.Value);
						}
					}
				}
				
				while (closeWinQueue.Count > 0)
				{
					CloseWindow(closeWinQueue.Dequeue(), false);
				}
			}


			if (modules.ContainsKey(vo.menuId))
			{
				modules [vo.menuId] = module;
			}
			else
			{
				modules.Add(vo.menuId, module);
			}

			
			module.IsActive = true;
			module.rectTransform.SetParent(GetRoot(vo.isPreInstance ? MenuLayerType.Layer_PreInstance : config.layer), false);
			if(vo.isPreInstance)
			{
				module.rectTransform.SetAsFirstSibling();
			}
			else
			{
				module.rectTransform.SetAsLastSibling();
			}
			module.SetParameter(vo.parameter);

			if (!vo.isBackState) 
			{
				if (!vo.isPreInstance)
					module.Enter ();
			} 
			else 
			{
				vo.isBackState = false;
				module.OnBack ();
			}
			

			
			if (config.showType == ShowType.Screen)
			{
				activeFullScreenWindowCount ++;
				//Debug.Log("MenuManager.OpenWindow config.name="+config.name+ " activeFullScreenWindowCount="+activeFullScreenWindowCount);
			}

			
			
			if(vo.isPreInstance)
			{
				DelayClose(vo);
				return;
			}

			CheckMainUI(config.menuId);



			//TODO blurbg
			if(config.showBlurBG)
			{
				if(blurBG != null)
				{
					blurBG.OnOpenMenu(config);
				}

			}

			if(config.isPushMenuId)
			{
				if(openedMenuIds.IndexOf(config.menuId) != -1)
				{
					openedMenuIds.Remove(config.menuId);
				}
				openedMenuIds.Add(config.menuId);
			}
			
		}

		private void DelayClose(MenuChangeVO vo)
		{
			StartCoroutine(OnDelayClose(vo));
		}

		IEnumerator OnDelayClose(MenuChangeVO vo)
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			
			CloseMenu(vo.menuId);
			if(vo.instanceCallback != null) vo.instanceCallback(vo.menuId);
		}

		private void CloseMenu(MenuChangeVO vo)
		{
			MenuConfig config = configSet [vo.menuId];
			
			if(config == null)
			{
				//Debug.Log(string.Format("<color=red>[MenuManager.CloseMenu(MenuVO vo)] 没有获取到配置 menuId={0} config=null</color>",  vo.menuId));
				return;
			}
			
			if(config.moduleType == ModuleType.Panel)
			{
				IModule module;
				if(modules.TryGetValue(vo.menuId, out module))
				{
					CloseWindow(module, true);
				}
			}
			else if(config.moduleType == ModuleType.Scene)
			{
				if(Application.loadedLevelName != "Main")
				{
					OpenMenu(MenuType.MainScene);
				}
			}
		}


		/// <summary>
		///	关闭窗口
		/// </summary>
		///
		/// <param name="win"> 窗口实体 </param>
		/// <param name="isInitiativeClose"> 是否是主动关闭(是否是主动关闭 true:主动，false:被迫) </param>
		/// <returns></returns>
		private void CloseWindow(IModule module, bool isInitiativeClose, bool forcedDestroy = false)
		{
			
			MenuConfig config = configSet [module.MenuId];
			//Debug.Log("MenuManager.CloseWindow config.name="+config.name+ "  config.showIndex=" + config.showIndex+ "  config.showType=" + config.showType + " module=" + module + "  module.MenuId=" + module.MenuId + "  isInitiativeClose=" + isInitiativeClose + "  activeFullScreenWindowCount=" + activeFullScreenWindowCount);



			
			if (config.showType == ShowType.Screen && module.IsActive)
			{
				activeFullScreenWindowCount --;
				//Debug.Log("MenuManager.CloseWindow config.name="+config.name+ " activeFullScreenWindowCount="+activeFullScreenWindowCount);

				if(activeFullScreenWindowCount < 0)
				{
					Debug.Log( "<color=red>MenuManager.CloseWindow config.name="+config.name+ " activeFullScreenWindowCount="+activeFullScreenWindowCount + "</color>");
				}
			}


			if (config.isDestroy || forcedDestroy)
			{
				modules.Remove(module.MenuId);
			}

			if (isInitiativeClose)
			{
				if (config.targetMenuId > 0)
				{
					MenuChangeVO menuVO = new MenuChangeVO();
					menuVO.menuId = config.targetMenuId;
					menuVO.isToOpen = true;
					menuVO.isCloseOthers = false;
					CheckMenuVO(menuVO);
				}
				else
				{
				}
			}


			
			//TODO blurbg
			if(config.showBlurBG)
			{
				if(blurBG != null)
				{
					blurBG.OnCloseMenu(config);
				}
			}

			
			if(config.isPushMenuId)
			{
				if(openedMenuIds.IndexOf(config.menuId) != -1)
				{
					openedMenuIds.Remove(config.menuId);
				}
			}

			if (config.showType == ShowType.Screen)
				CheckMainUI();

			RemoveWindow(module, isInitiativeClose, forcedDestroy);
		}

		private void RemoveWindow(IModule module, bool isInitiativeClose = true, bool forcedDestroy = false)
		{
			MenuConfig config = configSet [module.MenuId];
			//Debug.Log("MenuManager.RemoveWindow config.name="+config.name+ " module=" + module + "  module.MenuId=" + module.MenuId );
			
			Debug.Log(config.menuId + "  " + config.name +  "config.isDestroy=" + config.isDestroy + "  forcedDestroy=" + forcedDestroy);
			module.CheckOnExit();
			if (config.isDestroy || forcedDestroy)
			{
				Debug.Log(config.menuId + "  " + config.name +  "config.isDestroy=" + config.isDestroy + "  forcedDestroy=" + forcedDestroy);
//				if(module.IsActive) module.DestroyModule();
				module.DestroyModule();
				//Coo.assetManager.UnloadUnusedAssets();
			}
			else
			{
				if (module.IsActive)
				{
					module.IsActive = false;
				}
			}

			int activeScreenFullCount = 0;
			foreach (IModule mod in modules.Values)
			{
				var menuId = mod.MenuId;
				var cfg = configSet[menuId];
				if (cfg.showType == ShowType.Screen && mod.IsActive)
					activeScreenFullCount += 1;
			}
			if (activeScreenFullCount <= 0)
			{
				if(Application.loadedLevelName == "Main" && isInitiativeClose)//主动关闭会默认打开主场景
				{
					MenuChangeVO menuVO = null;
					
					if(!lastOpens.TryGetValue(MenuType.Home, out menuVO))
					{
						menuVO = new MenuChangeVO();
						menuVO.menuId = MenuType.Home;
						menuVO.isToOpen = true;
						menuVO.isCloseOthers = false;
					}
					CheckMenuVO(menuVO);
				}
			}
		}



        public void CloseCurrent()
        {
            if (currentWindowId >= 0 && modules.ContainsKey(currentWindowId))
            {
                modules[currentWindowId].Exit();
            }
        }

		public void CloseAll()
		{

			List<IModule> menuIdList = new List<IModule>();
			foreach(var item in modules)
			{
				menuIdList.Add(item.Value);
			}

			for(int i = 0; i < menuIdList.Count; i ++)
			{
				CloseWindow(menuIdList[i], false, forceDestroyAll);
			}

			if(blurBG != null)
			{
				blurBG.Close();
			}

			menuIdList.Clear();

			openedMenuIds.Clear();
			CloseMainUI(forceDestroyAll);

			
			activeFullScreenWindowCount = 0;
		}

		public void Clear()
		{
			modules = new Dictionary<int, IModule>();
			activeFullScreenWindowCount = 0;
		}


	}
}