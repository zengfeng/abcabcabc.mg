using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using Games.Module.Avatars;
using System;

namespace Game.Editors
{
	public class SpriteAvatarGenerator : EditorWindow 
	{
		/** 生成出的Prefab的路径 */
		private static string PrefabPath = "Assets/Game/Res/unit_Prefab";
		/** 生成出的AvatarData的路径 */
		private static string AvatarDataPath = "Assets/Game/Res/data/avatar";
		/** 生成出的AvatarAction的路径 */
		private static string AvatarActionPath = "Assets/Game/Res/data/avataraction";
		/** 生成出的SpriteAnimation的路径 */
		private static string SpriteAnimationPath = "Assets/Game/Res/data/spriteanimation";

		
		private static string typeName;
		private static string unitName;
		private static string fileFormat = "*.png";
		private static string[] loopActions = new string[]{"idle", "run", "walk"};
		private static float deltaAngle = 90;
		private static float offsetAngle = 0;
		private static float frameTime = 0.08333F;
		private static bool needFlip = false;
		private static int backAngle = 45;
		private static int frontAngle = 135;
		private static float defaultAngle = 180;
		private static string defaultAction = "idle";
		private static bool addAvatarInfo = false;

		
		[MenuItem("Assets/Avatar/生成单位 30度(动作_方向)", false, 1045)]
		public static void BuildUnit_30_Action_Angle() 
		{
			addAvatarInfo = true;
			fileFormat = "*.png";
			deltaAngle = 30F;
			offsetAngle = 0F;
			frameTime = 0.08333F;
			needFlip = false;
			loopActions = new string[]{"idle", "run", "walk", "die", "attack", "win"};
			
			defaultAngle = 0;
			defaultAction = "idle";
			
			
			Build_Action_Angle();
		}


		
		[MenuItem("Assets/Avatar/生成单位 45度(动作_方向)", false, 1045)]
		public static void BuildUnit_45_Action_Angle() 
		{
			addAvatarInfo = true;
			fileFormat = "*.png";
			deltaAngle = 45F;
			offsetAngle = 0F;
			frameTime = 0.08333F;
			needFlip = false;
			loopActions = new string[]{"idle", "run", "walk", "die", "attack", "win"};
			
			defaultAngle = 180;
			defaultAction = "idle";
			
			
			Build_Action_Angle();
		}

		[MenuItem("Assets/Avatar/生成单位 45度 需要镜像(动作_方向)", false, 1045)]
		public static void BuildUnit_45_Action_Angle_Flip() 
		{
			addAvatarInfo = true;
			fileFormat = "*.png";
			deltaAngle = 45F;
			offsetAngle = 0F;
			frameTime = 0.08333F;
			needFlip = true;
			loopActions = new string[]{"idle", "run", "walk", "die", "attack", "win"};
			
			defaultAngle = 180;
			defaultAction = "idle";
			
			Build_Action_Angle();
		}

		
		[MenuItem("Assets/Avatar/生成单位 90度 需要镜像(动作_方向)", false, 1090)]
		public static void BuildUnit_90_Action_Angle_Flip() 
		{
			addAvatarInfo = true;
			fileFormat = "*.png";
			deltaAngle = 90F;
			offsetAngle = 0F;
			frameTime = 0.08333F;
			needFlip = true;
			loopActions = new string[]{"idle", "run", "walk"};
			
			defaultAngle = 180;
			defaultAction = "idle";

			Build_Action_Angle();
		}

		
		
