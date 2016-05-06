using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.signals;
using Games.Module.Wars;
using Games.Module.Props;
using CC.Runtime;


namespace Games.Module.Wars
{
	public partial class WarScene : EntityMBBehaviour 
	{
		public StageWeightConfig weightConfig;
		public GameObject maskCollider;
		public Transform rootWalls;
		public Transform rootShadow;
		public Transform rootPlayers;
		public Transform rootCaserns;
		public Transform rootSoliders;
		public Transform rootHeros;
		public Transform 	rootHeroHeads;
		public Transform 	rootSkillHeadBar;
		public Transform	rootUnitHP;
		public Transform	rootUnitSOS;
		public Transform	rootUnitClock;
		public Transform	rootTerrains;

		public Dictionary<int, UnitCtl>						unitDict			= new Dictionary<int, UnitCtl>();
		public List<UnitCtl> 								players 			= new List<UnitCtl>();
		public List<UnitCtl> 								buildList 			= new List<UnitCtl>();
		public List<UnitCtl> 								soliderList 		= new List<UnitCtl>();
		public Dictionary<int, UnitCtl> 					buildDict 			= new Dictionary<int, UnitCtl>();
		public Dictionary<int, List<UnitCtl>> 				buildLegionDict 		= new Dictionary<int, List<UnitCtl>>();
		/** 每个势力对应的英雄列表 */
		public Dictionary<int, Dictionary<int, UnitCtl>> 	heroLegionDict 		= new Dictionary<int, Dictionary<int, UnitCtl>>();
		/** 每个兵营对应的英雄 */
		public Dictionary<int, UnitCtl> 					heroDictByBuild 	= new Dictionary<int, UnitCtl>();
		/** 势力数量 */
		public int 											legionCount 			= 0;

		public float 					friendHPRate 	= 0.5F;
		public float 					friendHP 	= 0F;
		public float 					totalHP 	= 0f;
		
		public int 						friendBuildCount = 0;
		public int 						totalBuildCount = 0;

		public Dictionary<int, float> 	legionHP 		= new Dictionary<int, float>();
		public float					GetLegionHP(int legionId) {	return legionHP.ContainsKey(legionId) ? legionHP[legionId] : 0f; }
        //获取非己方人口数量最大的势力的人口
        public float GetEnemyLegionHPMax(int mLegionId)
        {
            float hp = 0;
            foreach (var item in legionHP)
            {
                if (War.GetLegionData(mLegionId).GetRelation(item.Key) == RelationType.Enemy)
                {
                    if(hp < item.Value)
                    {
                        hp = item.Value;
                    }
                }
            }

            return hp;
        }

		public int GetBuildCount(int legionId, int relation, bool hasNeutral)
		{
			int count = 0;
			for(int i = 0; i < buildList.Count; i ++)
			{
				if (hasNeutral == false && buildList [i].unitData.legionData.type == LegionType.Neutral)
					continue;
				
				switch (buildList [i].unitData.GetRelation (legionId)) 
				{
				case RelationType.Own:
					if(relation.ROwn()) count++;
					break;
				case RelationType.Friendly:
					if(relation.RFriendly()) count++;
					break;
				case RelationType.Enemy:
					if(relation.REnemy()) count++;
					break;
				}
			}

			return count;
		}

		protected override void OnAwake ()
		{
			base.OnAwake ();
			Init();
			// 初始化更新器
			InitUpdateHandle();

			// 监听--建筑归属改变
			SignalFactory.GetInstance<WarBuildChangeLegion>().AddListener(OnBuildChangeLegion);
		}

		public void Init()
		{
			War.scene = this;
			
			// 单位父亲root
			if(rootWalls == null) rootWalls = transform.FindChild("Walls");
			if(rootShadow == null) rootShadow = transform.FindChild("Shadows");
			if(rootPlayers == null) rootPlayers = transform.FindChild("Players");
			if(rootCaserns == null) rootCaserns = transform.FindChild("Caserns");
			if(rootSoliders == null) rootSoliders = transform.FindChild("Soliders");
			if(rootHeros == null) rootHeros = transform.FindChild("Heros");
			if(rootTerrains == null) rootTerrains = GameObject.Find("Terrains").transform;

			GenerationLegionPositionDict();
		}


		protected override void OnDestroy ()
		{
            Debug.LogFormat("<color=wihte> war scene destorey</color>");
            //Coo.plotTalkManager.cleanTipsInfo();
			base.OnDestroy ();
			StopAllCoroutines();
			CearPathCache();
			SignalFactory.GetInstance<WarBuildChangeLegion>().RemoveListener(OnBuildChangeLegion);
			if(War.scene == this) War.scene = null;
		}


