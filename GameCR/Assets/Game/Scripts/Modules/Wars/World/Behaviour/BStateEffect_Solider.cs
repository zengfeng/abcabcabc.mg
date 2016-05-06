using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Module.Wars
{

	public class BStateEffect_Solider : EBehaviour
	{
		public bool burn = false;
		public bool freezedMoveSpeed = false;
		protected override void OnStart ()
		{
			base.OnStart ();
		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();

			if(burn != unitData.burn)
			{
				burn = unitData.burn;
				OnStageChange_Burn();
			}

			
			if(freezedMoveSpeed != unitData.freezedMoveSpeed)
			{
				freezedMoveSpeed = unitData.freezedMoveSpeed;
				OnStageChange_FreezedMoveSpeed();
			}
		}


		void OnStageChange_Burn()
		{

		}

		
		void OnStageChange_FreezedMoveSpeed()
		{
			
		}
	}

}