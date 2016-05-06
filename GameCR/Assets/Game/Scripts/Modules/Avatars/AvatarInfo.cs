using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Module.Avatars
{
	public class AvatarInfo : MonoBehaviour 
	{
		/** 士兵纵向间距 */
		public float gapV = 1;
		/** 一排士兵宽度 */
		public float armOnceWidth = 8;
		/** 一排士兵数量 */
		public int armOnceCount = 8;
		/** 阴影大小 */
		public float shadowScale = 1f;
		/** 灰尘大小 */
		public float dustScale = 1f;

		public void CopyInfo(AvatarInfo item)
		{
			gapV 			= item.gapV;
			armOnceWidth 	= item.armOnceWidth;
			armOnceCount 	= item.armOnceCount;
			shadowScale 	= item.shadowScale;
			dustScale 		= item.dustScale;
		}
	}
}