		[MenuItem("Assets/Avatar/生成单位 90度 需要镜像(方向_动作)", false, 1090)]
		public static void BuildUnit_90_Angle_Action_Flip() 
		{
			addAvatarInfo = true;
			fileFormat = "*.png";
			deltaAngle = 90F;
			offsetAngle = 0F;
			frameTime = 0.08333F;
			needFlip = true;
			loopActions = new string[]{"idle", "run", "walk"};
			
			defaultAngle = 180;
			defaultAction = "idle";
			
			Build_Angle_Action();
		}

		
//		[MenuItem("Assets/Avatar/兵营(等级)", false, 1090)]
//		public static void BuildUnit_Casern() 
//		{
//			fileFormat = "*.png";
//			deltaAngle = 360F;
//			offsetAngle = 0F;
//			frameTime = 0.08333F;
//			needFlip = true;
//			loopActions = new string[]{"idle", "run", "walk"};
//
//			
//			defaultAngle = 0;
//			defaultAction = "level1";
//			
//			Build_Level();
//		}

		
		[MenuItem("Assets/Avatar/兵营(动作等级)", false, 1090)]
		public static void BuildUnit_Casern_Color() 
		{
			addAvatarInfo = false;
			fileFormat = "*.png";
			deltaAngle = 360F;
			offsetAngle = 0F;
			frameTime = 0.08333F;
			needFlip = true;
			loopActions = new string[]{"idle", "run", "walk"};
			
			
			defaultAngle = 0;
			defaultAction = "idel_level1";
			
			Build_Level();
		}




		
		[MenuItem("Assets/Avatar/生成单位 90度 偏移45度 需要镜像(方向_动作)", false, 1090)]
		public static void BuildUnit_90_Angle_Action_Flip_Offest45() 
		{
			addAvatarInfo = true;
			fileFormat = "*.png";
			deltaAngle = 90F;
			offsetAngle = -45F;
			frameTime = 0.08333F;
			needFlip = true;
			loopActions = new string[]{"idle", "run", "walk"};
			
			backAngle = 45;
			frontAngle = 135;
			
			defaultAngle = 180;
			defaultAction = "idle";
			
			Build_Angle_Action();
		}

		
		
		[MenuItem("Assets/Avatar/批量生成单位 90度 偏移45度 需要镜像(方向_动作)", false, 2090)]
		public static void BatchBuildUnit_90_Angle_Action_Flip_Offest45() 
		{
			addAvatarInfo = true;
			fileFormat = "*.png";
			deltaAngle = 90F;
			offsetAngle = -45F;
			frameTime = 0.08333F;
			needFlip = true;
			loopActions = new string[]{"idle", "run", "walk"};
			
			backAngle = 45;
			frontAngle = 135;
			
			defaultAngle = 180;
			defaultAction = "idle";


			int i = 0;
			int count = Selection.objects.Length;
			foreach(UnityEngine.Object obj in  Selection.objects)
			{
				
				if (EditorUtility.DisplayCancelableProgressBar("Build AvatarData", i + "/" + count, (float)i/(float)count))
					break;
				string unitPath = AssetDatabase.GetAssetPath(obj);
				Debug.Log("unitPath=" + unitPath);
				Build_Angle_Action(unitPath);
			}
			
			EditorUtility.ClearProgressBar();
		}

		
		//---------------------------------------------
		public static void Build_Color_Level()
		{
			string unitPath = AssetDatabase.GetAssetPath(Selection.activeObject);
			Build_Color_Level(unitPath);
			EditorUtility.ClearProgressBar();
		}
		
