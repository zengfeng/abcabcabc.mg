using UnityEngine;
using System.Collections;
using CC.Runtime;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{

	/** 建筑--城池--属性配置 */
	[ConfigPath("Config/stage_weight",ConfigType.CSV)]
	public class StageWeightConfig :ScriptableObject, IParseCsv, IKey<int>
	{
		public int id;

		/** 产兵速度 */
		public float produceSpeed = 1;
		/** 升级时间倍数 */
		public float uplevelTime = 1;
		/** 势力经验乘的倍数 */
		public float legionExpMultiply = 1f;
		/** 技能生产速度 */
		public float skillProduceSpeed = 1f;
		/** 移动速度 */
		public float moveSpeed = 1f;



		public int Key
		{
			get
			{
				return id;
			}
		}

		public void ParseCsv(string[] csv)
		{
			int i = 0;
			id =  csv.GetInt32(i ++ );
			produceSpeed = csv.GetSingle( i ++);
			uplevelTime = csv.GetSingle( i ++);
			legionExpMultiply = csv.GetSingle( i ++);
			skillProduceSpeed = csv.GetSingle( i ++);
			moveSpeed = csv.GetSingle( i ++);

			War.model.AddWeightConfig(this);

		}

		public override string ToString ()
		{
			return string.Format ("[StageWeightConfig: Key={0},  produceSpeed={1}, uplevelTime={2}, legionExpMultiply={3}]", Key, produceSpeed, uplevelTime, legionExpMultiply);
		}
	}

}