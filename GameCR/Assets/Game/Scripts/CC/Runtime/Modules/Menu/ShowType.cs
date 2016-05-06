using UnityEngine;
using System.Collections;

namespace CC.Module.Menu
{
	public class ShowType
	{
		/** 全屏 (v == 0 ), 会销毁其他面版 */
		public static int Screen = 0;  

		/** 弹出面板(1 <= v  < 100), 会销毁其他showType相等的面版 */
		public static int Popup = 1;   

		/** 特殊面板(100 <= v) */
		public static int Special = 100;   
	}
}