using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ExtendButton))]
public class ExtentButton : Editor {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		//		UIButton t = (UIButton)target;
	}
}
