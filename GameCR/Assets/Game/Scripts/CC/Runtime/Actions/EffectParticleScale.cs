using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectParticleScale : MonoBehaviour
{

    public List<float> nomalSizeList = new List<float>();
	// Use this for initialization
	void Start () {
        
	}

    private int needDis = 0;
    private float _delayTime = 0.0f;
    private int scalCount = 0;
	// Update is called once per frame
	void Update () {
        if (needDis == 0)
        {
            return;
        }
        _delayTime += Time.deltaTime;
        if(_delayTime >= 0.2)
        {
            if (scalCount >= 10)
            {
                needDis = 0;
                scalCount = 0;
                _delayTime = 0.0f;
                //setNomal();
                return;
            }
            foreach (Transform child in transform)
            {
                foreach (Transform childEff in child.gameObject.transform)
                {
                    ParticleSystem particleSystem = childEff.gameObject.GetComponent<ParticleSystem>();
                    particleSystem.startSize = particleSystem.startSize * 0.9f;
                    //Debug.Log("===name: " + childEff.gameObject.name + "==size: " + particleSystem.startSize);
                }
            }
            //Debug.Log("========================================== ");
            scalCount++;
            _delayTime = 0.0f;
        }
	}

    public void setDisappear()
    {
        foreach (Transform child in transform)
        {
            foreach (Transform childEff in child.gameObject.transform)
            {
                ParticleSystem particleSystem = childEff.gameObject.GetComponent<ParticleSystem>();
                nomalSizeList.Add(particleSystem.startSize);
                needDis = 1; 
                //Debug.Log("1========" + childEff.gameObject.name);
            }
        }
    }

    public void setNomal()
    {
        foreach (Transform child in transform)
        {
            int idx = 0;
            foreach (Transform childEff in child.gameObject.transform)
            {
                ParticleSystem particleSystem = childEff.gameObject.GetComponent<ParticleSystem>();
                int nomalIdx = 0;
                foreach (float size in nomalSizeList)
                {
                    if(idx == nomalIdx)
                    {
                        particleSystem.startSize = size;
                    }
                    nomalIdx++;
                }
                idx++;
            }
        }
    }
}
