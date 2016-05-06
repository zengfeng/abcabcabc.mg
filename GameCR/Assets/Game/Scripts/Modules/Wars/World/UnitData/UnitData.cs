using UnityEngine;
using System.Collections;
using Games.Module.Props;
using System.Collections.Generic;
using CC.Runtime.Utils;
using CC.Runtime.signals;
using System;
using Games.Module.Avatars;
using Games.Cores;

namespace Games.Module.Wars
{
	public partial class UnitData : EData, IPropUnit
	{
		#region config
		/** 编号 */
		public int id;
		/** 名称 */
		public string name;
		/** 单位类型 */
		public UnitType unitType;
		/** 建筑类型 */
		public BuildType buildType;
		/** 初始势力ID */
		public int initLegionId;
		/** 当前势力ID */
		public int legionId;
		/** 初始位置 */
		public Vector3 position = Vector3.zero;
		public int avatarId;
		private AvatarConfig _avatarConfig;
		public AvatarConfig avatarConfig { 
			get
			{
				if(_avatarConfig == null) _avatarConfig = Goo.avatar.GetConfig(avatarId);
				return _avatarConfig;
			}

			set
			{
				_avatarConfig = value;
				if(_avatarConfig != null)
				{
					avatarId = _avatarConfig.id;
				}
				else
				{
					avatarId = 0;
				}
			}
		}
		/** 单位资源 */
		public string prefabFile 
		{
			get
			{
				
//				Debug.Log("avatarId=" + avatarId + "  avatarConfig=" + avatarConfig + " legionData=" + legionData);
				return avatarConfig.GetModelPath(legionData.colorId);
				
//				switch(unitType)
//				{
//				case UnitType.Wall:
//					return "unit_prefab/wall/wall_01_juma";
//					break;
//				default:
//					Debug.Log("avatarId=" + avatarId + "  avatarConfig=" + avatarConfig + " legionData=" + legionData);
//					return avatarConfig.GetModelPath(legionData.colorId);
//					break;
//				}

			}
		}
		
		/** 一排士兵宽度 */
		public float armOnceWidth = -1;
		/** 士兵纵向间距 */
		public float gapV = -1;
		private float _radius = -1;
		public float radius
		{
			get
			{
				if(_radius != -1) return _radius;
				if(avatarConfig != null) return avatarConfig.radius;
				return 1f;
			}

			set
			{
				_radius = value;
			}
		}

		/** 势力颜色 */
		public int colorId { get{return legionData.colorId;} }

		/** 位置配置 */
		public StagePositionConfig 	positionConfig;
		/** 墙配置 */
		public BuildWallConfig 		wallConfig;

		public WE_BuildConfigData   we_BuildConfigData;

		
		
		public string GetName()
		{
			if(unitType == UnitType.Build)
			{
				
				return id + " " + WarUtils.GetBuildTypeName(buildType);
			}
			else
			{
				return id + " " + WarUtils.GetUnitTypeName(unitType);
			}
		}
		#endregion

		/** 等级 */
		public int level = 1;
		/** 状态--暂停 */
		public bool pause = false;
		/** 状态--冰冻移动速度 */
		public bool freezedMoveSpeed	{ get { return props[PropId.StateFreezedMoveSpeed] > 0; 	} 		set { props[PropId.StateFreezedMoveSpeed] = value ? 1 : 0; 		}	}
		/** 状态--冰冻发兵 */
		public bool freezedSendArm		{ get { return props[PropId.StateFreezedSendArm] > 0; 	} 			set { props[PropId.StateFreezedSendArm] = value ? 1 : 0; 		}	}
		/** 状态--冰冻生产兵 */
		public bool freezedProduce		{ get { return props[PropId.StateFreezedProduce] > 0; 	} 			set { props[PropId.StateFreezedProduce] = value ? 1 : 0; 		}	}
		/** 状态--沉默 */
		public bool silence				{ get { return props[PropId.StateSilence] > 0; 	} 					set { props[PropId.StateSilence] = value ? 1 : 0; 				}	}
		/** 状态--无敌 */
		public bool invincible			{ get { return props[PropId.StateInvincible] > 0; 	} 				set { props[PropId.StateInvincible] = value ? 1 : 0; 			}	}
		/** 状态--显示血量 */
		public bool showHP				{ get { return props[PropId.StateShowHP] > 0; 	} 					set { props[PropId.StateShowHP] = value ? 1 : 0; 				}	}
		/** 状态--灼烧 */
		public bool burn				{ get { return props[PropId.StateBurn] > 0; 	} 					set { props[PropId.StateBurn] = value ? 1 : 0; 				}	}

