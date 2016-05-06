using UnityEngine;
using System.Collections;
using CC.Runtime;


namespace Games.Module.Wars
{
	public class AbstractBuildLevelConfig : AbstractBuildConfig
	{
		/** 等级 */
		public int level;
		/** 升级需要人口 */
		public float uplevelRequireHP;
		/** 升级需要时间 */
		public float uplevelRequireTime;

	}
}
