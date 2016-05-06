
using UnityEngine;
using UnityEditor;
using System.Collections;
using Games.Module.Wars;
using CC.Runtime;

namespace Game.Editors.Wars
{
	public class WarEditor_Instance
	{
		public static void Run(StageConfig stageConfig)
		{
			
			WarEnterData enterData = WarEnterData.CreateTest(stageConfig.id, 1, new int[][]{ }, new int[][]{ });
			
			War.isTest = true;
			War.isEditor = false;
			if(Coo.menuManager != null)
			{
				Coo.menuManager.StartCoroutine(WarStart(enterData));
			}
			else
			{
				War.Start(enterData);
			}
		}


		public static void Open(StageConfig stageConfig)
		{
			if(!CheckOpen())
			{
				return;
			}
			
			WarEnterData enterData = WarEnterData.CreateTest(stageConfig.id, 1, new int[][]{ }, new int[][]{ });
			
			War.isTest = true;
			War.isEditor = true;
			if(Coo.menuManager != null)
			{
				Coo.menuManager.StartCoroutine(WarStart(enterData));
			}
			else
			{
				War.Start(enterData);
			}
		}

		static IEnumerator WarStart(WarEnterData enterData)
		{
			War.Clear();
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			War.Start(enterData);
		}


//		public static void Open(StageConfig stageConfig, EditorWindow window)
//		{
//			if(!CheckOpen())
//			{
//				return;
//			}
//			
//			WarEnterData enterData = WarEnterData.CreateTest(stageConfig.id, 1, new int[][]{ });
//
//			War.isTest = true;
//			War.isEditor = true;
//			War.Start(enterData);
//
//			GameObject.Find("Scene").GetComponent<WarManager>().Init();
//			GameObject.Find("Scene").GetComponent<WarScene>().Init();
//
//			Clear();
//			War.preload.Load();
//			War.sceneCreate.EditorGeneration();
//		}

		public static void Clear()
		{
			HUnityUtil.DestroyImmediateChilds(War.scene.rootCaserns);
			HUnityUtil.DestroyImmediateChilds(War.scene.rootPlayers);
			HUnityUtil.DestroyImmediateChilds(War.scene.rootHeros);
			HUnityUtil.DestroyImmediateChilds(War.scene.rootSoliders);
			HUnityUtil.DestroyImmediateChilds(War.scene.rootWalls);
			HUnityUtil.DestroyImmediateChilds(War.scene.rootUnitHP);
			HUnityUtil.DestroyImmediateChilds(War.scene.rootUnitClock);
			HUnityUtil.DestroyImmediateChilds(War.scene.rootUnitSOS);
			HUnityUtil.DestroyImmediateChilds(War.scene.rootTerrains);


		}

		public static bool CheckOpen()
		{
			if(EditorApplication.currentScene != WarEditor.ScenePath)
			{
				if(EditorApplication.SaveCurrentSceneIfUserWantsTo())
				{
					EditorApplication.OpenScene(WarEditor.ScenePath);
				}
				else
				{
					return false;
				}
			}
			else
			{
//				int option = EditorUtility.DisplayDialogComplex(
//					"关卡有修改",
//					"是否保存？",
//					"保存且继续",
//					"取消",
//					"不保存且继续");
//				
//				switch(option)
//				{
//				case 0:
//					break;
//				case 1:
//					return false;
//					break;
//				case 2:
//					break;
//				}
			}


			return true;
		}
	}

}