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

namespace Game.Editors.Wars
{
	public class WarEditor_BuildConfigWindow : EditorWindow {

		[MenuItem ("关卡/建筑配置", false, 4000)]
		static void Init () {
			WarEditor_BuildConfigWindow window = EditorWindow.GetWindow <WarEditor_BuildConfigWindow>("建筑配置");
			window.minSize = new Vector2(500, 200);
			window.Show();
		}

		GUIStyle style_select_name;
		
		void InitStyle()
		{
			style_select_name = new GUIStyle(EditorStyles.helpBox);
			style_select_name.margin = new RectOffset();
			style_select_name.padding = new RectOffset();
			style_select_name.padding.left = 20;
			style_select_name.alignment = TextAnchor.MiddleLeft;
			style_select_name.fontSize = 16;
			style_select_name.fontStyle = FontStyle.Bold;
		}


		void OnGUI()
		{
			InitStyle();

			if(Selection.activeGameObject && Selection.activeGameObject.GetComponent<BuildAgent>())
			{
				GUI_Build(Selection.activeGameObject);
			}
			else
			{
				EditorGUILayout.HelpBox("没有选择建筑", MessageType.Info);
			}
		}

		void GUI_Build(GameObject go)
		{
			UnitCtl unitCtl = go.GetComponent<UnitCtl>();
			if(unitCtl == null || unitCtl.unitData == null ||  unitCtl.unitData.we_BuildConfigData == null)
			{
				return;
			}

			WE_BuildConfigData buildConfigData = unitCtl.unitData.we_BuildConfigData;
			
			string name = unitCtl.unitData == null ? unitCtl.gameObject.name : unitCtl.unitData.GetName() ;
			GUILayout.Box(name, style_select_name, GUILayout.ExpandWidth(true), GUILayout.Height(30));

			unitCtl.unitData.level = EditorGUILayout.IntField("等级", unitCtl.unitData.level);

			buildConfigData.hp = EditorGUILayout.IntField("初始兵力", buildConfigData.hp);
			EditorGUILayout.HelpBox("初始兵力为‘-1’时，通过计算公式计算", MessageType.None);

			buildConfigData.settledPriority = EditorGUILayout.IntField("上阵优先级", buildConfigData.settledPriority);

		}


	}
}
