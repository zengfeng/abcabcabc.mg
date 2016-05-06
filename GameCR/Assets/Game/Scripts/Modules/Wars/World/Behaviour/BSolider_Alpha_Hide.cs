using UnityEngine;
using System.Collections;
using Games.Module.Wars;
using CC.Runtime;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	public class BSolider_Alpha_Hide : EBehaviour
	{
		public SpriteRenderer shadowSpriteRenderer;
		public SpriteRenderer[] spriteRendererList;
		public float delay = 0f;
		public float time = 1f;
		private float _d = 0;
		private float _t = 0;
		private float alpha = 1;
		protected override void OnStart ()
		{
			base.OnStart ();

		}

		protected override void OnEnable ()
		{
			base.OnEnable ();
			shadowSpriteRenderer = GetComponent<BShadow>().shadow.GetComponent<SpriteRenderer>();
			spriteRendererList = transform.GetComponentsInChildren<SpriteRenderer>();
			_t = time;
			_d = delay;
		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			if(_d > 0)
			{
				_d -= Time.deltaTime;
			}
			else if(_t > 0)
			{
				_t -= Time.deltaTime;
				alpha =_t >= 0 ?  _t / time : 0;
				foreach(SpriteRenderer spriteRenderer in spriteRendererList)
				{
					spriteRenderer.color = spriteRenderer.color.SetAlhpa(alpha);
					shadowSpriteRenderer.color = shadowSpriteRenderer.color.SetAlhpa(alpha);
				}
			}

		}


	}
}
