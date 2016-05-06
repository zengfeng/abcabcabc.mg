using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.Actions.UGUI;
using CC.Runtime;
using UnityEngine.UI;

namespace Games.Module.Wars
{
	public class HeroSkillClip : MonoBehaviour 
	{
		public HeroSkillClipManager heroSkillClipManager;
		public bool isRight;
		
		public int index = 0;
		public float begin = -250;
		public float gap = -200;
		public float time = 2f;
		public float wait = 2f;



		public RectTransform anchor_pomo;
		public RectTransform pomo;

		public RectTransform content;
		public RectTransform bg;
		public Image  icon;
		public Text   nameText;

		private Vector3 anchor_pomo_InitPosition = Vector3.zero;


		RectTransform rectTransform;

		void Awake()
		{
			rectTransform =(RectTransform) transform;
		}

		public void SetData(SkillOperateData skillOperateData)
		{
			nameText.text = skillOperateData.heroName;
			skillOperateData.LoadHeadSkillClipIcon(OnLoadIcon);
		}

		
		
		void OnLoadIcon(string name, object obj)
		{
			if(obj == null) return; 
			if(obj is Sprite)
			{
				icon.sprite  = obj as Sprite;
			}
			else
			{

				Texture2D texture = obj as Texture2D;
				float width = texture.width;
				float height = texture.height;
				icon.sprite  = Sprite.Create(texture, new Rect(0f, 0f, width, height), new Vector2(width * 0.5F, height * 0.5F));
			}
		}

		[ContextMenu("SetDirection")]
		public void SetDirection()
		{
			rectTransform =(RectTransform) transform;
			if(isRight)
			{
				pomo.localScale = new Vector3(-1, 1, 1);
				bg.localScale = new Vector3(-1, 1, 1);
				nameText.rectTransform.anchoredPosition = new Vector2(-60, 0);

				
				rectTransform.pivot = new Vector2(1f, 1f);
				rectTransform.anchorMin = new Vector2(1f, 1f);
				rectTransform.anchorMax = new Vector2(1f, 1f);
				rectTransform.anchoredPosition = new Vector2(0f, begin + gap * index);
			}
			else
			{
				
				pomo.localScale = Vector3.one;
				bg.localScale =  Vector3.one;
				nameText.rectTransform.anchoredPosition = new Vector2(150, 0);

				rectTransform.pivot = new Vector2(0f, 1f);
				rectTransform.anchorMin = new Vector2(0f, 1f);
				rectTransform.anchorMax = new Vector2(0f, 1f);
				rectTransform.anchoredPosition = new Vector2(0f, begin + gap * index);
			}
		}
		
		[ContextMenu("Play")]
		public void Play()
		{
			if(isRight)
			{
				anchor_pomo.anchoredPosition = new Vector2(900, 0);
				content.anchoredPosition = new Vector2(900, 0);
			}
			else
			{
				anchor_pomo.anchoredPosition = new Vector2(-900, 0);
				content.anchoredPosition = new Vector2(-900, 0);
			}
			gameObject.SetActive(true);

			rectTransform =(RectTransform) transform;
			if(isRight)
			{
				StartCoroutine(PlayRight());
			}
			else
			{
				StartCoroutine(PlayLeft());
			}
		}

		IEnumerator PlayLeft()
		{
			anchor_pomo.anchoredPosition = new Vector2(0, 0);
			anchor_pomo_InitPosition = anchor_pomo.localPosition;
			anchor_pomo.anchoredPosition = new Vector2(-900, 0);

			iTween.MoveTo(anchor_pomo.gameObject, iTween.Hash(

				"delay", 0.15f,
				"time", 0.2f, 
				"islocal", true ,
				"position",  anchor_pomo_InitPosition
				));


			pomo.GetComponent<Image>().color = Color.white;
			iTween.ColorTo(pomo.gameObject, iTween.Hash(
				"delay", 0.2f, 
				"time", 0.2f,
				"alpha", 0F));

			
			content.anchoredPosition = new Vector2(-20, 0);
			Vector3 p = content.localPosition;
			content.anchoredPosition = new Vector2(-660, 0);
			
			iTween.MoveTo(content.gameObject, iTween.Hash(
				
				"delay", 0f,
				"time", 0.3f, 
				"islocal", true ,
				"position",  p,
				"easetype", iTween.EaseType.easeInExpo
				));
			
			iTween.MoveTo(content.gameObject, iTween.Hash(
				
				"delay", 0.32f,
				"time", 1f, 
				"islocal", true ,
				"position",  anchor_pomo_InitPosition
				));
			
			content.localScale = Vector3.one;

			yield return new WaitForSeconds(wait);
			iTween.ScaleTo(content.gameObject, iTween.Hash(
				
				"delay", 0.7f,
				"time", 0.4f, 
				"scale",  new Vector3(1.5f, 0f, 1f),
				"easetype", iTween.EaseType.easeInExpo
				));


			
			yield return new WaitForSeconds(time);
			icon.sprite = null;
			gameObject.SetActive(false);
			heroSkillClipManager.OnClose(this);
		}

		
		IEnumerator PlayRight()
		{
			anchor_pomo.anchoredPosition = new Vector2(0, 0);
			anchor_pomo_InitPosition = anchor_pomo.localPosition;
			anchor_pomo.anchoredPosition = new Vector2(900, 0);
			
			iTween.MoveTo(anchor_pomo.gameObject, iTween.Hash(
				
				"delay", 0.15f,
				"time", 0.2f, 
				"islocal", true ,
				"position",  anchor_pomo_InitPosition
				));
			

			pomo.GetComponent<Image>().color = Color.white;
			iTween.ColorTo(pomo.gameObject, iTween.Hash(
				"delay", 0.2f, 
				"time", 0.2f,
				"alpha", 0F));
			
			
			content.anchoredPosition = new Vector2(20, 0);
			Vector3 p = content.localPosition;
			content.anchoredPosition = new Vector2(660, 0);

			iTween.MoveTo(content.gameObject, iTween.Hash(
				
				"delay", 0f,
				"time", 0.3f, 
				"islocal", true ,
				"position",  p,
				"easetype", iTween.EaseType.easeInExpo
				));
			
			iTween.MoveTo(content.gameObject, iTween.Hash(
				
				"delay", 0.32f,
				"time", 1f, 
				"islocal", true ,
				"position",  anchor_pomo_InitPosition
				));
			
			content.localScale = Vector3.one;
			yield return new WaitForSeconds(wait);
			iTween.ScaleTo(content.gameObject, iTween.Hash(
				
				"delay", 0.7f,
				"time", 0.4f, 
				"scale",  new Vector3(1.5f, 0f, 1f),
				"easetype", iTween.EaseType.easeInExpo
				));


			
			yield return new WaitForSeconds(time);
			icon.sprite = null;
			gameObject.SetActive(false);
			heroSkillClipManager.OnClose(this);
		}







	}
}