using UnityEngine;
using System.Collections;
using Games.Module.Wars;

namespace Games.Guides
{
	public class GuideStepAction_War_Simple : GuideStepAction
	{

		/** 进入 */
		public override void Enter ()
		{
			switch(data.stepType)
			{
				/** 暂停游戏 */
			case GuideStepType.War_Pause:
				War.Pause();
				break;
				/** 播放游戏 */
			case GuideStepType.War_Play:
				War.Play();
				break;

				
				/** 打开美女对话面板 */
			case GuideStepType.War_OpenTeacherPanel:
				Guide.view.teacher.Show();
				break;
				/** 关闭美女对话面板 */
			case GuideStepType.War_CloseTeacherPanel:
				Guide.view.teacher.Hide();
				break;

				
				/** 士气等级飞到目标位置 */
			case GuideStepType.War_LegionLevel_Fly:
				Guide.view.legionLevelFly.Play(this);
				break;
				/** 技能盒飞到目标位置 */
			case GuideStepType.War_Skill_Fly:
				Guide.view.skillFly.Play(this);
				break;
				
				/** 卡牌飞入屏幕 */
			case GuideStepType.War_Card_Fly_Screen:
				Guide.view.cardPanel.Init();
				Guide.view.cardPanel.FlyScreen(this);
				break;
				/** 卡牌飞入技能盒 */
			case GuideStepType.War_Card_Fly_SkillBox:
				Guide.view.cardPanel.FlyBox();
				break;
			}
			base.Enter ();
		}

	}
}