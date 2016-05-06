using UnityEngine;
using System.Collections;

namespace CC.Runtime.Actions
{
	public class LoopRotation : MonoBehaviour 
	{
		public Vector3 velocity;
		public float smooth = 100F;
		private Vector3 _value;
		void Start () 
		{
			_value = transform.localRotation.eulerAngles;
		}

		void Update () 
		{
			_value = _value + velocity * Time.deltaTime * smooth;

			transform.localRotation = Quaternion.Euler(_value);
		}
	}
}