using UnityEngine;
using System.Collections;

public class yanchi : MonoBehaviour {
	
	public float time = 1.0f;
	
	// Use this for initialization
	void Start () {		
		
		gameObject.SetActive (false);
		Invoke("ok", time);
	}
	
	void ok()
	{
		gameObject.SetActive(true);
	}
	
}
