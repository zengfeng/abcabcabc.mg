using UnityEngine;
using System.Collections;

namespace CC.Runtime.Actions
{
	public class LookCamera : MonoBehaviour 
	{
		public Transform target;

		void Start () {
			if(target == null) target = Camera.main.transform;
		}

		void Update () 
		{
			transform.LookAt(target.position);
		}
	}
}