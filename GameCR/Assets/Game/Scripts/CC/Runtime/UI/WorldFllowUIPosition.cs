using UnityEngine;
using System.Collections;
using CC.Runtime;

public class WorldFllowUIPosition : MonoBehaviour 
{
	public LayerMask layerMask;
	public RectTransform targetUI;
	public Camera mainCamera;
	public Vector3 offset = new Vector3(0f, 0f, 0f);
	
	public float devWidth = 1920f;
	public float devHeight = 1280f;
	
	public float devAspect;
	private float screenWidth = 0;
	private float screenHeight = 0;
	public float aspect;
	public float rate = 1;
	public bool isUpdate = false;

	void Start () 
	{
		if(mainCamera == null) mainCamera = Camera.main;
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
		if (targetUI != null) 
		{
			Vector3 pos = targetUI.anchoredPosition / rate;
			pos = GetUIToWorldPoint (targetUI.position);
			transform.position = pos;
		}
	}

	public Vector3 GetUIToWorldPoint( Vector3 uiPosition)
	{
		uiPosition = Coo.uiCamera.WorldToScreenPoint (uiPosition);
		Ray ray = Camera.main.ScreenPointToRay (uiPosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, float.MaxValue, layerMask)) 
		{
			return hit.point;
		}

		return Vector3.zero;	
	}

}
