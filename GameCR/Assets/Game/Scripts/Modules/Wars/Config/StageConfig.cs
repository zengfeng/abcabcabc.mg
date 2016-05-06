using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.Utils;
using CC.Runtime;
using Newtonsoft.Json;
using System;

namespace Games.Module.Wars
{


	/** 关卡--势力联盟配置 */
	public class StageLegionGroupConfig
	{
		/** 势力联盟编号 */
		public int id;
		/** 势力列表 */
		public List<StageLegionConfig> list = new List<StageLegionConfig>();
		
	}
	
	/** 关卡--势力配置 */
	public class StageLegionConfig
	{
		/** 联盟编号 */
		public int groupId;
		
		/** 势力编号 */
		public int legionId;
		/** 势力类型 */
		public LegionType type;
		/** 势力颜色 */
		public int color;
		
		/** 兵营是否产兵 */
		public bool produce;
		/** 是否自动升级 */
		public bool aiUplevel;
		/** 是否自动派兵 */
		public bool aiSendArm;
		/** 是否自动使用技能 */
		public bool aiSkill;
		/** 兵营生产是否上限 */
		public bool produceLimit = false;
		/** 机器人ID */
		public int robotId;






		public StageLegionConfig Clone()
		{
			StageLegionConfig item  = new StageLegionConfig();
			
			item.groupId = groupId;
			/** 势力编号 */
			item.legionId	= legionId;
			/** 势力类型 */
			item.type	= type;
			/** 势力颜色 */
			item.color	= color;
			
			/** 兵营是否产兵 */
			item.produce	= produce;
			/** 是否自动升级 */
			item.aiUplevel	= aiUplevel;
			/** 是否自动派兵 */
			item.aiSendArm	= aiSendArm;
			/** 是否自动使用技能 */
			item.aiSkill	= aiSkill;
			/** 兵营生产是否上限 */
			item.produceLimit	= produceLimit;
			/** 机器人ID */
			item.robotId	= robotId;


			return item;
		}
	}

	/** 玩家兵营位置推荐英雄 */
	public class StageHeroConfig
	{
		/** 位置编号 */
		public int buildIndex;
		/** 武将职业编号  */
		public int heroType;
		/** 位置权重  */
		public int heroWeight;
	}

	/** 关卡配置 */
	[ConfigPath("Config/stage", ConfigType.CSV)]
	public class StageConfig : IParseCsv, IKey<int>
	{

		public int id;
		/** 关卡等级 */
		public int level;
		/** 名称 */
		public string name;
		/** 描述 */
		public string description;
		/** 关卡类型 */
		public StageType type;
		/**  */
        public int nextStageId;
		/** 美术资源编号 */
		public int resource;
		/** 胜利条件 */
		public int winId;
		/** Lua */
		public string lua = "";
		/** 消耗体力 */
		public int costStrength;
		/** 限时 */
		public float time;
		/** sos */
		public bool sos;
		/** 是否显示血条 */
		public bool showHP;
		/** 中立主公等级 */
		public int neutralRoleLevel = 0;
		/** 星级评价 */
		public int[] stars = new int[]{};
		/** 掉落编号 */
		public int dropId;
		/** 势力关系 */
		public List<StageLegionGroupConfig> legionGroups = new List<StageLegionGroupConfig>();
		/** 势力列表 */
		public Dictionary<int, StageLegionConfig> legionDict = new Dictionary<int, StageLegionConfig>();
		/** 建筑列表 */
		public Dictionary<int, StagePositionConfig> buildDict = new Dictionary<int, StagePositionConfig>();
		/** 墙列表 */
		public Dictionary<int, StagePositionConfig> wallDict = new Dictionary<int, StagePositionConfig>();
		/** 默认自己势力ID */
		public int defaultMyTeam = 1;

		public WinConfig winConfig
		{
			get
			{
				if(winId > 0 ) return War.model.GetWinConfig(winId);
				return null;

			}
		}
		public MapConfig mapConfig
		{
			get
			{
				if(resource > 0) return  War.model.GetMapConfig(resource);
				return null;
			}
		}



