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
		private IModule mainUiModule;
		private int setLasetMainUIMenuId = -1;

		private void CloseMainUI(bool forcedDestroy = false)
		{
			if(mainUiModule != null)
			{
				RemoveWindow(mainUiModule, false, forcedDestroy);
			}

			if (forcedDestroy) 
			{
				mainUiModule = null;
			}
		}

		private void CheckMainUI()
		{
			CheckMainUI(currentWindowId);
		}

		private void CheckMainUI(int moduleMenuId)
		{
			if(!GameScene.IsMain())
			{
				return;
			}

			setLasetMainUIMenuId = moduleMenuId;
			if(mainUiModule == null)
			{
				LoadMainUI();
			}
			else
			{
				SetMenuUI(setLasetMainUIMenuId);
			}
		}

		private void LoadMainUI()
		{
			int menuId = MenuType.MainUI;
			MenuConfig config = configSet [menuId];
			assetManager.Load(config.path, (string path, System.Object o) => 
			                  {
				UnityEngine.Object obj  = o as UnityEngine.Object;
				
				GameObject go = GameObject.Instantiate(obj) as GameObject;
				go.name = config.prefabName;
				go.transform.SetParent(GetRoot(MenuLayerType.Layer_MainUI), false);
				
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
				module.MenuId = menuId;

				mainUiModule = module;

				
				SetMenuUI(setLasetMainUIMenuId);
			});
		}

		private void SetMenuUI(int menuId)
		{
			if(menuId > 0)
			{
				MenuConfig config = configSet [menuId];

				if(mainUiModule.IsActive == false)
				{
					mainUiModule.IsActive = true;
				}
				if (config.mainUIType != 0)
				{
					mainUiModule.SetParameter(config.mainUIType);
					mainUiModule.Enter();
				}
			}

		}
		
	}
}