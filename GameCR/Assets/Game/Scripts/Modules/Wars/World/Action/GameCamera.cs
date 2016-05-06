using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	
	float devHeight = 9.6f;
	float devWidth = 6.4f;
	
	int screenWidth;
	int screenHeight;

	public float scale = 7f;
	public float orthographicSize = 22.4f;
	
	// Use this for initialization
	void Start () 
	{
		orthographicSize = this.GetComponent<Camera>().orthographicSize / scale;
		Set();
		
	}

	void Update () 
	{
		if(screenWidth != Screen.width || screenHeight != Screen.height)
		{
//			Set();
		}
	}

	void Set()
	{
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		
		Debug.Log ("screenHeight = " + screenHeight);
		
		//this.GetComponent<Camera>().orthographicSize = screenHeight / 200.0f;

		
		float aspectRatio = Screen.width * 1.0f / Screen.height;
		
		float cameraWidth = orthographicSize * 2 * aspectRatio;
		
		Debug.Log ("cameraWidth = " + cameraWidth);
		
		if (cameraWidth < devWidth)
		{
			float size = devWidth / (2 * aspectRatio);
			Debug.Log ("new orthographicSize = " + size);
			this.GetComponent<Camera>().orthographicSize = size * scale;
		}
	}
}