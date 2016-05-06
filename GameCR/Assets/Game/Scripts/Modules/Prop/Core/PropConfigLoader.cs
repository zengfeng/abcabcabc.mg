using System;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using CC.Runtime;
using CC.Runtime.Utils;

namespace Games.Module.Props
{
    public class PropConfigLoader : IConfig
    {
        #region IConfig implementation
        public void Load(AssetManager am)
		{
			am.Load ("Config/property", OnLoad);
		}

		virtual protected void OnLoad(string filename, System.Object data) 
		{
			if(data == null) Debug.LogError("[Error] finelname=" + filename );
			String text = data as String;

            List<PropConfig> ptsort = new List<PropConfig>();
            using (StringReader sr = new StringReader(text))
            {
				sr.ReadLine();
				sr.ReadLine();
                while (sr.Peek() >= 0)
                {
                    string str = sr.ReadLine();
                    string[] fields = str.Split(';');
                    if (string.IsNullOrEmpty(fields [0]))
                    {
                        continue;
                    }
					int i = 0;
                    PropConfig ept = new PropConfig();
                    ept.id = fields [i++].ToInt32();
					ept.name = fields [i++];
					ept.displayMultiplier = fields [i++].ToSingle();
					ept.format = fields [i++];
					ept.mapping = fields [i++].Trim();

					if (!string.IsNullOrEmpty(fields [i].Trim())) ept.limitMinValue = fields [i].ToSingle();
					i++;

					if (!string.IsNullOrEmpty(fields [i].Trim())) ept.limitMaxValue = fields [i].ToSingle();
					i++;

					ept.priority = fields [i++].ToInt32();
					ept.additive = fields [i++].ToInt32();
					ept.type = (PropType) fields [i++].ToInt32();
					i++;
					ept.commentName = fields [i++];
//                    ept.pass = (EnhPropPass)fields[5].ToInt32();
                    _propConfigs [ept.id] = ept;
                    ptsort.Add(ept);
                }
            }
            ptsort.Sort( (t1,t2)=>t1.priority - t2.priority);
            propsorts = ptsort.ToArray();
        }
        
        public void ReLoad(AssetManager am)
        {
            for (int i = 0; i < _propConfigs.Length; ++ i)
            {
                _propConfigs [i] = null;
            }
            Load(am);
        }
        #endregion

        public PropConfig[] propConfigs {
            get {
                return _propConfigs;
            }
        }

        private PropConfig[] _propConfigs = new PropConfig[PropId.MAX];
        private PropConfig[] propsorts;
        
        public PropConfig[] PropSorted{
            get{
                return propsorts;
            }
        }
    }
}

