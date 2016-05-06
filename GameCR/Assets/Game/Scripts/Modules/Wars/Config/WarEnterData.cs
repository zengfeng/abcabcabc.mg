using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games.Module.Props;
using SimpleFramework;
using CC.Runtime.Utils;
using System;
using ProtoBuf;

namespace Games.Module.Wars
{

	public class WarTestData
	{
		public static Prop[] GetSoliderProps()
		{
			Prop[] props = new Prop[]{
				Prop.CreateInstance(PropId.AtkAdd, 0), 
				Prop.CreateInstance(PropId.DefAdd, 0), 
				Prop.CreateInstance(PropId.MaxHpAdd, 1), 
				Prop.CreateInstance(PropId.MoveSpeedAdd, 0f), 
				Prop.CreateInstance(PropId.KillHeroAdd, 100)
			};

			return props;
		}
	}

	[Serializable]
	[ProtoContract]
	public class WarEnterSoliderData
	{
		// 士兵ID
		[ProtoMember(1)]
		public string id { get; set; }

		// 士兵名称
		[ProtoMember(2)]
		public string name { get; set; }
		// 士兵等级
		[ProtoMember(3)]
		public int level { get; set; }
		// 士兵avatarId
		[ProtoMember(4)]
		public int avatarId { get; set; }
		// 属性列表
		private Prop[] _props = new Prop[]{};
		[ProtoMember(5)]
		public Prop[] props { get { return _props; }		set { _props = value; }}

		public void CheckProps()
		{
			if(props == null || props.Length == 0)
			{
				props = WarTestData.GetSoliderProps();
			}
		}

		
		public override string ToString ()
		{
			return string.Format ("[WarEnterSoliderData]  level={0}, avatarId={1}, props={2}",
			                      level, avatarId, props.ToStr ());
		}
	}

	[Serializable]
	[ProtoContract]
	public class WarEnterHeroData
	{
		// 英雄名称
		[ProtoMember(1)]
		public string name { get; set; }
		// 英雄ID
		[ProtoMember(2)]
		public int heroId { get; set; }
		// 建筑位置索引
		[ProtoMember(3)]
		public int buildIndex { get; set; }
		// 英雄avatarId
		[ProtoMember(4)]
		public int avatarId { get; set; }
		// 技能A
		[ProtoMember(5)]
		public int skillId { get; set; }
		[ProtoMember(6)]
		public int level { get; set; }
		// 属性列表
		private Prop[] _props = new Prop[]{};
		[ProtoMember(7)]
		public Prop[] props { get { return _props; }		set { _props = value; }}
		// 远征--英雄携带初始兵力
		[ProtoMember(8)]
		public int initHP { get; set; }

		// 英雄品质 1=白 2=蓝 3=紫
		[ProtoMember(9)]
		public int quality { get; set; }


		public void CheckProps()
		{
//			if(props == null || props.Length == 0)
//			{
//				props =new Prop[]{
//					Prop.CreateInstance(PropId.AtkAdd, 140), 
//					Prop.CreateInstance(PropId.DefAdd, 20),
//					Prop.CreateInstance(PropId.ProduceSpeedAdd, 0.065f),
//					Prop.CreateInstance(PropId.MaxHpAdd, 3.32f),
//					Prop.CreateInstance(PropId.DefKillHeroAdd, 90)
//				};
//			}
		}

		public override string ToString ()
		{
			return string.Format ("[WarEnterHeroData]  heroId={0}, buildIndex={1}, avatarId={2}, skillId={3}, skillLevel={4}, skillId2={5}, skillLevel2={6}, initHP={7}, props={8}",
			                      heroId, buildIndex, avatarId, skillId, level, 0, 0, initHP, props.ToStr ());
		}
	}

	[Serializable]
	[ProtoContract]
	public class WarEnterLegionData
	{
		// 玩家名称
		[ProtoMember(1)]
		public string name { get; set; }
		// 玩家ID
		[ProtoMember(2)]
		public int roleId { get; set; }
		// 阵营ID
		[ProtoMember(3)]
		public int legionId { get; set; }
		// 是否是机器人
		[ProtoMember(4)]
		public bool isRobot { get; set; }
		// 玩家头像ID
		[ProtoMember(5)]
		public int  headAvatarId { get; set; }
		// AI
		[ProtoMember(6)]
		public int ai { get; set; }
		// 士兵数据
		private WarEnterSoliderData _solider = new WarEnterSoliderData();
		[ProtoMember(7)]
		public WarEnterSoliderData solider { get { return _solider; }		set { _solider = value; }}

