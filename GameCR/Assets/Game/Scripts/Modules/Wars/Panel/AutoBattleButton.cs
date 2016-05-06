using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CC.UI;
using CC.Runtime.signals;


namespace Games.Module.Wars
{
	public class AutoBattleButton : MonoBehaviour 
	{
		public TabButton toggle;
		void Start () 
		{
			if(toggle == null) toggle = GetComponent<TabButton>();

			if(War.isGameing)
			{
				InitValue();
//				SetValue(toggle.IsSelect);
			}
			else
			{
				War.signal.sGameBegin += OnWarStarted;
			}
		}
		
		void OnDestroy()
		{
			War.signal.sGameBegin -= OnWarStarted;
		}

		void OnWarStarted()
		{
			InitValue();
//			SetValue(toggle.IsSelect);
		}

		public void OnChange(bool value)
		{
			SetValue(toggle.IsSelect);
		}

		public void InitValue()
		{
			toggle.IsSelect = War.ownLegionData.aiSendArm;
		}

		public void SetValue(bool value)
		{
			if(!War.isGameing) return;
			War.ownLegionData.aiSendArm = value;
			War.ownLegionData.aiUplevel = value;
			War.ownLegionData.aiSkill = value;

		}
	}
}