		public static void Build_Color_Level(string unitPath)
		{
			DirectoryInfo unitDirectory = new DirectoryInfo (unitPath);
			unitName = unitDirectory.Name;
			typeName = unitDirectory.Parent.Name;
			
			
			Dictionary<string, List<SpriteAnimationClip>> actionDictionary = new Dictionary<string, List<SpriteAnimationClip>>();

			foreach(DirectoryInfo colorDirectory in unitDirectory.GetDirectories())
			{
				int i = 0;
				int count = colorDirectory.GetDirectories().Length;
				foreach(DirectoryInfo levelDirectory in colorDirectory.GetDirectories())
				{
					i++;
					string actionName = colorDirectory.Name + "_"+levelDirectory.Name;
					int angle = 0;
					bool loop = false;
					bool flip = false;
					
					List<SpriteAnimationClip> clips = null;
					if(!actionDictionary.TryGetValue(actionName, out clips))
					{
						clips = new List<SpriteAnimationClip>();
						actionDictionary.Add(actionName, clips);
					}
					
					
					if (EditorUtility.DisplayCancelableProgressBar("Build_Level " + typeName + "/"+ unitName + "/" + actionName , i + "/" + count, (float)i/(float)count))
						break;
					SpriteAnimationClip clip = BuildClip(levelDirectory, angle, actionName, loop, flip);
					clip.loop = clip.frames.Length > 1;
					clips.Add(clip);
				}
				
			}
			
			List<AvatarAction> actions = BuildActions(actionDictionary);
			AvatarData avatar = BuildAvatarData(actions);
			BuildPrefab(avatar);
		}
		
		//---------------------------------------------
		public static void Build_Level()
		{
			string unitPath = AssetDatabase.GetAssetPath(Selection.activeObject);
			Build_Level(unitPath);
			EditorUtility.ClearProgressBar();
		}

		public static void Build_Level(string unitPath)
		{
			DirectoryInfo unitDirectory = new DirectoryInfo (unitPath);
			unitName = unitDirectory.Name;
			typeName = unitDirectory.Parent.Name;
			
			
			Dictionary<string, List<SpriteAnimationClip>> actionDictionary = new Dictionary<string, List<SpriteAnimationClip>>();
			
			int i = 0;
			int count = unitDirectory.GetDirectories().Length;
			foreach(DirectoryInfo actionDirectory in unitDirectory.GetDirectories())
			{
				string actionName = actionDirectory.Name;
				int angle = 0;
				bool loop = false;
				bool flip = false;

				List<SpriteAnimationClip> clips = null;
				if(!actionDictionary.TryGetValue(actionName, out clips))
				{
					clips = new List<SpriteAnimationClip>();
					actionDictionary.Add(actionName, clips);
				}

				
				if (EditorUtility.DisplayCancelableProgressBar("Build_Level " + typeName + "/"+ unitName + "/" + actionName , i + "/" + count, (float)i/(float)count))
					break;
				SpriteAnimationClip clip = BuildClip(actionDirectory, angle, actionName, loop, flip);
				clip.loop = clip.frames.Length > 1;
				clips.Add(clip);

			}
			
			List<AvatarAction> actions = BuildActions(actionDictionary);
			AvatarData avatar = BuildAvatarData(actions);
			BuildPrefab(avatar);
		}


		//------------------------------
		public static void Build_Action_Angle()
		{
			string unitPath = AssetDatabase.GetAssetPath(Selection.activeObject);
			Build_Action_Angle(unitPath);
			EditorUtility.ClearProgressBar();
		}

		public static void Build_Action_Angle(string unitPath)
		{
			DirectoryInfo unitDirectory = new DirectoryInfo (unitPath);
			unitName = unitDirectory.Name;
			typeName = unitDirectory.Parent.Name;
			
			
			Dictionary<string, List<SpriteAnimationClip>> actionDictionary = new Dictionary<string, List<SpriteAnimationClip>>();
			foreach(DirectoryInfo actionDirectory in unitDirectory.GetDirectories())
			{
				string actionName = actionDirectory.Name;
				int i = 0;
				int count = actionDirectory.GetDirectories().Length;
				foreach (DirectoryInfo angleDirectory in actionDirectory.GetDirectories()) 
				{
					int angle = 0;
					if(angleDirectory.Name == "back")
					{
						angle = backAngle;
					}
					else if(angleDirectory.Name == "front")
					{
						angle = frontAngle;
					}
					else
					{
						angle = Convert.ToInt32(angleDirectory.Name);
					}
					bool loop = ArrayUtility.IndexOf<string>(loopActions, actionName) != -1;
					bool flip = false;
					
					List<SpriteAnimationClip> clips = null;
					if(!actionDictionary.TryGetValue(actionName, out clips))
					{
						clips = new List<SpriteAnimationClip>();
						actionDictionary.Add(actionName, clips);
					}

					
					if (EditorUtility.DisplayCancelableProgressBar("Build_Action_Angle " + typeName + "/"+ unitName + "/" + actionName , i + "/" + count, (float)i/(float)count))
						break;
					SpriteAnimationClip clip = BuildClip(angleDirectory, angle, actionName, loop, flip);
					clips.Add(clip);
					
					if(needFlip)
					{
						if(angle != 0 && angle != 180)
						{
							angle = 360 - angle;
							flip = true;
							clip = BuildClip(angleDirectory, angle, actionName, loop, flip);
							clips.Add(clip);
						}
					}
				}
			}
			
			List<AvatarAction> actions = BuildActions(actionDictionary);
			AvatarData avatar = BuildAvatarData(actions);
			BuildPrefab(avatar);
		}