		/** 更新器--建筑归属 */
		private UpdateBuildLegion 		updateBuildLegion = new UpdateBuildLegion();
		/** 更新器--势力兵力 */
		private UpdateHP 				updateHP = new UpdateHP();

		/** 初始化更新器 */
		void InitUpdateHandle()
		{
			updateBuildLegion.scene 	= this;
			updateHP.scene 				= this;
		}
		private float _beginTime = 0;
		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			if(War.isGameing && War.isEditor == false)
			{

				// 更新器
				updateBuildLegion.OnUpdate();
				updateHP.OnUpdate();

				
				// 游戏时间
				_beginTime += Time.deltaTime;
				if(_beginTime >= War.sceneData.begionDelayTime)
				{
					War.time += Time.deltaTime;
					if(War.timeLimit)
					{
						if(War.time >= War.timeMax )
						{
							War.time = War.timeMax;
							if(War.isGameing)
							{
								updateHP.Execute();
							}
						}
					}
				}
			}
		}

		public void ExeUpdateHandle()
		{
			updateBuildLegion.Execute ();
		}



		/** 兵营改变势力 */
		public void OnBuildChangeLegion(UnitData buildUnitData, int preLegionId, int targetLegionId)
		{
			// 强制更新兵营所属势力
			updateBuildLegion.Execute();

			if(preLegionId == targetLegionId)
			{
				Debug.Log("<color=red>preLegionId == targetLegionId</color>");
			}
			
			// 攻占方势力数据
			LegionData targetLegionData = War.GetLegionData(targetLegionId);
			
			UnitCtl heroUnit = GetHeroByBuild(buildUnitData.unit);
			if(heroUnit != null)
			{
				// 英雄数据
				HeroData heroData = heroUnit.heroData;
				// 英雄行为
				BHero heroBehaviour = heroUnit.GetComponent<BHero>();
				// 
				int legionId = heroUnit.unitData.legionId;

				// ---如果状态是幕前
				if(heroData.state == HeroState.Foregstage)
				{

//					KillHero(heroUnit, targetLegionData);

					if(War.requireSynch)
					{
						

						if(War.IsSendService(targetLegionData.legionId, targetLegionData.type))
						{
							War.service.C_SyncHeroBackstage_0x828(heroUnit.unitData.uid, targetLegionId);
						}
					}
					else
					{
						KillHero(heroUnit, targetLegionData);
					}
				}
			}
			else
			{
//				// 添加经验--占领
//				targetLegionData.levelData.AddExp_Build();
			}

			War.signal.BuildChangeLegionComplete ();
		}

		public void KillHero(UnitCtl heroUnit, LegionData targetLegionData)
		{
			// 英雄数据
			HeroData heroData = heroUnit.heroData;
			// 英雄行为
			BHero heroBehaviour = heroUnit.GetComponent<BHero>();

			// ---如果状态是幕前
			if(heroData.state == HeroState.Foregstage)
			{
				// 添加经验--击杀英雄
				targetLegionData.levelData.AddExp_KillHero(heroUnit);
				// 幕后
				heroBehaviour.Backstage();
				
				War.msgBox.Show_KillHero(targetLegionData, heroData);
				
				
				Coo.soundManager.PlaySound("effect_hero_dead");

				War.signal.DoHeroBackstage (heroUnit.unitData.uid, targetLegionData.legionId);
			}
		}



