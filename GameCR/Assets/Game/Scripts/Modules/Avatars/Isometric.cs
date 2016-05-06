using UnityEngine;
using System.Collections;

namespace Games.Module.Avatars
{
	[ExecuteInEditMode]
	public class Isometric : MonoBehaviour {
		
		public static Quaternion defaultRotation = Quaternion.Euler(new Vector3(45f, 0f, 0));
		public static Quaternion flipRotation = Quaternion.Euler(new Vector3(-45f, 180f, 0));

		
		public bool flip = false;
		public bool faceCamera = false;
		
		private Transform thisTransform;
		
		void Start()
		{
			thisTransform = GetComponent<Transform>();
			
			Update();
		}
		
		void Update()
		{
			if (faceCamera) {
				transform.rotation = Camera.main.transform.rotation;
				if (flip)
					transform.Rotate(new Vector3(0, 180, 0), Space.Self);
			}
			else if (flip)
				thisTransform.rotation = flipRotation;
			else
				thisTransform.rotation = defaultRotation;
		}
	}

}