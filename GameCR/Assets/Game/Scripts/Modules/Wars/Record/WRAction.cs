using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.PB;
using System;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ProtoBuf;
using Newtonsoft.Json;
using System.ComponentModel;


namespace Games.Module.Wars
{
	public class WRActionComponent
	{

		virtual public void Exe()
		{

		}
	}
	
	[ProtoContract]
	public class WRAction 
	{
		#region base propbuf member
		protected float 		_t;
		protected WRActionType 	_actionType;

		[ProtoMember(1)]
		public float t 
		{
			get 
			{
				return _t;
			}

			set 
			{
				_t = value;
			}
		}

		[ProtoMember(2)]
		public WRActionType actionType
		{
			get 
			{
				return _actionType;
			}

			set
			{
				_actionType = value;
			}
		}

		#endregion



		#region WRAction Component

		private WRAction_SendArm _sendArm = null;
		[ProtoMember(3, IsRequired = false, Name=@"sendArm", DataFormat =DataFormat.Default)]
		[DefaultValue(null)]
		public WRAction_SendArm sendArm
		{
			get { return _sendArm; }
			set { _sendArm = value; }
		}



		private WRAction_Uplevel _uplevel = null;
		[ProtoMember(4, IsRequired = false, Name=@"uplevel", DataFormat =DataFormat.Default)]
		[DefaultValue(null)]
		public WRAction_Uplevel uplevel
		{
			get { return _uplevel; }
			set { _uplevel = value; }
		}



		private WRAction_BuildLegionChange _buildLegionChange = null;
		[ProtoMember(5, IsRequired = false, Name=@"buildLegionChange", DataFormat =DataFormat.Default)]
		[DefaultValue(null)]
		public WRAction_BuildLegionChange buildLegionChange
		{
			get { return _buildLegionChange; }
			set { _buildLegionChange = value; }
		}



		private WRAction_HeroBackstage _heroBackstage = null;
		[ProtoMember(6, IsRequired = false, Name=@"heroBackstage", DataFormat =DataFormat.Default)]
		[DefaultValue(null)]
		public WRAction_HeroBackstage heroBackstage
		{
			get { return _heroBackstage; }
			set { _heroBackstage = value; }
		}


		private WRAction_TurretAtk _turretAtk = null;
		[ProtoMember(7, IsRequired = false, Name=@"turretAtk", DataFormat =DataFormat.Default)]
		[DefaultValue(null)]
		public WRAction_TurretAtk turretAtk
		{
			get { return _turretAtk; }
			set { _turretAtk = value; }
		}


		private WRAction_SetProductionSkill _productionSkill = null;
		[ProtoMember(8, IsRequired = false, Name=@"productionSkill", DataFormat =DataFormat.Default)]
		[DefaultValue(null)]
		public WRAction_SetProductionSkill productionSkill
		{
			get { return _productionSkill; }
			set { _productionSkill = value; }
		}


		private WRAction_Skill _skill = null;
		[ProtoMember(9, IsRequired = false, Name=@"skill", DataFormat =DataFormat.Default)]
		[DefaultValue(null)]
		public WRAction_Skill skill
		{
			get { return _skill; }
			set { _skill = value; }
		}


		private WRAction_Prop _prop = null;
		[ProtoMember(10, IsRequired = false, Name=@"prop", DataFormat =DataFormat.Default)]
		[DefaultValue(null)]
		public WRAction_Prop prop
		{
			get { return _prop; }
			set { _prop = value; }
		}




		private WRAction_GameOver _gameOver = null;
		[ProtoMember(11, IsRequired = false, Name=@"gameOver", DataFormat =DataFormat.Default)]
		[DefaultValue(null)]
		public WRAction_GameOver gameOver
		{
			get { return _gameOver; }
			set { _gameOver = value; }
		}

		#endregion


		#region create
		public static WRAction Create_SendArm(int fromUid, int toUid, int count, int beginUid)
		{
			WRAction action = new WRAction ();
			action.actionType = WRActionType.SendArm;
			action.sendArm = new WRAction_SendArm (fromUid, toUid, count, beginUid);
			return action;
		}

		public static WRAction Create_Uplevel(int uid, int level, float time)
		{
			WRAction action = new WRAction ();
			action.actionType = WRActionType.Uplevel;
			action.uplevel = new WRAction_Uplevel (uid, level, time);
			return action;
		}

