using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games.Module.Props;
using CC.Runtime.Actions;
using CC.Runtime;

namespace Games.Module.Wars
{
   
    public class SkillWarEffectSpecial
    {
       //=====技能目标需要特殊处理 =====
        #region 灼烧技能删选城市
        public void getUnitCtlBurn(EffectParameter effectParameter, Dictionary<int, UnitCtl> unitCtlSkill1Dic)
        {
            //随机获取城池
            UnitCtl unitCtlNewBurn = null;//新灼烧的城市
            List<UnitCtl> unitCtlNotBurnList = new List<UnitCtl>();
            List<UnitCtl> unitCtlBurn = new List<UnitCtl>();
            foreach (UnitCtl unit in effectParameter.unitCtlList)
            {
                if (unit.unitData.burn == true)
                {
                    unitCtlBurn.Add(unit);//获取有灼烧效果的城市
                    continue;
                }
                unitCtlNotBurnList.Add(unit);//获取没有灼烧效果的城市
            }
            //随机获取城池
            //if (unitCtlNotBurnList.Count > 0)
            //{
            //    int idxRand = Random.Range(0, unitCtlNotBurnList.Count);
            //    int idx = 0;
            //    foreach (UnitCtl unit in unitCtlNotBurnList)
            //    {
            //        Debug.Log("=======" + idx + "----- " + idxRand);
            //        if (idx == idxRand)
            //        {
            //            unitCtlNewBurn = unit;
            //            break;
            //        }
            //        idx++;
            //    }
            //}
            //获取人口最大的城池
            float maxCount = 0;
            foreach (UnitCtl unit in unitCtlNotBurnList)
            {
                if (unit.unitData.hp >= maxCount)
                {
                    maxCount = unit.unitData.hp;
                    unitCtlNewBurn = unit;
                }
            }
            //添加新灼烧的城市
            if (unitCtlNewBurn != null)
            {
                unitCtlBurn.Add(unitCtlNewBurn);
            }
            effectParameter.unitCtlList = unitCtlBurn;
            unitCtlSkill1Dic.Clear();
            unitCtlSkill1Dic[unitCtlNewBurn.unitData.id] = unitCtlNewBurn;
            Debug.LogFormat("<color=green> =====dead soldier :{0}====</color>", effectParameter.unitCtlList.Count);
        }
        #endregion

        #region 特殊处理技能作用位置
        public void getUnitCtlEx(EffectParameter effectParameter, Dictionary<int, UnitCtl> unitCtlSkill1Dic)
        {
            List<UnitCtl> unitCtlListTmp = effectParameter.unitCtlList;
            effectParameter.unitCtlList = new List<UnitCtl>();
            int maxLoop = 0;
            while (true)
            {
                maxLoop++;
                if (maxLoop >= 300)
                {
                    Debug.LogFormat("<color=red> =====max loop :{0}====", maxLoop);
                    break;
                }
                if (unitCtlListTmp.Count <= 0)
                {
                    break;
                }
                int idx = Random.Range(0, unitCtlListTmp.Count - 1);
                UnitCtl unit = unitCtlListTmp[idx];
                unitCtlListTmp.RemoveAt(idx);
                if (unit != null)
                {
                    effectParameter.unitCtlList.Add(unit);
                    unitCtlSkill1Dic.Remove(unit.unitData.id);
                }
                if (effectParameter.unitCtlList.Count >= (int)effectParameter.value)
                {
                    break;
                }
            }
        }
        #endregion

