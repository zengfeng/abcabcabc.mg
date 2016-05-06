using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using CC.Runtime;
using Games.Module.Props;


namespace Games.Module.Wars
{
	/** 主公等级属性列表配置 */
	[ConfigPath("Config/exp_neutral",ConfigType.CSV)]
	public class NeutralExpConfig : IParseCsv, IKey<int>
	{

		public int level;
		public Prop[] propList;
		public float[] props = new float[PropId.MAX];

		public float subAtk = 0;
		public float subProduceSpeed = 0;
		public float subMoveSpeed = 0;


		public int Key
		{
			get
			{
				return level;
			}
		}

		public void ParseCsv(string[] csv)
		{
			
			//			等级	属性类型1	初始兵力	属性类型2	战力	属性类型3	募兵	属性类型4	速度	战力最大	募兵最大	速度最大
			//			level	type1	initTroop	type2	atk	type3	produce	type4	speed	maxAtk	maxProduce	maxSpeed
			int i = 0;
			// 等级
			level =  csv.GetInt32(i ++ );



			int beginIndex = i;
			int endIndex = 8;
			propList = PropConfigUtils.ParsePropFields2(csv, beginIndex, endIndex);
			props = props.PropAdd (propList);

//			i = endIndex + 4;
//			float subs = csv.GetFloatArray(i);
//			subAtk 				= subs[0];
//			subProduceSpeed 	= subs[1];
//			subMoveSpeed 		= subs[2];

			
			War.model.AddNeutralExpConfig(this);
		}
		
	
	}


}
