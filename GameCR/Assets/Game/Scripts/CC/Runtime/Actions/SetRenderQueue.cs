using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetRenderQueue : MonoBehaviour 
{
	public List<Material> materials = new List<Material>();
	public int queue = 2500;
	public bool isUpdate;
	void Start ()
	{
		PushTransform(transform);
	}

	public void PushTransform(Transform t)
	{
		PushMaterials(t);
		for(int i = 0; i < t.childCount ; i++)
		{
			PushTransform(t.GetChild(i));
		}
	}

	public void PushMaterials(Transform t)
	{
		Renderer[] renderers = t.GetComponents<Renderer>();
		foreach(Renderer renderer in renderers)
		{
			Material[] ms = renderer.materials;
			foreach(Material m in ms)
			{
				if(m != null)
				{
					materials.Add(m);
					m.renderQueue = queue;
				}
			}
		}
	}

	void Update ()
	{
		if(isUpdate)
		{
			foreach(Material m in materials)
			{
				m.renderQueue = queue;
			}
		}
	}
}
