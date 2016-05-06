using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.Actions;
using Games.Module.Props;
using CC.Runtime.signals;
using System;

namespace Games.Module.Wars
{
    public class BuildSkillDots : MonoBehaviour
    {
        //[0, 6, -6]
        //[-1, 6, -6][1, 6, -6]
        //[-1, 8.5, -6][1, 8.5, -6][-1, 5.5, -6]
        //[-1, 8.5, -6][1, 8.5, -6][-1, 5.5, -6][1, 5.5, -6]
        Dictionary<int, Vector3> buffPosDic = new Dictionary<int, Vector3>();

        List<EffectParameter> effectParameterList = new List<EffectParameter>();
        // Use this for initialization
        void Start()
        {
            SignalFactory.GetInstance<WarBuildChangeLegion>().AddListener(changeLegion);
            Vector3 v11 = new Vector3(0f, 6f, -6f);
            Vector3 v21 = new Vector3(-1f, 6f, -6f);
            Vector3 v22 = new Vector3(1f, 6f, -6f);
            Vector3 v31 = new Vector3(-1f, 8.5f, -6f);
            Vector3 v32 = new Vector3(1f, 8.5f, -6f);
            Vector3 v33 = new Vector3(-1f, 5.5f, -6f);
            Vector3 v41 = new Vector3(-1f, 8.5f, -6f);
            Vector3 v42 = new Vector3(1f, 8.5f, -6f);
            Vector3 v43 = new Vector3(-1f, 5.5f, -6f);
            Vector3 v44 = new Vector3(1f, 5.5f, -6f);
            buffPosDic[11] = v11;
            buffPosDic[21] = v21;
            buffPosDic[22] = v22;
            buffPosDic[31] = v31;
            buffPosDic[32] = v32;
            buffPosDic[33] = v33;
            buffPosDic[41] = v41;
            buffPosDic[42] = v42;
            buffPosDic[43] = v43;
            buffPosDic[44] = v44;

        }

		void OnDestroy()
		{
			SignalFactory.GetInstance<WarBuildChangeLegion>().RemoveListener(changeLegion);
		}

