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
	public class WarEditor_StageConfigWindow_Create : WarEditor_StageConfigWindow {

		[MenuItem ("关卡/新建关卡", false, 3000)]
		public static void Open () 
		{
			Open(null);
		}

		public static void Open(StageConfig sourceStageConfig)
		{
			WarEditor_StageConfigWindow_Create window = ShowWindow();
			window.newStageConfig = sourceStageConfig == null ? null : sourceStageConfig.Clone();

			if(window.newStageConfig != null)
			{
				window.newStageConfig.id = 0;

				if(War.model.Editor_stageConfigs.ContainsKey(window.newStageConfig.id))
				{
					War.model.Editor_stageConfigs.Remove(window.newStageConfig.id);
				}
				
				War.model.Editor_stageConfigs.Add(window.newStageConfig.id, window.newStageConfig);
			}
		}

		public static WarEditor_StageConfigWindow_Create ShowWindow()
		{
			WarEditor_StageConfigWindow_Create window = EditorWindow.GetWindow <WarEditor_StageConfigWindow_Create>("新建关卡");
			window.minSize = new Vector2(500, 200);
			window.Show();
			return window;
		}


		
		override public void OpenWindow()
		{
			WarEditor_StageConfigWindow_Create.ShowWindow();
		}


		public StageConfig newStageConfig;
		override protected void OnGUI_Module()
		{
			if(newStageConfig == null)
			{
				newStageConfig = new StageConfig();
				newStageConfig.id = 0;
				newStageConfig.resource = 1;
				newStageConfig.legionDict.Add(0, CreateStageLegionConfig(0));
				newStageConfig.legionDict.Add(1, CreateStageLegionConfig(1));
				newStageConfig.legionDict.Add(2, CreateStageLegionConfig(2));
				
				if(War.model.Editor_stageConfigs.ContainsKey(newStageConfig.id))
				{
					War.model.Editor_stageConfigs.Remove(newStageConfig.id);
				}
				
				War.model.Editor_stageConfigs.Add(newStageConfig.id, newStageConfig);
			}

			GUIHanlder(newStageConfig);
		}
		
		
		
		override protected void OnIdChange(StageConfig stageConfig)
		{
			if(id != sourceId)
			{
				if(War.model.stageConfigs_Index.ContainsKey(id))
				{
					EditorGUILayout.HelpBox(string.Format("编号{0}以被使用, {1}。", id, War.model.stageConfigs_Index[id].name), MessageType.Error);
				}
			}

			if(stageConfig.id != id)
			{
				stageConfig.id = id;

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
