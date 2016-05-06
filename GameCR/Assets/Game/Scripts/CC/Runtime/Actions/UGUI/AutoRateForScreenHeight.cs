using UnityEngine;
using System.Collections;

namespace CC.Runtime.Actions.UGUI
{
	public class AutoRateForScreenHeight : MonoBehaviour {

		public Vector2 sourceSize = new Vector2(960F, 640F);
		public bool isUpdate = false;
		public bool useMin = false;
		public float minHeight;
		public bool useMax = false;
		public float maxHeight;
		private float minScale = 0.5F;
		private float maxScale = 2F;
		public float defaultScale = 1F;

		RectTransform rectTransform;

		void Start () 
		{
			if(rectTransform == null) rectTransform = GetComponent<RectTransform>();
			if(rectTransform.sizeDelta.y > 0)
			{
				minScale = minHeight / rectTransform.sizeDelta.y;
				maxScale = maxHeight / rectTransform.sizeDelta.y;
			}
			else
			{
				maxScale = maxHeight / rectTransform.rect.height;
			}
			SetSize();
		}

		Vector2 size = Vector2.one;
		Vector3 scale = Vector3.one;
		Vector2 screenSize = Vector2.zero;
		void Update () 
		{
			if(isUpdate)
			{
				if(screenSize.x != Screen.width || screenSize.y != Screen.height)
				{
					SetSize();
				}
			}
		}

		[ContextMenu ("SetSize")]
		void SetSize()
		{

			screenSize.x = Screen.width;
			screenSize.y = Screen.height;
//			size.y = Screen.height;
//			size.x = size.y / sourceSize.y * sourceSize.x;
			scale.x = scale.y = Screen.height / sourceSize.y;
			if(useMin && scale.y < minScale)
			{
				scale.x = scale.y = minScale;
			}

			if(useMax && scale.y > maxScale)
			{
				scale.x = scale.y = maxScale;
			}


			if(rectTransform == null) rectTransform = GetComponent<RectTransform>();
//			rectTransform.sizeDelta = size;
			rectTransform.localScale = scale * defaultScale;
		}
	}
}