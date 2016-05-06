using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime;
using CC.Runtime.Actions;
using System;

namespace Games.Module.Wars
{
    public class SkillWarEffectAddSoilder 
    {
        /*
         增兵
         */
        public int effectAddSoilder(SkillParameter skillParameter, EffectParameter effectInfo)
        {
            Debug.Log("======" + effectInfo.effect.type + "====" + effectInfo.effect.operation);
            if (effectInfo.effect.operation == (int)eSkillWarEffectOperation.eEffectAuto)//自动目标
            {
                autoAddBuildAllStart(skillParameter, effectInfo);
            }
            else if (effectInfo.effect.operation == (int)eSkillWarEffectOperation.eEffectManualTarget)//手动目标
            {
                autoAddBuildAllStart(skillParameter, effectInfo);
            }

            return 0;
        }
        //=========================给所有城池家兵===========
        private int autoAddBuildAllStart(SkillParameter skillParameter, EffectParameter effectInfo)
        {
            //SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillParameter.skillId);
            Debug.Log("=========" + effectInfo.effect.animPathStart + "++++++" + effectInfo.effect.animPathEnd);
            //播放技能特效
           
            foreach (UnitCtl unit in effectInfo.unitCtlList)//获取城市
            {
                if (effectInfo.effect.animPathStart != "temp")
                {
                    GameObject effectPrefab = WarRes.GetPrefab(effectInfo.effect.animPathStart);
                    GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
                    effectAnim.transform.position = unit.transform.position;

                    effectInfo.waitTime = 0.0f;
                }
            }

            War.skillWarManager.StartCoroutine(autoAddBuildAllEnd(skillParameter, effectInfo));
            return 0;
        }
        IEnumerator autoAddBuildAllEnd(SkillParameter skillParameter, EffectParameter effectInfo)
        {
            yield return new WaitForSeconds(effectInfo.waitTime);

            SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillParameter.skillId);

            float addSoild = effectInfo.value;
            foreach (UnitCtl unit in effectInfo.unitCtlList)//获取城市
            {
				try
				{
	                int lengion = War.skillWarManager.getLegionByHeroUid(skillParameter.curHeroUid);
	                if (lengion != unit.unitData.legionId)
	                {
	                    continue;
	                }
	                //添加持续效果
	                if (effectInfo.effect.buffAnimPath != "temp")
	                {
	                    GameObject effectPrefab = WarRes.GetPrefab(effectInfo.effect.buffAnimPath.ToLower());
	                    GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
	                    effectAnim.transform.position = unit.transform.position;
	                    DelayDestory destoryTimer = effectAnim.GetComponent<DelayDestory>();
	                    if (destoryTimer != null)
	                    {
	                        destoryTimer.DelayTime = effectInfo.effect.time;
	                    }
	                }
	                //按百分比加兵
	                if(effectInfo.effect.type == (int)eSKillWarEffectType.eEffectAddSoldierPer)
	                {
	                    addSoild = unit.unitData.maxHp * effectInfo.value / 100;
	                    Debug.LogFormat("add soldier rate: {0} {1}", effectInfo.value, addSoild);
	                }
	                else if (effectInfo.effect.type == (int)eSKillWarEffectType.eEffectAddSoldierHitMax)
	                {
	                    if(unit.unitData.beattack != true)
	                    {
	                        addSoild = 0;
	                    }
	                }
	                Debug.Log("========add soldier: " + addSoild);
	                unit.Damage(addSoild, effectInfo.effect.addSoldierMax, effectInfo.caster);
				}
				catch(Exception e)
				{
					if (Application.isEditor)
						Debug.Log (e);
				}
            }

            //处理2技能
            if(skillParameter.curDealSkillIdx == 1)
            {
                War.skillWarManager.dealSkill2Effect(skillParameter);
            }
            
            if (effectInfo.effect.time > 0)
            {
                War.skillWarManager.StartCoroutine(autoAddBuildAllTimer(skillParameter, effectInfo));
            }

            Debug.Log(string.Format("<color=yellow> autoAddBuildAll all=skill id:{0}, lvl:{1} v:{2}</color>",
                            skillParameter.skillId, skillParameter.skillLvl, addSoild));
        }

        IEnumerator autoAddBuildAllTimer(SkillParameter skillParameter, EffectParameter effectInfo)
        {
             SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillParameter.skillId);

             float addSoild = effectInfo.value;
             int timerCount = effectInfo.effect.time;
             while (true)
			{
				yield return new WaitForSeconds(1.0f);
				try
				{
	                foreach (UnitCtl unit in effectInfo.unitCtlList)//获取城市
	                {
	                    unit.Damage(addSoild, effectInfo.effect.addSoldierMax, effectInfo.caster);
	                }
	                Debug.Log(string.Format("<color=yellow> autoHurtBuildAllTimer all= effectid:{0} v:{1} </color>",
	                                                     effectInfo.effect.id, addSoild));
	                timerCount--;
	                if(timerCount <= 0)
	                {
	                    break;
	                }
				}
				catch(Exception e)
				{
					if (Application.isEditor) {
						Debug.Log (e);
					}
					break;
				}
            }
            Debug.Log(string.Format("<color=white> autoHurtBuildAllTimer done=</color>"));
        }

    }
}