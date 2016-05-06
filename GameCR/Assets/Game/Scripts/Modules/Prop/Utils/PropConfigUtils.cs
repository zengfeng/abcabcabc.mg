using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using CC.Runtime.Utils;

namespace Games.Module.Props
{
    public class PropConfigUtils
    {
        public static Prop[] ParsePropFields(string[] fields)
        {
            return ParsePropFields(fields, 0,fields.Length);
        }

        public static Prop[] ParsePropFields(string[] fields, int start)
        {
            return ParsePropFields(fields, start, fields.Length);
        }

        public static Prop[] ParsePropFields(string[] fields, int start, int end)
        {
            if (start >= fields.Length)
                return new Prop[0];

            if (end > fields.Length)
                end = fields.Length;

			int count = end - start;
			List<Prop> list = new List<Prop>();

			for (int i = 0; i < count; i++)
            {
                string[] segs = fields[start + i].Split(',');

                if (segs.Length <  2)
                    continue;

                int id = segs[0].ToInt32();
                float value = segs[1].ToSingle();

                Prop prop = Prop.CreateInstance(id, value);
				list.Add(prop);
            }

			return list.ToArray();
        }

        public static PropConfig[] ParsePropConfigFields(string[] fields, int start, int end)
        {
            if (start >= fields.Length)
                return new PropConfig[0];
            
            if (end > fields.Length)
                end = fields.Length;

            PropConfig[] configs = new PropConfig[end - start];
            
            for (int i = start; i < end; i++)
            {
                int id = fields[i].ToInt32();

                PropConfig config = PropConfig.GetInstance(id);
                configs[i - start] = config;
            }
            
            return configs;
        }

        public static Prop[] ParseCompactPropFields(string[] fields, PropConfig[] configs)
        {
            return ParseCompactPropFields(fields, configs, 0, fields.Length);
        }

        public static Prop[] ParseCompactPropFields(string[] fields, PropConfig[] configs, int start)
        {
            return ParseCompactPropFields(fields, configs, start, fields.Length);
        }

        public static Prop[] ParseCompactPropFields(string[] fields, PropConfig[] configs, int start, int end)
        {
            if (start >= fields.Length)
                return new Prop[0];
            
            if (end > fields.Length)
                end = fields.Length;
            
			int count = end - start;
			Prop[] props = new Prop[count];
            
			for (int i = 0; i < count; i++)
            {
                float value  = fields[start + i].ToSingle();
                PropConfig config = configs[i];
                Prop prop = Prop.CreateInstance(config, value);               
            
                props[i] = prop;
            }
            
            return props;
        }

		public static FormulaProp[] ParseFormulaPropFields(string[] fields, int start, int end)
		{
			if (start >= fields.Length)
				return new FormulaProp[0];
			
			if (end > fields.Length)
				end = fields.Length;
			
			int count = end - start;
			List<FormulaProp> list = new List<FormulaProp>();
			
			for (int i = 0; i < count; i++)
			{
				string[] segs = fields[start + i].Split(',');
				
				if (segs.Length <  2)
					continue;
				
				int id = segs[0].ToInt32();
				int value = segs[1].ToInt32();
				
				FormulaProp prop = new FormulaProp(id, value);
				list.Add(prop);
			}
			
			return list.ToArray();
		}



		//------------------------------
		public static Prop[] ParsePropFields2(string[] fields, int start)
		{
			return ParsePropFields2(fields, start, fields.Length);
		}
		
		public static Prop[] ParsePropFields2(string[] fields, int start, int end)
		{
			if (start >= fields.Length)
				return new Prop[0];
			
			if (end > fields.Length)
				end = fields.Length;
			
			int count = end - start;
			List<Prop> list = new List<Prop>();
			
			for (int i = 0; i < count; i+=2)
			{
				if(count - i < 2)
				{
					break;
				}

				int id 		= fields[start + i].ToInt32();
				float value = fields[start + i + 1].ToSingle();
				
				Prop prop = Prop.CreateInstance(id, value);
				list.Add(prop);
			}
			
			return list.ToArray();
		}

		//------------------------------
		public static Prop[] ParsePropFields3(string[] fields, int start)
		{
			return ParsePropFields2(fields, start, fields.Length);
		}
		
		public static Prop[] ParsePropFields3(string[] fields, int start, int end)
		{
			if (start >= fields.Length)
				return new Prop[0];
			
			if (end > fields.Length)
				end = fields.Length;
			
			int count = end - start;
			List<Prop> list = new List<Prop>();
			
			for (int i = 0; i < count; i+=3)
			{
				if(count - i < 3)
				{
					break;
				}

				int id 		= fields[start + i + 1].ToInt32();
				float value = fields[start + i + 2].ToSingle();
				
				Prop prop = Prop.CreateInstance(id, value);
				list.Add(prop);
			}
			
			return list.ToArray();
		}
    }
}

