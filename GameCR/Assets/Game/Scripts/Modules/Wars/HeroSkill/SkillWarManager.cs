using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime;
using CC.Runtime.Utils;
using CC.Runtime.Actions;
using CC.Runtime.PB;

namespace Games.Module.Wars
{
    public class EffectParameter
    {
        public CSkillEffectDataItem effect;
        public List<UnitCtl> unitCtlList = new List<UnitCtl>();//受技能影响的单位id
        public float value;//技能值
        public UnitCtl caster; 
        public Vector3 receivePos = Vector3.zero;//手动技能坐标
        public int curBuildUid;//释放技能建筑的uid，0表示没有
        //=========用于持续伤害的=============
        public float waitTime = 0.0f; //等待时机
        public GameObject effectAnim = null;//持续时间的技能
    }

    public class SkillParameter
    {
        public SkillParameter()
        {
            init();
        }
        public int skillId;//技能1
        public int skillLvl;//技能等级
        //public Dictionary<int, EffectParameter> effectInfoDic = new Dictionary<int, EffectParameter>();
        public List<EffectParameter> effectInfoList = new List<EffectParameter>();

        public int curHeroUid;        //释放技能uid
        public int curDealSkillIdx;   //当前处理的是1技能还是2技能
		public int skillUid;
        void init()
        {
            skillId = 0;
            skillLvl = 0;

            curHeroUid = 0;
            curDealSkillIdx = 1;
        }
    }

    public class SkillWarManager : MonoBehaviour
    {
        //public SkillOperateData skillOperateData;
        private SkillWarEffectHurt skillWarEffectHurt = new SkillWarEffectHurt();//伤害效果
        private SkillWarEffectAddSoilder skillWarEffectAddSoilder = new SkillWarEffectAddSoilder();//征兵效果
        public SkillWarEffectSpecial skillWarEffectSpecial = new SkillWarEffectSpecial();//其他效果

        // Use this for initialization
        void Start()
        {
            //InvokeRepeating("handleTimerSecond", 2, 1);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnDestroy()
        {
            Debug.Log(string.Format("<color=red> SkillWarManager destory </color>"));
        }
        #region 效果功能
        
        //特效移动
        public void sendSkillAnim(Vector3 fromPos, UnitCtl toUnit, string animPath, float heigt, float speedTime)
        {
            if(animPath == "temp")
            {
                return;
            }
            Vector3 targetDir = toUnit.transform.position - fromPos;
            targetDir.y = 0.0f;
            Vector3 direct = new Vector3(1, 0, 0);
            //float angle = Vector3.Angle(direct, targetDir);
            float angle = 0;
            if (targetDir.x > 0)
            {
                angle = Vector3.Angle(direct, targetDir);
            }
            else
            {
                angle = 360 - Vector3.Angle(direct, targetDir);
            }

            Debug.LogFormat("====sendSkillAnim : {0} angle:{1} =={2}", animPath, angle, animPath);
            GameObject effectPrefab = WarRes.GetPrefab(animPath);
            GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
            effectAnim.transform.rotation = Quaternion.Euler(0, angle, 0);
            effectAnim.transform.position = fromPos;
            DelayDestory destoryTimer = effectAnim.GetComponent<DelayDestory>();
            if (destoryTimer != null)
            {
                destoryTimer.DelayTime = speedTime ;
            }
            Vector3[] pathAll = new Vector3[3];
            pathAll[0] = fromPos;
            pathAll[1] = new Vector3((toUnit.transform.position.x - fromPos.x) / 2 + fromPos.x, heigt,
                                                        (toUnit.transform.position.z - fromPos.z) / 2 + fromPos.z);
            pathAll[2] = toUnit.transform.position;
            Hashtable args = new Hashtable();
            args.Add("path", pathAll);
            args.Add("easeType", iTween.EaseType.linear);
            args.Add("time", speedTime);
            iTween.MoveTo(effectAnim, args);
        }

        //伤害设置
        public DamageVO GetDamageParameter(float val, bool isOverMax, DamageType type, UnitCtl target, UnitCtl caster)
        {
            DamageVO damageVO = new DamageVO();
            damageVO.caster = caster;
            damageVO.target = target;
            damageVO.damageType = type;
            damageVO.value = val < 0 ? -val : val;
            damageVO.enableOverMax = isOverMax;
            return damageVO;
        }
        //士兵死亡特效
        public void soldierDieSHow(UnitCtl toUnit)
        {
            GameObject effectPrefab = WarRes.GetPrefab(WarRes.effect_soldiers_die);
            GameObject effectAnim = GameObject.Instantiate<GameObject>(effectPrefab);
            effectAnim.transform.position = toUnit.transform.position;
            DelayDestory destoryTimer = effectAnim.GetComponent<DelayDestory>();
            //if (destoryTimer != null)
            //{
            //    destoryTimer.DelayTime = 3.0f;
            //}
        }
        
        public int getLegionByHeroUid(int heroUid)
        {
            HeroData heroData = War.scene.GetUnitForUID(heroUid).heroData;
            return heroData.legionData.legionId;
        }

		public void setBuildHeroInfo(SkillParameter skillParameter, EffectParameter effectParameter)
		{
			int lengion = War.skillWarManager.getLegionByHeroUid(skillParameter.curHeroUid);
			//skillParameter.skillUid;
			int buildId = 0;
			foreach (UnitCtl unit in effectParameter.unitCtlList)
			{
				buildId = unit.unitData.id;
				break;
			}
			Debug.Log ("------buildId:" + buildId + "count: " + effectParameter.unitCtlList.Count);
			War.signal.HeroSettledBuild(lengion, skillParameter.skillUid, buildId);
		}

        #endregion

        //处理技能
        public int DealSkill(SkillOperateData operateData)
        {
            //Debug.Log("++++++++++++++++++++");
            //skillOperateData = operateData;
            if (operateData.caster == null)
            {
                Debug.Log(string.Format("<color=red>DealSkill err cant find skillOperateData caster</color>"));
                return -1;
            }
            DealSkillDispachEffect(operateData);
            return 0;
        }
        private void DealSkillDispachEffect(SkillOperateData operateData)
        {
            int skillId = operateData.skillId;
            SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillId);
            if (skillWarConf == null)
            {
                Debug.Log(string.Format("<color=red>DealSkill err cant find skillid={0}</color>", skillId));
                return ;
            }

            //处理技能1
            SkillParameter skillParameter = new SkillParameter();
            skillParameter.skillId = skillId;
            skillParameter.curHeroUid = operateData.heroUid;
			skillParameter.skillUid = operateData.uid;
            Debug.LogFormat("<color=green> ===skill: {0} ---</color>", skillId);
            foreach ( CSkillEffectDataItem effect in skillWarConf.effectDataList)
            {
                dealEffect(effect, skillParameter, operateData);
            }
            
			if (War.isTest || !War.requireSynch)
            {
                StartCoroutine(playSkillEffect(skillParameter));
            }
            else
            {
                sendSkillTo(skillParameter);
            }
            
        }

