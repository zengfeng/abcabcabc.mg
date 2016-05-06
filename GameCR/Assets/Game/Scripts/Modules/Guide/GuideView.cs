using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Guides
{
	public class GuideView : MonoBehaviour 
	{
		/** 移动面板 */
		public GuideMoveToPanel				moveToPanel;
		/** 点击手 */
		public GuidePointHanld				pointHanldPanel;

		/** 美女教师 */
		public GuideTeacherView 			teacher;

		/** 引导遮罩 */
		public GuideScreenMask 				screenMask;
		
		/** 引导遮罩 */
		public AbstractGuidePanelView 		mask;
		/** 引导遮罩 */
		public AbstractGuidePanelView 		clickScreenNextStep;

		/** TopBar */
		public AbstractGuidePanelView		topBar;

		/** 技能UI */
		public AbstractGuidePanelView		skillLevel;
		/** 发兵百分比设置UI */
		public AbstractGuidePanelView		sendArmSettingPanel;
		
		/** 引导介绍面板--箭塔 */
		public AbstractGuidePanelView		introducePanel_Turret;
		/** 引导介绍面板--士气 */
		public AbstractGuidePanelView		introducePanel_LegionLevel;
		/** 引导介绍面板--技能 */
		public AbstractGuidePanelView		introducePanel_Skill;

		/** 引导介绍面板--士气--fly */
		public GuideLegionLevelFly			legionLevelFly;
		/** 引导介绍面板--技能--fly */
		public GuideSkillFly				skillFly;
		public GuideHeroCardPanel			cardPanel;

		public GuideSkillButtonDrag 		useSkill;
		public GuideSkillButtonDragToCircle 		useSkillDragToCircle;

		public Dictionary<GuidePanelID, AbstractGuidePanelView> panelDict = new Dictionary<GuidePanelID, AbstractGuidePanelView>();

		void Start()
		{
			Guide.view = this;
			
			panelDict.Add(GuidePanelID.Guide_PointHanld, pointHanldPanel);
			panelDict.Add(GuidePanelID.Guide_Mask, mask);
			panelDict.Add(GuidePanelID.Guide_ClickScreenNext, clickScreenNextStep);

			panelDict.Add(GuidePanelID.War_TopBar, topBar);
			panelDict.Add(GuidePanelID.War_Skill, skillLevel);
			panelDict.Add(GuidePanelID.War_SendArmSettingPanel, sendArmSettingPanel);



			panelDict.Add(GuidePanelID.GuideIntroducePanel_Turret, introducePanel_Turret);
			panelDict.Add(GuidePanelID.GuideIntroducePanel_LegionLevel, introducePanel_LegionLevel);
			panelDict.Add(GuidePanelID.GuideIntroducePanel_Skill, introducePanel_Skill);
		}


		public void HidePanel(GuidePanelID panelId)
		{
			if(panelDict.ContainsKey(panelId)) panelDict[panelId].Hide();
		}

		
		public void ShowPanel(GuidePanelID panelId)
		{
			if(panelDict.ContainsKey(panelId)) panelDict[panelId].Show();
		}


		/** 点击手 */
		public void SetHanld(GuidePointHanld.HanldType hanldType, Vector2 anchorPos)
		{
			pointHanldPanel.Set(hanldType, anchorPos);
			pointHanldPanel.gameObject.SetActive(true);
		}

		public void SetHanldWorld(GuidePointHanld.HanldType hanldType, Vector3 position)
		{
			pointHanldPanel.SetWorld(hanldType, position);
		}

		public void CloseHanld()
		{
			pointHanldPanel.gameObject.SetActive(false);
		}

	}
}