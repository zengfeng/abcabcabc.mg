using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class BPropManager_Hero : EBehaviour
	{
		protected override void OnStart ()
		{
			base.OnStart ();

			unitData.buildPropContainer.sAddNode += OnAddBuildPropNode;
		}


		protected override void OnDestroy ()
		{
			unitData.buildPropContainer.sAddNode -= OnAddBuildPropNode;
			base.OnDestroy ();
		}

		void OnAddBuildPropNode(PropNdoe node)
		{

			int relation = 0;
			relation = relation.ROwn(true);

			List<UnitCtl>  list = War.scene.SearchBuild_ByHero(unitData, relation);
			foreach(UnitCtl unitCtl in list)
			{
				node.UnitApp(unitCtl.unitData, true);
			}
		}

	}
}