        //1技能效果
        private void dealEffect(CSkillEffectDataItem effect, SkillParameter skillParameter, SkillOperateData operateData)
        {
            EffectParameter effectParameter = new EffectParameter();
            effectParameter.effect = effect;
            float addLvlValue = effect.growUp * operateData.skillLevel;
            if(addLvlValue < 0)
            {
                addLvlValue = 0;
            }
            effectParameter.value = effect.data + addLvlValue;
			effectParameter.caster = operateData.heroData.unit;
            effectParameter.curBuildUid = 0;

            List<UnitCtl> unitCtlList = GetTargetBuildsByCamp(effect.camp, effectParameter);
            List<UnitCtl> unitCtlListTarget = GetTargetBuildsByEffectTarget(effect.target, unitCtlList, effectParameter, operateData);
            List<UnitCtl> unitCtlListRange = GetUnitRang(effect, unitCtlListTarget);
            Debug.Log(string.Format("<color=green> get target count=target:{0} {1} {2} {3} skillid:{4}</color>", effect.camp,
                                    effect.target, unitCtlList.Count, unitCtlListRange.Count, skillParameter.skillId));

            if (effect.operation == (int)eSkillWarEffectOperation.eEffectManualTarget)//手动目标
            {
                foreach (UnitCtl unit in operateData.receiveList)
                {
                    effectParameter.unitCtlList.Add(unit);
                }
            }
            else if (effect.operation == (int)eSkillWarEffectOperation.eEffectmanualRange)//手动范围
            {
                int unitType = 0;
                unitType = unitType.USolider(true);
                int relation = 0;
                relation = relation.REnemy(true);

                effectParameter.unitCtlList = War.scene.SearchUnit(operateData.receivePosition, effectParameter.effect.range, unitType, operateData.caster.unitData.legionId, relation);
                effectParameter.receivePos = operateData.receivePosition;

                if (effect.target == (int)eSkillWarTargetType.eEffectTargetSoliderAndBuild)
                {
                    if (effectParameter.value > effectParameter.unitCtlList.Count)
                    {
                        unitType = 0;
                        unitType = unitType.UBuild(true);
                        relation = 0;
                        relation = relation.REnemy(true);
                        List<UnitCtl> unitBuildList = War.scene.SearchUnit(operateData.receivePosition, effectParameter.effect.range, unitType, operateData.caster.unitData.legionId, relation);
                        foreach(UnitCtl unitBuild in unitBuildList)
                        {
                            effectParameter.unitCtlList.Add(unitBuild);
                        }
                    }
                    else
                    {
                        skillWarEffectSpecial.getRandomCount(effectParameter.unitCtlList, (int)effectParameter.value);
                    }

                }
                else if(effect.target == (int)eSkillWarTargetType.eEffectTargetSoliderAndBuildRangeAll)
                {
                    unitType = 0;
                    unitType = unitType.UBuild(true);
                    relation = 0;
                    relation = relation.REnemy(true);
                    List<UnitCtl> unitBuildList = War.scene.SearchUnit(operateData.receivePosition, effectParameter.effect.range, unitType, operateData.caster.unitData.legionId, relation);
                    foreach (UnitCtl unitBuild in unitBuildList)
                    {
                        effectParameter.unitCtlList.Add(unitBuild);
                    }
                }
                
                Debug.LogFormat("========effectParameter.unitCtlList:{0}==========", effectParameter.unitCtlList.Count);

            }
            else
            {
                effectParameter.unitCtlList = unitCtlListRange;
     //           foreach (UnitCtl unit in unitCtlListRange)
     //           {
					//Debug.Log(unit );
     //           }
            }
            
            skillParameter.effectInfoList.Add(effectParameter);

            if(effect.type == (int)eSKillWarEffectType.eEffectGo)//千里奔袭，获取己方最大人口城池
            {
                UnitCtl unit = GetSelfBuildMaxSolider(effectParameter);
                if(unit != null)
                {
                    effectParameter.curBuildUid = unit.unitData.uid;
                }
            }
            else if (effect.type == (int)eSKillWarEffectType.eEffectDispel)//驱散
            {
                int legionId = 0;
                foreach (UnitCtl unit in effectParameter.unitCtlList)
                {
                    effectParameter.curBuildUid = unit.unitData.uid;
                    effectParameter.unitCtlList.Clear();
                    legionId = unit.unitData.legionId;
                    break;
                }
                //获取和当前城池所在势力的城池
                List<UnitCtl> list = War.scene.GetBuilds(legionId);
                foreach (UnitCtl unitAll in list)
                {
                    if (unitAll.unitData.uid == effectParameter.curBuildUid)
                    {
                        continue;
                    }
                    effectParameter.unitCtlList.Add(unitAll);
                }
            }
            //if (skillParameter.skillId == 24)//连营
            //{
            //    skillWarEffectSpecial.getUnitCtlBurn(effectParameter, unitCtlSkill1Dic);
            //}
            Debug.LogFormat("<color=white>===skill 1 add effect:{0} count:{1}====</color>", effect.id, effectParameter.unitCtlList.Count);
        }