		/** 单位--添加到场景 */
		public void OnAddUnit(UnitCtl unit)
		{
			if(unit.unitData == null) return;
			switch(unit.unitData.unitType)
			{
			case UnitType.Build:
				if(!buildList.Contains(unit))
				{
					buildDict.Add(unit.unitData.id, unit);
					buildList.Add(unit);
					AddBuild(unit);
				}

				break;
			case UnitType.Solider:
				if(!soliderList.Contains(unit)) soliderList.Add(unit);
				break;
			case UnitType.Player:
				if(!players.Contains(unit)) players.Add(unit);
				break;
			case UnitType.Hero:
				Dictionary<int, UnitCtl> legionHeros;
				if(!heroLegionDict.TryGetValue(unit.unitData.legionId, out legionHeros))
				{
					legionHeros = new Dictionary<int, UnitCtl>();
					heroLegionDict.Add(unit.unitData.legionId, legionHeros);
				}

				if(!legionHeros.ContainsKey(unit.heroData.heroId))
				{
					legionHeros.Add(unit.heroData.heroId, unit);
				}

				if(unit.heroData.buildId >= 0)
				{
					heroDictByBuild.Add(unit.heroData.buildId, unit);
				}
				break;
			}

//			if(unitDict.ContainsKey(unit.unitData.id))
//			{
//				Debug.Log(unit.unitData.id + "  " + unit.gameObject.name + " ," + unitDict[unit.unitData.id].gameObject);
//			}
			unitDict.Add(unit.unitData.id, unit);
		}

		
		/** 单位--从场景移除 */
		public void OnRemoveUnit(UnitCtl unit)
		{
			if(unit.unitData == null) return;
			switch(unit.unitData.unitType)
			{
			case UnitType.Build:
				buildDict.Remove(unit.unitData.id);
				buildList.Remove(unit);
				break;
			case UnitType.Solider:
				soliderList.Remove(unit);
				break;
			case UnitType.Player:
				players.Remove(unit);
				break;
			case UnitType.Hero:
				Dictionary<int, UnitCtl> legionHeros;
				if(heroLegionDict.TryGetValue(unit.unitData.legionId, out legionHeros))
				{
					if(legionHeros.ContainsKey(unit.heroData.heroId))
					{
						legionHeros.Remove(unit.heroData.heroId);
					}
				}

				if(heroDictByBuild.ContainsKey(unit.heroData.buildId)) heroDictByBuild.Remove(unit.heroData.buildId);
				break;
			}

			
			unitDict.Remove(unit.unitData.id);
		}


		/** 获取单位,使用id */
		public UnitCtl GetUnitForUID(int uid)
		{
			UnitCtl unit = null;
			if(unitDict.TryGetValue(uid, out unit))
			{
				return unit;
			}
			return null;
		}



		/** 添加建筑 */
		public void AddBuild(UnitCtl unit)
		{
			int legionId = unit.unitData.legionId;
			
			List<UnitCtl> list;
			if(!buildLegionDict.TryGetValue(legionId, out list))
			{
				list = new List<UnitCtl>();
				buildLegionDict.Add(legionId, list);
				legionCount ++;
			}
			
			list.Add(unit);
		}
		
		/** 获取建筑 */
		public UnitCtl GetBuild(int index)
		{
			UnitCtl unit = null;
			if(buildDict.TryGetValue(index, out unit))
			{
				return unit;
			}
			return unit;
		}

        /*获取所有城池*/
        public List<UnitCtl> GetBuilds()
        {
            return buildList;
        }

		/** 获取势力建筑列表 */
		public List<UnitCtl> GetBuilds(int legionId)
		{
			List<UnitCtl> list;
			if(!buildLegionDict.TryGetValue(legionId, out list))
			{
				list = new List<UnitCtl>();
				buildLegionDict.Add(legionId, list);
			}
			return list;
		}

		
		/** 获取敌对势力建筑列表 */
		public List<UnitCtl> GetEnemyBuilds(int legionId)
		{
			List<UnitCtl> list = new List<UnitCtl>();
			foreach(UnitCtl unit in buildList)
			{
				if(unit.unitData.GetRelation(legionId) == RelationType.Enemy)
				{
					list.Add(unit);
				}
			}
			return list;
		}

		/** 获取英雄，用建筑 */
		public UnitCtl GetHeroByBuild(UnitCtl build)
		{
			UnitCtl unit;
			if(heroDictByBuild.TryGetValue(build.unitData.id, out unit))
			{
				return unit;
			}
			return null;
		}

		
		/** 获取英雄，用建筑ID */
		public UnitCtl GetHeroByBuildId(int buildId)
		{
			UnitCtl unit;
			if(heroDictByBuild.TryGetValue(buildId, out unit))
			{
				return unit;
			}
			return null;
		}
		
		/** 继续 */
		public void Resume()
		{
			foreach(KeyValuePair<int, UnitCtl> kvp in unitDict)
			{
				kvp.Value.Resume();
			}
			
			MaskVisiable = false;
		}
		
		/** 暂停 */
		public void Pause()
		{
			foreach(KeyValuePair<int, UnitCtl> kvp in unitDict)
			{
				kvp.Value.Pause();
			}

			MaskVisiable = true;
		}

		public bool MaskVisiable
		{
			get
			{
				if(maskCollider != null) return maskCollider.activeSelf;
				return false;
			}

			set
			{
				if(maskCollider != null) maskCollider.SetActive(value);
			}
		}

		/** 暂停， 除列表外的 */
		public void Puase(List<UnitCtl> exceptList)
		{
			foreach(KeyValuePair<int, UnitCtl> kvp in unitDict)
			{
				if(exceptList.IndexOf(kvp.Value) == -1)
				{
					kvp.Value.Pause();
				}
			}
		}

    }


}
