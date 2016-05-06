using UnityEngine;
using System.Collections;
using CC.Runtime;
using CC.Runtime.Utils;
using System.Collections.Generic;
using System;

namespace CC.Module.Menu
{
	[ConfigPath("Config/menu",ConfigType.CSV)]
	public class MenuConfig : IParseCsv, IKey<int>
	{
		/** 菜单ID */
		public int menuId;   
		/** 名称 */
		public string name;
		/** 开启等级 */
		public int openLevel;
		
		/** 层级 */
		public MenuLayerType layer = MenuLayerType.Layer_Module;  
		/** 显示方式 */
		public int showIndex;  
		/** 模块类型 */
		public ModuleType moduleType;
		/** 加载条方式 */
		public LoadType loadType;  
		/** 布局类型 */
		public LayoutType layoutType; 

		/** 资源路径 */
		public string path;   
		/** 面板名称 */
		public string prefabName; 


		
		/** 
		1 一般面板

		2 一般面板，显示货币条

		3 主页面板，显示所有 */
		public int mainUIType = 1;


		/** 是否销毁 */
		public bool isDestroy;   
		/** 关闭后要打开的面板 */
		public int targetMenuId;

		public int Key
		{
			get
			{
				return menuId;
			}
		}

		public void ParseCsv(string[] csv)
		{
			int i = 0;
			menuId = csv.GetInt32(i++);
			name = csv.GetString(i++);
			openLevel = csv.GetInt32(i++);
			layer = (MenuLayerType) csv.GetInt32(i++);
			showIndex = csv.GetInt32(i++);
			moduleType = (ModuleType) csv.GetInt32(i++);
			loadType = (LoadType) csv.GetInt32(i++);
			layoutType = (LayoutType) csv.GetInt32(i++);
			path = csv.GetString(i++);
			prefabName = System.IO.Path.GetFileName(path);

			mainUIType = csv.GetInt32(i++);
			
			isDestroy = (csv.GetString(i++) != "0");
			targetMenuId = csv.GetInt32(i++);

		}

		
		public int showType 
		{
			get
			{
				if(showIndex <= ShowType.Screen) return ShowType.Screen;
				if(showIndex < ShowType.Special) return ShowType.Popup;
				return ShowType.Special;
			}
		}

		public bool showBlurBG
		{
			get
			{
				if(!GameScene.IsMain())
				{
					return false;
				}
				return showType == ShowType.Popup;
			}
		}

		public bool isPushMenuId
		{
			get
			{
				return showType != ShowType.Special && menuId != MenuType.MainUI;
			}
		}
	}
}