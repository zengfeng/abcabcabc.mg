using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{

	public class LegionLevelViewManager : AbstractGuidePanelView
	{
		public LegionLevelView[] legionLevelViews;
		void Start()
		{
			War.legionLevelManager = this;

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
				if(legionData.colorId <= legionLevelViews.Length)
				{
//					Debug.Log(War.sceneData.stageConfig.id + "  " +  legionData.legionId + "  " + legionData.colorId);
					LegionLevelView view = legionLevelViews[legionData.colorId - 1];
					view.SetData(legionData);
				}
			}
		}

		public override void Show ()
		{
			gameObject.SetActive(true);

		}

		public override void Hide ()
		{
			gameObject.SetActive(false);
		}

	}
}