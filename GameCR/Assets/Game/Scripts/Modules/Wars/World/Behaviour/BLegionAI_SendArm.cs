using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class BLegionAI_SendArm : EBehaviour
	{
		public int legionId;
		public AIConfig aiConfig;
		public float intervalMin; 
		public float intervalMax; 
		public  float _updateTime;
		public float distanceScoreRate_Attack = 1f;
		public float distanceScoreRate_Rescue = 1f;
		public List<UnitCtl> ownBuilds;

		protected override void OnStart ()
		{
			base.OnStart ();

			if(legionData.aiConfig == null)
			{
				enabled = false;
				return;
			}
			legionId = legionData.legionId;
			aiConfig = legionData.aiConfig;
			distanceScoreRate_Attack = aiConfig.distanceScoreRate_Attack;
			distanceScoreRate_Rescue = aiConfig.distanceScoreRate_Rescue;
			intervalMax = aiConfig.interval;
			intervalMin = Mathf.Max(intervalMax - aiConfig.intervalRandom, 0f);


			_updateTime = Time.time + Random.Range(intervalMin, intervalMax) + War.sceneData.begionDelayTime;
		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			
			if(!War.isGameing)
			{
				_updateTime = Time.time + Random.Range(intervalMin, intervalMax) + War.sceneData.begionDelayTime;
				return;
			}
			if(!legionData.aiSendArm) return;
			if(unitData.freezedSendArm) return;
			if(!War.sceneData.enableAISendArm) return;
			if(Time.time > _updateTime)
			{
				_updateTime = Time.time + Random.Range(intervalMin, intervalMax);
				Execute();
			}
		}

		void Execute()
		{
			
			ownBuilds = War.scene.GetBuilds(legionId);
			if(ownBuilds.Count <= 0) return;
			// 排序自己兵力最多的建筑
			ownBuilds.Sort(delegate(UnitCtl A, UnitCtl B)
			               {
				return Mathf.RoundToInt(B.unitData.hp - A.unitData.hp);
			});



			float hpRate = War.scene.totalHP == 0 ? 1 : War.scene.GetLegionHP(legionId) /  War.scene.totalHP;
			if(aiConfig.GetIsRescue(hpRate))
			{
				if(!Rescue())
				{
					Attack();
				}
			}
			else
			{
				Attack();
			}
		}

		bool Rescue()
		{
			
//			Debug.Log("--------------Rescue--------------");
			
			// 救援,随机派部队数量
			int sendCount = aiConfig.GetRescueSendCount();
//			Debug.Log("救援,随机派部队数量 sendCount=" + sendCount);
			if(sendCount <= 0) return false;
			
			UnitCtl rescueUnit = null;
			float minRescueScore = 9999999;
			foreach(UnitCtl build in ownBuilds)
			{
				build.unitData.GenerationFromLegionUnitTotalNum();
				if(build.unitData.attackUnitNum > 0)
				{
					float distance = 0;
					foreach(UnitCtl buildB in ownBuilds)
					{
						if(build == buildB) continue;
						distance += War.scene.GetBuildDistance(build, buildB);
					}
					distance = ownBuilds.Count > 1 ? distance / (ownBuilds.Count - 1) : 0; ;
					build.unitData.rescueScore = build.hp + distance * distanceScoreRate_Rescue;
					
					if(build.unitData.rescueScore < minRescueScore)
					{
						minRescueScore = build.unitData.rescueScore;
						rescueUnit = build;
					}
				}
			}

			if(rescueUnit == null) return false;

			// 救援,生成派兵的建筑
			List<UnitCtl> ownSelectBuilds = new List<UnitCtl>();
			int index = 0;
			foreach(UnitCtl build in ownBuilds)
			{
				if(index < sendCount && build != rescueUnit)
				{
					ownSelectBuilds.Add(build);
					index ++;
					if(index >= sendCount) break;
				}
			}

			if(ownSelectBuilds.Count <= 0) return false;


			bool isSend = true;

			float rescueHP = 0;
			foreach(UnitCtl ownBuild in ownSelectBuilds)
			{
				rescueHP += ownBuild.unitData.hp * aiConfig.sendArmPercent;
			}

			float enemyHP = 0;
			foreach (KeyValuePair<int, int> kvp in rescueUnit.unitData.fromLegionUnitTotalNumDict)
			{
				if(kvp.Value > 0)
				{
					
					LegionData itemLegionData = War.GetLegionData(kvp.Key);
					if(unitData.GetRelation(itemLegionData.legionId) == RelationType.Enemy)
					{
						enemyHP += WarFormula.WD_Solider2Casern_Damage(rescueUnit.unitData.def, itemLegionData.soliderInitData.atk, kvp.Value * itemLegionData.soliderData.hp2UnitRate);
					}
					else
					{
						rescueHP += kvp.Value * itemLegionData.soliderData.hp2UnitRate ;
					}
				}
			}

			isSend = rescueHP > enemyHP;
			
			if(isSend)
			{
//				Debug.Log("<color=blue>救援</color>");
				foreach(UnitCtl ownBuild in ownSelectBuilds)
				{
					BSendArming bSendArming = ownBuild.GetComponent<BSendArming>();
					bSendArming.Send(rescueUnit, aiConfig.sendArmPercent);
				}
			}


			
			return isSend;

		}

		bool Attack()
		{
//			Debug.Log("--------------Attack--------------");
			if(aiConfig.attackLevel == AIAttackLevel.Level_0_Lazy) return false;
			
			

			
			// 攻击,随机派部队数量
			int sendCount = aiConfig.GetAttackSendCount();
//			Debug.Log("攻击,随机派部队数量 sendCount=" + sendCount);
			if(sendCount <= 0) return false;
			
			// 攻击,生成派兵的建筑
			List<UnitCtl> ownSelectBuilds = new List<UnitCtl>();
			int index = 0;
			foreach(UnitCtl build in ownBuilds)
			{
				if(index < sendCount)
				{
					if(build.hp <= 0) continue;
					if(build.unitData.behit &&  Random.Range(0f, 1f) > aiConfig.attackBehitRate)
					{
						continue;
					}
					ownSelectBuilds.Add(build);
					index ++;
				}
				if(index >= sendCount) break;
			}
			
			// 计算敌人建筑被攻击值
			List<UnitCtl> enemyBuilds = War.scene.GetEnemyBuilds(legionId);
			if(enemyBuilds.Count <= 0) return false;
			
			foreach(UnitCtl enemyBuild in enemyBuilds)
			{
				float distance = 0;
				foreach(UnitCtl ownBuild in ownSelectBuilds)
				{
					distance += War.scene.GetBuildDistance(enemyBuild, ownBuild);
				}
				
				distance /= ownSelectBuilds.Count;
				enemyBuild.unitData.attackScore = enemyBuild.unitData.hp + distance * distanceScoreRate_Attack;

//				Debug.Log(string.Format("<color=grey>id={0}, hp={1}, distance={2}, attackValue={3}</color>", enemyBuild.unitData.id, enemyBuild.unitData.hp, distance, enemyBuild.unitData.attackScore));
			}
			
			// 排序敌人建筑被攻击值
			enemyBuilds.Sort(delegate(UnitCtl A, UnitCtl B)
			                 {
									return Mathf.RoundToInt(A.unitData.attackScore - B.unitData.attackScore);
								});
			
			// 随机选择敌人建筑
			int enemyIndex = aiConfig.GetAttackTargetIndex();
			if(enemyIndex >= enemyBuilds.Count) enemyIndex = enemyBuilds.Count - 1;
			
//			Debug.Log("随机选择敌人建筑 enemyIndex=" + enemyIndex);
			
			UnitCtl targetBuild = enemyBuilds[enemyIndex];
			
			bool isSend = true;
			if(aiConfig.attackLevel == AIAttackLevel.Level_1_Cautious)
			{
				float hp = 0;
				foreach(UnitCtl ownBuild in ownSelectBuilds)
				{
					hp += ownBuild.unitData.hp * aiConfig.sendArmPercent;
//					Debug.Log("HP" + hp);
				}
				
				hp = WarFormula.WD_Solider2Casern_Damage(targetBuild.unitData.def, unitData.legionData.soliderInitData.atk, hp);
				isSend = hp > targetBuild.unitData.hp;
			}
			
			
			if(isSend)
			{
//				Debug.Log("<color=blue>攻击</color>");
				foreach(UnitCtl ownBuild in ownSelectBuilds)
				{
//					Debug.LogFormat("<color=blue>ownBuild.hp={0},  aiConfig.sendArmPercent=</color>", ownBuild.hp, aiConfig.sendArmPercent);
					BSendArming bSendArming = ownBuild.GetComponent<BSendArming>();
					bSendArming.Send(targetBuild, aiConfig.sendArmPercent);
				}
			}

			return isSend;
		}



	}
}