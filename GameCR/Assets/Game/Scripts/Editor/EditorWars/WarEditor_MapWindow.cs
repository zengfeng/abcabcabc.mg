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

	public partial class WarEditor_MapWindow : EditorWindow 
	{
		
		[MenuItem ("关卡/关卡地图", false, 2002)]
		static void Init () {
			WarEditor_MapWindow window = EditorWindow.GetWindow <WarEditor_MapWindow>("关卡地图");
			window.minSize = new Vector2(500, 200);
			window.Show();
		}


		GUIStyle style_label_id;
		GUIStyle style_label_line;
		GUIStyle style_box_txt;
		
		void InitStyle()
		{

			
			style_label_id = new GUIStyle(EditorStyles.label);
			style_label_id.alignment = TextAnchor.MiddleCenter;
			
			
			style_label_line = new GUIStyle(EditorStyles.label);
			style_label_line.alignment = TextAnchor.MiddleLeft;

			style_box_txt = new GUIStyle(EditorStyles.helpBox);
			style_box_txt.alignment = TextAnchor.MiddleCenter;
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
			GUIHandle();
		}

		Dictionary<int, Texture2D> mapIconDict = new Dictionary<int, Texture2D>();
		Vector2 scrollPos;
		void GUIHandle ()
		{
//			if(style_label_id == null)
//			{
				InitStyle();
//			}
			
			scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
			
			EditorGUILayout.BeginVertical();
			foreach(var item in War.model.mapConfigs)
			{
				MapConfig mapConfig = item.Value;

				GUILayout.Space(10);
				EditorGUILayout.BeginHorizontal();

				
				GUILayout.Label(mapConfig.id + "", style_label_id, GUILayout.Width(50), GUILayout.Height(100));

				Texture2D mapIcon = null;
				if(!mapIconDict.TryGetValue(mapConfig.id, out mapIcon))
				{
					mapIcon = (Texture2D) AssetDatabase.LoadAssetAtPath("Assets/EditorDefaultResources/MapIcon/" + mapConfig.id + ".png", typeof(Texture2D));
					mapIconDict.Add(mapConfig.id, mapIcon);
				}

				GUIContent content = mapIcon == null ? new GUIContent("没有缩列图") : new GUIContent(mapIcon);

				if(GUILayout.Button(content, GUILayout.Width(150), GUILayout.Height(100)))
				{
					InstanceMap(mapConfig);
				}

				Texture2D buildGround = WarRes.GetRes<Texture2D>(mapConfig.buildGround);
				if(buildGround != null)
				{
					GUILayout.Box(buildGround, GUILayout.Width(100), GUILayout.Height(100));
				}
				else
				{
					GUILayout.Box("没有建筑地表", style_box_txt, GUILayout.Width(100), GUILayout.Height(100));

					WarEditor.LoadRes(mapConfig.buildGround);
				}


				GUILayout.Label(mapConfig.name, style_label_line, GUILayout.Width(100), GUILayout.Height(100));
				GUILayout.Label(mapConfig.terrain, style_label_line, GUILayout.Width(200), GUILayout.Height(100));
				GUILayout.Label(mapConfig.buildGround, style_label_line, GUILayout.Height(100));


				EditorGUILayout.EndHorizontal();
				GUILayout.Space(10);
				GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
			}
			EditorGUILayout.EndVertical();
			EditorGUILayout.EndScrollView();
		}

		void InstanceMap(MapConfig mapConfig)
		{
			if(War.sceneData == null)
			{
				this.ShowNotification(new GUIContent("请先'选择关卡'或者'创建关卡'"));
				return;
			}

			WarEditor.LoadRes(mapConfig.terrain);

			War.sceneData.mapConfig = mapConfig;
			War.map.Clear();
			War.map.Instance();



			GameObject root = GameObject.Find("Scene/Caserns");
			if(root != null)
			{
				int count = root.transform.childCount;
				for(int i = 0; i < count; i ++)
				{
					BuildAgent buildAgent = root.transform.GetChild(i).GetComponent<BuildAgent>();
					if(buildAgent != null)
					{
						buildAgent.InitBuildGround();
					}
				}
			}
		}




	}
}