		public static WRAction Create_BuildLegionChange(int uid, int legionId)
		{
			WRAction action = new WRAction ();
			action.actionType = WRActionType.BuildLegionChange;
			action.buildLegionChange = new WRAction_BuildLegionChange (uid, legionId);
			return action;
		}


		public static WRAction Create_HeroBackstage(int heroUid, int targetLegionId)
		{
			WRAction action = new WRAction ();
			action.actionType = WRActionType.HeroBackstage;
			action.heroBackstage = new WRAction_HeroBackstage (heroUid, targetLegionId);
			return action;
		}


		public static WRAction Create_TurretAtk(int buildUid, int soliderUid)
		{
			WRAction action = new WRAction ();
			action.actionType = WRActionType.TurretAtk;
			action.turretAtk = new WRAction_TurretAtk (buildUid, soliderUid);
			return action;
		}

		public static WRAction Create_SetProductionSkill (int legionId, int skillUid, float speed)
		{
			WRAction action = new WRAction ();
			action.actionType = WRActionType.SetProductionSkill;
			action.productionSkill = new WRAction_SetProductionSkill (legionId, skillUid, speed);
			return action;
		}

		public static WRAction Create_Skill (C_SyncSkill_0x822 c)
		{
			WRAction action = new WRAction ();
			action.actionType = WRActionType.Skill;
			action.skill = new WRAction_Skill (c);
			return action;
		}

		public static WRAction Create_Prop (List<ProtoFightUnitInfo> unitPropList)
		{
			WRAction action = new WRAction ();
			action.actionType = WRActionType.Prop;
			action.prop = new WRAction_Prop (unitPropList);
			return action;
		}


		public static WRAction Create_GameOver ()
		{
			WRAction action = new WRAction ();
			action.actionType = WRActionType.GameOver;
			action.gameOver = new WRAction_GameOver ();
			return action;
		}

		#endregion

		public void Exe()
		{
			switch(actionType)
			{
			case WRActionType.SendArm:
				sendArm.Exe ();
				break;
			case WRActionType.Uplevel:
				uplevel.Exe ();
				break;
			case WRActionType.BuildLegionChange:
				buildLegionChange.Exe ();
				break;
			case WRActionType.HeroBackstage:
				heroBackstage.Exe ();
				break;
			case WRActionType.TurretAtk:
				turretAtk.Exe ();
				break;
			case WRActionType.SetProductionSkill:
				productionSkill.Exe ();
				break;
			case WRActionType.Skill:
				skill.Exe ();
				break;
			case WRActionType.Prop:
				prop.Exe ();
				break;
			case WRActionType.GameOver:
				gameOver.Exe ();
				break;
			}
		}

	}

	// 发兵
	[ProtoContract]
	public class WRAction_SendArm : WRActionComponent
	{

		[ProtoMember(1)]
		public int fromUid { get; set;}

		[ProtoMember(2)]
		public int toUid { get; set;}

		[ProtoMember(3)]
		public int count { get; set;}

		[ProtoMember(4)]
		public int beginUid { get; set;}

		public WRAction_SendArm()
		{
		}

		public WRAction_SendArm(int fromUid, int toUid, int count, int beginUid)
		{
			this.fromUid 		= fromUid;
			this.toUid 			= toUid;
			this.count 			= count;
			this.beginUid 		= beginUid;
		}

		override public void Exe()
		{
			War.exe.ExeSendArm (fromUid, toUid, count, beginUid);
		}

	}

	// 升级
	[ProtoContract]
	public class WRAction_Uplevel : WRActionComponent
	{
		

		[ProtoMember(1)]
		public int uid { get; set;}

		[ProtoMember(2)]
		public int level { get; set;}

		[ProtoMember(3)]
		public float time { get; set;}

		public WRAction_Uplevel()
		{
		}

		public WRAction_Uplevel(int uid, int level, float time)
		{
			this.uid 			= uid;
			this.level 			= level;
			this.time 			= time;
		}

		public override void Exe ()
		{
			War.exe.ExeUplevel (uid, level, time);
		}
	}


	//占领城池
	[ProtoContract]
	public class WRAction_BuildLegionChange : WRActionComponent
	{
		[ProtoMember(1)]
		public int uid { get; set;}
		[ProtoMember(2)]
		public int legionId { get; set;}

