using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime.signals;
using Games.Module.Wars;
using Games.Module.Props;


namespace Games.Module.Wars
{
	public class UpdateHP : UpdateHandle
	{
		private float _updateTime = 0F;
		public void OnUpdate ()
		{
			if(Time.time >= _updateTime)
			{
				_updateTime = Time.time + 1F * Random.Range(0.8F, 1.2F);
				Execute();
			}
		}
		
		public void Execute()
		{
//			Debug.Log("UpdateHP War.processState = "+ War.processState);
			if(War.processState != WarProcessState.Gameing) return;

			friendHP = 0f;
			totalHP = 0f;


			friendBuildCount = 0;
			totalBuildCount = 0;
			legionHP.Clear();
			//			Debug.Log(("<color=green>------------------</color>"));

			foreach(KeyValuePair<int, LegionData> kvp in War.sceneData.legionDict)
			{
				if(kvp.Value.type != LegionType.Neutral)
				{
					legionHP.Add(kvp.Value.legionId, 0);
				}
			}

			foreach(UnitCtl unit in buildList)
			{
				
				//				Debug.Log(string.Format("<color=green>buildList unit.teamData.team={0},   unit.teamData.type={1},   totalHP={2}</color>", unit.teamData.team, unit.teamData.type, totalHP));
				if(unit.legionData.type == LegionType.Neutral)
					continue;

				AddBuild(unit);
			}
			
			foreach(UnitCtl unit in soliderList)
			{
				
				//				Debug.Log(string.Format("<color=green>soliderList unit.teamData.team={0},   unit.teamData.type={1},   totalHP={2}</color>", unit.teamData.team, unit.teamData.type, totalHP));
				if(unit.legionData.type == LegionType.Neutral)
					continue;
				
				AddHP(unit);
			}

			if(totalHP > 0)
			{
				friendHPRate = friendHP / totalHP;
			}
			else
			{
				friendHPRate = 0.5f;
			}



//			if(totalHP > 0)
//			{
//				
//				//				Debug.Log("<color=green>totalHP="+totalHP+"</color>");
//				if(legionHP.ContainsKey(War.ownLegionData.legionId))
//				{
//					myHPRate =legionHP[War.ownLegionData.legionId] / totalHP;
//				}
//				else
//				{
//					myHPRate = 0F;
//					
//					//					Debug.Log("<color=green>myHPRate = 0F;</color>");
//				}
//			}
//			else
//			{
//				if(legionHP.ContainsKey(War.ownLegionData.legionId))
//				{
//					myHPRate =0F;
//					//					Debug.Log("<color=green>----myHPRate = 0F;</color>");
//				}
//			}
			
			//			Debug.Log("<color=green>myHPRate="+myHPRate+"</color>");




			if(friendBuildCount <= 0)
			{
				War.Over(OverType.Lose);
			}
			else if(friendBuildCount >= totalBuildCount)
			{
				War.Over(OverType.Win);
			}
			else if(War.timeLimit && War.time >= War.timeMax)
			{
				if(friendBuildCount == totalBuildCount * 0.5f)
				{
					War.Over(OverType.Draw, true);
				}
				else if(friendBuildCount <= totalBuildCount * 0.5f)
				{
					War.Over(OverType.Lose, true);
				}
				else 
				{
					War.Over(OverType.Win, true);
				}
			}

			return;

			if(friendHPRate <= 0)
			{
				War.Over(OverType.Lose);
			}
			else if(friendHPRate >= 1)
			{
				War.Over(OverType.Win);
			}
			else if(War.timeLimit && War.time >= War.timeMax)
			{
				if(War.vsmode == VSMode.PVE_Expedition)
				{
					War.Over(OverType.Win, true);
				}
				else
				{
					bool isWin = false;
					float buildRate = friendBuildCount * 1f / totalBuildCount;
					if(buildRate == 0.5f)
					{
						isWin = friendHPRate > 0.5f;
					}
					else
					{
						isWin = buildRate > 0.5f;
					}
					Debug.LogFormat("buildRate={0}, friendBuildCount={1}, totalBuildCount={2}, myHPRate={3}, isWin={4}", buildRate, friendBuildCount, totalBuildCount, friendHPRate, isWin);

					War.Over(isWin ? OverType.Win : OverType.Lose, true);
				}
			}
			else
			{
				if(War.vsmode == VSMode.PVE_Expedition)
				{
					if(War.GetLegionData(1).expeditionTotalHP < 1 && War.GetLegionData(2).expeditionTotalHP < 1)
					{
						War.Over(OverType.Win);
					}
				}
			}
			
		}
		
		void AddHP(UnitCtl unit)
		{
			totalHP += unit.unitData.hp;
			if(legionHP.ContainsKey(unit.unitData.legionId))
			{
				legionHP[unit.unitData.legionId] += unit.unitData.hp;
			}
			else
			{
				legionHP.Add(unit.unitData.legionId, unit.unitData.hp);
			}
			

			
			if(unit.unitData.relation != RelationType.Enemy)
			{
				friendHP += unit.unitData.hp;
			}

			//			Debug.Log(string.Format("<color=green>AddHP teamHP[{0}]={1}  unit.unitData.hp={2}</color>", unit.unitData.team, teamHP[unit.unitData.team],   unit.unitData.hp));
		}
		
		void AddBuild(UnitCtl unit)
		{
			float hp = War.vsmode != VSMode.PVE_Expedition || (unit.legionData.expeditionTotalHP > 0 && unit.legionData.expeditionLeftHP > 0)  ? (unit.unitData.hp + 1) : (unit.unitData.hp < 1) ? 0 : unit.unitData.hp ; 
//			float hp = unit.unitData.hp + 1;
			totalHP += hp;
			if(legionHP.ContainsKey(unit.unitData.legionId))
			{
				legionHP[unit.unitData.legionId] += hp;
			}
			else
			{
				legionHP.Add(unit.unitData.legionId, hp);
			}

			if(unit.unitData.relation != RelationType.Enemy)
			{
				friendHP += hp;
				friendBuildCount ++;
			}
			totalBuildCount ++;

			//			Debug.Log(string.Format("<color=green>AddBuild teamHP[{0}]={1}  unit.unitData.hp={2}</color>", unit.unitData.team, teamHP[unit.unitData.team],   unit.unitData.hp));
		}
	}
}
