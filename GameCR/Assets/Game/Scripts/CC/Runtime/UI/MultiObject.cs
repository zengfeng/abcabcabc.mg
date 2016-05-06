using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[ExecuteInEditMode]
public class MultiObject : MonoBehaviour {

	public GameObject[] objects;
	public int objIndex;

	// Use this for initialization
	void Start () {
		SetObjectIndex(objIndex);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnValidate(){
		SetObjectIndex(objIndex);
	}

	public void SetObjectIndex(int index = 0)
	{
		int clampIdx = Math.Max(index, 0);
		clampIdx = Math.Min(clampIdx, objects.Length);
        objIndex = index;
		for (int i=0; i<objects.Length; i++)
		{
			if (i == objIndex)
			{
				if (objects[i])
					objects[i].SetActive(true);
			}
			else
			{
				if (objects[i])
					objects[i].SetActive(false);
			}
		}
	}

	public GameObject GetCurObject()
	{
		return objects[objIndex];
	}
}
