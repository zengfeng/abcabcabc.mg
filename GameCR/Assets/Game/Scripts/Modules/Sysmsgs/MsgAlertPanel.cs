using UnityEngine;
using System.Collections;
using CC.Runtime;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Games.Module.Sysmsgs
{
	public class MsgAlertPanel : Window 
	{
		public Text text;
		public Button yesButton;
		public Button noButton;
		public Button closeButton;

		protected override void Start()
		{
			yesButton.onClick.AddListener(OnYes);
			noButton.onClick.AddListener(OnNo);
		}

		public override void OnEnter ()
		{
			UpdateView();
		}

		public MsgMenuData msgMenuData
		{
			get
			{
				return (MsgMenuData) parameter;
			}
		}

		public void UpdateView()
		{
			if(parameter == null) return;
			text.text = msgMenuData.content;

			noButton.gameObject.SetActive(false);
			yesButton.gameObject.SetActive(false);

			Vector3 pos = yesButton.transform.localPosition;

			switch(msgMenuData.config.Type)
			{
			case 1:
				noButton.gameObject.SetActive(false);
				yesButton.gameObject.SetActive(true);
				pos.x = 0F;
				yesButton.transform.localPosition = pos;
				break;
			case 2:
			case 3:
				noButton.gameObject.SetActive(true);
				yesButton.gameObject.SetActive(true);
//				pos.x = -60F;
//				noButton.transform.localPosition = pos;
//				pos.x = 60F;
//				yesButton.transform.localPosition = pos;
				break;
			case 0:
			default:
				noButton.gameObject.SetActive(true);
				yesButton.gameObject.SetActive(true);
				break;

			}
		}

		public void OnYes()
		{
			if(msgMenuData.handle != null)
			{
				msgMenuData.handle(SysmsgButtonType.YES);
			}
			Exit();
		}

		public void OnNo()
		{
			if(msgMenuData.handle != null)
			{
				msgMenuData.handle(SysmsgButtonType.NO);
			}
			Exit();
		}
	}
}