		//--------------------------------------------
		public static void Build_Angle_Action()
		{
			string unitPath = AssetDatabase.GetAssetPath(Selection.activeObject);
			Build_Angle_Action(unitPath);
			EditorUtility.ClearProgressBar();
		}

		public static void Build_Angle_Action(string unitPath)
		{
			DirectoryInfo unitDirectory = new DirectoryInfo (unitPath);
			unitName = unitDirectory.Name;
			typeName = unitDirectory.Parent.Name;

			Dictionary<string, List<SpriteAnimationClip>> actionDictionary = new Dictionary<string, List<SpriteAnimationClip>>();
			foreach (DirectoryInfo angleDirectory in unitDirectory.GetDirectories()) 
			{
				int i = 0;
				int count = angleDirectory.GetDirectories().Length;
				foreach(DirectoryInfo actionDirectory in angleDirectory.GetDirectories())
				{
					int angle = 0;
					if(angleDirectory.Name == "back")
					{
						angle = backAngle;
					}
					else if(angleDirectory.Name == "front")
					{
						angle = frontAngle;
					}
					else
					{
						angle = Convert.ToInt32(angleDirectory.Name);
					}

					string actionName = actionDirectory.Name;
					bool loop = ArrayUtility.IndexOf<string>(loopActions, actionName) != -1;
					bool flip = false;
					
					List<SpriteAnimationClip> clips = null;
					if(!actionDictionary.TryGetValue(actionName, out clips))
					{
						clips = new List<SpriteAnimationClip>();
						actionDictionary.Add(actionName, clips);
					}

					i++;
					if (EditorUtility.DisplayCancelableProgressBar("Build_Angle_Action " + typeName + "/"+ unitName + "/" + actionName , i + "/" + count, (float)i/(float)count))
						break;
					
					SpriteAnimationClip clip = BuildClip(actionDirectory, angle, actionName, loop, flip);
					clips.Add(clip);
					
					if(needFlip)
					{
						if(angle != 0 && angle != 180)
						{
							angle = 360 - angle;
							flip = true;
							clip = BuildClip(actionDirectory, angle, actionName, loop, flip);
							clips.Add(clip);
						}
					}
				}
			}
			
			List<AvatarAction> actions = BuildActions(actionDictionary);
			AvatarData avatar = BuildAvatarData(actions);
			BuildPrefab(avatar);
		}

		public static GameObject BuildPrefab(AvatarData avatarData)
		{
			GameObject go = new GameObject();
			go.name = unitName;
			SpriteRenderer spriteRender =go.AddComponent<SpriteRenderer>();
			Isometric isometric = go.AddComponent<Isometric>();
			isometric.faceCamera = true;
			go.AddComponent<SpriteAnimation>();
			SpriteAvatar avatar = go.AddComponent<SpriteAvatar>();
			avatar.avatarData = avatarData;
			avatar.action = defaultAction;
			avatar.angle = defaultAngle;

			if(addAvatarInfo)
			{
				go.AddComponent<AvatarInfo>();
			}
			
			string path = PrefabPath + "/" + typeName + "/"+ unitName + ".prefab";
			CheckPath(path);
			PrefabUtility.CreatePrefab(path,go);
			DestroyImmediate(go);
			return go;
		}