		/** 状态--移动速度--加 */
		public bool stateMoveSpeedUp			{ get { return props[PropId.StateMoveSpeedUp] > 0; 	} 						set { props[PropId.StateMoveSpeedUp] = value ? 1 : 0; 				}	}
		/** 状态--攻击--加 */
		public bool stateAtkUp					{ get { return props[PropId.StateAtkUp] > 0; 	} 							set { props[PropId.StateAtkUp] = value ? 1 : 0; 				}	}
		/** 状态--产兵--加 */
		public bool stateProduceSpeedUp			{ get { return props[PropId.StateProduceSpeedUp] > 0; 	} 					set { props[PropId.StateProduceSpeedUp] = value ? 1 : 0; 				}	}



		#region from to

		/** 围城的兵 */
		public List<UnitData> aroundList = new List<UnitData>();
		/** 正在派兵来的兵营 */
		public List<UnitData> fromList = new List<UnitData>();
		/** 士兵--出发兵营 */
		public UnitData from;
		/** 士兵--目标兵营 */
		public UnitData to;
		/** 危险值 */
		public float dangerous = 0f;
		/** 进攻值 */
		public float attackScore = 0f;
		/** 救援值 */
		public float rescueScore = 0f;
		/** 攻击士兵数量 */
		public int attackUnitNum = 0;
		/** 救援士兵数量 */
		public int rescueUnitNum = 0;
		
		/** 正在路上和即将出发的势力兵数量 */
		public Dictionary<int, int> fromLegionUnitTotalNumDict = new Dictionary<int, int>();
		/** 正在路上派兵来的势力兵数量 */
		public Dictionary<int, int> fromLegionUnitNumDict = new Dictionary<int, int>();
		/** 添加,正在路上派兵来的势力兵数量 */
		public void AddFromLegionUnit(int legionId, int num = 1)
		{
			if(fromLegionUnitNumDict.ContainsKey(legionId))
			{
				fromLegionUnitNumDict[legionId] += num;
			}
			else
			{
				fromLegionUnitNumDict.Add(legionId, num);
			}
		}

		/** 移除,正在路上派兵来的势力兵数量 */
		public void RemoveFromLegionUnit(int legionId, int num = 1)
		{
			if(fromLegionUnitNumDict.ContainsKey(legionId))
			{
				fromLegionUnitNumDict[legionId] -= num;
				if(fromLegionUnitNumDict[legionId] < 0) fromLegionUnitNumDict[legionId] = 0;
			}
		}

		/**  生成正在路上和即将出发的势力兵数量 */
		public void GenerationFromLegionUnitTotalNum()
		{
			foreach(KeyValuePair<int, int> kvp in fromLegionUnitNumDict)
			{
				if(fromLegionUnitTotalNumDict.ContainsKey(kvp.Key))
				{
					fromLegionUnitTotalNumDict[kvp.Key] = kvp.Value;
				}
				else
				{
					fromLegionUnitTotalNumDict.Add(kvp.Key, kvp.Value);
				}
			}

			foreach(UnitData item in fromList)
			{
				int legionId = item.legionId;
				int num = item.sendArmData.TargetCount > 0 ? item.sendArmData.sendNum / item.sendArmData.TargetCount : item.sendArmData.sendNum;

				if(fromLegionUnitTotalNumDict.ContainsKey(legionId))
				{
					fromLegionUnitTotalNumDict[legionId] += num;
				}
				else
				{
					fromLegionUnitTotalNumDict.Add(legionId, num);
				}


			}

			
			attackUnitNum = 0;
			rescueUnitNum = 0;
			foreach(KeyValuePair<int, int> kvp in fromLegionUnitTotalNumDict)
			{
				int legionId = kvp.Key;
				int num = kvp.Value;

				RelationType relation = GetRelation(legionId);
				if(relation == RelationType.Enemy)
				{
					attackUnitNum += num;
				}
				else
				{
					rescueUnitNum += num;
				}
			}


		}


		#endregion
	

		
		
		//-----------view---------------
		/** 是否显示血条 */
		public bool showHPView
		{
			get
			{
				// 显示野外的
				if(isNeutral)
				{
					return true;
				}

				// 关卡配置显示
                if (War.sceneData.showHP)
                {
                    return true;
                }

				// 不是敌人势力就显示
				if(relation != RelationType.Enemy)
				{
					return true;
				}

				//状态--显示血量
				if(showHP)
				{
					return showHP;
				}

				// 该势力是否显示
				return legionData.showHP;
			}
		}



		#region relation
		/** 和自己的势力关系 */
		public RelationType relation
		{
			get
			{
				return War.GetRelationType(legionId);
			}
		}

