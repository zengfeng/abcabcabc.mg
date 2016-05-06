using UnityEngine;
using System.Collections;
using Games.Module.Avatars;


namespace Games.Module.Wars
{
	public class StateBuffLevel_MoveSpeed : AbstateStateBuffLevel
	{
		public SpriteRenderer 		spriteRenderer;
		public SpriteAvatar 		avatar;

		public AvatarData[] 		avatarDatas;
		public Color[] 				colors = new Color[]{Color.gray, Color.red, Color.blue, Color.green, Color.magenta};

		public override void SetLevel (int level, int colorId)
		{
			int index = level - 1;
			if(index < 0) index = 0;
			if(index >= avatarDatas.Length) index = avatarDatas.Length - 1;
			avatar.avatarData = avatarDatas[index];

			SetColor(colorId);
		}

		public void SetColor (int colorId)
		{
			if(colorId >= colors.Length) colorId = colors.Length - 1;
			spriteRenderer.color = colors[colorId];
		}
	}
}