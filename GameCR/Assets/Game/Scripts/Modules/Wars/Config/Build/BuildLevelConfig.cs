using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using CC.Runtime;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	[ConfigPath("Config/build",ConfigType.CSV)]
	public class BuildLevelConfig : AbstractBuildLevelConfig
	{
		/** 基础属性ID */
		public int basepropId;
		/** 生产ID */
		public int produceId;
		/** 箭塔ID */
		public int turretId;
		/** 据点ID */
		public int spotId;


		public override void ParseCsv (string[] csv)
		{
//			编号	名称	建筑类型	建筑Avatar	等级	升级需要人口	升级需要时间	基本属性配置	箭塔配置	据点配置
//			id	name	buildType	buildAvatar	level	uplevelRequireHP	uplevelRequireTime	basepropId	turretId	spotId

			int i = 0;
			// ID
			id = csv.GetInt32(i ++);
			// 名称
			name = csv.GetString(i ++);
			// 建筑类型
			buildType = (BuildType) csv.GetInt32(i ++);
			// 建筑Avatar
			avatarId = csv.GetInt32(i ++);
			// 等级
			level = csv.GetInt32(i ++);
			// 升级需要人口
			uplevelRequireHP = csv.GetSingle(i ++);
			// 升级需要时间
			uplevelRequireTime = csv.GetSingle(i ++);
			// 基本属性配置
			basepropId = csv.GetInt32(i ++);
			// 生产ID
			produceId = csv.GetInt32(i ++);
			// 箭塔ID
			turretId = csv.GetInt32(i ++);
			// 据点ID
			spotId = csv.GetInt32(i ++);

//			Debug.Log(this);

			War.model.AddBuildLevelConfig(this);

		}


		
		
		public BuildBasepropConfig basepropConfig
		{
			get
			{
				return War.model.GetBuildBasepropConfig(basepropId);
			}
		}
		
		public BuildProduceConfig produceConfig
		{
			get
			{
				return War.model.GetBuildProduceConfig(produceId);
			}
		}
		
		public BuildTurretConfig turretConfig
		{
			get
			{
				return War.model.GetBuildTurretConfig(turretId);
			}
		}
		
		public BuildSpotConfig spotConfig
		{
			get
			{
				return War.model.GetBuildSpotConfig(spotId);
			}
		}


		
		public List<string> GetResList(List<string> list, int[] colorIds)
		{
			if(avatarConfig != null)
			{
				avatarConfig.GetResList(list, colorIds);
			}
			
			
			if(turretConfig != null && turretConfig.avatarConfig != null)
			{
				turretConfig.avatarConfig.GetResList(list, colorIds);
			}
			
			
			if(spotConfig != null && spotConfig.avatarConfig != null)
			{
				spotConfig.avatarConfig.GetResList(list, colorIds);
			}
			
			return list;
		}

		public override string ToString ()
		{
			return string.Format ("[BuildLevelConfig: id={3}, name={4}, buildType={5}, level={6}, uplevelRequireHP={7}, uplevelRequireTime={8}, avatarId={9} basepropConfig={0}, turretConfig={1}, spotConfig={2}]", basepropConfig, turretConfig, spotConfig,
			                      id, name, buildType, level, uplevelRequireHP, uplevelRequireTime, avatarId);
		}

	}

}