using UnityEngine;
using System.Collections;

public class MouseTarget : MonoBehaviour {
	public float maxDistance = 200;
	public LayerMask layerMask;
	public bool isDown;
	void Start () 
	{
		
	}
	
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			isDown = true;
			
		}
		
		if(isDown)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, maxDistance, layerMask.value))
			{
				Debug.DrawLine(ray.origin, hit.point);
				transform.position = hit.point;
			}
			
		}
		
		if(Input.GetMouseButtonUp(0))
		{
			isDown = false;
		}
		
		
	}
}
