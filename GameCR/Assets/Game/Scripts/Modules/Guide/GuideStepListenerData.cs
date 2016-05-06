using UnityEngine;
using System.Collections;

namespace Games.Guides
{
	/** 监听引导步奏数据 */
	public class GuideStepListenerData : GuideStepData
	{
		/** 监听类型 */
		public GuideListenerType listenerType;

		/** 延迟Exe时间 */
		public float delay = 0;


		/*--------  建筑被占领 --------*/
		/** 建筑ID，如果是-1表示任意 */
		public int buildOccupied_buildId = -1;
		/** 势力ID，如果是-1表示任意 */
		public int buildOccupied_legionId = -1;
		/** 阵营关系，如果是-1表示任意 */
		public int buildOccupied_relation = -1;
		/** 阵营关系相对势力ID */
		public int buildOccupied_relationLegionId = -1;


		/*--------  建筑被攻打 --------*/
		/** 建筑ID，如果是-1表示任意 */
		public int buildBehit_buildId = -1;
		/** 势力ID，如果是-1表示任意 */
		public int buildBehit_legionId = -1;
		/** 阵营关系，如果是-1表示任意 */
		public int buildBehit_relation = -1;
		/** 阵营关系相对势力ID */
		public int buildBehit_relationLegionId = -1;


		/** 攻击势力ID，如果是-1表示任意 */
		public int buildBehit_hit_legionId = -1;
		/** 攻击阵营关系，如果是-1表示任意 */
		public int buildBehit_hit_relation = -1;
		/** 攻击阵营关系相对势力ID */
		public int buildBehit_hit_relationLegionId = -1;



		/*--------  势力发兵了 --------*/

		/** 建筑ID，如果是-1表示任意 */
		public int sendArm_from_buildId = -1;
		/** 势力ID，如果是-1表示任意 */
		public int sendArm_from_legionId = -1;
		/** 阵营关系，如果是-1表示任意 */
		public int sendArm_from_relation = -1;
		/** 阵营关系相对势力ID */
		public int sendArm_from_relationLegionId = -1;


		/** 建筑ID，如果是-1表示任意 */
		public int sendArm_to_buildId = -1;
		/** 势力ID，如果是-1表示任意 */
		public int sendArm_to_legionId = -1;
		/** 阵营关系，如果是-1表示任意 */
		public int sendArm_to_relation = -1;
		/** 阵营关系相对势力ID */
		public int sendArm_to_relationLegionId = -1;


	
		public GuideStepListenerData SetListener_None()
		{

			listenerType = GuideListenerType.None;

			return this;
		}

		public GuideStepListenerData SetListener_BuildOccupied(int buildId = -1, int legionId = -1, int relation = -1, int relationLegionId = -1)
		{
			listenerType = GuideListenerType.BuildOccupied;
			buildOccupied_buildId = buildId;
			buildOccupied_legionId = legionId;
			buildOccupied_relation = relation;
			buildOccupied_relationLegionId = relationLegionId;

			return this;
		}




		public GuideStepListenerData SetListener_BuildBehit(int buildId = -1, int legionId = -1, int relation = -1, int relationLegionId = -1)
		{
			listenerType = GuideListenerType.BuildBehit;
			buildBehit_buildId = buildId;
			buildBehit_legionId = legionId;
			buildBehit_relation = relation;
			buildBehit_relationLegionId = relationLegionId;

			return this;

		}

		public GuideStepListenerData SetListener_BuildBehit_Hit(int hit_legionId = -1, int hit_relation = -1, int hit_relationLegionId = -1)
		{

			listenerType = GuideListenerType.BuildBehit;
			buildBehit_hit_legionId = hit_legionId;
			buildBehit_hit_relation = hit_relation;
			buildBehit_hit_relationLegionId = hit_relationLegionId;

			return this;
		}



		public GuideStepListenerData SetListener_SendArm_From(int buildId = -1, int legionId = -1, int relation = -1, int relationLegionId = -1)
		{
			listenerType = GuideListenerType.LegionSendArm;
			sendArm_from_buildId = buildId;
			sendArm_from_legionId = legionId;
			sendArm_from_relation = relation;
			sendArm_from_relationLegionId = relationLegionId;

			return this;
		}


		public GuideStepListenerData SetListener_SendArm_To(int buildId = -1, int legionId = -1, int relation = -1, int relationLegionId = -1)
		{
			listenerType = GuideListenerType.LegionSendArm;
			sendArm_to_buildId = buildId;
			sendArm_to_legionId = legionId;
			sendArm_to_relation = relation;
			sendArm_to_relationLegionId = relationLegionId;

			return this;
		}

		public GuideStepListenerData()
		{
			SetData (GuideStepType.War_Listener, "监听");
			SetCompleteType (GuideStepCompleteType.NextFrame);
		}

		public GuideStepListenerData(string describe)
		{
			SetData (GuideStepType.War_Listener, describe);
			SetCompleteType (GuideStepCompleteType.NextFrame);
		}

		public GuideStepListenerData SetDelay(float delay)
		{
			this.delay = delay;
			return this;
		}

	}
}