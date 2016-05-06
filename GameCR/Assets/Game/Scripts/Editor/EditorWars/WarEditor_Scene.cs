using UnityEngine;
using UnityEditor;
using System.Collections;
using Games.Module.Wars;
using Game.Editors.Wars;

namespace UnityEditor
{
	
	public enum WarEditorSceneOption
	{

		[HelpAttribute("A 选择")]
		Select,

		[HelpAttribute("A 删除")]
		Delete,

		[HelpAttribute("A 替换")]
		Replace,


		[HelpAttribute("B 兵力")]
		HP,

		[HelpAttribute("B 上阵优先级")]
		SettledPriority,

		[HelpAttribute("B 等级")]
		Level,

		[HelpAttribute("B 势力")]
		Legion,

		[HelpAttribute("C 编辑路径")]
        EditPath
	}

	[CustomEditor(typeof(WE_Scene))]
	public class WarEditor_Scene
	{


		protected static int[] 		option_ids 		= new int[]{};
		protected static string[] 	option_names 	= new string[]{};

		
		[MenuItem ("关卡/单位标签 & ", false, 5000)]
		public static void VisiableHanld () 
		{
			isShow = !isShow;

			if(isShow)
			{

				EnumUtil.GetValuesAndNames<WarEditorSceneOption>(out option_ids, out option_names);

				SceneView.onSceneGUIDelegate += OnSceneGUI;
			}
			else
			{
				SceneView.onSceneGUIDelegate -= OnSceneGUI;
			}
		}

		public static void Show()
		{
//			foreach(var item in SceneView.sceneViews)
//			{
//				Debug.Log(item);
//			}

			if(isShow == false)
			{
				VisiableHanld();
			}
		}


		private static GUIStyle style;
		private static GUIStyle Style{
			get{
				if(style == null){
					style = new GUIStyle( EditorStyles.largeLabel );
					style.alignment = TextAnchor.MiddleCenter;
					style.normal.textColor = new Color(0.9f,0.9f,0.9f);
					style.fontSize = 32;
				}
				return style;
			}
			
		}

		public static bool isShow = false;
		
		
		static void OnSceneGUI(SceneView sceneView)
		{
			GUI_Units();
			GUI_ToolButtons();
		}

		static void GUI_ToolButtons()
		{
			Handles.BeginGUI();
			GUI_Options();
			Handles.EndGUI();
		}


		public static WarEditorSceneOption option;
		static void GUI_Options()
		{
			GUILayout.BeginArea(new Rect(Screen.width - 110, Screen.height - 150, 100,150));
			EditorGUILayout.BeginVertical(EditorStyles.helpBox, GUILayout.Width(100));

			EditorGUILayout.BeginVertical();
			GUILayout.Box("操作模式", GUILayout.Width(90));


//			if(EditorGUILayout.ToggleLeft("选择", option == WarEditorSceneOption.Select))
//			{
//				option = WarEditorSceneOption.Select;
//			}
//
//			if(EditorGUILayout.ToggleLeft("兵力", option == WarEditorSceneOption.HP))
//			{
//				option = WarEditorSceneOption.HP;
//			}
//
//			if(EditorGUILayout.ToggleLeft("上阵优先级", option == WarEditorSceneOption.SettledPriority))
//			{
//				option = WarEditorSceneOption.SettledPriority;
//			}
//
//			if(EditorGUILayout.ToggleLeft("等级", option == WarEditorSceneOption.Level))
//			{
//				option = WarEditorSceneOption.Level;
//			}
//			
//			
//			if(EditorGUILayout.ToggleLeft("删除", option == WarEditorSceneOption.Delete))
//			{
//				option = WarEditorSceneOption.Delete;
//			}
//			
//			if(EditorGUILayout.ToggleLeft("替换", option == WarEditorSceneOption.Replace))
//			{
//				option = WarEditorSceneOption.Replace;
//			}


			option= (WarEditorSceneOption) EditorGUILayout.IntPopup("", (int) option, option_names, option_ids, GUILayout.Width(90));

            //if (EditorGUILayout.ToggleLeft("编辑路径", option == WarEditorSceneOption.EditPath))
            //{
            //    option = WarEditorSceneOption.EditPath;
            //    //WarEditor_EditPath.ShowPath();
            //}
            EditorGUILayout.EndVertical();

			GUILayout.Box("", GUILayout.Width(90), GUILayout.Height(1));

			//-------------------
			if(GUILayout.Button("生成寻路数据", GUILayout.Width(90))) 
			{ 
				WarEditor_File.SaveStagePathData();
			}

			if(GUILayout.Button("生成缩列图", GUILayout.Width(90))) 
			{ 
				WarEditor_File.SaveStateIcon();
			}

			if(War.isEditor && GUILayout.Button("保存", GUILayout.Width(90))) 
			{ 
				WarEditor_File.SaveStageConfig(War.sceneData.stageConfig);
			}


            EditorGUILayout.EndVertical();
			GUILayout.EndArea();
		}

