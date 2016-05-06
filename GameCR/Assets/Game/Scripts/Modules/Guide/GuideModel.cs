using UnityEngine;
using System.Collections;
using Games.Module.Wars;
using System.Collections.Generic;

namespace Games.Guides
{
	public class GuideModel 
	{

		public GuideModuleData GetStageData(int id)
		{
			int level = id + 1;
			if(level < 6)
			{
				if(War.sceneData != null) War.sceneData.visiableLegionLevelMsg = false;
			}

			if(level == 1)
			{
				if(War.sceneData != null) War.sceneData.enableUplevel = false;
			}

			switch(level)
			{
			case 1:
				return GenerateStage_1();
				break;
			case 2:
				return GenerateStage_2();
				break;
			case 3:
				return GenerateStage_3();
				break;
			case 4:
				return GenerateStage_4();
				break;
			case 5:
				return GenerateStage_5();
				break;
			case 6:
				return GenerateStage_6();
				break;
			case 7:
				return GenerateStage_7();
				break;

			}


			return null;
		}


		public List<string> GetCsv()
		{
			string head1 = "ID;步骤索引;描述;步骤类型;完成类型;完成等待时间";
			string head2 = "ID;stepIndex;describe;stepType;completeType;completeWaitSecond";

			List<string> list = new List<string> ();
			list.Add (head1);
			list.Add (head2);

			for(int i = 0; i < 7; i ++)
			{
				GuideModuleData data = GetStageData(i);
				data.GetCsv (data.moduleId, list);
			}

			return list;
		}



		public float openTeacherTime = 0.3f;
		public float openCardFlyTime = 0.3f;

