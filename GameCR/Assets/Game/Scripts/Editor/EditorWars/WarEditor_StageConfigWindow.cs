using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using Games.Module.Wars;
using CC.Runtime;
using Games;
using Games.Cores;
using Games.Module.Props;
using System;
using CC.Runtime.Utils;

namespace Game.Editors.Wars
{
	public class WarEditor_StageConfigWindow : EditorWindow {


		
		protected int[] 		stageType_ids 	= new int[]{};
		protected string[] 	stageType_names = new string[]{};

		
		protected int[]			legionType_ids 		= new int[]{};
		protected string[]		legionType_Names 	= new string[]{};


		protected int[]			win_ids 	= new int[]{};
		protected string[]		win_names 	= new string[]{};

		
		
		protected int[]			star_ids 	= new int[]{};
		protected string[]		star_names 	= new string[]{};
		
		
		
		protected int[]			playerNum_ids 		= new int[]{0, 1, 2, 3, 4, 5};
		protected string[]		playerNum_names 	= new string[]{"0个", "1个", "2个", "3个", "4个", "5个"};

		
		protected int[]			group_ids 		= new int[]{0, 1, 2, 3, 4};
		protected string[]		group_names 	= new string[]{"联盟0", "联盟1", "联盟2", "联盟3", "联盟4"};



		
		protected int[]			ai_ids 		= new int[]{};
		protected string[]		ai_names 	= new string[]{};




		protected bool		_isInit = false;


		protected void Init()
		{
//			if(_isInit) return;
//			_isInit = true;

			//---------- StageType --------------
			EnumUtil.GetValuesAndNames<StageType>(out stageType_ids, out stageType_names);
			
			//---------- LegionType --------------
			EnumUtil.GetValuesAndNames<LegionType>(out legionType_ids, out legionType_Names);


			//---------- win --------------
			win_ids 	= new int[War.model.winConfigs.Count + 1];
			win_names 	= new string[War.model.winConfigs.Count + 1];

			win_ids[0] 		= 0;
			win_names[0] 	= "不设置";

			int i = 1;
			foreach(var item in War.model.winConfigs)
			{
				win_ids[i] = item.Value.id;
				win_names[i] = string.Format("{0}  ({1})  {2}", item.Value.id, EnumUtil.GetName<WinType>(item.Value.winType) , item.Value.description);

				i ++;
			}

			
			//---------- star --------------
			star_ids 	= new int[War.model.starConfigs.Count + 1];
			star_names 	= new string[War.model.starConfigs.Count + 1];
			
			star_ids[0] 		= 0;
			star_names[0] 		= "不设置";
			
			i = 1;
			foreach(var item in War.model.starConfigs)
			{
				star_ids[i] = item.Value.id;
				star_names[i] = string.Format("{0}  {1}", item.Value.id,  item.Value.Description);
				
				i ++;
			}


			
			//---------- ai --------------
			ai_ids 		= new int[War.model.aiConfigs.Count + 1];
			ai_names 	= new string[War.model.aiConfigs.Count + 1];
			
			ai_ids[0] 		= 0;
			ai_names[0] 		= "不设置";
			
			i = 1;
			foreach(var item in War.model.aiConfigs)
			{
				ai_ids[i] = item.Value.id;
				ai_names[i] = string.Format("{0}  {1}  检测间隔={2},  出兵百分比={3},  {4}", item.Value.id,  item.Value.name, item.Value.interval, Mathf.CeilToInt(item.Value.sendArmPercent * 100), EnumUtil.GetName<AIAttackLevel>(item.Value.attackLevel));
				
				i ++;
			} 	

		}


		
		protected GUIStyle style_box_center;
		protected GUIStyle style_box;
		protected GUIStyle style_box_marginleft;
		protected GUIStyle style_label_toggle;
		protected GUIStyle style_label_IntPopup_color;

		
		protected GUIStyle style_box_legion;
		protected GUIStyle style_box_solider;
		protected GUIStyle style_box_heroIcon;

		
		protected GUIStyle style_label_id;
		protected GUIStyle style_label_name;
		protected GUIStyle style_label_line;

