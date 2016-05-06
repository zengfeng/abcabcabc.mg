#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using Games.Module.Wars;
using System;
using System.Collections.Generic;
using RayPaths;
using System.IO;
using Newtonsoft.Json;

public class WE_StagePathManager : MonoBehaviour
{
	public Action sFind;

	public GameObject prefab;

	public StagePathData pathData;
	public int findCount;
	public int findedCount;
	public bool isSeted;

	public void Init()
	{
		pathData = new StagePathData();
		pathData.stageId = War.sceneData.stageConfig.id;
		findCount = 0;
		findedCount = 0;
		isSeted = false;

		Find();
	}

	public void Find()
	{
		List<UnitCtl> buildList = War.scene.GetBuilds();
		int count = buildList.Count;

		Dictionary<string, bool> setdict = new Dictionary<string, bool>();

		for(int fromIndex = 0; fromIndex < count; fromIndex ++)
		{
			UnitCtl from = buildList[fromIndex];
			for(int toIndex = 0; toIndex < count; toIndex ++)
			{
				UnitCtl to = buildList[toIndex];

				if(from != to)
				{
					string key = StagePathData.GetKey(from.unitData.uid, to.unitData.uid);
					if(!setdict.ContainsKey(key))
					{
						setdict.Add(key, true);

						findCount ++;
						MoveTo(from, to);
					}
				}
			}
		}

		isSeted = true;
	}

	public void MoveTo(UnitCtl from, UnitCtl to)
	{
		StartCoroutine(SetMoveTo(from, to));
	}

	 IEnumerator SetMoveTo(UnitCtl from, UnitCtl to)
	{
		yield return new WaitForSeconds(0.3f);
		GameObject go = GameObject.Instantiate(prefab);
		go.transform.SetParent(War.scene.rootSoliders);

		go.transform.position = from.transform.position;
		WE_UnitPathGroup unitPathGroup = go.GetComponent<WE_UnitPathGroup>();
		PathAgentComponent pathAgent = go.GetComponent<PathAgentComponent>();
		pathAgent.m_pathManager = War.pathManager;

		go.SetActive(true);
		
//		unitPathGroup.gap = gapH;
//		unitPathGroup.pathNum = count;
		//		unitPathGroup.onceCount = onceCount;

		unitPathGroup.sPathFinded += OnFind;
		unitPathGroup.MoveTo(from, to);
	}

	void OnFind(int from, int to, Vector3[] path)
	{
		pathData.AddPoint(from, to, path);
		findedCount ++;

		if(isSeted && findedCount == findCount)
		{
			Save();
		}
	}

	public void Save()
	{
		string str = JsonConvert.SerializeObject(pathData, Formatting.Indented);

		
		string filesPath = Application.dataPath + "/Game/" + StagePathData.GetFilePath(pathData.stageId) + ".json";
		Debug.Log(filesPath);

		PathUtil.CheckPath(filesPath, true);
		if (File.Exists(filesPath)) File.Delete(filesPath);
		FileStream fs = new FileStream(filesPath, FileMode.CreateNew);
		StreamWriter sw = new StreamWriter(fs);
		sw.Write(str);
		sw.Close(); fs.Close();

		Final();
	}

	public void Final()
	{
		Debug.Log("保存数据完成 " + pathData.stageId);

		if(sFind != null)
		{
			sFind();
		}

	}

}
#endif