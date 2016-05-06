using UnityEngine;
using System.Collections;

namespace RayPaths
{
	public class RayAgent : MonoBehaviour {
		public RayAgentData agentData = new RayAgentData();
		void Start () 
		{
			agentData.Position = transform.position;
			agentData.Angle = transform.eulerAngles.y;
		}

		void Update () 
		{
			agentData.Position = transform.position;
			agentData.Angle = transform.eulerAngles.y;
		}

		void OnDrawGizmos()
		{
			if(!Application.isPlaying)
			{
				Update();
			}
			agentData.OnDrawGizmos ();
		}
	}
}
