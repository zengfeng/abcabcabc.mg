using UnityEngine;
using System.Collections;
using Games.Module.Props;

namespace Games.Module.Wars
{

	public class LegionLevelData 
	{
		public LegionData legionData;

		public float 	exp = 0;
		public float	maxExp = 100;

		
		
		public float	intBattleForce = 25;
		public float	intProduceSpeed = 1;
		public float	intMoveSpeed = 1;
		public float 	initHP = 0;


		
		public float	maxBattleForce = 100;
		public float	maxProduceSpeed = 100;
		public float	maxMoveSpeed = 100;

		
		public float	subBattleForce = 0;
		public float	subProduceSpeed = 0;
		public float	subMoveSpeed = 0;

		
		public float	displayIntBattleForce = 25;
		public float	displayIntProduceSpeed = 1;
		public float	displayIntMoveSpeed = 1;
		public float 	displayInitHP = 0;
		
		public AttachPropData soliderAttachPropData;
		public AttachPropData buildAttachPropData;

		
		public AttachPropData soliderUnitAttachPropData;
		public AttachPropData buildUnitAttachPropData;
		
		public Prop atkProp;
		public Prop defProp;
		public Prop produceSpeedProp;
		public Prop moveSpeedProp;

		
		public Prop uAtkProp;
		public Prop uDefProp;
		public Prop uProduceSpeedProp;
		public Prop uMoveSpeedProp;

		public LegionLevelData()
		{
			atkProp = Prop.CreateInstance(PropId.AtkAdd, 0);
			defProp = Prop.CreateInstance(PropId.DefAdd, 0);
			produceSpeedProp = Prop.CreateInstance(PropId.ProduceSpeedAdd, 0);
			moveSpeedProp = Prop.CreateInstance(PropId.MoveSpeedAdd, 0);


			//-------------------
			soliderUnitAttachPropData = new AttachPropData();
			soliderUnitAttachPropData.props = new Prop[]{atkProp,  moveSpeedProp};
			
			buildUnitAttachPropData = new AttachPropData();
			buildUnitAttachPropData.props = new Prop[]{produceSpeedProp, defProp};
			//------------------
			soliderAttachPropData = new AttachPropData(); 
			soliderAttachPropData.props = new Prop[]{};

			buildAttachPropData = new AttachPropData(); 
			buildAttachPropData.props = new Prop[]{};

		}


		public UnitData soliderUnitData;
		public UnitData buildUnitData;

		public void Init()
		{
//			Debug.Log("soliderInitPropContainer " + legionData.legionId);
//			legionData.soliderInitPropContainer.Print();

			subBattleForce 			= subBattleForce 	/ PropConfig.GetInstance(PropId.AtkAdd).displayMultiplier;
			subProduceSpeed 		= subProduceSpeed 	/ PropConfig.GetInstance(PropId.ProduceSpeedAdd).displayMultiplier;
			subMoveSpeed 			= subMoveSpeed 		/ PropConfig.GetInstance(PropId.MoveSpeedAdd).displayMultiplier;

			displayIntBattleForce 	= intBattleForce 	- subBattleForce;
			displayIntProduceSpeed 	= intProduceSpeed 	- subProduceSpeed;
			displayIntMoveSpeed 	= intMoveSpeed 		- subMoveSpeed;



			soliderUnitData = new UnitData();
			legionData.soliderInitPropContainer.UnitApp(soliderUnitData, true);


			buildUnitData = new UnitData();
			// 势力--战前属性
			buildUnitData.AppProps(legionData.buildInitAttachPropData, true);
		}

		
		public float	atk
		{
			get
			{
				return soliderUnitData.atk / ConstConfig.GetFloat(ConstConfig.ID.War_DV_BattleForce2Atk_Ratio);
			}
		}

		public float	moveSpeed
		{
			get
			{
				return soliderUnitData.moveSpeed ;
			}
		}

