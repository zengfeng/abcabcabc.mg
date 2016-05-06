using System;
using System.Collections.Generic;


namespace Games.Module.Props
{
    public class PropId
    {
		[HelpAttribute("属性最多数量，用于创建属性列表")]
        public const int MAX = 111;
		
		[HelpAttribute("兵力【血量】")]
        public const int HpAdd = 1;
        public const int HpPer = 2;
        public const int Hp = 3;
		
		[HelpAttribute("兵力上限【血量上限】")]
		public const int MaxHpAdd = 4;
		public const int MaxHpPer = 5;
		public const int MaxHp = 6;
		
		[HelpAttribute("人口【人口】")]
		public const int UnitNum = 7;
		[HelpAttribute("人口上限【人口上限】")]
		public const int MaxUnitNum = 8;
		
		[HelpAttribute("兵力转人口比例数值")]
		public const int Hp2UnitRate = 9;

		
		[HelpAttribute("攻击")]
        public const int AtkAdd = 10;
        public const int AtkPer = 11;
        public const int Atk = 12;
		
		[HelpAttribute("移动速度")]
		public const int MoveSpeedAdd = 13;
		public const int MoveSpeedPer = 14;
		public const int MoveSpeed = 15;
		
		[HelpAttribute("生产速度")]
		public const int ProduceSpeedAdd = 16;
		public const int ProduceSpeedPer = 17;
		public const int ProduceSpeed = 18;
		
		[HelpAttribute("怒气")]
		public const int MagAdd = 19;
		public const int MagPer = 20;
		public const int Mag = 21;

		
		[HelpAttribute("防御")]
		public const int DefAdd = 23;
		public const int DefPer = 24;
		public const int Def = 25;
		
		
		[HelpAttribute("普攻")]
		public const int AttackDamageAdd = 26;
		public const int AttackDamagePer = 27;
		public const int AttackDamage = 28;
		
		
		[HelpAttribute("普攻范围")]
		public const int AttackRadiusAdd = 29;
		public const int AttackRadiusPer = 30;
		public const int AttackRadius = 31;
		
		
		[HelpAttribute("普攻速度")]
		public const int AttackSpeedAdd = 32;
		public const int AttackSpeedPer = 33;
		public const int AttackSpeed = 34;
		
		
		[HelpAttribute("斩将值")]
		public const int KillHeroAdd = 35;
		public const int KillHeroPer = 36;
		public const int KillHero = 37;

		
		[HelpAttribute("防斩将值")]
		public const int DefKillHeroAdd = 38;
		public const int DefKillHeroPer = 39;
		public const int DefKillHero = 40;

		
		
		[HelpAttribute("斩将率")]
		public const int KillHeroRateAdd = 41;
		public const int KillHeroRatePer = 42;
		public const int KillHeroRate = 43;

		
		
		[HelpAttribute("怒气上限")]
		public const int MaxMagAdd = 44;
		public const int MaxMagPer = 45;
		public const int MaxMag = 46;

		[HelpAttribute("怒气恢复速度")]
		public const int MageSpeedAdd = 47;
		public const int MageSpeedPer = 48;
		public const int MageSpeed = 49;
		
		[HelpAttribute("战力")]
		public const int BattleForceAdd = 50;
		public const int BattleForcePer = 51;
		public const int BattleForce = 52;
		
