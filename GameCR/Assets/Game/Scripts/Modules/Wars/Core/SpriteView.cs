using UnityEngine;
using System.Collections;
using CC.Runtime.Actions;


namespace Games.Module.Wars
{
	[RequireComponent(typeof(LookCameraOfForward))]
	public class SpriteView : EntityView
	{
		private SpriteRenderer spriteRender;
		protected override void OnStart ()
		{
			base.OnStart ();
			if(spriteRender == null) spriteRender = GetComponent<SpriteRenderer>();
		}

		public void Show()
		{
			spriteRender.enabled = true;
		}

		public void Hide()
		{
			spriteRender.enabled = false;
		}
	}
}