using UnityEngine;
using System.Collections;

public class CanvasGroupHideTween : MonoBehaviour 
{
	public CanvasGroup canvasGroup;
	public float time = 1F;
	private float _time = 0f;
	void Start () 
	{
		if(canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
	}

	void Update () 
	{
		_time += Time.deltaTime;
		if(_time >= time)
		{
			canvasGroup.alpha = 1 - _time / time;
			enabled = false;
		}
	}
}
