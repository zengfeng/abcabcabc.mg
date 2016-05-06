using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[ExecuteInEditMode]
public class MultiImage : MonoBehaviour {

	public Sprite[] image;
	public int imageIndex;
	public Image target;
	public bool setNativeSize = false;

	// Use this for initialization
	void Start () {
		SetImageIndex(imageIndex);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnValidate(){
		SetImageIndex(imageIndex);
	}

	public void SetImageIndex(int index = 0)
	{
        if (target == null)
            return;

		int clampIdx = Math.Max(index, 0);
		clampIdx = Math.Min(clampIdx, image.Length);
        imageIndex = index;
		if (clampIdx < image.Length)
		{
			target.sprite = image[clampIdx];
			if (setNativeSize)
			{
				target.SetNativeSize();
			}
		}
	}


	public void SetImageSprite(int index, Sprite sprite)
	{
		if (index < image.Length) {
			image[index] = sprite;
		}
	}

}
