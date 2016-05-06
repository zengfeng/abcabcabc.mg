using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
[ExecuteInEditMode]
public class ParticleBindTransform : MonoBehaviour 
{
	public Transform target;
	private ParticleSystem particleSystem;
	public bool bindStartRotationY = true;

	void Start () 
	{
		if(target == null) target = transform;
		particleSystem = GetComponent<ParticleSystem>();
	}

	void Update () 
	{
		if(bindStartRotationY)
		{
			particleSystem.startRotation = target.eulerAngles.y / 57.29578F;
		}
	}
}
