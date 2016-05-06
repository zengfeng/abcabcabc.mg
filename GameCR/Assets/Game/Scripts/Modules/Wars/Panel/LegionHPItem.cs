using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	public class LegionHPItem : MonoBehaviour 
	{
		public Text text;
		public RectTransform rectTransform;
		void Start () 
		{
			rectTransform = transform as RectTransform;
			if(text == null) text = transform.FindChild("Text").GetComponent<Text>();
		}

		public void SetNum(float num)
		{
			text.text = ((int) num) .ToString();
		}

		public void SetWidth(float width)
		{
			rectTransform.sizeDelta = rectTransform.sizeDelta.SetX(width);
		}

		public void SetX(float x)
		{
			rectTransform.anchoredPosition = rectTransform.anchoredPosition.SetX(x);
		}
	}
}