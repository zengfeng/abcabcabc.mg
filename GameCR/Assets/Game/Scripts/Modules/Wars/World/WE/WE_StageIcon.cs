#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using Games.Module.Wars;
using System.Collections.Generic;
using System.IO;

public class WE_StageIcon : MonoBehaviour 
{
	static string stageIconRoot = "Assets/EditorDefaultResources/StageIcon/";

	void OnEnable()
	{
		PathUtil.CheckPath(stageIconRoot, false);
		StartCoroutine(Doing());
	}

	IEnumerator Doing()
	{
		foreach(KeyValuePair<int, StageConfig> kvp in War.model.stageConfigs_Index)
		{
			yield return new WaitForEndOfFrame();
			StageConfig stageConfig = kvp.Value;

			WarEnterData enterData = WarEnterData.CreateTest(stageConfig.id, 1, new int[][]{ }, new int[][]{ });
			War.isTest = true;
			War.isEditor = true;

			War.Clear();
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			War.Start(enterData);

			
			yield return new WaitForSeconds(2F);
			string filename = stageIconRoot + War.sceneData.id + ".png";
			ScreenshotTool.Shot(Camera.main, 300, 200, false, filename);

			yield return new WaitForEndOfFrame();

			string file_1920x1280 = Application.dataPath + "/../../../document/策划案/关卡截图/" + War.sceneData.id + ".png";
			PathUtil.CheckPath(file_1920x1280, true);
			ScreenshotTool.Shot(Camera.main, 1920, 1280, false, file_1920x1280);

			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
		}

		DestroyImmediate(this);
	}









}

#endif