        #region 选取一定数量
        public void getRandomCount(List<UnitCtl> unitAllList, int count)
        {
            int loopCount = 0;
            if(unitAllList.Count > count)
            {
                loopCount = unitAllList.Count - count;
            }
            for(int i = 0; i < loopCount; i ++)
            {
                int idx = Random.Range(0, unitAllList.Count - 1);
                if(idx  < unitAllList.Count)
                {
                    unitAllList.RemoveAt(idx);
                }
            }
        }
        #endregion
        //============技能==================
        #region 英雄上阵
        public void effectHeroToBuild(SkillParameter skillParameter, EffectParameter effectParameter)
        {
//			Debug.LogFormat("英雄上阵 effectHeroToBuild  effectParameter.unitCtlList.count={0}" , effectParameter.unitCtlList.Count);
            foreach (UnitCtl unit in effectParameter.unitCtlList)
            {
                int lengion = War.skillWarManager.getLegionByHeroUid(skillParameter.curHeroUid);
				War.signal.HeroSettledBuild(lengion, skillParameter.skillUid, unit.unitData.id);
                break;
            }
               
        }
        #endregion

        #region 无法出兵
        public int effectBuildCantSendSoldierStart(SkillParameter skillParameter, EffectParameter effectParameter)
        {
            //播放技能特效
            if (effectParameter.effect.animPathStart != "temp")
            {
                GameObject effectPrefabSelf = WarRes.GetPrefab(effectParameter.effect.animPathStart.ToLower());
                GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefabSelf);

                int lengion = War.skillWarManager.getLegionByHeroUid(skillParameter.curHeroUid);
                Vector3 fromPos = War.scene.GetLegionPosition(lengion);
                effectAnim.transform.position = fromPos;
                effectParameter.waitTime = 0.5f;
            }

            foreach (UnitCtl unit in effectParameter.unitCtlList)
            {
                if (unit == null)
                {
                    continue;
                }
                BuildSkillDots skillDots = unit.GetComponent<BuildSkillDots>();
                if (skillDots != null)
                {
                    skillDots.buildStopSendsoldier(effectParameter);
                }
            }

            Debug.Log(string.Format("<color=yellow> effectBuildCantSendSoldierStart all effid={0} time={1} count={2}</color>",
                                                  effectParameter.effect.id, effectParameter.effect.time, effectParameter.unitCtlList.Count));

            ////处理技能2
           // War.skillWarManager.StartCoroutine(useSkill2Effect(skillParameter, 1.0f));
            return 0;
        }

        IEnumerator useSkill2Effect(SkillParameter skillParameter, float time)
        {
            yield return new WaitForSeconds(time);
            if (skillParameter.curDealSkillIdx == 1)
            {
                War.skillWarManager.dealSkill2Effect(skillParameter);
            }
            Debug.Log(string.Format("<color=yellow> use second skill :{0}</color>", skillParameter.skillId));
        }


        #endregion

        #region 添加属性
        public int changeAttribute(SkillParameter skillParameter, EffectParameter effectParameter)
        {
            //SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillParameter.skillId);
            Debug.Log("changeAttribute=========" + effectParameter.effect.animPathStart + "++++++: " + effectParameter.effect.animPathEnd);
            //播放技能特效
            if (effectParameter.effect.animPathStart != "temp")
            {
                GameObject effectPrefabSelf = WarRes.GetPrefab(effectParameter.effect.animPathStart);
                GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefabSelf);

                int lengion = War.skillWarManager.getLegionByHeroUid(skillParameter.curHeroUid);
                Vector3 fromPos = War.scene.GetLegionPosition(lengion);
                effectAnim.transform.position = fromPos;

            }

            foreach (UnitCtl unit in effectParameter.unitCtlList)
            {
                if (unit == null)
                {
                    continue;
                }
                BuildSkillDots skillDots = unit.GetComponent<BuildSkillDots>();
                if (skillDots != null)
                {
                    skillDots.buildChangeAttri(effectParameter);
                }
            }

