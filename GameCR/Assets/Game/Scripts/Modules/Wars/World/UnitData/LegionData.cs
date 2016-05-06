using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games.Module.Props;
using System;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{


	/** 势力数据 */
	public class LegionData 
	{
		public LegionLevelData levelData;

		public int roleId;
		/** 势力ID */
		public int legionId;
		/** 势力名称 */
		public string name;
		// 势力头像ID
		public int  headAvatarId = 80001;
		/** 势力类型 (玩家，电脑，野外) */
		public LegionType type;
		/** 是否自动派兵 */
		public bool aiSendArm;
		/** 是否自动升级 */
		public bool aiUplevel;
		/** 是否自动使用技能 */
		public bool aiSkill;
		/** 兵营是否产兵 */
		public bool produce;
		/** 是否限制兵营产兵上限 */
		public bool produceLimit = false;
		/** 是否显示该势力血条 */
		public bool showHP = false;
		/** 该势力联盟数据 */
		public LegionGroupData group;
		/** 势力颜色 */
		public int colorId = WarColor.Gray;
		/** 发兵百分比 */
		public int sendArmRate = 100;
		/** ai */
		public AIConfig aiConfig;
		/** 总兵力上限 */
		public float totalMaxHP = 0;
		/** 远征--总兵力上限 */
		public float expeditionTotalMaxHP = 0;
		/** 远征--初始总兵力 */
		public float expeditionInitHP = 0;
		/** 远征--剩余总兵力 */
		public float expeditionTotalHP = 0;
		/** 远征--剩余可生产兵力 */
		public float expeditionLeftHP = 0;

		
		/** 单位--势力 */
		public PropContainer legionInitPropContainer 	= new PropContainer();
		public PropContainer legionPropContainer 		= new PropContainer();
		public float[]		 legionInitProp = new float[PropId.MAX];


		/** 单位--士兵 */
		public PropContainer soliderInitPropContainer 	= new PropContainer();
		public PropContainer soliderPropContainer 		= new PropContainer();
		public float[]	     soliderInitProp;

		
		/** 单位--建筑 */
		public PropContainer buildPropContainer 		= new PropContainer();
		public AttachPropData buildInitAttachPropData;
		public float[]	     buildInitProp;
		/** 兵营等级属性 （战前属性 + 兵营[1--N]等级叠加的附加属性） */
		public Dictionary<int, Prop[]> casernLevelProp = new Dictionary<int, Prop[]>();
		public Dictionary<int, AttachPropData> casernLevelAttachPropData = new Dictionary<int, AttachPropData>();
		/** 英雄附加给建筑属性 */
		public Dictionary<int, float[]>  hero2BuildProp = new Dictionary<int, float[]>();
		public Dictionary<int, AttachPropData>  hero2BuildAttachPropData = new Dictionary<int, AttachPropData>();
		
		
		/** 单位--英雄 */
		public PropContainer heroPropContainer 		= new PropContainer();
		public Dictionary<int, float[]>  heroInitProp = new Dictionary<int, float[]>();
		public Dictionary<int, AttachPropData>  heroInitAttachPropData = new Dictionary<int, AttachPropData>();



		public void Init()
		{
			soliderInitProp [PropId.InitMoveSpeed] *= War.sceneData.weight.moveSpeed;
			soliderInitProp [PropId.MoveSpeedAdd] *= War.sceneData.weight.moveSpeed;
			soliderInitProp [PropId.MoveSpeedPer] *= War.sceneData.weight.moveSpeed;


			AttachPropData attachPropData;

			// 势力
			attachPropData = new AttachPropData(legionInitProp.FilterZero());
			legionInitPropContainer.Add(attachPropData);


			attachPropData = new AttachPropData(soliderInitProp.FilterZero());
			soliderInitPropContainer.Add(attachPropData);
			
			// 建筑
			buildInitAttachPropData = new AttachPropData(buildInitProp.FilterZero());

			foreach(KeyValuePair<int, Prop[]> kvp in casernLevelProp)
			{
				
				attachPropData = new AttachPropData(kvp.Value);
				casernLevelAttachPropData.Add(kvp.Key, attachPropData);
			}

			foreach(KeyValuePair<int, float[]> kvp in hero2BuildProp)
			{
				
				attachPropData = new AttachPropData(kvp.Value.FilterZero());
				hero2BuildAttachPropData.Add(kvp.Key, attachPropData);
			}

			// 英雄
			foreach(KeyValuePair<int, float[]> kvp in heroInitProp)
			{
				
				attachPropData = new AttachPropData(kvp.Value.FilterZero());
				heroInitAttachPropData.Add(kvp.Key, attachPropData);
//				Debug.Log("英雄heroInitAttachPropData kvp.Key=" + kvp.Key);
			}



			
			soliderInitData = soliderData.Clone();
			soliderPropContainer.UnitApp(soliderInitData);
			soliderInitPropContainer.UnitApp(soliderInitData, true);

			levelData.Init();
			levelData.Level = 1;
		}



		/** 该势力士兵数据UnitData */
		public UnitData soliderData;
		public UnitData soliderInitData;

		/** 兵营升级 需要兵力 */
		public Dictionary<int, float> buildLevelNeedHP = new Dictionary<int, float>();
		/** 英雄单位数据UnitData */
		public Dictionary<int, UnitData> heroUnitDatas = new Dictionary<int, UnitData>();
		/** 英雄数据HeroData */
		public Dictionary<int, HeroData> heroDatas = new Dictionary<int, HeroData>();

		/** 英雄技能操作数据 */
		public Dictionary<int, SkillOperateData> 	skillDatas 					= new Dictionary<int, SkillOperateData>();
		/** 可生的技能列表 */
		public List<int> 							enableProduceSkillUids 		= new List<int>();
		/** 技能条上的技能列表 */
		public List<int> 							barSkillUids 				= new List<int>();
		/** 正在生产的技能 */
		public int									produceSkillUid				= -1 ;
		public SkillOperateData						produceSkillData { get{ return skillDatas[produceSkillUid];} }
		/** 初始化使用的技能 */
		public int									initUseSkillId				= -1;
		/** 初始化使用的技能 目标建筑ID */
		public int									initUseSkillBuildId			= -1;

		/** 根据技能ID获取技能数据 */
		public SkillOperateData GetSkillDataBySkillId(int skillId)
		{
			foreach(var item in skillDatas)
			{
				if(item.Value.skillId == skillId)
				{
					return item.Value;
					break;
				}
			}

			return null;
		}


		/** 兵营AvatarPrefab文件 */
		public string prefabFileForCasern
		{
			get
			{
				return string.Format("Unit_Prefab/Casern/c_01_zhangpeng_{0}", colorId);
			}
		}

		
		/** 据点AvatarPrefab文件 */
		public string prefabFileForSpot
		{
			get
			{
				return string.Format("Unit_Prefab/Spot/spot_01_zhangpeng_{0}", colorId);
			}
		}

		
		/** 箭塔AvatarPrefab文件 */
		public string prefabFileForTurret
		{
			get
			{
				return "Unit_Prefab/Turret/t_01_jianta_0";
			}
		}


		
		/** 士兵AvatarPrefab文件 */
		public string prefabFileForSolider
		{
			get
			{
				return string.Format("Unit_Prefab/Soldier/s_g_01_changqiangbing_{0}", colorId);
//				return "Unit_Prefab/Soldier/s_g_01_changqiangbing_1";
			}
		}





		/** 附加属性--等级 */
		public AttachPropData GetCasernLevelProps(int level)
		{
			AttachPropData attachPropData = null;
			if(casernLevelAttachPropData.TryGetValue(level, out attachPropData))
			{
				return attachPropData;
			}
			return null;
		}
		
		/** 获取兵营升级所需兵力 */
		public float GetBuildUplevelNeedHP(int level)
		{
			return buildLevelNeedHP[level];
		}

		/** 取消该势力（玩家）所有技能操作 */
		public void CancelSkillOperator(SkillOperateData current = null)
		{
			foreach(KeyValuePair<int, SkillOperateData> kvp in skillDatas)
			{
				if(current != kvp.Value)
				{
					kvp.Value.CancelOperator();
				}
			}
		}


		public LegionData(int team, string name, LegionType type, bool aiSendArm, bool aiUplevel, bool aiSkill, bool produce)
		{
			this.legionId = team;
			this.name = name;
			this.type = type;
			this.aiSendArm = aiSendArm;
			this.aiUplevel = aiUplevel;
			this.aiSkill = aiSkill;
			this.produce = produce;


			if(this.legionId == War.ownLegionID)
			{
				levelData = new LegionLevelData_Own();
			}
			else
			{
				levelData = new LegionLevelData();
			}

			levelData.legionData = this;
		}

		public RelationType GetRelation(int team)
		{
			if(this.legionId == team)
			{
				return RelationType.Own;
			}
			else if(group != null)
			{
				return group.IsOnceGroup(team) ? RelationType.Friendly : RelationType.Enemy;
			}
			return RelationType.Enemy;
		}


		public override string ToString ()
		{
			return string.Format ("[LegionData] legionId={0}, name={1}, type={2}, aiSendArm={3}, aiUplevel={4},  aiSkill={5}, produce={6}, group={7}, produceLimit={8}",
			                      legionId, name, type, aiSendArm, aiUplevel, aiSkill, produce, group, produceLimit);
		}



		
		//-----------prop---------------
		
		#region prop
		/** 势力单位数据 */
		public UnitData unitData;
		
		/** 势力属性 */
		public 	float[] 					Props		{ 	get { 	return unitData.Props; 		} 	}


		public float killHero 		{ get { return unitData.killHero;			}		set { unitData.killHero = value;			} 	}		// 斩将值
		public float mage	 		{ get { return unitData.mage;				}		set { unitData.mage = value;				} 	}		// 斩将值
		public float maxMag	 		{ get { return unitData.maxMage;			}		set { unitData.maxMage = value;				} 	}		// 斩将值
		public bool  mageFull		{ get { return mage >= maxMag;}		}	
		#endregion

	}
}