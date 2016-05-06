using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;



namespace Games.Module.Wars
{
	public class WarColor 
	{
		/** 灰色 */
		public const int Gray = 0;
		/** 红色 */
		public const int Red = 1;
		/** 蓝色 */
		public const int Blue = 2;
		/** 绿色 */
		public const int Green = 3;
		/** 紫色 */
		public const int Magenta = 4;
		/** 粉色 */
		public const int Pink = 5;
		/** 橙色 */
		public const int Orange = 6;
		/** 黄色 */
		public const int Yellow = 7;
		/** 棕色 */
		public const int Brown = 8;
		
		public static int[] IDs = new int[]{Gray, Red, Blue, Green, Magenta};
		public static string[] Names = new string[]{"灰色", "红色", "蓝色", "绿色", "紫色"};
		public static string[] TagNames = new string[]{"<color=gray>灰色</color>", "<color=red>红色</color>", "<color=blue>蓝色</color>", "<color=green>绿色</color>", "<color=magenta>紫色</color>"};

		public static Color[] turretColor;
		public static Color GetTurretColor(int colorId)
		{
			return turretColor[colorId];
		}

		public static Color[] unitHPColor = new Color[]{Color.gray, Color.red, Color.blue, Color.green, Color.magenta,  Color.white};
		public static Color GetUnitHPColor(int colorId)
		{
			return unitHPColor[colorId];
		}
		
		public static Color[] hunColor;
		public static Color GetHunColor(int colorId)
		{
			return hunColor[colorId];
		}
		
		public static Color[] heroHeadColor;
		public static Color GetHeroHeadColor(int colorId)
		{
			return heroHeadColor[colorId];
		}

		public static Color[] qualityColors = new Color[]{ColorUtil.ToColor(0xFFFFFF), ColorUtil.ToColor(0xFFFFFF), ColorUtil.ToColor(0x5AB7DD), ColorUtil.ToColor(0xD216D5)};
		public static Color GetQualityColor(int quality)
		{
			if(quality < 0) return qualityColors[0];
			if(quality >= qualityColors.Length) return qualityColors[qualityColors.Length - 1];
			return qualityColors[quality];
//			local arr = {"#FFFFFFFF", "#5AB7DDFF", "#D216D5FF"}
		}
	}
}