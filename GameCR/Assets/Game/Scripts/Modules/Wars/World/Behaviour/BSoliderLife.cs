using UnityEngine;
using System.Collections;
using CC.Runtime;
using CC.Runtime.Actions;
using RayPaths;


namespace Games.Module.Wars
{
	public class BSoliderLife : EBehaviour
	{
		
		public DelayDestory delayDestory;
		protected override void OnStart ()
		{
			base.OnStart ();
			
			if(delayDestory == null) delayDestory = GetComponent<DelayDestory>();
		}
		

		
		public bool _death = false;
		protected override void OnUpdate ()
		{
			base.OnUpdate ();

			if(unitData == null) return;

			if(!unitData.death && unitData.hp <= 0)
			{
				unitData.death = true;
			}
			
			if(_death != unitData.death)
			{
				_death = unitData.death;
				if(_death)
				{
					SoliderPoolItem soliderPoolItem = GetComponent<SoliderPoolItem>();
					UnitPath unitPath = GetComponent<UnitPath>();
					unitPath.state = UnitPathState.Die;
					if(unitData.isHitFly)
					{
						unitAgent.HitFly();
						if(soliderPoolItem != null)
						{
							//							soliderPoolItem.DelayRelease(3F);
							soliderPoolItem.Release();
						}
						else
						{
							delayDestory.delayTime = 3F;
							delayDestory.enabled = true;
						}
					}
					else
					{
						if(soliderPoolItem != null)
						{
							soliderPoolItem.Release();
						}
						else
						{
							delayDestory.delayTime = 0F;
							delayDestory.enabled = true;
						}
					}
				}
			}
		}

		protected override void OnDisable ()
		{
			base.OnDisable ();
			
			if(unitData != null && unitData.to != null) unitData.to.RemoveFromLegionUnit(unitData.legionId, 1);
		}

		
		public override void OnRelease ()
		{
			if(unitData != null && unitData.to != null) unitData.to.RemoveFromLegionUnit(unitData.legionId, 1);
			base.OnRelease();
		}


		public void OnRest()
		{
			_death = false;
		}


		protected override void OnDestroy ()
		{
			base.OnDestroy ();
//			Debug.Log("OnDestroy " + gameObject.name);
		}

	}
}
