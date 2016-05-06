using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
    //技能效果信息
    public class CSkillEffectDataItem 
    {
        public CSkillEffectDataItem()
        {
            init();
        }
        public int id;               //效果id
        public float data;           //属性
        public float growUp;         //每级成长
        public int type;             //type类型
        public int operation;        //操作方式
        public int camp;             //目标阵营
        public int target;           //目标类型
        public int range;            //作用范围
        public int time;             //持续时间
        public int addSoldierMax;    //人口上限
        public int changePropertyId; //属性类型
        public int overlap;          //是否可重叠
        public float costHP;         /** 消耗兵力 */
        public float costHPPer;      /** 消耗兵力百分比 */

        public string animPathStart;
        public string animPathEnd;
        public string buffAnimPath;
        public string musicEffectPath;
        public int hurtCount;
        public int isSend;
        public void init()
        {
           // Debug.Log("===stSkillEffectDataItem init====");
            id = 0;
            data = 0.0f;
            growUp = 0.0f;
            type = 0;
            operation = 0;
            camp = 0;
            target = 0;
            range = 0;
            time = 0;
            addSoldierMax = 0;
            changePropertyId = 0;
            overlap = 0;
            animPathStart = "";
            animPathEnd = "";
            buffAnimPath = "";
            musicEffectPath = "";
            hurtCount = 1;
            isSend = 0;
        }
    }

    [ConfigPath("Config/skill_war_attri", ConfigType.CSV)]
     public class SkillWarConf :  IParseCsv, IKey<int>
    {
		public SkillWarDisplayConf displayConfig;

        public int id;
		/** AI技能顺序 */
		public int aiPriority;
        /** ai类型 **/
        public int []aiTypeArray = new int[] { 0, 0};
        /** 使用次数 */
        public int useCount;
		/** 是否上阵 */
		public bool isSettledBuild;

		/** 目标建筑类型 */
		public int buildType;

		//技能效果属性
		public CSkillEffectDataItem mainEffectData;

        //public Dictionary<int, CSkillEffectDataItem> effectDataDict = new Dictionary<int, CSkillEffectDataItem>();
        public List< CSkillEffectDataItem> effectDataList = new List< CSkillEffectDataItem>();
        public int consume;//能量消耗
        public int skillCd;    //cd
        //public int skill2Id;   //对应的2技能id
        public string musicEffectPath;//技能特效
        public string heroVoicePath;  //英雄声音

        public int skillAvatar;
		public string skillName;
		public string skillDescribe;
		
        //public string skillName2;
        //public string skillDescribe2;

        private int maxEffectId = 6;
        
        public int Key
        {
            get
            {
                return id;
            }
        }

        public void ParseCsv(string[] csv)
        {

            int i = 0;
            //id
            id = csv.GetInt32(i++);
			// AI技能顺序 
			aiPriority = csv.GetInt32(i++);
            //AItype
            string aiTypeStr = "";
            aiTypeStr = csv.GetString(i++);
            string[] aiTypeStrArray = aiTypeStr.Split(':');
            if(aiTypeStrArray.Length == 2)
            {
                aiTypeArray[0] = aiTypeStrArray[0].ToInt32();
                aiTypeArray[1] = aiTypeStrArray[1].ToInt32();
            }
            //Debug.LogFormat("=============aiTypeStr: {0}, {1}",id, aiTypeStr);
            // 使用次数
            useCount = csv.GetInt32(i++);
			// 是否上阵
			isSettledBuild = csv.GetBoolean(i++);
			// 目标建筑类型
			buildType = csv.GetInt32(i++);

            //effectId
            string effectIdStr;
            effectIdStr = csv.GetString(i++);
            string[] effectIdArray = effectIdStr.Split(',');
            //data
            string dataStr;
            dataStr = csv.GetString(i++);
            string[] dataStrArray = dataStr.Split(',');
            //growUp
            string growUPStr;
            growUPStr = csv.GetString(i++);
            string[] growUPStrArray = growUPStr.Split(',');
            //Debug.Log("========" + id + "=========" + growUPStr + "++++" + effectIdArray.Length);
            for (int idx = 0; idx < maxEffectId; ++idx)
            {
                if (effectIdArray.Length <= idx ||
                    dataStrArray.Length <= idx ||
                    growUPStrArray.Length <= idx)
                {
                    break;
				}
				
				CSkillEffectDataItem skillEffectDate = new CSkillEffectDataItem();
                skillEffectDate.id = effectIdArray[idx].ToInt32();
                skillEffectDate.data = dataStrArray[idx].ToSingle();
                skillEffectDate.growUp = growUPStrArray[idx].ToSingle();
                effectDataList.Add(skillEffectDate);
				if(mainEffectData == null) mainEffectData = skillEffectDate;

                SkillWarEffectConf effect = War.model.GetSkillWarEffectConf(skillEffectDate.id);
                if (effect != null)
                {
                    skillEffectDate.type = effect.type;
                    skillEffectDate.operation = effect.operation;
                    skillEffectDate.camp = effect.camp;
                    skillEffectDate.target = effect.target;
                    skillEffectDate.range = effect.range;
                    skillEffectDate.time = effect.time;
                    skillEffectDate.addSoldierMax = effect.addSoldierMax;
                    skillEffectDate.changePropertyId = effect.changePropertyId;
                    skillEffectDate.overlap = effect.overlap;
                    skillEffectDate.animPathStart = effect.animPathStart;
                    skillEffectDate.animPathEnd = effect.animPathEnd;
                    skillEffectDate.buffAnimPath = effect.buffAnimPath;
                    skillEffectDate.hurtCount = effect.hurtCount;
                    skillEffectDate.isSend = effect.isSend;
                    skillEffectDate.costHP = effect.costHP;
                    skillEffectDate.costHPPer = effect.costHPPer;
                }
                else
                {
                  //  Debug.LogFormat("<color=#ff0000>=======cant find skillEffectDate: {0}=======</color>", skillEffectDate.id);
                }
                //Debug.Log(string.Format("<color=green> effectdata={0}, {1}, {2}, type:{3} id:{4}</color>",
                //                skillEffectDate.id, skillEffectDate.data, skillEffectDate.growUp, skillEffectDate.type,
                //                skillEffectDate.id));

            }
            consume = csv.GetInt32(i++);
            skillCd = csv.GetInt32(i++);
            //skill2Id = csv.GetInt32(i++);
            heroVoicePath = csv.GetString(i++);
            musicEffectPath = csv.GetString(i++);

            skillAvatar = csv.GetInt32(i++);

            skillName = csv.GetString(i++);
			skillDescribe = csv.GetString(i++);

            //skillName2 = csv.GetString(i++);
            //skillDescribe2 = csv.GetString(i++);

			displayConfig = War.model.GetSkillWarDisplayConf (id);
			if (displayConfig != null) 
			{
				skillAvatar = displayConfig.avatarId;
			} 
			else
			{
//				Debug.LogErrorFormat ("skillId={0}, displayConfig={1}", id, displayConfig);
			}
          
            War.model.AddSkillWarConf(this);
        }

        public CSkillEffectDataItem getEffectDataById(int id)
        {
            foreach(CSkillEffectDataItem effect in effectDataList)
            {
                if(id == effect.id)
                {
                    return effect;
                }
            }
            return null;
        }

        public Dictionary<int, float> getEffectValue()
        {
            Dictionary<int, float> effectDicTmp = new Dictionary<int, float>();
            foreach ( CSkillEffectDataItem effect in effectDataList)
            {
                effectDicTmp[effect.changePropertyId] = effect.data;
            }

            return effectDicTmp;
        }

        //获取技能类型，目标是否有eEffectTargetBuildBeHitMinHp
        public int getTargetType()
        {
            foreach (CSkillEffectDataItem effect in effectDataList)
            {
                if(effect.target == (int)eSkillWarTargetType.eEffectTargetBuildBeHitMinHp)
                {
                    return effect.target;
                }
            }
            return 0;
        }


        //获取技能修改建筑等级上限
        public int getBuildLvlUpValue()
        {
            int value = 0;
            foreach (CSkillEffectDataItem effect in effectDataList)
            {
                if (effect.type == (int)eSKillWarEffectType.eEffectLevelUp)
                {
                    value = (int)effect.data ;
                }
            }
            return value;
        }
        //获取技能需要消耗的士兵数量
        public float getSkillCostHp()
        {
            float costHp = 0.0f;
            foreach (CSkillEffectDataItem effect in effectDataList)
            {

                if (effect.costHP != 0)
                {
                    costHp = effect.costHP;
                }
            }
            return costHp;
        }

        //获取技能需要消耗的士兵数量百分比
        public float getSkillCostHPPer()
        {
            float costHPPer = 0.0f;
            foreach (CSkillEffectDataItem effect in effectDataList)
            {

                if (effect.costHPPer != 0)
                {
                    costHPPer = effect.costHPPer;
                }
            }
            return costHPPer;
        }

        //返回建筑类技能类型
        public int getBuildSkillType()
        {
            int type = 0;
            foreach (CSkillEffectDataItem effect in effectDataList)
            {
                if (effect.type == (int)eSKillWarEffectType.eEffectBuildLevelMax)//增加建筑最大等级
                {
//                    type = (int)eSKillWarEffectType.eEffectBuildLevelMax;
                }
                if (effect.type == (int)eSKillWarEffectType.eEffectAttach)//建筑等级增加
                {
                    type = (int)eSKillWarEffectType.eEffectAttach;
                }
                if (effect.type == (int)eSKillWarEffectType.eEffectLevelUp)//添加功能
                {
                    type = (int)eSKillWarEffectType.eEffectLevelUp;
                }
                if (effect.type == (int)eSKillWarEffectType.eEffectReplace)//替换建筑
                {
                    type = (int)eSKillWarEffectType.eEffectReplace;
                }

            }
            return type;
        }
    }

}
