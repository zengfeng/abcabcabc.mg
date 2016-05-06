using UnityEngine;
using System.Collections;
using CC.UI;
using System.Collections.Generic;
using DG.Tweening;

namespace Games.Module.Wars
{
	public class SendArmSettingPanel : AbstractGuidePanelView
	{
		public TabGroup tabGroup;
		public TabButton[] buttons;
		public Dictionary<int, TabButton> buttonDict = new Dictionary<int, TabButton>();

		void Start ()
		{
			foreach(TabButton button in buttons)
			{
				buttonDict.Add(button.uid, button);
			}

			if(buttonDict.ContainsKey((int) Setting.SendArm))
			{
				tabGroup.select = buttonDict[(int) Setting.SendArm];
			}
			else
			{
				tabGroup.select = buttonDict[100];
			}

			tabGroup.onValueChange.AddListener(OnChangeTab);

			Setting.sSendArmChange += OnSettingChange;
		}

		void OnDisable()
		{
			Setting.sSendArmChange -= OnSettingChange;
		}

		void OnSettingChange()
		{
			int val = (int) Setting.SendArm;
			if(tabGroup.select.uid != val)
			{
				tabGroup.select = buttonDict[val];
			}
		}

		
		public void OnChangeTab(TabButton tab)
		{
			Setting.SendArm = tab.uid;
			War.sendArmRate = tab.uid / 100f;
		}

		public override void Show ()
		{
			gameObject.SetActive(true);
			(transform as RectTransform).DOAnchorPos(new Vector2(0, 60), 1f, true);
		}

		
		public override void Hide ()
		{
			(transform as RectTransform).DOAnchorPos(new Vector2(-200, 60), 1f, true);
		}
		

	}

}