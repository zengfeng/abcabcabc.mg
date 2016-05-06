using UnityEngine;
using System.Collections;

public static class ScreenUtil 
{

	public static float DEV_WIDTH = 1920f;
	public static float DEV_HEIGHT = 1280f;


	public static float GetRate()
	{
		float rate = 1f;

		float devAspect = DEV_WIDTH / DEV_HEIGHT;
		
		float aspect = Screen.width * 1f/ Screen.height;
		if(aspect >= devAspect)
		{
			rate = DEV_HEIGHT / Screen.height;
		}
		else
		{
			rate = DEV_WIDTH / Screen.width;
		}
		return rate;
	}
	
	
	public static Vector2 WorldPosToAnchorPos(this Vector3 pos)
	{
		return WorldPosToAnchorPos(pos, Camera.main);
	}

	public static Vector2 WorldPosToAnchorPos(this Vector3 pos, Camera worldCamera)
	{
		Vector3 pt = worldCamera.WorldToScreenPoint(pos);
		pt.z = 0;
		pt = pt * GetRate();
		return pt;
	}

}
