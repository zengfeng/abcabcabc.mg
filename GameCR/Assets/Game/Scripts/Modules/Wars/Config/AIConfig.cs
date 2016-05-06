using UnityEngine;
using System.Collections;
using CC.Runtime;
using System.Collections.Generic;
using CC.Runtime.Utils;



namespace Games.Module.Wars
{
	public enum AIAttackLevel
	{
		/** 懒惰，不会进攻 */
		[HelpAttribute("懒惰，不会进攻")]
		Level_0_Lazy 		= 0,


		/** 谨慎，有胜算才进攻 */
		[HelpAttribute("谨慎，有胜算才进攻")]
		Level_1_Cautious 	= 1,


		/** 勇猛，不管咋地都进攻 */
		[HelpAttribute("勇猛，不管咋地都进攻")]
		Level_2_Valor 		= 2,
	}

	/** AI升级级别 */
	public enum AIUplevelLevel
	{

		[HelpAttribute("0=不会建筑升级")]
		Level_0_Lazy = 0,

		
		[HelpAttribute("1=满足人口条件就会升级")]
		Level_1_Enable = 1,
		
		[HelpAttribute("2=非攻打状态下，满足人口条件就会升级")]
		Level_2_Cautious = 2,


	}

	/** 建筑--城池--属性配置 */
	[ConfigPath("Config/stage_ai",ConfigType.CSV)]
	public class AIConfig : IParseCsv, IKey<int>
	{
		public int 				id;
		public string			name;
		/** 间隔时间 */
		public float			interval;
		/** 间隔时间浮动 */
		public float			intervalRandom;
		/** 攻击--级别 */
		public AIAttackLevel	attackLevel;
		/** 攻击--级别 */
		public float	distanceScoreRate_Attack;
		/** 攻击--被攻击是否出兵概率% */
		public float	attackBehitRate;
		/** 攻击--部队数量概率 */
		public List<float> 		attackUnitRate = new List<float>();
		/** 攻击--选择目标概率 */
		public List<float> 		attackTargetRate = new List<float>();
		/** 救援--概率 */
		public float 			rescueRate;
		/** 救援--距离权重 */
		public float	distanceScoreRate_Rescue;
		/** 救援--部队数量概率 */
		public List<float> 		rescueUnitRate = new List<float>();
		/** 出兵百分比 */
		public float 			sendArmPercent = 1;
		/** AI升级级别 */
		public AIUplevelLevel	uplevelLevel;
		/** AI升级间隔时间 */
		public float			uplevelInterval;
		/** AI升级间隔时间浮动 */
		public float			uplevelIntervalRandom;


		/** 攻击--部队数量 */
		public int GetAttackSendCount()
		{
			float r = Random.Range(0f, 99f);
			float v = 0;
			for(int i = 0; i < attackUnitRate.Count; i ++)
			{
				v += attackUnitRate[i];
				if(r < v)
				{
					return i + 1;
				}
			}
			return 0;
		}
		
		/** 攻击--选择目标 */
		public int GetAttackTargetIndex()
		{
			float r = Random.Range(0f, 99f);
			float v = 0;
			for(int i = 0; i < attackTargetRate.Count; i ++)
			{
				v += attackTargetRate[i];
				if(r < v)
				{
					return i;
				}
			}
			return 0;
		}

		
		
		/** 救援--部队数量 */
		public int GetRescueSendCount()
		{
			float r = Random.Range(0f, 99f);
			float v = 0;
			for(int i = 0; i < rescueUnitRate.Count; i ++)
			{
				v += attackTargetRate[i];
				if(r < v)
				{
					return i + 1;
				}
			}
			return 0;
		}
		
		/** 是否救援 */
		public bool GetIsRescue(float mhHpRate)
		{
			return Random.Range(0f, 99f) < (rescueRate + (1 - mhHpRate)) / 2f;
		}
		


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
			id =  csv.GetInt32(i ++ );
			name = csv.GetString( i ++);
			interval = csv.GetSingle( i ++);
			intervalRandom = csv.GetSingle( i ++);
			sendArmPercent = csv.GetSingle( i ++) / 100f;
			attackLevel = (AIAttackLevel) csv.GetInt32(i ++ );
			distanceScoreRate_Attack = csv.GetSingle(i ++ );
			attackBehitRate = csv.GetSingle(i ++ ) / 100f;

			int index = 3;
			while(index > 0)
			{
				index --;
				attackUnitRate.Add(csv.GetSingle( i ++));
			}

			index = 3;
			while(index > 0)
			{
				index --;
				attackTargetRate.Add(csv.GetSingle( i ++));
			}


			rescueRate = csv.GetSingle( i ++);
			distanceScoreRate_Rescue = csv.GetSingle(i ++ );
			
			index = 3;
			while(index > 0)
			{
				index --;
				rescueUnitRate.Add(csv.GetSingle( i ++));
			}

			uplevelLevel = (AIUplevelLevel) csv.GetInt32(i ++ );
			uplevelInterval = csv.GetSingle(i ++ );
			uplevelIntervalRandom = csv.GetSingle(i ++ );

			War.model.AddAIConfig(this);
//			Debug.Log(this);
		}
		
//		public override string ToString ()
//		{
//			return string.Format ("[BuildCasernConfig: id={0},  avatarId={1}]", id, avatarId);
//		}
		
	}
	
}


