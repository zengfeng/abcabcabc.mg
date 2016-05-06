using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

namespace Games.Module.Wars
{
	public class HeroHead : MonoBehaviour
	{
		HeroData heroData;
		public CanvasGroup canvasGroup;
		public Text heroNameText;
		public GameObject foregstageText;
		public GameObject 		killEffect;
		public SpriteRenderer 	killEffectSprite;
		public SpriteRenderer 	killEffectSprite2;
		public Color			killEffect_Own = Color.red;
		public Color			killEffect_Other = Color.yellow;

		public Image colorImage;
		public Image iconImage;

		
		public Image colorImage_role;
		public Image iconImage_role;


		public UIFllowWorldPosition fllow;
		void Start () {
		
		}

		void Update () {
		
		}

		public void SetData(HeroData heroData)
		{
			this.heroData = heroData;
			heroNameText.text = heroData.name;
			heroNameText.color = WarColor.GetHeroHeadColor(heroData.legionData.colorId);


			colorImage.color = WarColor.GetHeroHeadColor(heroData.legionData.colorId);
			heroData.avatar.LoadVSIcon(OnLoadIcon);

			colorImage_role.color = colorImage.color;

			if(heroData.isRole)
			{
				colorImage.gameObject.SetActive(false);
				iconImage.gameObject.SetActive(false);

				colorImage_role.gameObject.SetActive(true);
				iconImage_role.gameObject.SetActive(true);
			}
			else
			{
				colorImage.gameObject.SetActive(true);
				iconImage.gameObject.SetActive(true);
				
				colorImage_role.gameObject.SetActive(false);
				iconImage_role.gameObject.SetActive(false);
			}

			fllow.targetWorld = heroData.unit.transform;
		}

		void OnLoadIcon(string name, object obj)
		{
			if(obj == null) return; 
			if(obj is Sprite)
			{
				iconImage.sprite  = obj as Sprite;
			}
			else
			{
				
				float width = 43;
				float height = 43;
				Texture2D texture = obj as Texture2D;
				width = texture.width;
				height = texture.height;
				iconImage.sprite  = Sprite.Create(texture, new Rect(0f, 0f, width, height), new Vector2(width * 0.5F, height * 0.5F));
			}

			
			iconImage_role.sprite = iconImage.sprite;
		}

		public void Show()
		{
			gameObject.SetActive(true);
			if(heroData != null && heroData.isRole == false) foregstageText.SetActive(true);
			canvasGroup.DOKill();
			canvasGroup.alpha = 1;
			StopAllCoroutines();
		}


		public void Hide()
		{
			gameObject.SetActive(false);
		}

		public void Kill()
		{
			if(killEffectSprite != null)
			{
				killEffectSprite2.color = killEffectSprite.color = heroData.legionData.GetRelation(War.ownLegionID) == RelationType.Own ? killEffect_Own : killEffect_Other;
			}
			canvasGroup.transform.DOShakeScale(0.3f, 1.5f, 30, 90).SetDelay(0.3f);
			canvasGroup.DOFade(0, 0.5F).SetDelay(0.5F);

			killEffect.gameObject.SetActive(true);
			StartCoroutine(DelayHide(3f));
		}

		IEnumerator DelayHide(float time)
		{
			yield return new WaitForSeconds(time);
			Hide();
		}

	}
}