            Debug.Log(string.Format("<color=yellow> addAttribute all skill id={0} effid={1}</color>", skillParameter.skillId, effectParameter.effect.id));
            return 0;
        }


        #endregion

        #region 速度降为0
        public int stopSoldierStart(SkillParameter skillParameter, EffectParameter effectInfo)
        {
            Debug.Log("stopSoldierStart=========" + effectInfo.effect.animPathStart + "++++++" + effectInfo.effect.animPathEnd);
            //播放技能特效
            if (effectInfo.effect.animPathStart != "temp")
            {
                GameObject effectPrefabSelf = WarRes.GetPrefab(effectInfo.effect.animPathStart.ToLower());
                GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefabSelf);
                effectAnim.transform.position = effectInfo.receivePos;

                effectInfo.waitTime = 0.8f;
            }
            War.skillWarManager.StartCoroutine(stopSoldierEnd(skillParameter, effectInfo));
            return 0;
        }
        IEnumerator stopSoldierEnd(SkillParameter skillParameter, EffectParameter effectParameter)
        {
            yield return new WaitForSeconds(effectParameter.waitTime);
            //所有士兵显示被击效果
            //int unitType = 0;
            //unitType = unitType.USolider(true);
            //int relation = 0;
            //relation = relation.REnemy(true);
            //List<UnitCtl> unitSoldierList = War.scene.SearchUnit(unitType, effectParameter.caster.unitData.legionId, relation);
            foreach (UnitCtl unit in effectParameter.unitCtlList)
            {
                if (unit == null)
                {
                    continue;
                }
                if (unit.unitData == null)
                {
                    continue;
                }
                if (effectParameter.effect.animPathEnd != "temp")
                {
                    GameObject effectPrefab = WarRes.GetPrefab(effectParameter.effect.animPathEnd.ToLower());
                    GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
                    effectAnim.transform.position = unit.transform.position;
                }
            }

            Prop[] props = new Prop[] { Prop.CreateInstance(PropId.StateFreezedMoveSpeed, 1) };
            AttachPropData attachPropData = new AttachPropData(props);
            Debug.LogFormat("=====stop soldier count:{0}", effectParameter.unitCtlList.Count);
            foreach (UnitCtl unit in effectParameter.unitCtlList)
            {
                if (unit == null)
                {
                    continue;
                }
                if (unit.unitData == null)
                {
                    continue;
                }


                if (unit.unitData.unitType == UnitType.Build)
                {
                    BuildSkillDots skillDots = unit.GetComponent<BuildSkillDots>();
                    if (skillDots != null)
                    {
                        skillDots.buildStopSendsoldier(effectParameter);
                    }
                }
                else
                {
                    if (effectParameter.effect.buffAnimPath != "temp")
                    {
                        GameObject effectPrefab = WarRes.GetPrefab(effectParameter.effect.buffAnimPath.ToLower());
                        GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
                        effectAnim.transform.position = unit.transform.position;
                        DelayDestory destoryTimer = effectAnim.GetComponent<DelayDestory>();
                        if (destoryTimer != null)
                        {
                            destoryTimer.DelayTime = effectParameter.value;
                        }
                    }
                    unit.unitData.AppProps(attachPropData, true);
                }
            }

            if (effectParameter.value > 0)
            {
                War.skillWarManager.StartCoroutine(stopSoldierTimer(effectParameter, attachPropData));
            }
            
            Debug.Log(string.Format("<color=yellow> stopSoldier all skill id={0} effid={1} {2}</color>", skillParameter.skillId, effectParameter.effect.id, effectParameter.value));
        }


        IEnumerator stopSoldierTimer(EffectParameter effectParameter, AttachPropData attachPropData)
        {
            yield return new WaitForSeconds(effectParameter.value);

            foreach (UnitCtl unit in effectParameter.unitCtlList)
            {
                if (unit == null)
                {
                    continue;
                }
                if (unit.unitData == null)
                {
                    continue;
                }
                if (unit.unitData.unitType == UnitType.Build)
                {
                    continue;
                }
                else
                {
                    unit.unitData.RevokeProps(attachPropData);
                }
            }

            Debug.Log(string.Format("<color=yellow> stopSoldierTimer </color>"));
        }

        #endregion

        #region 加盾
        public int addShieldStart(SkillParameter skillParameter, EffectParameter effectParameter)
        {
            Debug.Log("=========" + effectParameter.effect.animPathStart + "++++++" + effectParameter.effect.animPathEnd);
            Dictionary<int, GameObject> animDic = new Dictionary<int, GameObject>();
            //播放技能特效
            foreach (UnitCtl unit in effectParameter.unitCtlList)//获取城市
            {
                if (effectParameter.effect.animPathStart != "temp")
                {
                    GameObject effectPrefab = WarRes.GetPrefab(effectParameter.effect.animPathStart);
                    GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
                    effectAnim.transform.position = unit.transform.position;
                    DelayDestory destoryTimer = effectAnim.GetComponent<DelayDestory>();
                    if (destoryTimer != null)
                    {
                        destoryTimer.DelayTime = effectParameter.effect.time;
                    }
                    animDic.Add(unit.unitData.id, effectAnim);
                    unit.unitCtl.BeforeDamage += OnBeforeDamage;
                    unit.unitData.shield = effectParameter.value;
                    War.skillWarManager.StartCoroutine(addShieldTimer(skillParameter, effectParameter));
                    Debug.Log("==============effect.time: " + effectParameter.effect.time);
                }
            }
            //处理特效，城市血没后要删除特效
            War.skillWarManager.StartCoroutine(delShieldWhenHurt(animDic, effectParameter.unitCtlList, effectParameter.effect.time));
            //处理技能2
            if (skillParameter.curDealSkillIdx == 1)
            {
                War.skillWarManager.dealSkill2Effect(skillParameter);
            }
            Debug.Log(string.Format("<color=yellow> addShield addvalue:{0} </color>",
                                                   effectParameter.value));
            return 0;
        }

        public void OnBeforeDamage(DamageVO damageVO)
        {
            if(damageVO.damageType == DamageType.HEAL)
            {
                return;
            }
            Debug.Log("=====OnBeforeDamage=====" + damageVO.target.unitData.shield + "====: " + damageVO.value);
            if (damageVO.target.unitData.shield < damageVO.value)
            {
                damageVO.target.unitData.shield = 0.0f;
                damageVO.value -= damageVO.target.unitData.shield;
            }
            else
            {
                damageVO.target.unitData.shield -= damageVO.value;
                damageVO.value = 0.0f;
            }

        }
        IEnumerator delShieldWhenHurt(Dictionary<int, GameObject> animDic, List<UnitCtl> unitCtlList, int timerAll)
        {
            int timer = 0;
            while (true)
            {
                timer++;
                if (timer >= timerAll)
                {
                    break;
                }
                yield return new WaitForSeconds(1);

                //Debug.LogFormat("=======delShieldWhenHurt=======");
                if (animDic.Count == 0)
                {
                    break;
                }
                for (int i = 0; i < unitCtlList.Count; i++)
                {
                    UnitCtl unit = unitCtlList[i];
                    if (unit.unitData.shield <= 0.1f)
                    {
                        GameObject effectAnim;
                        if (!animDic.TryGetValue(unit.unitData.id, out effectAnim))
                        {
                            continue;
                        }
                        DelayDestory destoryTimer = effectAnim.GetComponent<DelayDestory>();
                        if (destoryTimer != null)
                        {
                            destoryTimer.DelayTime = 0;
                        }
                        animDic.Remove(unit.unitData.id);
                    }
                }
            }
        }
        IEnumerator addShieldTimer(SkillParameter skillParameter, EffectParameter effectParameter)
        {
            yield return new WaitForSeconds(effectParameter.effect.time);
            foreach (UnitCtl unit in effectParameter.unitCtlList)//获取城市
            {
                //Debug.Log("===unit id===" + unit.unitData.id);
                unit.unitCtl.BeforeDamage -= OnBeforeDamage;
                unit.unitData.shield = 0.0f;
            }

            Debug.Log(string.Format("<color=yellow> addShieldTimer </color>"));
        }

        #endregion


        #region 沉默
        public int heroSilence(SkillParameter skillParameter, EffectParameter effectParameter)
        {
            Debug.Log("=========" + effectParameter.effect.animPathStart + "++++++" + effectParameter.effect.animPathEnd);

            Prop[] props = new Prop[] { Prop.CreateInstance(PropId.StateSilence, 1) };
            AttachPropData attachPropData = new AttachPropData(props);

            foreach (UnitCtl unit in effectParameter.unitCtlList)
            {
                if (effectParameter.effect.animPathStart != "temp")
                {
                    GameObject effectPrefab = WarRes.GetPrefab(effectParameter.effect.animPathStart);
                    GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
                    effectAnim.transform.position = unit.transform.position;
                    //DelayDestory destoryTimer = effectAnim.GetComponent<DelayDestory>();
                    //if (destoryTimer != null)
                    //{
                    //    destoryTimer.DelayTime = skillParameter.effect.time;
                    //}
                }
                //todo 沉默
                unit.unitData.AppProps(attachPropData, true);
                if (effectParameter.effect.time > 0)
                {
                    War.skillWarManager.StartCoroutine(heroSilenceSkill2Timer(effectParameter, attachPropData));
                }
                //处理技能2
                if (skillParameter.curDealSkillIdx == 1)
                {
                    War.skillWarManager.dealSkill2Effect(skillParameter);
                }
                Debug.Log(string.Format("<color=yellow> heroSilenceSkill2 to {0}  </color>",
                                      unit.unitData.id));
            }
            return 0;
        }

        IEnumerator heroSilenceSkill2Timer(EffectParameter effectParameter, AttachPropData attachPropData)
        {
            yield return new WaitForSeconds(effectParameter.effect.time);

            foreach (UnitCtl unit in effectParameter.unitCtlList)//获取城市
            {
                //todo 沉默
                unit.unitData.RevokeProps(attachPropData, true);
            }
            Debug.Log(string.Format("<color=yellow> heroSilenceSkill2Timer </color>"));
        }
        #endregion

        #region 显示城市士兵数量
        //public int effectShowNum(CSkillEffectDataItem effect, List<UnitCtl> unitCtlList, SkillOperateData skillOperateDate, int showEffect)
        //{
        //    if (effect.operation == (int)eSkillWarEffectOperation.eEffectAuto)//自动目标
        //    {
        //        //autoHurtBuildAllShowNum(effect, unitCtlList, skillOperateDate, showEffect);
        //    }
        //    else if (effect.operation == (int)eSkillWarEffectOperation.eEffectManualTarget)//手动目标
        //    {

        //    }
        //    return 0;
        //}

        //private int autoHurtBuildAllShowNum(CSkillEffectDataItem effect, List<UnitCtl> unitCtlList, SkillOperateData skillOperateDate, int showEffect)
        //{
        //    List<GameObject> effectAnimList = new List<GameObject>();
        //    SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillOperateDate.skillId);

        //    //播放技能特效
        //    if (showEffect == 1 && skillWarConf.animPathStart != "temp")
        //    {
        //        GameObject effectPrefabSelf = WarRes.GetPrefab(skillWarConf.animPathStart.ToLower());
        //        GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefabSelf);
        //        effectAnim.transform.position = War.scene.GetBuild(skillOperateDate.heroData.buildId).transform.position;
        //    }

        //    foreach (UnitCtl unit in unitCtlList)
        //    {
        //        if (showEffect == 1)
        //        {
        //            GameObject effectPrefab = WarRes.GetPrefab(skillWarConf.animPathEnd.ToLower());
        //            GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
        //            effectAnim.transform.position = unit.transform.position;
        //        }

        //        unit.unitData.showHP = true;
        //    }
        //    if (effect.time > 0)
        //    {
                
        //    }
        //    Debug.Log(string.Format("<color=yellow> autoHurtBuildAllShowNum all </color>"));
        //    return 0;
        //}
        //public int autoBuildAllShowNumTimer(SkillEffectInfoTImer effectInfoTimer)
        //{
        //    if(effectInfoTimer.timer > 1)
        //    {
        //        effectInfoTimer.timer--;
        //        return 0;
        //    }

        //    foreach (UnitCtl unit in effectInfoTimer.unitList)//获取城市
        //    {
        //        Debug.Log("===unit id==="+ unit.unitData.id);
        //        unit.unitData.showHP = false;
        //    }
        //    effectInfoTimer.timer--;
        //    Debug.Log(string.Format("<color=yellow> autoAddBuildAllShowNumTimer all </color>" ));

        //    return 0;
        //}
        #endregion

        #region 快速前往某地
        public int GotoBuildSoon(SkillParameter skillParameter, EffectParameter effectParameter)
        {
            Debug.Log("=========" + effectParameter.effect.animPathStart + "++++++" + effectParameter.effect.animPathEnd);

            if (effectParameter.unitCtlList.Count <= 0)
            {
                return -1;
            }
            UnitCtl unit = effectParameter.unitCtlList[0];
            if (effectParameter.effect.animPathStart != "temp")
            {
                GameObject effectPrefab = WarRes.GetPrefab(effectParameter.effect.animPathStart.ToLower());
                GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
                effectAnim.transform.position = unit.transform.position;

            }
            War.skillWarManager.StartCoroutine(GotoBuildSoonEnd(skillParameter, effectParameter));
            return 0;
        }

        IEnumerator GotoBuildSoonEnd(SkillParameter skillParameter, EffectParameter effectParameter)
        {
            yield return new WaitForSeconds(1.0f);

            UnitCtl unit = effectParameter.unitCtlList[0];
            //SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillParameter.skillId);
           
            UnitCtl curUnit = War.scene.GetUnitForUID(effectParameter.curBuildUid);
            if(curUnit != null)
            {
                curUnit.GetComponent<BSendArming>().Send(unit, (int)effectParameter.value, 20.0f);
            }
            Debug.Log(string.Format("<color=yellow> GotoBuildSoon to {0} {1}</color>",
                                                 unit.unitData.id, effectParameter.value));

        }

        #endregion

        #region 灼烧标记
        public int burnTag( EffectParameter effectParameter)
        {
            Debug.Log("=========: " + effectParameter.effect.animPathStart + " ++++++: " + effectParameter.effect.animPathEnd + " buffAnimPath: " + effectParameter.effect.buffAnimPath);

            foreach (UnitCtl unit in effectParameter.unitCtlList)
            {
                if(unit == null)
                {
                    continue;
                }
                BuildSkillDots skillDots = unit.GetComponent<BuildSkillDots>();
                if (skillDots != null)
                {
                    skillDots.buildingBurnTag(effectParameter);
                }
            }
            
            Debug.Log(string.Format("<color=yellow> burnTag all effid={0} time={1} count={2}</color>",
                                                  effectParameter.effect.id, effectParameter.effect.time, effectParameter.unitCtlList.Count));
            return 0;
        }

       
        #endregion

        #region 建筑升级
        public int effectBuildLevelUpStart(SkillParameter skillParameter, EffectParameter effectInfo)
        {
            //播放技能特效
            if (effectInfo.effect.animPathStart != "temp")
            {
                GameObject effectPrefabSelf = WarRes.GetPrefab(effectInfo.effect.animPathStart.ToLower());
                GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefabSelf);

                int lengion = War.skillWarManager.getLegionByHeroUid(skillParameter.curHeroUid);
                Vector3 fromPos = War.scene.GetLegionPosition(lengion);
                effectAnim.transform.position = fromPos;
                effectInfo.waitTime = 0.2f;
            }


			War.skillWarManager.setBuildHeroInfo(skillParameter, effectInfo);
            War.skillWarManager.StartCoroutine(effectBuildLevelUprEnd(skillParameter, effectInfo));
            return 0;
        }

        IEnumerator effectBuildLevelUprEnd(SkillParameter skillParameter, EffectParameter effectParameter)
        {
            yield return new WaitForSeconds(effectParameter.waitTime);

            foreach (UnitCtl unit in effectParameter.unitCtlList)
            {
                Debug.Log("=======" + effectParameter.effect.buffAnimPath);
                int lengion = War.skillWarManager.getLegionByHeroUid(skillParameter.curHeroUid);
                if (lengion != unit.unitData.legionId)
                {
                    continue;
                }

                if (effectParameter.effect.buffAnimPath != "temp")
                {
                    GameObject effectPrefab = WarRes.GetPrefab(effectParameter.effect.buffAnimPath);
                    GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
                    effectAnim.transform.position = unit.transform.position;
                }
                if(effectParameter.value > 0)
                {
                    unit.BuildSkillUplevel();
                    unit.unitData.BuildSkillCostHP(effectParameter.effect.costHP);
                    unit.unitData.BuildSkillCostHPPer(effectParameter.effect.costHPPer);
                }

                Debug.Log(string.Format("<color=yellow> effectBuildLevelUpStart to {0}  </color>",
                                      unit.unitData.id));
            }
        }
        #endregion

        #region 建筑替换
        public int effectBuildReplaceStart(SkillParameter skillParameter, EffectParameter effectInfo)
        {
            //播放技能特效
            if (effectInfo.effect.animPathStart != "temp")
            {
                GameObject effectPrefabSelf = WarRes.GetPrefab(effectInfo.effect.animPathStart.ToLower());
                GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefabSelf);

                int lengion = War.skillWarManager.getLegionByHeroUid(skillParameter.curHeroUid);
                Vector3 fromPos = War.scene.GetLegionPosition(lengion);
                effectAnim.transform.position = fromPos;
                effectInfo.waitTime = 0.5f;
            }
			War.skillWarManager.setBuildHeroInfo(skillParameter, effectInfo);
            War.skillWarManager.StartCoroutine(effectBuildReplaceEnd(skillParameter, effectInfo));
            return 0;
        }

        IEnumerator effectBuildReplaceEnd(SkillParameter skillParameter, EffectParameter effectParameter)
        {
            yield return new WaitForSeconds(effectParameter.waitTime);

            foreach (UnitCtl unit in effectParameter.unitCtlList)
            {
                Debug.Log("=======" + effectParameter.effect.buffAnimPath);
                int lengion = War.skillWarManager.getLegionByHeroUid(skillParameter.curHeroUid);
                if (lengion != unit.unitData.legionId)
                {
                    continue;
                }
                if (effectParameter.effect.buffAnimPath != "temp")
                {
                    GameObject effectPrefab = WarRes.GetPrefab(effectParameter.effect.buffAnimPath);
                    GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
                    effectAnim.transform.position = unit.transform.position;
                }
               
                if(unit.unitData.buildConfig.id == effectParameter.value)
				{
//					unit.unitData.BuildSkillUplevel();
				}
				else
				{
                    unit.BuildChangeBuildConfig((int)effectParameter.value);
				}

				unit.unitData.BuildSkillCostHP(effectParameter.effect.costHP);
				unit.unitData.BuildSkillCostHPPer(effectParameter.effect.costHPPer);
                Debug.Log(string.Format("<color=yellow> effectBuildReplaceStart to {0}  </color>",
                                      unit.unitData.id));
            }
        }


        #endregion

        #region 建筑等级上限提升
        public int effectBuildLevelMaxStart(SkillParameter skillParameter, EffectParameter effectInfo)
        {
            //播放技能特效
            if (effectInfo.effect.animPathStart != "temp")
            {
                GameObject effectPrefabSelf = WarRes.GetPrefab(effectInfo.effect.animPathStart.ToLower());
                GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefabSelf);

                int lengion = War.skillWarManager.getLegionByHeroUid(skillParameter.curHeroUid);
                Vector3 fromPos = War.scene.GetLegionPosition(lengion);
                effectAnim.transform.position = fromPos;
                effectInfo.waitTime = 0.5f;
            }
			War.skillWarManager.setBuildHeroInfo(skillParameter, effectInfo);
            foreach (UnitCtl unit in effectInfo.unitCtlList)
            {
                Debug.Log("=======" + effectInfo.effect.buffAnimPath);
                int lengion = War.skillWarManager.getLegionByHeroUid(skillParameter.curHeroUid);
                if (lengion != unit.unitData.legionId)
                {
                    continue;
                }
                if (effectInfo.effect.buffAnimPath != "temp")
                {
                    GameObject effectPrefab = WarRes.GetPrefab(effectInfo.effect.buffAnimPath);
                    GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
                    effectAnim.transform.position = unit.transform.position;
                }
                unit.unitData.build_addMaxLevel = (int)effectInfo.value;

				unit.unitData.BuildSkillCostHP(effectInfo.effect.costHP);
				unit.unitData.BuildSkillCostHPPer(effectInfo.effect.costHPPer);

                Debug.Log(string.Format("<color=yellow> effectBuildLevelMaxStart to {0}  </color>",
                                      unit.unitData.id));
            }
            return 0;
        }

        #endregion

        #region 驱散
        public int effectDispel(SkillParameter skillParameter, EffectParameter effectParameter)
        {
            UnitCtl curUnit = War.scene.GetUnitForUID(effectParameter.curBuildUid);
            if (curUnit == null)
            {
                return -1;
            }

            if (effectParameter.effect.animPathStart != "temp")
            {
                GameObject effectPrefab = WarRes.GetPrefab(effectParameter.effect.animPathStart.ToLower());
                GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
                effectAnim.transform.position = curUnit.transform.position;

            }
            if (effectParameter.unitCtlList.Count <= 1)
            {
                Debug.Log("==============unitctllist count < 1");
                return -1;
            }
            
            War.skillWarManager.StartCoroutine(effectDispelEnd(skillParameter, effectParameter));
            return 0;
        }

        IEnumerator effectDispelEnd(SkillParameter skillParameter, EffectParameter effectParameter)
        {
            yield return new WaitForSeconds(0.5f);
            UnitCtl curUnit = War.scene.GetUnitForUID(effectParameter.curBuildUid);
            float sendCountTatal = curUnit.unitData.hp * effectParameter.value / 100;
            int countBuild = effectParameter.unitCtlList.Count;
            if (countBuild > 0)
            {
                float sendCount = sendCountTatal / countBuild;
                foreach(UnitCtl unit in effectParameter.unitCtlList)
                {
                    Debug.Log("sendto " + unit.unitData.id + " count: " + sendCount);
                    curUnit.GetComponent<BSendArming>().Send(unit, (int)sendCount, 10.0f);
                }
                
            }
            Debug.Log(string.Format("<color=yellow> effectDispelEnd to {0} {1}</color>",
                                                 curUnit.unitData.id, sendCountTatal));

        }

        #endregion

        #region 建筑定时伤害其它建筑
        public int effectBuildAutoHurt(SkillParameter skillParameter, EffectParameter effectParameter)
        {
            Debug.Log("effectBuildAutoHurt=========" + effectParameter.effect.animPathStart + "++++++: " + effectParameter.effect.animPathEnd);
 
            foreach (UnitCtl unit in effectParameter.unitCtlList)
            {
                if (unit == null)
                {
                    continue;
                }
                BuildSkillDots skillDots = unit.GetComponent<BuildSkillDots>();
                if (skillDots != null)
                {
                    skillDots.GetBuildHurtOther(effectParameter);
                }
            }

            Debug.Log(string.Format("<color=yellow> addAttribute all skill id={0} effid={1}</color>", skillParameter.skillId, effectParameter.effect.id));
            return 0;
        }
        #endregion
    }
}
