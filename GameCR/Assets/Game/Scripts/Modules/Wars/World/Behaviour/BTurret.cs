using UnityEngine;
using System.Collections;
using System.Security.Policy;
using CC.Runtime.Actions;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class BTurret : EBehaviour 
	{
		public float attackCD = 0f;


		protected override void OnUpdate ()
		{
			base.OnUpdate ();

			if(!War.isGameing) return;
			if(War.isRecord) return;
			if(!unitData.build_turret) return;

			attackCD += Time.deltaTime;
			if(attackCD >= unitData.attackSpeed)
			{
				attackCD = 0;

				if (!War.IsSendService (legionData))return;

				int unitType = 0;
				unitType = unitType.USolider(true);

				int relation = 0;
				relation = relation.REnemy(true);

				UnitCtl target = War.scene.SearchUnit_MinDistance(transform.position, unitData.attackRadius, unitType, unitData.legionId, relation);
				if(target != null)
				{
					Atk(target);
				}
			}
		}

		public void Atk(UnitCtl solider)
		{
			if(War.requireSynch)
			{
				War.pvp.C_Turret(unitCtl, solider);
			}
			else
			{
				ExeAtk(solider);
			}
		}


		public void ExeAtk(UnitCtl target)
		{
			target.unitData.isTurretHit = true;

			GameObject prefab =  WarRes.GetPrefab(WarRes.Turret_Fx_Projectile);
			GameObject go = GameObject.Instantiate<GameObject>(prefab);
			go.transform.position = transform.position + Vector3.up * 3f;
			TurretProjectile projectile = go.AddComponent<TurretProjectile>();
			projectile.curveType = ProjectType.Line;
			projectile.duration = unitData.attackSpeed * 0.5f;
			projectile.targetTransform = target.transform;
			projectile.explosionPrefab = WarRes.GetPrefab(WarRes.Turret_Fx_Explosion);
			projectile.completeArg = target;
			projectile.OnCompleteHandler += OnProjectileComplete;

			War.signal.DoTurretAtk (unitCtl.unitData.uid, target.unitData.uid);
		}

		void OnProjectileComplete(object obj)
		{
			if(obj == null) return;
			UnitCtl enemy = (UnitCtl)obj;
			if(enemy == null) return;


			DamageVO damageVO = new DamageVO();
			damageVO.caster = unitCtl;
			damageVO.target = enemy;
			damageVO.value = unitData.attackDamage;;
			damageVO.fromType = DamageFromType.Turret;
			damageVO.damageType = DamageType.ATTACK;
			damageVO.hitFlyPoint = transform.position;


			damageVO.target.Damage(damageVO);

		}
	}
}