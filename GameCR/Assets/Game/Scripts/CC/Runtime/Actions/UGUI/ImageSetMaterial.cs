using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ImageSetMaterial : MonoBehaviour 
{
	public Image[] images;
	public Material[] materials;
	public int materialIndex;
	private int _materialIndex;
	public bool isUpdate;

	void Start ()
	{
		SetMaterial (materialIndex);
	}

	void Update () 
	{
		if (isUpdate)
		{
			if(_materialIndex != materialIndex)
			{
				SetMaterial(materialIndex);
			}
		}
	}

	public void SetMaterial(int i = 0)
	{
		_materialIndex = materialIndex = i;
		Material m = null;
		if(i < materials.Length) m = materials[i];
		foreach(Image img in images)
		{
			if(img != null)
			{
				img.material = m;
			}
		}
	}
}
