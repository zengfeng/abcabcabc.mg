using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MultiColor : MonoBehaviour {

	public PrefabText prefabText;
	public Image image;
	public Color[] colors;
	public int colorIndex;
	public bool setMaterial = false;
	
	void Start () {
		SetColorIndex(colorIndex);
	}
	
	void Update () {
	}
	
	void OnValidate(){
		SetColorIndex(colorIndex);
	}

	//0是设置颜色索引，-1是使用原值
	public void SetColorIndex(int index = 0)
	{
		if (image != null)
		{
			//图片原值使用白色
			if (index < 0)
			{
				if (!setMaterial)
					image.color = Color.white;
				else
					image.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0.5f));
			}
			else
			{
				int clampIdx = Math.Max(index, 0);
				clampIdx = Math.Min(clampIdx, colors.Length);
				if (clampIdx < colors.Length)
				{
					colorIndex = index;

					if (!setMaterial)
						image.color = colors[clampIdx];
					else
						image.material.SetColor("_TintColor", colors[clampIdx]);
				}
			}
		}

		if (prefabText != null)
		{
			if (index < 0)
			{
				colorIndex = index;
				if (prefabText != null)
					prefabText.SetToOriginColor();
			}
			else
			{
				int clampIdx = Math.Max(index, 0);
				clampIdx = Math.Min(clampIdx, colors.Length);
				if (clampIdx < colors.Length && prefabText != null)
				{
					colorIndex = index;
					prefabText.SetTextColor(colors[clampIdx]);
				}
			}
		}
	}
}
