using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using System.Collections.Generic;
using System;

namespace RayPaths
{
	public class ObstacleBox : MonoBehaviour 
	{
	//	public Transform[] anchors = new Transform[4];
	//	public Transform minXMinZ;
	//	public Transform maxXMaxZ;
	//	public Transform minXMaxZ;
	//	public Transform maxXMinZ;
	//	public ObstacleBoxManager obstacleBoxMananger;
		public Action<ObstacleBox> change;
		private bool isChange = true;

	//	void Awake () 
	//	{
	//		if(minXMinZ == null) minXMinZ = transform.FindChild("0 minX_minZ");
	//		if(maxXMaxZ == null) maxXMaxZ = transform.FindChild("1 maxX_maxZ");
	//		if(minXMaxZ == null) minXMaxZ = transform.FindChild("2 minX_maxZ");
	//		if(maxXMinZ == null) maxXMinZ = transform.FindChild("3 maxX_minZ");
	//		anchors[0] = minXMinZ;
	//		anchors[1] = maxXMaxZ;
	//		anchors[2] = minXMaxZ;
	//		anchors[3] = maxXMinZ;
	//
	//	}
	//

	//	void OnEnable()
	//	{
	//		if(obstacleBoxMananger == null)
	//		{
	//			GameObject go = GameObject.Find("ObstacleBoxManager");
	//			if(go != null)
	//			{
	//				obstacleBoxMananger = go.GetComponent<ObstacleBoxManager>();
	//			}
	//		}
	//
	//		obstacleBoxMananger.AddObstacleBox(this);
	//	}
	//	
	//	void OnDestroy()
	//	{
	//		obstacleBoxMananger.RemoveObstacleBox(this);
	//	}

		void Update()
		{
			if(_prePosition != transform.position || _preRotation != transform.eulerAngles || _preScale != transform.lossyScale)
			{

				isChange = true;
				_prePosition = transform.position;
				_preRotation = transform.eulerAngles;
				_preScale = transform.lossyScale;

				if(change != null) change(this);
			}
		}
		
		
		public bool IsIn(Vector3 pos)
		{
			return pos.x > min.x && pos.x < max.x && pos.z > min.z && pos.z < max.z;
		}

		
		Vector3[] anchorPointsSource = new Vector3[4];
		Vector3[] anchorPoints = new Vector3[4];
		Vector3[] anchorPoints2 = new Vector3[4];
		Vector3 _prePosition = Vector3.one * 99999;
		Vector3 _preRotation = Vector3.one * 99999;
		Vector3 _preScale = Vector3.one * 99999;
		Vector3 min = Vector3.zero;
		Vector3 max = Vector3.zero;
		private float extended = 1F;
		public Vector3[] GetAnchorPoints()
		{
			if(isChange == false) return anchorPointsSource;
			isChange = false;

			Vector3 center = transform.position;
			Vector3 size = transform.lossyScale;
			float angle = -transform.eulerAngles.y;
			
			anchorPointsSource[0] = new Vector3(size.x * -0.5F, 0F, size.z * -0.5F);
			anchorPointsSource[1] = new Vector3(size.x * 0.5F, 0F, size.z * 0.5F);
			anchorPointsSource[2] = new Vector3(size.x * -0.5F, 0F, size.z * 0.5F);
			anchorPointsSource[3] = new Vector3(size.x * 0.5F, 0F, size.z * -0.5F);

			size.x += extended;
			size.z += extended;
			
			anchorPoints[0] = new Vector3(size.x * -0.5F, 0F, size.z * -0.5F);
			anchorPoints[1] = new Vector3(size.x * 0.5F, 0F, size.z * 0.5F);
			anchorPoints[2] = new Vector3(size.x * -0.5F, 0F, size.z * 0.5F);
			anchorPoints[3] = new Vector3(size.x * 0.5F, 0F, size.z * -0.5F);

			min.x = min.z = 9999999F;
			max.x = max.z = -9999999F;
			for(int i = 0; i < anchorPoints.Length; i ++)
			{
				Vector3 point = anchorPoints[i];
				float anglePoint = HMath.angle(0f, 0f, point.x, point.z);
				float angleEnd = angle + anglePoint;
				float length = point.magnitude;
				float radian = HMath.angleToRadian(angleEnd);
				
				point.x = HMath.radianPointX(radian, length, 0f);
				point.z = HMath.radianPointY(radian, length, 0f);
				point += center;
				anchorPoints[i] = point;
				if(point.x < min.x) min.x = point.x;
				if(point.z < min.z) min.z = point.z;
				if(point.x > max.x) max.x = point.x;
				if(point.z > max.z) max.z = point.z;


				point = anchorPointsSource[i];
				anglePoint = HMath.angle(0f, 0f, point.x, point.z);
				angleEnd = angle + anglePoint;
				length = point.magnitude;
				radian = HMath.angleToRadian(angleEnd);
				point.x = HMath.radianPointX(radian, length, 0f);
				point.z = HMath.radianPointY(radian, length, 0f);
				point += center;
				anchorPointsSource[i] = point;
			}

			anchorPoints2[0] = anchorPoints[1];
			anchorPoints2[1] = anchorPoints[2];
			anchorPoints2[2] = anchorPoints[0];
			anchorPoints2[3] = anchorPoints[3];

			return anchorPoints;
		}

		
		public Vector3[] AnchorSortPints
		{
			get
			{
				GetAnchorPoints ();
				return anchorPoints2;
			}
		}