		/** 生成关卡引导数据--1发兵 */
		public GuideModuleData GenerateStage_1()
		{
			GuideModuleData moduleData = new GuideModuleData(1 , "引导阵营颜色,发兵");

			moduleData.Add(new GuideStepData(GuideStepType.Begin_Guide, GuideStepCompleteType.NextFrame, "开始引导"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_TopBar, GuideStepType.War_ClosePanel, "关闭势力等级UI"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_Skill, GuideStepType.War_ClosePanel, "关闭技能UI"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_SendArmSettingPanel, GuideStepType.War_ClosePanel, "关闭 发兵百分比设置UI"));
			moduleData.Add(new GuideStepData(GuideStepType.War_Pause, GuideStepCompleteType.NextFrame, "暂停战斗"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_Mask, GuideStepType.War_OpenPanel, "打开引导遮罩"));
			moduleData.Add(new GuideStepData(GuideStepType.War_OpenTeacherPanel, GuideStepCompleteType.WaitSecond, openTeacherTime, "打开美女对话面板"));
			
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_ClickScreenNext, GuideStepType.War_OpenPanel, "打开点击屏幕下一步"));
			moduleData.Add(new GuideStepData_TeacherSay("我方为<color=#D30000FF>红色</color>！\n敌方为<color=#0059D3FF>蓝色</color>！", GuideStepCompleteType.ClickScreenCall_Ro_WaitSecond, 3f));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_ClickScreenNext, GuideStepType.War_ClosePanel, "关闭点击屏幕下一步"));
			moduleData.Add(new GuideStepData_TeacherSay("出击！占领敌方城池！", GuideStepCompleteType.NextFrame));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_Mask, GuideStepType.War_ClosePanel, "关闭引导遮罩"));
			moduleData.Add(new GuideStepData(GuideStepType.War_Play, GuideStepCompleteType.NextFrame, "播放游戏"));

			moduleData.Add(new GuideStepData_SendArm(1, 2, "发兵1->2"));
			//			moduleData.Add(new GuideStepData(GuideStepType.Empty,  GuideStepCompleteType.WaitSecond, 8, "空"));
			moduleData.Add(new GuideStepData(GuideStepType.War_CloseTeacherPanel, GuideStepCompleteType.NextFrame, "关闭美女对话面板"));
			moduleData.Add(new GuideStepListenerData("监听 2被攻占").SetListener_BuildOccupied(2));
			moduleData.Add(new GuideStepData(GuideStepType.War_OpenTeacherPanel, GuideStepCompleteType.WaitSecond, openTeacherTime, "打开美女对话面板"));
			moduleData.Add(new GuideStepData_TeacherSay("主公,干得漂亮！", GuideStepCompleteType.NextFrame));
			moduleData.Add(new GuideStepData(GuideStepType.Empty,  GuideStepCompleteType.WaitSecond, 2, "空"));
			moduleData.Add(new GuideStepData_TeacherSay("继续攻占敌军主基地！", GuideStepCompleteType.NextFrame));
			moduleData.Add(new GuideStepData_SendArm(2, 3, "发兵2->3"));
			moduleData.Add(new GuideStepData(GuideStepType.War_CloseTeacherPanel, GuideStepCompleteType.NextFrame, "关闭美女对话面板"));
			moduleData.Add(new GuideStepData(GuideStepType.End_Guide, GuideStepCompleteType.NextFrame, "结束引导"));
			moduleData.Init();
			return moduleData;
		}

		/** 生成关卡引导数据--2占领野城,升级 */
		public GuideModuleData GenerateStage_2()
		{
			GuideModuleData moduleData = new GuideModuleData(2 , "占领野城,升级");

			moduleData.Add(new GuideStepData(GuideStepType.Begin_Guide, GuideStepCompleteType.NextFrame, "开始引导"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_TopBar, GuideStepType.War_ClosePanel, "关闭势力等级UI"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_Skill, GuideStepType.War_ClosePanel, "关闭技能UI"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_SendArmSettingPanel, GuideStepType.War_ClosePanel, "关闭 发兵百分比设置UI"));

			moduleData.Add(new GuideStepData(GuideStepType.War_OpenTeacherPanel, GuideStepCompleteType.WaitSecond, openTeacherTime, "打开美女对话面板"));
			moduleData.Add(new GuideStepData_TeacherSay("灰色为<color=#FF9D0BFF>中立</color>建筑，主公可以优先占领！", GuideStepCompleteType.WaitSecond, 1f));
			moduleData.Add(new GuideStepData_SendArm(5, 3, "发兵5->3"));
			moduleData.Add(new GuideStepData(GuideStepType.War_CloseTeacherPanel, GuideStepCompleteType.NextFrame, "关闭美女对话面板"));
			moduleData.Add(new GuideStepData_LoackGuide(0.GLLTime(true).GLLProduce(true), GuideStepType.Unloack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));


			moduleData.Add(new GuideStepListenerData("监听 3被攻占").SetListener_BuildOccupied(3).SetDelay(1));


			moduleData.Add(new GuideStepData_LoackGuide(0.GLLTime(true).GLLProduce(true), GuideStepType.Loack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));
			moduleData.Add(new GuideStepData(GuideStepType.War_OpenTeacherPanel, GuideStepCompleteType.WaitSecond, openTeacherTime, "打开美女对话面板"));
			moduleData.Add(new GuideStepData_TeacherSay("\"双击\"有<color=#63B24FFF>箭头</color>的兵营可以\n<color=#FF9D0BFF>升级</color>！提升造兵速度！", GuideStepCompleteType.WaitSecond, 1f));
			
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_PointHanld, GuideStepType.War_OpenPanel, "打开点击手"));
			moduleData.Add(new GuideStepData_Uplevel(3));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_PointHanld, GuideStepType.War_ClosePanel, "关闭点击手"));

			moduleData.Add(new GuideStepData(GuideStepType.War_CloseTeacherPanel, GuideStepCompleteType.NextFrame, "关闭美女对话面板"));
			moduleData.Add(new GuideStepData_LoackGuide(0.GLLHanld(true).GLLProduce(true).GLLTime(true), GuideStepType.Unloack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));


			moduleData.Add(new GuideStepData(GuideStepType.Empty,  GuideStepCompleteType.WaitSecond, 2f, "空--等待时间"));
			moduleData.Add(new GuideStepData_ExeSendArm(1, 2, 8, "敌方执行发兵1->2"));
