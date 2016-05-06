using UnityEngine;
using System.Collections;

public class HUnityUtil 
{
	public static void DestoryChilds(GameObject go)
	{
		DestroyChilds(go.transform);
	}

	public static void DestroyChilds(Transform parent)
	{
		int count = parent.childCount;
		for(int i = count - 1; i >= 0; i --)
		{
			GameObject.Destroy(parent.GetChild(i).gameObject);
		}
	}

	
	public static void DestroyImmediateChilds(GameObject go)
	{
		DestroyImmediateChilds(go.transform);
	}
	
	public static void DestroyImmediateChilds(Transform parent)
	{
		int count = parent.childCount;
		for(int i = count - 1; i >= 0; i --)
		{
			GameObject.DestroyImmediate(parent.GetChild(i).gameObject);
		}
	}
}
