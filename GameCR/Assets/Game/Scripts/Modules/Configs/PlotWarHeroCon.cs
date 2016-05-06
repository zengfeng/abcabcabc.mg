using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime;
using CC.Runtime.Utils;
using Games.Module.Wars;

namespace Games.conf
{
        
    [ConfigPath("Config/plot_war_hero", ConfigType.CSV)]
    public class PlotWarHeroConf : IParseCsv, IKey<string>
    {
        public string id;
        public int stageId;
        public int monsterId;
        public int triggerType;//触发类型
        public int triggerRate;//触发概率
        public string[] contentArray;
        public int count;
        public string Key
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
            stageId = csv.GetInt32(i++);
            monsterId = csv.GetInt32(i++);
            triggerType = csv.GetInt32(i++);
            triggerRate = csv.GetInt32(i++);
            string contentString = csv.GetString(i++);
            contentArray = contentString.Split('|');
            count = csv.GetInt32(i++);
            id = string.Format("{0}_{1}_{2}", stageId, monsterId, triggerType);
            //Debug.LogFormat("=====PlotwarHero: {0} ======", id);
           // Coo.plotTalkManager.AddPlotWarHeroConf(this);
        }
    }
}