		static void GUI_Units()
		{
			GameObject root  = GameObject.Find("Scene/Caserns");
			if(root != null)
			{
				int count = root.transform.childCount;
				for(int i = 0; i < count; i ++)
				{
					Transform item = root.transform.GetChild(i);
					
					UnitCtl unitCtl = item.GetComponent<UnitCtl>();
					DrawUnit(unitCtl);
				}
			}
			
			root  = GameObject.Find("Scene/Walls");
			if(root != null)
			{
				int count = root.transform.childCount;
				for(int i = 0; i < count; i ++)
				{
					Transform item = root.transform.GetChild(i);
					
					UnitCtl unitCtl = item.GetComponent<UnitCtl>();
					DrawUnit(unitCtl);
				}
			}
		}
		
		static void DrawUnit(UnitCtl unitCtl)
		{
			if(unitCtl.gameObject.activeSelf == false) return;
			
			string text = unitCtl.unitData == null ? unitCtl.gameObject.name : unitCtl.unitData.GetName() + "Lv" + unitCtl.unitData.level;
			Transform transform = unitCtl.transform;
			RaycastHit hit;
			Ray r = new Ray(transform.position + Camera.current.transform.up * 8f, -Camera.current.transform.up );
			
			Collider collider = transform.GetComponent<Collider>();
			if(collider == null)
			{
				collider = transform.GetComponentInChildren<Collider>();
			}
			
			if(collider != null && collider.Raycast( r, out hit, Mathf.Infinity) ){
				
				float dist = (Camera.current.transform.position - hit.point).magnitude;
				
				float fontSize = Mathf.Lerp(64, 12, dist/10f);
				
				Style.fontSize = (int)fontSize;
				
				Vector3 wPos = hit.point ;
				if(Camera.current.orthographic == false)
				{
					wPos += Camera.current.transform.up*dist*0.07f;
				}
				else
				{
					wPos += Camera.current.transform.up*dist*0.01f;
				}
				
				Vector3 scPos = Camera.current.WorldToScreenPoint(wPos);
				if(scPos.z <= 0){
					return;
				}

				float alpha = Mathf.Clamp(-Camera.current.transform.forward.y, 0f, 1f);
				alpha = 1f-((1f-alpha)*(1f-alpha));
				
				alpha = Mathf.Lerp(-0.2f,1f,alpha);
				
				Handles.BeginGUI();
				
				scPos.y = Screen.height - scPos.y; // Flip Y
				
				Vector2 strSize = Style.CalcSize(new GUIContent(text));
				
				Rect rect = new Rect(0f, 0f, strSize.x + 6,strSize.y + 4);
				rect.center = scPos - Vector3.up*rect.height*0.5f;
				GUI.color = new Color(0f,0f,0f,0.8f * alpha);
				GUI.DrawTexture(rect, EditorGUIUtility.whiteTexture);
				GUI.color = Color.white;
				GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
                //			GUI.Label(rect, text, Style);

                if (option == WarEditorSceneOption.Select && GUI.Button(rect, text, Style))
				{
					Selection.activeGameObject = unitCtl.gameObject;
				}

				if(option == WarEditorSceneOption.Delete && GUI.Button(rect, "删除", Style))
				{
					GameObject.Destroy(unitCtl.gameObject);
				}

				
				if(option == WarEditorSceneOption.Replace && GUI.Button(rect, "替换", Style))
				{
					Selection.activeGameObject = unitCtl.gameObject;
					WarEditor_LibraryWindow.Replace(unitCtl);
				}

				if(option == WarEditorSceneOption.HP)
				{
					WE_BuildConfigData buildConfigData = null;
					if(unitCtl.unitData != null)
					{
						buildConfigData = unitCtl.unitData.we_BuildConfigData;
					}

					if(buildConfigData != null && unitCtl.unitData.unitType == UnitType.Build)
					{
						buildConfigData.hp = EditorGUI.IntField(rect, buildConfigData.hp);
					}
				}



				if(option == WarEditorSceneOption.SettledPriority)
				{
					WE_BuildConfigData buildConfigData = null;
					if(unitCtl.unitData != null)
					{
						buildConfigData = unitCtl.unitData.we_BuildConfigData;
					}

					if(buildConfigData != null && unitCtl.unitData.unitType == UnitType.Build)
					{
						buildConfigData.settledPriority = EditorGUI.IntField(rect, buildConfigData.settledPriority);
					}
				}



				if(option == WarEditorSceneOption.Level)
				{
					
					if( unitCtl.unitData.unitType == UnitType.Build)
					{
						
						int level = EditorGUI.IntField(rect, unitCtl.unitData.level);
						if (level != unitCtl.unitData.level) 
						{
							unitCtl.unitData.Uplevel (level);
						}
					}
				}


				if(option == WarEditorSceneOption.Legion)
				{

					if( unitCtl.unitData.unitType == UnitType.Build)
					{

						int legionId = EditorGUI.IntField(rect, unitCtl.unitData.legionId);
						if (legionId != unitCtl.unitData.legionId) 
						{
							if (War.sceneData.legionDict.ContainsKey (legionId))
							{
								unitCtl.unitData.ChangeLegion (legionId);
							} 
							else 
							{
								if(SceneView.lastActiveSceneView != null) SceneView.lastActiveSceneView.ShowNotification(new GUIContent("关卡没有配置'" + WarColor.Names[legionId]+ "'势力，请先到（关卡/关卡配置）里添加势力"));
							}
						}
					}
				}

				GUI.color = Color.white;
				
				Handles.EndGUI();
			}
		}


	}

}