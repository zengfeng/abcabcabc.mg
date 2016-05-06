using UnityEngine;
using System.Collections;
using Games.Module.Props;
using System.Collections.Generic;

namespace Games.Module.Wars
{
	public class LevelData : EData
	{
		public float[] levelMaxHps = new float[]{20, 20, 30, 40, 50};
		public int[] uplevelNeedHps = new int[]{0, 5, 10, 15, 20};
		public float[] uplevelNeedTimes = new float[]{0, 3, 5, 7, 10};
		public float uplevelTime = 0;
		public int maxLevel
		{
			get
			{
				int val = unitData.buildConfig.maxLevel - 1;
				val += unitData.build_addMaxLevel;
				if(val < 1) val = 1;
				if(val > unitData.buildConfig.maxLevel) val = unitData.buildConfig.maxLevel;
				return val;
			}
		}

		public int GetMaxLevel(int addMaxLevel)
		{
			int val = maxLevel;
			val += addMaxLevel;
			if(val < 1) val = 1;
			if(val > unitData.buildConfig.maxLevel) val = unitData.buildConfig.maxLevel;
			return val;
		}

        public void CheckLevel()
        {
            if(Level > maxLevel)
            {
                unitData.level = maxLevel;
            }
        }



		public int Level
		{
			get
			{
				return unitData.level;
			}
		}

		public float HP
		{
			get
			{
				return unitData.hp;
			}
		}


		public float UplevelRequireHp
		{
			get
			{
				if(Level < 2)
				{
					return unitData.buildLevelConfig.uplevelRequireHP;
				}
				else
				{
					if(HP <= War.config.buildUplevel_RequireMinHp)
					{
						return War.config.buildUplevel_RequireMinHp;
					}
					else if(HP >= War.config.buildUplevel_RequireMaxHp)
					{
						return War.config.buildUplevel_RequireMaxHp;
					}
					else
					{
						return Mathf.FloorToInt(HP);
					}
				}
//				return legionData.GetBuildUplevelNeedHP(Level);
//				return uplevelNeedHps[Level];
			}
		}
		
		public float UplevelRequireTime
		{
			get
			{
				//Debug.Log (" War.sceneData.weight.uplevelTime=" +  War.sceneData.weight.uplevelTime);
				if(Level < 2)
				{
					return unitData.buildLevelConfig.uplevelRequireTime * War.sceneData.weight.uplevelTime;
				}
				else
				{
					float time = War.config.buildUplevel_RequireMaxTime;
					float sub = UplevelRequireHp - War.config.buildUplevel_RequireMinHp;
					time -= sub * War.config.buildUplevel_Hp2Time;
					time *= War.sceneData.weight.uplevelTime;
					if(time <= 0) time = 0.1f;

					return time;

				}
//				return uplevelNeedTimes[Level];
			}
		}

		public bool Upleveing
		{
			get
			{
				return uplevelTime > 0;
			}
		}

		public bool EnableUpLevel
		{
			get
			{
				if(!War.config.CasernEnableUplevel)
				{
					return false;
				}

				if(!War.sceneData.enableUplevel)
				{
					return false;
				}

				if(War.isRecord)
				{
					return false;
				}

				if (unitData.relation == RelationType.Own) 
				{
					if (!Games.Guides.Guide.warConfig.GetEnableUplevel (unitData.uid)) 
					{
						return false;
					}
				}

				
				if(unitData.changeBuilding) return false;
				if(Upleveing) return false;
				if(unitData.death) return false;
				if(unitData.freezedProduce) return false;

				if(Level < maxLevel)
				{
					return HP >= UplevelRequireHp;
				}
				return false;
			}
		}

		
		
		public bool GetSkillEnableUpLevel(int addMaxLevel)
		{
			if(!War.config.CasernEnableUplevel)
			{
				return false;
			}
			
			
			if(unitData.changeBuilding) return false;
			if(Upleveing) return false;
			if(unitData.death) return false;
			if(unitData.freezedProduce) return false;
			
			return Level < GetMaxLevel(addMaxLevel);
		}

		public void Uplevel()
		{
			if(EnableUpLevel)
			{
				War.signal.HandUplevel (unitData.uid);
				if(War.requireSynch)
				{
					War.pvp.C_Uplevel(unitData.uid);
				}
				else
				{
					ExeUplevel();
				}
			}
		}

		public void ExeUplevel()
		{
			if(Level < maxLevel)
			{
				//Debug.LogFormat ("<color=#FF8877>ExeUplevel UplevelRequireHp={0}, UplevelRequireTime={1}, toLevel={2}</color>", UplevelRequireHp, UplevelRequireTime, unitData.level + 1);
				unitData.AddHP((float)-UplevelRequireHp);
				if (unitData.hp < 0) unitData.hp = 0;
				uplevelTime = UplevelRequireTime;

				War.signal.DoUplevel (unitData.uid, unitData.level + 1, uplevelTime);
			}
		}

		public void SkillUplevelHandler()
		{
			if(unitData.level < unitData.buildConfig.maxLevel)
			{
				uplevelTime = UplevelRequireTime;
			}
		}

		public void AddLevel()
		{
			if(unitData.level < unitData.buildConfig.maxLevel)
			{
				unitData.Uplevel(unitData.level + 1);
			}
		}



	}
}