using UnityEngine;
using System.Collections;
using CC.UI;
using System.Collections.Generic;
using DG.Tweening;

namespace Games.Module.Wars
{
	public class Record_SendArmSettings : AbstractGuidePanelView
	{
		public Record_SendArmSettingPanel[] items;

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
					Record_SendArmSettingPanel item = items[legionData.colorId - 1];
					item.SetData (legionData.sendArmRate);

				}
			}
		}



	}

}