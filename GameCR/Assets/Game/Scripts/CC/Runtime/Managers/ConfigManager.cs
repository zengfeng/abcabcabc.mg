using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CC.Runtime
{
    public class ConfigManager : MonoBehaviour
    {
		private static ConfigManager _Instance;
		public static ConfigManager Instance
		{
			get
			{
				if(_Instance == null)
				{
					GameObject go = GameObject.Find("GameManagers");
					if(go == null) go = new GameObject("GameManagers");
					
					_Instance = go.GetComponent<ConfigManager>();
					if(_Instance == null) _Instance = go.AddComponent<ConfigManager>();
				}
				return _Instance;
			}
		}


		public AssetManager assetManager { get{return AssetManager.Instance;} }

        public void Awake()
        {
			_Instance = this;
            configs = new Dictionary<string, object>();
        }

        public ConfigSet<T1, T2> GetConfig<T1, T2>() where T2 : class, IKey<T1>
        {
            Type t2 = typeof(T2);
            object obj = null;
            if (configs.TryGetValue(t2.FullName, out obj))
            {
                return obj as ConfigSet<T1, T2>;
            }
            else
            {
                ConfigSet<T1, T2> cs = new ConfigSet<T1, T2>();
                cs.Load();
                configs.Add(t2.FullName, cs);
                return cs;
            }
        }
        public T GetCustomConfig<T>() where T : class, IConfig, new()
        {
            Type typ = typeof(T);
            object obj;
            if (configs.TryGetValue(typ.FullName, out obj))
            {
                return obj as T;
            }
            else
            {
                T t = new T();
                t.Load(assetManager);
                configs.Add(typ.FullName, t);
                return t;
            }
        }


		private Dictionary<string, object> configs = new Dictionary<string, object>();
    }
}