//			moduleData.Add(new GuideStepData(GuideStepType.Empty,  GuideStepCompleteType.WaitSecond, 3f, "空--等待时间"));
//			moduleData.Add(new GuideStepData_SendArm(3, 4, "发兵3->4"));
////			moduleData.Add(new GuideStepData(GuideStepType.Empty,  GuideStepCompleteType.WaitSecond, 5f, "空--等待时间"));
//			moduleData.Add(new GuideStepData_ExeSendArm(1, 4, -1, "敌方执行发兵1->4"));
//			moduleData.Add(new GuideStepData_ExeSendArm(2, 4, -1, "敌方执行发兵2->4"));
//			moduleData.Add(new GuideStepData(GuideStepType.Empty,  GuideStepCompleteType.WaitSecond, 3f, "空--等待时间"));

			moduleData.Add(new GuideStepData(GuideStepType.End_Guide, GuideStepCompleteType.NextFrame, "结束引导"));
			moduleData.Init();
			return moduleData;
		}

		
		
		/** 生成关卡引导数据--3箭塔 */
		public GuideModuleData GenerateStage_3()
		{
			GuideModuleData moduleData = new GuideModuleData(3 , "箭塔");

			moduleData.Add(new GuideStepData(GuideStepType.Begin_Guide, GuideStepCompleteType.NextFrame, "开始引导"));

			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_TopBar, GuideStepType.War_ClosePanel, "关闭势力等级UI"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_Skill, GuideStepType.War_ClosePanel, "关闭技能UI"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_SendArmSettingPanel, GuideStepType.War_ClosePanel, "关闭 发兵百分比设置UI"));
			moduleData.Add(new GuideStepData(GuideStepType.War_Pause, GuideStepCompleteType.NextFrame, "暂停战斗"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_Mask, GuideStepType.War_OpenPanel, "打开引导遮罩"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_ClickScreenNext, GuideStepType.War_OpenPanel, "打开点击屏幕下一步"));

			moduleData.Add(new GuideStepData_Panel(GuidePanelID.GuideIntroducePanel_Turret, GuideStepType.War_OpenPanel, GuideStepCompleteType.ClickScreenCall, "打开 引导介绍面板--箭塔"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.GuideIntroducePanel_Turret, GuideStepType.War_ClosePanel, GuideStepCompleteType.WaitSecond, 0.5f,  "关闭 引导介绍面板--箭塔"));

			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_ClickScreenNext, GuideStepType.War_ClosePanel, "关闭点击屏幕下一步"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_Mask, GuideStepType.War_ClosePanel, "关闭引导遮罩"));
			moduleData.Add(new GuideStepData(GuideStepType.War_Play, GuideStepCompleteType.NextFrame, "播放游戏"));

			moduleData.Add(new GuideStepData(GuideStepType.War_OpenTeacherPanel, GuideStepCompleteType.WaitSecond, openTeacherTime, "打开美女对话面板"));
			moduleData.Add(new GuideStepData_TeacherSay("出击! 攻占<color=#FF9D0BFF>箭塔</color>", GuideStepCompleteType.NextFrame));
			moduleData.Add(new GuideStepData_SendArm(5, 1, "发兵5->1"));
			moduleData.Add(new GuideStepData(GuideStepType.War_CloseTeacherPanel, GuideStepCompleteType.NextFrame, "关闭美女对话面板"));
			moduleData.Add(new GuideStepData_LoackGuide(0.GLLHanld(true).GLLProduce(true).GLLTime(true), GuideStepType.Unloack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));


			moduleData.Add(new GuideStepListenerData("监听 1被攻占").SetListener_BuildOccupied(1));
			moduleData.Add(new GuideStepData_LoackGuide(0.GLLAll(true), GuideStepType.Unloack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));

			moduleData.Add(new GuideStepData(GuideStepType.War_OpenTeacherPanel, GuideStepCompleteType.WaitSecond, openTeacherTime, "打开美女对话面板"));
			moduleData.Add(new GuideStepData_TeacherSay("漂亮！升级建筑是胜利的诀窍", GuideStepCompleteType.WaitSecond, 3));
			moduleData.Add(new GuideStepData(GuideStepType.War_CloseTeacherPanel, GuideStepCompleteType.NextFrame, "关闭美女对话面板"));

			moduleData.Add(new GuideStepData(GuideStepType.End_Guide, GuideStepCompleteType.NextFrame, "结束引导"));
			moduleData.Init();
			return moduleData;
		}

		/** 生成关卡引导数据--4陆逊技能 */
		public GuideModuleData GenerateStage_4()
		{

			GuideModuleData moduleData = new GuideModuleData(4 , "陆逊技能");
			moduleData.Add(new GuideStepData(GuideStepType.Begin_Guide, GuideStepCompleteType.NextFrame, "开始引导"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_TopBar, GuideStepType.War_ClosePanel, "关闭势力等级UI"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_Skill, GuideStepType.War_ClosePanel, "关闭技能UI"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_SendArmSettingPanel, GuideStepType.War_ClosePanel, "关闭 发兵百分比设置UI"));
			moduleData.Add(new GuideStepData(GuideStepType.War_Pause, GuideStepCompleteType.NextFrame, "暂停战斗"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_Mask, GuideStepType.War_OpenPanel, "打开引导遮罩"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_ClickScreenNext, GuideStepType.War_OpenPanel, "打开点击屏幕下一步"));

			moduleData.Add(new GuideStepData_Panel(GuidePanelID.GuideIntroducePanel_Skill, GuideStepType.War_OpenPanel,  "打开 引导介绍面板--技能"));
			moduleData.Add(new GuideStepData(GuideStepType.Empty,  GuideStepCompleteType.ClickScreenCall, "空"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_Skill, GuideStepType.War_OpenPanel, "打开 技能UI"));
			moduleData.Add(new GuideStepData(GuideStepType.War_Skill_Fly,  GuideStepCompleteType.Call, "技能盒飞到目标位置"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.GuideIntroducePanel_Skill, GuideStepType.War_ClosePanel, GuideStepCompleteType.WaitSecond, 0.7f, "关闭 引导介绍面板--技能"));




			moduleData.Add(new GuideStepData(GuideStepType.War_Card_Fly_Screen,  GuideStepCompleteType.WaitSecond, openCardFlyTime, "卡牌飞入屏幕"));
			moduleData.Add(new GuideStepData(GuideStepType.War_OpenTeacherPanel, GuideStepCompleteType.WaitSecond, openTeacherTime, "打开美女对话面板"));

			int skillCount = War.ownLegionData == null ? 0 : War.ownLegionData.skillDatas.Count - 1;
			moduleData.Add(new GuideStepData_TeacherSay("本局可使用"+skillCount+"张<color=#FF9D0BFF>武将卡</color>", GuideStepCompleteType.ClickScreenCall));

			moduleData.Add(new GuideStepData(GuideStepType.War_Card_Fly_SkillBox,  GuideStepCompleteType.WaitSecond, 1f, "卡牌飞入技能盒"));

			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_ClickScreenNext, GuideStepType.War_ClosePanel, "关闭点击屏幕下一步"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_Mask, GuideStepType.War_ClosePanel, "关闭引导遮罩"));
			moduleData.Add(new GuideStepData(GuideStepType.War_Play, GuideStepCompleteType.NextFrame, "播放游戏"));

			moduleData.Add(new GuideStepData_TeacherSay("出击!", GuideStepCompleteType.NextFrame));
			moduleData.Add(new GuideStepData_SendArm(3, 1, "发兵3->1"));
			moduleData.Add(new GuideStepData(GuideStepType.War_CloseTeacherPanel, GuideStepCompleteType.NextFrame, "关闭美女对话面板"));
			moduleData.Add(new GuideStepData_LoackGuide(0.GLLTime(true).GLLProduce(true), GuideStepType.Unloack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));


			int skillId = 24;
			moduleData.Add(new GuideStepData_LoackGuide(0.GLLProduceSkill(true), GuideStepType.Unloack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));

			moduleData.Add(new GuideStepData_ProduceSkill(skillId, "快速生产一个技能"));


			moduleData.Add(new GuideStepData(GuideStepType.Empty,  GuideStepCompleteType.WaitSecond, 5f, "空--等待时间"));
			moduleData.Add(new GuideStepData_FreezedSolider(0.RAll(true), "冻结士兵"));

			moduleData.Add(new GuideStepData(GuideStepType.War_OpenTeacherPanel, GuideStepCompleteType.WaitSecond, openTeacherTime, "打开美女对话面板"));
			moduleData.Add(new GuideStepData_TeacherSay("使用<color=#FF9D0BFF>陆逊卡</color>可以击杀20名敌城士兵", GuideStepCompleteType.NextFrame));
			moduleData.Add(new GuideStepData_LoackGuide(0.GLLTime(true).GLLProduce(true), GuideStepType.Loack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));

			moduleData.Add(new GuideStepData_UseSkill(skillId, 1, "拖动技能A到建筑B"));
			moduleData.Add(new GuideStepData_CloseFreezedSolider(0.RAll(true), "解除冻结士兵"));
			moduleData.Add(new GuideStepData(GuideStepType.War_CloseTeacherPanel, GuideStepCompleteType.NextFrame, "关闭美女对话面板"));
			moduleData.Add(new GuideStepData_LoackGuide(0.GLLHanld(true).GLLProduce(true).GLLTime(true), GuideStepType.Unloack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));



			moduleData.Add(new GuideStepListenerData("监听 箭塔被攻占").SetListener_BuildOccupied(1).SetDelay(2));
			moduleData.Add(new GuideStepData_ExeSendArm(2, 3, -1, "敌方执行发兵2->3"));
			moduleData.Add(new GuideStepData(GuideStepType.Empty,  GuideStepCompleteType.WaitSecond, 2f, "空--等待时间"));
			moduleData.Add(new GuideStepData_LoackGuide(0.GLLHanld(true), GuideStepType.Unloack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));


			moduleData.Add(new GuideStepListenerData_ExeUseSkill(2, 331001, "监听--执行释放技能 -- 华佗").SetListener_SendArm_To(-1, 2));

			moduleData.Add(new GuideStepData(GuideStepType.Empty,  GuideStepCompleteType.WaitSecond, 5f, "空--等待时间"));

			moduleData.Add(new GuideStepData(GuideStepType.End_Guide, GuideStepCompleteType.NextFrame, "结束引导"));
			moduleData.Init();
			return moduleData;
		}
		
		
		/** 生成关卡引导数据--5攻打箭塔，使用华佗技能 */
		public GuideModuleData GenerateStage_5()
		{

			GuideModuleData moduleData = new GuideModuleData(5 , "攻打箭塔，使用华佗技能");
			moduleData.Add(new GuideStepData(GuideStepType.Begin_Guide, GuideStepCompleteType.NextFrame, "开始引导"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_TopBar, GuideStepType.War_ClosePanel, "关闭势力等级UI"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_SendArmSettingPanel, GuideStepType.War_ClosePanel, "关闭 发兵百分比设置UI"));
			moduleData.Add(new GuideStepData(GuideStepType.War_Pause, GuideStepCompleteType.NextFrame, "暂停战斗"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_Mask, GuideStepType.War_OpenPanel, "打开引导遮罩"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_ClickScreenNext, GuideStepType.War_OpenPanel, "打开点击屏幕下一步"));



			moduleData.Add(new GuideStepData(GuideStepType.War_Card_Fly_Screen,  GuideStepCompleteType.WaitSecond, openCardFlyTime, "卡牌飞入屏幕"));
			moduleData.Add(new GuideStepData(GuideStepType.War_OpenTeacherPanel, GuideStepCompleteType.WaitSecond, openTeacherTime, "打开美女对话面板"));

			int skillCount = War.ownLegionData == null ? 0 : War.ownLegionData.skillDatas.Count - 1;
			moduleData.Add(new GuideStepData_TeacherSay("本局可使用"+skillCount+"张<color=#FF9D0BFF>武将卡</color>", GuideStepCompleteType.ClickScreenCall));

			moduleData.Add(new GuideStepData(GuideStepType.War_Card_Fly_SkillBox,  GuideStepCompleteType.WaitSecond, 1f, "卡牌飞入技能盒"));
			moduleData.Add(new GuideStepData(GuideStepType.War_CloseTeacherPanel, GuideStepCompleteType.NextFrame, "关闭美女对话面板"));

			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_ClickScreenNext, GuideStepType.War_ClosePanel, "关闭点击屏幕下一步"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_Mask, GuideStepType.War_ClosePanel, "关闭引导遮罩"));
			moduleData.Add(new GuideStepData(GuideStepType.War_Play, GuideStepCompleteType.NextFrame, "播放游戏"));

			moduleData.Add (new GuideStepData_ScreenMaskDraw().ResetAndShow());
			moduleData.Add (new GuideStepData_ScreenMaskDraw().DrawBuild(1));
			moduleData.Add (new GuideStepData_ScreenMaskDraw().DrawBuild(4));
			moduleData.Add (new GuideStepData_ScreenMaskDraw().DrawBuild(3));

			moduleData.Add(new GuideStepData_ExeSendArm(1, 3, 14, "执行发兵1->3"));
			moduleData.Add(new GuideStepData_ExeSendArm(4, 3, 14, "执行发兵4->3"));

