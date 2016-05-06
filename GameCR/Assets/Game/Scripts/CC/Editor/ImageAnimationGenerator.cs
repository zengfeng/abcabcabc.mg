using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

namespace CC.Editors
{
	public class ImageAnimationGenerator : EditorWindow 
	{
		
		/** 生成出的Prefab的路径 */
		private static string PrefabPath = "Assets/Resources/Prefabs";
		/** 生成出的AnimationController的路径 */
		private static string AnimationControllerPath = "Assets/AnimationController";
		/** 生成出的Animation的路径 */
		private static string AnimationPath = "Assets/Animation";
		/** 美术给的原始图片路径 */
		private static string ImagePath = Application.dataPath +"/ZF/TestAnimator";

		
		
		[MenuItem("Assets/CC/ImageAnimationClip", false, 1)]
		public static void BuildAnimationClip() 
		{
			string imagePath = AssetDatabase.GetAssetPath(Selection.activeObject);
			BuildAnimationClip(imagePath, false);
		}

		
		public static List<AnimationClip> BatchBuildAnimationClip(string dirPath, bool hasAngle = false, bool hasType = false)
		{
			dirPath = dirPath.Replace('\\', '/');
			dirPath = dirPath.Substring(dirPath.IndexOf('/'));
			dirPath = Application.dataPath + "/" + dirPath;
			dirPath = dirPath.Replace('\\', '/');
			DirectoryInfo unit = new DirectoryInfo (dirPath);

			List<AnimationClip> clips = new List<AnimationClip>();


			if(hasAngle)
			{
				foreach (DirectoryInfo angleDictorys in unit.GetDirectories()) 
				{
					foreach (DirectoryInfo dictorys in angleDictorys.GetDirectories()) 
					{
						AnimationClip clip = BuildAnimationClip(dictorys, hasAngle, hasType);
						clips.Add(clip);
					}
				}
			}
			else
			{
				foreach (DirectoryInfo dictorys in unit.GetDirectories()) 
				{
					Debug.Log(dictorys.FullName);
					AnimationClip clip = BuildAnimationClip(dictorys, hasAngle, hasType);
					clips.Add(clip);
				}
			}

			return clips;
		}


		public static AnimationClip BuildAnimationClip(string dirPath, bool hasAngle = false, bool hasType = false)
		{
			dirPath = dirPath.Replace('\\', '/');
			dirPath = dirPath.Substring(dirPath.IndexOf('/'));
			dirPath = Application.dataPath + "/" + dirPath;
			dirPath = dirPath.Replace('\\', '/');
			DirectoryInfo dir = new DirectoryInfo (dirPath);
			return BuildAnimationClip(dir, hasAngle, hasType);
		}

