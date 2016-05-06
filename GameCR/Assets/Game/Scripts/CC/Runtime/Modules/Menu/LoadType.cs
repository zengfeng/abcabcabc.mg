using UnityEngine;
using System.Collections;

namespace CC.Module.Menu
{
	public enum LoadType
	{
		/** 不需要加载条 */
		None,      
		/** 转圈圈 */
		Circle,   
		/** 屏幕变暗转圈圈 */
		DarkCircle,    
		/** 全屏面板进度条 */
		Screen, 
		/** 场景进度条--普通 */
		Scene_Normal,
		/** 场景进度条--副本 */
		Scene_Dungeon,
		/** 场景进度条--PVE */
		Scene_PVE,
		/** 场景进度条--PVP */
		Scene_PVP,
	}
}