//			moduleData.Add(new GuideStepListenerData("监听 3被攻占打").SetListener_BuildBehit(3).SetDelay(0));
			moduleData.Add(new GuideStepData(GuideStepType.Empty,  GuideStepCompleteType.WaitSecond, 3f, "空--等待时间"));
			int skillId = 33;
			moduleData.Add(new GuideStepData_LoackGuide(0.GLLProduceSkill(true), GuideStepType.Unloack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));

			moduleData.Add(new GuideStepData_ProduceSkill(skillId, "快速生产一个技能"));
			moduleData.Add(new GuideStepData_FreezedSolider(0.RAll(true), "冻结士兵"));

			moduleData.Add(new GuideStepData_LoackGuide(0.GLLProduce(true).GLLTime(true), GuideStepType.Loack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));

			moduleData.Add(new GuideStepData(GuideStepType.War_OpenTeacherPanel, GuideStepCompleteType.WaitSecond, openTeacherTime, "打开美女对话面板"));
			moduleData.Add(new GuideStepData_TeacherSay("军情告急！使用<color=#FF9D0BFF>华佗卡</color>立即补充20名援兵！", GuideStepCompleteType.NextFrame));
			moduleData.Add(new GuideStepData_UseSkill(skillId, 3, "拖动技能A到建筑B"));
			moduleData.Add(new GuideStepData_CloseFreezedSolider(0.RAll(true), "解除冻结士兵"));

			moduleData.Add(new GuideStepData(GuideStepType.Empty,  GuideStepCompleteType.WaitSecond, 5f, "空--等待时间"));
			moduleData.Add(new GuideStepData_LoackGuide(0.GLLAll(true), GuideStepType.Unloack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));
			moduleData.Add(new GuideStepData_TeacherSay("成功抵御了敌军的攻击！", GuideStepCompleteType.WaitSecond, 2f));

			moduleData.Add(new GuideStepData(GuideStepType.War_CloseTeacherPanel, GuideStepCompleteType.NextFrame, "关闭美女对话面板"));
			
			moduleData.Add(new GuideStepData(GuideStepType.End_Guide, GuideStepCompleteType.NextFrame, "结束引导"));
			moduleData.Init();
			return moduleData;
		}
		
		
		/** 生成关卡引导数据--6攻打主城，使用范围技能 */
		public GuideModuleData GenerateStage_6()
		{

			GuideModuleData moduleData = new GuideModuleData(6 , "攻打主城，使用范围技能");
			moduleData.Add(new GuideStepData(GuideStepType.Begin_Guide, GuideStepCompleteType.NextFrame, "开始引导"));
//			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_TopBar, GuideStepType.War_ClosePanel, "关闭势力等级UI"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_SendArmSettingPanel, GuideStepType.War_ClosePanel, "关闭 发兵百分比设置UI"));
			moduleData.Add(new GuideStepData(GuideStepType.War_Pause, GuideStepCompleteType.NextFrame, "暂停战斗"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_Mask, GuideStepType.War_OpenPanel, "打开引导遮罩"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_ClickScreenNext, GuideStepType.War_OpenPanel, "打开点击屏幕下一步"));



			moduleData.Add(new GuideStepData(GuideStepType.War_Card_Fly_Screen,  GuideStepCompleteType.WaitSecond, openCardFlyTime, "卡牌飞入屏幕"));
			moduleData.Add(new GuideStepData(GuideStepType.War_OpenTeacherPanel, GuideStepCompleteType.WaitSecond, openTeacherTime, "打开美女对话面板"));

			int skillCount = War.ownLegionData == null ? 0 : War.ownLegionData.skillDatas.Count - 1;
			moduleData.Add(new GuideStepData_TeacherSay("本局可使用"+skillCount+"张<color=#FF9D0BFF>武将卡</color>", GuideStepCompleteType.ClickScreenCall));

			moduleData.Add(new GuideStepData(GuideStepType.War_Card_Fly_SkillBox,  GuideStepCompleteType.WaitSecond, 1f, "卡牌飞入技能盒"));
			moduleData.Add(new GuideStepData(GuideStepType.War_CloseTeacherPanel, GuideStepCompleteType.NextFrame, "关闭美女对话面板"));



			moduleData.Add(new GuideStepData_Panel(GuidePanelID.GuideIntroducePanel_LegionLevel, GuideStepType.War_OpenPanel,  "打开 引导介绍面板--士气"));
			moduleData.Add(new GuideStepData(GuideStepType.Empty,  GuideStepCompleteType.ClickScreenCall, "空"));
			moduleData.Add(new GuideStepData(GuideStepType.War_LegionLevel_Fly,  GuideStepCompleteType.Call, "士气等级飞到目标位置"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_TopBar, GuideStepType.War_OpenPanel, "打开势力等级UI"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.GuideIntroducePanel_LegionLevel, GuideStepType.War_ClosePanel, GuideStepCompleteType.NextFrame, "关闭 引导介绍面板--士气"));


			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_ClickScreenNext, GuideStepType.War_ClosePanel, "关闭点击屏幕下一步"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_Mask, GuideStepType.War_ClosePanel, "关闭引导遮罩"));
			moduleData.Add(new GuideStepData(GuideStepType.War_Play, GuideStepCompleteType.NextFrame, "播放游戏"));


			moduleData.Add(new GuideStepData(GuideStepType.War_OpenTeacherPanel, GuideStepCompleteType.WaitSecond, openTeacherTime, "打开美女对话面板"));
			moduleData.Add(new GuideStepData_TeacherSay("出兵！攻占敌军<color=#FF9D0BFF>主基地</color>！", GuideStepCompleteType.NextFrame));

			int to = Application.isPlaying ? War.GetLegionData(2).initUseSkillBuildId : -1;
			if (to == -1)
				to = 6;
			
			moduleData.Add(new GuideStepData_SendArm(6, to, "发兵6->" + to));
			moduleData.Add(new GuideStepData(GuideStepType.War_CloseTeacherPanel, GuideStepCompleteType.NextFrame, "关闭美女对话面板"));
			moduleData.Add(new GuideStepData_LoackGuide(0.GLLProduce(true).GLLTime(true), GuideStepType.Unloack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));


			moduleData.Add(new GuideStepListenerData("监听 箭塔被攻占").SetListener_BuildOccupied(to));

			moduleData.Add(new GuideStepData(GuideStepType.War_OpenTeacherPanel, GuideStepCompleteType.WaitSecond, openTeacherTime, "打开美女对话面板"));
			moduleData.Add(new GuideStepData_TeacherSay("斩杀了敌方主公，我军<color=#FF9D0BFF>士气</color>大大提升！", GuideStepCompleteType.NextFrame));
			moduleData.Add(new GuideStepData(GuideStepType.Empty,  GuideStepCompleteType.WaitSecond, 2f, "空--等待时间"));


			int skillId = 19;
			moduleData.Add(new GuideStepData_LoackGuide(0.GLLProduceSkill(true), GuideStepType.Unloack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));

			moduleData.Add(new GuideStepData_ProduceSkill(skillId, "快速生产一个技能"));
			moduleData.Add(new GuideStepData_LoackGuide(0.GLLHanld(true).GLLProduce(true).GLLTime(true), GuideStepType.Loack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));
