using UnityEngine;
using System.Collections;
using CC.Runtime.signals;

namespace Games.Module.Wars
{
	/** 星星--游戏结束 占领城池数量百分比 */
	public class Star_T11_CasernOccupyPercent_GameOver : StarProcessor 
	{
		private float _percent = -1;
		public float percent
		{
			get
			{
				if(_percent < 0)
				{
					_percent = starConfig.parameters[0] / 100f;
				}

				return _percent;
			}
		}

		
		public override void Init (StarConfig starConfig)
		{
			base.Init (starConfig);
			
			processParameters = new object[1];
			processParameters[0] = starConfig.parameters[0];
		}


		void CheckBuildPercent()
		{
			float rate = War.scene.GetBuilds(War.ownLegionID).Count * 1f / War.scene.GetBuilds().Count;
			if(rate >= percent)
			{
				SetSuccess();
			}
		}


		
		override public void OnGameOver()
		{
			CheckBuildPercent ();

			if(state != StarState.Success)
			{
				state = StarState.Fail;
			}
		}

	}
}