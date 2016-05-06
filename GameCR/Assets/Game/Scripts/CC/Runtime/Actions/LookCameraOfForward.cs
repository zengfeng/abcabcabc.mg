using UnityEngine;
using System.Collections;

namespace CC.Runtime.Actions
{
	public class LookCameraOfForward : MonoBehaviour 
	{
		public Transform target;

		void Start () {
			if(target == null) target = Camera.main.transform;
		}

		void Update () 
		{
			this.transform.forward = new Vector3(transform.position.x-target.position.x , 0, transform.position.z-target.position.z);
		}
	}
}