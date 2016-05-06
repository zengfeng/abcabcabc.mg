using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class BPropManager_Build : EBehaviour
	{
		protected override void OnStart ()
		{
			base.OnStart ();

			unitData.soliderPropContainer.sAddNode += OnAddSoliderPropNode;
			unitData.heroPropContainer.sAddNode += OnAddHeroPropNode;
		}


		protected override void OnDestroy ()
		{
			unitData.soliderPropContainer.sAddNode -= OnAddSoliderPropNode;
			unitData.heroPropContainer.sAddNode -= OnAddHeroPropNode;
			base.OnDestroy ();
		}

		void OnAddSoliderPropNode(PropNdoe node)
		{
			int relation = 0;
			relation = relation.ROwn(true);

			List<UnitCtl>  list = War.scene.SearchSolider_FromBuild(unitData, relation);
			foreach(UnitCtl unitCtl in list)
			{
				node.UnitApp(unitCtl.unitData, true);
			}
		}
		
		
		void OnAddHeroPropNode(PropNdoe node)
		{
			int relation = 0;
			relation = relation.ROwn(true);
			
			List<UnitCtl>  list = War.scene.SearchHero_InBuild(unitData, relation);
			foreach(UnitCtl unitCtl in list)
			{
				node.UnitApp(unitCtl.unitData, true);
			}
		}
	}
}