using UnityEngine;
using System.Collections;

public class AutoContentGroup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Layout();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnRectTransformDimensionsChange()
	{
		Layout();
	}

	void Layout()
	{
		float accumHeight = 0;
		for (int i=0; i<transform.childCount; i++)
		{
			var child = transform.GetChild(i) as RectTransform;
			child.anchorMin = new Vector2(0.5f, 1.0f);
			child.anchorMax = new Vector2(0.5f, 1.0f);
			child.pivot = new Vector2(0.5f, 1.0f);

			var pos = child.anchoredPosition;
			pos.y = -accumHeight;
			child.anchoredPosition = pos;

			accumHeight += child.rect.height;
		}

		var rectTrans = transform as RectTransform;
		var size = rectTrans.sizeDelta;
		size.y = accumHeight;
		rectTrans.sizeDelta = size;
	}
}