//			moduleData.Add(new GuideStepData(GuideStepType.War_OpenTeacherPanel, GuideStepCompleteType.WaitSecond, openTeacherTime, "打开美女对话面板"));
			moduleData.Add(new GuideStepData_TeacherSay("派<color=#FF9D0BFF>诸葛亮</color>入驻，兵营等级上限+1", GuideStepCompleteType.NextFrame));

			moduleData.Add(new GuideStepData_UseSkill(skillId, 5, "拖动技能A到建筑B"));
			moduleData.Add(new GuideStepData(GuideStepType.War_CloseTeacherPanel, GuideStepCompleteType.NextFrame, "关闭美女对话面板"));
			moduleData.Add(new GuideStepData_LoackGuide(0.GLLHanld(true).GLLProduce(true).GLLTime(true), GuideStepType.Unloack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));


//
//			moduleData.Add(new GuideStepData_ExeSendArm(5, 6, -1, "执行发兵5->6"));
			moduleData.Add(new GuideStepData(GuideStepType.Empty,  GuideStepCompleteType.WaitSecond, 3f, "空--等待时间"));

			moduleData.Add(new GuideStepData(GuideStepType.End_Guide, GuideStepCompleteType.NextFrame, "结束引导"));


			moduleData.Init();
			return moduleData;


		}


		
		/** 生成关卡引导数据--7攻打据点，上阵改建技能 */
		public GuideModuleData GenerateStage_7()
		{

			int skillId = 32;

			GuideModuleData moduleData = new GuideModuleData(7 , "攻打据点，上阵改建技能");
			moduleData.Add(new GuideStepData(GuideStepType.Begin_Guide, GuideStepCompleteType.NextFrame, "开始引导"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.War_SendArmSettingPanel, GuideStepType.War_ClosePanel, "关闭 发兵百分比设置UI"));
			moduleData.Add(new GuideStepData(GuideStepType.War_Pause, GuideStepCompleteType.NextFrame, "暂停战斗"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_Mask, GuideStepType.War_OpenPanel, "打开引导遮罩"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_ClickScreenNext, GuideStepType.War_OpenPanel, "打开点击屏幕下一步"));










			moduleData.Add(new GuideStepData(GuideStepType.War_Card_Fly_Screen,  GuideStepCompleteType.WaitSecond, openCardFlyTime, "卡牌飞入屏幕"));
			moduleData.Add(new GuideStepData(GuideStepType.War_OpenTeacherPanel, GuideStepCompleteType.WaitSecond, openTeacherTime, "打开美女对话面板"));

			int skillCount = War.ownLegionData == null ? 0 : War.ownLegionData.skillDatas.Count - 1;
			moduleData.Add(new GuideStepData_TeacherSay("本局可使用"+skillCount+"张<color=#FF9D0BFF>武将卡</color>", GuideStepCompleteType.ClickScreenCall));
			moduleData.Add(new GuideStepData(GuideStepType.War_Card_Fly_SkillBox,  GuideStepCompleteType.WaitSecond, 1f, "卡牌飞入技能盒"));
			moduleData.Add(new GuideStepData(GuideStepType.War_CloseTeacherPanel, GuideStepCompleteType.NextFrame, "关闭美女对话面板"));


			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_ClickScreenNext, GuideStepType.War_ClosePanel, "关闭点击屏幕下一步"));
			moduleData.Add(new GuideStepData_Panel(GuidePanelID.Guide_Mask, GuideStepType.War_ClosePanel, "关闭引导遮罩"));
			moduleData.Add(new GuideStepData(GuideStepType.War_Play, GuideStepCompleteType.NextFrame, "播放游戏"));

			moduleData.Add(new GuideStepData_LoackGuide(0.GLLProduceSkill(true), GuideStepType.Unloack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));

			moduleData.Add(new GuideStepData_ProduceSkill(GuideStepType.War_Skill_SetProduce, GuideStepCompleteType.NextFrame, skillId, "设置生产一个技能"));

			moduleData.Add(new GuideStepData(GuideStepType.War_OpenTeacherPanel, GuideStepCompleteType.WaitSecond, openTeacherTime, "打开美女对话面板"));
			moduleData.Add(new GuideStepData_TeacherSay("出击！抢占<color=#FF9D0BFF>攻击据点</color>", GuideStepCompleteType.NextFrame));

			moduleData.Add(new GuideStepData_SendArm(1, 6, "发兵1->6"));
			moduleData.Add(new GuideStepData(GuideStepType.War_CloseTeacherPanel, GuideStepCompleteType.NextFrame, "关闭美女对话面板"));


