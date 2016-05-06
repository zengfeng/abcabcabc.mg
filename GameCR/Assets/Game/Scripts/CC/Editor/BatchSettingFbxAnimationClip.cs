using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

namespace CC.Editors
{
	public class BatchSettingFbxAnimationClip : EditorWindow 
	{
		
		[MenuItem ("CC/批量设置Fbx动作", false, 12)]
		static void ShowWindow () 
		{
			GetPrefs();
			BatchSettingFbxAnimationClip tm = EditorWindow.GetWindow<BatchSettingFbxAnimationClip>("批量设置Fbx动作");
		}

		public static void SavePrefs()
		{
			for(int i = 0; i < modeList.Count; i ++)
			{
				string clipNames = string.Join("\n", modeList[i]);
				PlayerPrefs.SetString("CC.Editors.BatchSettingFbxAnimationClip.modeNames_" + i, clipNames);
			}
			
			PlayerPrefs.SetInt("CC.Editors.BatchSettingFbxAnimationClip.modeList.Count" , modeList.Count);
			PlayerPrefs.Save();
		}

		public static void GetPrefs()
		{
			if(PlayerPrefs.HasKey("CC.Editors.BatchSettingFbxAnimationClip.modeList.Count"))
			{
				int count = PlayerPrefs.GetInt("CC.Editors.BatchSettingFbxAnimationClip.modeList.Count" );

				modeList.Clear();
				
				for(int i = 0; i < count; i ++)
				{
					string clipNames = PlayerPrefs.GetString("CC.Editors.BatchSettingFbxAnimationClip.modeNames_" + i);
					string[] clips = clipNames.Split('\n');
					modeList.Add(clips);
				}
			}
		}

		public static string[] modeNames = new string[]{"Mode 1", "Mode 2"};
		public static List<string[]> modeList = new List<string[]>( new string[][]{
			new string[]{"idle", "run", "walk"},
			new string[]{"idle", "run", "walk", "dance"},
			new string[]{"idle", "run", "walk", "dance", "idle1", "idle2", "idle3", "idle4", "run1", "run2", "run3", "run4", "run1_fast", "laugh", "joke", "joke_darius", "joke_katarina" }
			} );

		public static int modeIndex = 0;
		private static int _modeIndex = -1;
		public static string[] loopClips = new string[]{"idle", "run", "walk"};
		public static string clipNames = "";

		void OnGUI()
		{
			modeNames = new string[modeList.Count];
			for(int i = 0; i < modeList.Count; i ++)
			{
				modeNames[i] = "模式 " + (i + 1);
			}

			modeIndex = EditorGUILayout.Popup("模式", modeIndex, modeNames);
			if(_modeIndex != modeIndex)
			{
				_modeIndex = modeIndex;
				
				loopClips = modeList[modeIndex];
				clipNames = string.Join("\n", loopClips);
			}

			EditorGUILayout.Space();
			EditorGUILayout.LabelField("动作列表");
			clipNames = EditorGUILayout.TextArea(clipNames, GUILayout.MinHeight(100));


			if(GUILayout.Button("添加模式"))
			{
				string[] arr = clipNames.Split('\n');
				List<string> list = new List<string>();
				foreach(string item in arr)
				{
					string str = item.Trim();
					if(list.IndexOf(str) == -1)
					{
						list.Add(str);
					}
				}

				loopClips = list.ToArray();
				modeList.Add(loopClips);
				modeIndex = modeList.Count - 1;

				SavePrefs();
			}

			
			if(modeIndex >= 3)
			{
				if(GUILayout.Button("删除模式"))
				{
					modeList.RemoveAt(modeIndex);
					if(modeIndex >= modeList.Count)
					{
						modeIndex = modeList.Count - 1;
					}
					SavePrefs();
				}
			}

			if(Selection.activeObject == null)
			{
				GUILayout.Label("请选着你要处理的动作目录");
			}
			else
			{
				
				string path = AssetDatabase.GetAssetPath(Selection.activeObject);
				if(string.IsNullOrEmpty(path) || (File.GetAttributes(path) & FileAttributes.Directory) != FileAttributes.Directory)
				{
					GUILayout.Label("请选着你要处理的动作目录，记住是目录哦哦哦哦！！！");
				}
				else
				{
					if(GUILayout.Button("(选着目录)批量设置"))
					{
						string[] arr = clipNames.Split('\n');
						List<string> list = new List<string>();
						foreach(string item in arr)
						{
							string str = item.Trim();
							if(list.IndexOf(str) == -1)
							{
								list.Add(str);
							}
						}
						loopClips = list.ToArray();
						
						Setting(path, loopClips);
					}
				}
			}


		}

		public static void Setting(string path, string[] loopClips)
		{
			List<string> clipPaths = new List<string>();
			Find(path, clipPaths);

			int numFiles = clipPaths.Count;
			int index = 0;
			foreach(string clipPath in clipPaths)
			{
				index++;
				if (EditorUtility.DisplayCancelableProgressBar("Setting Fbx Clip" , index + "/" + numFiles + " "+ clipPath, (float)index/(float)numFiles))
					break;

				ModelImporter mi = AssetImporter.GetAtPath(clipPath) as ModelImporter;

				if(mi == null) continue;
				mi.importMaterials = false;
				ModelImporterClipAnimation[] clips = mi.defaultClipAnimations;

				ModelImporterClipAnimation[] myclips = new ModelImporterClipAnimation[clips.Length];
				for(int i = 0; i < clips.Length; i ++)
				{

					ModelImporterClipAnimation clip = clips[i];
					myclips[i] = clip;
//					clip.loop = true;
//					clip.loopTime = true;
//					ModelImporterClipAnimation mc = myclips[i] = new ModelImporterClipAnimation();
//					mc.name = clip.name;
//					mc.takeName = clip.takeName;
//					mc.firstFrame = clip.firstFrame;
//					mc.lastFrame = clip.lastFrame;
//					mc.loop = true;
//					mc.loopTime = true;
					if(ArrayUtility.IndexOf<string>(loopClips, clip.name ) != -1)
					{
						clip.loop = true;
						clip.loopTime = true;
					}
					else
					{
						clip.loop = false;
						clip.loopTime = false;
					}
//					Debug.Log(string.Format("name={0}, loop={1}, loopTime={2}, path={3}", clip.name, clip.loop,clip.loopTime, clipPath));
				}
				mi.clipAnimations = myclips;

				mi.SaveAndReimport();
			}
			
			EditorUtility.ClearProgressBar();

		}

		public static void Find(string path, List<string> clips)
		{
			string[] filePaths = Directory.GetFiles(path);
			
			foreach(string filePath in  filePaths)
			{
				AnimationClip clip =AssetDatabase.LoadAssetAtPath<AnimationClip>(filePath);
				if(clip != null)
				{
					clips.Add(filePath);
				}
			}

			string[] dirPaths = Directory.GetDirectories(path);
			foreach(string dirPath in dirPaths)
			{
				Find(dirPath, clips);
			}

		}

	}
}