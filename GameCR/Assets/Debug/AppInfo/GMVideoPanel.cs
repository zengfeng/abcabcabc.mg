using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.PB;
using Games.Module.Wars;
using CC.Runtime.Utils;

public class GMVideoPanel : MonoBehaviour 
{
	public GameObject itemPrefab;
	public RectTransform container;
	public List<ProtoBattleVideoInfo> datas;

	void Start () 
	{
		
	}

	void Update ()
	{
	
	}

	void OnEnable()
	{
		Load ();
	}


	public void Open()
	{
		gameObject.SetActive (true);
	}

	public void Close()
	{
		gameObject.SetActive (false);
	}

	public void Load()
	{
		datas = War.record.GetList();

		int index = container.childCount;
		while(-- index  >= 0)
		{
			Destroy(container.GetChild(index).gameObject);
		}

		for(int i = 0; i < datas.Count; i ++)
		{
			GameObject itemGO = GameObject.Instantiate (itemPrefab);
			itemGO.transform.SetParent (container, false);
			itemGO.transform.localScale = Vector3.one;
			itemGO.SetActive (true);
			RectTransform rt = (RectTransform)itemGO.transform;
			rt.anchoredPosition = new Vector2 (0, -i * 80 );

			GMVideoItem item = itemGO.GetComponent<GMVideoItem> ();
			item.SetData (datas[i]);
			item.panel = this;
		}

		container.sizeDelta = container.sizeDelta.SetY (datas.Count * 80);
	}

	public void Clear()
	{
		War.record.Clear ();
		Load ();
	}

}
