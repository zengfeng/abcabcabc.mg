using UnityEngine;
using System.Collections;
using Games.Module.Wars;
using System.Collections.Generic;

public class HunManager : MonoBehaviour {
	
	public GameObject prefab;
	public Stack<Hun> pool = new Stack<Hun>();


	void Start()
	{
		War.hunManager = this;
		if(War.isGameing)
		{
			Init();
		}
		else
		{
			War.signal.sGameBegin += Init;
		}
	}
	
	
	
	
	void OnDestroy()
	{
		War.signal.sGameBegin -= Init;
		pool.Clear();
	}

	
	void Init()
	{
		prefab = WarRes.GetPrefab(WarRes.Unit_Hun);
	}

	public Hun Play(UnitCtl unitCtl)
	{
		return Play(WarColor.GetHunColor(unitCtl.unitData.colorId), unitCtl.transform.position);
	}

	
	public Hun Play(int colorId, Vector3 position)
	{
		return Play(WarColor.GetHunColor(colorId), position);
	}

	public Hun Play(Color color, Vector3 position)
	{
		Hun hun;
		if(pool.Count > 0)
		{
			hun = pool.Pop();
		}
		else
		{
			hun = GameObject.Instantiate(prefab).GetComponent<Hun>();
			hun.transform.SetParent(transform);
		}

		hun.manager = this;
		hun.color = color;
		hun.transform.position = position;
		hun.Play();
		return hun;
	}

	
	public void OnOver(Hun item)
	{
		pool.Push(item);
	}
}
