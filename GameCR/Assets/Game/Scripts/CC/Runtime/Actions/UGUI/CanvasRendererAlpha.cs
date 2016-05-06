using UnityEngine;
using System.Collections;

namespace CC.Runtime.Actions.UGUI
{
	public class CanvasRendererAlpha : MonoBehaviour 
	{
		private float _alpha = 1F;
		public float alpha = 1F;
		public bool isUpdate = false;
		void Start () 
		{
			SetValue();
		}

		void Update () 
		{
			if(isUpdate)
			{
				if(_alpha != alpha)
					SetValue();
			}
		}

		[ContextMenu("SetValue")]
		public void SetValue()
		{
			CanvasRenderer selfRenderer = transform.GetComponent<CanvasRenderer>();
			if(selfRenderer != null)
			{
				_alpha = alpha;
				selfRenderer.SetAlpha(alpha);
				SetChildrens(transform);
			}
		}

		public void SetValue(float a)
		{
			alpha = a;
			CanvasRenderer selfRenderer = transform.GetComponent<CanvasRenderer>();
			if(selfRenderer != null)
			{
				_alpha = alpha;
				selfRenderer.SetAlpha(alpha);
				SetChildrens(transform);
			}
		}

		void SetChildrens(Transform t)
		{
			CanvasRendererAlphaBindParent[] list = t.GetComponentsInChildren<CanvasRendererAlphaBindParent>();
			foreach(CanvasRendererAlphaBindParent item in list)
			{
				item.SetValue();
			}
		}
	}
}
