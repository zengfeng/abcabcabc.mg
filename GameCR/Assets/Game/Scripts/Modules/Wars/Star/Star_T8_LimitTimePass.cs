using UnityEngine;
using System.Collections;
using CC.Runtime.signals;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class Star_T8_LimitTimePass : StarProcessor 
	{
		public int time
		{
			get
			{
				return starConfig.parameters[0];
			}
		}

		public float nowTime = 0;
		public float needTime = 0;

		public override void Init (StarConfig starConfig)
		{
			base.Init (starConfig);
			
			processParameters = new object[1];
			processParameters[0] = starConfig.parameters[0];
		}

		override protected void OnLateUpdate()
		{
			if(War.time > time)
			{
				state = StarState.Fail;
			}

			needTime = time;
			nowTime = War.time;
		}

	
		override public void OnGameOver()
		{
			if(state != StarState.Fail && War.isWin)
			{
				SetSuccess();
			}
		}


	}
}