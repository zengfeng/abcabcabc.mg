using UnityEngine;
using System.Collections;
using Games.Module.Props;

namespace Games.Module.Wars
{
	public class BProduce : EBehaviour
	{
		private float delayTime = 2;
		private float delay = 0f;
		public float gap = 0.2f;

		protected override void Start ()
		{
			base.Start ();

			delayTime = Mathf.Max(War.sceneData.begionDelayTime, 2);
		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			if(War.processState != WarProcessState.Gameing) return;
			if(delay < delayTime)
			{
				delay += Time.deltaTime;
				return;
			}


			unitData.isProduceing = false;
			if(!War.sceneData.enableProduce) return;
			if(!unitData.build_produce) return;
			if(unitData.death) return;
			if(!legionData.produce) return;
			if(unitData.freezedProduce) return;
			if(produceData.produceLimit && unitData.hp >= produceData.produceLimitNum) return;
			unitData.isProduceing = true;

			if(War.vsmode != VSMode.PVE_Expedition && War.scene.GetLegionHP(unitData.legionId) >= legionData.totalMaxHP) return;
			if(War.vsmode == VSMode.PVE_Expedition && legionData.expeditionLeftHP <= 0) return;



			if(produceData.produceType == ProduceType.Prop)
			{
				if(produceData.propId == PropId.HpAdd)
				{
					if(unitData.hp < unitData.maxHp)
					{
						produceData.time += Time.deltaTime;
						if(produceData.time >= gap)
						{
							produceData.time = 0;
							float produceSpeedVal = produceData.ProduceSpeed * gap * War.sceneData.weight.produceSpeed;
							float addHP = unitData.hp + produceSpeedVal < unitData.maxHp ? produceSpeedVal : Mathf.CeilToInt(unitData.maxHp -  unitData.hp);
							if(War.vsmode == VSMode.PVE_Expedition)
							{
								if(addHP > legionData.expeditionLeftHP) addHP = legionData.expeditionLeftHP;
							}

							unitData.hp += addHP;
							legionData.expeditionLeftHP -= addHP;
							if(produceData.produceLimit && unitData.hp > produceData.produceLimitNum) unitData.hp = produceData.produceLimitNum;
						}
					}
				}
			}
		}
	}
}
