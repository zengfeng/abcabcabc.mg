using UnityEngine;
using System.Collections;
using System;

namespace Games.Module.Wars
{
	public class BLegionMage : EBehaviour
	{
		public Action sFull;
		public float delaySendFullSingalTime = 0.2f;
		public float gapTime = 0.1f;
		public float val = 10f ;
		public float time = 0;
		public bool runing = true;
		private bool isTest = false;

		public float mageSpeed = 0;
		public float maxMage = 0;

		public bool aiSendArm;
		public bool aiSkill;
		public bool aiUplevel;
		public bool produce;
		private float _delay = 0;

		protected override void OnStart ()
		{
			base.OnStart ();

			if(legionData.skillDatas.Count == 0)
			{
				this.enabled = false;
			}
		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			if(!War.isGameing) return;
			if (!War.sceneData.enableProduceSkill) return;

			if(_delay < War.sceneData.begionDelayTime)
			{
				_delay += Time.deltaTime;
				return;
			}

#if UNITY_EDITOR
			mageSpeed = unitData.mageSpeed;
			maxMage = unitData.maxMage;

			
			aiSendArm = legionData.aiSendArm;
			aiSkill = legionData.aiSkill;
			aiUplevel = legionData.aiUplevel;
			produce = legionData.produce;
#endif

			runing = !legionData.mageFull;
			if(!runing) return;
			time += Time.deltaTime;
			if(time >= gapTime)
			{
				time = time - gapTime;
				time = 0;

				if(War.isTest == false)
				{
					val = unitData.mageSpeed * gapTime * War.sceneData.weight.skillProduceSpeed;
				}


				unitData.mage += val;
				if(unitData.mage >= unitData.maxMage)
				{
					unitData.mage = unitData.maxMage;
					runing = false;
					StartCoroutine(DelaySendFullSingal());
				}
			}
		}

		IEnumerator DelaySendFullSingal()
		{
			yield return new WaitForSeconds(delaySendFullSingalTime);
			if(sFull != null) sFull();
		}
	}
}
