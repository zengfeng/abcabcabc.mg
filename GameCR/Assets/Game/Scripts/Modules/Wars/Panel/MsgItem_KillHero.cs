using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Games.Module.Wars
{
	public class MsgItem_KillHero : MonoBehaviour 
	{
		public Text playerNameText;

		public Text heroNameText;
		public Image heroIconImage;
		public Image heroColorImage;
		public Image heroColorImage2;

		public void Set(LegionData legionData, HeroData heroData)
		{
			playerNameText.text = legionData.name;
			playerNameText.color = WarColor.GetHeroHeadColor(legionData.colorId);

			heroNameText.text = heroData.name;
			heroNameText.color = WarColor.GetHeroHeadColor(heroData.legionData.colorId);
			heroColorImage.color = WarColor.GetHeroHeadColor(heroData.legionData.colorId);
			heroColorImage2.color = heroColorImage.color;

			heroColorImage.gameObject.SetActive (!heroData.isRole);
			heroColorImage2.gameObject.SetActive (heroData.isRole);

			heroData.avatar.LoadVSIcon(OnLoadIcon);
		}

		void OnLoadIcon(string name, object obj)
		{
			if(obj == null) return; 
			if(obj is Sprite)
			{
				heroIconImage.sprite  = obj as Sprite;
			}
			else
			{
				
				float width = 55;
				float height = 55;
				Texture2D texture = obj as Texture2D;
				width = texture.width;
				height = texture.height;
				heroIconImage.sprite  = Sprite.Create(texture, new Rect(0f, 0f, width, height), new Vector2(width * 0.5F, height * 0.5F));
			}
		}


	}
}