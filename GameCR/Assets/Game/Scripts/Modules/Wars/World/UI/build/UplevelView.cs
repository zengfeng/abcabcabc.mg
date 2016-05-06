using UnityEngine;
using System.Collections;
using CC.Runtime.Actions;


namespace Games.Module.Wars
{
	public class UplevelView : MonoBehaviour
	{
		
		public SpriteRenderer spriteRender;
		public Sprite[] sprites;

		public bool visiable;
		private bool	_visiable = true;
		void Update()
		{
			visiable = War.skillOperateSelect == null || War.skillOperateSelect.selected == null;
			if(_visiable != visiable)
			{
				_visiable = visiable;
				spriteRender.enabled = visiable;
			}
		}

		public void SetLevel(int level)
		{
			if(sprites.Length == 0) return;
			level -= 1;
			if(level >= sprites.Length)
			{
				level = sprites.Length - 1;
			}

			spriteRender.sprite = sprites[level];
		}
	}
}