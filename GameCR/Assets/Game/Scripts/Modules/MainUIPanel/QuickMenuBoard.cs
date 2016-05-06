using UnityEngine;
using System.Collections;
using CC.UI;
using UnityEngine.UI;
using CC.Runtime.Actions.UGUI;
using CC.Runtime.Utils;
using System.Collections.Generic;
using CC.Runtime;

namespace Games.Module.MainUIs
{
	public class QuickMenuBoard : MonoBehaviour 
	{
		public TabButton popupButton;
		public RectTransform bg;
		public RectTransform container;
		public RectTransform tipParent;
		public Button mask;
		public bool useMask;

		//public float x0 = -131f;
		//public float w = -262f;
		//public float gap = 30f;
		public float y0 = -131f;
		public float h = -262f;
		public float gap = 30f;

		void Awake()
		{
			if(popupButton == null) popupButton = transform.FindChild("Content/DownPopupButton").GetComponent<TabButton>();
//			if(bg == null) bg = transform.FindChild("Content/Bg").GetComponent<RectTransform>();
			if(container == null) container = transform.FindChild("Content/ButtonList").GetComponent<RectTransform>();
			if(tipParent == null) tipParent = transform.FindChild("Content/DownPopupButton/TipParent").GetComponent<RectTransform>();
			if(!useMask) mask.gameObject.SetActive(false);

			popupButton.onValueChanged.AddListener(OnClickPopupButton);
			mask.onClick.AddListener(CloseListManually);
			CloseListComplete();
		}

		void OnDestroy()
		{
			if(popupButton != null) popupButton.onValueChanged.RemoveAllListeners();
			if(mask != null) mask.onClick.RemoveAllListeners();
		}

        protected void OnClickPopupButton(bool isSelect)
		{
			if(gameObject == null)
			{
				OnDestroy();
				return;
			}

			if(popupButton.IsSelect)
			{
				OpenList();
			}
			else
			{
				CloseList();
			}
		}

		public List<RectTransform> GetList()
		{
			List<RectTransform> list = new List<RectTransform>();
			
			for(int i = 0; i < container.childCount; i ++)
			{
				RectTransform item = container.GetChild(i) as RectTransform;
				if(item.gameObject.activeSelf)
				list.Add(item);
			}

            /*
			list.Sort(delegate(RectTransform a, RectTransform b)
			          {
				return (int)(b.anchoredPosition.x - a.anchoredPosition.x);
			});
            */
			return list;
		}

        protected void OpenList()
		{
			popupButton.Interactable = false;
			if(useMask) 
			{
				mask.gameObject.SetActive(true);
            }
//			bg.gameObject.SetActive(true);
			container.gameObject.SetActive(true);
			tipParent.gameObject.SetActive(false);
			
			List<RectTransform> list = GetList();
//			bg.sizeDelta = bg.sizeDelta.SetX((gap + w) * list.Count + 100f);

			
//			bg.localScale = new Vector3(0.0f, 1f, 1f);
//			iTween.ScaleTo(bg.gameObject, iTween.Hash("time",0.15F,
//			                                          "scale", Vector3.one,
//			                                          "easetype", iTween.EaseType.easeOutBack));



//            iTween.Stop();
			for(int i = 0; i < list.Count; i ++)
			{
				RectTransform item = list[i];
				
				Image image = item.GetComponent<Image>();
				image.color = image.color.Clone().SetAlhpa(0f);
				iTween.FadeTo(item.gameObject, iTween.Hash(
															"time", 0.2f,
				                                           "alpha", 1F));


				Vector3 position = item.localPosition;
				//position.x = x0 + (w + gap) * i;
				//item.localPosition = position.Clone().SetX(x0);
				position.y = y0 + (h + gap) * i;
				item.localPosition = position.Clone().SetY(y0);

				
				iTween.MoveTo(item.gameObject, iTween.Hash("delay", 0.01f,
				                                           "time", 0.2f,
				                                           "islocal", true,
				                                           "position", position,
				                                           "easetype", iTween.EaseType.easeOutBack
				                                           ));

			}

			Invoke("OpenListComplete", 0.2F);
		}

        public void LayoutButtons()
		{
			
			List<RectTransform> list = GetList();
//			bg.sizeDelta = bg.sizeDelta.SetX((-gap - w) * list.Count + 220f);

			for(int i = 0; i < list.Count; i ++)
			{
				RectTransform item = list[i];

				Image image = item.GetComponent<Image>();
				image.color = image.color.Clone().SetAlhpa(1f);
			
				
				Vector3 position = item.localPosition;
				//position.x = x0 + (w + gap) * i;
				position.y = y0 + (h + gap) * i;
				item.localPosition = position;
			}

			if(useMask) 
			{
				mask.gameObject.SetActive(true);
			}
		}


        protected void OpenListComplete()
		{
			popupButton.Interactable = true;
		}

        protected void CloseList()
		{
			
			popupButton.Interactable = false;
			tipParent.gameObject.SetActive(true);

			
			List<RectTransform> list = GetList();
//			iTween.ScaleTo(bg.gameObject, iTween.Hash("delay", 0.05f,
//			                                          "time",0.2F,
//			                                          "scale", new Vector3(0.0f, 1f, 1f),
//			                                          "easetype", iTween.EaseType.easeInBack));


//			iTween.Stop();
			for(int i = list.Count - 1; i >= 0; i --)
			{
				RectTransform item = list[i];

				Image image = item.GetComponent<Image>();
				iTween.FadeTo(item.gameObject, iTween.Hash(
					
															"delay", 0.01f * i,
															"time", 0.15F,
				                                           "alpha", 0F,
															"easetype", iTween.EaseType.easeInBack
				                                           ));

				
				Vector3 position = item.localPosition;
				//position.x = x0 - gap * i;
				position.y = y0 - gap * i;
				
				
				iTween.MoveTo(item.gameObject, iTween.Hash(
					                                       "delay", 0.01f * i,
															"time", 0.15F,
				                                           "islocal", true,
				                                           "position", position,
				                                           "easetype", iTween.EaseType.easeInBack
				                                           ));
				
			}



			Invoke("CloseListComplete", 0.3F);
		}

		protected void CloseListComplete()
		{
			popupButton.Interactable = true;
			mask.gameObject.SetActive(false);
//			bg.gameObject.SetActive(false);
			container.gameObject.SetActive(false);
//			bg.localScale = new Vector3(0.5f, 1f, 1f);
		}

		public void CloseListManually()
		{
            popupButton.IsSelect = false;
            CloseList();
		}

		public void SetIsUseMask(bool val)
		{
			useMask = val;
		}
	}
}