		/** 获取势力关系 */
		public RelationType GetRelation(int legionId)
		{
			return legionData.GetRelation(legionId);
		}

		/** 是否是电脑 */
		public bool isComputer
		{
			get
			{
				return legionData.type == LegionType.Computer;
			}
		}

		/** 是否是野外 */
		public bool isNeutral
		{
			get
			{
				return legionData.type == LegionType.Neutral;
			}
		}

        /** 是否是有将领 */
        public bool hasHero
        {
            get
            {
                return heroData != null;
            }
        }

		#endregion


		
		
		#region sos
		/** 求救持久时间 */
		public float sosTimeConfig = 3F;
		/** 求救时间 */
		public float _sosTime = 0F;
		public float sosTime
		{
			get
			{
				return _sosTime;
			}
			
			set
			{
				_sosTime = value;
			}
		}
		
		/** 是否是求救状态 */
		public bool sos
		{
			get
			{
				return _sosTime > 0;
			}
			
			set
			{
				if(value)
				{
					_sosTime = sosTimeConfig;
				}
				else
				{
					_sosTime = 0f;
				}
			}
		}
		#endregion


		#region death
		/** 死亡持久时间 */
		public float deathTimeConfig = 1.2F;
		/** 死亡时间 */
		public float _deathTime = 0F;
		public float deathTime
		{
			get
			{
				return _deathTime;
			}
			
			set
			{
				_deathTime = value;
			}
		}

		/** 是否是死亡状态 */
		public bool death
		{
			get
			{
				return _deathTime > 0;
			}

			set
			{
				if(value)
				{
					_deathTime = deathTimeConfig;
				}
				else
				{
					_deathTime = 0f;
				}
			}
		}
		#endregion




		
		#region behit

		// 士兵是否被箭塔攻击
		public bool isTurretHit = false;


		public bool isHitFly = false;
		public Vector3 hitFlyPoint = Vector3.zero;
        public float hitFlyPower = 500f;
        public float hitFlyPowerUp = 5f;
        public float hitFlyPowerRadius = 6f;

		public float beattackConfig = 0.5F;
		public float _beattackTime = 0;
		public float beattackTime
		{
			get
			{
				return _beattackTime;
			}
			
			set
			{
				_beattackTime = value;
			}
		}

		public bool beattack
		{
			get
			{
				return _beattackTime > 0;
			}

			set
			{
				if(value)
				{
					_beattackTime = beattackConfig;
				}
				else
				{
					_beattackTime = 0f;
				}
			}
		}

		/** 被攻打状态持久时间 */
		public float behitTimeConfig = 3F;
		/** 被攻打状态时间 */
		public float _behitTime = 0;
		public float behitTime
		{
			get
			{
				return _behitTime;
			}

			set
			{
				_behitTime = value;
			}
		}

		/** 是否被攻打 */
		public bool behit
		{
			get
			{
				return _behitTime > 0;
			}

			set
			{
				if(value)
				{
					_behitTime = behitTimeConfig;
				}
				else
				{
					_behitTime = 0f;
				}

				//beattack = value;
			}
		}

		/** 改变势力过程持久时间 */
		public float changeLegionTimeConfig = 2F;
		/** 改变势力过程时间 */
		public float _changeLegionTime = 0;
		public float changeLegionTime
		{
			get
			{
				return _changeLegionTime;
			}
			
			set
			{
				_changeLegionTime = value;
			}
		}

		/** 是否正在改变势力 */
		public bool changeTeaming
		{
			get
			{
				return _changeLegionTime > 0;
			}
			
			set
			{
				if(value)
				{
					_changeLegionTime = changeLegionTimeConfig;
				}
				else
				{
					_changeLegionTime = 0f;
				}
			}
		}

