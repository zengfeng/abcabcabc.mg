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
	public class WarEditor_StageWindow : EditorWindow {
		
		static WarEditor_StageWindow window;

		[MenuItem ("关卡/关卡浏览器", false, 2000)]
		static void Init () {
			window = EditorWindow.GetWindow <WarEditor_StageWindow>("关卡浏览器");
			window.minSize = new Vector2(500, 200);
			window.Show();
		}

		
		
		public static void RefreshStageIcon(int stageId)
		{
			if(window != null)
			{
				if(window.stageIcons.ContainsKey(stageId))
				{
					window.stageIcons.Remove(stageId);
				}
			}
		}

		void ReadConfig()
		{
			Coo.assetManager = AssetManager.Instance;
			Coo.configManager = ConfigManager.Instance;
			Coo.assetManager.Init();
			
			
			PropConfig.Initialize(Coo.configManager.GetCustomConfig<PropConfigLoader>().propConfigs);
			Coo.configManager.GetConfig<int, ConstConfig>();
			Goo.avatar.LoadConfig();
			War.model.LoadConfig();
			if(Application.isPlaying == false)
			{
				GameObject.DestroyImmediate(GameObject.Find("GameManagers"));
			}
		}

		void PrintStageList()
		{
			foreach(KeyValuePair<int, StageConfig> kvp in War.model.stageConfigs_Index)
			{
				Debug.Log(kvp.Key + "  " + kvp.Value);
			}
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

			if(Application.isPlaying)
			{
				GUI_StageList();
			}
		}

		private GUISkin guiSkin;
		private Vector2 scrollPos;
		private Dictionary<int, Texture> stageIcons = new Dictionary<int, Texture>();
		private List<StageConfig> stageList = new List<StageConfig>();
		void GUI_StageList()
		{
			GUI_StageKey();
			scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
			EditorGUILayout.BeginVertical();

			
			if(stageList.Count != War.model.stageConfigs_Index.Count)
			{
				stageList.Clear();
				foreach(KeyValuePair<int, StageConfig> kvp in War.model.stageConfigs_Index)
				{
					stageList.Add(kvp.Value);
				}
			}


			for(int i = 0; i < stageList.Count; i ++)
			{
				GUI_StageItem(i, stageList[i]);
			}

			EditorGUILayout.EndVertical();
			EditorGUILayout.EndScrollView();
			GUI_ToolButtons();
		}

		
		void GUI_ToolButtons()
		{
			GUILayout.BeginHorizontal();
			if(GUILayout.Button("新建", GUILayout.Height(30)))
			{
				WarEditor_StageConfigWindow_Create.Open();
			}

			if(GUILayout.Button("批量生成关卡缩列图", GUILayout.Height(30)))
			{
				if(Camera.main.gameObject.GetComponent<WE_StageIcon>() == null)
				{
					Camera.main.gameObject.AddComponent<WE_StageIcon>();
				}
			}
			
			
			if(GUILayout.Button("批量生成寻路数据", GUILayout.Height(30)))
			{
				if(Camera.main.gameObject.GetComponent<WE_PathManager>() == null)
				{
					Camera.main.gameObject.AddComponent<WE_PathManager>();
				}
			}
			GUILayout.EndHorizontal();
		}

		public bool editorIsOpenStageConfigWindow = true;
		void GUI_StageKey()
		{
			
			GUIStyle style = new GUIStyle(EditorStyles.boldLabel);
			style.alignment = TextAnchor.MiddleCenter;

			GUILayout.Space(10);
			GUIContent iconContent = new GUIContent("");
			GUILayout.BeginHorizontal(iconContent, guiSkin.box);
			style.alignment = TextAnchor.MiddleLeft;
			GUILayout.Label("ID", style, GUILayout.Width(50) ,  GUILayout.Height(18));
			GUILayout.Space(10);
			style.alignment = TextAnchor.MiddleCenter;
			GUILayout.Label("图标", style, GUILayout.Width(300) ,  GUILayout.Height(18));
			GUILayout.Space(10);
			editorIsOpenStageConfigWindow = EditorGUILayout.ToggleLeft("编辑跳转到配置面板", editorIsOpenStageConfigWindow,  GUILayout.Width(150) ,  GUILayout.Height(18));
//			GUILayout.Label("--",   GUILayout.Height(18));
			GUILayout.EndHorizontal();
		}

		int itemHeight = 200;
		void GUI_StageItem(int index, StageConfig stageConfig)
		{
			Texture icon = null;
			if(stageIcons.ContainsKey(stageConfig.id))
			{
				icon = stageIcons[stageConfig.id];
			}
			else
			{
				icon = LoadEditorResource<Texture2D>("StageIcon/" + stageConfig.id + ".png");
				stageIcons.Add(stageConfig.id, icon);
			}

			if(icon == null)
			{
				icon = defaultStageIcon;
			}
			GUIContent iconContent = new GUIContent(icon);



			GUILayout.Space(5);
			GUILayout.BeginHorizontal();
			GUILayout.Label(stageConfig.id  + "", guiSkin.label, GUILayout.Width(50) ,  GUILayout.Height(itemHeight));
			GUILayout.Space(10);
			GUILayout.Box(iconContent, guiSkin.box,  GUILayout.Width(300), GUILayout.Height(itemHeight));
			GUILayout.Space(10);

			GUILayout.BeginVertical();
			GUILayout.Label(stageConfig.name, guiSkin.label,  GUILayout.Height(30));
			GUILayout.Space(10);

			if(GUILayout.Button("运行", guiSkin.button, GUILayout.Height(30)))
			{
				WarEditor_Instance.Run(stageConfig);
			}

			if(GUILayout.Button("编辑", guiSkin.button, GUILayout.Height(30)))
			{
				WarEditor_Instance.Open(stageConfig);
				if(editorIsOpenStageConfigWindow)
				{
					WarEditor_StageConfigWindow_Modify.Open();
				}
			}
			
			if(GUILayout.Button("克隆", guiSkin.button, GUILayout.Height(30)))
			{
				WarEditor_StageConfigWindow_Create.Open(stageConfig);
			}

			if(GUILayout.Button("删除", guiSkin.button, GUILayout.Height(30)))
			{
				if(EditorUtility.DisplayDialog("删除关卡", "是否真的要删除？", "删除", "取消"))
				{
					WarEditor_File.Delete(stageConfig.id);
				}
			}
			GUILayout.EndVertical();
			GUILayout.EndHorizontal();
			GUILayout.Space(5);
			GUILayout.Box(iconContent, GUILayout.ExpandWidth(true), GUILayout.Height(1));
		}


		
		private Texture fieldBG;
		private Texture defaultStageIcon;
		public void OnEnable()
		{
			fieldBG =  LoadEditorResource<Texture>("StageIcon/DefaultStageIcon.png");
			defaultStageIcon = LoadEditorResource<Texture>("StageIcon/DefaultStageIcon.png");
//			Debug.Log("defaultStageIcon=" + defaultStageIcon);

			guiSkin = LoadEditorResource<GUISkin>("StageGUISkin.guiskin");
//			Debug.Log("guiSkin=" + guiSkin);
		}

		


		
		T LoadEditorResource<T>(string name) {
			return (T) LoadEditorResource(name, typeof(T));
		}
		
		System.Object LoadEditorResource(string name, Type type) {
			string path = "Assets/EditorDefaultResources/" + name;
			return AssetDatabase.LoadAssetAtPath(path, type);
		}


	}
}
