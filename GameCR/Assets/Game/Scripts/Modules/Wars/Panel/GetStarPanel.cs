using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Games.Module.Wars
{
	public class GetStarPanel : MonoBehaviour, IPointerClickHandler
	{
		public RectTransform content;
		public Text text;
		public bool isTwening;
		public bool isOpen;
		public float hideTime = 0f;
		public Vector3 p;
		Queue starConfigs = new Queue();

		public bool isFinal
		{
			get
			{
				return !isOpen && starConfigs.Count == 0;
			}
		}

		void Start ()
		{
			if(content == null) content = transform.FindChild("Content") as RectTransform;
			if(text == null) text = content.FindChild("BG/Text").GetComponent<Text>();

			p = content.position;
			HideEnd();
			content.gameObject.SetActive(true);
		}

		void Update ()
		{
			if(!isTwening)
			{
				if(hideTime > 0)
				{
					hideTime -= Time.deltaTime;
					if(hideTime <= 0)
					{
						Hide();
					}

				}
			}
		}

		
		public void OnPointerClick (PointerEventData eventData)
		{
			if(!isTwening)
			{
				Hide();
			}
		}

		public void Open(StarConfig config)
		{
			starConfigs.Enqueue(config);
			CheckOpen();
		}

		private void CheckOpen()
		{
			if(starConfigs.Count > 0)
			{
				if(!isOpen)
				{
					Show();
				}
			}
		}

		public void Show()
		{
			if(starConfigs.Count > 0)
			{
				StarConfig config = starConfigs.Dequeue() as StarConfig;
				text.text = config.Description;
			}

			isOpen = true;
			isTwening = true;
			gameObject.SetActive(true);
			transform.SetAsLastSibling();
			content.localScale = Vector3.zero;
			content.rotation = Quaternion.Euler(new Vector3(0F, 180F, 0F));
			content.anchoredPosition3D = new Vector3(Screen.width, 0f, 0f);


			iTween.ScaleTo(content.gameObject, iTween.Hash("time", 0.3f,
   			                                               "delay", 0.0f,
			                                               "easetype", iTween.EaseType.linear,
			                                               "scale", Vector3.one,
			                                               "oncomplete", "ShowEnd",
			                                               "oncompletetarget", gameObject));

			iTween.MoveTo(content.gameObject, iTween.Hash("time", 0.3f,
			                                              "delay", 0.0f,
			                                              "easetype", iTween.EaseType.linear,
			                                              "position", p
														));

			
			
			iTween.RotateTo(content.gameObject, iTween.Hash("time", 0.3f,
			                                              "delay", 0.0f,
			                                              "easetype", iTween.EaseType.linear,
			                                              "rotation", Vector3.zero
			                                              ));
		}

		void ShowEnd()
		{
			isTwening = false;
			hideTime = 5f;
		}


		public void Hide()
		{
			isTwening = true;
			iTween.ScaleTo(content.gameObject, iTween.Hash("time", 0.3f,
			                                               "delay", 0f,
			                                               "scale", Vector3.zero,
			                                               "easetype", iTween.EaseType.easeInBack,
			                                               "oncomplete", "HideEnd",
			                                               "oncompletetarget", gameObject));


			Vector3 pos = new Vector3(-Screen.width, 0f, 0f);
			iTween.MoveTo(content.gameObject, iTween.Hash("time", 0.3f,
			                                              "delay", 0.0f,
			                                              "easetype", iTween.EaseType.easeInBack,
			                                              "position", pos
			                                              ));

			
			
			
			iTween.RotateTo(content.gameObject, iTween.Hash("time", 0.3f,
			                                                "delay", 0.0f,
			                                                "easetype", iTween.EaseType.linear,
			                                                "rotation", new Vector3(0F, -30F, 0F)
			                                                ));
		}

		
		
		void HideEnd()
		{
			isOpen = false;
			isTwening = false;
			gameObject.SetActive(false);
			hideTime = 0;
			Invoke("CheckOpen", 0.5f);
		}


	}
}
