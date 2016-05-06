using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using Games.Module.Wars;
using System;
using System.Reflection;
using UnityEditor.AnimatedValues;
using Games.Module.Avatars;
using Games.Cores;
using CC.Runtime;
using Games.Module.Props;


namespace Game.Editors.Wars
{

	public class WarEditor_HeroLibraryWindow : EditorWindow 
	{
		public static object 							onSelectParameter;
		public static Func<EditorWindow, MonsterConfig, object, bool> 	sOnSelect;

		[MenuItem ("关卡/英雄库", false, 2005)]
		public static void Open () {
			Open(null, null);
		}

		public static void Open(Func<EditorWindow, MonsterConfig, object, bool> selectCall, object parameter)
		{
			sOnSelect = selectCall;
			onSelectParameter = parameter;

			WarEditor_HeroLibraryWindow window = EditorWindow.GetWindow <WarEditor_HeroLibraryWindow>("英雄库");
			window.minSize = new Vector2(500, 200);
			window.Show();
		}
		


		void OnGUI ()
		{
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
			}
			//GUIHandle();
		}

		
		
		GUIStyle style_box_key;
		GUIStyle style_label_key;
		GUIStyle style_label_id;
		GUIStyle style_label_name;
		GUIStyle style_label_line;

		void InitStyle()
		{
			style_box_key = new GUIStyle(EditorStyles.helpBox);

			style_label_key = new GUIStyle(EditorStyles.label);
			style_label_key.margin = new RectOffset();
			style_label_key.margin.left = 0;
			style_label_key.margin.right = 0;
			style_label_key.alignment = TextAnchor.MiddleCenter;
			style_label_key.fontStyle = FontStyle.Bold;

			
			
			style_label_id = new GUIStyle(EditorStyles.label);
			style_label_id.alignment = TextAnchor.MiddleCenter;
			style_label_id.fontSize = 20;
			

			style_label_name = new GUIStyle(EditorStyles.boldLabel);
			style_label_name.alignment = TextAnchor.MiddleLeft;
			style_label_name.fontSize = 16;

			style_label_line = new GUIStyle(EditorStyles.label);
			style_label_line.alignment = TextAnchor.MiddleLeft;
		}


		Vector2 scrollPos;
		private List<MonsterConfig> monsters = new List<MonsterConfig>();
		void GUIHandle ()
		{
			InitStyle();

			GUI_Key();

			scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
//			if(monsters.Count == 0)
//			{
				foreach(var item in War.model.monsterConfigs)
				{
					if(item.Value.id >= 10000)
					{
						monsters.Add(item.Value);
						GUI_Item(item.Value);
					}
				}
//			}
//
//
//			foreach(MonsterConfig item in monsters)
//			{
//				GUI_Item(item);
//			}



			EditorGUILayout.EndScrollView();
		}


		private bool isShowPropId = false;
		public void GUI_Key()
		{
			
			GUILayout.BeginHorizontal(style_box_key);
			GUILayout.Label("编号", style_label_key, GUILayout.Width(100), GUILayout.Height(20));
			GUILayout.Label("缩列图", style_label_key, GUILayout.Width(200), GUILayout.Height(20));
			isShowPropId = EditorGUILayout.ToggleLeft("是否显示属性ID", isShowPropId, GUILayout.Width(100));
			GUILayout.EndHorizontal();
		}

		public void GUI_Item(MonsterConfig config)
		{
			GUILayout.Space(10);
			EditorGUILayout.BeginHorizontal(GUILayout.Width(600));

			GUILayout.Label(config.id + "", style_label_id, GUILayout.Width(100), GUILayout.Height(200));

			Texture2D icon = Resources.Load<Texture2D>(config.avatarConfig.full);
			if(GUILayout.Button(icon, GUILayout.Width(200), GUILayout.Height(200)))
			{
				if(sOnSelect != null)
				{
					if(sOnSelect(this, config, onSelectParameter))
					{
						sOnSelect = null;
						onSelectParameter = null;
					}
				}
			}

			EditorGUILayout.BeginVertical();
			GUILayout.Space(5);
			GUILayout.Label(config.name, style_label_name);
			GUILayout.Space(10);

			if(config.skillId > 0)
			{
				EditorGUILayout.BeginHorizontal();
				SkillWarConf skillWarConfig = War.model.GetSkillWarConf(config.skillId);
				GUILayout.Label("技能A:  " + skillWarConfig.skillName, GUILayout.Width(100));
				GUILayout.Label(config.skillLevel + "级", GUILayout.Width(50));
				GUILayout.Label(skillWarConfig.skillDescribe);
				EditorGUILayout.EndHorizontal();
			}

			
			if(config.skillId > 0)
			{
				EditorGUILayout.BeginHorizontal();
				SkillWarConf skillWarConfig = War.model.GetSkillWarConf(config.skillId2);
				GUILayout.Label("技能B:  " + skillWarConfig.skillName, GUILayout.Width(100));
				GUILayout.Label(config.skillLevel + "级", GUILayout.Width(50));
				GUILayout.Label(skillWarConfig.skillDescribe);
				EditorGUILayout.EndHorizontal();
			}

			
			GUILayout.Space(10);
			foreach(Prop prop in config.props)
			{
				if(prop.value == 0) continue;
				if(isShowPropId)
				{
					GUILayout.Label(prop.id + " " + prop.Name + ":" + prop.ValueStr, GUILayout.Width(150));
				}
				else
				{
					GUILayout.Label(prop.Name + ":" + prop.ValueStr, GUILayout.Width(150));
				}
			}


			EditorGUILayout.EndVertical();

			EditorGUILayout.EndHorizontal();
			GUILayout.Space(10);
			GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
		}
		
		
		
		
	}
}
