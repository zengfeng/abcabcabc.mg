using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using Games.Module.Avatars;
using System;

namespace Game.Editors
{
	public class SpriteAvatarGenerator_Effect : EditorWindow 
	{
		/** 生成出的Prefab的路径 */
		private static string PrefabPath = "Assets/Game/Res/Unit_Prefab";
		/** 生成出的AvatarData的路径 */
		private static string AvatarDataPath = "Assets/Game/Res/Data/Avatar";
		/** 生成出的AvatarAction的路径 */
		private static string AvatarActionPath = "Assets/Game/Res/Data/AvatarAction";
		/** 生成出的SpriteAnimation的路径 */
		private static string SpriteAnimationPath = "Assets/Game/Res/Data/SpriteAnimation";

		
		private static string typeName;
		private static string unitName;
		private static string fileFormat = "*.png";
		private static string[] loopActions = new string[]{"idle"};
		private static float deltaAngle = 360;
		private static float offsetAngle = 0;
		private static float frameTime = 0.08333F;
		private static bool needFlip = false;
		private static bool loop = false;
		private static bool autoDestory = false;
		private static float defaultAngle = 180;
		private static string defaultAction = "idle";




		
		
		[MenuItem("Assets/Avatar/生成特效", false, 1090)]
		public static void BuildEffect() 
		{
			fileFormat = "*.png";
			deltaAngle = 0F;
			offsetAngle = 0F;
			frameTime = 0.08333F;
			needFlip = true;
			loop = false;
			autoDestory = true;
			
			defaultAngle = 0;
			defaultAction = "idle";
			
			Build_Action();
		}

		
		
		[MenuItem("Assets/Avatar/生成特效循环", false, 1090)]
		public static void BuildEffect_Loop() 
		{
			fileFormat = "*.png";
			deltaAngle = 0F;
			offsetAngle = 0F;
			frameTime = 0.08333F;
			needFlip = true;
			loop = true;
			autoDestory = false;
			
			defaultAngle = 0;
			defaultAction = "idle";
			
			Build_Action();
		}



		

		public static void Build_Action()
		{
			string unitPath = AssetDatabase.GetAssetPath(Selection.activeObject);
			Build_Action(unitPath);
		}

		public static void Build_Action(string unitPath)
		{
			DirectoryInfo unitDirectory = new DirectoryInfo (unitPath);
			unitName = unitDirectory.Name;
			typeName = "Effect";

			
			Dictionary<string, List<SpriteAnimationClip>> actionDictionary = new Dictionary<string, List<SpriteAnimationClip>>();
			int angle = 0;
			string actionName = "idle";
			bool flip = false;
			
			List<SpriteAnimationClip> clips = new List<SpriteAnimationClip>();
			actionDictionary.Add(actionName, clips);
			
			SpriteAnimationClip clip = BuildClip(unitDirectory, angle, actionName, loop, flip);
			clips.Add(clip);
			
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
			if(autoDestory) go.AddComponent<AutoDestoryOnActionComplete>();
			
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
				
				string path = AvatarActionPath + "/" + typeName + "/"+ unitName  + ".asset";
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

			string path = SpriteAnimationPath + "/" + typeName + "/"+ unitName + ".asset";

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