using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace CC.UI
{
	public class MultipleTextList : BaseUI  , ITextList
	{
		public RectTransform container;
		public GameObject cell;
		public float gap = 2F;
		public Scrollbar scrollbar;
		public bool autoScroll = true;
		public float paddingTop = 10F;

		protected float _height = 0F;
		protected List<RectTransform> list = new List<RectTransform>();

		protected override void Start ()
		{
			base.Start ();
			if(cell != null) cell.SetActive(false);

			_height += paddingTop;
			UpdateLayout();
		}

		public void Add(RectTransform item)
		{
			if(_height > 0) _height += gap;

			float h = item.rect.height;
			item.SetParent(container);
			item.anchorMin = new Vector2(0F, 1f);
			item.anchorMax = new Vector2(1F, 1f);
			item.pivot = new Vector2(0F, 1F);
			item.localPosition = new Vector3(0, _height * -1, 0);
			item.sizeDelta = new Vector2(0F, h);
			list.Add(item);

			_height += h;

			UpdateLayout();

		}

		public void Add(string str)
		{
			GameObject item;
			if(cell != null)
			{
				item = GameObject.Instantiate(cell);
				item.SetActive(true);
			}
			else
			{
				item = new GameObject();
				item.AddComponent<RectTransform>();
				item.AddComponent<Text>();
			}

			Text text = item.GetComponent<Text>();
			text.text = str;

			Add(item.GetComponent<RectTransform>());
		}

		public void Clear()
		{
			while(list.Count > 0)
			{
				RectTransform item = list[0];
				GameObject.DestroyImmediate(item.gameObject);
				list.RemoveAt(0);
			}

			_height = 0;
		}

		
		protected void UpdateLayout()
		{
			container.sizeDelta = new Vector2(container.sizeDelta.x, _height > rectTransform.sizeDelta.y ? _height : rectTransform.sizeDelta.y);

			if(autoScroll) scrollbar.value = 0F;
		}

	}
}
