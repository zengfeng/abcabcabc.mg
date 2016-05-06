using UnityEngine;
using System.Collections;


namespace Games.Module.Wars
{
	/// <summary>
	/// <c>WarProcessState</c> 战斗流程状态
	/// </summary>
	public enum WarProcessState
	{
		/** 未知 */
		None,
		/** 游戏退出 */
		Exit,
		/** 生成数据 */
		GenerateData,
		/** 加载中 */
		Loading,
		/** 安装中 */
		Installing,
		/** 游戏进行中 */
		Gameing,
		/** 游戏结束 */
		GameOver,
	}
}
