using UnityEngine;
using System.Collections;
using CC.Runtime;
using CC.Runtime.Utils;
using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Security.Permissions;
using ProtoBuf;

namespace Games.Module.Props
{
	[Serializable]
	[ProtoContract]
	public class Prop : IParseField
	{
		[ProtoMember(1)]
		public int ID { get; set;}
		[ProtoMember(2)]
		public float value { get; set;}

		private PropConfig _config;
		[XmlIgnore]
        public PropConfig config
		{
			get 
			{
				if (_config == null) 
				{
					_config =  PropConfig.GetInstance(ID);
				}

				return _config;
			}

			set
			{
				_config = value;
				if(_config != null) ID = _config.id;
			}
		}

        public Prop()
        {
        }

        public string Name{
            get{
                return config.name;
            }
        }

        public int id {
            get {
                return config.id;
            }
        }

        public int priority {
            get {
                return config.priority;
            }
        }
		
		public int additive {
			get {
				return config.additive;
			}
		}
		
		public PropType type {
			get {
				return config.type;
			}
		}
		
		public string commentName {
			get {
				return config.commentName;
			}
		}



        public string ValueStr{
            get{
                return string.Format(config.format, value);
            }
        }

        public Prop Clone()
        {
            Prop clone = new Prop();
            clone.config = config;
            clone.value = value;

            return clone;
        }

        public static Prop operator*( Prop p, float f){
            Prop res = p.Clone();
            res.value *= f;
            return res;
        }
             

        public static Prop CreateInstance(int id, float value)
        {
            PropConfig config = PropConfig.GetInstance(id);
            return CreateInstance(config, value);
        }

        public static Prop CreateInstance(PropConfig config, float value)
        {
            Prop prop = new Prop();
            prop.config = config;
            prop.value = value;
            return prop;
        }

		public static Prop CreateInstance(string field)
		{
			Prop prop = new Prop();
			prop.ParseField(field);
			return prop;
		}



        public void ParseField(string field)
        {
            string[] str = field.Split(',');
            int id = str.GetInt32(0);
            config = PropConfig.GetInstance(id);
            value = str.GetSingle(1);
        }

		public override string ToString ()
		{
			return string.Format ("[Prop: id={0}, {1}:{2}]",id, commentName, ValueStr);
		}




    }
}