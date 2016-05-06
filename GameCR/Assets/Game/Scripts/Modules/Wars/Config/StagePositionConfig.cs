using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using CC.Runtime;
using Games.Module.Props;


namespace Games.Module.Wars
{
	
	/** 关卡--坐标位置配置 */
	[ConfigPath("Config/stage_position",ConfigType.CSV)]
	public class StagePositionConfig : IParseCsv, IKey<int>
	{
		
		/** 关卡编号 */
		public int 		stageId;
		/** 建筑编号 */
		public int 		index;
		/** 坐标 */
		public Vector3 		position = Vector3.zero;
		/** 初始兵力 (-1通过公式计算；其他直接读配置) */
		public float 		hp;
		/** 势力ID */
		public int   		legionId;
		/** 单位类型 */
		public UnitType   	unitType;
		/** 建筑类型 */
		public BuildType   	buildType;
		/** 建筑等级 */
		public int   		level;
		/** 不同类型，建筑数据UID */
		public int   		buildUid;
		/** 英雄上阵优先级 */
		public int 			settledPriority;

		public string		name = "";
		public string		stageName = "";

		public BuildConfig buildConfig
		{
			get
			{
				if(unitType == UnitType.Build)
				{
					return War.model.GetBuildConfig(buildUid);
				}

				return null;
			}
		}




		public StagePositionConfig Clone()
		{
			StagePositionConfig item  = new StagePositionConfig();


			
			/** 关卡编号 */
			item.stageId	= stageId;
			/** 建筑编号 */
			item.index		= index;
			/** 坐标 */
			item.position		= position.Clone();
			/** 初始兵力 (-1通过公式计算；其他直接读配置) */
			item.hp		= hp;
			/** 势力ID */
			item.legionId		= legionId;
			/** 单位类型 */
			item.unitType		= unitType;
			/** 建筑类型 */
			item.buildType		= buildType;
			/** 建筑等级 */
			item.level			= level;
			/** 不同类型，建筑数据UID */
			item.buildUid		= buildUid;
			/** 英雄上阵优先级 */
			item.settledPriority = settledPriority;

			item.name			= name;
			item.stageName		= stageName;
			
			
			return item;
		}



		public int avatarId
		{
			get
			{
				if(unitType == UnitType.Build)
				{
					// TODO NewWar
//					switch(buildType)
//					{
//					case BuildType.Casern:
//						BuildCasernConfig casernConfig = War.model.GetBuildCasernConfig(buildUid);
//						return casernConfig.avatarId;
//						break;
//					case BuildType.Turret:
//						BuildTurretConfig turrentConfig = War.model.GetBuildTurretConfig(buildUid);
//						return turrentConfig.avatarId;
//						break;
//					case BuildType.Spot:
//						BuildSpotConfig spotConfig = War.model.GetBuildSpotConfig(buildUid);
//						return spotConfig.avatarId;
//						break;
//					}
				}
				else if(unitType == UnitType.Wall)
				{
					BuildWallConfig wallConfig = War.model.GetBuildWallConfigg(buildUid);
					return wallConfig.avatarId;
				}
				return 0;
			}
		}











		
		public int Key
		{
			get
			{
				return stageId * 100 + index;
			}
		}


		
		
		//		关卡编号	建筑编号	X坐标	Y坐标	人口配置	势力ID	建筑类型	建筑等级	建筑参数	武将配置	备注	备注
		//			stageId	buldIndex	X	y	hp	legionId	type	buldLeve	typeUid	heroMonster	ps2	ps1
		
		public void ParseCsv(string[] csv)
		{
			int i = 0;
			// 关卡编号
			stageId =  csv.GetInt32(i ++ );
			// 建筑编号
			index =  csv.GetInt32(i ++ );
			// X坐标
			position.x =  csv.GetSingle(i ++ );
			// Z坐标
			position.z =  csv.GetSingle(i ++ );
			// 人口配置
			hp =  csv.GetSingle(i ++ );
			// 势力ID
			legionId =  csv.GetInt32(i ++ );
			// 单位类型
			unitType =  (UnitType)csv.GetInt32(i ++ );
			// 建筑类型
			buildType =  (BuildType)csv.GetInt32(i ++ );
			// 建筑等级
			level =  csv.GetInt32(i ++ );
			// 不同类型，建筑数据UID
			buildUid =  csv.GetInt32(i ++ );
			// 英雄上阵优先级
			settledPriority =  csv.GetInt32(i ++ );

			name = csv.GetString(i ++);
			stageName = csv.GetString(i ++);
			
			
			War.model.AddStagePositionConfig(this);
		}
		
		public override string ToString ()
		{
			return string.Format ("[StagePositionConfig: stageId={0}, buldIndex={1}  position={2},  hp={3}, legionId={4}, buildType={5}, buildUid={6}]",
			                      stageId, index, position, hp, legionId, buildType, buildUid);
		}


		public string ToCsv()
		{
//			关卡编号	建筑编号	X坐标	Y坐标	人口配置	势力ID	单位类型	建筑类型	建筑等级	建筑参数	英雄上阵优先级	备注	备注
//			stageId	buldIndex	X	y	hp	legionId	unitType	buildType	buldLeve	typeUid	settledPriority	ps2	ps1

			string csv = "";
			csv += stageId + ";";
			csv += index + ";";
			csv += position.x + ";";
			csv += position.z + ";";
			csv += hp + ";";
			csv += legionId + ";";
			csv += (int)unitType + ";";
			csv += (int)buildType + ";";
			csv += level + ";";
			csv += buildUid + ";";
			csv += settledPriority + ";";
			csv += name + ";";
			csv += stageName ;

			return csv;
		}
		
	}

}