		public static AnimationClip BuildAnimationClip(DirectoryInfo dictorys, bool hasAngle = false, bool hasType = false)
		{
			string animationName = dictorys.Name;
			string parentName = Directory.GetParent(dictorys.FullName).Name;

			if(hasAngle)
			{
				animationName = Directory.GetParent(dictorys.FullName).Name + "_"+ dictorys.Name;
				parentName = Directory.GetParent(Directory.GetParent(dictorys.FullName).FullName).Name;
			}

			if(hasType)
			{
				parentName = Directory.GetParent(Directory.GetParent(Directory.GetParent(dictorys.FullName).FullName).FullName).Name;
				parentName += "/" + Directory.GetParent(Directory.GetParent(dictorys.FullName).FullName).Name;
			}



			//查找所有图片，因为我找的测试动画是.jpg 
			FileInfo []images  = dictorys.GetFiles("*.png");
			AnimationClip clip = new AnimationClip();
			//		AnimationUtility.SetAnimationType(clip,ModelImporterAnimationType.Generic);
			EditorCurveBinding curveBinding = new EditorCurveBinding();
			curveBinding.type = typeof(Image);
			curveBinding.path="";
			curveBinding.propertyName = "m_Sprite";
			ObjectReferenceKeyframe[] keyFrames = new ObjectReferenceKeyframe[images.Length];
			//动画长度是按秒为单位，1/10就表示1秒切10张图片，根据项目的情况可以自己调节
			float frameTime = 1/10f;
			for(int i =0; i< images.Length; i++){
				Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(DataPathToAssetPath(images[i].FullName));
				keyFrames[i] =   new ObjectReferenceKeyframe ();
				keyFrames[i].time = frameTime *i;
				keyFrames[i].value = sprite;
			}
			//动画帧率，30比较合适
			clip.frameRate = 30;
			
			//有些动画我希望天生它就动画循环
			if(animationName.IndexOf("idle") >=0 || animationName.IndexOf("run") >= 0)
			{
				//设置idle文件为循环动画
				SerializedObject serializedClip = new SerializedObject(clip);
				AnimationClipSettings clipSettings = new AnimationClipSettings(serializedClip.FindProperty("m_AnimationClipSettings"));
				clipSettings.loopTime = true;
				serializedClip.ApplyModifiedProperties();
			}


			string path = AnimationPath +"/"+parentName +"/" +animationName+".anim";
			CheckPath(path, true);
			AnimationUtility.SetObjectReferenceCurve(clip,curveBinding,keyFrames);
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
		
		
		class AnimationClipSettings
		{
			SerializedProperty m_Property;
			
			private SerializedProperty Get (string property) { return m_Property.FindPropertyRelative(property); }
			
			public AnimationClipSettings(SerializedProperty prop) { m_Property = prop; }
			
			public float startTime   { get { return Get("m_StartTime").floatValue; } set { Get("m_StartTime").floatValue = value; } }
			public float stopTime	{ get { return Get("m_StopTime").floatValue; }  set { Get("m_StopTime").floatValue = value; } }
			public float orientationOffsetY { get { return Get("m_OrientationOffsetY").floatValue; } set { Get("m_OrientationOffsetY").floatValue = value; } }
			public float level { get { return Get("m_Level").floatValue; } set { Get("m_Level").floatValue = value; } }
			public float cycleOffset { get { return Get("m_CycleOffset").floatValue; } set { Get("m_CycleOffset").floatValue = value; } }
			
			public bool loopTime { get { return Get("m_LoopTime").boolValue; } set { Get("m_LoopTime").boolValue = value; } }
			public bool loopBlend { get { return Get("m_LoopBlend").boolValue; } set { Get("m_LoopBlend").boolValue = value; } }
			public bool loopBlendOrientation { get { return Get("m_LoopBlendOrientation").boolValue; } set { Get("m_LoopBlendOrientation").boolValue = value; } }
			public bool loopBlendPositionY { get { return Get("m_LoopBlendPositionY").boolValue; } set { Get("m_LoopBlendPositionY").boolValue = value; } }
			public bool loopBlendPositionXZ { get { return Get("m_LoopBlendPositionXZ").boolValue; } set { Get("m_LoopBlendPositionXZ").boolValue = value; } }
			public bool keepOriginalOrientation { get { return Get("m_KeepOriginalOrientation").boolValue; } set { Get("m_KeepOriginalOrientation").boolValue = value; } }
			public bool keepOriginalPositionY { get { return Get("m_KeepOriginalPositionY").boolValue; } set { Get("m_KeepOriginalPositionY").boolValue = value; } }
			public bool keepOriginalPositionXZ { get { return Get("m_KeepOriginalPositionXZ").boolValue; } set { Get("m_KeepOriginalPositionXZ").boolValue = value; } }
			public bool heightFromFeet { get { return Get("m_HeightFromFeet").boolValue; } set { Get("m_HeightFromFeet").boolValue = value; } }
			public bool mirror { get { return Get("m_Mirror").boolValue; } set { Get("m_Mirror").boolValue = value; } }
		}











	}
}
