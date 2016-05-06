using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Games.Guides
{
	public class GuideActionManager
	{
		/** 处理器配置 */
		private Dictionary<GuideStepType, Type> _actionConfig;
		public Dictionary<GuideStepType, Type> actionConfig
		{
			get
			{
				if(_actionConfig == null)
				{
					_actionConfig = new Dictionary<GuideStepType, Type>();
					/** 空 */
					_actionConfig.Add(GuideStepType.Empty, typeof(GuideStepAction));

					/** 开始--引导 */
					_actionConfig.Add(GuideStepType.Begin_Guide, typeof(GuideStepAction_BeginGuide));
					/** 结束--引导 */
					_actionConfig.Add(GuideStepType.End_Guide, typeof(GuideStepAction_EndGuide));


					/** 锁定强制--引导 */
					_actionConfig.Add(GuideStepType.Loack_Guide, typeof(GuideStepAction_LoackGuide));
					/** 解锁引导--引导 */
					_actionConfig.Add(GuideStepType.Unloack_Guide, typeof(GuideStepAction_UnloackGuide));


					/** 模块 */
					_actionConfig.Add(GuideStepType.Module, typeof(GuideModuleAction));
					
					/** 暂停游戏 */
					_actionConfig.Add(GuideStepType.War_Pause, typeof(GuideStepAction_War_Simple));
					/** 播放游戏 */
					_actionConfig.Add(GuideStepType.War_Play, typeof(GuideStepAction_War_Simple));

					/** 打开美女对话面板 */
					_actionConfig.Add(GuideStepType.War_OpenTeacherPanel, typeof(GuideStepAction_War_Simple));
					/** 关闭美女对话面板 */
					_actionConfig.Add(GuideStepType.War_CloseTeacherPanel, typeof(GuideStepAction_War_Simple));
					/** 设置美女对话内容 */
					_actionConfig.Add(GuideStepType.War_SetTeacherSay, typeof(GuideStepAction_War_Teacher));

					
					/** 打开面板 */
					_actionConfig.Add(GuideStepType.War_OpenPanel, typeof(GuideStepAction_War_Panel));
					/** 关闭面板 */
					_actionConfig.Add(GuideStepType.War_ClosePanel, typeof(GuideStepAction_War_Panel));

					
					/** 发兵 */
					_actionConfig.Add(GuideStepType.War_SendArm, typeof(GuideStepAction_War_SendArm));
					/** 升级 */
					_actionConfig.Add(GuideStepType.War_Uplevel, typeof(GuideStepAction_War_Uplevel));
					/** 执行发兵 */
					_actionConfig.Add(GuideStepType.War_ExeSendArm, typeof(GuideStepAction_War_ExeSendArm));
					/** 冻结士兵 */
					_actionConfig.Add(GuideStepType.War_FreezedSolider, typeof(GuideStepAction_War_FreezedSolider));
					/** 解除冻结士兵 */
					_actionConfig.Add(GuideStepType.War_CloseFreezedSolider, typeof(GuideStepAction_War_CloseFreezedSolider));

					/** 士气等级飞到目标位置 */
					_actionConfig.Add(GuideStepType.War_LegionLevel_Fly, typeof(GuideStepAction_War_Simple));
					/** 技能盒飞到目标位置 */
					_actionConfig.Add(GuideStepType.War_Skill_Fly, typeof(GuideStepAction_War_Simple));
					
					/** 卡牌飞入屏幕 */
					_actionConfig.Add(GuideStepType.War_Card_Fly_Screen, typeof(GuideStepAction_War_Simple));
					/** 卡牌飞入技能盒 */
					_actionConfig.Add(GuideStepType.War_Card_Fly_SkillBox, typeof(GuideStepAction_War_Simple));


					/** 设置生产一个技能 */
					_actionConfig.Add(GuideStepType.War_Skill_SetProduce, typeof(GuideStepAction_War_SetProduceSkill));
					/** 快速生产一个技能 */
					_actionConfig.Add(GuideStepType.War_Skill_Produce, typeof(GuideStepAction_War_ProduceSkill));
					/** 拖动技能A到建筑B */
					_actionConfig.Add(GuideStepType.War_Skill_Use_DragToBuild, typeof(GuideStepAction_War_UseSkill));
					/** 拖动技能A到到区域 */
					_actionConfig.Add(GuideStepType.War_Skill_Use_DragToCircle, typeof(GuideStepAction_War_UseSkillDragToCircle));

					/** 监听--执行释放技能 */
					_actionConfig.Add (GuideStepType.War_Listener_ExeUseSkill, typeof(GuideStepListenerAction_War_ExeUseSkill));


					/** 监听 */
					_actionConfig.Add (GuideStepType.War_Listener, typeof(GuideStepListenerAction));

					/** 屏幕遮罩--绘制 */
					_actionConfig.Add (GuideStepType.War_ScreenMask_Draw, typeof(GuideStepAction_War_ScreenMaskDraw));

				}
				return _actionConfig;
			}
		}

		public Type GetActionType(GuideStepData stepData)
		{
			switch(stepData.stepType)
			{
			case GuideStepType.Group:
				GuideGroupData groupData = (GuideGroupData) stepData;
				switch(groupData.groupType)
				{
				case GuideGroupType.Sequence:
					return typeof(GuideSequenceGroupAction);
					break;
				case GuideGroupType.Parallel:
					return typeof(GuideParallelGroupAction);
					break;
				}
				break;
			}

			if(actionConfig.ContainsKey(stepData.stepType))
			{
				return actionConfig[stepData.stepType];
			}
			else
			{
				return typeof(GuideStepAction);
			}
		}
		


		public GuideStepAction CreateAction(GuideStepData stepData)
		{
			Type type = GetActionType(stepData);
			return (GuideStepAction) Guide.go.AddComponent(type);
		}

	}
}