using UnityEngine;
using System.Collections;
using CC.Runtime.signals;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class Star_T5_AlsoOwnsCasern : StarProcessor 
	{
		public int casernNum
		{
			get
			{
				return starConfig.parameters[0];
			}
		}

		
		public int casernLevel
		{
			get
			{
				return starConfig.parameters[1];
			}
		}

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
			int num = 0;
			List<UnitCtl> list = War.scene.GetBuilds(War.ownLegionData.legionId);
			foreach(UnitCtl unit in list)
			{
				if(unit.unitData.level >= casernLevel)
				{
					num ++;
				}
			}

			if(num >= casernNum)
			{
				SetSuccess();
			}
			
			
			if(num > (int)processParameters[2])
			{
				processParameters[2] = num;
			}
		}


	}
}