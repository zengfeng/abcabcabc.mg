using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.signals;
using Games.Module.Wars;
using Games.Module.Props;


namespace Games.Module.Wars
{
	public partial class WarScene : EntityMBBehaviour 
	{
		public void Clear()
		{
			_beginTime = 0;

			unitDict.Clear();
			players.Clear();
			buildList.Clear();
			soliderList.Clear();
			buildDict.Clear();
			buildLegionDict.Clear();
			heroLegionDict.Clear();
			heroDictByBuild.Clear();

			buildDistanceDict.Clear();
		}

	}
}
	
