﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Games.Module.Wars
{

	public class TBLegionLevelProp : MonoBehaviour
	{

		public TBLegionLevelPropItem[] items;
		void Start()
		{
			if(War.isGameing)
			{
				Init();
			}
			else
			{
				War.signal.sGameBegin += Init;
			}
		}




		void OnDestroy()
		{
			War.signal.sGameBegin -= Init;
		}

		void Init()
		{

			foreach(var kvp in War.sceneData.legionDict)
			{
				if(kvp.Key == 0) continue;

				LegionData legionData = kvp.Value;
				if(legionData.colorId <= items.Length)
				{
					TBLegionLevelPropItem view = items[legionData.colorId - 1];
					view.SetData(legionData);
				}
			}
		}


	}
}