using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games.Cores;
using Games.Module.Props;
using System.Linq;
using CC.Runtime.Utils;
using Newtonsoft.Json;

namespace Games.Module.Wars
{
	/** 战场数据 */
	public class SceneData
	{
		public StageWeightConfig weight = new StageWeightConfig();

		public StagePathData pathData;
		public void InitPathData()
		{
            if (War.isEditor)
            {
                return;
            }

            if (War.model.stagePaths.ContainsKey(id))
			{
				pathData = War.model.stagePaths[id];
			}
			else
			{
				object asset = WarRes.GetRes<object>(StagePathData.GetFilePath(id));
//				Debug.Log(asset);
				pathData = JsonConvert.DeserializeObject(asset.ToString(), typeof(StagePathData)) as StagePathData;
				pathData.PointToVector3();

				War.model.stagePaths[id] = pathData; 
			}
		}


		//============================================
		/** 是否显示势力消息 */
		public bool visiableLegionLevelMsg = true;
		/** 是否可以升级 */
		public bool enableUplevel = true;
		/** 是否可以产兵 */
		public bool enableProduce = true;
		/** 是否可以生产技能 */
		public bool enableProduceSkill = true;
		/** 是否可以运行时间 */
		public bool enableTime = true;
		/** 是否AI可以发兵 */
		public bool enableAISendArm = true;
		/** 是否AI可以升级 */
		public bool enableAIUplevel = true;
		/** 是否AI可以使用技能 */
		public bool enableAISkill = true;
		/** 开始时间 */
		public int begionDelayTime = 0;
		/** 势力总兵力 */
		public float legionTotalMaxHP = 100;
		//============================================

		public int[] colorIds = new int[]{};


		public Dictionary<int, float[]> buildFirstProp = new Dictionary<int, float[]>();
		public Dictionary<int, float[]> buildInitProp = new Dictionary<int, float[]>();
		
		public Dictionary<int, AttachPropData> buildFirstAttachPropData = new Dictionary<int, AttachPropData>();
		public Dictionary<int, AttachPropData> buildInitAttachPropData = new Dictionary<int, AttachPropData>();

		public Dictionary<int, BuildSpotConfig> buildSpotConfigDict = new Dictionary<int, BuildSpotConfig>();
		public Dictionary<int, AttachPropData>  buildSpotAttachPropData = new Dictionary<int, AttachPropData>();

		public void InitAttachPropData()
		{
			
			AttachPropData attachPropData;
			foreach(KeyValuePair<int, float[]> kvp in buildFirstProp)
			{
				
				attachPropData = new AttachPropData(kvp.Value.FilterZero());
				buildFirstAttachPropData.Add(kvp.Key, attachPropData);
			}

			
			foreach(KeyValuePair<int, float[]> kvp in buildInitProp)
			{
				
				attachPropData = new AttachPropData(kvp.Value.FilterZero());
				buildInitAttachPropData.Add(kvp.Key, attachPropData);
			}

			foreach(KeyValuePair<int, BuildSpotConfig> kvp in buildSpotConfigDict)
			{
				
				attachPropData = new AttachPropData(kvp.Value.props);
				buildSpotAttachPropData.Add(kvp.Key, attachPropData);
			}
		}

		public void InitAttachPropData(int index)
		{
			
			AttachPropData attachPropData;
			if(buildFirstProp.ContainsKey(index))
			{
				attachPropData = new AttachPropData(buildFirstProp[index].FilterZero());
				buildFirstAttachPropData.Add(index, attachPropData);
			}

			if(buildInitProp.ContainsKey(index))
			{
				attachPropData = new AttachPropData(buildInitProp[index].FilterZero());
				buildInitAttachPropData.Add(index, attachPropData);
			}

			
			
			if(buildSpotConfigDict.ContainsKey(index))
			{
				attachPropData = new AttachPropData(buildSpotConfigDict[index].props);
				buildSpotAttachPropData.Add(index, attachPropData);
			}

		}



		//---------------------------------
		public int id;
		/** 关卡配置 */
		public StageConfig 	stageConfig;
		/* 地图配置 */
		public MapConfig	mapConfig;

		/** 自己势力数据 */
		public int ownLegionID;
		public LegionData ownLegion;
		/** 势力数据 */
		public Dictionary<int, LegionData> roleDict = new Dictionary<int, LegionData>();
		/** 势力数据 */
		public Dictionary<int, LegionData> legionDict = new Dictionary<int, LegionData>();
		/** 势力联盟数据 */
		public Dictionary<int, LegionGroupData> legionGroupDict = new Dictionary<int, LegionGroupData>();
		/** 墙数据UnitData */
		public Dictionary<int, UnitData> wallDict = new Dictionary<int, UnitData>();
		/** 建筑数据UnitData */
		public Dictionary<int, UnitData> buildDict = new Dictionary<int, UnitData>();
		/** 兵营上对应的英雄数据HeroData (主要用于 兵营初始血量计算 判断是否有英雄) */
		public Dictionary<int, HeroData> herosByBuild = new Dictionary<int, HeroData>();
		/** 是否显示敌方势力血条 */
		public bool showHP;

		public Dictionary<int, SkillOperateData> skillOperateDataForUID = new Dictionary<int, SkillOperateData>();
		
		/** 获取 建筑第一次初始化属性[Hp] */
		public AttachPropData GetBuildFistProps(int index)
		{
			AttachPropData props;
			if(buildFirstAttachPropData.TryGetValue(index, out props))
			{
				return props;
			}

			return null;
		}

		/** 获取 建筑初始建筑类型属性 */
		public AttachPropData GetBuildInitProps(int index)
		{
			AttachPropData props;
			if(buildInitAttachPropData.TryGetValue(index, out props))
			{
				return props;
			}
			
			return null;
		}

		public SkillOperateData GetSkillOperateData(int skillUID)
		{
			SkillOperateData data = null;
			if(skillOperateDataForUID.TryGetValue(skillUID, out data))
			{
				return data;
			}
			return null;
		}

		
		//---------------------------------


		public int GetSoliderUID(int from, int to, int num, int legion)
		{
			int uid = 10000000 * legion + from * 100000 + to * 1000 + num;
//			Debug.Log(string.Format("<color=yellow> from={0}, to={1}, num={2},   uid={3} </color>", from, to, num, uid));
			return uid;
		}

		
		public int GetPlayerUID(int legionId)
		{
			return 100 + legionId;
		}
		
		
		public int GetHeroUID(int heroId, int legionId)
		{
			//Debug.Log("heroId="  + heroId);
			//			return heroId;
			return legionId * 100000 + heroId;
		}

		public int GetSkillUID(int skillId, int legionId, int heroId)
		{
			return legionId * 10000000 + heroId * 100 + skillId;
		}

	}
}