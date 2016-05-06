using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.signals;
using Games.Module.Wars;
using Games.Module.Props;
using CC.Runtime.Utils;


namespace Games.Module.Wars
{
	public partial class WarScene : EntityMBBehaviour 
	{
		/** 搜索单位列表--英雄驻扎的建筑 */
		public List<UnitCtl> SearchBuild_ByHero(UnitData hero, int relation)
		{
			List<UnitCtl> list = new List<UnitCtl>();
			int casterLegionId = hero.legionId;
			UnitCtl unitCtl = GetBuild(hero.heroData.buildId);
			RelationType relationType = unitCtl.unitData.GetRelation(casterLegionId);
			if (relation.RValue(relationType) == true)
			{
				list.Add(unitCtl);
			}
			
			return list;
		}


		/** 搜索单位列表--驻扎在建筑里的英雄 */
		public List<UnitCtl> SearchHero_InBuild(UnitData build, int relation)
		{
			List<UnitCtl> list = new List<UnitCtl>();
			int casterLegionId = build.legionId;
			foreach (KeyValuePair<int, UnitCtl> kvp in heroDictByBuild)
			{
				UnitCtl unitCtl = kvp.Value;
				if (unitCtl.unitData == null || unitCtl.death) continue;
				
				if(kvp.Key != build.id) continue;
				
				RelationType relationType = unitCtl.unitData.GetRelation(casterLegionId);
				if (relation.RValue(relationType) == false) continue;
				
				list.Add(unitCtl);
				
			}
			
			return list;
		}

		/** 搜索单位列表--来自某个建筑的士兵 */
		public List<UnitCtl> SearchSolider_FromBuild(UnitData from, int relation)
		{
			List<UnitCtl> list = new List<UnitCtl>();
			int casterLegionId = from.legionId;
			foreach (UnitCtl unitCtl in soliderList)
			{
				if (unitCtl.unitData == null || unitCtl.death) continue;

				if(unitCtl.unitData.from != from) continue;

				RelationType relationType = unitCtl.unitData.GetRelation(casterLegionId);
				if (relation.RValue(relationType) == false) continue;
				
				list.Add(unitCtl);
				
			}
			
			return list;
		}

        /** 搜索单位列表 */
        public List<UnitCtl> SearchUnit( int unitType, int casterLegionId, int relation)
        {
            List<UnitCtl> list = new List<UnitCtl>();

            foreach (KeyValuePair<int, UnitCtl> kvp in unitDict)
            {
                UnitCtl unitCtl = kvp.Value;
                if (unitCtl.unitData == null || unitCtl.death) continue;
                if (unitType.UValue(unitCtl.unitData.unitType) == false) continue;

                RelationType relationType = unitCtl.unitData.GetRelation(casterLegionId);
                if (relation.RValue(relationType) == false) continue;

                list.Add(unitCtl);

            }

            return list;
        }


		/** 搜索单位列表 */
		public List<UnitCtl> SearchUnit(Vector3 point, float radius, int unitType, int casterLegionId, int relation)
		{
			//Debug.LogFormat ("SearchUnit point={0}, radius={1}, unitType={2}, casterLegionId={3}, relation={4}, unitType.USolider()={5}, relation.REnemy()={6}", point, radius, unitType, casterLegionId, relation ,unitType.USolider() , relation.REnemy());
			List<UnitCtl> list = new List<UnitCtl>();

			foreach(KeyValuePair<int, UnitCtl> kvp in unitDict)
			{
				UnitCtl unitCtl = kvp.Value;
				if(unitCtl.unitData == null || unitCtl.death) continue;
				if(unitType.UValue(unitCtl.unitData.unitType) == false) continue;

				RelationType relationType = unitCtl.unitData.GetRelation(casterLegionId);
				if(relation.RValue(relationType) == false) continue;

				if(CheckCircle(unitCtl, point, radius))
				{
					list.Add(unitCtl);
				}

			}

			return list;
		}

		
		/** 搜索单位列表 */
		public UnitCtl SearchUnit_MinDistance(Vector3 point, float radius, int unitType, int casterLegionId, int relation, float around = 0f)
		{
			UnitCtl minUnit = null;
			float minDistance = 999999;
			
			foreach(KeyValuePair<int, UnitCtl> kvp in unitDict)
			{
				UnitCtl unitCtl = kvp.Value;
				if(unitCtl.unitData == null || unitCtl.death || unitCtl.unitData.isTurretHit) continue;
				if(unitType.UValue(unitCtl.unitData.unitType) == false) continue;
				
				RelationType relationType = unitCtl.unitData.GetRelation(casterLegionId);
				if(relation.RValue(relationType) == false) continue;

				float distance = Vector3.Distance(point, unitCtl.transform.position);

				if(distance <= radius && distance < minDistance)
				{
					minUnit = unitCtl;
					minDistance = distance;
				}

				if(distance <= around && minUnit != null)
				{
					return minUnit;
				}
			}
			
			return minUnit;
		}

