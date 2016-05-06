using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class BPropManager_Legion : EBehaviour
	{
		protected override void OnStart ()
		{
			base.OnStart ();
			
			unitData.legionData.legionPropContainer.sAddNode += OnAddLegionPropNode;
			unitData.legionData.buildPropContainer.sAddNode += OnAddBuildPropNode;
			unitData.legionData.soliderPropContainer.sAddNode += OnAddSoliderPropNode;
			unitData.legionData.heroPropContainer.sAddNode += OnAddHeroPropNode;
		}


		protected override void OnDestroy ()
		{
			unitData.legionData.legionPropContainer.sAddNode -= OnAddLegionPropNode;
			unitData.legionData.soliderPropContainer.sAddNode -= OnAddSoliderPropNode;
			unitData.legionData.buildPropContainer.sAddNode -=  OnAddBuildPropNode;
			unitData.legionData.heroPropContainer.sAddNode  -=  OnAddHeroPropNode;
			base.OnDestroy ();
		}

		
		void OnAddLegionPropNode(PropNdoe node)
		{
//			Debug.Log("<color=green>BPropManager_Legion.OnAddLegionPropNode node=" + node + "</color>");
			int unitType = 0;
			unitType = unitType.UPlayer(true);
			
			int relation = 0;
			relation = relation.ROwn(true);
			
			List<UnitCtl>  list = War.scene.SearchUnit(unitType, unitData.legionId, relation);
			foreach(UnitCtl unitCtl in list)
			{
				node.UnitApp(unitCtl.unitData, true);
			}

//			node.UnitApp(legionData.levelData.buildUnitData, true);
//			node.UnitApp(legionData.levelData.soliderUnitData, true);
		}

		
		void OnAddBuildPropNode(PropNdoe node)
		{
			int unitType = 0;
			unitType = unitType.UBuild(true);
			
			int relation = 0;
			relation = relation.ROwn(true);
			
			List<UnitCtl>  list = War.scene.SearchUnit(unitType, unitData.legionId, relation);
			foreach(UnitCtl unitCtl in list)
			{
				node.UnitApp(unitCtl.unitData, true);
			}

//			node.UnitApp(legionData.levelData.buildUnitData, true);
		}

		void OnAddSoliderPropNode(PropNdoe node)
		{
			int unitType = 0;
			unitType = unitType.USolider(true);

			int relation = 0;
			relation = relation.ROwn(true);

			List<UnitCtl>  list = War.scene.SearchUnit(unitType, unitData.legionId, relation);
			foreach(UnitCtl unitCtl in list)
			{
				node.UnitApp(unitCtl.unitData, true);
			}
			
//			node.UnitApp(legionData.levelData.soliderUnitData, true);
		}


		
		
		void OnAddHeroPropNode(PropNdoe node)
		{
			int unitType = 0;
			unitType = unitType.UHero(true);
			
			int relation = 0;
			relation = relation.ROwn(true);
			
			List<UnitCtl>  list = War.scene.SearchUnit(unitType, unitData.legionId, relation);
			foreach(UnitCtl unitCtl in list)
			{
				node.UnitApp(unitCtl.unitData, true);
			}
		}
	}
}