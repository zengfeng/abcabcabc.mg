using UnityEngine;
using System.Collections;


namespace Games.Module.Wars
{
	public class StateBuffLevel_Atk : AbstateStateBuffLevel
	{
		public SpriteRenderer spriteRenderer;
		public Sprite[] legion_0;
		public Sprite[] legion_1;
		public Sprite[] legion_2;
		public Sprite[] legion_3;
		public Sprite[] legion_4;



		public override void SetLevel (int level, int colorId)
		{

			Sprite[] sprites = null;

			switch(colorId)
			{
			case 0:
				sprites = legion_0;
				break;
			case 1:
				sprites = legion_1;
				break;
			case 2:
				sprites = legion_2;
				break;
			case 3:
				sprites = legion_3;
				break;
			case 4:
				sprites = legion_4;
				break;
			default:
				sprites = legion_0;
				break;
			}


			int index = level - 1;
			if(index < 0) index = 0;
			if(index >= sprites.Length) index = sprites.Length - 1;
			spriteRenderer.sprite = sprites[index];
		}
	}
}