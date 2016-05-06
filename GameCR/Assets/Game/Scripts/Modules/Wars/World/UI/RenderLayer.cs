using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
public class RenderLayer : MonoBehaviour 
{
	public enum Layer
	{
		War_Terrain = -5,
		War_BuildGround,
		War_Shadow,
		War_Dust,
		War_AtkRadius,
		Default = 0,
		War_Unit,
		War_DarkScreen,
		War_HeroSkill,
		War_SkillEffect
	}
	
	public bool hasChildren = true;
	public Layer sortingLayer = Layer.Default;
	public int sortingOrder = 0;

	private Layer _sortingLayer;
	private int _sortingOrder;

	void Start () 
	{
		Set();
	}

	void Update () 
	{
		if(_sortingLayer != sortingLayer || _sortingOrder != sortingOrder)
		{
			Set();
		}
	}

	[ContextMenu("Set")]
	public void Set()
	{
		string sortingLayerName = Enum.GetName(typeof(RenderLayer.Layer), sortingLayer);
		_sortingLayer = sortingLayer;
		_sortingOrder = sortingOrder;

		if(hasChildren)
		{
			Renderer[] renderers = transform.GetComponentsInChildren<Renderer>();
			foreach(Renderer renderer in renderers)
			{
				renderer.sortingLayerName = sortingLayerName;
				renderer.sortingOrder = sortingOrder;
			}
		}
		else
		{
			Renderer renderer = GetComponent<Renderer>();
			if(renderer != null)
			{
				renderer.sortingLayerName = sortingLayerName;
				renderer.sortingOrder = sortingOrder;
			}
		}
	}
	
	[ContextMenu("Log")]
	public void Log()
	{
		Renderer[] renderers = transform.GetComponentsInChildren<Renderer>();
		foreach(Renderer renderer in renderers)
		{
			Debug.Log(string.Format("{0}, sortingLayerID={1}, sortingLayerName={2}, sortingOrder={3}", renderer.gameObject, renderer.sortingLayerID, renderer.sortingLayerName, renderer.sortingOrder));
		}
	}
}
