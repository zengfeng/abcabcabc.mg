using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using CC.Runtime;
using Games.Module.Props;


namespace Games.Module.Wars
{
	/** 建筑--据点--属性配置 */
	[ConfigPath("Config/build_wall",ConfigType.CSV)]
	public class BuildWallConfig : AbstractBuildConfig
	{

		/** 墙类型 */
		public WallType 		wallType;
		/** 长方体大小 */
		public Vector3 	size = Vector3.one;
		/** 角度 */
		public float 	angle = 0;
		/** 球半径 */
		public float 	radius;

		
		override public void ParseCsv(string[] csv)
		{
			int i = 0;
			// 编号
			id =  csv.GetInt32(i ++ );
			// 素材
			avatarId =  csv.GetInt32(i ++ );
			// 墙类型
			wallType = (WallType)csv.GetInt32(i ++);
			// 长
			size.x = csv.GetSingle(i ++);
			// 宽
			size.z = csv.GetSingle(i ++);
			// 角度
			angle = csv.GetSingle(i ++);
			//球半径
			radius = csv.GetSingle(i ++);
			// 名称
			name =  csv.GetString(i ++ );

			
			War.model.AddBuildWallConfig(this);
		}
		
		public override string ToString ()
		{
			return string.Format ("[BuildWallConfig: id={0}, name={1}  avatarId={2},  wallType={3}, size={4}, radius={5}]",
			                      id, name, avatarId, wallType, size, radius);
		}
		
	}


}
