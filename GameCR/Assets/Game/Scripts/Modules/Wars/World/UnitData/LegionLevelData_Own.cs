using UnityEngine;
using System.Collections;
using Games.Module.Props;

namespace Games.Module.Wars
{

	public class LegionLevelData_Own : LegionLevelData
	{

		
		/** 添加经验--击杀英雄 */
		public override void AddExp_KillHero (UnitCtl unit)
		{
			base.AddExp_KillHero (unit);

			War.legionExpEffect.Play( LegionExpEffectType.L, unit);
		}
		
		/** 添加经验--进攻 */
		public override void AddExp_SoliderAtk (float num, UnitCtl unit)
		{
			base.AddExp_SoliderAtk (num, unit);

			War.legionExpEffect.Play( LegionExpEffectType.S, unit);
		}
		
		/** 添加经验--防守 */
		public override void AddExp_SoliderDef (float num, UnitCtl unit)
		{
			base.AddExp_SoliderDef (num, unit);

			War.legionExpEffect.Play( LegionExpEffectType.S, unit);
		}
		
		/** 添加经验--技能 */
		public override void AddExp_SoliderSkill (float num, UnitCtl unit)
		{
			base.AddExp_SoliderSkill (num, unit);
			
			War.legionExpEffect.Play( LegionExpEffectType.S, unit);
		}
		
		/** 添加经验--箭塔攻击 */
		public override void AddExp_SoliderTurret (float num, UnitCtl unit)
		{
			base.AddExp_SoliderTurret (num, unit);
			
			War.legionExpEffect.Play( LegionExpEffectType.S, unit);
		}

		
		/** 添加经验--占领 */
		public override void AddExp_Build (UnitCtl unit)
		{
			base.AddExp_Build (unit);
			
			War.legionExpEffect.Play( LegionExpEffectType.M, unit);
		}
	
	}
}