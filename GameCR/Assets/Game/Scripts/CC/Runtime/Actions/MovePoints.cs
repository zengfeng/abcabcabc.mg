using UnityEngine;
using System.Collections;

namespace CC.Runtime.Actions
{
	public class MovePoints : MonoBehaviour {
		public float speed = 1f;
		public float arriveDistance = 1f;
		public Vector3[] points;
		private Vector3 curPoint;
		private int curIndex = 0;

		void Update () 
		{
			if(points.Length > 0)
			{
				transform.position += (points[curIndex] - transform.position).normalized * speed;
				if(Vector3.Distance(transform.position, points[curIndex]) < arriveDistance)
				{
					curIndex ++;
					if(curIndex >= points.Length)
					{
						curIndex = 0;
					}
				}
			}
		}

		void OnDrawGizmos()
		{
			foreach(Vector3 point in points)
			{
				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere(point, 1F);
			}
		}
	}
}
