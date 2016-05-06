using UnityEngine;
using System.Collections;
using Games.Module.Avatars;
using Games.Cores;
using UnityEngine.UI;
using DG.Tweening;


namespace Games.Guides
{
	public class GuideHeroCard : MonoBehaviour 
	{
		public int heroId;
		public Image image;
		public float widht = 327;
		public float height = 455;

		public void SetHero(int heroId)
		{
			this.heroId = heroId;

			AvatarConfig avatarConfig = Goo.avatar.GetConfig(heroId);
			avatarConfig.LoadFull(OnLoadIcon);
		}

		void OnLoadIcon(string name, object obj)
		{
			if(obj == null) return; 
			if(obj is Sprite)
			{
				image.sprite  = obj as Sprite;
			}
			else
			{
				Texture2D texture = obj as Texture2D;
				int width = texture.width;
				int height = texture.height;
				image.sprite   = Sprite.Create(texture, new Rect(0f, 0f, width, height), new Vector2(width * 0.5F, height * 0.5F));
			}
		}

	}
}