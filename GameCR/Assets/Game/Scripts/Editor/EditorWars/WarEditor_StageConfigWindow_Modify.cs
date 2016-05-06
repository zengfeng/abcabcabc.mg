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
	public class WarEditor_StageConfigWindow_Modify : WarEditor_StageConfigWindow {

		[MenuItem ("关卡/关卡配置", false, 3000)]
		public static void Open () {
			WarEditor_StageConfigWindow_Modify window = EditorWindow.GetWindow <WarEditor_StageConfigWindow_Modify>("关卡配置");
			window.minSize = new Vector2(500, 200);
			window.visiable_SaveButton = true;
			window.Show();
		}

		
		override public void OpenWindow()
		{
			WarEditor_StageConfigWindow_Modify.Open();
		}

		
		override protected void OnGUI_Module()
		{
			if(War.sceneData == null)
			{
				if(GUILayout.Button("新建关卡", GUILayout.MinHeight(100)))
				{
					WarEditor_StageConfigWindow_Create.Open();
				}
			}
			else
			{
				GUIHanlder(War.sceneData.stageConfig);
			}
		}



		override protected void OnIdChange(StageConfig stageConfig)
		{
			if(id != sourceId)
			{
				if(War.model.stageConfigs_Index.ContainsKey(id))
				{
					EditorGUILayout.HelpBox(string.Format("编号{0}以被使用, {1}。初始编号{2}", id, War.model.stageConfigs_Index[id].name, sourceId), MessageType.Error);
				}
				else
				{
					EditorGUILayout.HelpBox(string.Format("初始编号{0}", sourceId), MessageType.None);
					if(War.model.Editor_stageConfigs.ContainsKey(id))
					{
						War.model.Editor_stageConfigs.Remove(id);
					}
					
					stageConfig.id = id;
					
					War.model.Editor_stageConfigs.Add(stageConfig.id, stageConfig);
				}
			}
			else
			{
				if(stageConfig.id != id)
				{
					if(War.model.Editor_stageConfigs.ContainsKey(id))
					{
						War.model.Editor_stageConfigs.Remove(id);
					}
					
					stageConfig.id = id;
					
					War.model.Editor_stageConfigs.Add(stageConfig.id, stageConfig);
				}
			}
		}


	}
}
