using UnityEngine;
using System.Collections;

public class BezierPoint
{
	public Vector3 anchorPoint;
	public Vector3 controlPoint;

	public BezierPoint()
	{
	}

	public BezierPoint(Vector3 anchorPoint)
	{
		this.anchorPoint = anchorPoint;
		this.controlPoint = new Vector3 (anchorPoint.x, anchorPoint.y, anchorPoint.z);
	}


	public BezierPoint(Vector3 anchorPoint, Vector3 controlPoint)
	{
		this.anchorPoint = anchorPoint;
		this.controlPoint = controlPoint;
	}

	public static BezierPoint Zero
	{
		get 
		{
			return new BezierPoint (Vector3.zero, Vector3.zero);
		}
	}



	public static BezierPoint One
	{
		get 
		{
			return new BezierPoint (Vector3.one, Vector3.one);
		}
	}
}
