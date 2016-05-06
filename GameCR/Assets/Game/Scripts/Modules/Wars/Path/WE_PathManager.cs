#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using Games.Module.Wars;
using System.Collections.Generic;
using System.IO;

public class WE_PathManager : MonoBehaviour 
{
	public List<int> filters = new List<int>(new int[]{40001, 400001});
	public List<StageConfig> configs = new List<StageConfig>();
	public int index = 0;
	public int count = 0;

	WE_StagePathManager stagePathManager ;

	void OnEnable()
	{

		stagePathManager = GameObject.Find("WarEditorScene").GetComponent<WE_StagePathManager>();
		stagePathManager.sFind += OnFindStage;

		foreach(KeyValuePair<int, StageConfig> kvp in War.model.stageConfigs_Index)
		{
			if (filters.Contains (kvp.Key))
				continue;
			configs.Add(kvp.Value);
		}

		index = 0;
		count = configs.Count;

		StartCoroutine(DoStage());
	}

	IEnumerator DoStage()
	{
		yield return new WaitForEndOfFrame();
		StageConfig stageConfig = configs[index];
		
		WarEnterData enterData = WarEnterData.CreateTest(stageConfig.id, 1, new int[][]{ }, new int[][]{ });
		War.isTest = true;
		War.isEditor = true;
		
		War.Clear();
		yield return new WaitForEndOfFrame();
		yield return new WaitForEndOfFrame();
		War.Start(enterData);

		yield return new WaitForSeconds(3F);

		stagePathManager.Init();

	}

	void OnFindStage()
	{
		index ++;
		
		Debug.Log("寻路数据 " + index + "/" + count);

		if(index == count)
		{
			Find();
		}
		else
		{
			StartCoroutine(DoStage());
		}
	}

	void Find()
	{
		Debug.Log("寻路数据 全部完成");
		DestroyImmediate(this);
	}









}

#endif