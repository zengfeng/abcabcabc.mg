using UnityEngine;
using System.Collections;

namespace CC.UI
{
	[AddComponentMenu("CC/UI/UIColliderSize", 50)]
	[RequireComponent(typeof(BoxCollider2D))]
	public class UIColliderSize : MonoBehaviour 
	{
		public BoxCollider2D collider;
		[HideInInspector]
		public RectTransform rectTransform;
		public bool isUpdate;
		private Rect rect;
		void OnEnable () 
		{
			Set();
		}

		void Update () 
		{
			if(rectTransform.rect != rect)
			{
				Set();
			}
		}

		[ContextMenu("Set")]
		public void Set()
		{

			if(collider 		== null) 		collider 		= GetComponent<BoxCollider2D>();
			if(rectTransform 	== null) 		rectTransform 	= GetComponent<RectTransform>();
			
			rect = rectTransform.rect;

			collider.size 		= new Vector2(rectTransform.rect.width, rectTransform.rect.height);
			collider.offset 	= rectTransform.rect.center;
		}
	}
}