        // Update is called once per frame
        void Update()
        {

        }
        public void changeLegion(UnitData buildUnitData, int preLegionId, int targetLegionId)
        {
            UnitCtl unit = gameObject.GetComponent<UnitCtl>();
            if (buildUnitData.id != unit.unitData.id)
            {
                return;
            }
            for (int i = 0; i < effectParameterList.Count; i++)
            {
                effectParameterList[i].waitTime = 0.0f;
                Debug.LogFormat("-----------changeLegion set time 0 {0}------------------", effectParameterList[i].effect.id);
            }
            CleanList();
        }
        //获取技能buf效果数量
        int getBuffCount()
        {
            int count = 0;
            for (int i = 0; i < effectParameterList.Count; i++)
            {
                if(effectParameterList[i].effectAnim == null)
                {
                    continue;
                }
                if((effectParameterList[i].effect.type == (int)eSKillWarEffectType.eEffectAddAttri) ||
                   (effectParameterList[i].effect.type == (int)eSKillWarEffectType.eEffectReduceAttri) ||
                   (effectParameterList[i].effect.type == (int)eSKillWarEffectType.eEffectMess))
                {
                    count++;
                }
            }
            return count;
        }
        //更新buff位置
        void updateBuffPos()
        {
            int totalCount = getBuffCount();
            for (int i = 0; i < effectParameterList.Count; i++)
            {
                if (effectParameterList[i].effectAnim == null)
                {
                    continue;
                }
                int idx = totalCount * 10 + i + 1;
                Vector3 pos;
                if(buffPosDic.TryGetValue(idx, out pos) == false)
                {
                    continue;
                }
                effectParameterList[i].effectAnim.transform.localPosition = pos;
            }

        }
        //清楚技能效果
        void CleanList()
        {
            for (int i = 0; i < effectParameterList.Count; )
            {
                Debug.LogFormat("===BuildSkillDots clean==={0} {1} waitTime:{2}", i, effectParameterList.Count, effectParameterList[i].waitTime);
                if (effectParameterList[i].waitTime < 1)
                {
                    if (effectParameterList[i].effectAnim != null)
                    {
                        DelayDestory destoryTimer = effectParameterList[i].effectAnim.GetComponent<DelayDestory>();
                        if (destoryTimer != null)
                        {
                            destoryTimer.DelayTime = 0;
                        }
                    }
                    effectParameterList.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            updateBuffPos();
        }

        #region 持续伤害
        public void GetSkillHurt(EffectParameter effectInfo)
        {
            effectParameterList.Add(effectInfo);
            StartCoroutine(autoHurtBuildAllTimer(effectInfo));
        }

        //定时伤害
        IEnumerator autoHurtBuildAllTimer(EffectParameter effectInfo)
        {
            UnitCtl unit = gameObject.GetComponent<UnitCtl>();
            effectInfo.waitTime = effectInfo.effect.time;
            DelayDestory destoryTimer = effectInfo.effectAnim.GetComponent<DelayDestory>();
            if (destoryTimer != null)
            {
                destoryTimer.DelayTime = effectInfo.waitTime;
            }
            int timerCount = 0;
            //SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillParameter.skillId);
            while (true)
            {
                yield return new WaitForSeconds(1.0f);

				try
				{
	                DamageVO damageVo = War.skillWarManager.GetDamageParameter(effectInfo.value, false, DamageType.ATTACK, unit, effectInfo.caster);
	                unit.Damage(damageVo);

	                Debug.Log(string.Format("<color=yellow> autoHurtBuildAllTimer all= effectid:{0}  </color>",
	                                                     effectInfo.effect.id));
	                timerCount++;
	                if (timerCount >= effectInfo.waitTime)
	                {
	                    break;
	                }
				}
				catch(Exception e)
				{
					if (Application.isEditor)
						Debug.LogError (e);
					break;
				}
            }

            effectInfo.waitTime = 0;
            CleanList();
            Debug.Log(string.Format("<color=white> autoHurtBuildAllTimer done=</color>"));
        }
        #endregion

        #region 灼烧标记
        //灼烧标记
        public void buildingBurnTag(EffectParameter effectInfo)
        {
            effectParameterList.Add(effectInfo);
            UnitCtl unit = gameObject.GetComponent<UnitCtl>();

            Prop[] props = new Prop[] { Prop.CreateInstance(PropId.StateBurn, 1) };
            AttachPropData attachPropData = new AttachPropData(props);

            if (effectInfo.effect.buffAnimPath != "temp")
            {
                GameObject effectPrefab = WarRes.GetPrefab(effectInfo.effect.buffAnimPath);
                GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
                effectAnim.transform.position = unit.transform.position;
                DelayDestory destoryTimer = effectAnim.GetComponent<DelayDestory>();
                if (destoryTimer != null)
                {
                    destoryTimer.DelayTime = effectInfo.effect.time;
                }
                effectInfo.effectAnim = effectAnim;
                Debug.Log("=======destoryTimer.DelayTime: " + effectInfo.effect.time);
            }
            unit.unitData.AppProps(attachPropData, true);

            if (effectInfo.effect.time > 0)
            {
                effectInfo.waitTime = effectInfo.effect.time;
                StartCoroutine(burnTagTimer(attachPropData, effectInfo));
            }
        }

        IEnumerator burnTagTimer(AttachPropData attachPropData, EffectParameter effectInfo)
        {
            int timerCount = 0;
            while(true)
            {
                yield return new WaitForSeconds(1.0f);
                if (timerCount >= effectInfo.waitTime)
                {
                    UnitCtl unit = gameObject.GetComponent<UnitCtl>();
                    unit.unitData.RevokeProps(attachPropData);
                    break;
                }
                timerCount++;
            }
            effectInfo.waitTime = 0;
            CleanList();
            Debug.Log(string.Format("<color=yellow> burnTagTimer </color>"));
        }
        #endregion

        #region 无法出兵
        public void buildStopSendsoldier(EffectParameter effectParameter)
        {
            effectParameterList.Add(effectParameter);
            StartCoroutine(effectBuildCantSendSoldierEnd(effectParameter));
        }

        IEnumerator effectBuildCantSendSoldierEnd( EffectParameter effectParameter)
        {
            yield return new WaitForSeconds(effectParameter.waitTime);

            Prop[] props = new Prop[] { Prop.CreateInstance(PropId.StateFreezedSendArm, 1) };
            AttachPropData attachPropData = new AttachPropData(props);

            Debug.Log("=======" + effectParameter.effect.buffAnimPath);
            effectParameter.waitTime = effectParameter.effect.time;
            UnitCtl unit = gameObject.GetComponent<UnitCtl>();
            if (effectParameter.effect.buffAnimPath != "temp")
            {
                GameObject effectPrefab = WarRes.GetPrefab(effectParameter.effect.buffAnimPath);
                GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
                //effectAnim.transform.position = unit.transform.position;
                effectAnim.transform.SetParent(unit.transform, false);
                DelayDestory destoryTimer = effectAnim.GetComponent<DelayDestory>();
                if (destoryTimer != null)
                {
                    destoryTimer.DelayTime = effectParameter.value;
                }
                effectParameter.effectAnim = effectAnim;
                updateBuffPos();
            }
            //todo 设置不能出兵
            if(effectParameter.effect.type == (int)eSKillWarEffectType.eEffectReduceSpeedTo)//修改材质
            {
				unit.unitAgent.SetMaterial(WarMaterialsType.stateFreeze);
            }
            unit.unitData.AppProps(attachPropData, true);
            if (effectParameter.effect.time > 0)
            {
                StartCoroutine(effectBuildCantSendTimer(effectParameter, attachPropData, unit));
            }

            Debug.Log(string.Format("<color=yellow> effectBuildCantSend to {0}  </color>",unit.unitData.id));
            
        }

        IEnumerator effectBuildCantSendTimer(EffectParameter effectParameter, AttachPropData attachPropData, UnitCtl unit)
        {
            yield return new WaitForSeconds(effectParameter.value);
            if (effectParameter.effect.type == (int)eSKillWarEffectType.eEffectReduceSpeedTo)//修改材质
            {
				unit.unitAgent.BackMaterial(WarMaterialsType.stateFreeze);
            }
            unit.unitData.RevokeProps(attachPropData, true);

            effectParameter.waitTime = 0;
            CleanList();
            Debug.Log(string.Format("<color=yellow> effectBuildCantSendTimer </color>"));
        }
        #endregion

        #region 改变属性
        public void buildChangeAttri(EffectParameter effectParameter)
        {
            effectParameterList.Add(effectParameter);
            float value = effectParameter.value;
            if (effectParameter.effect.type == (int)eSKillWarEffectType.eEffectReduceAttri)
            {
                value = 0 - value;
            }
            UnitCtl unit = gameObject.GetComponent<UnitCtl>();
            effectParameter.waitTime = effectParameter.effect.time;
            Prop[] props = new Prop[] { Prop.CreateInstance(effectParameter.effect.changePropertyId, value) };
            AttachPropData attachPropData = new AttachPropData(props);
            //Debug.Log("=================" + effectParameter.unitCtlList.Count + "prop: " + effectParameter.effect.changePropertyId + "value: " + vaue);
            Debug.Log("===============buffAnimPath: " + effectParameter.effect.buffAnimPath);
            unit.unitData.soliderPropContainer.Add(attachPropData);
            if (effectParameter.effect.buffAnimPath != "temp")
            {
                GameObject effectPrefabSelf = WarRes.GetPrefab(effectParameter.effect.buffAnimPath);
                GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefabSelf);
                //effectAnim.transform.position = unit.transform.position;
                effectAnim.transform.SetParent(unit.transform, false);
                effectParameter.effectAnim = effectAnim;
                DelayDestory destoryTimer = effectAnim.GetComponent<DelayDestory>();
                if (destoryTimer != null)
                {
                    destoryTimer.DelayTime = effectParameter.effect.time;
                }
                updateBuffPos();
            }

            if (effectParameter.effect.time > 0)
            {
                StartCoroutine(changeAttributeTimer(effectParameter, attachPropData));
            }
        }

        IEnumerator changeAttributeTimer(EffectParameter effectParameter, AttachPropData attachPropData)
        {
            yield return new WaitForSeconds(effectParameter.effect.time);
            UnitCtl unit = gameObject.GetComponent<UnitCtl>();
            unit.unitData.soliderPropContainer.Remove(attachPropData);

            effectParameter.waitTime = 0;
            CleanList();

            Debug.Log(string.Format("<color=yellow> addAttributeTimer done attachPropData :{0}</color>", effectParameter.effect.changePropertyId));

        }

        #endregion

        #region 投石
        public void GetBuildHurtOther(EffectParameter effectInfo)
        {
            effectParameterList.Add(effectInfo);

            StartCoroutine(buildHurtOtherTimer(effectInfo));
        }

        IEnumerator buildHurtOtherTimer(EffectParameter effectInfo)
        {
            UnitCtl unit = gameObject.GetComponent<UnitCtl>();
            effectInfo.waitTime = 9999;
            
            int timerCount = 0;
            //SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillParameter.skillId);
            while (true)
            {
				try
				{
	                if (effectInfo.effect.buffAnimPath != "temp")
	                {
	                    GameObject effectPrefab = WarRes.GetPrefab(effectInfo.effect.buffAnimPath);
	                    GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
	                    effectAnim.transform.position = unit.transform.position;
	                }

				}
				catch(Exception e)
				{
					if (Application.isEditor)
						Debug.LogError (e);
					break;
				}

	           	yield return new WaitForSeconds(effectInfo.effect.time);

				try
				{

	                //DamageVO damageVo = War.skillWarManager.GetDamageParameter(effectInfo.value, false, DamageType.ATTACK, unit, effectInfo.caster);
	                // unit.Damage(damageVo);
	                UnitCtl unitEnemy =  War.skillWarManager.GetEnemyBuildNearest(unit, effectInfo);
	                if(unitEnemy != null)
	                {
	                    War.skillWarManager.sendSkillAnim(unit.transform.position, unitEnemy,effectInfo.effect.animPathStart, 5.0f, 1.0f);
	                    StartCoroutine(buildHurt(unitEnemy, effectInfo));
	                }
	                Debug.Log(string.Format("<color=yellow> buildHurtOtherTimer all= effectid:{0}  </color>",
	                                                     effectInfo.effect.id));
	                timerCount++;
	                if (timerCount >= effectInfo.waitTime)
	                {
	                    break;
	                }
				}
				catch(Exception e)
				{
					if (Application.isEditor)
						Debug.LogError (e);
					break;
				}
            }

            effectInfo.waitTime = 0;
            CleanList();
            Debug.Log(string.Format("<color=white> buildHurtOtherTimer done=</color>"));
        }

        IEnumerator buildHurt(UnitCtl unit, EffectParameter effectInfo)
        {
            yield return new WaitForSeconds(0.8f);
            if (effectInfo.effect.animPathEnd != "temp")
            {
                GameObject effectPrefab = WarRes.GetPrefab(effectInfo.effect.animPathEnd);
                GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
                effectAnim.transform.position = unit.transform.position;
            }
            DamageVO damageVo = War.skillWarManager.GetDamageParameter(effectInfo.value, false, DamageType.ATTACK, unit, effectInfo.caster);
            unit.Damage(damageVo);
        }
        #endregion
    }
}