		public float	produceSpeed
		{
			get
			{
				return buildUnitData.produceSpeed ;
			}
		}


//		public float	atk
//		{
//			get
//			{
//				return soliderUnitData.atk / ConstConfig.GetFloat(ConstConfig.ID.War_DV_BattleForce2Atk_Ratio) - subBattleForce - levelConfig.SubAtk ;
//			}
//		}
//
//		public float	moveSpeed
//		{
//			get
//			{
//				return soliderUnitData.moveSpeed - subMoveSpeed - levelConfig.SubMoveSpeed ;
//			}
//		}
//
//		public float	produceSpeed
//		{
//			get
//			{
//				return buildUnitData.produceSpeed - subProduceSpeed - levelConfig.SubProduceSpeed ;
//			}
//		}


		
		private int 	_level = 1;
		LegionLevelConfig levelConfig;
		public int 	Level
		{
			get
			{
				return _level;
			}

			set
			{

				soliderUnitData.RevokeProps(soliderAttachPropData);
				buildUnitData.RevokeProps(buildAttachPropData);

				legionData.soliderPropContainer.Remove(soliderUnitAttachPropData);
				legionData.buildPropContainer.Remove(buildUnitAttachPropData);

				_level = value;
				levelConfig = War.model.GetLegionLevelConfig(_level);
				maxExp = levelConfig.exp;

				if(_level >= LegionLevelConfig.MaxLevel)
				{
					maxExp = 0;
				}

				soliderAttachPropData.props = levelConfig.soliderPropList;
				buildAttachPropData.props = levelConfig.buildPropList;



				
				soliderUnitData.AppProps(soliderAttachPropData, true);
				buildUnitData.AppProps(buildAttachPropData, true);

				
				atkProp.value = soliderUnitData.atk - intBattleForce * ConstConfig.GetFloat(ConstConfig.ID.War_DV_BattleForce2Atk_Ratio);
				defProp.value = buildUnitData.def - intBattleForce * ConstConfig.GetFloat(ConstConfig.ID.War_DV_BattleForce2Atk_Ratio);

				produceSpeedProp.value = buildUnitData.produceSpeed - intProduceSpeed;
				moveSpeedProp.value = soliderUnitData.moveSpeed - intMoveSpeed;
				
				legionData.soliderPropContainer.Add(soliderAttachPropData);
				legionData.buildPropContainer.Add(buildAttachPropData);
			}
		}


		public void AddExp(float val)
		{
			val *= War.sceneData.weight.legionExpMultiply;
			exp += val;
			if(_level < LegionLevelConfig.MaxLevel)
			{
				if(exp >= maxExp)
				{
					exp = exp - maxExp;
					Level ++;

					if(legionData.legionId == War.ownLegionID)
					{
						War.msgBox.Show_LegionUplevel(Level);
					}
				}
			}
		}

		/** 添加经验--击杀英雄 */
		public virtual void AddExp_KillHero(UnitCtl e)
		{
//			Debug.Log("添加经验--击杀英雄 " + WarColor.Names[legionData.colorId]);
			float exp = LegionLevelHeroExpConfig.GetLevelExp(e.legionData.levelData.Level);
			AddExp(exp);
		}
		
		/** 添加经验--进攻 */
		public virtual void AddExp_SoliderAtk(float num, UnitCtl unit)
		{
			float exp = num * LegionLevelSoliderExpConfig.SoliderAtkExp;
			AddExp(exp);
		}
		
		/** 添加经验--防守 */
		public virtual void AddExp_SoliderDef(float num, UnitCtl unit)
		{
			float exp = num * LegionLevelSoliderExpConfig.SoliderDefExp;
			AddExp(exp);
		}

		
		/** 添加经验--技能 */
		public virtual void AddExp_SoliderSkill(float num, UnitCtl unit)
		{
			float exp = num * LegionLevelSoliderExpConfig.SoliderSkillExp;
			AddExp(exp);
		}

		
		/** 添加经验--箭塔攻击 */
		public virtual void AddExp_SoliderTurret(float num, UnitCtl unit)
		{
			float exp = num * LegionLevelSoliderExpConfig.SoliderTurretExp;
			AddExp(exp);

		}
		
		
		/** 添加经验--占领 */
		public virtual void AddExp_Build(UnitCtl unit)
		{
//			Debug.Log("添加经验--占领 " + WarColor.Names[legionData.colorId]);
			float exp = LegionLevelSoliderExpConfig.BuildExp;
			AddExp(exp);

		}

		

	
	}
}