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

	public partial class WarEditor_LibraryWindow : EditorWindow 
	{
		//int colorId, int level, AbstractBuildConfig buildConfig, object parameter
		public static Action<int, int, AbstractBuildConfig, object> sOnSelect;
		public static object onSelect_parameter;

		[MenuItem ("关卡/关卡资源库", false, 2001)]
		public static void Open ()
		{
			Open(null, null);
		}

		public static WarEditor_LibraryWindow window;
		public static void Open (Action<int, int, AbstractBuildConfig, object> callback, object parameter) 
		{
			sOnSelect = callback;
			onSelect_parameter = parameter;

			
			window = EditorWindow.GetWindow <WarEditor_LibraryWindow>("关卡资源库");
			window.minSize = new Vector2(500, 200);
			window.Show();
		}

		public static void Replace(UnitCtl unitCtl)
		{
			Open();
			sOnSelect = window.OnReplaceSelect;
			onSelect_parameter = unitCtl;
		}
		
		private bool 		unitGroupEnabled 	= true;
		private bool[] 		unitEnables 		= new bool[]	{true, true};
		private string[] 	unitNames 			= new string[]	{"建筑", "路障"};

		private bool 		colorGroupEnabled = true;
		private bool[] 		colorEnables;
		private string[] 	colorNames;
		private int[] 		colorIds;

		private bool[] 		levelEnables 	= new bool[]{true, true, true};
		private string[] 	levelNames 		= new string[]{"一级", "二级", "三级"};


		
		private bool 		buildGroupEnabled = true;
		private bool[] 		buildEnableds;
		private string[] 	buildTypeNames;
		private int[] 		buildTypeIds;
		private bool[]  	buildSwitchs;

		void OnEnable()
		{
			colorNames = WarColor.Names;
			colorIds = WarColor.IDs;
			colorEnables = new bool[colorNames.Length];
			for(int i = 0; i < colorEnables.Length; i ++)
			{
				colorEnables[i] = true;
			}

			
			BuildType[] buildTypes =(BuildType[]) Enum.GetValues(typeof(BuildType));
			buildTypeNames = new string[buildTypes.Length - 1];
			buildTypeIds = new int[buildTypes.Length - 1];

			for(int i = 0; i < buildTypes.Length; i ++)
			{
				if(i < 1) continue;
				buildTypeIds[i - 1] = (int)buildTypes[i];
			}
			
			Type t = typeof(BuildType);
			FieldInfo[] fis = t.GetFields();
			for(int i = 0; i < fis.Length; i ++)
			{
				if(i < 2) continue;

				FieldInfo f = fis[i];
				if(f.GetCustomAttributes(true).Length > 0)
				{
					HelpAttribute help =(HelpAttribute) f.GetCustomAttributes(true)[0];
					buildTypeNames[i - 2] = help.description;
				}
			}

			
			buildEnableds = new bool[buildTypes.Length - 1];
			buildSwitchs = new bool[buildEnableds.Length];
			for(int i = 0; i < buildEnableds.Length; i ++)
			{
				buildEnableds[i] = true;
				buildSwitchs [i] = true;
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
			else
			{
			}
			GUIHandle();
		}

		

		GUIStyle style_key;
		GUIStyle style_box_key;
		GUIStyle style_box_marginleft;
		GUIStyle style_box_type;
		GUIStyle style_label_type;
		GUIStyle style_label_icon;
		GUIStyle style_label_icon_hasbg;
		GUIStyle style_label_wall_id;
		GUIStyle style_label_wall_line;
		GUIStyle style_label_prop;

		void InitStyle()
		{
			style_box_key = new GUIStyle(EditorStyles.label);
			style_box_key.margin = new RectOffset();
			style_box_key.margin.left = 0;
			style_box_key.margin.right = 0;
			style_box_key.alignment = TextAnchor.MiddleCenter;
			style_box_key.fontStyle = FontStyle.Bold;
			
			
			style_box_marginleft = new GUIStyle(EditorStyles.helpBox);
			style_box_marginleft.margin = new RectOffset();
			style_box_marginleft.margin.left = 30;
			//			style_box_marginleft.margin.right = 30;
			
			style_box_type = new GUIStyle(EditorStyles.helpBox);
			style_box_type.margin = new RectOffset();
			style_box_type.margin.left = 0;
			
			style_label_type = new GUIStyle(EditorStyles.boldLabel);
			style_label_type.alignment = TextAnchor.MiddleLeft;
			
			style_label_icon = new GUIStyle(EditorStyles.label);
			style_label_icon.alignment = TextAnchor.MiddleCenter;
			
			
			style_label_icon_hasbg = new GUIStyle(EditorStyles.helpBox);
			style_label_icon_hasbg.alignment = TextAnchor.MiddleCenter;
			
			
			style_label_wall_id = new GUIStyle(EditorStyles.label);
			style_label_wall_id.alignment = TextAnchor.MiddleCenter;
			
			
			style_label_wall_line = new GUIStyle(EditorStyles.label);
			style_label_wall_line.alignment = TextAnchor.MiddleLeft;

			style_label_prop = new GUIStyle(EditorStyles.label);
			style_label_prop.alignment = TextAnchor.MiddleLeft;
			style_label_prop.richText = true;


			style_key = new GUIStyle(EditorStyles.label);
			style_key.alignment = TextAnchor.MiddleLeft;
			style_key.richText = true;
			style_key.fontSize = 14;
			style_key.fontStyle = FontStyle.Bold;

		}

		public bool fold_filter = true;
		public bool fold_build 	= true;
		public bool fold_wall 	= true;


		Vector2 scrollPos_build;
		Vector2 scrollPos_wall;
		void GUIHandle ()
		{
//			if(style_box_key == null)
//			{
				InitStyle();
//			}


			fold_filter = EditorGUILayout.Foldout(fold_filter, "过滤器");
			if (fold_filter)
			{
				EditorGUILayout.BeginVertical(style_box_marginleft);
				GUILayout.Label ("单位", style_key);
				EditorGUILayout.BeginHorizontal ();
				for(int i = 0; i < unitEnables.Length; i ++)
				{
					GUILayout.Space(20);
					unitEnables[i] = EditorGUILayout.ToggleLeft(unitNames[i], unitEnables[i], GUILayout.Width(50));
				}
				EditorGUILayout.EndHorizontal ();
				GUILayout.Space(10);

				 
				if(unitGroupEnabled && unitEnables[0])
				{

					GUILayout.Label ("颜色", style_key);
					EditorGUILayout.BeginHorizontal ();
					for(int i = 0; i < colorEnables.Length; i ++)
					{
						GUILayout.Space(20);
						colorEnables[i] = EditorGUILayout.ToggleLeft(colorNames[i], colorEnables[i], GUILayout.Width(50));
					}
					EditorGUILayout.EndHorizontal ();
					GUILayout.Space(10);


					GUILayout.Label ("建筑", style_key);
					EditorGUILayout.BeginHorizontal ();
					for(int i = 0; i < buildEnableds.Length; i ++)
					{
						GUILayout.Space(20);
						buildEnableds[i] = EditorGUILayout.ToggleLeft(buildTypeNames[i], buildEnableds[i], GUILayout.Width(50));
					}
					EditorGUILayout.EndHorizontal ();

					GUILayout.Space(10);

					GUILayout.Label ("等级", style_key);
					EditorGUILayout.BeginHorizontal ();

					for(int i = 0; i < levelEnables.Length; i ++)
					{
						GUILayout.Space(20);
						levelEnables[i] = EditorGUILayout.ToggleLeft(levelNames[i], levelEnables[i], GUILayout.Width(50));

					}
					EditorGUILayout.EndHorizontal ();
				}

				
				EditorGUILayout.EndVertical();
				GUILayout.Space(20);
			}


			scrollPos_build = EditorGUILayout.BeginScrollView(scrollPos_build);
			if(buildGroupEnabled && unitGroupEnabled && unitEnables[0])
			{
				fold_build = EditorGUILayout.Foldout(fold_build, "建筑");
				if (fold_build)
				{


					for(int i = 0; i < buildEnableds.Length; i ++)
					{
						if(buildEnableds[i])
						{

							GUI_Build (i, buildTypeNames[i]);
							
							GUILayout.Space(20);
						}
					}
				}
			}

			if(unitGroupEnabled && unitEnables[1])
			{
				
				fold_wall = EditorGUILayout.Foldout(fold_wall, "路障");
				if(fold_wall)
				{
					GUI_Wall();
				}
			}
			EditorGUILayout.EndScrollView();
		}


		void GUI_Empty()
		{

		}


		void GUI_Build(int buildTypeValue, string name)
		{
			EditorGUILayout.BeginVertical(style_box_marginleft);
			buildSwitchs[buildTypeValue] = GUILayout.Toggle(buildSwitchs[buildTypeValue], name, style_label_type, GUILayout.ExpandWidth(true));
			if(buildSwitchs[buildTypeValue])
			{


				GUIContent iconContent = new GUIContent("");
				GUILayout.BeginHorizontal(iconContent, style_box_key);
				int column = 0;
				for(int i = 0; i < colorEnables.Length; i ++)
				{
					if(colorEnables[i])
					{
						GUILayout.Space(10);
						GUILayout.Label(colorNames[i], style_box_key, GUILayout.Width(100) ,  GUILayout.Height(18));
						GUILayout.Space(10);
						column ++;
					}
				}
				GUILayout.EndHorizontal();


				foreach(KeyValuePair<int, BuildConfig> kvp in War.model.buildConfigs)
				{
					BuildConfig buildConfig = kvp.Value;

					if ((int)buildConfig.buildType != buildTypeValue + 1)
						continue;

					GUILayout.Space(20);

					foreach(KeyValuePair<int, BuildLevelConfig> levelKVP in buildConfig.levels)
					{
						BuildLevelConfig levelConfig = levelKVP.Value;
						if(levelEnables[levelConfig.level - 1] == false)
						{
							continue;
						}

						EditorGUILayout.BeginHorizontal(GUILayout.Width(column * 120));
						for(int i = 0; i < colorEnables.Length; i ++)
						{
							if(colorEnables[i])
							{

								AvatarConfig avatarConfig = Goo.avatar.GetConfig(levelConfig.avatarId);
								string file = avatarConfig.GetModelPath(colorIds[i]);

								GameObject prefab = WarRes.GetPrefab(file);
								if(prefab)
								{
									GUILayout.Space(10);
									EditorGUILayout.BeginVertical();
									SpriteAvatar spriteAvatar = prefab.GetComponent<SpriteAvatar>();
									Sprite sprite = spriteAvatar.avatarData.avatarActions[0].clips[0].frames[0];
									if(GUILayout.Button(sprite.texture, GUILayout.Width(100), GUILayout.Height(100)))
									{
										Click_Build(colorIds[i], levelConfig.level, buildConfig);
									}
									GUILayout.Label(buildConfig.id + " " + levelConfig.name, style_label_icon_hasbg, GUILayout.Width(100));
								
									if (levelConfig.basepropId > 0) 
									{
										GUILayout.Label ("<color=#55AAAA><b>#" + levelConfig.basepropId + " 基本属性</b></color>", style_label_prop);
										foreach (Prop prop in levelConfig.basepropConfig.props) {
											GUILayout.Label ("<color=#88AAAA>" + prop.id + " " + prop.Name + ":" + prop.ValueStr + "</color>", style_label_prop, GUILayout.Width (150));
										}
									}

									if (levelConfig.produceId > 0) 
									{
										GUILayout.Space(5);
										GUILayout.Label ("<color=#55AA55><b>#" + levelConfig.produceId + " 生产属性</b></color>", style_label_prop);
										foreach (Prop prop in levelConfig.produceConfig.props) {
											GUILayout.Label ("<color=#88AA88>" + prop.id + " " + prop.Name + ":" + prop.ValueStr + "</color>", style_label_prop, GUILayout.Width (150));
										}
									}

									if (levelConfig.turretId > 0) 
									{
										GUILayout.Space(5);
										GUILayout.Label ("<color=#AA5555><b>#" + levelConfig.turretId + " 箭塔属性</b></color>", style_label_prop);
										foreach (Prop prop in levelConfig.turretConfig.props) {
											GUILayout.Label ("<color=#AA8888>" + prop.id + " " + prop.Name + ":" + prop.ValueStr + "</color>", style_label_prop, GUILayout.Width (150));
										}
									}

									if (levelConfig.spotId > 0) 
									{
										GUILayout.Space(5);
										GUILayout.Label ("<color=#5555AA><b>#" + levelConfig.spotId + " 据点属性</b></color>", style_label_prop);
										foreach (Prop prop in levelConfig.spotConfig.props) {
											GUILayout.Label ("<color=#8888AA>" + prop.id + " " + prop.Name + ":" + prop.ValueStr + "</color>", style_label_prop, GUILayout.Width (150));
										}
									}

									EditorGUILayout.EndVertical();
									GUILayout.Space(10);

								}
								else
								{
									GUILayout.Space(10);
									GUILayout.Button("没有资源", GUILayout.Width(100), GUILayout.Height(100));
									GUILayout.Space(10);

									WarEditor.LoadRes(file);
								}
							}
						}
						EditorGUILayout.EndHorizontal();

					}


					GUILayout.Space(20);
				}
			}
			EditorGUILayout.EndVertical();
		}





		private Dictionary<Sprite, Texture2D> wall_icon_dict = new Dictionary<Sprite, Texture2D>();
		void GUI_Wall()
		{
			EditorGUILayout.BeginVertical(style_box_marginleft);
			
			foreach(KeyValuePair<int, BuildWallConfig> kvp in War.model.buildWallConfigs)
			{
				BuildWallConfig wallConfig = kvp.Value;

				GUILayout.Space(10);
				EditorGUILayout.BeginHorizontal();
				
				GUILayout.Label(wallConfig.id + "", style_label_wall_id, GUILayout.Width(50), GUILayout.Height(100));

				AvatarConfig avatarConfig = Goo.avatar.GetConfig(wallConfig.avatarId);
				GameObject prefab  = null;
				if(avatarConfig != null)
				{
					prefab = WarRes.GetPrefab(avatarConfig.model);
				}

				if(prefab)
				{

					SpriteAvatar spriteAvatar = prefab.GetComponent<SpriteAvatar>();
					Sprite sprite = spriteAvatar.avatarData.avatarActions[0].GetSpriteAnimationClip(wallConfig.angle).frames[0];

					
					Texture2D tex = null;
					if(!wall_icon_dict.TryGetValue(sprite, out tex))
					{
						tex = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height, TextureFormat.RGBA32, false);

						Color[] pixels = sprite.texture.GetPixels((int)sprite.rect.xMin, (int)sprite.rect.yMin,
						                                          (int)sprite.rect.width, (int)sprite.rect.height);
						tex.SetPixels(pixels);
						tex.Apply();
						wall_icon_dict.Add(sprite, tex);
					}

					if(GUILayout.Button(tex, GUILayout.Width(100), GUILayout.Height(100)))
					{
						Click_Wall(wallConfig);
					}
				}
				else
				{
					GUILayout.Button("没有资源", GUILayout.Width(100), GUILayout.Height(100));

					if(avatarConfig != null)
					{
						WarEditor.LoadRes(avatarConfig.model);
					}
				}

				
				GUILayout.Label(wallConfig.name, style_label_wall_line, GUILayout.Width(100), GUILayout.Height(100));
				GUILayout.Label(wallConfig.wallType == WallType.Cube ? "立方体" : "球", style_label_wall_line, GUILayout.Width(50), GUILayout.Height(100));
				if(wallConfig.wallType == WallType.Cube)
				{
					GUILayout.Label("角度:" + wallConfig.angle, style_label_wall_line, GUILayout.Width(100), GUILayout.Height(100));
					GUILayout.Label("大小:" + wallConfig.size.x + "x" + wallConfig.size.z, style_label_wall_line, GUILayout.Width(100), GUILayout.Height(100));
				}
				else
				{
					GUILayout.Label("半径:" + wallConfig.radius, style_label_wall_line, GUILayout.Width(100), GUILayout.Height(100));
				}


				EditorGUILayout.EndHorizontal();
				GUILayout.Space(10);
				GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
			}
			EditorGUILayout.EndVertical();
			
		}


	}
}