		// 英雄数据
		private List<WarEnterHeroData>  _heroList = new List<WarEnterHeroData>();
		[ProtoMember(8)]
		public List<WarEnterHeroData>  heroList { get { return _heroList; }		set { _heroList = value; }}
		
		// 远征--势力总兵力
		[ProtoMember(9)]
		public int maxHP { get; set; }
		// 远征--势力目前剩余兵力
		[ProtoMember(10)]
		public int hp { get; set; }
		// 远征--初始怒气
		[ProtoMember(11)]
		public int marale { get; set; }

		// 玩家头像
		[ProtoMember(12)]
		public int head { get; set; }

		// 建筑初始兵力如果是-1就读取这个值
		[ProtoMember(13)]
		public float initHP  { get; set; }
		
		// 玩家总初始属性列表
		[ProtoMember(14)]
		public float atk  { get; set; }
		[ProtoMember(15)]
		public float produceSpeed  { get; set; }
		[ProtoMember(16)]
		public float movespeed  { get; set; }

		[ProtoMember(17)]
		public float totalAtk  { get; set; }
		[ProtoMember(18)]
		public float totalProduceSpeed  { get; set; }
		[ProtoMember(19)]
		public float totalMoveSpeed  { get; set; }
		

		[ProtoMember(20)]
		public float subAtk  { get; set; }
		[ProtoMember(21)]
		public float subProduceSpeed  { get; set; }
		[ProtoMember(22)]
		public float subMoveSpeed  { get; set; }

		[ProtoMember(23)]
		public float maxAtk  { get; set; }
		[ProtoMember(24)]
		public float maxProduceSpeed  { get; set; }
		[ProtoMember(25)]
		public float maxMovespeed  { get; set; }

		[ProtoMember(26)]
		public int prize {get; set;}

		[ProtoMember(27)]
		public int level {get; set;}

		public float _prop1Factor = 1;
		[ProtoMember(28)]
		public float prop1Factor {get { return _prop1Factor; } set { _prop1Factor = value;}}

		public float _prop2Factor = 1;
		[ProtoMember(29)]
		public float prop2Factor {get { return _prop2Factor; } set { _prop2Factor = value;}}

		public float _prop3Factor = 1;
		[ProtoMember(30)]
		public float prop3Factor {get { return _prop3Factor; } set { _prop3Factor = value;}}

		private int _sendArmRate = 100;
		[ProtoMember(31)]
		public int sendArmRate {get { return _sendArmRate; } set { _sendArmRate = value;}}
		
		// 生成--势力数据
		internal Dictionary<int, WarEnterHeroData> heroDict = new Dictionary<int, WarEnterHeroData>();

		public void CheckProps()
		{
			solider.CheckProps();
			foreach(WarEnterHeroData heroData in heroList)
			{
				heroData.CheckProps();
			}
		}

		public override string ToString ()
		{
			string heroStr = "";
			for(int i = 0; i < heroList.Count; i ++)
			{
				heroStr += string.Format("\n   heroList[{0}] = {1}", i, heroList[i]);
			}

			return string.Format ("[WarEnterData] roleId={0}, legionId={1}, maxHP=[2], hp={3}, marale={4}, head={5}, \n solider={6}, \n heroList={7}", 
			                      roleId, legionId, maxHP, hp, marale, head, solider, heroStr);
		}
	}

	[Serializable]
	[ProtoContract]
	public class WarEnterData 
	{
		private bool isInited;
		// 战斗结束面板
		[ProtoMember(1)]
		public int overMenuId { get; set; }
		// 退出战斗时返回模块
		[ProtoMember(2)]
		public int backMenuId { get; set; }
		// 关卡ID
		[ProtoMember(3)]
		public int stageId { get; set; }
		// 关卡索引
		[ProtoMember(4)]
		public int stageIndex { get; set; }
		// 是否谁录像
		[ProtoMember(5)]
		public bool isRecord { get; set; }
		// 战斗模式
		[ProtoMember(6)]
		public VSMode vsmode { get; set; }
		// 如果是PVP，房间ID
		[ProtoMember(7)]
		public int roomId { get; set; }
		// PVP主机正营ID
		[ProtoMember(8)]
		public int mainLegionId { get; set; }
		// 自己玩家ID
		[ProtoMember(9)]
		public int ownRoleId { get; set; }
		// 自己阵营ID
		[ProtoMember(10)]
		public int ownLegionId { get; set; }
		// PVE对手ID
		[ProtoMember(11)]
		public int rivalRoleId { get; set; }
		// 玩家战前数据
		private  List<WarEnterLegionData> _legionList = new List<WarEnterLegionData>();
		[ProtoMember(12)]
		public List<WarEnterLegionData>	legionList  
		{ 
			get 
			{
				return _legionList;
			}

			set 
			{
				_legionList = new List<WarEnterLegionData> ();
			}
		}

