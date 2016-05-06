using UnityEngine;
using System.Collections;
using CC.Runtime.signals;

namespace Games.Module.Wars
{
	/** 战斗结束至少占领{0}个城池 */
	public class Star_T10_CasernOccupyLatest_PVP : StarProcessor 
	{
		private int _min = -1;
		public int min
		{
			get
			{
				if(_min < 0)
				{
					_min = starConfig.parameters[0];
				}

				return _min;
			}
		}

		
		public override void Init (StarConfig starConfig)
		{
			base.Init (starConfig);
			
			processParameters = new object[1];
			processParameters[0] = starConfig.parameters[0];
		}


		
		override public void OnGameOver()
		{
			int count = War.scene.GetBuilds(legionData.legionId).Count;
			if(count >= min)
			{
				SetSuccess();
			}
			else
			{
				state = StarState.Fail;
			}
		}

	}
}