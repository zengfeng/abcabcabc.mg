using UnityEngine;
using System.Collections;
using CC.UI;
using System.Collections.Generic;
using DG.Tweening;

namespace Games.Module.Wars
{
	public class Record_SendArmSettingPanel : AbstractGuidePanelView
	{
		public TabGroup tabGroup;
		public TabButton[] buttons;
		public Dictionary<int, TabButton> buttonDict = new Dictionary<int, TabButton>();

		void Start ()
		{
			if (buttonDict.Count == 0) 
			{
				foreach (TabButton button in buttons) {
					buttonDict.Add (button.uid, button);
				}

				if (buttonDict.ContainsKey ((int)Setting.SendArm)) {
					tabGroup.select = buttonDict [(int)Setting.SendArm];
				} else {
					tabGroup.select = buttonDict [100];
				}
			}
		}


		public void SetData(int val)
		{
			if (buttonDict.Count == 0) 
			{
				foreach (TabButton button in buttons) {
					buttonDict.Add (button.uid, button);
				}
			}

			if (buttonDict.ContainsKey (val)) 
			{
				tabGroup.select = buttonDict [val];
			}
		}


		

	}

}