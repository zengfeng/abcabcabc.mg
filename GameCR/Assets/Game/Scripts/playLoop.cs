using UnityEngine;
using System.Collections;

public class playLoop : MonoBehaviour {

    public GameObject effect;
	// Use this for initialization
    private GameObject lastObj;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void play()
    {
        //GameObject s = Instantiate(effect) ;
        //s.SetActive(true);
        //Destroy(lastObj);
        //lastObj = s;
        effect.SetActive(false);
        effect.SetActive(true);
    }
}
