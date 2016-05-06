using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games.Module.Props;

namespace Games.Module.Wars
{

	public class BStateEffect_Build : EBehaviour
	{
		public bool 		isProduceing;
		public int 			stateProduceSpeedUp;

		private bool 		_isProduceing;
		private int 		_stateProduceSpeedUp;

		public AbstateStateBuffLevel stateBuffLevel_produceSpeed;
		protected override void OnStart ()
		{
			base.OnStart ();
		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();

			if(stateProduceSpeedUp != unitData.Props[PropId.StateProduceSpeedUp])
			{
				stateProduceSpeedUp = (int) unitData.Props[PropId.StateProduceSpeedUp];

			}

			if(isProduceing != unitData.isProduceing)
			{
				isProduceing = unitData.isProduceing;
			}


			if(_isProduceing != isProduceing || _stateProduceSpeedUp != stateProduceSpeedUp)
			{
				_stateProduceSpeedUp = stateProduceSpeedUp;
				_isProduceing = isProduceing;

				if(_isProduceing)
				{
					OnStageChange_ProduceSpeedUp(_stateProduceSpeedUp);
				}
				else
				{
					OnStageChange_ProduceSpeedUp(0);
				}
			}
		}


		void OnStageChange_ProduceSpeedUp(int level)
		{
			if(level == 0)
			{
				if(stateBuffLevel_produceSpeed != null)
				{
					if(stateBuffLevel_produceSpeed != null) stateBuffLevel_produceSpeed.Release();
					stateBuffLevel_produceSpeed = null;
				}
			}
			else
			{
				if(stateBuffLevel_produceSpeed != null)
				{
					stateBuffLevel_produceSpeed.SetLevel(level, legionData.colorId);
				}
				else
				{
					GameObject go = War.pool.stateBuffProduceSpeedUp.Get();
					stateBuffLevel_produceSpeed = go.GetComponent<AbstateStateBuffLevel>();
					stateBuffLevel_produceSpeed.SetLevel(level, legionData.colorId);
					go.transform.SetParent(transform, false);
					go.transform.localPosition = Vector3.zero;
					go.transform.localEulerAngles = Vector3.zero;
					go.SetActive(true);
				}
			}
		}
	}

}