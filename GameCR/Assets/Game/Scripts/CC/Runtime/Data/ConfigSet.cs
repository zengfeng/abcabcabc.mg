using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CC.Runtime.Utils;

namespace CC.Runtime
{
    public class ConfigSet<T1, T2> where T2 : class, IKey<T1>
    {
        public ConfigSet()
        {
            Type t2 = typeof(T2);
            pathattr = t2.GetCustomAttributes(typeof(ConfigPathAttribute), false)[0] as ConfigPathAttribute;
            content = new Dictionary<T1, T2>();
        }

        public T2 this[T1 key]
        {
            get
            {
                T2 res;
                if (content.TryGetValue(key, out res))
                {
                    return res;
                }
                return default(T2);
            }
        }

        public void Load()
        {
			AssetManager am = AssetManager.Instance;
            am.Load(pathattr.assetName, ParseAsset);
        }

        private void ParseAsset(string name, System.Object objs)
        {
            Type t2 = typeof(T2);
            Type icsv = typeof(IParseCsv);
            Type ijson = typeof(IParseJson);
            Type tsc = typeof(ScriptableObject);
            //TextAsset ta = objs as TextAsset;
			/** 如果ta=null，有可能是配置资源路径不对，或配置文件不存在 */
			if (objs == null) {
				Debug.LogError(name + " 有可能是配置资源路径不对，或配置文件不存在");
			}
			//string s = ta.text;
//			string s = objs as String;
			string s = objs.ToString();
            if (pathattr.configType == ConfigType.CSV)
            {
                bool iscsv = icsv.IsAssignableFrom(t2);
                StringReader sr = new StringReader(s);
				sr.ReadLine();
				sr.ReadLine();
                while (true)
                {
                    string str = sr.ReadLine();
                    if (str == null)
                    {
                        break;
                    }
                    string[] csv = str.Split(';');
                    if (csv.Length != 0 && !string.IsNullOrEmpty(csv[0]))
                    {
                        T2 item = default(T2);
                        if (tsc.IsAssignableFrom(t2))
                        {
                            item = ScriptableObject.CreateInstance(t2) as T2;
                        }
                        else
                        {
                            item = Activator.CreateInstance<T2>();
                        }

                        if (iscsv)
                        {
                            (item as IParseCsv).ParseCsv(csv);
                            Add(item.Key, item);
                        }
                        else
                        {
                            Fill(item, csv);
                            Add(item.Key, item);
                        }
                    }
                }
            }
            else
            {
                bool isjson = ijson.IsAssignableFrom(t2);
                object obj = JsonConvert.DeserializeObject(s);
                if (obj is JArray) {
                    JArray jar = obj as JArray;
                    for (int i = 0; i < jar.Count; ++i) { 
                        T2 item = null ;
                        if (tsc.IsAssignableFrom(t2))
                        {
                            item = ScriptableObject.CreateInstance(t2) as T2;
                        }
                        else
                        {
                            item = Activator.CreateInstance<T2>();
                        }
                        if (isjson)
                        {
                            (item as IParseJson).ParseJson(jar[i]);
                        }
                        else
                        {
                            JsonConvert.PopulateObject(jar[i].ToString(), item);
                        }
                        Add(item.Key, item);
                    }
                }
                else
                {
                    T2 item = null;
                    if (tsc.IsAssignableFrom(t2))
                    {
                        item = ScriptableObject.CreateInstance(t2) as T2;
                    }
                    else
                    {
                        item = Activator.CreateInstance<T2>();
                    }
                    if(isjson)
                    {
                        (item as IParseJson).ParseJson((JToken)obj);
                    }
                    else
                    {
                        JsonConvert.PopulateObject(obj.ToString(), item);
                    }
                    JsonConvert.PopulateObject(obj.ToString(), item);
                    Add(item.Key, item);
                }
            }
        }

