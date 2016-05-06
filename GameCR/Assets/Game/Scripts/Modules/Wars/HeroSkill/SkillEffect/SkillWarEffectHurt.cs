using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.Actions;
using Games.Module.Props;
using CC.Runtime;
using DG.Tweening;

namespace Games.Module.Wars
{
    /*
     伤害
     */
    public class SkillWarEffectHurt : MonoBehaviour
    {
        public int effectHurt(SkillParameter skillParameter, EffectParameter effectInfo)
        {
            Debug.Log("======" + effectInfo.effect.type + "====" + effectInfo.effect.operation + "---: " + effectInfo.effect.target);
            if (effectInfo.effect.operation == (int)eSkillWarEffectOperation.eEffectAuto)//自动目标
            {
                if (effectInfo.effect.target == (int)eSkillWarTargetType.eEffectTargetSoilderOnWay)//士兵
                {
                    autoHurtSoilderStart(skillParameter, effectInfo);
                }
                else if (effectInfo.effect.target == (int)eSkillWarTargetType.eEffectTargetSoliderMax)//一定范围内影响士兵最多
                {
                    manualHurtRang(skillParameter, effectInfo);
                }
                else//城市
                {
                    autoHurtBuildAll(skillParameter, effectInfo);
                }
            }
            else if (effectInfo.effect.operation == (int)eSkillWarEffectOperation.eEffectManualTarget)//手动目标
            {
                autoHurtBuildAll(skillParameter, effectInfo);
            }
            else if (effectInfo.effect.operation == (int)eSkillWarEffectOperation.eEffectmanualRange)//手动范围
            {
                manualHurtRang(skillParameter, effectInfo);
            }

            return 0;
        }

        #region 自动伤害城池
        //--------------------自动伤害城池------------------------------
        private int autoHurtBuildAll(SkillParameter skillParameter, EffectParameter effectInfo)
        {
            SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillParameter.skillId);
            Debug.Log("=========" + effectInfo.effect.animPathStart + "++++++" + effectInfo.effect.animPathEnd);
            //发射技能 :号令天下 无双 连营
            if (effectInfo.effect.isSend == 1)
            {
                float timeProcess = 1.5f;
                float height = 8.0f;

                int idx = 0;
                foreach (UnitCtl unit in effectInfo.unitCtlList)//获取城市
                {
                    if (effectInfo.effect.animPathStart != "temp")
                    {
                        int lengion = War.skillWarManager.getLegionByHeroUid(skillParameter.curHeroUid);
                        Vector3 fromPos = War.scene.GetLegionPosition(lengion);
                        War.skillWarManager.sendSkillAnim(fromPos, unit, effectInfo.effect.animPathStart, height, timeProcess);
                        effectInfo.waitTime = timeProcess;
                    }
                    idx++;
                    bool needDealSKill2 = false;
                    if (idx == effectInfo.unitCtlList.Count)
                    {
                        needDealSKill2 = true;
                    }
                    War.skillWarManager.StartCoroutine(autoHurtBuildSingleEnd(skillParameter, effectInfo, unit, needDealSKill2));
                }
            }
            else
            {
                int idx = 0;
                foreach (UnitCtl unit in effectInfo.unitCtlList)//获取城市
                {
                    idx++;
                    bool needDealSKill2 = false;
                    if (idx == effectInfo.unitCtlList.Count)
                    {
                        needDealSKill2 = true;
                    }
                    War.skillWarManager.StartCoroutine(effectHurtSingleStart(skillParameter, effectInfo, unit, needDealSKill2));
                }
            }
            return 0;
        }

        //单个技能效果
        IEnumerator effectHurtSingleStart(SkillParameter skillParameter, EffectParameter effectInfo, UnitCtl unit, bool needDealSkill2)
        {
            float idxRand = Random.Range(0.0f, 1.0f);
            //Debug.LogFormat("=====idxRand:{0}", idxRand);
            yield return new WaitForSeconds(idxRand);
            SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillParameter.skillId);
            if (effectInfo.effect.animPathStart != "temp")
            {
                GameObject effectPrefab = WarRes.GetPrefab(effectInfo.effect.animPathStart);
                GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
                effectAnim.transform.position = unit.transform.position;
                effectInfo.waitTime = 0.2f;
            }

