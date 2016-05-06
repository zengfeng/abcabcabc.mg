using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Games.Module.Wars
{
	public class ProduceSkillButton : MonoBehaviour
	{
		
		public Text 					nameText;
		public Text 					countText;
		public ProduceSkillButtonIcon 	icon;

		private int _produceSkillId;

		void Start () 
		{
			icon.Progress = 0;
			icon.Visiable = false;
		}

		void Update () 
		{
			if(War.isGameing)
			{

				LegionData legionData = War.ownLegionData;
				icon.Progress = legionData.mage / legionData.maxMag;

				if(_produceSkillId != legionData.produceSkillUid)
				{
					_produceSkillId = legionData.produceSkillUid;
					if(_produceSkillId >= 0)
					{
						legionData.produceSkillData.LoadIcon(OnLoadSkillIcon);
						legionData.produceSkillData.LoadVSHeadIcon(OnLoadHeroIcon);
						icon.Visiable = true;

						
						nameText.text = legionData.produceSkillData.skillConfig.name;
						nameText.gameObject.SetActive(false);
					}
					else
					{
						icon.Visiable = false;
						nameText.gameObject.SetActive(false);
					}
				}

				countText.text = "×" + legionData.enableProduceSkillUids.Count;
			}
		}


		
		void OnLoadHeroIcon(string name, object obj)
		{
			if(obj == null) return; 
			if(obj is Sprite)
			{
				icon.SetHeroIcon(obj as Sprite);
			}
			else
			{
				
				float width = 43;
				float height = 43;
				Texture2D texture = obj as Texture2D;
				width = texture.width;
				height = texture.height;
				Sprite sprite  = Sprite.Create(texture, new Rect(0f, 0f, width, height), new Vector2(width * 0.5F, height * 0.5F));
				icon.SetHeroIcon(sprite);
			}
		}

		void OnLoadSkillIcon(string name, object obj)
		{
			if(obj == null) return; 
			if(obj is Sprite)
			{
				icon.SetSkillIcon(obj as Sprite);
			}
			else
			{
				
				float width = 118;
				float height = 118;
				Texture2D texture = obj as Texture2D;
				width = texture.width;
				height = texture.height;
				Sprite sprite  = Sprite.Create(texture, new Rect(0f, 0f, width, height), new Vector2(width * 0.5F, height * 0.5F));
				icon.SetSkillIcon(sprite);
			}
		}





	}
}