//			moduleData.Add(new GuideStepData_LoackGuide(0.GLLHanld(true).GLLProduce(true).GLLTime(true), GuideStepType.Unloack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));


			moduleData.Add(new GuideStepListenerData("监听 攻打据点被占领").SetListener_BuildOccupied(6));
			moduleData.Add(new GuideStepData(GuideStepType.War_OpenTeacherPanel, GuideStepCompleteType.WaitSecond, openTeacherTime, "打开美女对话面板"));
			moduleData.Add(new GuideStepData_TeacherSay("我军<color=#FF9D0BFF>攻击</color>提升了", GuideStepCompleteType.NextFrame));
			moduleData.Add(new GuideStepData(GuideStepType.Empty,  GuideStepCompleteType.WaitSecond, 2f, "空--等待时间"));






			moduleData.Add (new GuideStepData_ScreenMaskDraw().ResetAndShow());
			moduleData.Add (new GuideStepData_ScreenMaskDraw().DrawBuild(8));
			moduleData.Add(new GuideStepData_ExeSendArm(8, 6, 32, "执行发兵8->6"));
			moduleData.Add(new GuideStepData(GuideStepType.Empty,  GuideStepCompleteType.WaitSecond, 3f, "空--等待时间"));
			moduleData.Add(new GuideStepData(GuideStepType.War_CloseTeacherPanel, GuideStepCompleteType.NextFrame, "关闭美女对话面板"));
			moduleData.Add(new GuideStepData_FreezedSolider(0.REnemy(true), "冻结士兵"));
			moduleData.Add(new GuideStepData_LoackGuide(0.GLLProduceSkill(true), GuideStepType.Unloack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));

			moduleData.Add(new GuideStepData_ProduceSkill(skillId, "快速生产一个技能"));
			moduleData.Add(new GuideStepData_LoackGuide(0.GLLProduce(true).GLLTime(true), GuideStepType.Loack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));
			moduleData.Add(new GuideStepData(GuideStepType.War_OpenTeacherPanel, GuideStepCompleteType.WaitSecond, openTeacherTime, "打开美女对话面板"));
			moduleData.Add(new GuideStepData_TeacherSay("使用<color=#FF9D0BFF>张角</color>可造成范围伤害", GuideStepCompleteType.NextFrame));
			moduleData.Add(new GuideStepData_UseSkillDragToCircle(skillId, 0.REnemy(true), 0.USolider(true), "拖动技能A到到区域"));
			moduleData.Add(new GuideStepData_CloseFreezedSolider(0.REnemy(true), "解除冻结士兵"));
			moduleData.Add(new GuideStepData(GuideStepType.War_CloseTeacherPanel, GuideStepCompleteType.NextFrame, "关闭美女对话面板"));

			moduleData.Add(new GuideStepData_LoackGuide(0.GLLHanld(true).GLLProduce(true).GLLTime(true), GuideStepType.Unloack_Guide, GuideStepCompleteType.NextFrame, "解锁强制--引导"));

			moduleData.Add(new GuideStepData(GuideStepType.Empty,  GuideStepCompleteType.WaitSecond, 5f, "空--等待时间"));





			moduleData.Add(new GuideStepData(GuideStepType.End_Guide, GuideStepCompleteType.NextFrame, "结束引导"));


			moduleData.Init();
			return moduleData;


		}


	}

}