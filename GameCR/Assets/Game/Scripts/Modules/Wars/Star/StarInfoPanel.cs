using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace Games.Module.Wars
{
	public class StarInfoPanel : MonoBehaviour, IPointerClickHandler
	{

		public StarInfoItem[] items;

		void Start()
		{
			Generation();
		}

		/** 生成处理器 */
		public void Generation()
		{
			int count = War.starManager.list.Count;
			for(int i = 0; i < items.Length; i ++)
			{
				if(i < count)
				{
					items[i].processor = War.starManager.list[i];
				}
				else
				{
					items[i].gameObject.SetActive(false);
				}
			}
		}

		public void Show()
		{
			gameObject.SetActive(true);
//			War.Pause();
		}
		
		
		public void Hide()
		{
//			War.Play();
			gameObject.SetActive(false);
		}

		
		public void OnPointerClick (PointerEventData eventData)
		{
			Hide();
		}

	}
}