		public StageConfig Clone()
		{
			StageConfig item  = new StageConfig();
			item.id 	= id;
			/** 关卡等级 */
			item.level 	= level;
			/** 名称 */
			item.name 	= name;
			/** 描述 */
			item.description 	= description;
			/** 关卡类型 */
			item.type 	= type;
			/**  */
			item.nextStageId 	= nextStageId;
			/** 美术资源编号 */
			item.resource 	= resource;
			/** 胜利条件 */
			item.winId 	= winId;
			/** Lua */
			item.lua 	= lua;
			/** 消耗体力 */
			item.costStrength 	= costStrength;
			/** 限时 */
			item.time 	= time;
			/** sos */
			item.sos 	= sos;
			/** 是否显示血条 */
			item.showHP 	= showHP;
			/** 中立主公等级 */
			item.neutralRoleLevel 	= neutralRoleLevel;
			/** 星级评价 */
			item.stars 	= new List<int>(stars).ToArray();
			/** 掉落编号 */
			item.dropId 	= dropId;

			
			/** 势力列表 */
			foreach(var legionConfig in legionDict)
			{
				item.legionDict.Add(legionConfig.Key, legionConfig.Value.Clone());
			}

			
			/** 势力关系 */
			foreach(StageLegionGroupConfig source in legionGroups)
			{
				StageLegionGroupConfig dist = new StageLegionGroupConfig();
				dist.id = source.id;
				foreach(StageLegionConfig legionConfig in source.list)
				{
					dist.list.Add(item.legionDict[legionConfig.legionId]);
				}

				item.legionGroups.Add(dist);
			}

			/** 建筑列表 */
			foreach(var positionConfig in buildDict)
			{
				item.buildDict.Add(positionConfig.Key, positionConfig.Value.Clone());
			}
			/** 墙列表 */

			foreach(var positionConfig in wallDict)
			{
				item.wallDict.Add(positionConfig.Key, positionConfig.Value.Clone());
			}

			/** 默认自己势力ID */
			item.defaultMyTeam 	= defaultMyTeam;


			return item;
		}

		
		public int Key
		{
			get
			{
				return id;
			}
		}

	



		public void ParseCsv(string[] csv)
		{

			//编号	名称	描述	关卡类型	解锁关卡	美术资源编号	掉落编号	星级评价	胜利条件	挂载脚本	消耗体力	限时	sos	关卡等级	血条开关	上阵武将数量	联盟关系
            //id	name	description	type	nextStageId	resource	dropID	stars	win	luaID	costStrength	time	sos	level	showHP	playerHeroNo	LegionRelation

			int i = 0;
			id = csv.GetInt32(i++);
			// 名称
			name = csv.GetString(i++);
			// 描述
			description = csv.GetString(i++);
			// 关卡类型
            type = (StageType)csv.GetInt32(i++);
            // 解锁关卡
            nextStageId =csv.GetInt32(i++);
			// 美术资源编号
			resource = csv.GetInt32(i++);
			// 掉落编号
			dropId = csv.GetInt32(i++);
			// 星级评价
			stars = csv.GetInt32Array(i++);
			// 胜利条件
			winId = csv.GetInt32(i++);
			// 挂载脚本
			lua = csv.GetString(i++);
			// 消耗体力
			costStrength = csv.GetInt32(i++);
			// 限时
			time = csv.GetSingle(i++);
			// SOS
			sos = csv.GetBoolean(i++);

//			Debug.Log(string.Format("<color=blue>id={0}, name={1} stars={2}</color>", id, name, stars.ToStr()));
			// 关卡等级
			level = csv.GetInt32(i++);
			// 是否显示血条
			showHP = csv.GetInt32(i++) == 1;
			// 中立主公等级
			neutralRoleLevel = csv.GetInt32(i++);
			// 势力关系
			ParseTeamGroup(csv.GetString(i++));





			// 势力列表
			ParseLegions(csv, i, -1);

			// 生成位置数据
			GenerationPositionData();

			War.model.AddStageConfig(this);
		}

