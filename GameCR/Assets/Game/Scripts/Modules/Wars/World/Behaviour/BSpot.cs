using UnityEngine;
using System.Collections;
using System.Security.Policy;
using CC.Runtime.Actions;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class BSpot : EBehaviour 
	{
		private int _legionId = -1;
		public BuildSpotConfig buildSpotConfig;
		private BuildSpotConfig _buildSpotConfig;
		private bool isFirst = true;
		private bool isMsg = false;
		private bool isEffect = false;
		private bool runing = true;

		protected override void OnStart ()
		{
			base.OnStart ();
			StartCoroutine(Check());

			isFirst = unitData.lastBuildSpotConfig != null;
		}


		protected override void OnDestroy ()
		{
			base.OnDestroy ();
			StopAllCoroutines();
		}

		IEnumerator Check ()
		{
			while(runing)
			{
				yield return new WaitForSeconds(1f);

				if(!War.isGameing) continue;

				if(buildSpotConfig != unitData.lastBuildSpotConfig)
				{
					buildSpotConfig = unitData.lastBuildSpotConfig;

					if(_buildSpotConfig == null && buildSpotConfig != null && _legionId == War.ownLegionID)
					{
						isMsg = true;
					}

					if(buildSpotConfig != null)
					{
						isEffect = true;
					}

					_buildSpotConfig = buildSpotConfig;
				}

				if(buildSpotConfig != null && _legionId != unitData.legionId)
				{
					
					_legionId = unitData.legionId;

					isEffect = true;
					
					if(_legionId == War.ownLegionID)
					{
						isMsg = true;
					}

				}

				if(isFirst)
				{
					isEffect = false;
					isMsg = false;
					isFirst = false;
				}

				if(isMsg)
				{
					War.textEffect.PlaySpot(buildSpotConfig.spotType, transform);
					isMsg = false;
				}


				if(isEffect)
				{
					GameObject go = War.pool.spotChange.Get();
					go.transform.position = transform.position;
					go.GetComponent<SpotChangeEffect>().SetColorId(legionData.colorId);
					go.SetActive(true);
					isEffect = false;
				}
			}
		}

	}
}