using UnityEngine;
using System.Collections;
using System.Security.Policy;
using CC.Runtime.Actions;

namespace Games.Module.Wars
{
	public class BUnitTurret : EBehaviour  {
		/*
		public int team = 1;
		public SkillData skillData;

		public SkillOperateData skillOperateData;
		public float attackCD = 1f;
		public float attackCDMax = 1F;

		public GameObject model;
		public Transform pao;
		public Transform paoKou;


		public GameObject birthEffect;
		public GameObject deathEffect;
		DelayDestory delayDestory;
		protected override void OnAwake ()
		{
			UnitCtl unit = GetComponent<UnitCtl>();
			UnitData unitData = new UnitData();
			unitData.unitType = UnitType.Turret;
			unitData.maxHp = 30;
			unitData.hp = 30;
			unitData.legionId = team; 

			AddData(unitData);

			base.OnAwake ();
			unitData.Init();

//			SkillAI skillAI = BattleCreator.CreateSkill(skillData, unit, gameObject);
//			skillAI.enabled = false;
//			unit.attackAI = skillAI;


			GameObject go = (GameObject) GameObject.Instantiate(birthEffect, transform.position,Quaternion.identity);
			go.SetActive(true);

			Invoke("ModelShow", 0.3f);
			delayDestory = GetComponent<DelayDestory>();
			delayDestory.OnBeforeDestroy += OnBeforeDestroy;
		}

		void ModelShow()
		{
			model.SetActive(true);
		}


		void OnBeforeDestroy()
		{
			GameObject go = (GameObject) GameObject.Instantiate(deathEffect, transform.position,Quaternion.identity);
			go.SetActive(true);
		}

		protected override void OnDisable ()
		{
			base.OnDisable ();
			delayDestory.OnBeforeDestroy -= OnBeforeDestroy;
		}


		protected override void OnUpdate ()
		{
			base.OnUpdate ();

			if(skillOperateData == null && War.isGameing)
			{
				skillOperateData = new SkillOperateData();
				skillOperateData.skillId = 1000;
				skillOperateData.heroData = null;
				skillOperateData.Init();
				skillOperateData.caster = GetComponent<UnitCtl>();
				Debug.Log("skillOperateData create");
			}

			attackCD -= Time.deltaTime;
			if(attackCD <= 0)
			{
				attackCD = attackCDMax;
				if(skillOperateData != null)
				{
					UnitCtl target = War.scene.SearchAoeTarget(skillOperateData, skillOperateData.caster);
					if(target != null)
					{
						skillOperateData.receiveList.Clear();
						skillOperateData.receiveList.Add(target);
						Debug.Log("skillOperateData OnUse");
						skillOperateData.OnUse();
						float distance = Vector3.Distance(transform.position, target.transform.position);
						if(distance > 3)
						{
							pao.LookAt(target.transform.position + Vector3.up * 3F);
						}
						else
						{
							pao.LookAt(target.transform.position+ Vector3.up * 0.5F);
						}
						iTween.MoveAdd(paoKou.gameObject, iTween.Hash("amount",	Vector3.forward * -0.3F,		"time",0.1F, 	"space", Space.Self));
						iTween.MoveAdd(paoKou.gameObject, iTween.Hash("amount",	Vector3.forward * 0.3F,			"time",0.3F, 	"space", Space.Self, 	"delay", 0.2F));
					}
				}
			}
		}
	*/
	}
}