using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	public class BLegionAI_Skill : EBehaviour
	{
		public int legionId;
		public float intervalMin = 2f; 
		public float intervalMax = 5f; 
		public  float _updateTime;

		protected override void OnStart ()
		{
			base.OnStart ();

			legionId = legionData.legionId;

			_updateTime = Time.time + Random.Range(intervalMin, intervalMax) + War.sceneData.begionDelayTime;

		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			
			if(!War.isGameing)
			{
				_updateTime = Time.time + Random.Range(intervalMin, intervalMax);
				return;
			}
			if(!legionData.aiSkill) return;
			if(Time.time > _updateTime)
			{
				_updateTime = Time.time + Random.Range(intervalMin, intervalMax);
				if(!War.sceneData.enableAISkill) return;
				Execute();
			}
		}

		void Execute()
		{
            for (int i = 0; i < legionData.barSkillUids.Count; i ++)
			{
				int skillUid = legionData.barSkillUids[i];
				SkillOperateData skillOperateData = legionData.skillDatas[skillUid];
				if(AIUse(skillOperateData))
				{
                    skillOperateData.OnUse();

					return;
				}
			}
		}

		public void ExeSkill(int skillId)
		{
			SkillOperateData skillOperateData = legionData.GetSkillDataBySkillId(skillId);
			if (skillOperateData != null)
			{
				if (AIUse (skillOperateData)) 
				{
					skillOperateData.OnUse ();
				}
			}
		}


		bool AIUse(SkillOperateData skillData)
		{
            bool isUse = War.skillWarManager.checkSkillAIType(skillData.skillId, legionData.legionId);
            if(isUse == false)
            {
                return false;
            }
            switch (skillData.skillConfig.operate)
			{
			case SkillOperateType.Immediately:
			case SkillOperateType.Passive:

				return true;
				break;
			case SkillOperateType.SelectUnit:
				return AIUse_SelectUnit(skillData);
				break;
			case SkillOperateType.SelectCircle:
				return AIUse_SelectCircle(skillData);
				break;
			}

			return false;
		}

		bool AIUse_SelectUnit(SkillOperateData skillData)
		{
			skillData.receiveList.Clear ();

            List<UnitCtl> buildList = War.scene.buildList;
            //ai目标
            SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillData.skillId);
            if(skillWarConf.getTargetType() == (int)eSkillWarTargetType.eEffectTargetBuildBeHitMinHp)//正在被攻击&人口最少，没有被攻击则选人口最少的
            {
                int unitType = 0;
                unitType = unitType.UBuild(true);
                int relation = 0;
                relation = relation.ROwn(true);
                List<UnitCtl> listTmp = War.scene.SearchUnit(unitType, legionData.legionId, relation);
                foreach (UnitCtl unit in listTmp)
                {
                    if (unit.unitData.behit == true)
                    {
                        skillData.receiveList.Add(unit);
                        return true;
                    }
                }
                //没有正在被攻击的城池，选择人口钌俚锰
                UnitCtl unitMin = null;
                float hpTmp = 10000.0f;
                foreach (UnitCtl unit in listTmp)
                {
                    if (unit.hp <= hpTmp)
                    {
                        hpTmp = unit.hp;
                        unitMin = unit;
                    }
                }
                if (unitMin != null)
                {
                    if (skillData.EnableUse(unitMin))
                    {
                        skillData.receiveList.Add(unitMin);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

			List<UnitCtl> candidatesList = new List<UnitCtl> ();
  			foreach(UnitCtl entity in buildList)
			{
				if(skillData.EnableUse(entity))
				{
					candidatesList.Add (entity);
				}
			}

			UnitCtl select = null;
			foreach (UnitCtl entity in candidatesList)
			{
				select = entity;
				if (select.legionData.type != LegionType.Neutral) 
				{
					break;
				}
			}

			if (select != null) 
			{
				skillData.receiveList.Add (select);
				return true;
			}

			return false;
		}

		bool AIUse_SelectCircle(SkillOperateData skillData)
		{
			List<UnitCtl> soliderList = War.scene.soliderList;


			List<Vector3> 	pointTotals 	= new List<Vector3>();
			List<Vector3> 	pointCenters 	= new List<Vector3>();
			List<int> 		pointCounts 	= new List<int>();

			float distance = skillData.skillConfig.radius * 2;
			for(int i = 0; i < soliderList.Count; i ++)
			{
				UnitCtl entity = soliderList[i];
				
				RelationType relationType = entity.unitData.GetRelation(skillData.heroData.legionData.legionId);
				if (skillData.skillConfig.relation.RValue(relationType) == false) continue;


				Vector3 pos =entity.transform.position;
				bool hasContain = false;
				for(int index = 0;  index < pointCenters.Count; index ++)
				{
					Vector3 center = pointCenters[index];
					if(Vector3.Distance(center, pos) <= distance)
					{
						pointTotals[index] += pos;
						pointCounts[index] += 1;
						pointCenters[index] =pointTotals[index] / pointCounts[index];
						hasContain = true;
						break;
					}
				}

				if(hasContain == false)
				{
					pointTotals.Add(pos.Clone());
					pointCenters.Add(pos.Clone());
					pointCounts.Add(1);
				}
			}

			int maxIndex = -1;
			int maxCount = -1;
			for(int index = 0;  index < pointCounts.Count; index ++)
			{
				if(maxCount < pointCounts[index])
				{
					maxCount = pointCounts[index];
					maxIndex = index;
				}
			}

			if(maxIndex != -1)
			{
				skillData.receivePosition = pointCenters[maxIndex];


				
//				War.skillUse.selectCircleView.transform.position = skillData.receivePosition;
//				War.skillUse.selectCircleView.Radius = skillData.skillConfig.radius;
//				War.skillUse.selectCircleView.gameObject.SetActive(true);

				return true;
			}


			return false;

		}



	}
}