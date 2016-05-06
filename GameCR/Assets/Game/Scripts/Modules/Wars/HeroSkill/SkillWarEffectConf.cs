using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
    [ConfigPath("Config/skill_war_effect", ConfigType.CSV)]
    public class SkillWarEffectConf : IParseCsv, IKey<int>
    {
        public int id;
        /************************************
         * type类型
         * 1=伤害
         * 2=增兵
         * 3=加盾
         * 4=显示兵力
         * 5=奔袭：快速出兵到某处
         * 10 = 建筑升级
         * 11 = 建筑替换
         * 12 = 建筑附加功能
         * 100=增加属性
         * 101=减少属性
         * 102=增强主动技能效果
         * 103=伪报：（概率）出征士兵回到出发城池
         * 104=混乱：（概率）城池无法出兵
         * 105=沉默：（概率）方武将无法释放技能
         * 106=连击：（概率）再次出发该技能
         * 107=灼烧：（概率）灼烧标记（优先选择没有被标记的城池）
         * 108=修炼：（战前）永久增加属性
         * 109=移动速度降为0
         ************************************/
        public int type;
        /************************************
         * 操作方式
         * 0=自动
         * 1=选择目标
         * 2=选择区域
         ************************************/
        public int operation;  
        /************************************
         * 目标阵营
         * 0=己方
         * 1=敌方
         * 2=友方
         * 3=不限
         ************************************/
         public int camp;  
        /************************************
         * 目标类型
         * 0=施法武将城池
         * 1=城池
         * 2=空城
         * 3=将城
         * 4=当前兵力最少的城池
         * 5=当前兵力最多的城池
         * 6=当前兵力与兵力上限差值最大的城池
         * 7=与施法武将距离最近的城池
         * 8=与施法武将距离最远的城池
         * 9=出征士兵
         * 10=士兵
         * 11=武将
         ************************************/
        public int target;  
        /************************************
         * 作用范围
         * 范围或者目标数量
         * 0=全部
         ************************************/
        public int range;  
        /************************************
         * 持续时间
         ************************************/
        public int time;
         /************************************
         * 人口上限
         * 0=否
         * 1=可以超过
         ************************************/
        public int addSoldierMax;
         /************************************
         * 属性类型
          * 改变属性的类型property表
         ************************************/
        public int changePropertyId;
         /************************************
         * 是否可重叠
         * 0=否
         * 1=是
         ************************************/
        public int overlap;
        public float costHP;         /** 消耗兵力 */
        public float costHPPer;      /** 消耗兵力百分比 */
        public string animPathStart = "";
        public string animPathEnd = "";
        public string buffAnimPath = "";
        public int hurtCount = 1;
        public int isSend = 0;
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
            type = csv.GetInt32(i++);
            operation = csv.GetInt32(i++);
            camp = csv.GetInt32(i++);
            target = csv.GetInt32(i++);
            range = csv.GetInt32(i++);
            time = csv.GetInt32(i++);
            addSoldierMax = csv.GetInt32(i++);
            changePropertyId = csv.GetInt32(i++);
            overlap = csv.GetInt32(i++);
            // 消耗兵力
            costHP = csv.GetInt32(i++);
            // 消耗兵力百分比
            costHPPer = csv.GetInt32(i++) / 100f;
            animPathEnd = csv.GetString(i++);
            animPathStart = csv.GetString(i++);
            buffAnimPath = csv.GetString(i++);
            hurtCount = csv.GetInt32(i++);
            isSend = csv.GetInt32(i++);
            //Debug.Log("====SkillWarEffectConf====" + id);
            War.model.AddSkillWarEffectConf(this);
        }
    }
}