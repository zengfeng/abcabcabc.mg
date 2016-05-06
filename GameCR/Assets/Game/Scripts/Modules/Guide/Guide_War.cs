using UnityEngine;
using System.Collections;
using Games.Module.Wars;
using System.Collections.Generic;

namespace Games.Guides
{
	public class Guide_War : MonoBehaviour
	{
		public List<int> stageIds = new List<int>();

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
            Guide.OnDestroy();

        }
		
		void Init()
		{
			Guide.Init();

			StartCoroutine(CheckStage());
		}

		IEnumerator CheckStage()
		{
			Guide.warConfig = new GuideWarConfig ();

			int index = stageIds.IndexOf(War.sceneData.id);
			if(index != -1)
			{

				GuideModuleData data = Guide.model.GetStageData(index);
				if(data != null)
				{
					if (War.requireGuide) 
					{
						War.sceneData.enableAIUplevel = false;
						War.sceneData.enableAISkill = false;
						War.sceneData.enableAISendArm = false;

						Setting.SendArm = 75;
						War.sendArmRate = 75 / 100f;

						yield return new WaitForSeconds(0.5f);
						Guide.manager.PlayModule(data);
					}
				}
			}
		}



	}

}