using UnityEngine;
using System.Collections;

public class BezierSegment 
{
	public BezierPoint begin = BezierPoint.Zero;
	public BezierPoint end   = BezierPoint.Zero;

	public BezierSegment()
	{
	}

	public BezierSegment(BezierPoint begin, BezierPoint end)
	{
		this.begin 	= begin;
		this.end 	= end;
	}


	public Vector3 GetPoint(float t)
	{
		return begin.anchorPoint * Mathf.Pow(1 - t, 3) + 3 * begin.controlPoint * t * Mathf.Pow(1 -t, 2) + 3 * end.controlPoint * Mathf.Pow(t, 2) * (1 - t) + end.anchorPoint * Mathf.Pow(t, 3);
	}

	public float LineDistance
	{
		get 
		{
			return Vector3.Distance (begin.anchorPoint, end.anchorPoint);
		}
	}


	public float LineDistanceAll
	{
		get 
		{
			return Vector3.Distance (begin.anchorPoint, begin.controlPoint) + Vector3.Distance (begin.controlPoint, end.controlPoint) + Vector3.Distance (end.controlPoint, end.anchorPoint);
		}
	}

}