		// 生成--势力数据
		private Dictionary<int, WarEnterLegionData> legionDict = new Dictionary<int, WarEnterLegionData>();

		// [测试] 技能配置
		internal Dictionary<int, ISkillConfig>	skillConfigDict = new Dictionary<int, ISkillConfig>();
		
		// [测试] 获取技能配置
		public ISkillConfig GetSkillConfig(int skillId)
		{
			if(skillConfigDict.ContainsKey(skillId))
			{
				return skillConfigDict[skillId];
			}

			return null;
		}

		public override string ToString ()
		{
			string legionStr = "";
			for(int i = 0; i < legionList.Count; i ++)
			{
				legionStr += string.Format("\n legionList[{0}] = {1}", i,  legionList[i]);
			}
			return string.Format ("[WarEnterData]  backMenuId={0}, stageId={1}, stageIndex={2}, vsmode={3}, roomId={4}, mainLegionId={5}, ownRoleId={6}, ownLegionId={7}, rivalRoleId={8}, legionList={9}",
			                      backMenuId, stageId, stageIndex, vsmode, roomId, mainLegionId, ownRoleId, ownLegionId, rivalRoleId, legionStr);
		}


		public void CheckWatchRole(int watchRoleId)
		{
			if (watchRoleId == ownRoleId)
				return;
			
			Init ();
			Dictionary<int, WarEnterLegionData> roleDict = new Dictionary<int, WarEnterLegionData> ();
			foreach (WarEnterLegionData item in legionList)
			{
				if (!roleDict.ContainsKey (item.roleId))
				{
					roleDict.Add (item.roleId, item);
				}
			}

			if (roleDict.ContainsKey (watchRoleId)) 
			{
				if (rivalRoleId == watchRoleId) 
				{
					rivalRoleId = ownRoleId;
				}

				WarEnterLegionData watchLegionData = roleDict[watchRoleId];

				ownRoleId = watchRoleId;
				ownLegionId = watchLegionData.legionId;
			}
		}

		public void Init()
		{
			if(isInited) return;
			isInited = true;
			foreach(WarEnterLegionData item in legionList)
			{
				item.CheckProps();
				legionDict.Add(item.legionId, item);

				foreach(WarEnterHeroData heroItem in item.heroList)
				{
					item.heroDict.Add(heroItem.heroId, heroItem);
				}
			}
		}

		public int FindMinLegionId()
		{
			int min = ownLegionId;
			foreach(WarEnterLegionData item in legionList)
			{
				if(item.isRobot == false && item.legionId < min && item.legionId != 0)
				{
					min = item.legionId;
				}
			}

			return min;
		}

		
		public bool HasEnterLegionData(int legion)
		{
			return legionDict.ContainsKey(legion);
		}

		public Prop[] GetSoliderProps(int legion)
		{
			if(!legionDict.ContainsKey(legion)) return new Prop[]{};
			return legionDict[legion].solider.props;
		}

		
		public int GetSoliderLevel(int legion)
		{
			if(!legionDict.ContainsKey(legion)) return 1;
//			Debug.Log("GetSoliderLevel legion=" + legion);
			return legionDict[legion].solider.level;
		}

		public int GetSoliderAvatarId(int legion)
		{
			if(!legionDict.ContainsKey(legion)) return 30101;
			if(legionDict[legion].solider.avatarId > 0)
			{
				return legionDict[legion].solider.avatarId;
			}
			else
			{
				Debug.Log("<color=red>GetSoliderAvatarId legion=" + legion +"   avatarId=" + legionDict[legion].solider.avatarId + "</color>");
				return 30101;
			}
			return legionDict[legion].solider.avatarId;
		}

		public float GetHeroInitHP(int legion, int heroId)
		{
			if(legionDict.ContainsKey(legion))
			{
				if(legionDict[legion].heroDict.ContainsKey(heroId))
				{
					return legionDict[legion].heroDict[heroId].initHP;
				}
			}
			return -1;
		}

		public float GetTotalMaxHP(int legion)
		{
			if(legionDict.ContainsKey(legion))
			{
				return legionDict[legion].maxHP;
			}
			return 10000;
		}

		
		public float GetTotalHP(int legion)
		{
			if(legionDict.ContainsKey(legion))
			{
				return legionDict[legion].hp;
			}
			return 10000;
		}
		
		public float GetMag(int legion)
		{
			if(legionDict.ContainsKey(legion))
			{
				return legionDict[legion].marale;
			}
			return 0;
		}