		public Vector3 GetAnchorSourcePoint(int index)
		{
			GetAnchorPoints();
			return anchorPointsSource[index];
		}

		public Vector3 FindAnchor(Vector3 pos, out int index)
		{
			GetAnchorPoints ();
			index = 0;
			Vector3 result = anchorPoints2[0];
			float maxDot = -2f;
			
			for(int i = 0; i < anchorPoints2.Length; i ++)
			{
				Vector3 v = anchorPoints2[i];
				float dot = Vector3.Dot((pos - transform.position).normalized, (v - transform.position).normalized);
				if(dot >= maxDot)
				{
					index = i;
					result = v;
					maxDot = dot;
				}
			}
			
			return result;
		}

		public Vector3 FindAnchor(Vector3 pos)
		{
			GetAnchorPoints ();
			Vector3 result = anchorPoints[0];
			float maxDot = -2f;

			foreach(Vector3 v in anchorPoints2)
			{
				float dot = Vector3.Dot(pos.normalized, v.normalized);
				if(dot >= maxDot)
				{
					result = v;
					maxDot = dot;
				}
			}

			return result;
		}


		public Vector3 FindAnchor2(Vector3 pos, int index, out int resultIndex)
		{
			Vector3 p1;
			Vector3 p2;
			float angle = GetAngle(transform.position, pos);
			float angle0 = GetAngle(transform.position, anchorPoints2[index]);
			if (index == 0) 
			{
				p1 = anchorPoints2[1];
				p2 = anchorPoints2[3];
				if(angle >= angle0 && angle <= 180F)
				{
					resultIndex = 1;
					return p1;
				}
				else
				{
					resultIndex = 3;
					return p2;
				}
			}
			else if(index == 1)
			{
				p1 = anchorPoints2[0];
				p2 = anchorPoints2[2];

				if(angle > angle0)
				{
					resultIndex = 2;
					return p2;
				}
				else
				{
					resultIndex = 0;
					return p1;
				}
			}
			else if(index == 2)
			{
				p1 = anchorPoints2[1];
				p2 = anchorPoints2[3];

				if(angle > angle0)
				{
					resultIndex = 3;
					return p2;
				}
				else
				{
					resultIndex = 1;
					return p1;
				}
			}
			else
			{
				p1 = anchorPoints2[0];
				p2 = anchorPoints2[2];
				
				resultIndex = 2;
				if(angle < angle0 && angle >= 180F)
				{
					resultIndex = 2;
					return p2;
				}
				else
				{
					resultIndex = 0;
					return p1;
				}
			}

		}

		public Vector3 FindAnchor3(Vector3 hit, int index)
		{
			Vector3 p1;
			Vector3 p2;
			float angle = GetAngle(transform.position, hit);
			float angle0 = GetAngle(transform.position, anchorPoints2[index]);
			if (index == 0) 
			{
				p1 = anchorPoints2[1];
				p2 = anchorPoints2[3];
				
				if(angle >= angle0 && angle <= 180F)
				{
					return p2;
				}
				else
				{
					return p1;
				}
			}
			else if(index == 1)
			{
				p1 = anchorPoints2[0];
				p2 = anchorPoints2[2];
				
				if(angle > angle0)
				{
					return p1;
				}
				else
				{
					return p2;
				}
			}
			else if(index == 2)
			{
				p1 = anchorPoints2[1];
				p2 = anchorPoints2[3];
				if(angle > angle0)
				{
					return p1;
				}
				else
				{
					return p2;
				}
			}
			else
			{
				p1 = anchorPoints2[0];
				p2 = anchorPoints2[2];
				
				if(angle < angle0 && angle >= 180F)
				{
					return p1;
				}
				else
				{
					return p2;
				}
			}
			
		}

		float GetAngle(Vector3 from, Vector3 to)
		{
			float angle = HMath.angle(from.x, from.z, to.x, to.z);
			if(angle < 0) angle += 360;
			return angle;
		}
		
		
		public Vector3 FindAnchor2(Vector3 pos, Vector3 e)
		{
			GetAnchorPoints ();
			Vector3 result = anchorPoints[0];
			float maxDot = -2f;
			foreach(Vector3 v in anchorPoints)
			{
				if(v == e) continue;
				float dot = Vector3.Dot(pos.normalized, v.normalized);
				if(dot >= maxDot)
				{
					result = v;
					maxDot = dot;
				}
			}
			
			return result;
		}

		void OnDrawGizmos()
		{
			if (!Application.isPlaying)
			{
				Update ();
				GetAnchorPoints ();
			}

			foreach(Vector3 v in anchorPoints)
			{
				Gizmos.color = Color.magenta;
				Gizmos.DrawWireSphere(v, 0.1F);
			}

			foreach(Vector3 v in anchorPointsSource)
			{
				Gizmos.color = Color.blue;
				Gizmos.DrawWireCube(v, Vector3.one * 0.1F);
			}

		}

	}
}