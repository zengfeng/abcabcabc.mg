using UnityEngine;
using System.Collections;



public class SM_destroyThisTimed : MonoBehaviour {

	public float destroyTime = 5;

	void Start () {
		Destroy(gameObject, destroyTime);
	}

}
