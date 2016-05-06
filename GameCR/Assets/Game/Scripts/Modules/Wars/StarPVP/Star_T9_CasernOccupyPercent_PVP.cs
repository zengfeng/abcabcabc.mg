using UnityEngine;
using System.Collections;
using CC.Runtime.signals;

namespace Games.Module.Wars
{
	/** 星星--占领城池数量百分比 */
	public class Star_T9_CasernOccupyPercent_PVP : StarProcessor 
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


		void OnEnable()
		{
			if(state == StarState.Doing)
			{
				War.signal.sBuildChangeLegionComplete += OnBuildChangeTeam;

				if(War.isGameing)
				{
					CheckBuildPercent();
				}
				else
				{
					War.signal.sGameBegin += CheckBuildPercent;
				}
			}
		}

		void OnDisable()
		{
			War.signal.sBuildChangeLegionComplete -= OnBuildChangeTeam;
			War.signal.sGameBegin -= CheckBuildPercent;
		}

		/** 兵营改变势力 */
		public void OnBuildChangeTeam()
		{
			CheckBuildPercent();
		}

		void CheckBuildPercent()
		{
			float rate = War.scene.GetBuilds(legionData.legionId).Count * 1f / War.scene.GetBuilds().Count;
			if(rate >= percent)
			{
				SetSuccess();
			}
		}

		
		public override void SetSuccess ()
		{
			state = StarState.Success;
			War.signal.sBuildChangeLegionComplete -= OnBuildChangeTeam;
			War.signal.sGameBegin -= CheckBuildPercent;
		}


		
		override public void OnGameOver()
		{
			if(state != StarState.Success)
			{
				state = StarState.Fail;
			}
		}


	}
}