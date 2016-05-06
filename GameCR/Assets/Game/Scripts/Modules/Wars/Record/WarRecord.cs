using UnityEngine;
using System.Collections;
using CC.Runtime.PB;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class WarRecord : MonoBehaviour 
	{
		public WRTimeLineData timeLineData = new WRTimeLineData();

		void Awake()
		{
			War.recordManager = this;
		}

		void Start()
		{
			if(War.isGameing)
			{
				Init();
			}
			else
			{
				War.signal.sGameBegin += Init;
			}
		}


		void OnDestroy()
		{
			War.signal.sGameBegin -= Init;
		}

		void Init()
		{
			this.enabled = !War.isRecord;
		}


		void OnEnable()
		{
			War.signal.sDoSendArm 				+= SendArm;
			War.signal.sDoUplevel 				+= Uplevel;
			War.signal.sDoBuildLegionChange 	+= BuildLegionChange;
			War.signal.sDoHeroBackstage 		+= HeroBackstage;
			War.signal.sDoTurretAtk 			+= TurretAtk;
			War.signal.sDoSetProductionSkill 	+= SetProductionSkill;
			War.signal.sDoSkill 				+= Skill;
			War.signal.sDoProp 					+= Prop;
			War.signal.sDoGameOver 				+= GameOver;

			if (!War.requireSynch) 
			{
				isCheckProp = true;
				//StartCoroutine (CheckProp ());
			}
		}

		void OnDisable()
		{
			War.signal.sDoSendArm 				-= SendArm;
			War.signal.sDoUplevel 				-= Uplevel;
			War.signal.sDoBuildLegionChange 	-= BuildLegionChange;
			War.signal.sDoHeroBackstage 		-= HeroBackstage;
			War.signal.sDoTurretAtk 			-= TurretAtk;
			War.signal.sDoSetProductionSkill 	-= SetProductionSkill;
			War.signal.sDoSkill 				-= Skill;
			War.signal.sDoProp 					-= Prop;
			War.signal.sDoGameOver 				-= GameOver;

			isCheckProp = false;
			StopAllCoroutines ();
		}

		public bool isCheckProp;
		IEnumerator CheckProp()
		{
			while (isCheckProp) 
			{
				yield return new WaitForSeconds (2f);
				if(War.isGameing )
				{
					War.signal.DoProp (War.pvp.GetUnitPropList ());
				}

			}
		}



		//发兵
		public void SendArm(int fromUid, int toUid, int count, int beginUid)
		{
			timeLineData.AddAction (WRAction.Create_SendArm(fromUid, toUid, count, beginUid));
		}


		//升级
		public void Uplevel(int uid, int level, float time)
		{
			timeLineData.AddAction (WRAction.Create_Uplevel(uid, level, time));
		}

		//占领城池
		public void BuildLegionChange(int uid, int legionId)
		{
			timeLineData.AddAction (WRAction.Create_BuildLegionChange(uid, legionId));
		}


		//英雄下阵
		public void HeroBackstage(int heroUid, int targetLegionId)
		{
			timeLineData.AddAction (WRAction.Create_HeroBackstage(heroUid, targetLegionId));
		}

		//箭塔攻击
		public void TurretAtk(int buildUid, int soliderUid)
		{
			timeLineData.AddAction (WRAction.Create_TurretAtk(buildUid, soliderUid));
		}


		//生产技能
		public void SetProductionSkill(int legionId, int skillUid, float speed)
		{
			timeLineData.AddAction (WRAction.Create_SetProductionSkill(legionId, skillUid, speed));
		}

		//放进能
		public void Skill(C_SyncSkill_0x822 c)
		{
			timeLineData.AddAction (WRAction.Create_Skill(c));
		}



		//属性
		public void Prop(List<ProtoFightUnitInfo> unitPropList)
		{
			return;
			timeLineData.AddAction (WRAction.Create_Prop(unitPropList));
		}


		//游戏结束
		public void GameOver()
		{
			timeLineData.AddAction (WRAction.Create_GameOver());
		}
	}

}