		public WRAction_BuildLegionChange()
		{
		}

		public WRAction_BuildLegionChange(int uid, int legionId)
		{
			this.uid 			= uid;
			this.legionId 		= legionId;
		}

		public override void Exe ()
		{
			War.exe.ExeBuildChangeLegion (uid, legionId);
		}
	}


	//英雄下阵
	[ProtoContract]
	public class WRAction_HeroBackstage : WRActionComponent
	{
		[ProtoMember(1)]
		public int heroUid { get; set;}
		[ProtoMember(2)]
		public int targetLegionId { get; set;}
		public WRAction_HeroBackstage()
		{
		}

		public WRAction_HeroBackstage(int heroUid, int targetLegionId)
		{
			this.heroUid 					= heroUid;
			this.targetLegionId 			= targetLegionId;

		}

		public override void Exe ()
		{
			War.exe.ExeHeroBackstag (heroUid, targetLegionId);
		}
	}


	//箭塔攻击
	[ProtoContract]
	public class WRAction_TurretAtk : WRActionComponent
	{
		[ProtoMember(1)]
		public int buildUid { get; set;}

		[ProtoMember(2)]
		public int soliderUid { get; set;}

		public WRAction_TurretAtk()
		{
		}

		public WRAction_TurretAtk(int buildUid, int soliderUid)
		{
			this.buildUid 				= buildUid;
			this.soliderUid 			= soliderUid;
		}

		public override void Exe ()
		{
			War.exe.ExeTurret (buildUid, soliderUid);
		}
	}


	//生产技能
	[ProtoContract]
	public class WRAction_SetProductionSkill : WRActionComponent
	{
		[ProtoMember(1)]
		public int legionId { get; set;}

		[ProtoMember(2)]
		public int skillUid { get; set;}

		[ProtoMember(3)]
		public float speed { get; set;}

		public WRAction_SetProductionSkill()
		{
		}

		public WRAction_SetProductionSkill(int legionId, int skillUid, float speed)
		{
			this.legionId 			= legionId;
			this.skillUid 			= skillUid;
			this.speed 				= speed;

		}

		public override void Exe ()
		{
			War.exe.ExeSetProduceSkill (legionId, skillUid, speed);
		}

	}


	//使用进能
	[ProtoContract]
	public class WRAction_Skill : WRActionComponent
	{

		private C_SyncSkill_0x822 _c = null;
		[ProtoMember(1, IsRequired = false, Name=@"cmsg", DataFormat =DataFormat.Default)]
		[DefaultValue(null)]
		public C_SyncSkill_0x822 c
		{
			get { return _c; }
			set { _c = value; }
		}




		public WRAction_Skill()
		{
		}

		public WRAction_Skill(C_SyncSkill_0x822 c)
		{
			this.c = c;
		}

		public override void Exe ()
		{
			War.exe.ExeSkill (c);
		}

	}



	//属性
	[ProtoContract]
	public class WRAction_Prop : WRActionComponent
	{
		private  List<ProtoFightUnitInfo> _unitPropList = new List<ProtoFightUnitInfo>();

		[ProtoMember(1)]
		public List<ProtoFightUnitInfo> unitPropList 
		{ 
			get 
			{
				return _unitPropList;
			}

			set 
			{
				_unitPropList = value;
			}

		}

		public WRAction_Prop()
		{
			
		}


		public WRAction_Prop(List<ProtoFightUnitInfo> unitPropList)
		{
			this.unitPropList = unitPropList;
		}


		public override void Exe ()
		{
			War.exe.ExeProp (unitPropList);
		}


	}


	//游戏结束
	[ProtoContract]
	public class WRAction_GameOver : WRActionComponent
	{
		public WRAction_GameOver()
		{
		}


		public override void Exe ()
		{
//			Debug.Log ("timeLineDatastarCount WRAction_GameOver 1=" + War.timeLineData.overData.legionDatas[0].starCount + "  " + War.timeLineData.overData.legionDatas[0].buildCount);
//			Debug.Log ("timeLineDatastarCount WRAction_GameOver 2=" + War.timeLineData.overData.legionDatas[1].starCount + "  " + War.timeLineData.overData.legionDatas[1].buildCount);

			War.exe.ExeGameOver (War.timeLineData.overData);
		}


	}





}