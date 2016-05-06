using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using CC.Runtime;

namespace Games.Module.Wars
{
	/** 关卡--地图资源 */
	[ConfigPath("Config/stage_map",ConfigType.CSV)]
	public class MapConfig : IParseCsv, IKey<int>
	{
		/** 编号 */
		public int 			id;
		/** 名称 */
		public string 		name;
		/** 地图图片 */
		public string 		terrain;
		/** 建筑地表 */
		public string		buildGround;

		
		public int Key
		{
			get
			{
				return id;
			}
		}
		
		
		
		
//			编号	名称	地图图片	建筑地表
//			id	name	terrain	build_ground

		public void ParseCsv(string[] csv)
		{
			ParseCsv(csv, true);
		}

		public void ParseCsv(string[] csv, bool addModel = true)
		{
			int i = 0;
			// 编号
			id =  csv.GetInt32(i ++ );
			// 名称
			name =  csv.GetString(i ++ );
			// 地图图片
			terrain =  csv.GetString(i ++ );
			// 建筑地表
			buildGround =  csv.GetString(i ++ );
			
			if(addModel)
			{
				War.model.AddMapConfig(this);
			}
		}
		
		public override string ToString ()
		{
			return string.Format ("[MapConfig: id={0}, name={1}  terrain={2},  buildGround={3}]",
			                      id, name, terrain, buildGround);
		}
	}

}