using UnityEngine;
using System.Collections;
using System;


namespace CC.Module.Menu
{
	public class MenuChangeVO 
	{
		/** 菜单ID（模块ID） */
		public int menuId = 0;
		/** 打开关闭行为 (true:打开,  false:关闭） */
		public bool isToOpen = true;
		/** 是否关闭其他面板，默认关闭。 */
		public bool isCloseOthers = true;
		/** 后退 */
		public int backId = 0;
		/** 打开时，传递的参数 */
		public object parameter;
		/** 使用的加载方式 */
		public LoadType loadType;
		/** 是否返回 */
		public bool isBackState = false;

		/** 预安装 */
		public bool isPreInstance = false;
		public Action<int> instanceCallback;
	}
}
