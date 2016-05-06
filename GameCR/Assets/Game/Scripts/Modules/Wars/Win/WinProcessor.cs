using UnityEngine;
using System.Collections;

namespace Games.Module.Wars
{
	public class WinProcessor : MonoBehaviour 
	{
		public GameObject viewGO;
		public WinConfig winConfig;
		public WinState state = WinState.Doing;
		public object[] processParameters = new object[0];

		virtual public void Init(WinConfig winConfig, GameObject viewGO)
		{
			this.winConfig = winConfig;
			this.viewGO = viewGO;
		}

		virtual public void SetInfoPanel(GameObject infoPanelGO)
		{

		}


		virtual protected void LateUpdate()
		{
			if(War.isGameing && state == WinState.Doing)
			{
				OnLateUpdate();
			}
		}

		virtual protected void OnLateUpdate()
		{

		}


		virtual public void OnGameOver()
		{
		}

		virtual public OverType GetGameOverType()
		{
			return War.overType;
		}

		virtual public void SetWarOverData(WarOverData overData)
		{
		}
	}
}