            War.skillWarManager.StartCoroutine(autoHurtBuildSingleEnd(skillParameter, effectInfo, unit, needDealSkill2));
        }
        IEnumerator autoHurtBuildSingleEnd(SkillParameter skillParameter, EffectParameter effectInfo, UnitCtl unit, bool needDealSkill2)
        {
            yield return new WaitForSeconds(effectInfo.waitTime);
            SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillParameter.skillId);
            Debug.Log("++++++animPathEnd: " + effectInfo.effect.animPathEnd);
            if (effectInfo.effect.animPathEnd != "temp")
            {
                GameObject effectPrefab = WarRes.GetPrefab(effectInfo.effect.animPathEnd);
                GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
                effectAnim.transform.position = unit.transform.position;
                DelayDestory destoryTimer = effectAnim.GetComponent<DelayDestory>();
                if (destoryTimer != null && effectInfo.effect.time > 0)
                {
                    destoryTimer.DelayTime = effectInfo.effect.time;
                    effectInfo.effectAnim = effectAnim;
                }
               // effectInfo.waitTime = 0.2f;
            }

            War.skillWarManager.StartCoroutine(autoHurtBuildAllHurtSingle(skillParameter, effectInfo, unit, needDealSkill2));
        }

        //伤害单个
        IEnumerator autoHurtBuildAllHurtSingle(SkillParameter skillParameter, EffectParameter effectInfo, UnitCtl unit, bool needDealSkill2)
        {
            yield return new WaitForSeconds(0);
            int lengion = War.skillWarManager.getLegionByHeroUid(skillParameter.curHeroUid);
            if(lengion == unit.unitData.legionId)
            {
                yield break;
            }
            float hurtValue = effectInfo.value;
            if (effectInfo.effect.type == (int)eSKillWarEffectType.eEffectHurtBuidingMax)
            {
                hurtValue = unit.unitData.maxHp * effectInfo.value / 100;
            }
            else if(effectInfo.effect.type == (int)eSKillWarEffectType.eEffectHurtRate)
            {
                Debug.LogFormat("=================hp:{0} value:{1}", unit.unitData.hp, effectInfo.value);
                hurtValue = unit.unitData.hp * effectInfo.value / 100;
            }
            DamageVO damageVo = War.skillWarManager.GetDamageParameter(hurtValue, false, DamageType.ATTACK, unit, effectInfo.caster);
            unit.Damage(damageVo, 0f, 0.2f, effectInfo.effect.hurtCount);
            //War.skillWarManager.soldierDieSHow(unit);

            //处理技能2
            if (needDealSkill2 == true && skillParameter.curDealSkillIdx == 1)
            {
                Debug.LogFormat("=====needDealSkill2 true=====");
                War.skillWarManager.dealSkill2Effect(skillParameter);
            }

            if (effectInfo.effect.time > 0)
            {
                //War.skillWarManager.StartCoroutine(autoHurtBuildAllTimer(skillParameter, unit));
                BuildSkillDots skillDots = unit.GetComponent<BuildSkillDots>();
                if (skillDots != null)
                {
                    skillDots.GetSkillHurt( effectInfo);
                }
            }
            Debug.Log(string.Format("<color=yellow> autoHurtBuildAllHurtSingle all=skill id:{0}, lvl:{1} v:{2}  effecttime:{3}</color>",
                            skillParameter.skillId, skillParameter.skillLvl, effectInfo.value, effectInfo.effect.time));
        }



        //--------------------定时伤害------------------------------

        #endregion

        #region 手动范围
        //--------------------手动范围------------------------------
        private int manualHurtRang(SkillParameter skillParameter, EffectParameter effectInfo)
        {
            if (effectInfo.effect.animPathStart != "temp")
            {
                GameObject effectPrefab = WarRes.GetPrefab(effectInfo.effect.animPathStart);
                GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
                effectAnim.transform.position = effectInfo.receivePos;
            }
            War.skillWarManager.StartCoroutine(manualHurtRangEnd(skillParameter, effectInfo)); 

            return 0;
        }

        IEnumerator manualHurtRangEnd(SkillParameter skillParameter, EffectParameter effectInfo)
        {
            yield return new WaitForSeconds(0.2f);
            //UnitCtl curUnit = War.scene.GetBuild(skillParameter.curHeroBuildId);

            foreach(UnitCtl unit in effectInfo.unitCtlList)
            {
				try
				{
					if (unit == null || unit.unitData == null)
	                {
	                    continue;
	                }
	                if (unit.unitData.hp <= 0)
	                {
	                    continue;
	                }

	                if(unit.unitData.unitType == UnitType.Build)
	                {
	                    int lengion = War.skillWarManager.getLegionByHeroUid(skillParameter.curHeroUid);
	                    if (lengion == unit.unitData.legionId)
	                    {
	                        yield break;
	                    }

	                    float hurt = effectInfo.value - (effectInfo.unitCtlList.Count - 1);
	                    if(hurt >= 1)
	                    {
	                        DamageVO damageVo = War.skillWarManager.GetDamageParameter(hurt, false, DamageType.ATTACK, unit, effectInfo.caster);
	                        unit.Damage(damageVo, 0f, 0.2f, effectInfo.effect.hurtCount);
	                    }
	                }
	                else
	                {
	                    TrackParamClass param = new TrackParamClass();
	                    param.caster = effectInfo.caster;
	                    param.high = 4.0f;
	                    param.range = 5.0f;
	                    param.speedTrack = 20.0f;
	                    param.unitCtlCur = unit;
	                    unit.GetComponent<SkillTrackController>().addForceParabola(effectInfo.receivePos, 6.0f, param);
	                }
				}
				catch(System.Exception e)
				{
					if (Application.isEditor)
						Debug.Log (e);

					break;
				}

            }

            SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillParameter.skillId);

            Debug.Log(string.Format("<color=yellow> manualHurtRang=id:{0} {1} leftcount{2}</color>",
                                                    skillParameter.skillId, effectInfo.value, effectInfo.unitCtlList.Count));
            if (skillParameter.curDealSkillIdx == 1)
            {
                War.skillWarManager.dealSkill2Effect(skillParameter);
            }

        }
        #endregion

        #region 伤害出征士兵
        //==================伤害出征士兵 冰冻效果=========================
        private int autoHurtSoilderStart(SkillParameter skillParameter, EffectParameter effectInfo)
        {
            Debug.Log("=========" + effectInfo.effect.animPathStart + "++++++" + effectInfo.effect.animPathEnd);
            //播放技能特效
            if (effectInfo.effect.animPathStart != "temp")
            {
                GameObject effectPrefabSelf = WarRes.GetPrefab(effectInfo.effect.animPathStart.ToLower());
                GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefabSelf);

                int lengion = War.skillWarManager.getLegionByHeroUid(skillParameter.curHeroUid);
                Vector3 fromPos = War.scene.GetLegionPosition(lengion);
                effectAnim.transform.position = fromPos;
                effectInfo.waitTime = 0.8f;
            }
            War.skillWarManager.StartCoroutine(autoHurtSoilderEnd(skillParameter, effectInfo));
            return 0;
        }

        IEnumerator autoHurtSoilderEnd(SkillParameter skillParameter, EffectParameter effectInfo)
        {
            yield return new WaitForSeconds(effectInfo.waitTime);
            SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillParameter.skillId);

            //播放技能，针对所有出征士兵
            int unitType = 0;
            unitType = unitType.USolider(true);
            int relation = 0;
            relation = relation.REnemy(true);
            List<UnitCtl> unitSoldierList = War.scene.SearchUnit(unitType, effectInfo.caster.unitData.legionId, relation);
            foreach (UnitCtl unit in unitSoldierList)
            {
                if(unit == null)
                {
                    continue;
                }
                if (effectInfo.effect.animPathEnd != "temp")
                {
                    GameObject effectPrefab = WarRes.GetPrefab(effectInfo.effect.animPathEnd.ToLower());
                    GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
                    effectAnim.transform.position = unit.transform.position;
                }
            }
            
            foreach (UnitCtl unit in effectInfo.unitCtlList)
            {
                if(unit == null)
                {
                    continue;
                }
                unit.DamageToDeath(effectInfo.caster);
            }


            Debug.Log(string.Format("<color=yellow> autoHurtSoilder=id:{0} {1}</color>",
                                                    skillParameter.skillId, effectInfo.unitCtlList.Count));
            //处理技能2
            if (skillParameter.curDealSkillIdx == 1)
            {
                War.skillWarManager.dealSkill2Effect(skillParameter);
            }
        }

        #endregion

    }

}