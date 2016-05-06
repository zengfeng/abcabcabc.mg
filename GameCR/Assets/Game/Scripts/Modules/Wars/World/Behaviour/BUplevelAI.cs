using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class BUplevelAI : EBehaviour
	{
		
		public int legionId;
		public AIConfig aiConfig;
		public float intervalMin; 
		public float intervalMax; 
		public  float _updateTime;

		
		public List<UnitCtl> ownBuilds;

		protected override void OnStart ()
		{
			base.OnStart ();
			
			if(legionData.aiConfig == null || legionData.aiConfig.uplevelLevel == AIUplevelLevel.Level_0_Lazy)
			{
				enabled = false;
				return;
			}
			legionId = legionData.legionId;
			aiConfig = legionData.aiConfig;
			intervalMax = aiConfig.uplevelInterval;
			intervalMin = Mathf.Max(intervalMax - aiConfig.uplevelIntervalRandom, 0f);

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
			
			if(!legionData.aiUplevel) return;
			if(Time.time > _updateTime)
			{
				_updateTime = Time.time + Random.Range(intervalMin, intervalMax);
				if (!War.sceneData.enableAIUplevel) return;
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

			UnitCtl select = null;

			foreach(UnitCtl unit in ownBuilds)
			{
				if(unit.unitData.legionId == legionId)
				{
					if(unit.levelData.EnableUpLevel)
					{
						if(aiConfig.uplevelLevel == AIUplevelLevel.Level_1_Enable)
						{
							select = unit;
							break;
						}
						else
						{
							if(unit.unitData.behit) continue;
							if(unit.unitData.attackUnitNum > 0) continue;

							select = unit;
							break;
						}
					}
				}
			}


			if(select != null)
			{
				select.levelData.Uplevel();
			}
		}



	}
}