        private void FillField(FieldInfo fi, T2 t2, string[] csv, int idx) 
        {
            object v = null;
            switch (fi.FieldType.FullName)
            {
                case "System.UInt16":
                    v = csv.GetUInt16(idx);
                    break;
                case "System.UInt32":
                    v = csv.GetUInt32(idx);
                    break;
                case "System.UInt64":
                    v = csv.GetUInt64(idx);
                    break;
                case "System.Int16":
                    v = csv.GetInt16(idx);
                    break;
                case "System.Int32":
                    v = csv.GetInt32(idx);
                    break;
                case "System.Int64":
                    v = csv.GetInt64(idx);
                    break;
                case "System.String":
                    v = csv.GetString(idx);
                    break;
                case "System.Boolean":
                    v = csv.GetBoolean(idx);
                    break;
                case "System.Single":
                    v = csv.GetSingle(idx);
                    break;
                case "System.Int32[]":
                    {
                        string str = csv.GetString(idx);
                        if (str == null)
                        {
                            v = null;
                        }
                        else
                        {
                            string[] spl = str.Split(',');
                            int[] arr = new int[spl.Length];
                            for (int i = 0; i < spl.Length; ++i)
                            {
                                arr[i] = spl[i].ToInt32();
                            }
                            v = arr;
                        }
                    }
				break;
				case "System.Single[]":
					{
						string str = csv.GetString(idx);
						if (str == null)
						{
							v = null;
						}
						else
						{
							string[] spl = str.Split(',');
							float[] arr = new float[spl.Length];
							for (int i = 0; i < spl.Length; ++i)
							{
								arr[i] = spl[i].ToSingle();
							}
							v = arr;
						}
					}
						break;
                case "System.String[]":
                    {
                        string str = csv.GetString(idx);
                        if (str == null)
                        {
                            v = null;
                        }
                        else
                        {
                            string[] spl = str.Split(',');
                            v = spl;
                        }
                    }
                    break;
                default:
                    if (fi.FieldType.IsEnum)
                    {
                        v = Enum.Parse(fi.DeclaringType, csv[idx]);
                    }
                    break;
            }
            fi.SetValue(t2, v);
        }

        private void FillField(FieldInfo fi, T2 t2, string[] csv, int[] idx)
        {
            Type tp = typeof(IParseField);
            object v = null;
            switch (fi.FieldType.FullName)
            {
                case "System.Int32[]":
                    {
                        List<int> list = new List<int>();
                        foreach (var i in idx) {
                            if (!string.IsNullOrEmpty(csv.GetString(i))) {
                                list.Add(csv.GetInt32(i));
                            }
                        }
                        v = list.ToArray();
                    }
                    break;
                case "System.String[]":
                    {
                        List<string> list = new List<string>();
                        foreach (var i in idx)
                        {
                            if (!string.IsNullOrEmpty(csv.GetString(i)))
                            {
                                list.Add(csv.GetString(i));
                            }
                        }
                        v = list.ToArray();
                    }
                    break;
                case "System.Single[]":
                    {
                        List<float> list = new List<float>();
                        foreach (var i in idx)
                        {
                            if (!string.IsNullOrEmpty(csv.GetString(i)))
                            {
                                list.Add(csv.GetSingle(i));
                            }
                        }
                        v = list.ToArray();
                    }
                    break;
                default:
                    Type t = Type.GetType(fi.FieldType.FullName).GetElementType();
                    if (tp.IsAssignableFrom(t))
                    {
                        int len = 0 ;
                        foreach (var i in idx)
                        {
                            if (!string.IsNullOrEmpty(csv.GetString(i)))
                            {
                                ++len;
                            }
                        }
                        Array arr = Array.CreateInstance(t, len);
                        int index = 0 ;
                        foreach (var i in idx) {
                            if (!string.IsNullOrEmpty(csv.GetString(i))) {
                                IParseField ipf = Activator.CreateInstance(t) as IParseField;
								ipf.ParseField(csv.GetString(i));
                                arr.SetValue(ipf, index);
                            }
                        }

                        v = arr;
                    }
                    break;
            }
            fi.SetValue(t2, v);
        }

        private void Fill(T2 t2, string[] csv)
        {
            Type typ2 = typeof(T2);
            FieldInfo[] fis = typ2.GetFields();
            foreach (var fi in fis)
            {
                CsvFieldAttribute[] cfas = (CsvFieldAttribute[])fi.GetCustomAttributes(typeof(CsvFieldAttribute), false);
                if (cfas != null && cfas.Length > 0)
                {
                    CsvFieldAttribute cfa = cfas[0];
                    if (cfa.columns == null || cfa.columns.Length == 0)
                        continue;
                    if (cfa.columns.Length == 1) {
                        FillField(fi, t2, csv, cfa.columns[0]);
                    }
                    else
                    {
                        FillField(fi, t2, csv, cfa.columns);
                    }
                }
            }
        }

        private void Add(T1 t1, T2 t2)
        {
            if (content.ContainsKey(t1))
            {
                content[t1] = t2;
            }
            else
            {
                content.Add(t1, t2);
            }
        }

        public void Reload()
        {
            if (pathattr.isStable)
            {
                return;
            }
            Clear();
            Load();
        }

        public void Clear()
        {
            content.Clear();
        }

        public void Each(Action<T2> proc) {
            foreach (var p in content.Values)
            {
                proc(p);
            }
        }

        private Dictionary<T1, T2> content;
        private ConfigPathAttribute pathattr;
    }
}
