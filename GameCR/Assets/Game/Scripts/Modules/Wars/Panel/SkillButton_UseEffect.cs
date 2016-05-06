using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	public class SkillButton_UseEffect : MonoBehaviour {

		public SkillOperateData  data;

		public SkillInfo skillInfoNode;

		public Image 			skillIconImage;
		public Image 			heroIconImage;
		public Image 			glowImage;
		public Image 			glowImage2;
		public GameObject		effect;

		public RectTransform   pointGO;
		
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


		void Awake()
		{
//			Visiable = false;
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

		}

		public void Play(Vector3 position, SkillOperateType operateType)
		{
			transform.position = position;
			skillInfoNode.SetData (data);
			gameObject.SetActive(true);
			Init();


			if(operateType == SkillOperateType.Immediately)
			{
				PlayMoveToPoint();
			}
			else
			{
				PlayHide();
			}
		}

		void Init()
		{
			StopAllCoroutines();

			transform.DOKill();
			skillIconImage.DOKill();
			heroIconImage.DOKill();
			glowImage.DOKill();
			
			skillIconImage.color = skillIconImage.color.SetAlhpa(1);
			heroIconImage.color = heroIconImage.color.SetAlhpa(1);
			glowImage.color = heroIconImage.color.SetAlhpa(1);
			glowImage2.color = glowImage2.color.SetAlhpa(1);
		}
		
		public float moveTime = 0.5f;
		[ContextMenu("PlayMoveToPoint")]
		public void PlayMoveToPoint()
		{
			effect.SetActive(false);
			transform.DOMove(pointGO.position, moveTime, false).OnComplete(()=>{PlayHide();});
		}

		public float picHideTime = 1f;
		public float borderHideDelay = 0.7f;
		public float borderHideTime = 1.5f;
		public float hideTime = 1f;


		[ContextMenu("PlayHide")]
		public void PlayHide()
		{

			skillIconImage.DOFade(0, picHideTime);
			heroIconImage.DOFade(0, picHideTime);
			
			glowImage.DOFade(0, picHideTime);
			glowImage2.DOFade(0, borderHideTime).SetDelay(borderHideDelay);

			effect.SetActive(true);

			if (gameObject.activeInHierarchy) 
			{
				StartCoroutine (OnPlayHide ());
			}
		}

		IEnumerator OnPlayHide()
		{
			yield return new WaitForSeconds(hideTime);
			gameObject.SetActive(false);
		}


	}
}