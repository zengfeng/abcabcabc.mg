using System;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.PB;
namespace CC.Runtime
{
	public partial class PacketManager
	{
		private void InitialCS()
		{
			RegisterCS<C_EnterGame_0x100>();
			RegisterCS<C_ReConnect_0x101>();
			RegisterCS<C_ChangeName_0x102>();
			RegisterCS<C_EnterFight_0x104>();
			RegisterCS<C_ChangeHeadIcon_0x105>();
			RegisterCS<C_PacketTest_0x110>();
			RegisterCS<C_UpdateGuideStep_0x118>();
			RegisterCS<C_RecordSubGuideStep_0x119>();
			RegisterCS<C_GetRoleDisplayInfo_0x120>();
			RegisterCS<C_ExchangeCdkey_0x1050>();
			RegisterCS<C_GmCmd_0x1618>();
			RegisterCS<C_AttendMatcher_0x800>();
			RegisterCS<C_LeaveMatcher_0x801>();
			RegisterCS<C_BattleLoad_0x811>();
			RegisterCS<C_BattleLeave_0x813>();
			RegisterCS<C_SyncSendArm_0x820>();
			RegisterCS<C_SyncProp_0x821>();
			RegisterCS<C_SyncSkill_0x822>();
			RegisterCS<C_AttackBuild_0x823>();
			RegisterCS<C_SyncUplevel_0x825>();
			RegisterCS<C_SyncTurret_0x826>();
			RegisterCS<C_SyncBuild_0x827>();
			RegisterCS<C_SyncHeroBackstage_0x828>();
			RegisterCS<C_BattleEnd_0x830>();
			RegisterCS<C_UploadBattleVideo_0x550>();
			RegisterCS<C_GetEliteVideoList_0x551>();
			RegisterCS<C_ViewBattleVideo_0x552>();
			RegisterCS<C_ViewSelfVideo_0x553>();
		}
		private void InitialSC()
		{
			RegisterSC<S_EnterGame_0x100>();
			RegisterSC<S_ReConnect_0x101>();
			RegisterSC<S_ChangeName_0x102>();
			RegisterSC<S_KickOut_0x103>();
			RegisterSC<S_EnterFight_0x104>();
			RegisterSC<S_ChangeHeadIcon_0x105>();
			RegisterSC<S_PacketTest_0x110>();
			RegisterSC<S_UpdateGuideStep_0x118>();
			RegisterSC<S_RecordSubGuideStep_0x119>();
			RegisterSC<S_GetRoleDisPlayInfo_0x120>();
			RegisterSC<S_RewardInfoNotify_0x150>();
			RegisterSC<S_RoleBaseInfoNotify_0x151>();
			RegisterSC<S_ExchangeCdkey_0x1050>();
			RegisterSC<S_GmCmd_0x1618>();
			RegisterSC<S_AttendMatcher_0x800>();
			RegisterSC<S_LeaveMatcher_0x801>();
			RegisterSC<S_PvPMatched_0x802>();
			RegisterSC<S_BattleRoomPrepare_0x810>();
			RegisterSC<S_BattleLoad_0x811>();
			RegisterSC<S_BattleStart_0x812>();
			RegisterSC<S_BattleLeave_0x813>();
			RegisterSC<S_SyncSendArm_0x820>();
			RegisterSC<S_SyncProp_0x821>();
			RegisterSC<S_SyncSkill_0x822>();
			RegisterSC<S_SyncUplevel_0x825>();
			RegisterSC<S_SyncTurret_0x826>();
			RegisterSC<S_SyncBuild_0x827>();
			RegisterSC<S_SyncHeroBackstage_0x828>();
			RegisterSC<S_BattleEnd_0x830>();
			RegisterSC<S_UploadBattleVideo_0x550>();
			RegisterSC<S_GetEliteVideoList_0x551>();
			RegisterSC<S_ViewBattleVideo_0x552>();
			RegisterSC<S_ViewSelfVideo_0x553>();
			RegisterSC<S_NewEliteVideoNotify_0x559>();
		}
		private void InitialTR()
		{
			RegisterTR<T_User_Login_0x8000>();
			RegisterTR<T_User_JoinGroup_0x8001>();
			RegisterTR<T_User_ChannelMsg_0x8002>();
			RegisterTR<T_User_ChannelReturn_0x8003>();
			RegisterTR<T_User_PersonalMsg_0x8004>();
			RegisterTR<T_User_PersonalReturn_0x8005>();
		}
		private void InitialRT()
		{
			RegisterRT<R_User_Login_0x8000>();
			RegisterRT<R_User_JoinGroup_0x8001>();
			RegisterRT<R_User_ChannelMsg_0x8002>();
			RegisterRT<R_User_PersonalMsg_0x8004>();
		}
	}
}
