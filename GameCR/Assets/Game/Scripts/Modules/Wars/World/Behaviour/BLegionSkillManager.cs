using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class BLegionSkillManager : EBehaviour
	{
		/** 势力怒气管理 */
		public BLegionMage legionMage;

		/** 技能只能使用1次 */
		public bool onlyUseOnce;
		/** 技能条--凹槽数量 */
		public int barMaxCount = 3;
		/** 技能条--凹槽状态 (false为空，true为占用) */
		public Dictionary<int, bool> grooveStates = new Dictionary<int, bool>();

		/** 获取一个空凹槽 */
		public int GetGrooveIndex()
		{
			int index = -1;
			foreach(var item in grooveStates)
			{
				if(item.Value == false)
				{
					index = item.Key;
					break;
				}
			}

			return index;
		}

		protected override void OnStart ()
		{
			base.OnStart ();
			
			legionMage = GetComponent<BLegionMage>();

			if(legionData.skillDatas.Count == 0)
			{
				this.enabled = false;
				return;
			}

			
			legionMage.sFull += OnMageFull;
			War.signal.sSkillUse += OnSkillUse;
			War.signal.sHeroSettledBuild += OnHeroSettledBuild;


			Init();
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();
			
			legionMage.sFull -= OnMageFull;
			War.signal.sSkillUse -= OnSkillUse;
			War.signal.sHeroSettledBuild -= OnHeroSettledBuild;
			StopAllCoroutines();

		}

		/** 初始化 */
		void Init()
		{
			legionData.enableProduceSkillUids.Clear();

			// 初始化可生产技能列表
			foreach(KeyValuePair<int, SkillOperateData> kvp in legionData.skillDatas)
			{
				if(kvp.Value.isRoleSkill) continue;
				legionData.enableProduceSkillUids.Add(kvp.Key);
			}


			// 初始化技能凹槽
			for(int i = 0; i < barMaxCount; i ++)
			{
				grooveStates.Add(i, false);
			}
			
			// 设置当前正在生产的技能
			SetProduceSkill();
		}







		/** 设置当前正在生产的技能 */
		void SetProduceSkill()
		{
			if(legionData.produceSkillUid == -1)
			{
				// 怒气置0
				legionData.mage 			= 0f;
			}

			if(legionData.enableProduceSkillUids.Count > 0)
			{
				if (!War.isRecord) 
				{
					int index = Random.Range (0, legionData.enableProduceSkillUids.Count);
					int skillUid = legionData.enableProduceSkillUids [index];

					SetProduceSkill (skillUid);
				}
			}
			else
			{
				legionData.produceSkillUid = -1;
			}
		}

		SkillOperateData skillOperateData;
		bool isProduceComplete = true;
		public void SetProduceSkill(int skillUid, float speed = -1)
		{
			legionData.produceSkillUid = skillUid;

			if (isProduceComplete) 
			{
				skillOperateData = legionData.produceSkillData;
				isProduceComplete = false;
			}

			if (speed != -1)
			{
				legionData.unitData.mageSpeed = speed;
			}

			War.signal.DoSetProductionSkill (legionData.legionId, skillUid, legionData.unitData.mageSpeed);
		}

		/** 事件--怒气满 */
		void OnMageFull()
		{
			// 获取一个空凹槽
			int index = GetGrooveIndex();
			// 中断执行--没有空凹槽
			if(index == -1) return;
			// 中断执行--没有可以生产的技能
			if(legionData.produceSkillUid == -1) return;

			SkillOperateData skillOperateData = legionData.produceSkillData;
			if (War.isRecord && this.skillOperateData != null)
			{
				skillOperateData = this.skillOperateData;
			}

			// 设置技能”凹槽位置“
			skillOperateData.grooveIndex 		= index;
			skillOperateData.operateState 		= SkillOperateState.Normal;
			// 设置凹槽填充
			grooveStates[skillOperateData.grooveIndex] = true;

			// 从可生产列表删除
			legionData.enableProduceSkillUids.Remove(legionData.produceSkillUid);
			// 添加到技能栏列表
			legionData.barSkillUids.Add(legionData.produceSkillUid);
			
//			Debug.Log("legionData.enableProduceSkillIds.Count=" + legionData.enableProduceSkillUids.Count);
//			Debug.Log("legionData.barSkillIds.Count=" + legionData.barSkillUids.Count);


			// 怒气置0
			legionData.mage 			= 0f;
			// 设置下一个生产技能ID
			SetProduceSkill();
				

			if(legionData.legionId == War.ownLegionID)
			{
				War.signal.SkillProduceOwn (skillOperateData);
			}


			isProduceComplete = true;
			if (War.isRecord) 
			{
				this.skillOperateData = legionData.produceSkillData;
			}
		}


		/** 检测是否需要设置生成技能 */
		void CheckProduceSkill()
		{
			if(legionData.produceSkillUid == -1)
			{
				SetProduceSkill();
				CheckMageFull();
			}
		}
		
		/** 检测怒气是否满了，如果满了就生产一个技能 */
		void CheckMageFull()
		{
			if(legionData.mageFull)
			{
				OnMageFull();
			}
		}

		
		/** 事件--使用技能 */
		void OnSkillUse(SkillOperateData skillOperateData)
		{
			StartCoroutine(DelayOnSkillUse(skillOperateData));
		}

		/** 事件--使用技能 */
		IEnumerator DelayOnSkillUse(SkillOperateData skillOperateData)
		{
			yield return new WaitForSeconds(0.5f);

			if(skillOperateData.heroData.legionData == legionData)
			{
				skillOperateData.useNum ++;

				int skillUid = skillOperateData.uid;
				if(legionData.barSkillUids.Contains(skillUid))
				{
					// 从技能栏列表删除
					legionData.barSkillUids.Remove(skillUid);
					// 设置凹槽为空
					grooveStates[skillOperateData.grooveIndex] = false;
					
					Debug.Log("skillOperateData.skillConfig.isSettledBuild=" + skillOperateData.skillConfig.isSettledBuild);
					// 如果英雄不用入驻建筑
					if(skillOperateData.skillConfig.isSettledBuild == false)
					{
						if(onlyUseOnce == false)
						{
							if(skillOperateData.enableProduce && skillOperateData.isRoleSkill == false)
							{
								// 添加到生产列表
								legionData.enableProduceSkillUids.Add(skillUid);
							}
						}
					}
					else
					{
//						// 添加英雄回到幕后事件
//						skillOperateData.heroData.sBackstage += OnBackstage;
//						// 设置英雄入驻建筑ID
//						skillOperateData.heroData.buildId = skillOperateData.GetReceiveUnitCtl().unitData.id;
//						// 设置英雄为"幕前状态"
//						skillOperateData.heroData.state = HeroState.Foregstage;
//
//						Debug.Log("skillOperateData.heroData.state=" + skillOperateData.heroData.state);
					}

					// 检测是否需要设置生成技能
					CheckProduceSkill();
					// 检测怒气是否满了，如果满了就生产一个技能
					CheckMageFull();
				}
			}
		}
		
		/** 英雄--幕前事件 */
		void OnForegstage(HeroData heroData)
		{

		}


		/** 英雄--幕后事件 */
		void OnBackstage(HeroData heroData)
		{
			// 移除英雄回到幕后事件
			heroData.sBackstage -= OnBackstage;
			if(onlyUseOnce == false)
			{
				if(heroData.skillOperateData.enableProduce)
				{

					if(heroData.skillOperateData.skillConfig.cd > 0)
					{
						StartCoroutine(SkillCD(heroData.skillOperateData));
					}
					else
					{
						// 添加到生产列表
						legionData.enableProduceSkillUids.Add(heroData.skillOperateData.uid);
						// 检测是否需要设置生成技能
						CheckProduceSkill();
					}
				}
			}
		}

		void OnHeroSettledBuild(int legionId, int skillUid, int buildId)
		{
			if(legionId == legionData.legionId)
			{
				SkillOperateData skillOperateData = legionData.skillDatas[skillUid];

				if(skillOperateData.skillConfig.isSettledBuild)
				{
					// 添加英雄回到幕后事件
					skillOperateData.heroData.sBackstage += OnBackstage;
					// 设置英雄入驻建筑ID
					skillOperateData.heroData.buildId = buildId;
					// 设置英雄为"幕前状态"
					skillOperateData.heroData.state = HeroState.Foregstage;
					
//					Debug.Log("skillOperateData.heroData.state=" + skillOperateData.heroData.state);

				}
			}
		}

		IEnumerator SkillCD(SkillOperateData skillOperateData)
		{
			yield return new WaitForSeconds(skillOperateData.skillConfig.cd);

			// 添加到生产列表
			legionData.enableProduceSkillUids.Add(skillOperateData.uid);
			// 检测是否需要设置生成技能
			CheckProduceSkill();
		}

	}
}
