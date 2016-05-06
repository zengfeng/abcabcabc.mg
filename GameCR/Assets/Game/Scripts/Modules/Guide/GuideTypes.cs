using UnityEngine;
using System.Collections;

namespace Games.Guides
{

	/** 锁定等级 */
	public enum GuideScreenMaskDrawType
	{
		[HelpAttribute("绘制建筑")]
		Build,
		[HelpAttribute("绘制发兵")]
		SendArm,
		[HelpAttribute("在一个位置绘制圆")]
		Position,
		[HelpAttribute("重新绘制并显示")]
		ResetAndShow,
		[HelpAttribute("隐藏")]
		Hide,
	}

	/** 锁定等级 */
	public enum GuideLoackLevel
	{
		[HelpAttribute("所有")]
		All,
		[HelpAttribute("时间")]
		Time,
		[HelpAttribute("生产技能")]
		ProduceSkill,
		[HelpAttribute("产兵")]
		Produce,
		[HelpAttribute("AI所有行为")]
		AI,
		[HelpAttribute("手动操作")]
		Hanld,
		[HelpAttribute("AI技能")]
		AI_Skill,
		[HelpAttribute("AI升级")]
		AI_Uplevel,
		[HelpAttribute("AI出兵")]
		AI_SendArm,
	}


	/** 监听类型 */
	public enum GuideListenerType
	{
		None,
		[HelpAttribute("建筑被占领")]
		BuildOccupied,
		[HelpAttribute("建筑被攻打")]
		BuildBehit,
		[HelpAttribute("势力发兵了")]
		LegionSendArm,
	}


	/** 面板ID */
	public enum GuidePanelID
	{
		[HelpAttribute("点击手")]
		Guide_PointHanld,
		[HelpAttribute("引导遮罩")]
		Guide_Mask,
		[HelpAttribute("点击屏幕下一步")]
		Guide_ClickScreenNext,

		[HelpAttribute("引导介绍面板--箭塔")]
		GuideIntroducePanel_Turret,
		[HelpAttribute("引导介绍面板--士气")]
		GuideIntroducePanel_LegionLevel,
		[HelpAttribute("引导介绍面板--技能")]
		GuideIntroducePanel_Skill,

		[HelpAttribute("士气UI")]
		War_TopBar,
		[HelpAttribute("技能UI")]
		War_Skill,
		[HelpAttribute("发兵百分比设置UI")]
		War_SendArmSettingPanel,
	}



	/** 组类型 */
	public enum GuideGroupType
	{
		[HelpAttribute("顺序")]
		Sequence,
		[HelpAttribute("并列")]
		Parallel,
	}

	/** 步骤完成类型 */
	public enum GuideStepCompleteType
	{
		[HelpAttribute("需要调用完成")]
		Call,
		[HelpAttribute("点击屏幕")]
		ClickScreenCall,
		[HelpAttribute("立即")]
		Immediately,
		[HelpAttribute("下一帧")]
		NextFrame,
		[HelpAttribute("等待时间")]
		WaitSecond,
		[HelpAttribute("点击屏幕 Or 等待时间")]
        ClickScreenCall_Ro_WaitSecond,
    }


	/** 步骤类型 */
	public enum GuideStepType
	{
		[HelpAttribute("空")]
		Empty,

		[HelpAttribute("模块")]
		Module,
		[HelpAttribute("组")]
		Group,


		[HelpAttribute("开始--引导")]
		Begin_Guide,
		[HelpAttribute("结束--引导")]
		End_Guide,

		[HelpAttribute("锁定强制--引导")]
		Loack_Guide,
		[HelpAttribute("解锁强制--引导")]
		Unloack_Guide,

		[HelpAttribute("结束--组")]
		End_Group,
		[HelpAttribute("结束--模块")]
		End_Module,

		[HelpAttribute("暂停游戏")]
		War_Pause,
		[HelpAttribute("播放游戏")]
		War_Play,

		[HelpAttribute("打开面板")]
		War_OpenPanel,
		[HelpAttribute("关闭面板")]
		War_ClosePanel,

		[HelpAttribute("打开美女对话面板")]
		War_OpenTeacherPanel,
		[HelpAttribute("关闭美女对话面板")]
		War_CloseTeacherPanel,
		[HelpAttribute("设置美女对话内容")]
		War_SetTeacherSay,


		[HelpAttribute("发兵")]
		War_SendArm,
		[HelpAttribute("升级")]
		War_Uplevel,
		[HelpAttribute("执行发兵")]
		War_ExeSendArm,
		[HelpAttribute("冻结士兵")]
		War_FreezedSolider,
		[HelpAttribute("解除冻结士兵")]
		War_CloseFreezedSolider,


		[HelpAttribute("隐藏势力等级")]
		War_LegionLevel_Hide,
		[HelpAttribute("显示势力等级")]
		War_LegionLevel_Show,
		[HelpAttribute("士气等级飞到目标位置")]
		War_LegionLevel_Fly,
		


		[HelpAttribute("隐藏技能")]
		War_Skill_Hide,
		[HelpAttribute("显示技能")]
		War_Skill_Show,
		[HelpAttribute("技能盒飞到目标位置")]
		War_Skill_Fly,



		[HelpAttribute("卡牌飞入屏幕")]
		War_Card_Fly_Screen,
		[HelpAttribute("卡牌飞入技能盒")]
		War_Card_Fly_SkillBox,


		

		[HelpAttribute("设置生产一个技能")]
		War_Skill_SetProduce,
		[HelpAttribute("快速生产一个技能")]
		War_Skill_Produce,
		[HelpAttribute("拖动技能A到建筑B")]
		War_Skill_Use_DragToBuild,
		[HelpAttribute("拖动技能A到到区域")]
		War_Skill_Use_DragToCircle,


		[HelpAttribute("监听")]
		War_Listener,

		[HelpAttribute("监听--执行发兵")]
		War_Listener_ExeSendArm,
		[HelpAttribute("监听--执行释放技能")]
		War_Listener_ExeUseSkill,

		[HelpAttribute("屏幕遮罩--绘制")]
		War_ScreenMask_Draw,

	}
}