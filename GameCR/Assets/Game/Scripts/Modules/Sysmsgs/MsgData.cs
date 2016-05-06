using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CC.Runtime;
using CC.Runtime.Utils;

namespace Games.Module.Sysmsgs
{
	[ConfigPath("Config/sysmsg",ConfigType.CSV)]
	public class MsgData:IFormatParse,IParseCsv, IKey<int>
    {
        private int id;
        public int level;
        private int type;
        private string content; 
        public bool isWaring=false;
        public bool flash=false;
		public MsgData()
        {
        }

        public int Key
        {
            get
            {
                return id;
            }
        }

        public int Type
        {
            get
            {
                return type;
            }
			set
			{
				type = value;
			}
        }

        public string Content
        {
            get
            {
                return content;
            }
        }

        public string Format(params object[] args)
        {
            return StringUtils.Format(content,args);
        }

        public void ParseCsv(string[] csv)
        { 
            id = Convert.ToInt32(csv[0]);
            level=Convert.ToInt32(csv[2]);
            content = csv[3];
            type = Convert.ToInt32(csv[4]);
            isWaring=Convert.ToInt32(csv[5])==1;
            flash=Convert.ToInt32(csv[6])==1;
        }
    }
}

