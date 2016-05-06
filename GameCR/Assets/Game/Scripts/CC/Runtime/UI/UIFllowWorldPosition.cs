using UnityEngine;
using System.Collections;

public class UIFllowWorldPosition : MonoBehaviour 
{
	public Transform targetWorld;
	public Camera mainCamera;
	public Vector3 offset = new Vector3(0f, 0f, 0f);
	
	public float devWidth = 1920f;
	public float devHeight = 1280f;
	
	public float devAspect;
	private float screenWidth = 0;
	private float screenHeight = 0;
	public float aspect;
	public float rate = 1;
	private RectTransform rectTransform;
	public bool isUpdate = false;

	void Start () 
	{
		if(mainCamera == null) mainCamera = Camera.main;
		rectTransform = (RectTransform) transform;
		devAspect = devWidth / devHeight;

		SetRate();
		SetPosition();
		
#if UNITY_EDITOR
		isUpdate = true;
#endif
	}

	void Update ()
	{
		if(screenWidth != Screen.width || screenHeight != Screen.height)
		{
			SetRate();
			
			
			#if UNITY_EDITOR
			if(!isUpdate) SetPosition();
			#endif
		}

		if(isUpdate)
		{
			SetPosition();
		}
	}

	
	void SetRate()
	{
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		
		float aspect = screenWidth / screenHeight;
		if(aspect >= devAspect)
		{
			rate = devHeight / screenHeight;
		}
		else
		{
			rate = devWidth / screenWidth;
		}
	}


	void SetPosition()
	{
		Vector3 pt = mainCamera.WorldToScreenPoint(targetWorld.position + offset);
		pt.z = 0;
		rectTransform.anchoredPosition = pt * rate;
	}
}