		public WarEnterLegionData GetEnterLegionData(int legionId)
		{
			if(legionDict.ContainsKey(legionId))
			{
				return legionDict[legionId];
			}

			return null;
		}

		
		public int GetRoleId(int legion)
		{
			if(legionDict.ContainsKey(legion))
			{
				return legionDict[legion].roleId;
			}
			return -1;
		}



		/** heroSkill=[buildIndx, heroId, skillId, skillLevel, skillId2, skillLevel2] */
		public static WarEnterData CreateTest(int stageId, int ownLegionId, int[][] heroSkills, int[][] completeHeroSkills)
		{
			int ownRoleId = 1; 
			WarEnterData enterData = new WarEnterData();
			enterData.stageId = stageId;
			enterData.ownRoleId = ownRoleId;
			enterData.ownLegionId = ownLegionId;
			enterData.mainLegionId = ownLegionId;

			WarEnterLegionData legionData = new WarEnterLegionData();
			legionData.legionId = ownLegionId;
			legionData.name = "赵信他爷";
			legionData.maxAtk = 100;
			legionData.maxMovespeed = 100;
			legionData.maxProduceSpeed = 100;

			legionData.totalAtk = 64.925f;
			legionData.totalMoveSpeed = 2f;
//			legionData.totalMoveSpeed = 1f;
			legionData.totalProduceSpeed = 0.34f;


			legionData.initHP = 20;

			legionData.solider = new WarEnterSoliderData();
			legionData.solider.level = 1;
			legionData.solider.props = new Prop[]{Prop.CreateInstance(PropId.AtkAdd, 362), 
				Prop.CreateInstance(PropId.DefAdd, 221), 
				Prop.CreateInstance(PropId.MaxHpAdd, 1), 
				Prop.CreateInstance(PropId.MoveSpeedAdd, 3f), 
				Prop.CreateInstance(PropId.KillHeroAdd, 50)};

			foreach(int[] heroSkill in heroSkills)
			{
				WarEnterHeroData heroData = new WarEnterHeroData();
				heroData.heroId = heroSkill[0];
				heroData.skillId = heroSkill[1];
				heroData.level = heroSkill[2];
				heroData.props = new Prop[]{Prop.CreateInstance(PropId.AtkAdd, 10), 
					Prop.CreateInstance(PropId.DefAdd, 20),
					Prop.CreateInstance(PropId.ProduceSpeedAdd, 0.065f),
					Prop.CreateInstance(PropId.MaxHpAdd, 3.32f),
					Prop.CreateInstance(PropId.DefKillHeroAdd, 90)
				};
				legionData.heroList.Add(heroData);
			}


			enterData.legionList.Add(legionData);

			CreateTestCompleteLegion (enterData, completeHeroSkills);
			return enterData;
		}

		static void CreateTestCompleteLegion(WarEnterData enterData, int[][] heroSkills)
		{
			WarEnterLegionData legionData = new WarEnterLegionData();
			legionData.legionId = 2;
			legionData.name = "Computer";
			legionData.maxAtk = 100;
			legionData.maxMovespeed = 100;
			legionData.maxProduceSpeed = 100;

			legionData.totalAtk = 20;
			legionData.totalMoveSpeed = 3;
			legionData.totalProduceSpeed = 4;

			legionData.initHP = 20;

			legionData.solider = new WarEnterSoliderData();
			legionData.solider.level = 1;
			legionData.solider.props = new Prop[]{Prop.CreateInstance(PropId.AtkAdd, 362), 
				Prop.CreateInstance(PropId.DefAdd, 221), 
				Prop.CreateInstance(PropId.MaxHpAdd, 1), 
				Prop.CreateInstance(PropId.MoveSpeedAdd, 3f), 
				Prop.CreateInstance(PropId.KillHeroAdd, 50)};

			foreach(int[] heroSkill in heroSkills)
			{
				WarEnterHeroData heroData = new WarEnterHeroData();
				heroData.heroId = heroSkill[0];
				heroData.skillId = heroSkill[1];
				heroData.level = heroSkill[2];
				heroData.props = new Prop[]{Prop.CreateInstance(PropId.AtkAdd, 140), 
					Prop.CreateInstance(PropId.DefAdd, 20),
					Prop.CreateInstance(PropId.ProduceSpeedAdd, 0.065f),
					Prop.CreateInstance(PropId.MaxHpAdd, 3.32f),
					Prop.CreateInstance(PropId.DefKillHeroAdd, 90)
				};
				legionData.heroList.Add(heroData);
			}



			enterData.legionList.Add(legionData);
		}


	}


}