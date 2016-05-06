using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Games.Module.Wars
{
	public class SkillButton : MonoBehaviour {

		public SkillOperateData  data;
		public bool  selected = false;
		public bool  drag = false;
		public bool  moveBack = false;

		public Image 			skillIconImage;
		public Image 			heroIconImage;
		public Text 			nameText;
		public Button			cancelButton;

		
		public RectTransform 	rectTransform
		{
			get
			{
				return (RectTransform) transform;
			}
		}
		
		public bool Visiable
		{
			get
			{
				return gameObject.activeSelf;
			}

			set
			{
				gameObject.SetActive(value);
			}
		}

		public bool Selected
		{
			get
			{
				return selected;
			}

			set
			{
				selected = value;
				if(selected)
				{
					rectTransform.anchoredPosition = new Vector2(0, 32);
					rectTransform.localScale = Vector3.one * 1.1f;
					cancelButton.gameObject.SetActive(!MoveBack);
				}
				else
				{
					rectTransform.anchoredPosition = Vector2.zero;
					rectTransform.localScale = Vector3.one;
					cancelButton.gameObject.SetActive(false);
				}
			}
		}

		public bool Drag
		{
			get
			{
				return drag;
			}
			
			set
			{
				drag = value;
				if(drag)
				{
					rectTransform.anchoredPosition = Vector2.zero;
					rectTransform.localScale = Vector3.one * 0.9f;
					cancelButton.gameObject.SetActive(false);
				}
				else
				{
					Selected = Selected;
				}
			}
		}

		public bool MoveBack
		{
			get
			{
				return moveBack;
			}

			set
			{
				moveBack= value;
				if(moveBack)
				{
					cancelButton.gameObject.SetActive(false);
				}
				else
				{
					Selected = Selected;
				}
			}
		}

		void Awake()
		{
			Visiable = false;
		}
		
		public void SetSkillIcon(Sprite sprite)
		{
			skillIconImage.sprite 			= sprite;
		}
		
		public void SetHeroIcon(Sprite sprite)
		{
			heroIconImage.sprite 	= sprite;
		}

		void OnLoadHeroIcon(string name, object obj)
		{
			if(obj == null) return; 
			if(obj is Sprite)
			{
				SetHeroIcon(obj as Sprite);
			}
			else
			{
				
				float width = 43;
				float height = 43;
				Texture2D texture = obj as Texture2D;
				width = texture.width;
				height = texture.height;
				Sprite sprite  = Sprite.Create(texture, new Rect(0f, 0f, width, height), new Vector2(width * 0.5F, height * 0.5F));
				SetHeroIcon(sprite);
			}
		}
		
		void OnLoadSkillIcon(string name, object obj)
		{
			if(obj == null) return; 
			if(obj is Sprite)
			{
				SetSkillIcon(obj as Sprite);
			}
			else
			{
				
				float width = 118;
				float height = 118;
				Texture2D texture = obj as Texture2D;
				width = texture.width;
				height = texture.height;
				Sprite sprite  = Sprite.Create(texture, new Rect(0f, 0f, width, height), new Vector2(width * 0.5F, height * 0.5F));
				SetSkillIcon(sprite);
			}
		}

		public void SetData(SkillOperateData data)
		{
			this.data = data;
			data.LoadIcon(OnLoadSkillIcon);
			data.LoadVSHeadIcon(OnLoadHeroIcon);

//			nameText.text =data.skillConfig.skillId + data.skillConfig.name;
			nameText.text = "";
		}


	}
}