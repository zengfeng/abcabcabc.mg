
using CC.Runtime;
using System.Collections.Generic;
using ProtoBuf;

namespace Games.Module.Wars
{
	/** 战斗结束势力数据 */
	[ProtoContract]
	public class WarOverLegionData
	{
		/** 角色ID */
		[ProtoMember(1)]
		public int roleId  { get; set; }
		/** 势力ID */
		[ProtoMember(2)]
		public int legionId  { get; set; }
		/** 获取的星星数量 */
		[ProtoMember(3)]
		public int starCount  { get; set; }
		/** 建筑数量 */
		[ProtoMember(4)]
		public int buildCount  { get; set; }
		/** 建筑总数 */
		[ProtoMember(5)]
		public int buildTotal  { get; set; }
		/**  是否胜利 */
		[ProtoMember(6)]
		public OverType overType  { get; set; }
	}


	[ProtoContract]
	public class WarOverData : IData
	{
		/** 是否是录像 */
		public bool isRecord = false;

		/**  是否胜利 */
		[ProtoMember(1)]
		public OverType overType { get; set; }
		/** 关卡ID */
		[ProtoMember(2)]
		public int stageId { get; set; }
		/** 对战模式 */
		[ProtoMember(3)]
		public VSMode vsmode { get; set; }
		/** 游戏时间 */
		[ProtoMember(4)]
		public int  time { get; set; }
		/** 是否超时 */
		[ProtoMember(5)]
		public bool isOverTime { get; set; }


		private List<WarOverLegionData> _legionDatas = new List<WarOverLegionData>();
		[ProtoMember(6)]
		public List<WarOverLegionData> legionDatas
		{ 
			get 
			{
				return _legionDatas;
			}

			set 
			{
				_legionDatas = value;
			}
		}

        public WarEnterData enterData;
	}
}