		protected void InitStyle()
		{
			style_box_center = new GUIStyle(EditorStyles.helpBox);
			style_box_center.margin = new RectOffset();
			style_box_center.alignment = TextAnchor.MiddleCenter;
			
			style_box_heroIcon = new GUIStyle(EditorStyles.helpBox);
			style_box_heroIcon.margin = new RectOffset();

			
			style_box_solider = new GUIStyle(EditorStyles.helpBox);
			style_box_solider.margin = new RectOffset(30, 0, 0, 20);

			style_box = new GUIStyle(EditorStyles.helpBox);
			style_box.margin = new RectOffset();

			
			
			style_box_legion = new GUIStyle(EditorStyles.helpBox);
			style_box_legion.margin = new RectOffset();
			style_box_legion.padding = new RectOffset(10, 10 ,10, 10);

			style_box_marginleft = new GUIStyle(EditorStyles.helpBox);
			style_box_marginleft.margin = new RectOffset();
			style_box_marginleft.margin.left = 30;
			style_box_marginleft.padding = new RectOffset(10, 10 ,10, 10);

			
			style_label_toggle = new GUIStyle(EditorStyles.boldLabel);
			style_label_toggle.alignment = TextAnchor.MiddleLeft;
			style_label_toggle.richText = true;

			style_label_IntPopup_color = new GUIStyle(EditorStyles.popup);
			style_label_IntPopup_color.richText = true;

			
			style_label_id = new GUIStyle(EditorStyles.label);
			style_label_id.alignment = TextAnchor.MiddleCenter;
			style_label_id.fontSize = 20;
			
			
			style_label_name = new GUIStyle(EditorStyles.boldLabel);
			style_label_name.alignment = TextAnchor.MiddleLeft;
			style_label_name.fontSize = 16;
			
			style_label_line = new GUIStyle(EditorStyles.label);
			style_label_line.alignment = TextAnchor.MiddleLeft;
		}
		
		protected void OnGUI ()
		{
			Init();
			InitStyle();

			if(!WarEditor.IsInEditeMode())
			{
				GUILayout.Space(20);
				if(GUILayout.Button("进入战斗编辑模式", GUILayout.MinHeight(100)))
				{
					WarEditor.InEditMode();
				}
			}
			else
			{
				OnGUI_Module();
			}
		}

		
		virtual public void OpenWindow()
		{
			
		}

		virtual protected void OnGUI_Module()
		{

		}


		
		public bool fold_base = true;
		public bool fold_legionList = true;
		public bool[] legion_toggles =  new bool[]{true, true, true, true, true};

		
		protected Vector2 scrollPos;


		protected int sourceId = -1;
		protected int id = -1;
		protected StageConfig _stageConfig;
		public bool visiable_SaveButton = false;

		virtual protected void OnIdChange(StageConfig stageConfig)
		{

		}

