using UnityEngine;
using System.Collections;

namespace CC.Runtime.Actions.UGUI
{
	public class CanvasRendererAlphaBindParent : MonoBehaviour 
	{
		public float alpha = 1F;
		void Start () 
		{
			SetValue();
		}

		void Update () 
		{
			SetValue();
		}

		
		
		[ContextMenu("SetValue")]
		public void SetValue()
		{

			if(transform.parent != null)
			{
				
				CanvasRenderer selfRenderer = transform.GetComponent<CanvasRenderer>();
				if(selfRenderer != null)
				{
					CanvasRenderer parentRenderer = transform.parent.GetComponent<CanvasRenderer>();
					if(parentRenderer != null)
					{
						alpha = parentRenderer.GetAlpha();
						selfRenderer.SetAlpha(alpha);
					}
				}
			}
		}
	}
}
