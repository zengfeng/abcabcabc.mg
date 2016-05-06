using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;


namespace CC.UI
{
	public class BaseUI : UIBehaviour 
	{
		[HideInInspector]
		public RectTransform rectTransform;
		protected override void Awake ()
		{
			rectTransform = GetComponent<RectTransform>();
			base.Awake ();
		}

	}
}