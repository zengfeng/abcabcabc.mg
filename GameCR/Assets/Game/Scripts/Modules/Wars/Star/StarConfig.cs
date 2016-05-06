using UnityEngine;
using System.Collections;
using CC.Runtime;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	/** 星级评价配置 */
	[ConfigPath("Config/stage_star",ConfigType.CSV)]
	public class StarConfig : IParseCsv, IKey<int>
	{
		/** id */
		public int id;
		/** 星星类型 */
		public StarType starType;
		/** 描述 */
		public string description;
		/** 进程描述 */
		public string processDescription;
		/** 参数 */
		public int[] parameters = new int[]{};

		
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
			// 星星类型
			starType = (StarType) csv.GetInt32(i ++ );
			// 描述
			description = csv.GetString(i ++ );
			// 进程描述
			processDescription = csv.GetString(i ++ );
			// 参数
			parameters =  csv.GetInt32Array(i ++ );

			
			War.model.AddStarConfig(this);
		}

		public string Description
		{
			get
			{
				return string.Format(description, parameters.ToObjectArray());
			}
		}

		public override string ToString ()
		{
			return string.Format ("[StarConfig: id={0}, starType={1}, Description={2}]", Key, starType, Description);
		}
	}
}