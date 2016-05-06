using UnityEngine;
using System.Collections;

namespace CC.Runtime.FSMs
{
	public class State<T>
	{
		public virtual void Enter(T owner)
		{
		}

		public virtual void Execute(T owner)
		{
		}

		public virtual void Exit(T owner)
		{
		}


	}
}
