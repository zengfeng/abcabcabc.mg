using UnityEngine;
using System.Collections;
using CC.Runtime;
using CC.Runtime.PB;
using SimpleFramework;
using Games.Cores;
using System.Collections.Generic;
using Games.Module.Props;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	public class WarService : Service 
	{

		public static float PROP_FLOAT_MULTIPLIER = 1000;
		
		public static void PropToProtoPropInfoList(float[] props, List<ProtoPropInfo> list)
		{
			for(int i = 0; i < props.Length; i ++)
			{
				if(props[i] != 0)
				{
					ProtoPropInfo prop = new ProtoPropInfo();
					prop.id = i;
					prop.value = (int)(props[i] * WarService.PROP_FLOAT_MULTIPLIER);
					list.Add(prop);
				}
			}
		}
		
		public static void PropToProtoPropInfoList(Prop[] props, List<ProtoPropInfo> list)
		{
			foreach(Prop item in props)
			{
				if(item.value != 0)
				{
					ProtoPropInfo prop = new ProtoPropInfo();
					prop.id = item.id;
					prop.value =  (int)(item.value * WarService.PROP_FLOAT_MULTIPLIER); 
					list.Add(prop);
				}
			}
		}
		
		public static Prop[] ProtoPropInfoToPropList(List<ProtoPropInfo> props)
		{
			List<Prop> list = new List<Prop>();
			foreach(ProtoPropInfo item in props)
			{
				list.Add(Prop.CreateInstance(item.id, item.value / WarService.PROP_FLOAT_MULTIPLIER));
			}
			return list.ToArray();
		}



		public static S_SyncSkill_0x822 To__S_SyncSkill_0x822(C_SyncSkill_0x822 c)
		{
			S_SyncSkill_0x822 msg = new S_SyncSkill_0x822 ();
			msg.uid 		= c.uid;
			msg.skill_id 	= c.skill_id;
			msg.skill_id_2 	= c.skill_id_2;
			msg.src_id 		= c.src_id;

			for(int i = 0; i < c.skill_effect_item.Count; i ++)
			{
				msg.skill_effect_item.Add (c.skill_effect_item[i]);
			}


			for(int i = 0; i < c.skill2_effect_item.Count; i ++)
			{
				msg.skill2_effect_item.Add (c.skill2_effect_item[i]);
			}

			return msg;
		}
		
		public int backMenuId;
		public int stageId;
		public int roomId;
		public int roleId;
		public int ownLegionId;

		public WarService()
		{
			AddStoC();
		}

		public void AddStoC()
		{

			if(packetManager == null) return;
			
			/** 战斗开始 */
			packetManager.AddCallback<S_BattleStart_0x812>(S_BattleStart_0x812);
			
			
			/** 反馈--战斗退出 */
			packetManager.AddCallback<S_BattleLeave_0x813>(S_BattleLeave_0x813);
			/** 反馈--战斗结束 */
			packetManager.AddCallback<S_BattleEnd_0x830>(S_BattleEnd_0x830);



			//--------------------------------
			// 加载同步
			//--------------------------------
			
			/** 加载进度 */
			packetManager.AddCallback<S_BattleLoad_0x811>(S_BattleLoad_0x811);






			
			//--------------------------------
			// 战斗同步
			//--------------------------------

			/** 发兵 */
			packetManager.AddCallback<S_SyncSendArm_0x820>(S_SyncSendArm_0x820);
			/** 属性 */
			packetManager.AddCallback<S_SyncProp_0x821>(S_SyncProp_0x821);
			/** 放技能 */
			packetManager.AddCallback<S_SyncSkill_0x822>(S_SyncSkill_0x822);
			/** 建筑升级 */
			packetManager.AddCallback<S_SyncUplevel_0x825>(S_SyncUplevel_0x825);
			/** 箭塔攻击 */
			packetManager.AddCallback<S_SyncTurret_0x826>(S_SyncTurret_0x826);
			/** 同步建筑势力ID切换 */
			packetManager.AddCallback<S_SyncBuild_0x827>(S_SyncBuild_0x827);
			/** 同步英雄下阵 */
			packetManager.AddCallback<S_SyncHeroBackstage_0x828>(S_SyncHeroBackstage_0x828);


		}
		

		/** 战斗开始 */
		public void S_BattleStart_0x812(S_BattleStart_0x812 msg)
		{
			War.OnReadyPVP();
		}

		/** 发送--引导步骤 */
		public void C_RecordSubGuideStep_0x119(int stepIndex)
		{	
			if (War.isTest)
				return;
			
			C_RecordSubGuideStep_0x119 msg = new C_RecordSubGuideStep_0x119();
			msg.sub_step = stepIndex;
			packetManager.SendMessage<C_RecordSubGuideStep_0x119>(SocketId.Main, msg);

		}
		#region 退出
		/** 发送--战斗退出 */
		public void C_BattleLeave_0x813()
		{
			if(War.realPlayerCount <= 1)
			{
				War.Over(OverType.Lose);
				return;
			}


			C_BattleLeave_0x813 msg = new C_BattleLeave_0x813();
			msg.battle_room_id = War.scene.buildList.Count;
			packetManager.SendMessage<C_BattleLeave_0x813>(SocketId.Battle, msg);
		}
		
		
		/** 反馈--战斗退出 */
		void S_BattleLeave_0x813(S_BattleLeave_0x813 msg)
		{
			LegionData legionData = War.GetLegionDataByRoleId (msg.role_id);
			if (legionData != null)
			{
				if(War.textEffect != null) War.textEffect.Play (TextEffectType.Normal, string.Format ("{0}离开", legionData.name), Color.white, new Vector3 (0, 0, 0), 0);

				if (War.GetLegionDataByRoleId (msg.role_id).legionId == War.mainLegionID) {
					if (War.mainLegionID != War.ownLegionID) {
						War.mainLegionID = War.ownLegionID;
					}
				}
			}
		}
		
		
		
		/** 发送--战斗结束 */
		public void C_BattleEnd_0x830(List<ProtoRoleFightResult> result)
		{
			C_BattleEnd_0x830 msg = new C_BattleEnd_0x830();
			foreach(ProtoRoleFightResult item in result)
			{
				msg.result.Add(item);
			}

			packetManager.SendMessage<C_BattleEnd_0x830>(SocketId.Battle, msg);
		}
		
		
		/** 反馈--战斗结束 */
		void S_BattleEnd_0x830(S_BattleEnd_0x830 msg)
		{
			War.endProto = msg;
			WarOverData overData = new WarOverData();

			foreach(ProtoRoleFightResult info in msg.fight_result)
			{
				LegionData legionData = War.GetLegionDataByRoleId(info.roleId);

				WarOverLegionData result = new WarOverLegionData();
				result.roleId = info.roleId;
				result.legionId = legionData.legionId;
				result.starCount = info.star;
				result.buildCount = info.build_count;
				result.buildTotal = info.build_total;
				result.overType = (OverType) info.end_type;

				if(result.legionId == War.ownLegionID)
				{
					overData.overType = result.overType;
				}

				overData.legionDatas.Add(result);
			}

			War.S_Over(overData);
		}


		/** 发送--上传视频 */
		public void C_UploadBattleVideo_0x550(ProtoBattleVideoInfo videoInfo, int upload_type, int roleId)
		{

			C_UploadBattleVideo_0x550 msg = new C_UploadBattleVideo_0x550();
			msg.upload_type = upload_type;  // 1.公会分享   2.精选上传   99.私人上传
			msg.share_video = new ProtoShareVideoInfo ();
			msg.share_video.share_roleId = roleId != -1 ? roleId :    War.ownLegionData != null ? War.ownLegionData.roleId : 0;
			msg.share_video.video = videoInfo;
			videoInfo.share_time = DateTimeUtils.CurrentTimestamp;

			packetManager.SendMessage<C_UploadBattleVideo_0x550>(SocketId.Main, msg);
		}
		
		#endregion

		
		#region 加载同步
		public void C_LoadProgress(float progress)
		{
			C_BattleLoad_0x811(Mathf.FloorToInt(progress * 100));
		}


		private float _loadTime = 0;
		/** 加载进度 */
		public void C_BattleLoad_0x811(int progress)
		{
			if(progress < 100 && Time.time - _loadTime < 0.5f)
			{
				return;
			}

			if(progress >= 100)
			{
				Debug.Log("progress=" + progress);
			}

			_loadTime = Time.time;

			C_BattleLoad_0x811 msg = new C_BattleLoad_0x811();
			msg.progress = progress;
			packetManager.SendMessage<C_BattleLoad_0x811>(SocketId.Battle, msg);
		}

		/** 加载进度 */
		void S_BattleLoad_0x811(S_BattleLoad_0x811 msg)
		{
			
		}
		#endregion





		#region 战斗同步

		/** 发兵 */
		public void C_SyncSendArm_0x820(int from, int to, int count, int idBegin)
		{
			C_SyncSendArm_0x820 msg = new C_SyncSendArm_0x820();
			msg.from = from;
			msg.to = to;
			msg.count = count;
			msg.uid_begin = idBegin;
			Debug.Log(string.Format("C_SyncSendArm_0x820  from={0}, to={1}, count={2}, uid_begin={3}", msg.from, msg.to, msg.count, msg.uid_begin));

			if(War.isSendSynchrService)
			{
				packetManager.SendMessage<C_SyncSendArm_0x820>(SocketId.Battle, msg);
			}
			else
			{
				War.exe.ExeSendArm(from, to, count, idBegin);
			}

//			//TODO test
//			S_SyncSendArm_0x820 msg0x608 = new S_SyncSendArm_0x820();
//			msg0x608.from = from;
//			msg0x608.to = to;
//			msg0x608.count = count;
//			msg0x608.uid_begin = idBegin;
//			S_SyncSendArm_0x820(msg0x608);

		}

		void S_SyncSendArm_0x820(S_SyncSendArm_0x820 msg)
		{
			if(!War.isGameing) return;
			Debug.Log(string.Format("S_SyncSendArm_0x820  from={0}, to={1}, count={2}, uid_begin={3}", msg.from, msg.to, msg.count, msg.uid_begin));

			if (sendArmUid.ContainsKey (msg.uid_begin)) 
			{
				if(Application.isEditor)
				{
					Debug.LogError ("发兵 收到相同的包 msg.uid_begin=" + msg.uid_begin);
				}
				return;
			}
			
			sendArmUid.Add (msg.uid_begin, true);

			War.exe.ExeSendArm(msg.from, msg.to, msg.count, msg.uid_begin);
		}


		
		/** 属性 */
		public void C_SyncProp_0x821(List<ProtoFightUnitInfo> unitProps)
		{
			if(!War.isSendSynchrService)
			{
				return;
			}

			C_SyncProp_0x821 msg = new C_SyncProp_0x821();
			foreach(ProtoFightUnitInfo item in unitProps)
			{
				msg.unit_props.Add(item);
			}
			packetManager.SendMessage<C_SyncProp_0x821>(SocketId.Battle, msg);


//			// TODO test
//			S_SyncProp_0x821 msg0x609 = new S_SyncProp_0x821();
//			foreach(ProtoFightUnitInfo item in unitProps)
//			{
//				msg0x609.unit_props.Add(item);
//			}
//			S_SyncProp_0x821(msg0x609);
		}
		
		void S_SyncProp_0x821(S_SyncProp_0x821 msg)
		{
			if(!War.isGameing) return;
			if(War.isMainLegion) return;
			War.exe.ExeProp(msg.unit_props);
		}
		
		/** 放技能 */
        public void C_SyncSkill_0x822(C_SyncSkill_0x822 msg)
		{
            Debug.LogFormat("<color=yellow> =====send pvp use skill :{0} room:{1}====", msg.skill_id, roomId);
			packetManager.SendMessage<C_SyncSkill_0x822>(SocketId.Battle, msg);

            //Debug.Log(string.Format("C_SyncSkill_0x822 msg.skill_id={0},  position={1}, msg.position={2}, msg.unit_id={3}", msg.skill_id, position, msg.position, msg.unit_id.ToStr ()) );

		}
		
		void S_SyncSkill_0x822(S_SyncSkill_0x822 msg)
		{
			Debug.LogFormat("<color=yellow> =====receive pvp use skill :{0}====</color>", msg.skill_id);
			if(!War.isGameing) return;
            War.skillWarManager.DealSkillForPvp(msg);
		}



		/** 建筑升级 */
		public void C_SyncUplevel_0x825(int buildId, int level, float time)
		{
			if(!War.isSendSynchrService)
			{
				War.exe.ExeUplevel(buildId, level, time);
				return;
			}
			
			C_SyncUplevel_0x825 msg = new C_SyncUplevel_0x825();
			msg.build_id = buildId;
			msg.level = level;
			msg.time = Mathf.CeilToInt(time * 1000);

			packetManager.SendMessage<C_SyncUplevel_0x825>(SocketId.Battle, msg);
		
		}
		
		void S_SyncUplevel_0x825(S_SyncUplevel_0x825 msg)
		{
			if(!War.isGameing) return;
			War.exe.ExeUplevel(msg.build_id, msg.level, msg.time / 1000);
		}

		
		
		/** 箭塔攻击 */
		public void C_SyncTurret_0x826(int buildId, int soliderId)
		{
			if(!War.isSendSynchrService)
			{
				War.exe.ExeTurret(buildId, soliderId);
				return;
			}
			
			C_SyncTurret_0x826 msg = new C_SyncTurret_0x826();
			msg.build_id = buildId;
			msg.solider_id = soliderId;
			
			packetManager.SendMessage<C_SyncTurret_0x826>(SocketId.Battle, msg);
			
		}
		
		void S_SyncTurret_0x826(S_SyncTurret_0x826 msg)
		{
			if(!War.isGameing) return;
			War.exe.ExeTurret(msg.build_id, msg.solider_id);
		}

		
		
		/** 同步建筑势力ID切换 */
		public void C_SyncBuild_0x827(int buildId, int legionId)
		{
			if(!War.isSendSynchrService)
			{
				War.exe.ExeBuildChangeLegion(buildId, legionId);
				return;
			}

//			Debug.Log("buildId=" + buildId + "  legionId=" + legionId);
			
			C_SyncBuild_0x827 msg = new C_SyncBuild_0x827();
			msg.build_id = buildId;
			msg.legion_id = legionId;
			
			packetManager.SendMessage<C_SyncBuild_0x827>(SocketId.Battle, msg);
			
		}
		
		void S_SyncBuild_0x827(S_SyncBuild_0x827 msg)
		{
			//			Debug.Log("msg.build_id=" + msg.build_id + "  msg.legion_id=" + msg.legion_id);
			if(!War.isGameing) return;
			War.exe.ExeBuildChangeLegion(msg.build_id, msg.legion_id);
		}



		/** 同步英雄下阵 */
		public void C_SyncHeroBackstage_0x828(int heroUid, int targetLegionId)
		{
			if(!War.isSendSynchrService)
			{
				War.exe.ExeHeroBackstag(heroUid, targetLegionId);
				return;
			}
			
			C_SyncHeroBackstage_0x828 msg = new C_SyncHeroBackstage_0x828();
			msg.hero_uid = heroUid;
			msg.target_legion_id = targetLegionId;
			
			packetManager.SendMessage<C_SyncHeroBackstage_0x828>(SocketId.Battle, msg);
			
		}
		
		void S_SyncHeroBackstage_0x828(S_SyncHeroBackstage_0x828 msg)
		{
			//			Debug.Log("msg.hero_uid=" + msg.hero_uid + "  msg.target_legion_id=" + msg.target_legion_id);
			if(!War.isGameing) return;
			War.exe.ExeHeroBackstag(msg.hero_uid, msg.target_legion_id);
		}


		#endregion



		public Dictionary<int, bool> sendArmUid = new Dictionary<int, bool>();

		public void Clear()
		{
			sendArmUid.Clear ();
		}

	}
}
