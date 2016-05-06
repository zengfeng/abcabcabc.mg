using UnityEngine;
using System.Collections;


namespace Games.Module.Wars
{
	public class EntityMBBehaviour : MonoBehaviour 
	{
		protected virtual void Awake()
		{
			OnAwake();
		}

		protected virtual  void Start () 
		{
			OnStart();
		}
		
		protected virtual void Update ()
		{
			if(War.isUpdateBehaviour)
			{
				OnUpdate();
			}
		}

		protected virtual void OnDestroy()
		{

		}

		public virtual void OnRelease()
		{

		}

		//-------------------
		protected virtual  void OnAwake () 
		{
		}
		
		protected virtual  void OnStart () 
		{
		}
		
		protected virtual void OnUpdate () 
		{
		}
		
		
		protected virtual void OnEnable () 
		{
		}
		
		
		protected virtual void OnDisable () 
		{
		}

	}
}