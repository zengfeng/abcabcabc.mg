using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour
{
	private bool isDown;
	public Camera camera;
	public LayerMask layerMask;
	public Transform target;
	public float offset = 3f;

	public BezierArrow bezierArrow;
	public bool isSetVisiable = false;
	void Start () 
	{
		isDown = false;
		if (camera == null) camera = Camera.main;
		if (target == null) target = transform;

	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0))
		{
			isDown = true;

			if(isSetVisiable) bezierArrow.Show ();
		}

		if (isDown) 
		{
			Ray ray = camera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, float.MaxValue, layerMask.value)) 
			{
				
				target.position = hit.point - ray.direction * offset;
			}
		}


		if (Input.GetMouseButtonUp (0))
		{
			isDown = false;
			if(isSetVisiable) bezierArrow.Hide ();
		}

	}


}
