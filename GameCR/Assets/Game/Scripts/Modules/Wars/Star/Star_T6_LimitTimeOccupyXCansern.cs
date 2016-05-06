using UnityEngine;
using System.Collections;
using CC.Runtime.signals;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class Star_T6_LimitTimeOccupyXCansern : StarProcessor 
	{
		public int time
		{
			get
			{
				return starConfig.parameters[0];
			}
		}

		
		public int casernNum
		{
			get
			{
				return starConfig.parameters[1];
			}
		}

		public int num = 0;
		public int needNum = 0;
		public float nowTime = 0;
		public float needTime = 0;

		public override void Init (StarConfig starConfig)
		{
			base.Init (starConfig);
			
			processParameters = new object[3];
			processParameters[0] = starConfig.parameters[0];
			processParameters[1] = starConfig.parameters[1];
			processParameters[2] = 0;
		}

		override protected void OnLateUpdate()
		{
			if(War.time > time)
			{
				SetFail();
			}

			nowTime = time;
			needTime = War.time;

			needNum = casernNum;
			processParameters[2] = num;
		}


		void OnEnable()
		{
			if(state == StarState.Doing)
			{
				SignalFactory.GetInstance<WarBuildChangeLegion>().AddListener(OnBuildChangeTeam);
			}
		}
		
		void OnDisable()
		{
			SignalFactory.GetInstance<WarBuildChangeLegion>().RemoveListener(OnBuildChangeTeam);
		}
		
		/** 兵营改变势力 */
		public void OnBuildChangeTeam(UnitData buildUnitData, int preTeam, int targetTeam)
		{
			if(targetTeam == War.ownLegionData.legionId)
			{
				if(War.time <= time)
				{
					num ++;
					if(num >= casernNum)
					{
						SetSuccess();
					}
				}
			}
		}
	

		public override void SetSuccess ()
		{
			base.SetSuccess ();
			SignalFactory.GetInstance<WarBuildChangeLegion>().RemoveListener(OnBuildChangeTeam);
		}

		public void SetFail()
		{
			state = StarState.Fail;
			SignalFactory.GetInstance<WarBuildChangeLegion>().RemoveListener(OnBuildChangeTeam);
		}


	}
}