		public static C_SyncSkill_0x822 To_C_SyncSkill_0x822(SkillParameter skillParameter)
		{
			C_SyncSkill_0x822 msg = new C_SyncSkill_0x822();
			msg.skill_id = skillParameter.skillId;
			msg.src_id = skillParameter.curHeroUid;
			msg.uid = skillParameter.skillUid;

			foreach ( EffectParameter effectParameter in skillParameter.effectInfoList)
			{
				SkillEffectItem skillEffectItem = new SkillEffectItem();
				skillEffectItem.effect_id = effectParameter.effect.id;
				skillEffectItem.skill_value = effectParameter.value;
				foreach(UnitCtl unit in effectParameter.unitCtlList)
				{
					skillEffectItem.dis_ids.Add(unit.unitData.id);
				}

				skillEffectItem.x = effectParameter.receivePos.x;
				skillEffectItem.y = effectParameter.receivePos.y;
				skillEffectItem.z = effectParameter.receivePos.z;
				skillEffectItem.cur_build_uid = effectParameter.curBuildUid;
				//Debug.LogFormat("----send skill to {0} unit count:{1}", skillEffectItem.effect_id, skillEffectItem.dis_ids.Count);
				msg.skill_effect_item.Add(skillEffectItem);
			}

			return msg;
		}
       
        private void sendSkillTo(SkillParameter skillParameter)
        {
			War.service.C_SyncSkill_0x822(To_C_SyncSkill_0x822(skillParameter));
        }

        //收到技能处理
        public void DealSkillForPvp(S_SyncSkill_0x822 msg)
        {
            SkillParameter skillParameter = new SkillParameter();
            skillParameter.skillId = msg.skill_id;
			skillParameter.skillUid = msg.uid;
            SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillParameter.skillId);
            if (skillWarConf == null)
            {
                Debug.Log(string.Format("<color=red>DealSkill err cant find skillid={0}</color>", skillParameter.skillId));
                return;
            }
            //释放技能英雄
            skillParameter.curHeroUid = msg.src_id;
           // HeroData heroData = War.scene.GetBuild(msg.src_id).heroData;
            HeroData heroData = War.scene.GetUnitForUID(skillParameter.curHeroUid).heroData;
            UnitCtl caster = null;
            if (heroData != null)
            {
                caster = heroData.unit;
            }
            //技能1效果
            foreach (SkillEffectItem effectItem in msg.skill_effect_item)
            {
                // Debug.LogFormat("-----DealSkillForPvp effect1 effect_id:{0}", effectItem.effect_id);
                CSkillEffectDataItem effectData = skillWarConf.getEffectDataById(effectItem.effect_id);
                if (effectData == null)
                {
                    continue;
                }
                EffectParameter effectParameter = new EffectParameter();
                effectParameter.effect = effectData;
                effectParameter.value = effectItem.skill_value;

                foreach (int unitId in effectItem.dis_ids)
                {
                    //UnitCtl unitCtl = War.scene.GetBuild(unitId);
                    UnitCtl unitCtl = War.scene.GetUnitForUID(unitId);
                    if (unitCtl != null)
                    {
                        effectParameter.unitCtlList.Add(unitCtl);
                    }
                }
                effectParameter.receivePos.x = effectItem.x;
                effectParameter.receivePos.y = effectItem.y;
                effectParameter.receivePos.z = effectItem.z;
                effectParameter.curBuildUid = effectItem.cur_build_uid;
                effectParameter.caster = caster;
                Debug.LogFormat("-----DealSkillForPvp:{0} id:{1} type:{2} pos:{3} {4} {5}",
                                         effectParameter.unitCtlList.Count, effectData.id, effectData.type, effectItem.x, effectItem.y, effectItem.z);
                skillParameter.effectInfoList.Add(effectParameter);
            }

            StartCoroutine(playSkillEffect(skillParameter));
            // playSkillEffect(skillParameter);
        }
        //////////////////////////////////////////////////////////////////////
        //处理技能效果
        IEnumerator playSkillEffect(SkillParameter skillParameter)
		{
			War.signal.DoSkill(To_C_SyncSkill_0x822(skillParameter));
            yield return new WaitForSeconds(0.0f);
            //音效
            SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillParameter.skillId);
            if (skillWarConf.musicEffectPath != "temp")
            {
                Coo.soundManager.PlaySound(skillWarConf.musicEffectPath);
            }
            if (skillWarConf.heroVoicePath != "temp")
            {
                Coo.soundManager.PlaySound(skillWarConf.heroVoicePath);
            }

