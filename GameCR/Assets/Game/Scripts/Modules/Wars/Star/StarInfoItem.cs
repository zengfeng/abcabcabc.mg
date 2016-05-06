using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class StarInfoItem : MonoBehaviour 
	{
		public StarProcessor processor;
		public Text text;
		public Image stateIcon;
		public Sprite[] stateIcons;


		void Start () 
		{
			if(text == null) text = transform.FindChild("Text").GetComponent<Text>(); 
			if(stateIcon == null) stateIcon = transform.FindChild("Star").GetComponent<Image>(); 
		}

		void Update ()
		{
			SetState();
		}

		public void SetState()
		{
			if(processor != null && text != null)
			{
				stateIcon.sprite = stateIcons[processor.state == StarState.Success ? 1 : 0];
				text.text = string.Format(processor.starConfig.processDescription, processor.processParameters);

			}
		}
	}
}