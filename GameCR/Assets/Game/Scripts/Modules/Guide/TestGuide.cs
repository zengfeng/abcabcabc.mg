using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;


namespace Games.Guides
{
	public class TestGuide : MonoBehaviour 
	{
		public Transform from;
		public Transform to;
		public MoveToView_Send moveTo;

		public void Play()
		{
			moveTo.MoveWorld(from, to);
		}
	}
}