		[HelpAttribute("速攻")]
		public const int SpeedAtkAdd = 53;
		public const int SpeedAtkPer = 54;
		public const int SpeedAtk = 55;



		
		[HelpAttribute("附加初始兵力")]
		public const int InitHpPer = 60;
		[HelpAttribute("附加初始兵力上限")]
		public const int InitMaxHpPer = 61;
		[HelpAttribute("附加初始攻击")]
		public const int InitAtkPer = 62;
		[HelpAttribute("附加初始移动速度")]
		public const int InitMoveSpeedPer = 63;
		[HelpAttribute("附加初始生产速度")]
		public const int InitProduceSpeedPer = 64;
		[HelpAttribute("附加初始怒气")]
		public const int InitMagPer = 65;
		[HelpAttribute("附加初始防御")]
		public const int InitDefPer = 66;
		[HelpAttribute("附加初始普攻")]
		public const int InitAttackDamagePer = 67;
		[HelpAttribute("附加初始普攻范围")]
		public const int InitAttackRadiusPer = 68;
		[HelpAttribute("附加初始普攻速度")]
		public const int InitAttackSpeedPer = 69;
		[HelpAttribute("附加初始必杀（斩将值）")]
		public const int InitKillHeroPer = 70;
		[HelpAttribute("附加初始运气（防斩将值）")]
		public const int InitDefKillHeroPer = 71;
		[HelpAttribute("附加初始斩将率")]
		public const int InitKillHeroRatePer = 72;
		[HelpAttribute("附加初始怒气上限")]
		public const int InitMaxMagePer = 73;
		[HelpAttribute("附加初始怒气恢复速度")]
		public const int InitMageSpeedPer = 74;
		[HelpAttribute("附加初始战力")]
		public const int InitBattleForcePer = 75;
		[HelpAttribute("附加初始速攻")]
		public const int InitSpeedAtkPer = 76;



		[HelpAttribute("初始兵力")]
		public const int InitHp = 80;
		[HelpAttribute("初始兵力上限")]
		public const int InitMaxHp = 81;
		[HelpAttribute("初始攻击")]
		public const int InitAtk = 82;
		[HelpAttribute("初始移动速度")]
		public const int InitMoveSpeed = 83;
		[HelpAttribute("初始生产速度")]
		public const int InitProduceSpeed = 84;
		[HelpAttribute("初始怒气")]
		public const int InitMag = 85;
		[HelpAttribute("初始防御")]
		public const int InitDef = 86;
		[HelpAttribute("初始普攻")]
		public const int InitAttackDamage = 87;
		[HelpAttribute("初始普攻范围")]
		public const int InitAttackRadius = 88;
		[HelpAttribute("初始普攻速度")]
		public const int InitAttackSpeed = 89;
		[HelpAttribute("初始必杀（斩将值）")]
		public const int InitKillHero = 90;
		[HelpAttribute("初始运气（防斩将值）")]
		public const int InitDefKillHero = 91;
		[HelpAttribute("初始斩将率")]
		public const int InitKillHeroRate = 92;
		[HelpAttribute("初始怒气上限")]
		public const int InitMaxMage = 93;
		[HelpAttribute("初始怒气恢复速度")]
		public const int InitMageSpeed = 94;
		[HelpAttribute("初始战力")]
		public const int InitBattleForce = 95;
		[HelpAttribute("初始攻速")]
		public const int InitSpeedAtk = 96;





			
		[HelpAttribute("状态--冰冻移动速度")]
		public const int StateFreezedMoveSpeed = 100;
		[HelpAttribute("状态--冰冻发兵")]
		public const int StateFreezedSendArm = 101;
		[HelpAttribute("状态--冰冻生产兵")]
		public const int StateFreezedProduce = 102;
		[HelpAttribute("状态--沉默")]
		public const int StateSilence = 103;
		[HelpAttribute("状态--无敌")]
		public const int StateInvincible = 104;
		[HelpAttribute("状态--显示血量")]
		public const int StateShowHP = 105;
		[HelpAttribute("状态--灼烧")]
		public const int StateBurn = 106;

