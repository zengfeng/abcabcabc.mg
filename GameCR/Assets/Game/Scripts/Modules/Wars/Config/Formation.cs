using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	/** 英雄阵型位置 */
	public class FormationPosition
	{
		/** 兵营ID */
		public int index;
		/** 英雄ID */
		public int heroId;

		public int test_skillId;
        public int test_skillLevel;

        public int test_skillId2;
        public int test_skillLevel2;

		public FormationPosition()
		{
		}
		
		public FormationPosition(int index, int heroId)
		{
			this.index = index;
			this.heroId = heroId;
		}

		
		public FormationPosition(int index, int heroId, int test_skillId, int test_skillLevel, int test_skillId2, int test_skillLevel2)
		{
			this.index = index;
			this.heroId = heroId;
			this.test_skillId = test_skillId;
			this.test_skillLevel = test_skillLevel;


            this.test_skillId2 = test_skillId2;
            this.test_skillLevel2 = test_skillLevel2;
		}


	}

	/** 英雄上阵数据 */
	public class Formation 
	{
		/** 玩家ID */
		public int roldId;
		/** 玩家势力ID */
		public int legionId;
		/** 英雄位置列表 */
		public List<FormationPosition> positions = new List<FormationPosition>();

		public Formation()
		{
		}

		public Formation(int legionId)
		{
			this.legionId = legionId;
			this.positions = new List<FormationPosition> ();
		}
		
		public Formation(int legionId, int roldId)
		{
			this.legionId = legionId;
			this.roldId = roldId;
			this.positions = new List<FormationPosition> ();
		}


	}
}