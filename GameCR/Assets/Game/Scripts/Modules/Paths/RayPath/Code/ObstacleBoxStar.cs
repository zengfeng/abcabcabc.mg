using UnityEngine;
using System.Collections;

public class ObstacleBoxStar : MonoBehaviour 
{
	public int hideIndex = 0;
	public void Hide()
	{
		hideIndex ++;
		gameObject.SetActive(false);
	}

	public void Show()
	{
		hideIndex--;
		if(hideIndex <= 0)
		{
			hideIndex = 0;
			gameObject.SetActive(true);
		}

	}

}
