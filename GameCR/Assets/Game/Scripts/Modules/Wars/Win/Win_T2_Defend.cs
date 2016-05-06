using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	/** 胜利条件--关卡规定时间内，坚守时间越长，将领越丰厚 */
	public class Win_T2_Defend : WinProcessor 
	{
		public Win_T2_Defend_View view;


		public override void Init (WinConfig winConfig, GameObject viewGO)
		{
			base.Init (winConfig, viewGO);
			
			view = viewGO.GetComponent<Win_T2_Defend_View>();
		}

		
		override public void SetInfoPanel(GameObject infoPanelGO)
		{
			Win_T2_Defend_View view = infoPanelGO.GetComponent<Win_T2_Defend_View>();
			view.descriptionText.text = winConfig.description;
			view.time = (int)War.time;
		}

		override protected void OnLateUpdate()
		{

			view.time = (int)War.time;

		}

		public override OverType GetGameOverType ()
		{
			return OverType.Win;
		}

		public override void SetWarOverData (WarOverData overData)
		{
//			overData.parameter = new float[]{(int)War.time};
		}


	}
}