		protected void GUIHanlder(StageConfig stageConfig)
		{
			
			scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
			
			fold_base = EditorGUILayout.Foldout(fold_base, "基本配置");
			if (fold_base)
			{
				EditorGUILayout.BeginVertical(style_box_marginleft);

				if(id == -1 || _stageConfig != stageConfig)
				{
					sourceId = id = stageConfig.id;
					_stageConfig = stageConfig;
				}

				id = EditorGUILayout.IntField("编号", id);
				OnIdChange(stageConfig);


				
				stageConfig.name 			= EditorGUILayout.TextField("名称", 		stageConfig.name);
				
				GUILayout.Space(5);
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField("描述", GUILayout.Width(100));
				stageConfig.description 	= EditorGUILayout.TextArea(stageConfig.description, GUILayout.Height(50));
				EditorGUILayout.EndHorizontal();
				GUILayout.Space(5);

				stageConfig.type = (StageType) EditorGUILayout.IntPopup("关卡类型", (int) stageConfig.type, stageType_names, stageType_ids);
				
				stageConfig.level = EditorGUILayout.IntField("等级", stageConfig.level);
				stageConfig.nextStageId = EditorGUILayout.IntField("解锁关卡", stageConfig.nextStageId);
				stageConfig.dropId = EditorGUILayout.IntField("掉落", stageConfig.dropId);
				stageConfig.costStrength = EditorGUILayout.IntField("消耗体力", stageConfig.costStrength);

				stageConfig.time = EditorGUILayout.IntField("限时", (int)stageConfig.time);
				EditorGUILayout.ToggleLeft("限时", stageConfig.time > 0);
				
				stageConfig.showHP = EditorGUILayout.ToggleLeft("血条开关", stageConfig.showHP);
				stageConfig.sos = EditorGUILayout.ToggleLeft("求救提示", stageConfig.sos);
				stageConfig.neutralRoleLevel = EditorGUILayout.IntField("中立主公等级", stageConfig.neutralRoleLevel);
				stageConfig.winId = EditorGUILayout.IntPopup("胜利条件", stageConfig.winId, win_names, win_ids);

				GUILayout.Space(10);
				EditorGUILayout.LabelField("星级评价");
				EditorGUILayout.BeginVertical(style_box_marginleft);
				if(stageConfig.stars.Length < 3)
				{
					int[] tempStarts = stageConfig.stars;
					stageConfig.stars = new int[3];
					for(int i = 0; i < tempStarts.Length; i ++)
					{
						GUILayout.Space(3);
						stageConfig.stars[i] = tempStarts[i];
						GUILayout.Space(3);
					}
				}

				for(int i = 0; i < 3; i ++)
				{
					stageConfig.stars[i] = EditorGUILayout.IntPopup("星级评价1", stageConfig.stars[i], star_names, star_ids);
				}

				EditorGUILayout.EndVertical();
				GUILayout.Space(10);

				EditorGUILayout.EndVertical();

			}


			
			fold_legionList = EditorGUILayout.Foldout(fold_legionList, "势力列表");
			if (fold_legionList)
			{

				List<StageLegionConfig> legionList = new List<StageLegionConfig>();
				foreach(var legionKVP in stageConfig.legionDict)
				{
					legionList.Add(legionKVP.Value);
				}

				foreach(StageLegionConfig legionConfig in legionList)
				{
					GUILayout.Space(10);
					
					EditorGUILayout.BeginHorizontal();
					
					GUILayout.Space(30);
					if(GUILayout.Button("删除", style_box_center, GUILayout.Width(50), GUILayout.Height(30)))
					{
						stageConfig.legionDict.Remove(legionConfig.legionId);
					}

					EditorGUILayout.BeginVertical(style_box_legion);
					legion_toggles[legionConfig.legionId] = GUILayout.Toggle(legion_toggles[legionConfig.legionId], string.Format("<color={2}>势力{0} [{1}--{3}]</color>", legionConfig.legionId, WarColor.Names[legionConfig.color], WarColor.GetUnitHPColor(legionConfig.color).ToStr32(), EnumUtil.GetName<LegionType>(legionConfig.type) ), style_label_toggle, GUILayout.ExpandWidth(true), GUILayout.Height(30));
					if(legion_toggles[legionConfig.legionId])
					{
						legionConfig.color =  EditorGUILayout.IntPopup("颜色", legionConfig.color, WarColor.Names, WarColor.IDs, style_label_IntPopup_color);

						if(legionConfig.color != legionConfig.legionId)
						{
							if(stageConfig.legionDict.ContainsKey(legionConfig.color))
							{
								EditorGUILayout.HelpBox(string.Format("该颜色以被其他势力使用, 请改回'{0}'", WarColor.Names[legionConfig.legionId]), MessageType.Error);
							}
							else
							{
								stageConfig.legionDict.Remove(legionConfig.legionId);
								legionConfig.legionId = legionConfig.color;
								stageConfig.legionDict.Add(legionConfig.legionId, legionConfig);
							}
						}

						legionConfig.type = (LegionType) EditorGUILayout.IntPopup("类型", (int) legionConfig.type, legionType_Names, legionType_ids);
						legionConfig.groupId = EditorGUILayout.IntPopup("联盟",  legionConfig.groupId, group_names, group_ids);
//						legionConfig.ai = EditorGUILayout.IntPopup("AI", legionConfig.ai, ai_names, ai_ids);
						legionConfig.robotId = EditorGUILayout.IntField("机器人", legionConfig.robotId);
						
						GUILayout.Space(10);
						legionConfig.produce = EditorGUILayout.ToggleLeft("兵营是否产兵", legionConfig.produce);
						legionConfig.produceLimit = EditorGUILayout.ToggleLeft("兵营生产是否上限(一般只有中立勾选)", legionConfig.produceLimit);
						GUILayout.Space(10);
						legionConfig.aiUplevel = EditorGUILayout.ToggleLeft("是否自动升级", legionConfig.aiUplevel);
						legionConfig.aiSendArm = EditorGUILayout.ToggleLeft("是否自动派兵", legionConfig.aiSendArm);
						legionConfig.aiSkill = EditorGUILayout.ToggleLeft("是否自动使用技能", legionConfig.aiSkill);
						GUILayout.Space(10);


						// ===========================

//						EditorGUILayout.LabelField("士兵");
//						EditorGUILayout.BeginVertical(style_box_solider);
//						if(legionConfig.soldierMonsterId > 0)
//						{
//							GUI_Solider(legionConfig.soliderMonster);
//							
//							if(GUILayout.Button("清除", GUILayout.Height(30)))
//							{
//								legionConfig.soldierMonsterId = 0;
//							}
//						}
//
//						if(GUILayout.Button("选择", GUILayout.Height(30)))
//						{
//							WarEditor_SoliderLibraryWindow.Open(OnSelectSolider, legionConfig);
//						}
//						EditorGUILayout.EndVertical();
						
						// ===========================

						
//						EditorGUILayout.LabelField("英雄");
//						EditorGUILayout.BeginVertical();
//						int heroIndex = 0;
//						for(int i = 0; i < legionConfig.heroIdList.Length; i ++)
//						{
//							int heroId = legionConfig.heroIdList[i];
//							if(heroId <= 0) continue;
//							GUI_Hero(heroId, legionConfig, heroIndex, i);
//							GUILayout.Space(10);
//							heroIndex ++;
//						}
//
//						if(GUILayout.Button("添加", GUILayout.Height(30)))
//						{
//							WarEditor_HeroLibraryWindow.Open(OnSelectAddHero, legionConfig);
//						}
//
//						EditorGUILayout.EndVertical();
						
						// ===========================

					}
					EditorGUILayout.EndVertical();
					EditorGUILayout.EndHorizontal();

					GUILayout.Space(10);
				}
			}


			
			
			
//			fold_legionGroup = EditorGUILayout.Foldout(fold_legionGroup, "势力关系");
//			if (fold_legionGroup)
//			{
//				for(int i = 0; i < stageConfig.legionGroups.Count; i ++)
//				{
//					GUILayout.Box("联盟" + i);
//					EditorGUILayout.BeginHorizontal();
//
//					EditorGUILayout.EndHorizontal();
//
//				}
//			}


			
			EditorGUILayout.EndScrollView();


			//------------------------
			
			GUILayout.Space(20);
			EditorGUILayout.BeginHorizontal();
			
			
			if(GUILayout.Button("应用", GUILayout.Width(100), GUILayout.Height(30)))
			{
				if(stageConfig.legionDict.Count < 2)
				{
					this.ShowNotification(new GUIContent("请创建势力，势力至少需要2个"));
				}
				else
				{
					GenerateGroup(stageConfig);
					WarEditor_Instance.Open(stageConfig);
					WarEditor_StageConfigWindow_Modify.Open();
				}
			}

			if(visiable_SaveButton && GUILayout.Button("保存", GUILayout.Width(100), GUILayout.Height(30)))
			{
				GenerateGroup(stageConfig);
				WarEditor_File.SaveStageConfig(stageConfig);
			}

			if(stageConfig.legionDict.Count < WarColor.Names.Length && 
			   GUILayout.Button("添加势力", GUILayout.Width(100), GUILayout.Height(30)))
			{
				int legionId = 0;
				for(int i = 0; i < WarColor.Names.Length; i ++)
				{
					if(!stageConfig.legionDict.ContainsKey(i))
					{
						legionId = i;
						break;
					}
				}

				StageLegionConfig legionConfig = CreateStageLegionConfig(legionId);
				stageConfig.legionDict.Add(legionConfig.legionId, legionConfig);
			}
			
			EditorGUILayout.EndHorizontal();

		}