		public static AvatarData BuildAvatarData(List<AvatarAction> actions)
		{
			AvatarData avatar = ScriptableObject.CreateInstance<AvatarData>();
			avatar.avatarActions = actions.ToArray();
			string path = AvatarDataPath + "/" + typeName + "/"+ unitName + ".asset";
			CheckPath(path);
			AssetDatabase.CreateAsset(avatar, path);
			AssetDatabase.SaveAssets();
			return avatar;
		}

		public static List<AvatarAction> BuildActions(Dictionary<string, List<SpriteAnimationClip>> actionDictionary)
		{
			List<AvatarAction> actions = new List<AvatarAction>();
			foreach(KeyValuePair<string, List<SpriteAnimationClip>> kvp  in actionDictionary)
			{
				string actionName = kvp.Key;
				List<SpriteAnimationClip> clips = kvp.Value;
				clips.Sort(
					delegate(SpriteAnimationClip s1, SpriteAnimationClip s2)
					{
					return s1.angle.CompareTo(s2.angle);
					}
				);
				AvatarAction action = ScriptableObject.CreateInstance<AvatarAction>();
				action.action = actionName;
				action.clips = clips.ToArray();
				action.deltaAngle = deltaAngle;
				action.offsetAngle = offsetAngle;
				action.frameTime = frameTime;
				
				string path = AvatarActionPath + "/" + typeName + "/"+ unitName + "/" + actionName + ".asset";
				CheckPath(path);
				AssetDatabase.CreateAsset(action, path);
				AssetDatabase.SaveAssets();
				actions.Add(action);
			}
			return actions;
		}

		public static SpriteAnimationClip BuildClip(DirectoryInfo directory, int angle, string actionName, bool loop = false, bool flip= false)
		{
			
			FileInfo[] files  = directory.GetFiles(fileFormat);

			
			List<Sprite> sprites = new List<Sprite>();
			foreach(FileInfo file in files)
			{
				Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(DataPathToAssetPath(file.FullName));
				sprites.Add(sprite);
			}

			sprites.Sort(
				delegate(Sprite s1, Sprite s2)
				{
				return s1.name.CompareTo(s2.name);
			}
			);


			SpriteAnimationClip clip = ScriptableObject.CreateInstance<SpriteAnimationClip>();
			clip.frames = sprites.ToArray();
			clip.actionName = actionName;
			clip.angle = angle;
			clip.loop = loop;
			clip.flip = flip;

			string path = SpriteAnimationPath + "/" + typeName + "/"+ unitName + "/" + actionName + "_" + angle + ".asset";

			CheckPath(path);
			AssetDatabase.CreateAsset(clip, path);
			AssetDatabase.SaveAssets();
			return clip;
		}

		
		public static string DataPathToAssetPath(string path)
		{
			if (Application.platform == RuntimePlatform.WindowsEditor)
				return path.Substring(path.IndexOf("Assets\\"));
			else
				return path.Substring(path.IndexOf("Assets/"));
		}

		
		public static void CheckPath(string path, bool isFile = true)
		{
			if(isFile) path = path.Substring(0, path.LastIndexOf('/'));
			path = path.Replace("Assets", "");
			string[] dirs = path.Split('/');
			string target = Application.dataPath;
			string parent = "Assets";
			foreach(string dir in dirs)
			{
				if(string.IsNullOrEmpty(dir)) continue;
				target +="/"+ dir;
				if(!Directory.Exists(target))
				{
					AssetDatabase.CreateFolder(parent, dir);
				}
				parent += "/"+ dir;
			}
		}


	}
}