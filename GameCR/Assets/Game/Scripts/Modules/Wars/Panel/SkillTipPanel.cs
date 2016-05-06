using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace Games.Module.Wars
{
	public class SkillTipPanel : MonoBehaviour
	{
		static SkillTipPanel _Instance;
		private static SkillTipPanel Instance
		{
			get
			{
				if(_Instance == null)
				{
					GameObject go = GameObject.Find("SkillTipPanel");
					Debug.Log("go=" + go);
					_Instance = go.GetComponent<SkillTipPanel>();
				}
				return _Instance;
			}
		}

		public static void Show(SkillOperateData skillData, RectTransform target)
		{
			return;
			Instance.MShow(skillData, target);
		}

		
		public static void Hide()
		{
			Instance.MHide();
		}



		public SkillOperateData  skillData;
		private SkillOperateData  _skillData;

		public Image skillIcon;
		public Text skillName;
		public Text skillDescription;
		public Camera camera;
		void Awake()
		{
			_Instance = this;
		}

		void Start () 
		{
			skillIcon = transform.FindChild("SkillIcon").GetComponent<Image>();
			skillName = transform.FindChild("SkillName").GetComponent<Text>();
			skillDescription = transform.FindChild("SkillDescription").GetComponent<Text>();
			if(camera == null) camera = Camera.main;

			MHide();
		}

		void Update () 
		{
			if(_skillData != skillData)
			{
				_skillData = skillData;

				if(_skillData != null)
				{
					skillData.LoadIcon(OnLoadIcon);

					skillName.text = skillData.skillConfig.name;
					skillDescription.text = skillData.skillConfig.description;
				}

			}
		}

		void OnLoadIcon(string name, object obj)
		{

			Texture2D texture = obj as Texture2D;
			skillIcon.sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(texture.width * 0.5F, texture.height * 0.5F));
		}

		public void MShow(SkillOperateData skillData, RectTransform target)
		{
			this.skillData = skillData;
			gameObject.SetActive(true);

			
			RectTransform rectTransform = GetComponent<RectTransform>();
			
//			float rate  = Mathf.Min(Screen.height / 640F, 1.3F);
//			rate  = Mathf.Max(rate, 0.7F);
//			transform.localScale = new Vector3(rate, rate, rate);


//			Vector3 screenPos = camera.WorldToScreenPoint(target.position);
			
			Vector3 screenPos = target.position;
			screenPos.y += target.rect.height * target.lossyScale.y ;
			if(screenPos.x < rectTransform.rect.width * rectTransform.lossyScale.x * 0.5f)
			{
				screenPos.x = rectTransform.rect.width * rectTransform.lossyScale.x * 0.5f;
			}

			if(screenPos.x >  Screen.width - rectTransform.rect.width * rectTransform.lossyScale.x * 0.5f)
			{
				screenPos.x = Screen.width - rectTransform.rect.width * rectTransform.lossyScale.x * 0.5f;
			}

//			Vector3 position = target.position;
//			position.y += target.rect.height * target.lossyScale.y * 0.5F;

			rectTransform.position = screenPos;

		}

		public void MHide()
		{
			gameObject.SetActive(false);
		}

	}
}