		public void GenerateGroup(StageConfig stageConfig)
		{
			List<StageLegionGroupConfig> groupList = new List<StageLegionGroupConfig>();
			Dictionary<int, StageLegionGroupConfig> groupDict = new Dictionary<int, StageLegionGroupConfig>();

			int index = 0;
			foreach(var kvp in stageConfig.legionDict)
			{
				StageLegionConfig legion = kvp.Value;

				StageLegionGroupConfig group = null;
				if(!groupDict.TryGetValue(legion.groupId, out group))
				{
					group = new StageLegionGroupConfig();
					group.id = index;
					index ++;

					groupDict.Add(legion.groupId, group);
					groupList.Add(group);
				}

				group.list.Add(legion);
				legion.groupId = group.id;
			}



			stageConfig.legionGroups = groupList;
		}

		public StageLegionConfig CreateStageLegionConfig(int legionId)
		{
			StageLegionConfig legionConfig = new StageLegionConfig();
			legionConfig.groupId = legionConfig.legionId = legionConfig.color = legionId;

			if(legionId == 0)
			{
				legionConfig.type = LegionType.Neutral;
				legionConfig.produce = true;
				legionConfig.produceLimit = true;
				
				legionConfig.aiUplevel = false;
				legionConfig.aiSkill = false;
				legionConfig.aiSendArm = false;

			}
			else if(legionId == 1)
			{
				legionConfig.type = LegionType.Player;
				legionConfig.produce = true;
				legionConfig.produceLimit = false;
				
				legionConfig.aiUplevel = false;
				legionConfig.aiSkill = false;
				legionConfig.aiSendArm = false;

			}
			else
			{
				legionConfig.type = LegionType.Computer;
				legionConfig.produce = true;
				legionConfig.produceLimit = false;
				
				legionConfig.aiUplevel = true;
				legionConfig.aiSkill = true;
				legionConfig.aiSendArm = true;

			}

			return legionConfig;
		}


//		public void GUI_Hero(int heroId, StageLegionConfig legionConfig, int heroIndex, int i)
//		{
//			
//			MonsterConfig config = War.model.GetMonster(heroId);
//
//			EditorGUILayout.BeginHorizontal();
//			EditorGUILayout.BeginVertical(GUILayout.Width(50));
//
//			GUILayout.Box(heroIndex + "", style_box_center ,GUILayout.Width(50), GUILayout.Height(30));
//
//			if(GUILayout.Button("删除", style_box_center, GUILayout.Width(50), GUILayout.Height(30)))
//			{
//				List<int> ids = new List<int>();
//				foreach(int id in legionConfig.heroIdList)
//				{
//					if(id <= 0 || id == heroId) continue;
//					ids.Add(id);
//				}
//				legionConfig.heroIdList = ids.ToArray();
//			}
//
//			if(GUILayout.Button("选择", style_box_center, GUILayout.Width(50), GUILayout.Height(30)))
//			{
//				WarEditor_HeroLibraryWindow.Open(OnSelectHero, new object[]{legionConfig, i});
//			}
//			EditorGUILayout.EndVertical();
//
//			GUI_HeroIcon(config);
//			EditorGUILayout.EndHorizontal();
//
//		}

//		public void GUI_HeroIcon(MonsterConfig config)
//		{
//			EditorGUILayout.BeginHorizontal(style_box_heroIcon);
//			
//			GUILayout.Label(config.id + "", style_label_id, GUILayout.Width(100), GUILayout.Height(200));
//			
//			Texture2D icon = Resources.Load<Texture2D>(config.avatarConfig.full);
//			GUILayout.Box(icon, GUILayout.Width(200), GUILayout.Height(200));
//
//			
//			EditorGUILayout.BeginVertical();
//			GUILayout.Space(5);
//			GUILayout.Label(config.name, style_label_name);
//			GUILayout.Space(10);
//			
//			if(config.skillId > 0)
//			{
//				EditorGUILayout.BeginHorizontal();
//				SkillWarConf skillWarConfig = War.model.GetSkillWarConf(config.skillId);
//				GUILayout.Label("技能A:  " + skillWarConfig.skillName, GUILayout.Width(100));
//				GUILayout.Label(config.skillLevel + "级", GUILayout.Width(50));
//				GUILayout.Label(skillWarConfig.skillDescribe);
//				EditorGUILayout.EndHorizontal();
//			}
//			
//			
//			if(config.skillId > 0)
//			{
//				EditorGUILayout.BeginHorizontal();
//				SkillWarConf skillWarConfig = War.model.GetSkillWarConf(config.skillId2);
//				GUILayout.Label("技能B:  " + skillWarConfig.skillName, GUILayout.Width(100));
//				GUILayout.Label(config.skillLevel + "级", GUILayout.Width(50));
//				GUILayout.Label(skillWarConfig.skillDescribe);
//				EditorGUILayout.EndHorizontal();
//			}
//			
//			
//			GUILayout.Space(10);
//			foreach(Prop prop in config.props)
//			{
//				if(prop.value == 0) continue;
//				GUILayout.Label(prop.id + " " + prop.Name + ":" + prop.ValueStr, GUILayout.Width(150));
//			}
//			
//			
//			EditorGUILayout.EndVertical();
//			
//			EditorGUILayout.EndHorizontal();
//		}

		
//		public bool OnSelectHero(EditorWindow window , MonsterConfig monsterConfig, object obj)
//		{
//			object[] args =(object[]) obj;
//			StageLegionConfig legionConfig = (StageLegionConfig) args[0]; 
//			int index = (int) args[1];
//
//			List<int> heroIds = new List<int>(legionConfig.heroIdList);
//			int hasIndex = heroIds.IndexOf(monsterConfig.id);
//			if(hasIndex != -1 && hasIndex != index)
//			{
//				window.ShowNotification(new GUIContent("英雄已存在"));
//				return false;
//			}
//
//			legionConfig.heroIdList[index] = monsterConfig.id;
//			OpenWindow();
//			return true;
//		}

		
//		public bool OnSelectAddHero(EditorWindow window ,MonsterConfig monsterConfig, object obj)
//		{
//			StageLegionConfig legionConfig = (StageLegionConfig) obj; 
//			
//			List<int> heroIds = new List<int>(legionConfig.heroIdList);
//			int hasIndex = heroIds.IndexOf(monsterConfig.id);
//			if(hasIndex != -1)
//			{
//				window.ShowNotification(new GUIContent("英雄已存在"));
//				return false;
//			}
//
//			heroIds.Add(monsterConfig.id);
//			legionConfig.heroIdList = heroIds.ToArray();
//			OpenWindow();
//			return true;
//		}