		/** 被士兵攻打 */
		public void BehitForUnit(UnitData enemy)
		{
			if (!War.isGameing) return;
			if(invincible) return;

//			Debug.Log(string.Format("hpbug BehitForUnit atk={0}, def={1},  hp={2}, enemy.atk={3}, enemy.hp={3}", atk, def,  hp, enemy.atk, enemy.hp));

//			Debug.Log(string.Format("<color=lightblue>BehitForUnit enemy={0}  enemy.props={1}</color>", enemy, enemy.props.ToStrProp()));
			DamageVO damageVO = new DamageVO();
			damageVO.caster = enemy.unit;
			damageVO.target = this.unit;
			damageVO.value = WarFormula.WD_Solider2Casern_Damage(def, enemy.atk, enemy.hp);
			damageVO.fromType = DamageFromType.Solider;
			damageVO.damageType = DamageType.ATTACK;

			try
			{
				damageVO.target.DamageBehit(damageVO);
			}
			catch(Exception e)
			{
				if (Application.isEditor) 
				{
					Debug.LogError (e);
				}
				else 
				{
					Debug.LogFormat ("<color=red>" + e + "</color>");
				}
			}

//			Debug.Log(string.Format("hpbug BehitForUnit atk={0}, def={1}, hitVO.damageVO.value={2}, hp={3}", atk, def, damageVO.value, hp));
			if(hp >= 0)
			{
				behit = true;
				War.signal.OnBehit (uid, enemy.legionId);
			}
			else
			{
				hp = WarFormula.WD_RelativelyHP_Def2Atk(def, enemy.atk, -hp);
				behit = false;
				ChangeLegion(enemy.legionId);
			}

		}
		
		#endregion







		//-----------prop---------------
		
		#region prop
		
		/** 单位ID */
		public int 							uid			{	get{	return id;			}	}
		/** 清除属性 */
		private Action<IPropUnit>			_sClearProp ;
		public 	Action<IPropUnit> 			sClearProp{ 	get{	return _sClearProp;	} 		set{	_sClearProp = value;	}	}


		/** 属性列表 */
		private float[] 					props		= new float[PropId.MAX];
		/** 获取属性列表 */
		public 	float[] 					Props		{ 	get { 	return props; 		} 	}


		/** 附加属性标记字典 */
		private Dictionary<int, AttachPropData> attachProps	= new Dictionary<int, AttachPropData>();
		/** 获取附加属性标记字典 */
		public 	Dictionary<int, AttachPropData> AttachProps	{	get	{	return attachProps;	}	}

		/** 设置属性列表 */
		public void SetProps(float[] props)
		{
			this.props = props;
		}
		
		/** 兵力上限(血量上限) */
		public float maxHp
		{
			get
			{
				return props[PropId.MaxHp].Limit(PropId.MaxHp);
			}

			set
			{
				props[PropId.MaxHp] = value;
				if(props[PropId.Hp2UnitRate] > 0)
				{
					props[PropId.MaxUnitNum] = value / props[PropId.Hp2UnitRate];
				}
				else
				{
					props[PropId.MaxUnitNum] = value;
				}
			}
		}
		
		/** 兵力(血量) */
		public float hp
		{
			get
			{
				return props[PropId.Hp].Limit(PropId.Hp);
			}

			set
			{
				props[PropId.Hp] = value;
				if(props[PropId.Hp2UnitRate] > 0)
				{
					props[PropId.UnitNum] = value / props[PropId.Hp2UnitRate];
				}
				else
				{
					props[PropId.UnitNum] = value;
				}
			}
		}

		
		/** 人口上限 */
		public int maxUnitNum
		{
			get
			{
				props[PropId.MaxUnitNum] = (int)(props[PropId.MaxHp] / hp2UnitRate).Limit(PropId.MaxUnitNum);
				return (int)props[PropId.MaxUnitNum];
			}
		}
		
		/** 人口 */
		public int unitNum
		{
			get
			{
				props[PropId.UnitNum] = (int)(props[PropId.Hp] / hp2UnitRate);
				return (int)props[PropId.UnitNum];
			}
		}

		/** 兵力转人口比例数值 */
		public float hp2UnitRate
		{
			get
			{
				if(legionData != null && legionData.soliderInitProp[PropId.InitMaxHp] != 0) return legionData.soliderInitProp[PropId.InitMaxHp];
				if(props[PropId.Hp2UnitRate] == 0)
				{
					return 1;
				}
				return props[PropId.Hp2UnitRate];
			}

			set
			{
				props[PropId.Hp2UnitRate] = value;
			}
		}

		
		/** 攻击 */
		public float atk 			
		{ 
			get 
			{	
				return props[PropId.Atk].Limit(PropId.Atk);
			} 		
			set 
			{ 
				props[PropId.Atk] = value; 				
			}	
		}

