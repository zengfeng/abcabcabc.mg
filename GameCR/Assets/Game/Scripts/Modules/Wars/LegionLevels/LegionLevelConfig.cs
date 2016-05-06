using UnityEngine;
using System.Collections;
using CC.Runtime;
using Games.Module.Props;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	[ConfigPath("Config/morale_consume",ConfigType.CSV)]
	public class LegionLevelConfig : IParseCsv, IKey<int>
	{
		public static int MaxLevel = 0;
		public int 		level;
		public float 	exp;

		private float	subAtk;
		private float	subProduceSpeed;
		private float	subMoveSpeed;
		
		/** 属性列表 */
		public Prop[] soliderPropList;
		public float[] soliderProps = new float[PropId.MAX];


		/** 属性列表 */
		public Prop[] buildPropList;
		public float[] buildProps = new float[PropId.MAX];

		public float atkPer
		{
			get
			{
				return soliderProps[PropId.AtkPer];
			}
		}

		public float produceSpeedPer
		{
			get
			{
				return soliderProps[PropId.ProduceSpeedPer];
			}
		}
		
		public float moveSpeedPer
		{
			get
			{
				return soliderProps[PropId.MoveSpeedPer];
			}
		}

		public float SubAtk
		{
			get
			{
				return subAtk / PropConfig.GetInstance(PropId.AtkAdd).displayMultiplier;
			}
		}
		
		public float SubProduceSpeed
		{
			get
			{
				return subProduceSpeed / PropConfig.GetInstance(PropId.ProduceSpeedAdd).displayMultiplier;
			}
		}
		
		public float SubMoveSpeed
		{
			get
			{
				return subMoveSpeed / PropConfig.GetInstance(PropId.MoveSpeedAdd).displayMultiplier;
			}
		}
		
		public int Key
		{
			get
			{
				return level;
			}
		}

		public void ParseCsv(string[] csv)
		{
			int i = 0;
			
			level 	=  csv.GetInt32(i ++ );
			exp		=  csv.GetInt32(i ++ );

			float[] subs = csv.GetFloatArray(i ++);
			subAtk 				= subs[0];
			subProduceSpeed 	= subs[1];
			subMoveSpeed 		= subs[2];

			i ++ ;
			int beginIndex = i;
			int endIndex = i + 8;
			soliderPropList = PropConfigUtils.ParsePropFields2(csv, beginIndex, endIndex);
			soliderProps = soliderProps.PropAdd(soliderPropList);

			i = endIndex;
			i++;
			beginIndex = i;
			endIndex = i + 8;
			buildPropList = PropConfigUtils.ParsePropFields2(csv, beginIndex, endIndex);
			buildProps = buildProps.PropAdd (buildPropList);
//			buildProps[PropId.BattleForceAdd] += soliderProps[PropId.BattleForceAdd];
//			buildProps[PropId.BattleForcePer] += soliderProps[PropId.BattleForcePer];
//			buildPropList = buildProps.FilterZero();

			if(MaxLevel < level)
			{
				MaxLevel = level;
			}
			
			War.model.AddLegionLevelConfig(this);
		}


	}
}