            skillParameter.curDealSkillIdx = 1;
            foreach(EffectParameter effectDic in skillParameter.effectInfoList)
            {
                Debug.Log(string.Format("<color=green> deal effect id:{0} {1}</color>", effectDic.effect.id,
                                       effectDic.effect.type));
                if(effectDic.effect.type == (int)eSKillWarEffectType.eEffectDelay)
                {
                    Debug.LogFormat("=======effect delay :{0}======", effectDic.effect.time);
                    yield return new WaitForSeconds(effectDic.effect.time);
                }
                
                if (effectDic.effect.type == (int)eSKillWarEffectType.eEffectHurt ||
                    effectDic.effect.type == (int)eSKillWarEffectType.eEffectHurtBuidingMax ||
                    effectDic.effect.type == (int)eSKillWarEffectType.eEffectHurtRate)//伤害
                {
                    skillWarEffectHurt.effectHurt(skillParameter, effectDic);
                }
                else if (effectDic.effect.type == (int)eSKillWarEffectType.eEffectAddSolder ||
                         effectDic.effect.type == (int)eSKillWarEffectType.eEffectAddSoldierPer ||
                         effectDic.effect.type == (int)eSKillWarEffectType.eEffectAddSoldierHitMax)//增兵
                {
                    skillWarEffectAddSoilder.effectAddSoilder(skillParameter, effectDic);
                }
                else if (effectDic.effect.type == (int)eSKillWarEffectType.eEffectGo)//快速前往
                {
                    skillWarEffectSpecial.GotoBuildSoon(skillParameter, effectDic);
                }
                else if (effectDic.effect.type == (int)eSKillWarEffectType.eEffectAddShield)//加盾
                {
                    skillWarEffectSpecial.addShieldStart(skillParameter, effectDic);
                }
                else if (effectDic.effect.type == (int)eSKillWarEffectType.eEffectAddAttri ||
                         effectDic.effect.type == (int)eSKillWarEffectType.eEffectReduceAttri)//改变属性
                {
                    skillWarEffectSpecial.changeAttribute(skillParameter, effectDic);
                }
                else if (effectDic.effect.type == (int)eSKillWarEffectType.eEffectReduceSpeedTo)//冰冻
                {
                    War.skillWarManager.skillWarEffectSpecial.stopSoldierStart(skillParameter, effectDic);
                }
                else if (effectDic.effect.type == (int)eSKillWarEffectType.eEffectMess)//混乱
                {
                    skillWarEffectSpecial.effectBuildCantSendSoldierStart(skillParameter, effectDic);
                }
                else if (effectDic.effect.type == (int)eSKillWarEffectType.eEffectLevelUp)//建筑等级增加
                {
                    skillWarEffectSpecial.effectBuildLevelUpStart(skillParameter, effectDic);
                }
                else if (effectDic.effect.type == (int)eSKillWarEffectType.eEffectReplace)//建筑替换
                {
                    skillWarEffectSpecial.effectBuildReplaceStart(skillParameter, effectDic);
                }
                else if (effectDic.effect.type == (int)eSKillWarEffectType.eEffectAttach)//建筑附加功能
                {

                }
                else if (effectDic.effect.type == (int)eSKillWarEffectType.eEffectBuildLevelMax)//建筑附加功能
                {
                    skillWarEffectSpecial.effectBuildLevelMaxStart(skillParameter, effectDic);
                }
                else if(effectDic.effect.type == (int)eSKillWarEffectType.eEffectHeroToBuild)//主公上阵
                {
                    skillWarEffectSpecial.effectHeroToBuild(skillParameter, effectDic);
                }
                else if(effectDic.effect.type == (int)eSKillWarEffectType.eEffectDispel)//驱散
                {
                    skillWarEffectSpecial.effectDispel(skillParameter, effectDic);
                }
                else if(effectDic.effect.type == (int)eSKillWarEffectType.eEffectBuildAutoHurt)//建筑定时伤害
                {
                    skillWarEffectSpecial.effectBuildAutoHurt(skillParameter, effectDic);
                }
                else
                {
                    Debug.Log(string.Format("<color=red> cat find effect id:{0} {1}</color>", effectDic.effect.id,
                                        effectDic.effect.type));
                }
            }
        }

        //处理2技能特效
        public void dealSkill2Effect(SkillParameter skillParameter)
        {
#if SKILL2ENABLE
            skillParameter.curDealSkillIdx = 2; 
            foreach (KeyValuePair<int, EffectParameter> effectDic in skillParameter.effectInfoDic2)
            {
                EffectParameter effectParameter = effectDic.Value;
                Debug.LogFormat("<color=green> ===dealSkill2Effect skillId2:{0}===</color>", effectParameter.effect.id);
                if (effectParameter.effect.type == (int)eSKillWarEffectType.eEffectMess)//混乱
                {
                    skillWarEffectSpecial.effectBuildCantSendSoldierStart(skillParameter, effectParameter);
                }
                else if (effectDic.Value.effect.type == (int)eSKillWarEffectType.eEffectAddAttri ||
                            effectDic.Value.effect.type == (int)eSKillWarEffectType.eEffectReduceAttri)//改变属性
                {
                    skillWarEffectSpecial.changeAttribute(skillParameter, effectParameter);
                }
                else if (effectDic.Value.effect.type == (int)eSKillWarEffectType.eEffectReduceSpeedTo)
                {
                    War.skillWarManager.skillWarEffectSpecial.stopSoldierStart(skillParameter, effectParameter);
                }
                else if (effectDic.Value.effect.type == (int)eSKillWarEffectType.eEffectGoBack)
                {
                    foreach (UnitCtl unit in effectDic.Value.unitCtlList)
                    {
                        if (unit == null)
                        {
                            continue;
                        }
                        unit.unitCtl.BackHome();
                    }
                }
                else if (effectParameter.effect.type == (int)eSKillWarEffectType.eEffectSilence)//沉默
                {
                    skillWarEffectSpecial.heroSilence(skillParameter, effectParameter);
                }
                else if (effectParameter.effect.type == (int)eSKillWarEffectType.eEffectBurn)//灼烧
                {
                    skillWarEffectSpecial.burnTag( effectParameter);
                }
                else if (effectParameter.effect.type == (int)eSKillWarEffectType.eEffectDouble)//连击
                {
                    //技能1连击
                    if (skillParameter.skillId == 35)//吕布无双
                    {
                        skillParameter.skillId2 = 0;
                        skillParameter.effectInfoDic2.Clear();
                        playSkillEffect(skillParameter);
                    }
                }
                else if (effectParameter.effect.type == (int)eSKillWarEffectType.eEffectHurt ||
                           effectParameter.effect.type == (int)eSKillWarEffectType.eEffectHurtBuidingMax)//伤害
                {
                    skillWarEffectHurt.effectHurt(skillParameter, effectParameter);
                }
                else if (effectDic.Value.effect.type == (int)eSKillWarEffectType.eEffectAddSolder ||
                           effectDic.Value.effect.type == (int)eSKillWarEffectType.eEffectAddSoldierPer ||
                           effectDic.Value.effect.type == (int)eSKillWarEffectType.eEffectAddSoldierHitMax)//增兵
                {
                    skillWarEffectAddSoilder.effectAddSoilder(skillParameter, effectDic.Value);
                }
                else
                {
                    Debug.LogFormat("===skill2 effect id:{0} type:{1} not deal===", effectParameter.effect.id, effectParameter.effect.type);
                }
            }
#endif
        }

        #region 技能释放条件
        //通过AI类型，来控制技能释放是否有效
        public bool checkSkillAIType(int skillId, int selfLegionId)
        {
            SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillId);
            if (skillWarConf == null)
            {
                Debug.Log(string.Format("<color=red>checkSkillAIType err cant find skillid={0}</color>", skillId));
                return false;
            }
            int aiType = skillWarConf.aiTypeArray[0];
            int aiValue = skillWarConf.aiTypeArray[1];
            Debug.Log(string.Format("<color=green> checkSkillAIType:{0} {1} type:{2} value:{3}</color>", skillId, selfLegionId, aiType, aiValue));

            bool isActive = false;
            if (aiType == (int)eSkillAiType.eSkillAiNone)//无
            {
                isActive = true;
            }
            else if (aiType == (int)eSkillAiType.eSkillAiEnemyBuildSoldier)//敌方存在城池人口≥X
            {
                int unitType = 0;
                unitType = unitType.UBuild(true);
                int relation = 0;
                relation = relation.REnemy(true);
                List<UnitCtl> listTmp = War.scene.SearchUnit(unitType, selfLegionId, relation);

                foreach (UnitCtl unit in listTmp)
                {
                    if(skillWarConf.isSettledBuild == true && unit.unitData.hasHero == true)
                    {
                        continue;
                    }
                    if (unit.unitData.isNeutral == true)
                    {
                        continue;
                    }
                    if (unit.unitData.hp > aiValue)
                    {
                        isActive = true;
                    }
                }

            }
            else if (aiType == (int)eSkillAiType.eSkillAiSelfSoldierAll)//存在没有被攻击的城池，没有正在升级的城池时
            {
                //己方人口
                int unitType = 0;
                unitType = unitType.UBuild(true);
                int relation = 0;
                relation = relation.ROwn(true);
                List<UnitCtl> listTmp = War.scene.SearchUnit(unitType, selfLegionId, relation);

                int buildCount = 0;
                foreach (UnitCtl unit in listTmp)
                {
                    Debug.Log("skillid: " + skillId + " ================: " + skillWarConf.isSettledBuild + " ++++++: " + unit.unitData.hasHero);
                    if (skillWarConf.isSettledBuild == true && unit.unitData.hasHero == true)
                    {
                        continue;
                    }
                    if (unit.unitData.isNeutral == true)
                    {
                        continue;
                    }

                    if (unit.unitData.behit == false && unit.unitData.levelData.Upleveing == false)
                    {
                        buildCount += 1;
                    }
                }
                float totalSoldier = War.scene.GetLegionHP(selfLegionId);
                float totalEnemySoldier = 0.0f;
                if (buildCount > 0)
                {
                    //敌方人口
                    //totalEnemySoldier = War.scene.GetEnemyLegionHPMax(selfLegionId);

                    //if (totalSoldier >= totalEnemySoldier)
                    //{
                    isActive = true;
                    //}
                }
                Debug.LogFormat("========soldier:{0} build:{1} enemy:{2}", totalSoldier, buildCount, totalEnemySoldier);
            }
            else if (aiType == (int)eSkillAiType.eSkillAiEnemyBuild)//敌方城池≥X
            {
                int unitType = 0;
                unitType = unitType.UBuild(true);
                int relation = 0;
                relation = relation.REnemy(true);
                List<UnitCtl> listTmp = War.scene.SearchUnit(unitType, selfLegionId, relation);
                int buildCount = 0;
                foreach (UnitCtl unit in listTmp)
                {
                    if (skillWarConf.isSettledBuild == true && unit.unitData.hasHero == true)
                    {
                        continue;
                    }
                    if (unit.unitData.isNeutral == true)
                    {
                        continue;
                    }
                    buildCount += 1;
                }
                if(buildCount > aiValue)
                {
                    isActive = true;
                }
            }
            else if (aiType == (int)eSkillAiType.eSkillAiEnemySoldier)//敌方出征部队≥X（占当期出征总人数的百分比）
            {
                //所有士兵
                int unitType = 0;
                unitType = unitType.UBuild(true);
                int relation = 0;
                relation = relation.REnemy(true);
                List<UnitCtl> listTmp = War.scene.SearchUnit(unitType, selfLegionId, relation);
                int totalSoldier = 0;
                foreach (UnitCtl unit in listTmp)
                {
                    if (unit.unitData.isNeutral == true)
                    {
                        continue;
                    }
                    totalSoldier += (int)unit.unitData.hp;
                }
                //出征士兵
                unitType = 0;
                unitType = unitType.USolider(true);
                relation = 0;
                relation = relation.REnemy(true);
                List<UnitCtl> listSoldiersTmp = War.scene.SearchUnit(unitType, selfLegionId, relation);
                int count = listSoldiersTmp.Count;
                float rate = (count * 100) / totalSoldier;
                if (rate > aiValue)
                {
                    isActive = true;
                }
            }
            else if (aiType == (int)eSkillAiType.eSkillAiSelfBuild)//己方城池数≥X
            {
                int unitType = 0;
                unitType = unitType.UBuild(true);
                int relation = 0;
                relation = relation.ROwn(true);
                List<UnitCtl> listSoldiersTmp = War.scene.SearchUnit(unitType, selfLegionId, relation);
                if (listSoldiersTmp.Count > aiValue)
                {
                    isActive = true;
                }
            }
            else if (aiType == (int)eSkillAiType.eSkillAiSelfBuildAttack)//己方城池被攻击时
            {
                int unitType = 0;
                unitType = unitType.UBuild(true);
                int relation = 0;
                relation = relation.ROwn(true);
                List<UnitCtl> listTmp = War.scene.SearchUnit(unitType, selfLegionId, relation);
                foreach (UnitCtl unit in listTmp)
                {
                    if (unit.unitData.behit == true)
                    {
                        isActive = true;
                    }
                }
            }
            else if (aiType == (int)eSkillAiType.eSkillAiSelfBuildSoldier)//己方总人口≥敌方，且存在没有被攻击的城池，没有正在升级的城池,并且有等级小于x级的城市
            {
                //己方人口
                int unitType = 0;
                unitType = unitType.UBuild(true);
                int relation = 0;
                relation = relation.ROwn(true);
                List<UnitCtl> listTmp = War.scene.SearchUnit(unitType, selfLegionId, relation);

                int buildCount = 0;
                foreach (UnitCtl unit in listTmp)
                {
                    if (skillWarConf.isSettledBuild == true && unit.unitData.hasHero == true)
                    {
                        continue;
                    }
                    if (unit.unitData.isNeutral == true)
                    {
                        continue;
                    }

                    if (unit.unitData.behit == false && 
                        unit.unitData.levelData.Upleveing == false )
                    {
                        buildCount += 1;
                    }
                }
                float totalSoldier = War.scene.GetLegionHP(selfLegionId);
                float totalEnemySoldier = 0.0f;
                if (buildCount > 0)
                {
                    //敌方人口
                    totalEnemySoldier = War.scene.GetEnemyLegionHPMax(selfLegionId);

                    if (totalSoldier >= totalEnemySoldier)
                    {
                        isActive = true;
                    }
                }
                Debug.LogFormat("========soldier:{0} build:{1} enemy:{2}", totalSoldier, buildCount, totalEnemySoldier);

            }
            else if(aiType == (int)eSkillAiType.eSkillAiSelfBuildLevel)//己方总人口≥敌方，且存在没有被攻击的城池，没有正在升级的城池,并且有等级小于x级的城市
            {
                //己方人口
                int unitType = 0;
                unitType = unitType.UBuild(true);
                int relation = 0;
                relation = relation.ROwn(true);
                List<UnitCtl> listTmp = War.scene.SearchUnit(unitType, selfLegionId, relation);

                int buildCount = 0;
                foreach (UnitCtl unit in listTmp)
                {
                    if (unit.unitData.isNeutral == true)
                    {
                        continue;
                    }

                    if (unit.unitData.behit == false &&
                        unit.unitData.levelData.Upleveing == false &&
                        unit.unitData.level < aiValue)
                    {
                        buildCount += 1;
                    }
                }
                float totalSoldier = War.scene.GetLegionHP(selfLegionId);
                float totalEnemySoldier = 0.0f;
                if (buildCount > 0)
                {
                    //敌方人口
                    totalEnemySoldier = War.scene.GetEnemyLegionHPMax(selfLegionId);

                    if (totalSoldier >= totalEnemySoldier)
                    {
                        isActive = true;
                    }
                }
                Debug.LogFormat("========soldier:{0} build:{1} enemy:{2}", totalSoldier, buildCount, totalEnemySoldier);
            }
            else if(aiType == (int)eSkillAiType.eSkillAiSelfSoldier)//己方出征部队≥X（占当期出征总人数的百分比）
            {
                //所有士兵
                int unitType = 0;
                unitType = unitType.UBuild(true);
                int relation = 0;
                relation = relation.ROwn(true);
                List<UnitCtl> listTmp = War.scene.SearchUnit(unitType, selfLegionId, relation);
                int totalSoldier = 0;
                foreach (UnitCtl unit in listTmp)
                {
                    if (unit.unitData.isNeutral == true)
                    {
                        continue;
                    }
                    totalSoldier += (int)unit.unitData.hp;
                }
                //出征士兵
                unitType = 0;
                unitType = unitType.ROwn(true);
                relation = 0;
                relation = relation.REnemy(true);
                List<UnitCtl> listSoldiersTmp = War.scene.SearchUnit(unitType, selfLegionId, relation);
                int count = listSoldiersTmp.Count;
                float rate = (count * 100) / totalSoldier;
                if (rate > aiValue)
                {
                    isActive = true;
                }
            }
            return isActive;
        }
        #endregion

        #region 获取作用单位
        //己方兵力最多的城池
        private UnitCtl GetSelfBuildMaxSolider(EffectParameter effectParameter)
        {
            int unitType = 0;
            unitType = unitType.UBuild(true);
            int relation = 0;
            relation = relation.ROwn(true);
            List<UnitCtl> unitList = War.scene.SearchUnit(unitType, effectParameter.caster.unitData.legionId, relation);

            UnitCtl unitMax = null;
            float hpTmp = 0.0f;
            foreach (UnitCtl unit in unitList)
            {
                if (unit.hp >= hpTmp)
                {
                    hpTmp = unit.hp;
                    unitMax = unit;
                }
            }

            return unitMax;
        }

        //获取离最近的敌方城池
        public UnitCtl GetEnemyBuildNearest(UnitCtl unitSelf, EffectParameter effectParameter)
        {
            int unitType = 0;
            unitType = unitType.UBuild(true);
            int relation = 0;
            relation = relation.REnemy(true);
            List<UnitCtl> listTmp = War.scene.SearchUnit(unitType, effectParameter.caster.unitData.legionId, relation);
            List<UnitCtl> listUnit = new List<UnitCtl>();
            float distance = 10000.0f;
            UnitCtl unitFind = null;
            foreach (UnitCtl unit in listTmp)
            {
                float currentDist = Vector3.Distance(unitSelf.transform.position, unit.transform.position);
                if(currentDist < distance)
                {
                    distance = currentDist;
                    unitFind = unit;
                }
            }
            return unitFind;
         }

        //获取阵营建筑
        private List<UnitCtl> GetTargetBuildsByCamp(int camp, EffectParameter effectParameter)
        {
            if (camp == (int)eSkillWarEffectCamp.eEffectCampSelf)//自己
            {
                int unitType = 0;
                unitType = unitType.UBuild(true);
                int relation = 0;
                relation = relation.ROwn(true);
                return War.scene.SearchUnit(unitType, effectParameter.caster.unitData.legionId, relation);
                //return unitCtlList;
                //return War.scene.GetBuilds(skillOperateData.caster.unitData.legionId);
            }
            else if (camp == (int)eSkillWarEffectCamp.eEffectCampEnemy)//敌方
            {
                int unitType = 0;
                unitType = unitType.UBuild(true);
                int relation = 0;
                relation = relation.REnemy(true);
                List<UnitCtl> listTmp = War.scene.SearchUnit(unitType, effectParameter.caster.unitData.legionId, relation);
                List<UnitCtl> listUnit = new List<UnitCtl>();
                foreach (UnitCtl unit in listTmp)
                {
                    if (unit.unitData.isNeutral == true)
                    {
                        continue;
                    }
                    listUnit.Add(unit);
                }
                return listUnit;

                //return War.scene.GetEnemyBuilds(skillOperateData.caster.unitData.legionId);
            }
            else if (camp == (int)eSkillWarEffectCamp.eEffectCampfriend)//友方
            {
                int unitType = 0;
                unitType = unitType.UBuild(true);
                int relation = 0;
                relation = relation.RFriendly(true);
                return War.scene.SearchUnit(unitType, effectParameter.caster.unitData.legionId, relation);
                //return unitCtlList;
                //return War.scene.GetEnemyBuilds(skillOperateData.caster.unitData.legionId);
            }
            else//所有城池
            {
                int unitType = 0;
                unitType = unitType.UBuild(true);
                int relation = 0;
                relation = relation.RAll(true);
                return War.scene.SearchUnit(unitType, effectParameter.caster.unitData.legionId, relation);
                //return War.scene.GetBuilds();
            }
            List<UnitCtl> list = new List<UnitCtl>(); 
            return list;
        }

        //获取目标
        private List<UnitCtl> GetTargetBuildsByEffectTarget(int target, List<UnitCtl> unitCtlListAll, 
                                                            EffectParameter effectParameter, SkillOperateData skillOperateData)
        {
            List<UnitCtl> list = new List<UnitCtl>();

             if (target == (int)eSkillWarTargetType.eEffectTargetBuild)//城池
            {
                foreach(UnitCtl unit in unitCtlListAll)
                {
                    list.Add(unit);
                }
            }
            else if (target == (int)eSkillWarTargetType.eEffectTargetEmptyBuild)//空城
            {
                foreach (UnitCtl unit in unitCtlListAll)
                {
                    if (unit.unitData.isNeutral == true)
                    {
                        list.Add(unit);
                    }
                }
            }
            else if (target == (int)eSkillWarTargetType.eEffectTargetHeroBuild)//将城
            {
                foreach (UnitCtl unit in unitCtlListAll)
                {

                    if (unit.unitData.hasHero == true && unit.unitData.heroData.state == HeroState.Foregstage)
                    {
                        list.Add(unit);
                    }
                }
            }
            else if (target == (int)eSkillWarTargetType.eEffectTargetBuildMinSolder)//当前兵力最少的城池
            {
                UnitCtl unitMin = null;
                float hpTmp = 10000.0f;
                foreach (UnitCtl unit in unitCtlListAll)
                {
                    if (unit.hp <= hpTmp)
                    {
                        hpTmp = unit.hp;
                        unitMin = unit;
                    }
                }
                if (unitMin != null)
                {
                    list.Add(unitMin);
                }
            }
            else if (target == (int)eSkillWarTargetType.eEffectTargetBuildMaxSolder)//当前兵力最多的城池
            {
                UnitCtl unitMax = null;
                float hpTmp = 0.0f;
                SkillWarConf skillWarConf = War.model.GetSkillWarConf(skillOperateData.skillId);
                int skillType = skillWarConf.getBuildSkillType();//获取建筑类型技能
                foreach (UnitCtl unit in unitCtlListAll)
                {
                    RelationType unitRelation = effectParameter.caster.unitData.GetRelation(unit.unitData.legionId);
                    if (unit.hp >= hpTmp)
                    {
                        if(skillType == (int)eSKillWarEffectType.eEffectReplace && (skillOperateData.skillConfig.EnableUse(unit, unitRelation) == false))
                        {
                            continue;
                        }
                        hpTmp = unit.hp;
                        unitMax = unit;
                    }
                }
                if (unitMax != null)
                {
                    list.Add(unitMax);
                }
            }
            else if (target == (int)eSkillWarTargetType.eEffectTargetBuildFullMax)//当前兵力与兵力上限差值最大的城池
            {
                UnitCtl unitMax = null;
                float hpTmp = 0.0f;
                foreach (UnitCtl unit in unitCtlListAll)
                {
                    float hpDec = unit.hpMax - unit.hp;
                    if (hpDec >= hpTmp)
                    {
                        hpTmp = hpDec;
                        unitMax = unit;
                    }
                }
                if (unitMax != null)
                {
                    list.Add(unitMax);
                }
            }
            else if (target == (int)eSkillWarTargetType.eEffectTargetSoilderOnWay)//出征士兵
            {
                int unitType = 0;
                unitType = unitType.USolider(true);
                int relation = 0;
                relation = relation.REnemy(true);
                return War.scene.SearchUnit(unitType, effectParameter.caster.unitData.legionId, relation);
            }
            else if (target == (int)eSkillWarTargetType.eEffectTargetSoilder)//士兵所在城市
            {
                foreach (UnitCtl unit in unitCtlListAll)
                {
                    list.Add(unit);
                }
            }
            else if (target == (int)eSkillWarTargetType.eEffectTargetHero)//武将
            {
                foreach (UnitCtl unit in unitCtlListAll)
                {
                    if (unit.unitData.hasHero && unit.unitData.heroData.state  == HeroState.Foregstage)
                    {
                        list.Add(War.scene.GetHeroByBuild(unit));
                    }
                    //list.Add(unit);
                }
            }
            else if (target == (int)eSkillWarTargetType.eEffectTargetBuildBeHitMinHp)//正在被攻击&人口最少，没有被攻击则选人口最少的
            {
                List<UnitCtl> unitTmpList = new List<UnitCtl>();
                foreach (UnitCtl unit in unitCtlListAll)
                {
                    if(unit.unitData.behit == true)
                    {
                        unitTmpList.Add(unit);
                    }
                }
                if (unitTmpList.Count > 0)
                {
                    UnitCtl unitMin = null;
                    float hpTmp = 10000.0f;
                    foreach (UnitCtl unit in unitTmpList)
                    {
                        if (unit.hp <= hpTmp)
                        {
                            hpTmp = unit.hp;
                            unitMin = unit;
                        }
                    }
                    if (unitMin != null)
                    {
                        list.Add(unitMin);
                    }
                }
                if(list.Count <= 0)
                {
                    UnitCtl unitMin = null;
                    float hpTmp = 10000.0f;
                    foreach (UnitCtl unit in unitCtlListAll)
                    {
                        if (unit.hp <= hpTmp)
                        {
                            hpTmp = unit.hp;
                            unitMin = unit;
                        }
                    }
                    if (unitMin != null)
                    {
                        list.Add(unitMin);
                    }
                }
            }
            else if (target == (int)eSkillWarTargetType.eEffectTargetSoliderMax)//一定范围内影响士兵最多
            {
                int unitType = 0;
                unitType = unitType.USolider(true);
                int relation = 0;
                relation = relation.REnemy(true);
                //所有士兵
                List<UnitCtl> soldierListAll = War.scene.SearchUnit(unitType, effectParameter.caster.unitData.legionId, relation);
                //
                int interval = (int)(soldierListAll.Count / 10);
                if(interval <= 0)
                {
                    interval = 1;
                }
                int count = 0;
                for (int i = 0; i < soldierListAll.Count;  )
                {
                    UnitCtl unit = soldierListAll[i];
                    List<UnitCtl> listTmp = War.scene.SearchUnit(unit.transform.position, effectParameter.effect.range, unitType, effectParameter.caster.unitData.legionId, relation);
                    if (listTmp.Count > count)
                    {
                        count = listTmp.Count;
                        list = listTmp;
                        effectParameter.receivePos = unit.transform.position;
                    }
                    i += interval;
                    if(i >= soldierListAll.Count)
                    {
                        break;
                    }
                }
                Debug.LogFormat("=============================count: {0}", list.Count);
            }
            else if(target == (int)eSkillWarTargetType.eEffectTargetSoliderMaxNotAtk)//从没有被攻击，没有正在升级的城池里选一个人口最多的
            {
                foreach (UnitCtl unit in unitCtlListAll)
                {
                    if (unit.unitData.behit == false && unit.unitData.levelData.Upleveing == false && unit.unitData.hasHero == false)
                    {
                        list.Add(unit);
                    }
                }
                
            }
            else if(target == (int)eSkillWarTargetType.eEffectTargetSoliderMaxLevel)//从没有被攻击，没有正在升级,并且等级小于3的城池里选一个人口最多的
            {
                foreach (UnitCtl unit in unitCtlListAll)
                {
                    if (unit.unitData.behit == false && 
                        unit.unitData.levelData.Upleveing == false &&
                         unit.unitData.hasHero == false)
                    {
                        list.Add(unit);
                    }
                }
            }
            //else if(target == (int)eSkillWarTargetType.eEffectTargetSoliderAndBuild)//伤害士兵和建筑
            //{

            //}
            return list;
        }

        private List<UnitCtl> GetUnitRang(CSkillEffectDataItem effect, List<UnitCtl> unitCtlListTarget)
        {
            List<UnitCtl> list = new List<UnitCtl>();

            if (effect.operation == (int)eSkillWarEffectOperation.eEffectAuto)//自动目标
            {
                if (effect.target == (int)eSkillWarTargetType.eEffectTargetSoilderOnWay ||
                    effect.target == (int)eSkillWarTargetType.eEffectTargetSoliderMax)//士兵
                {
                    return unitCtlListTarget;
                }
                else//城市
                {
                    if (effect.range == 0 || effect.range >= unitCtlListTarget.Count)
                    {
                        return unitCtlListTarget;
                    }
                    List<UnitCtl> effectUnitTmp = new List<UnitCtl>();
                    int count = unitCtlListTarget.Count;
                    
                    //for (int i = 0; i < effect.range; i++)
                    //{
                        //超出当前城市个数
                       //if (count >= unitCtlListTarget.Count)
                       // {
                       //     return;
                       // }
                        int maxLoop = 1;
                        //已经受伤害的城池
                        Dictionary<int, int> demageBuildDic = new Dictionary<int, int>();
                        while (true)
                        {
                            if (unitCtlListTarget.Count <= 0)
                            {
                                break;
                            }
                            maxLoop++;
                            if (maxLoop >= 100)
                            {
                                Debug.Log("<color=red>==============maxLoop err</color>");
                                Debug.Log(string.Format("<color=red> effectHurt Loop err</color>"));
                                break;
                            }
                            int idxRand = Random.Range(0, count - 1);
                            Debug.LogFormat("========idxRand:{0} range:{1} {2} count:{3}", idxRand, effect.id, effect.range, count);
                            int idxCur = 0;
							int range = effect.range > count ? count : effect.range;
                            //UnitCtl unitGet = null;
                            foreach (UnitCtl unit in unitCtlListTarget)//获取城市
                            {
                                if (idxRand == idxCur)
                                {
                                    if (!demageBuildDic.ContainsKey(unit.unitData.id))
                                    {
                                        //unitGet = unit;
                                        effectUnitTmp.Add(unit);
                                        demageBuildDic.Add(unit.unitData.id, 1);
                                    }
                                    break;
                                }
                                idxCur++;
                            }
							if (effectUnitTmp.Count >= range)
                            {
                                break;
                            }
                        }
                        Debug.Log("======GetUnitRang maxLoop: " + maxLoop);
                    //}
                    return effectUnitTmp;
                }
            }
            else if (effect.operation == (int)eSkillWarEffectOperation.eEffectManualTarget)//手动目标
            {
                return unitCtlListTarget;
            }
            else if (effect.operation == (int)eSkillWarEffectOperation.eEffectmanualRange)//手动范围
            {
                return unitCtlListTarget;
            }
            else
            {
                return unitCtlListTarget;
            }
            return list;
        }
        #endregion

    }
}