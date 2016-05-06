using UnityEngine;
using System.Collections;

namespace CC.Runtime.Actions
{
	public class FPSUpdate : MonoBehaviour 
	{
		public int frameRate = 60;
		void Awake () 
		{
			Application.targetFrameRate = frameRate;
		}

		void Update()
		{
			if(Application.targetFrameRate != frameRate)
			{
				Application.targetFrameRate = frameRate;
			}
		}
		

	}
}