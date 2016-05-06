using UnityEngine;
using System.Collections;


namespace CC.Runtime.Utils
{
	public static class VectorUtil {

		public static string ToStr(this Vector3[] list)
		{
			string str = "";
			string gap = "";
			for(int i = 0; i < list.Length; i ++)
			{
				Vector3 v = list[i];
				str += gap + i + "\t" + v;
				gap = "\n";
			}
			return str;
		}

		public static void Print(this Vector3[] list)
		{
			for(int i = 0; i < list.Length; i ++)
			{
				Debug.Log(i + "\t" + list[i]);
			}
		}

		public static Vector2 ToV2(this Vector3 src)
		{
			return new Vector2(src.x, src.z);
		}

		public static Vector3 ToV3(this Vector2 src)
		{
			return new Vector3(src.x, 0f, src.y);
		}

		
		public static Vector3 ZToY(this Vector3 src)
		{
			return new Vector3(src.x, src.z, 0);
		}

		
		public static float SqrDistance( this Vector3 vec1 , Vector3 vec2 )
		{
			return (vec1 - vec2).sqrMagnitude ;
		}

		public static Vector3 Multiply(this Vector3 a, Vector3 b)
		{
			return new Vector3(a.x * b.x,		a.y * b.y,		a.z * b.z);
		}

		
		public static Vector3 Clone(this Vector3 src)
		{
			return new Vector3(src.x, src.y, src.z);
		}

		
		public static Vector3 SetX(this Vector3 src, float x)
		{
			src.x = x;
			return src;
		}

		
		public static Vector3 SetY(this Vector3 src, float y)
		{
			src.y = y;
			return src;
		}
		
		public static Vector3 SetZ(this Vector3 src, float z)
		{
			src.z = z;
			return src;
		}

		
		//-----------------------------------------------
		public static Vector2 Clone(this Vector2 src)
		{
			return new Vector2(src.x, src.y);
		}


		public static Vector2 SetX(this Vector2 src, float x)
		{
			src.x = x;
			return src;
		}
		
		
		public static Vector2 SetY(this Vector2 src, float y)
		{
			src.y = y;
			return src;
		}


		public static PathPoint ToPoint(this Vector3 src)
		{
			return new PathPoint(src.x, src.z);
		}
		
		
		public static Vector3 ToVector3(this PathPoint src)
		{
			return new Vector3(src.x, 0, src.z);
		}


	}

	
	public class PathPoint
	{
		public float x;
		public float z;
		
		public PathPoint()
		{
		}
		
		
		public PathPoint(float x, float z)
		{
			this.x = x;
			this.z = z;
		}
	}

}
