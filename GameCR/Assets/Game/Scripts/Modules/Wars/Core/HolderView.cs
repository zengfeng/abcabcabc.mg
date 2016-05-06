using UnityEngine;
using System.Collections;
using CC.Runtime.Actions;


namespace Games.Module.Wars
{
	public class HolderView : EntityView
	{
		public bool visible = false;
		private bool _visible = false;
		
		public Transform[] childs = new Transform[]{};

		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			if(_visible != visible)
			{
				_visible = visible;
				for(int i = 0; i < childs.Length; i ++)
				{
					childs[i].gameObject.SetActive(_visible);
				}
			}
		}

		[ContextMenu("SetChilds")]
		public void SetChilds()
		{
			childs = new Transform[transform.childCount];
			for(int i = 0; i < transform.childCount; i ++)
			{
				childs[i] = transform.GetChild(i);
			}
		}
	}
}