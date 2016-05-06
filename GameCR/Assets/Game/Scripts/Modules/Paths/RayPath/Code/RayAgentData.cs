using UnityEngine;
using System.Collections;

namespace RayPaths
{
	public enum RayAgentPos
	{
		Center,
		Left,
		Right
	}
	public class RayAgentHitInfo
	{
		public RaycastHit hit;
		public RayAgentPos pos;
		public Vector3 hitpoint = Vector3.zero;

		public ObstacleBox obstacle;
		
	}

	public class RayAgentData
	{
		public RayAgentPos pos = RayAgentPos.Center;
		public float radius = 2F;
		private Vector3 _position = Vector3.zero;
		private float _angle= 0F;
		
		private Vector3 _left;
		private Vector3 _right;
		private Vector3[] _anchors = new Vector3[3];
		private bool _isChange = true;
		public Vector3 Position
		{
			get
			{
				return _position;		
			}
			
			set
			{
				if(_position == value) return;
				_position = value;
				_isChange = true;
			}
		}
		
		public float Angle
		{
			get
			{
				return _angle;		
			}
			
			set
			{
				if(_angle == value) return;
				_angle = value;
				_isChange = true;
			}
		}
		
		private void Calculate()
		{
			if(_isChange)
			{
				_isChange = false;
				Vector3 point = Vector3.right;
				float angle = -_angle;
				float rad =  angle * Mathf.Deg2Rad;
				point.x =  Mathf.Cos(rad) * radius;
				point.z =  Mathf.Sin(rad) * radius;
				point += _position;
				_right = point;
				
				point = Vector3.left;
				angle = -_angle + 180F;
				rad =  angle * Mathf.Deg2Rad;
				point.x =  Mathf.Cos(rad) * radius;
				point.z =  Mathf.Sin(rad) * radius;
				point += _position;
				_left = point;

				_anchors[0] = _position;
				_anchors[1] = _left;
				_anchors[2] = _right;
			}
		}

		public Vector3 GetLocal(Vector3 pos)
		{
			Vector3 point = Vector3.zero;
			Vector3 offest = pos - _position;
			float angle = Mathf.Atan2 (offest.z, offest.x)* Mathf.Rad2Deg;
			angle -= _angle;
			float length = offest.magnitude;
			float rad =  angle * Mathf.Deg2Rad;
			point.x =  Mathf.Cos(rad) * length;
			point.z =  Mathf.Sin(rad) * length;
			return point;
		}
		
		public Vector3 Left
		{
			get
			{
				Calculate();
				return _left;
			}
		}
		
		
		
		public Vector3 Right
		{
			get
			{
				Calculate();
				return _right;
			}
		}

		public Vector3[] Anchors
		{
			get
			{
				Calculate();
				return _anchors;	
			}
		}
		
		
		public void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere (Position, 0.1F);
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere (Left, 0.05F);
			Gizmos.DrawLine (Position, Left);
			Gizmos.color = Color.blue;
			Gizmos.DrawWireSphere (Right, 0.05F);
			Gizmos.DrawLine (Position, Right);
		}

		public void SetTarget(Vector3 target)
		{
			Vector3 direction = target - Position;
			SetDirection (direction);
		}
		
		
		public void SetDirection(Vector3 direction)
		{
			Angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		}
	}
}
