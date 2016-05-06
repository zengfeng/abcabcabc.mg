using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace CC.UI
{
	public class UITextList : BaseUI , ITextList
	{
		public Text text;
		public Scrollbar scrollbar;
		public bool autoScroll = true;

		override protected void Start ()
		{
			if(text == null)
			{
				Transform t  = transform.FindChild("Text");
				if(t != null) text = t.GetComponent<Text>();
			}

			if(scrollbar == null)
			{
				Transform t  = transform.FindChild("Scrollbar");
				if(t != null) scrollbar = t.GetComponent<Scrollbar>();
			}


			UpdateLayout();
		}

		virtual protected void Update () 
		{

		}

		virtual public void Clear()
		{
			text.text = "";
			text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
		}

		virtual public void Add(string str)
		{
			text.text += str + "\n";
			UpdateLayout();
		}

		protected void UpdateLayout()
		{
			text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, text.preferredHeight > rectTransform.sizeDelta.y ? text.preferredHeight :  rectTransform.sizeDelta.y);

			if(autoScroll) scrollbar.value = 0F;
		}
	}
}
