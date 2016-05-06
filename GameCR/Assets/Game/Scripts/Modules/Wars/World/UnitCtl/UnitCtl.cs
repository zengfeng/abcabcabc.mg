using UnityEngine;
using System.Collections;
using CC.Runtime;
using CC.Runtime.Utils;
using Games.Module.Props;
using CC.Runtime.signals;
using RayPaths;

namespace Games.Module.Wars
{
	public class UnitCtl : EBehaviour 
	{
		/** 伤害事件 */
		public delegate void DamageEventHandler(DamageVO damageVO);
		/** 伤害事件--应用伤害前 */
		public event DamageEventHandler BeforeDamage;
		/** 伤害事件--应用伤害 */
		public event DamageEventHandler OnDamage;

		#region prop
		/** 是否死亡 */
		public bool death		{	get{return unitData.death;}		}
		/** 兵力上限 */
		public float hpMax 		{	get{return unitData != null ? unitData.maxHp : 100;} 	set{if(unitData != null) unitData.maxHp = value;}	}
		/** 当前兵力 */
		public float hp			{	get{return unitData != null ? unitData.hp : 0;} 		set{if(unitData != null) unitData.hp = value;}		}

        #endregion

#if UNITY_EDITOR
        public float moveSpeed;
		public float produceSpeed;
		public float atk;
		public float def;
		public float battleForce;
		public float speedAtk;
        public bool freezedSendArm;
        public bool freezedProduce;
		public bool freezedMoveSpeed;
		public bool build_produce;
        public bool hasHero;
#endif




        /** 渲染层 */
        public RenderLayer renderLayer;
		public UnitAnchor anchor;
		public BBuildChangeManager buildChangeManager;


		protected override void OnAwake ()
		{
			base.OnAwake ();
			renderLayer = GetComponent<RenderLayer>();
			anchor = GetComponent<UnitAnchor>();
			buildChangeManager = GetComponent<BBuildChangeManager>();
		}
		
		



		protected override void OnStart ()
		{
			base.OnStart ();

			OnRest();

//			//TODO test log
//			if(event3D != null) event3D.sDown.AddListener(OnDown);
		}

#if UNITY_EDITOR
		protected override void OnUpdate ()
		{
			base.OnUpdate ();


			if (unitData == null)
				return;

			moveSpeed = unitData.moveSpeed;
			produceSpeed = unitData.produceSpeed;
			atk = unitData.atk;
			def = unitData.def;
			battleForce = unitData.Props[PropId.BattleForce];
			speedAtk = unitData.Props[PropId.SpeedAtk];
            freezedSendArm = unitData.freezedSendArm;
            freezedProduce = unitData.freezedProduce;
            freezedMoveSpeed = unitData.freezedMoveSpeed;
			build_produce = unitData.build_produce;
            hasHero = unitData.hasHero;

        }
#endif

		void OnDown()
		{
			Debug.Log(unitData + "   Props="+ unitData.Props.ToStrProp ());
		}

		protected override void OnEnable ()
		{
			base.OnEnable ();

		}



		protected override void OnDisable ()
		{
			if(unitData != null) unitData.RevokeAll();
			if(War.scene != null) War.scene.OnRemoveUnit(this);
			base.OnDisable ();
		}


		#region build skill
		public void BuildChangeBuildConfig(int buildId)
		{
			buildChangeManager.BuildChangeConfig(buildId);
		}

		public void BuildAttachModule(AbstractBuildConfig config)
		{
			buildChangeManager.BuildAttachModule(config);
		}
		
		public void BuildSkillUplevel()
		{
			levelData.SkillUplevelHandler();
		}
		#endregion


		public void BackHome()
		{
			GetComponent<UnitPath>().BackHome();
		}

		
		/** zdl 接收技能伤害 */
        /*
         *val:改变值，若是伤害为负数
         *isOverMax:是否可以超过最大值
       */
		public void Damage(float val, int isOverMax, UnitCtl caster)
		{
			DamageVO damageVO = new DamageVO();
			damageVO.caster = caster;
			damageVO.target = unitCtl;
			damageVO.fromType = DamageFromType.Skill;
			damageVO.damageType = val < 0 ? DamageType.ATTACK : DamageType.HEAL;
			damageVO.value = val < 0 ? -val : val;
			damageVO.enableOverMax = isOverMax == 1;
			Damage(damageVO);
		}

		public void Damage(float val, int isOverMax, UnitCtl caster, Vector3 hitFlyPoint, float hitFlyPower = -1, float hitFlyPowerRadius = -1, float hitFlyPowerUp = -1)
		{
			Damage(val, isOverMax, caster);

			if(unitData.unitType == UnitType.Solider && hp <= 0)
			{
				unitData.isHitFly = true;
				unitData.hitFlyPoint = hitFlyPoint;
				if(hitFlyPower > 0)unitData.hitFlyPower = hitFlyPower;
				if(hitFlyPowerRadius > 0)unitData.hitFlyPowerRadius = hitFlyPowerRadius;
				if(hitFlyPowerUp > 0)unitData.hitFlyPowerUp = hitFlyPowerUp;
			}
		}