		/** 生产速度 */
		public float produceSpeed	{ get { return props[PropId.ProduceSpeed].Limit(PropId.ProduceSpeed); 	} 		set { props[PropId.ProduceSpeed] = value; 		}	}		// 生产速度
		/** 移动速度 */
		public float moveSpeed 		{ get { return props[PropId.MoveSpeed];									}		set { props[PropId.MoveSpeed] = value.Limit(PropId.MoveSpeed);			} 	}		// 移动速度
		/** 怒气值 */
		public float mage 			{ get { return props[PropId.Mag].Limit(PropId.Mag);						}		set { props[PropId.Mag] = value;				} 	}			// 移动速度
		/** 怒气值上限 */
		public float maxMage 		{ get { return props[PropId.MaxMag].Limit(PropId.MaxMag);				}		set { props[PropId.MaxMag] = value;				} 	}	// 怒气
		/** 怒气值恢复速度 */
		public float mageSpeed		{ get { return props[PropId.MageSpeed].Limit(PropId.MageSpeed);			}		set { props[PropId.MageSpeed] = value;				} 	}			// 移动速度
		/** 防御值 */
		public float def 			{ get { return props[PropId.Def].Limit(PropId.Def);						}		set { props[PropId.Def] = value;				} 	}		// 防御
		/** 斩将值 */
		public float killHero 		{ get { return props[PropId.KillHero].Limit(PropId.KillHero);			}		set { props[PropId.KillHero] = value;			} 	}		// 斩将值
		/** 防斩将值 */
		public float defkillHero 	{ get { return props[PropId.DefKillHero].Limit(PropId.DefKillHero);		}		set { props[PropId.DefKillHero] = value;		} 	}		// 防斩将值
		/** 攻击伤害 */
		public float attackDamage	{ get { return props[PropId.AttackDamage].Limit(PropId.AttackDamage); 	} 		set { props[PropId.AttackDamage] = value; 		}	}		// 生产速度
		/** 攻击范围 */
		public float attackRadius	{ get { return props[PropId.AttackRadius].Limit(PropId.AttackRadius); 	} 		set { props[PropId.AttackRadius] = value; 		}	}		// 生产速度
		/** 攻击速度 */
		public float attackSpeed	{ get { return props[PropId.AttackSpeed].Limit(PropId.AttackSpeed); 	} 		set { props[PropId.AttackSpeed] = value; 		}	}		// 生产速度
		/**  盾牌抵消血量值 */
        public float shield = 0;


		
		/** 单位--士兵 */
		public PropContainer soliderPropContainer 		= new PropContainer();
		/** 单位--建筑 */
		public PropContainer buildPropContainer 		= new PropContainer();
		/** 单位--英雄 */
		public PropContainer heroPropContainer 			= new PropContainer();
        #endregion


		#region HP Method
		/** 添加兵力 */
		public void AddHP(float val)
		{
			hp += val;
		}

		/** 添加人口 */
		public void AddUnitNum(int val)
		{
			hp += val * hp2UnitRate;
		}

		#endregion



		#region Method
		/** 初始化 */
		public void Init()
		{
			initLegionId = legionId;

			if(unitType == UnitType.Build)
			{
				BuildInit();
			}
		}

		/** 升级 */
		public void Uplevel(int level)
		{
			if(unitType == UnitType.Build)
			{
				BuildUplevel(level);
			}
			this.level = level;
		}

		/** 改变势力 */
		public void ChangeLegion(int legionId)
		{
			if (War.isRecord) return;

			if(War.requireSynch)
			{
				if(legionId == War.ownLegionID)
				{
					ExeChangeLegion(legionId);
					War.pvp.C_Build(uid, legionId);
				}
				else
				{
					if(War.GetLegionData(legionId).type != LegionType.Player && War.isMainLegion)
					{
						ExeChangeLegion(legionId);
						War.pvp.C_Build(uid, legionId);
					}
				}
			}
			else
			{
				ExeChangeLegion(legionId);
			}

//			if(War.requireSynch)
//			{
////				ExeChangeLegion(legionId);
//
//				if (War.IsSendService (legionId, legionData.type))
//				{
//					War.pvp.C_Build(uid, legionId);
//				}
//			}
//			else
//			{
//				ExeChangeLegion(legionId);
//			}
		}


		public void ExeChangeLegion(int legionId)
		{
			if(unitType == UnitType.Build)
			{
				BuildChangeLegion(legionId);
				War.signal.DoBuildLegionChange (uid, legionId);
			}
			this.legionId = legionId;
		}


		public UnitData Clone()
		{
			UnitData n = new UnitData();
			n.id = id;
			n.name = name;
			n.unitType = unitType;
			n.buildType = buildType;
			n.legionId = legionId;
			n.level = level;
			n.position = position.Clone();
			n.avatarId = avatarId;
			n.props.PropAdd(props);
			n._radius = _radius;
			if(we_BuildConfigData != null) n.we_BuildConfigData = we_BuildConfigData.Clone();

			
			n.buildConfig = buildConfig;
			return n;
		}

		public override string ToString ()
		{
			return string.Format ("UserData id={0}, team={1}, relation={2}, teamData={3}", id, legionId, relation, legionData);
		}
		#endregion

	}
	

}