		/** 生成建筑数据 */
		public void GenerationPositionData()
		{
			buildDict.Clear();
			wallDict.Clear();

			List<StagePositionConfig> list = War.model.GetStagePositionConfigList(id);
			foreach(StagePositionConfig item in list)
			{
				StageLegionConfig legionConfig;
				if (!legionDict.TryGetValue(item.legionId, out legionConfig))
				{
					Debug.LogError(string.Format("legionId not found , stageId = {0}, legionId = {1}", item.stageId, item.legionId));
				}
				if(legionConfig == null)
				{
					Debug.Log(string.Format("<color=red>关卡stageId={0} , 建筑buildIndex={1}.配置的势力legionId={2}不存在</color>", id, item.index, item.legionId));
				}


				if(item.unitType == UnitType.Build)
				{
					if(buildDict.ContainsKey(item.index))
					{
						Debug.Log(string.Format("<color=red>关卡stageId={0}，存在多个相同的建筑StagePositionConfig index={1} </color>", id, item.index));
					}

					buildDict.Add(item.index, item);
				}
				else if(item.unitType == UnitType.Wall)
				{
					if(buildDict.ContainsKey(item.index))
					{
						Debug.Log(string.Format("<color=red>关卡stageId={0}，存在多个相同的建筑StagePositionConfig index={1} </color>", id, item.index));
					}
					wallDict.Add(item.index, item);
				}

			}
		}

		void ParseTeamGroup(string str)
		{
			string[] groupstrs = str.Split(',');
			int groupId = 0;
			foreach(string groupstr in groupstrs)
			{
				if(string.IsNullOrEmpty(groupstr)) continue;

				StageLegionGroupConfig groupConfig = new StageLegionGroupConfig();
				groupConfig.id = groupId ++;
				legionGroups.Add(groupConfig);

				string[] teamstrs = groupstr.Split(':');
				foreach(string teamstr in teamstrs)
				{
					if(string.IsNullOrEmpty(teamstr)) continue;
					
					int teamId = teamstr.ToInt32();
					if(!legionDict.ContainsKey(teamId))
					{
						StageLegionConfig teamConfig = new StageLegionConfig();
						teamConfig.legionId = teamId;
						teamConfig.groupId = groupConfig.id;
						legionDict.Add(teamConfig.legionId, teamConfig);
						groupConfig.list.Add(teamConfig);
					}
				}
			}
		}
	

		void ParseLegions(string[] csv, int begin, int end)
		{

//			势力0	势力0类型	势力0颜色	开放功能0	机器人ID
//			legion	legionType	color	produce	robotId


			int length = end == -1 ? csv.Length - begin :  end - begin + 1;
			int index = begin;
			for(int i = 0; i < length; i += 5)
			{
				ParseLegion(csv, index);
				index += 5;
			}
			 
		}

		
		void ParseLegion(string[] csv, int begin)
		{
			int i = begin;
			if(string.IsNullOrEmpty(csv[i])) 
			{
				return;
			}

			// 势力--ID
			int legionId = csv.GetInt32(i ++);


			StageLegionConfig legionConfig;
			if(!legionDict.TryGetValue(legionId, out legionConfig))
			{
				legionConfig = new StageLegionConfig();
				legionConfig.legionId = legionId;
				legionDict.Add(legionConfig.legionId, legionConfig);
			}
			
			// 势力--类型 (0=野城, 1=玩家, 2=电脑敌人)
			legionConfig.type = (LegionType)csv.GetInt32(i ++);
			// 势力--颜色
			legionConfig.color = csv.GetInt32(i ++);
			// 势力--开放功能
			ParseLegionOpens(csv.GetString(i ++), legionConfig);
			// 势力--机器人ID
			legionConfig.robotId = csv.GetInt32(i ++);


			if(legionConfig.type == LegionType.Player)
			{
				defaultMyTeam = legionId;
			}
		}