		/** 接收技能伤害 */
		public void DamageToDeath(UnitCtl caster)
		{
			if(unitData == null)
			{
				Debug.LogFormat("<color=yellow>UnitCtl 已经死亡，缓存  gameObject={0}</color>", gameObject );
				return;
			}
			War.signal.HPConst(unitData.legionId, caster.unitData.legionId, hp);
			War.hunManager.Play(this);
			caster.legionData.levelData.AddExp_SoliderSkill(hp, this);
			hp = 0;
		}

		public void DamageToDeath(UnitCtl caster, Vector3 hitFlyPoint, float hitFlyPower = -1, float hitFlyPowerRadius = -1, float hitFlyPowerUp = -1)
		{
			DamageToDeath(caster);
			
			if(hp <= 0)
			{
				unitData.isHitFly = true;
				unitData.hitFlyPoint = hitFlyPoint;
				if(hitFlyPower > 0)unitData.hitFlyPower = hitFlyPower ;
				if(hitFlyPowerRadius > 0)unitData.hitFlyPowerRadius = hitFlyPowerRadius;
				if(hitFlyPowerUp > 0)unitData.hitFlyPowerUp = hitFlyPowerUp;
			}
		}

		/// <summary>
		/// 总伤害分X次数，平均化
		/// </summary>
		/// <param name="damageVO">总伤害数据</param>
		/// <param name="delay">第一次延迟多长时间.</param>
		/// <param name="gapTime">连续的间隔时间 time.</param>
		/// <param name="count">次数.</param>
		public void Damage(DamageVO damageVO, float delay, float gapTime, int count)
		{
			StartCoroutine(AverageDamage(damageVO, delay, gapTime, count));
		}

		IEnumerator AverageDamage(DamageVO damageVO, float delay, float gapTime, int count)
		{
			yield return new WaitForSeconds(delay);
			if(count <= 0) count = 1;
			float totalVal = damageVO.value;
			if(Mathf.Abs(totalVal) < count)
			{
				count = Mathf.CeilToInt(Mathf.Abs(totalVal));
			}
			float averageVal = totalVal / count;
			for(int i = 0; i < count; i ++)
			{
				try
				{
					DamageVO vo = damageVO.Clone();
					vo.value = averageVal;
					Damage(vo);
				}
				catch(System.Exception e)
				{
					if (Application.isEditor)
						Debug.Log (e);

					break;
				}
				yield return new WaitForSeconds(gapTime);
			}
		}

		/** 接收技能伤害 */
		public void Damage(DamageVO damageVO)
		{
			if(unitData == null || (unitData.invincible && damageVO.damageType != DamageType.HEAL))
			{
				return;
			}

			if (BeforeDamage != null)
				BeforeDamage(damageVO);


			if(damageVO.value == 0) return;

//			Debug.Log(string.Format("damageVO.damageType={0}, damageVO.value={1}", damageVO.damageType, damageVO.value));
			if (damageVO.damageType == DamageType.HEAL)
			{
				float legionHP = 0;
				if(War.vsmode == VSMode.PVE_Expedition)
				{
					legionHP = War.scene.GetLegionHP(legionData.legionId);

					if(legionHP + damageVO.value > legionData.expeditionTotalMaxHP)
					{
						damageVO.value = legionData.expeditionTotalMaxHP - legionHP;
					}
				}

				
				float addHP = damageVO.value;

				if(damageVO.enableOverMax)
				{
					hp += addHP;
				}
				else
				{
					bool isPerOver = hp > hpMax;
					if(isPerOver == false)
					{
                        float addHPTmp = hpMax - hp;
                        addHP = addHPTmp > addHP ? addHP : addHPTmp;
                        hp += addHP;
					}
					else
					{
						addHP = 0;
						return;
					}
				}

				
				War.textEffect.PlayHP(addHP, this, 60);
				War.signal.HPAdd (unitData.legionId, damageVO.caster.unitData.legionId, addHP);

				if(War.vsmode == VSMode.PVE_Expedition)
				{
					if(legionData.expeditionTotalHP >= legionData.expeditionTotalMaxHP)
					{
						legionData.expeditionLeftHP = legionData.expeditionTotalMaxHP - legionHP - addHP;
					}
				}

			}
			else
			{
				unitData.behit = true;
				hp -= damageVO.value;

				float consHp = damageVO.value;
				if(hp < 0) consHp =damageVO.value + hp;

				if(unitData.unitType != UnitType.Solider)
				{
					War.textEffect.PlayHP(-consHp, this, 60);
				}

				War.signal.HPConst(unitData.legionId, damageVO.caster.unitData.legionId, consHp);

				if(damageVO.fromType == DamageFromType.Turret)
				{
					damageVO.caster.legionData.levelData.AddExp_SoliderTurret(consHp, this);
				}
				else
				{
					damageVO.caster.legionData.levelData.AddExp_SoliderSkill(consHp, this);
				}
			}
		

			if(hp <= 0)
			{
				hp = 0;

				if(unitData.unitType == UnitType.Solider)
				{
					War.hunManager.Play(this);
//					unitData.isHitFly = true;
//					unitData.hitFlyPoint = damageVO.hitFlyPoint;
//					if(damageVO.hitFlyPower > 0)unitData.hitFlyPower 				= damageVO.hitFlyPower;
//					if(damageVO.hitFlyPowerRadius > 0)unitData.hitFlyPowerRadius	= damageVO.hitFlyPowerRadius;
//					if(damageVO.hitFlyPowerUp > 0)unitData.hitFlyPowerUp 			= damageVO.hitFlyPowerUp;
				}
			}
			
			if (OnDamage != null)
				OnDamage(damageVO);
		}