		[HelpAttribute("状态--移动速度--加")]
		public const int StateMoveSpeedUp = 107;
		[HelpAttribute("状态--攻击--加")]
		public const int StateAtkUp = 108;
		[HelpAttribute("状态--产兵--加")]
		public const int StateProduceSpeedUp = 109;

		
		[HelpAttribute("势力ID")]
		public const int LegionID = 109;
		[HelpAttribute("战斗力")]
		public const int BattlePower = 110;

		
		[HelpAttribute("兵力【血量】")]
		public static PropIdGroup HpGroup = new PropIdGroup(InitHp, InitHpPer, HpAdd, HpPer, Hp);
		[HelpAttribute("兵力上限【血量上限】")]
		public static PropIdGroup MaxHpGroup = new PropIdGroup(InitMaxHp, InitMaxHpPer, MaxHpAdd, MaxHpPer, MaxHp);
		[HelpAttribute("攻击")]
		public static PropIdGroup AtkGroup = new PropIdGroup(InitAtk, InitAtkPer, AtkAdd, AtkPer, Atk);
		[HelpAttribute("移动速度")]
		public static PropIdGroup MoveSpeedGroup = new PropIdGroup(InitMoveSpeed, InitMoveSpeedPer, MoveSpeedAdd, MoveSpeedPer, MoveSpeed);
		[HelpAttribute("生产速度")]
		public static PropIdGroup ProduceSpeedGroup = new PropIdGroup(InitProduceSpeed, InitProduceSpeedPer, ProduceSpeedAdd, ProduceSpeedPer, ProduceSpeed);
		[HelpAttribute("怒气")]
		public static PropIdGroup MagGroup = new PropIdGroup(InitMag, InitMagPer, MagAdd, MagPer, Mag);
		[HelpAttribute("防御")]
		public static PropIdGroup DefGroup = new PropIdGroup(InitDef, InitDefPer, DefAdd, DefPer, Def);
		[HelpAttribute("普攻")]
		public static PropIdGroup AttackDamageGroup = new PropIdGroup(InitAttackDamage, InitAttackDamagePer, AttackDamageAdd, AttackDamagePer, AttackDamage);
		[HelpAttribute("普攻范围")]
		public static PropIdGroup AttackRadiusGroup = new PropIdGroup(InitAttackRadius, InitAttackRadiusPer, AttackRadiusAdd, AttackRadiusPer, AttackRadius);
		[HelpAttribute("普攻速度")]
		public static PropIdGroup AttackSpeedGroup = new PropIdGroup(InitAttackSpeed, InitAttackSpeedPer, AttackSpeedAdd, AttackSpeedPer, AttackSpeed);
		[HelpAttribute("必杀（斩将值）")]
		public static PropIdGroup KillHeroGroup = new PropIdGroup(InitKillHero, InitKillHeroPer, KillHeroAdd, KillHeroPer, KillHero);
		[HelpAttribute("运气（防斩将值）")]
		public static PropIdGroup DefKillHeroGroup = new PropIdGroup(InitDefKillHero, InitDefKillHeroPer, DefKillHeroAdd, DefKillHeroPer, DefKillHero);
		[HelpAttribute("斩将率")]
		public static PropIdGroup KillHeroRateGroup = new PropIdGroup(InitKillHeroRate, InitKillHeroRatePer, KillHeroRateAdd, KillHeroRatePer, KillHeroRate);
		[HelpAttribute("怒气上限")]
		public static PropIdGroup MaxMageGroup = new PropIdGroup(InitMaxMage, InitMaxMagePer, MaxMagAdd, MaxMagPer, MaxMag);
		[HelpAttribute("怒气恢复速度")]
		public static PropIdGroup MageSpeedGroup = new PropIdGroup(InitMageSpeed, InitMageSpeedPer, MageSpeedAdd, MageSpeedPer, MageSpeed);
		[HelpAttribute("战力")]
		public static PropIdGroup BattleForceGroup = new PropIdGroup(InitBattleForce, InitBattleForcePer, BattleForceAdd, BattleForcePer, BattleForce);
		[HelpAttribute("攻速")]
		public static PropIdGroup SpeedAtkGroup = new PropIdGroup(InitSpeedAtk, InitSpeedAtkPer, SpeedAtkAdd, SpeedAtkPer, SpeedAtk);

