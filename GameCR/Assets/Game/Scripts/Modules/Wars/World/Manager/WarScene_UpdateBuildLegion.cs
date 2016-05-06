using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.signals;
using Games.Module.Wars;
using Games.Module.Props;


namespace Games.Module.Wars
{
	public class UpdateBuildLegion : UpdateHandle
	{
		private float _updateTime = 0f;
		
		
		public void OnUpdate()
		{
			if(Time.time >= _updateTime)
			{
				_updateTime = Time.time + 5F * Random.Range(0.8F, 1.2F);
				Execute();
			}
		}

		
		public void Execute ()
		{
			foreach(KeyValuePair<int, List<UnitCtl>> kv in buildLegionDict)
			{
				kv.Value.Clear();
			}

//			foreach(KeyValuePair<int, LegionData> kv in War.sceneData.legionDict)
//			{
//				kv.Value.totalMaxHP = 0;
//			}
			
			foreach(UnitCtl unit in buildList)
			{
				AddBuild(unit);
//				if(unit.unitData.unitType == UnitType.Build && unit.unitData.build_produce)
//				{
//					unit.legionData.totalMaxHP += unit.hpMax;
//				}
			}
		}
		
		
	}
}