		//------------------------------
//		public void GUI_Solider(MonsterConfig config)
//		{
//			EditorGUILayout.BeginHorizontal();
//			GUILayout.Label(config.id + "", style_label_id, GUILayout.Width(100), GUILayout.Height(200));
//			Texture2D icon = Resources.Load<Texture2D>(config.avatarConfig.full);
//			GUILayout.Box(icon, GUILayout.Width(200), GUILayout.Height(200));
//			EditorGUILayout.BeginVertical();
//			GUILayout.Space(20);
//			GUILayout.Label(config.name, style_label_name);
//			GUILayout.Space(20);
//			
//			foreach(Prop prop in config.props)
//			{
//				if(prop.value == 0) continue;
//				GUILayout.Label(prop.id + " " + prop.Name + ":" + prop.ValueStr, GUILayout.Width(150));
//			}
//			
//			
//			EditorGUILayout.EndVertical();
//			
//			EditorGUILayout.EndHorizontal();
//			GUILayout.Space(10);
//		}
//
//
//		public void OnSelectSolider(MonsterConfig monsterConfig, object obj)
//		{
//			StageLegionConfig legionConfig = (StageLegionConfig) obj; 
//			legionConfig.soldierMonsterId = monsterConfig.id;
//			OpenWindow();
//		}
//

	}
}
