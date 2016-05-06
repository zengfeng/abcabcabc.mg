using UnityEngine;
using System.Collections;
using CC.Runtime;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	/** 胜利条件 */
	[ConfigPath("Config/stage_win",ConfigType.CSV)]
	public class WinConfig : IParseCsv, IKey<int>
	{
		/** id */
		public int id;
		/** 胜利条件类型 */
		public WinType winType;
		/** 描述 */
		public string description;
		/** 进程描述 */
		public string processDescription;
		/** 奖励类型 */
		public int itemId;
		/** 参数 */
		public float[] parametersA = new float[]{};
		/** 参数 */
		public float[] parametersB = new float[]{};
		/** 参数 */
		public float[] parametersC = new float[]{};

		/** 占领--建筑ID列表 */
		public int[] t1_builds;
		/** 占领--持续时间 */
		public float t1_time = 30;

		
		/** 参数A */
		public float paramA = 0.125f;
		/** 参数B */
		public float paramB = 3;

		/** avatar */
		public int[] avatar = new int[]{};


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
			// id
			id = csv.GetInt32(i ++ );
			// 胜利条件类型
			winType = (WinType) csv.GetInt32(i ++ );
			// 描述
			description = csv.GetString(i ++ );
			// 进程描述
			processDescription = csv.GetString(i ++ );
			// 参数
			parametersA =  csv.GetFloatArray(i ++ );
			// 参数
			parametersB =  csv.GetFloatArray(i ++ );
			// item
			itemId = csv.GetInt32(i ++ );
			// 参数A
			paramA =  csv.GetSingle(i ++ );
			// 参数A
			paramB=  csv.GetSingle(i ++ );

			if(winType == WinType.T1_Occupy)
			{
				t1_builds = parametersA.ToIntArray();
				t1_time = parametersB[0];
			}

			// avatar
			avatar = csv.GetInt32Array(i ++ );
			
			War.model.AddWinConfig(this);
		}



		public override string ToString ()
		{
			return string.Format ("[StarConfig: id={0}, winType={1}, description={2}, parametersA={3}, parametersB={4}]", Key, winType, description, parametersA.ToStr(), parametersB.ToStr());
		}
	}
}