using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutoContentFitter : ContentSizeFitter {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected override void OnRectTransformDimensionsChange ()
	{
		base.OnRectTransformDimensionsChange ();

		if (transform.parent != null)
		{
			var autoContentGroup = transform.parent.GetComponent<AutoContentGroup>();
			if (autoContentGroup != null)
			{
				autoContentGroup.OnRectTransformDimensionsChange();
			}
		}
	}
}
