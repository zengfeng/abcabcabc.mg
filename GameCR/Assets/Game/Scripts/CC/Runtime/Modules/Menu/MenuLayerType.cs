using UnityEngine;
using System.Collections;

namespace CC.Module.Menu
{
	public enum MenuLayerType
	{
		/** 预安装 */
		Layer_PreInstance,
		/** 默认背景 */
		Layer_DefaultBG = 1,
		/** 主场景 */
		Layer_Home = 2,
		/** 模糊背景 */
		Layer_BlurBG = 3,
		/** 模块 */
		Layer_Module = 4,
		/** 主UI */
		Layer_MainUI = 5,
		/** 对话框 */
		Layer_Dialog = 6,
		/** 引导 */
		Layer_Guide = 7
	}
}