		public bool CheckCircle( UnitCtl unit, Vector3 point, float radius)
		{
			bool result = false;
			float distance = Vector3.Distance(point, unit.transform.position);
			if(distance <= radius)
			{
				result = true;
			}
			return result;
		}


		public bool SearchCirclePosition(float radius, int legionId, int relation, out Vector3 result)
		{
			List<UnitCtl> soliderList = War.scene.soliderList;


			List<Vector3> 	pointTotals 	= new List<Vector3>();
			List<Vector3> 	pointCenters 	= new List<Vector3>();
			List<int> 		pointCounts 	= new List<int>();

			float distance = radius * 2;
			for(int i = 0; i < soliderList.Count; i ++)
			{
				UnitCtl entity = soliderList[i];

				RelationType relationType = entity.unitData.GetRelation(legionId);
				if (relation.RValue(relationType) == false) continue;


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
				result = pointCenters[maxIndex];

//				War.skillUse.selectCircleView.transform.position = result;
//				War.skillUse.selectCircleView.Radius = radius;
//				War.skillUse.selectCircleView.gameObject.SetActive(true);
				return true;
			}

			result = Vector3.zero;


			return false;
		}



		/*

		public UnitCtl SearchAoeTarget(SkillOperateData operateData, UnitCtl caster)
		{
			UnitCtl minTarget = null;
			float minDistance = 10000f;

			float radius = operateData.skillConfig.radius > 0 ? operateData.skillConfig.radius : minDistance;

			if(operateData.skillConfig.UBuild)
			{
				foreach(UnitCtl unit in buildList)
				{
					RelationType relationType = caster.unitData.GetRelation(unit.unitData.legionId);
					if(operateData.skillConfig.relation.RValue(relationType))
					{
						float distance = Vector3.Distance(caster.transform.position, unit.transform.position);
						if(distance < radius && distance <= minDistance)
						{
							minDistance = distance;
							minTarget = unit;
						}
					}
				}
			}

			if(operateData.skillConfig.USolider)
			{
				foreach(UnitCtl unit in soliderList)
				{
					RelationType relationType = caster.unitData.GetRelation(unit.unitData.legionId);
					if(operateData.skillConfig.relation.RValue(relationType))
					{
						float distance = Vector3.Distance(caster.transform.position, unit.transform.position);
						if(distance < radius && distance <= minDistance)
						{
							minDistance = distance;
							minTarget = unit;
						}
					}
				}
			}

			return minTarget;


		}

		public List<UnitCtl> SearchAoeTargets(SkillData skillData, HitVO hitVO)
		{
			List<UnitCtl> targets = new List<UnitCtl>();

			
			AOEArchor aoeArchor = skillData.aoeArchor;

			if(aoeArchor == AOEArchor.Caster)
			{
				targets.Add(hitVO.caster);
			}
			else if(aoeArchor == AOEArchor.SelectTargets)
			{
				if(skillData.skillConfig.operate == SkillOperateType.SelectUnit)
				{
					if(skillData.operateData.receiveList.Count > 0)
					{
						hitVO.mainTarget = skillData.operateData.receiveList[0];
					}

					foreach(UnitCtl unit in  skillData.operateData.receiveList)
					{
						targets.Add(unit);
					}
				}
				//
				else if(skillData.skillConfig.operate == SkillOperateType.SelectCircle)
				{
					hitVO.isPosition = true;
					hitVO.position = skillData.operateData.receivePosition;

					if(skillData.skillConfig.UBuild)
					{
						foreach(UnitCtl unit in buildList)
						{
							if(SearchCheckCircle(hitVO.caster, unit, skillData))
							{
								targets.Add(unit);
							}
						}
					}

					if(skillData.skillConfig.UHero)
					{
						foreach(KeyValuePair<int, Dictionary<int, UnitCtl>> kvp in heroLegionDict)
						{
							foreach(KeyValuePair<int, UnitCtl> kv in kvp.Value)
							{
								UnitCtl unit = kv.Value;


								if(SearchCheckCircle(hitVO.caster, unit, skillData))
								{
									targets.Add(unit);
								}
							}
						}
					}

					if(skillData.skillConfig.USolider)
					{
						foreach(UnitCtl unit in soliderList)
						{
							if(SearchCheckCircle(hitVO.caster, unit, skillData))
							{
								targets.Add(unit);
							}
						}
					}
					
					Debug.Log("hitVO.isPosition=" + hitVO.isPosition);
					Debug.Log("hitVO.position=" + hitVO.position);
					Debug.Log("skillData.skillConfig.UBuild=" + skillData.skillConfig.UBuild);
					Debug.Log("skillData.skillConfig.UHero=" + skillData.skillConfig.UHero);
					Debug.Log("skillData.skillConfig.USolider=" + skillData.skillConfig.USolider);
					Debug.Log("targets.COUNT=" + targets.Count);
				}
				//
				else if(skillData.skillConfig.operate == SkillOperateType.SelectDirection)
				{
					if(skillData.skillConfig.UBuild)
					{
						foreach(UnitCtl unit in buildList)
						{
							if(SearchCheckDirection(hitVO.caster, unit, skillData))
							{
								targets.Add(unit);
							}
						}
					}

					if(skillData.skillConfig.UHero)
					{
						foreach(KeyValuePair<int, Dictionary<int, UnitCtl>> kvp in heroLegionDict)
						{
							foreach(KeyValuePair<int, UnitCtl> kv in kvp.Value)
							{
								UnitCtl unit = kv.Value;
								
								if(SearchCheckDirection(hitVO.caster, unit, skillData))
								{
									targets.Add(unit);
								}
							}
						}
					}

					if(skillData.skillConfig.USolider)
					{
						foreach(UnitCtl unit in soliderList)
						{
							if(SearchCheckDirection(hitVO.caster, unit, skillData))
							{
								targets.Add(unit);
							}
						}
					}
				}
				//
				else if(skillData.skillConfig.operate == SkillOperateType.Immediately || skillData.skillConfig.operate == SkillOperateType.Passive)
				{

					Debug.Log(string.Format("<color=blue>skillData.skillConfig.UPlayer={0}</color>", skillData.skillConfig.UPlayer));
					Debug.Log(string.Format("<color=blue>skillData.skillConfig.UBuild={0}</color>", skillData.skillConfig.UBuild));
					Debug.Log(string.Format("<color=blue>skillData.skillConfig.USolider={0}</color>", skillData.skillConfig.USolider));
					Debug.Log(string.Format("<color=blue>skillData.skillConfig.UHero={0}</color>", skillData.skillConfig.UHero));
					if(skillData.skillConfig.UPlayer)
					{
						foreach(UnitCtl unit in players)
						{
							if(SearchCheckImmediately(hitVO.caster, unit, skillData))
							{
								targets.Add(unit);
							}
						}
					}


					if(skillData.skillConfig.UBuild)
					{

						foreach(UnitCtl unit in buildList)
						{
							if(SearchCheckImmediately(hitVO.caster, unit, skillData))
							{
								targets.Add(unit);
							}
						}
					}
					
					if(skillData.skillConfig.USolider)
					{

						foreach(UnitCtl unit in soliderList)
						{
							bool result = SearchCheckImmediately(hitVO.caster, unit, skillData);
							
//							Debug.Log(string.Format("<color=blue>Solider result={0}</color>", result));
							if(result)
							{
								targets.Add(unit);
							}
						}
					}

					
					
					if(skillData.skillConfig.UHero)
					{
						foreach(KeyValuePair<int, Dictionary<int, UnitCtl>> kvp in heroLegionDict)
						{
							foreach(KeyValuePair<int, UnitCtl> kv in kvp.Value)
							{
								UnitCtl unit = kv.Value;

								if(SearchCheckImmediately(hitVO.caster, unit, skillData))
								{
									targets.Add(unit);
								}
							}
						}
					}
				}

			}

//			if(hitVO.mainTarget == null && targets.Count > 0) hitVO.mainTarget = targets[0];
			hitVO.allTargets = targets.ToArray();
			return targets;
		}

		public bool SearchCheckImmediately(UnitCtl caster, UnitCtl unit, SkillData skillData)
		{
			bool result = false;
			if(unit.death) return result;
			if(skillData.id == 7 && caster == unit) return result;
			RelationType relationType = caster.unitData.GetRelation(unit.unitData.legionId);
			if(relationType == RelationType.Enemy)
			{
				if(unit.unitData.invincible) return result;
			}

			if(skillData.skillConfig.relation.RValue(relationType))
			{
				result = true;
			}
			return result;
		}
		
		
		public bool SearchCheckDirection(UnitCtl caster, UnitCtl unit, SkillData skillData)
		{
			bool result = false;
			if(unit.death) return result;
			Vector3 ab = skillData.operateData.receiveDirection * skillData.skillConfig.distance;
			Vector3 from = caster.transform.position;
			Vector3 to = from + ab;
			Vector3 point = unit.transform.position;
			Vector3 ac = point - from;
			
			if(Vector3.Dot(ab, ac) > 0)
			{
				if(ac.magnitude <= skillData.skillConfig.distance)
				{
					Vector3 cross = Vector3.Cross(ac, ab);
					float wd = cross.magnitude / ab.magnitude;
					
					if(wd <= skillData.skillConfig.radius)
					{
						result = true;
					}
				}
			}
			return result;
		}

		public bool SearchCheckCircle(UnitCtl caster, UnitCtl unit, SkillData skillData)
		{
			bool result = false;
			if(unit.death) return result;
			RelationType relationType = caster.unitData.GetRelation(unit.unitData.legionId);
			if(skillData.skillConfig.relation.RValue(relationType))
			{
				float distance = Vector3.Distance(skillData.operateData.receivePosition, unit.transform.position);
				if(distance <= skillData.skillConfig.radius)
				{
					result = true;
				}
			}
			return result;
		}
		*/

	}
}
