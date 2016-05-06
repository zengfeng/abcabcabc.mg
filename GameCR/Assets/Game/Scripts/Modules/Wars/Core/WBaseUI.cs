using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;


namespace Games.Module.Wars
{
	public class WBaseUI : UIBehaviour 
	{
		[HideInInspector]
		public RectTransform rectTransform;
		protected override void Awake ()
		{
			rectTransform = GetComponent<RectTransform>();
			base.Awake ();
			
			OnAwake();
		}
		
		protected virtual  void Start () 
		{
			OnStart();
		}
		
		protected virtual void Update ()
		{
			if(War.isPlaying)
			{
				OnUpdate();
			}
		}
		
		protected virtual void OnDestroy()
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