		void ParseLegionOpens(string str, StageLegionConfig teamConfig)
		{
			string[] infos = str.Split(',');
			int i = 0;
			int produce = infos.GetInt32(i ++ );
			teamConfig.produce = produce > 0;
			teamConfig.produceLimit = produce == 2;
			teamConfig.aiUplevel = infos.GetInt32(i ++ ) == 1;
			teamConfig.aiSendArm = infos.GetInt32(i ++ ) == 1;
			teamConfig.aiSkill = infos.GetInt32(i ++ ) == 1;
		}





		public string ToCsv()
		{
//			编号	名称	描述	关卡类型	解锁关卡	美术资源编号	掉落编号	星级评价	胜利条件	挂载脚本	消耗体力	限时	求救提示	关卡等级	血条开关	中立主公等级	联盟关系	势力0	势力0类型	势力0颜色	开放功能0	机器人ID	势力1	势力1类型	势力1颜色	开放功能1	机器人ID	势力2	势力2类型	势力2颜色	开放功能2	机器人ID	势力3	势力3类型	势力3颜色	开放功能3	机器人ID	势力4	势力4类型	势力4颜色	开放功能4	机器人ID
//			id	name	description	type	nextStageId	resource	dropID	stars	win	luaID	costStrength	time	sos	level	showHP	neutralRoleLevel	LegionRelation	legion	legionType	color	produce	robotId	legion	legionType	color	produce	robotId	legion	legionType	color	produce	robotId	legion	legionType	color	produce	robotId	legion	legionType	color	produce	robotId


			string csv = "";
			csv += id + ";";
			csv += name + ";";
			csv += description + ";";
			csv += (int)type + ";";
			csv += nextStageId + ";";
			csv += resource + ";";
			csv += dropId + ";";
			csv += stars.ToStrCsv() + ";";
			csv += winId + ";";
			csv += lua + ";";
			csv += costStrength + ";";
			csv += time + ";";
			csv += (sos ? 1 : 0) + ";";
			csv += level + ";";
			csv += (showHP ? 1 : 0) + ";";
			csv += neutralRoleLevel + ";";
			csv += ToCsvLegionRelation() + ";";
			csv += ToCsvLegions() ;

			return csv;
		}

		string ToCsvLegionRelation()
		{
			string csv = "";
			string gap = "";
			foreach(StageLegionGroupConfig group in legionGroups)
			{
				csv += gap;

				string itemCsv = "";
				string itemGap = "";
				foreach(StageLegionConfig item in group.list)
				{
					itemCsv += itemGap;
					itemCsv += item.legionId + "";
					itemGap = ":";
				}
				csv += itemCsv;

				gap = ",";
			}

			return csv;
		}

		string ToCsvLegions()
		{
			string csv = "";
			string gap = "";
			for(int i = 0; i < 5; i ++)
			{
				csv += gap;
				csv += ToCsvLegion(i);
				gap = ";";
			}
			return csv;
		}

		string ToCsvLegion(int legionId)
		{
			string csv = "";
			StageLegionConfig legionConfig;
			if(legionDict.TryGetValue(legionId, out legionConfig))
			{
				csv += legionConfig.legionId + ";";
				csv += (int)legionConfig.type + ";";
				csv += legionConfig.color + ";";
				csv += ToCsvLegionOpens(legionConfig) + ";";
				csv += legionConfig.robotId;
			}
			else
			{
				for(int i = 0; i < 4; i ++)
				{
					csv += ";";
				}
			}
			return csv;
		}

		string ToCsvLegionOpens(StageLegionConfig item)
		{
//			产兵，AI升级，AI发兵，AI技能
//				
//				0=不开放/1=开放
//					2只针对产兵，如果产兵选项填2的话表示，会产兵但是有上限(初始兵力上限，而不是总人口或者城池人口上限)，
//					上限值在默认属性表里。

			string csv = "";
			csv += (item.produce ? (item.produceLimit ? 2 : 1) : 0) + ",";
			csv += (item.aiUplevel ? 1 : 0) + ",";
			csv += (item.aiSendArm ? 1 : 0) + ",";
			csv += (item.aiSkill ? 1 : 0) + ",";
			return csv;
		}


	}
}
;