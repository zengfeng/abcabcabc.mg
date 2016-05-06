using UnityEngine;
using System.Collections;

namespace Games.Module.Wars
{
        public enum eSKillWarEffectType
        {
            eEffectHurt             = 1,//伤害
            eEffectAddSolder        = 2,//增兵
            eEffectAddShield        = 3,//加盾
            eEffectShowNum          = 4,//显示兵力
            eEffectGo               = 5,//奔袭：快速出兵到某处
            eEffectLevelUp          = 10,//建筑等级增加
            eEffectReplace          = 11,//替换建筑
            eEffectAttach           = 12,//添加功能
            eEffectBuildLevelMax    = 13,//增加建筑最大等级
            eEffectAddAttri         = 100,//增加属性
            eEffectReduceAttri      = 101,//减少属性
            eEffectAddSkillPower    = 102,//增强主动技能效果(待定)
            eEffectGoBack           = 103,//伪报：（概率）出征士兵回到出发城池
            eEffectMess             = 104,//混乱：（概率）城池无法出兵
            eEffectSilence          = 105,//沉默：（概率）方武将无法释放技能
            eEffectDouble           = 106,//连击：（概率）再次出发该技能
            eEffectBurn             = 107,//灼烧：（概率）灼烧标记（优先选择没有被标记的城池）
            eEffectAddAttriBeforeWar = 108,//修炼：（战前）永久增加属性
            eEffectReduceSpeedTo    = 109,//移动速度降为0
            eEffectAddSoldierPer    = 110,//根据百分比增加士兵
            eEffectHurtBuidingMax   = 111,//根据建筑伤害上限百分比
            eEffectAddSoldierHitMax = 112,//根据是否受到士兵攻击判定加血
            eEffectHeroToBuild      = 113,//主公上阵
            eEffectDispel           = 114,//驱散
            eEffectHurtRate         = 115,//百分比伤害
            eEffectBuildAutoHurt    = 118,//是建筑定时伤害
            eEffectDelay            = 200,//用于多个效果序列执行等待
    	}
        enum eSkillWarEffectOperation
        {
            eEffectAuto         = 0, // 0=自动
            eEffectManualTarget = 1, //1=选择目标
            eEffectmanualRange  = 2,//2=选择区域
        }
    
        enum eSkillWarEffectCamp
        {
            eEffectCampSelf     = 0,//己方
            eEffectCampEnemy = 1,//敌方
            eEffectCampfriend   = 2,//友方
            eEffectCampFree     = 3,//不限
        }
         enum eSkillWarTargetType
         {
             eEffectTargetBuild            = 1,  //城池
             eEffectTargetEmptyBuild       = 2,  //空城
             eEffectTargetHeroBuild        = 3,  //将城
              eEffectTargetBuildMinSolder  = 4,  //当前兵力最少的城池
             eEffectTargetBuildMaxSolder   = 5,  //当前兵力最多的城池
             eEffectTargetBuildFullMax     = 6,  //当前兵力与兵力上限差值最大的城池
             eEffectTargetSoilderOnWay     = 9,  //出征士兵
             eEffectTargetSoilder          = 10, //士兵所在城市
             eEffectTargetHero             = 11, //武将
             eEffectTargetBuildBeHitMinHp  = 12, //正在被攻击&人口最少，没有被攻击则选人口最少的
             eEffectTargetSoliderMax       = 13, //一定范围内影响士兵最多
             eEffectTargetSoliderMaxNotAtk = 14, //从没有被攻击，没有正在升级的城池里选一个人口最多的
             eEffectTargetSoliderMaxLevel  = 15, //从没有被攻击，没有正在升级,并且等级小于3的城池里选一个人口最多的
             eEffectTargetSoliderAndBuild  = 16, //优先伤害士兵，没有士兵伤害敌方城池
             eEffectTargetSoliderAndBuildRangeAll  = 17, //范围内所有士兵和城池
    }

    enum eSkillAiType
    {
        eSkillAiNone              = 0,//无
        eSkillAiEnemyBuildSoldier = 1,//敌方存在城池人口≥X
        eSkillAiSelfSoldierAll    = 2,//存在没有被攻击的城池，没有正在升级的城池时
        eSkillAiEnemyBuild        = 3,//敌方城池≥X
        eSkillAiEnemySoldier      = 4,//敌方出征部队≥X（占当期出征总人数的百分比）
        eSkillAiSelfBuild         = 5,//己方城池数≥X
        eSkillAiSelfBuildAttack   = 6,//己方城池被攻击时
        eSkillAiSelfBuildSoldier  = 7,//己方总人口≥敌方，且存在没有被攻击的城池，没有正在升级的城池时
        eSkillAiSelfBuildLevel    = 8,//己方总人口≥敌方，且存在没有被攻击的城池，没有正在升级的城池,并且有等级小于x级的城市
        eSkillAiSelfSoldier       = 9,//己方出征部队≥X（占当期出征总人数的百分比）
    }
}