using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	/** 引导步奏数据--屏幕遮罩--绘制 */
	public class GuideStepData_ScreenMaskDraw : GuideStepData
	{
		public GuideScreenMaskDrawType drawType;

		/** 建筑 */
		public int buildId;

		/** 发兵 */
		public int fromBuildId;
		public int toBuildId;

		/** 位置 */
		public Vector3 worldPosition;


		/** 区域 */
		public Rect rect;

		public GuideStepData_ScreenMaskDraw()
		{
			SetData(GuideStepType.War_ScreenMask_Draw, GuideStepCompleteType.NextFrame, "屏幕遮罩--绘制");
		}

		/** 建筑 */
		public GuideStepData_ScreenMaskDraw DrawBuild(int buildID)
		{
			drawType = GuideScreenMaskDrawType.Build;
			this.buildId = buildID;

			this.describe = "屏幕遮罩--绘制--建筑";

			return this;
		}

		/** 发兵 */
		public GuideStepData_ScreenMaskDraw DrawSendArm(int from, int to)
		{
			drawType = GuideScreenMaskDrawType.SendArm;
			this.fromBuildId = from;
			this.toBuildId = to;
			this.describe = "屏幕遮罩--绘制--发兵";
			return this;
		}


		/** 位置 */
		public GuideStepData_ScreenMaskDraw DrawPosition(Vector3 worldPosition)
		{
			drawType = GuideScreenMaskDrawType.Position;
			this.worldPosition = worldPosition;
			this.describe = "屏幕遮罩--绘制--位置";
			return this;
		}

//		/** 区域 */
//		public void DrawRect(Rect rect)
//		{
//			drawType = GuideScreenMaskDrawType.Rect;
//			this.rect = rect;
//			this.describe = "屏幕遮罩--绘制--区域";
//		}


		/** 重置并显示 */
		public GuideStepData_ScreenMaskDraw ResetAndShow()
		{
			drawType = GuideScreenMaskDrawType.ResetAndShow;
			this.describe = "屏幕遮罩--绘制--重置并显示";
			return this;
		}


		/** 关闭 */
		public GuideStepData_ScreenMaskDraw Hide()
		{
			drawType = GuideScreenMaskDrawType.Hide;
			this.describe = "屏幕遮罩--绘制--关闭";
			return this;
		}
	}
}