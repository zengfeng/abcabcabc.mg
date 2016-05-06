using UnityEngine;
using System.Collections;

namespace RayPaths
{
	public class SetMoveTo : MonoBehaviour {

		public Transform target;
		private Vector3 pos = Vector3.one * 99999f;
		public RayPath rayPath;

		void Start () 
		{
			rayPath = GetComponent<RayPath>();
		}

		void Update () 
		{
			if(pos != target.position)
			{
				pos = target.position;
				rayPath.MoveTo(target);
			}
		}
	}
}
