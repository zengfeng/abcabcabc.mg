using UnityEngine;
using System.Collections;
using CC.Runtime.PB;
using System.Collections.Generic;
using ProtoBuf;
using System.IO;
using Games.Cores;
using CC.Runtime.Utils;
using System;

namespace Games.Module.Wars
{

	[ProtoContract]
	public class WarRecordIOInfo
	{
		private int _lastId = 1;
		[ProtoMember(1)]
		public int lastId 
		{
			get 
			{
				return _lastId;
			}

			set 
			{
				_lastId = value;
			}
		}

		private List<int> _ids = new List<int>();
		[ProtoMember(2)]
		public List<int> ids
		{
			get 
			{
				return _ids;
			}

			set
			{ 
				_ids = value;
			}
		}

		[ProtoMember(3)]
		public int lastVersion { get; set;}

		internal int MaxNum = 10;

		public int GetNewId()
		{
			return lastId++;
		}

		public void Add(int newId)
		{
			_ids.Add (newId);
		}

		public int Count
		{
			get 
			{
				return _ids.Count;
			}
		}

		public void Clear()
		{
			_ids.Clear ();
		}

		public byte[] GetBytes()
		{
			MemoryStream memStream = new MemoryStream (500);
			Serializer.Serialize(memStream, this);

			byte[] bytes = new byte[(int)memStream.Length];
			memStream.Position = 0;
			memStream.Read (bytes, 0, (int)memStream.Length);
			memStream.Dispose ();

			return bytes;
		}


		public static WarRecordIOInfo Create(byte[] bytes)
		{
			MemoryStream memStream = new MemoryStream (500);
			memStream.Position = 0;
			memStream.Write (bytes, 0, bytes.Length);

			memStream.Position = 0;
			WarRecordIOInfo info = Serializer.Deserialize<WarRecordIOInfo>(memStream);
			memStream.Dispose ();
			return info;
		}




	}
	
	public class WarRecordIO 
	{
		private WarRecordIOInfo _info;
		internal WarRecordIOInfo info
		{
			get 
			{
				if (_info == null)
				{
					_info = Goo.save.record.LoadInfo();
					if (!War.GetVersionCompatible (_info.lastVersion)) 
					{
						Clear ();
					}

					_info.lastVersion = War.version;
				} 

				return _info;
			}
		}

		public void Save(WarOverData overData)
		{
			if (War.recordManager == null) return;
			
			War.recordManager.timeLineData.overData = overData;
			War.recordManager.timeLineData.enterData = War.enterData;
			byte[] videoData = War.recordManager.timeLineData.GetBytes ();

			ProtoBattleVideoInfo video = new ProtoBattleVideoInfo ();
			video.war_version = War.version;
			video.stageId = War.enterData.stageId;
			video.video_data = videoData;
			video.create_time = DateTimeUtils.CurrentTimestamp;
			GenerateProtoBattleVideoRoleInfoList(overData, video.fight_roles);

			Goo.save.record.SaveVideo (video, info);

			Debug.Log ("War.endProto.video_type=" + War.endProto.video_type + " 视频类型: 0.普通视频   1.精选视频 ");

			// 视频类型: 0.普通视频   1.精选视频
			if (War.endProto != null && War.endProto.video_type == 1)
			{
				// 1.公会分享   2.精选上传   99.私人上传
				Upload (video, 2, -1);
			}
		}

		public ProtoBattleVideoInfo GetVideo(int id)
		{
			return Goo.save.record.LoadVideo (id);
		}

		/// <summary>
		/// 上传视频
		/// </summary>
		/// <param name="id">视频ID.</param>
		/// <param name="uploadType">上传类型 : 1.公会分享   2.精选上传   99.私人上传.</param>
		/// <param name="roleId">上传玩家ID.</param>
		public void Upload(int id, int uploadType, int roleId)
		{
			ProtoBattleVideoInfo video = GetVideo(id);
			Upload (video, uploadType, roleId);
		}

		public void Upload(ProtoBattleVideoInfo data, int uploadType, int roleId)
		{
			if (roleId == -1 && War.ownLegionData != null) 
			{
				roleId = War.ownLegionData.roleId;
			}
			Goo.save.record.Upload (data, uploadType, roleId);
		}

		public List<ProtoBattleVideoInfo> GetList()
		{
			return Goo.save.record.LoadVideoList (info);
		}

		public void SetWatchCount(int id, int count)
		{
			Goo.save.record.SetWatchCount (id, count);
		}

		public void Delete(int id)
		{
			Goo.save.record.DeleteVide (id, info);
		}

		public void Clear()
		{
			if (_info != null) 
			{
				_info.Clear ();
			}
			Goo.save.record.Clear();
		}


		void GenerateProtoBattleVideoRoleInfoList(WarOverData overData, List<ProtoBattleVideoRoleInfo> fight_roles)
		{
			Dictionary<int, ProtoFightRoleInfo> fightRoleInfoDict = new Dictionary<int, ProtoFightRoleInfo> ();
			int ownChangePrize = 0;
			if (War.endProto != null) 
			{
				foreach(ProtoFightRoleInfo roleInfo in War.endProto.fight_roles)
				{
					Debug.Log ("roleInfo.role_info.roleId=" + roleInfo.role_info.roleId);
					fightRoleInfoDict.Add (roleInfo.role_info.roleId, roleInfo);
				}

				ownChangePrize = War.endProto.prize - fightRoleInfoDict [War.ownLegionData.roleId].role_info.prize;
			}

			foreach(WarOverLegionData overLegionData in overData.legionDatas)
			{
				WarEnterLegionData enterLegionData = overData.enterData.GetEnterLegionData (overLegionData.legionId);

				if (enterLegionData == null) 
				{
					Debug.LogFormat ("<color=red>生成录像信息时 legionId={0} enterLegionData=null</color>", overLegionData.legionId);
					continue;
				}

				ProtoBattleVideoRoleInfo videoRole = new ProtoBattleVideoRoleInfo ();
				videoRole.end_type = (int)overLegionData.overType;
				videoRole.final_house = overLegionData.buildCount;
				videoRole.final_star = overLegionData.starCount;
				videoRole.change_prize = enterLegionData.legionId == War.ownLegionID ? ownChangePrize : -ownChangePrize;

				if (fightRoleInfoDict.ContainsKey (enterLegionData.roleId))
				{
					ProtoFightRoleInfo protoFightRoleInfo = fightRoleInfoDict [enterLegionData.roleId];
					videoRole.role_info = protoFightRoleInfo.role_info;
					videoRole.battle_info = protoFightRoleInfo.battle_info;
					videoRole.league_info = protoFightRoleInfo.league_info;
					videoRole.rank = protoFightRoleInfo.rank;

					protoFightRoleInfo.role_info.name = enterLegionData.name;
				}
				else
				{


					ProtoRoleBaseInfo roleBase = videoRole.role_info = new ProtoRoleBaseInfo ();
					roleBase.roleId = enterLegionData.roleId;
					roleBase.name = enterLegionData.name;
					roleBase.icon = enterLegionData.headAvatarId;



					ProtoRoleBattleInfo roleBattle = videoRole.battle_info = new ProtoRoleBattleInfo ();
					roleBattle.battle_soldier = enterLegionData.solider.avatarId;
					foreach (WarEnterHeroData enterHeroData in enterLegionData.heroList) 
					{
						ProtoCardInfo card = new ProtoCardInfo ();
						card.card_id = enterHeroData.heroId;
						card.level = enterHeroData.level;

						roleBattle.battle_cards.Add (card);
					}
				}

				fight_roles.Add (videoRole);
			}
		}



	}

}