using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	public class UnitShadow : MonoBehaviour 
	{
		public Transform target;
		public Vector3 offset = Vector3.zero;

		void Start ()
		{
			SetPosition();
		}

		void OnEnable()
		{
			SetPosition();
		}

		void OnDisable()
		{
			transform.position = new Vector3(-1000, 0, -1000);
		}

		void Update () 
		{
			SetPosition();
		}

		public void SetPosition()
		{
			if(target == null) return;
			transform.position = target.position.SetY(0) + offset;
		}

	}
}
