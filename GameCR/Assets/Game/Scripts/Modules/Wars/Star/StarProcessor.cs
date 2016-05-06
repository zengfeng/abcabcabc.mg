using UnityEngine;
using System.Collections;

namespace Games.Module.Wars
{
	public class StarProcessor : MonoBehaviour 
	{
		public LegionData legionData;
		public StarConfig starConfig;
		public StarState state = StarState.Doing;
		public object[] processParameters = new object[0];

		virtual public void Init(StarConfig starConfig)
		{
			this.starConfig = starConfig;
		}


		virtual protected void LateUpdate()
		{
			if(War.isGameing && state == StarState.Doing)
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

		virtual public void SetSuccess()
		{
			state = StarState.Success;

			if (legionData == null)
			{
				War.starManager.getPanel.Open (starConfig);
			}
		}
	}
}
