using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class DamageVO
	{
		public UnitCtl caster;
		public UnitCtl target;

		public DamageFromType 	fromType = DamageFromType.Skill;
		public DamageType 		damageType;
		public float value;
		public bool enableOverMax = false;


		public Vector3 hitFlyPoint;
		public float hitFlyPower = -1;
		public float hitFlyPowerRadius = -1;
		public float hitFlyPowerUp = -1;

		
		public DamageVO()
		{
		}

		public DamageVO Clone()
		{
			DamageVO vo = new DamageVO();
			vo.caster = caster;
			vo.target = target;
			vo.damageType = damageType;
			vo.value = value;
			vo.enableOverMax = enableOverMax;
			vo.hitFlyPoint = hitFlyPoint;
			vo.hitFlyPower = hitFlyPower;
			vo.hitFlyPowerRadius = hitFlyPowerRadius;
			vo.hitFlyPowerUp = hitFlyPowerUp;
			return vo;
		}
	}
}