		/** 接收士兵伤害 */
		public void DamageBehit(DamageVO damageVO)
		{

			if(unitData.invincible && damageVO.damageType != DamageType.HEAL)
			{
				return;
			}


			if (BeforeDamage != null)
				BeforeDamage(damageVO);

			
			if (damageVO.damageType == DamageType.HEAL)
			{
				hp += damageVO.value;
				War.textEffect.PlayHP(damageVO.value, this);
			}
			else
			{
				hp -= damageVO.value;
                unitData.beattack = true;

//				Debug.Log(string.Format("hpbug UnitCtl.DamageBehit atk={0}, def={1},  hp={2}, damageVO.value={3}", atk, def,  hp, damageVO.value));
				
				float consHp = damageVO.value;
				if(hp < 0) consHp =damageVO.value + hp;

				float def2AtkHP = WarFormula.WD_RelativelyHP_Def2Atk(unitData.def, damageVO.caster.unitData.atk, consHp);
				
				War.textEffect.PlayHP(-consHp, this);

				War.signal.HPConst(unitData.legionId, damageVO.caster.unitData.legionId, consHp);
				War.signal.HPConst(damageVO.caster.unitData.legionId, unitData.legionId, def2AtkHP);

			
				War.hunManager.Play(damageVO.caster);
				
				if(consHp != 0) War.hunManager.Play(unitData.colorId, transform.position + new Vector3(Random.Range(-2, 2), 0f, Random.Range(-2, 2)));

				// 添加经验--进攻
				damageVO.caster.legionData.levelData.AddExp_SoliderAtk(consHp, damageVO.caster);
				// 添加经验--防守
				damageVO.target.legionData.levelData.AddExp_SoliderDef(def2AtkHP, damageVO.caster);
			}

			
			
			if (OnDamage != null)
				OnDamage(damageVO);
			
		}
	

		/** 渲染层--当前技能播放层 */
		virtual public void SkillLayer()
		{
			if(renderLayer != null)
			{
				renderLayer.sortingLayer = RenderLayer.Layer.War_HeroSkill;
			}
		}
		
		/** 渲染层--正常层 */
		virtual public void NormalLayer()
		{
			if(renderLayer != null)
			{
				renderLayer.sortingLayer = RenderLayer.Layer.Default;
			}
		}

		
		/** 继续 */
		virtual public void Resume()
		{
			
			unitData.pause = false;

			UnitAgent agent = GetComponent<UnitAgent>();
			if (agent != null)
				agent.Resume();

			
			BSendArming sendArming = GetComponent<BSendArming>();
			if (sendArming != null)
				sendArming.enabled = true;

			
			BProduce produce = GetComponent<BProduce>();
			if (produce != null)
				produce.enabled = true;
			
			BMoveArrived move = GetComponent<BMoveArrived>();
			if (move != null)
				move.Resume();


		}
		
		
		/** 暂停 */
		virtual public void Pause()
		{
			unitData.pause = true;

			UnitAgent agent = GetComponent<UnitAgent>();
			if (agent != null)
				agent.Pause();

			
			BSendArming sendArming = GetComponent<BSendArming>();
			if (sendArming != null)
				sendArming.enabled = false;

			
			BProduce produce = GetComponent<BProduce>();
			if (produce != null)
				produce.enabled = false;

			BMoveArrived move = GetComponent<BMoveArrived>();
			if (move != null)
				move.Pause();

		}

		
		public void OnRest ()
		{
			if(War.scene != null) War.scene.OnAddUnit(this);
		}

		public override void OnRelease ()
		{
			if(unitData != null) unitData.RevokeAll();
			if(War.scene != null) War.scene.OnRemoveUnit(this);

			
			if(unitData.to != null && unitData.to.aroundList.Contains(unitData))
			{
				unitData.to.aroundList.Remove(unitData);
			}

			if(unitData != null)
			{
				RemoveEC(unitData);
				unitData.OnRelease();
			}
			
			
			if(levelData != null)
			{
				RemoveEC(levelData);
				levelData.OnRelease();
			}
			
			
			if(heroData != null)
			{
				RemoveEC(heroData);
				heroData.OnRelease();
			}
			
			
			if(produceData != null)
			{
				RemoveEC(produceData);
				produceData.OnRelease();
			}
			
			
			if(sendArmData != null)
			{
				RemoveEC(sendArmData);
				sendArmData.OnRelease();
			}

			base.OnRelease ();
			StopAllCoroutines();
			BeforeDamage = null;
			OnDamage = null;
		}



	

	}
}