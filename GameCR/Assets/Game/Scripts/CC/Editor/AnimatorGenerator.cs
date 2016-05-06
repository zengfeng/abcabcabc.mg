using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Collections.Generic;


namespace CC.Editors
{
	public class AnimatorGenerator
	{
		[MenuItem("Assets/CC/Animator/生成单位动画控制器(AnimatorController)", false, 4)]
		public static void BuildAnimatorController()
		{
			if(Selection.activeObject == null)
			{
				return;
			}


			string root = AssetDatabase.GetAssetPath(Selection.activeObject);
			List<AnimationClip> clips = new List<AnimationClip>();
			BuildAnimatorController(root, clips);

			DirectoryInfo rootDir = new DirectoryInfo(root);
			string controllerPath = root +"/"+rootDir.Name+".controller";
			UnityEditor.Animations.AnimatorController animatorController = BuildAnimatorController(clips, controllerPath);

			
			GameObject model =AssetDatabase.LoadAssetAtPath<GameObject>(root + "/" + rootDir.Name + ".dae");
			Animator animator = model.GetComponent<Animator>();
			animator.runtimeAnimatorController = animatorController;
			Debug.Log("animator=" + animator );
		}

		public static void BuildAnimatorController(string path, List<AnimationClip> clips)
		{
			string[] filePaths = Directory.GetFiles(path);

			foreach(string filePath in  filePaths)
			{
				AnimationClip clip =AssetDatabase.LoadAssetAtPath<AnimationClip>(filePath);
				if(clip != null)
				{
					clips.Add(clip);
				}
			}
		}


		public static UnityEditor.Animations.AnimatorController BuildAnimatorController(List<AnimationClip> clips, string path)
		{
			CheckPath(path);

			
			UnityEditor.Animations.AnimatorController animatorController = UnityEditor.Animations.AnimatorController.CreateAnimatorControllerAtPath(path);
			UnityEditor.Animations.AnimatorControllerLayer layer = animatorController.layers[0];
			UnityEditor.Animations.AnimatorStateMachine sm = layer.stateMachine;

			foreach(AnimationClip clip in clips)
			{
				UnityEditor.Animations.AnimatorState  state = sm.AddState(clip.name);
				state.motion = clip;
				
				if(clip.name.IndexOf("idle") != -1)
				{
					sm.defaultState = state;
				}
			}
			AssetDatabase.SaveAssets();
			return animatorController;
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