		private static  List<PropIdGroup> _listA;
		public static List<PropIdGroup> GetPropListA()
		{
			if(_listA == null)
			{
				_listA = new List<PropIdGroup>();
				_listA.Add(BattleForceGroup);
				_listA.Add(SpeedAtkGroup);
				_listA.Add(MaxHpGroup);
//				_listA.Add(AtkGroup);
//				_listA.Add(DefGroup);
//				_listA.Add(MoveSpeedGroup);
				_listA.Add(ProduceSpeedGroup);
				_listA.Add(AttackDamageGroup);
				_listA.Add(AttackRadiusGroup);
				_listA.Add(AttackSpeedGroup);
				_listA.Add(KillHeroGroup);
				_listA.Add(DefKillHeroGroup);
				_listA.Add(KillHeroRateGroup);
				_listA.Add(MaxMageGroup);
				_listA.Add(MageSpeedGroup);
			}

			return _listA;
		}

		private static  List<PropIdGroup> _listB;
		public static List<PropIdGroup> GetPropListB()
		{
			if(_listB == null)
			{
				_listB = new List<PropIdGroup>();
				_listB.Add(HpGroup);
				_listB.Add(MagGroup);
			}
			
			return _listB;
		}

		private static  List<PropIdGroup> _listC;
		public static List<PropIdGroup> GetPropListC()
		{
			if(_listC == null)
			{
				AtkGroup.cInit = InitBattleForce;
				AtkGroup.cInitPer = InitBattleForcePer;
				AtkGroup.cAdd = BattleForceAdd;
				AtkGroup.cPer = BattleForcePer;
				AtkGroup.cFinal = BattleForce;
				AtkGroup.cRate = ConstConfig.GetFloat(ConstConfig.ID.War_DV_BattleForce2Atk_Ratio);
				
				DefGroup.cInit = InitBattleForce;
				DefGroup.cInitPer = InitBattleForcePer;
				DefGroup.cAdd = BattleForceAdd;
				DefGroup.cPer = BattleForcePer;
				DefGroup.cFinal = BattleForce;
				DefGroup.cRate = ConstConfig.GetFloat(ConstConfig.ID.War_DV_BattleForce2Defence_Ratio);

				
				MoveSpeedGroup.cInit = InitSpeedAtk;
				MoveSpeedGroup.cInitPer = InitSpeedAtkPer;
				MoveSpeedGroup.cAdd = SpeedAtkAdd;
				MoveSpeedGroup.cPer = SpeedAtkPer;
				MoveSpeedGroup.cFinal = SpeedAtk;
				MoveSpeedGroup.cRate = ConstConfig.GetFloat(ConstConfig.ID.War_DV_SpeedAtk2MoveSpeed_Ratio);

				_listC = new List<PropIdGroup>();
				_listC.Add(AtkGroup);
				_listC.Add(DefGroup);
				_listC.Add(MoveSpeedGroup);
			}
			
			return _listC;
		}

		
		private static  List<int> _listState;
		public static List<int> GetPropListState()
		{
			if(_listState == null)
			{
				_listState = new List<int>();
				_listState.Add(StateFreezedMoveSpeed);
				_listState.Add(StateFreezedSendArm);
				_listState.Add(StateFreezedProduce);
				_listState.Add(StateSilence);
				_listState.Add(StateInvincible);
				_listState.Add(StateShowHP);
			}
			
			return _listState;
		}


    }

	/** 属性组 */
	public class PropIdGroup
	{
		/** 初始值 */
		public int init;
		/** 附加相对初始% */
		public int initPer;
		/** 附加具体值 */
		public int add;
		/** 附加相对当前% */
		public int per;
		/** 最终值 */
		public int final;

		
		/** 转换初始值 */
		public int cInit;
		/** 转换附加相对初始% */
		public int cInitPer;
		/** 转换附加具体值 */
		public int cAdd;
		/** 转换附加相对当前% */
		public int cPer;

		/** 转换最终值 */
		public int cFinal;
		/** 转换比例 */
		public float cRate = 0;

		public PropIdGroup(int init, int initPer, int add, int per, int final)
		{
			this.init 		= init;
			this.initPer 	= initPer;
			this.add 		= add;
			this.per 		= per;
			this.final 		= final;
		}
	}
}

