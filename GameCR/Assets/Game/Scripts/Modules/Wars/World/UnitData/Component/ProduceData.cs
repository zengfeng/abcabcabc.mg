using UnityEngine;
using System.Collections;
using Games.Module.Props;

namespace Games.Module.Wars
{
	public class ProduceData : EData
	{
		public float[] levelMaxProduceSpeed = new float[]{10000F, 3F, 2F, 1F, 0.5F};
		public ProduceType produceType;
		public int propId = PropId.HpAdd;
		public float value = 1F;
		public float produceLimitNum = 0;

		public bool produceLimit
		{
			get
			{
				return unitData.legionData.produceLimit;
			}
		}


		public float time = 0;
		public float ProduceSpeed
		{
			get
			{
				return unitData.produceSpeed;
			}
		}
	}
}
