using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime;
using CC.Runtime.Utils;
using Games.Module.Wars;

namespace Games.conf
{
        
    [ConfigPath("Config/plot_war_start", ConfigType.CSV)]
    public class PlotWarStartConf : IParseCsv, IKey<int>
    {
        public int id;
        public int stageId;
        public int plotId;
        public int postion;//0=左边，1=右边
        public int avatarId;
        public string name = "";
        public string content = "";
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
            stageId = csv.GetInt32(i++);
            plotId = csv.GetInt32(i++);
            postion = csv.GetInt32(i++);
            avatarId = csv.GetInt32(i++);
            name = csv.GetString(i++);
            content = csv.GetString(i++);
            id = stageId * 1000 + plotId;
            //Debug.Log("====SkillWarEffectConf====:" + id);
            //Coo.plotTalkManager.AddPlotWarStartConf(this);
        }
    }
}