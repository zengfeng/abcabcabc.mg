using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Games.Module.Wars
{

	
	/** 势力联盟数据 */
	public class LegionGroupData
	{
		/** 联盟ID */
		public int id;
		/** 联盟势力列表 */
		public Dictionary<int, LegionData> dict = new Dictionary<int, LegionData>(); 
		
		public LegionGroupData(int groupId)
		{
			id = groupId;
		}
		
		/** 联盟添加势力 */
		public void AddLegion(LegionData legionData)
		{
			dict.Add(legionData.legionId, legionData);
			legionData.group = this;
		}
		
		/** 目标势力是否和自己是同盟 */
		public bool IsOnceGroup(int team)
		{
			return dict.ContainsKey(team);
		}
	}
}