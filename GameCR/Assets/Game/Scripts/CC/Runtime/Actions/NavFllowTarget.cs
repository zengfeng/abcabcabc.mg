using UnityEngine;
using System.Collections;

public class NavFllowTarget : MonoBehaviour
{
	public Transform target;
	public NavMeshAgent agent;
	public bool isUpdate;
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
		agent.SetDestination(target.position);
	}

	void Update () 
	{
		if(isUpdate)
		{
			agent.SetDestination(target.position);
		}
	}
}
