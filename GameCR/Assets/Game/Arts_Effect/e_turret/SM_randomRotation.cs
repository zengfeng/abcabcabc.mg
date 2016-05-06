using UnityEngine;
using System.Collections;

public class SM_randomRotation : MonoBehaviour {
	public float rotationMaxX	= 0f;
	public float rotationMaxY	= 360f;
	public float rotationMaxZ	= 0f;


	void Start () {
		
		float rotX = Random.Range(-rotationMaxX, rotationMaxX);
		float rotY = Random.Range(-rotationMaxY, rotationMaxY);
		float rotZ = Random.Range(-rotationMaxZ, rotationMaxZ);
		
		transform.Rotate(rotX, rotY, rotZ);
	}

}
