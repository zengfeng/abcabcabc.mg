using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using CC.Runtime.Utils;
using CC.Runtime.PB;

namespace Games.Module.Wars
{
	public class StarPVPManager : MonoBehaviour 
	{


		/** 本关卡处理器列表 */
		public Dictionary<int, StarPVPLegionManager> legionDict = new Dictionary<int, StarPVPLegionManager>();
		
		protected void Awake ()
		{
			War.starPVPManager = this;
		}



		/** 生成处理器 */
		public void Generation()
		{

			foreach(var kvp in War.sceneData.legionDict)
			{
				if(kvp.Value.type == LegionType.Neutral) continue;
				StarPVPLegionManager legionManager = new StarPVPLegionManager();
				legionManager.gameObject = gameObject;
				legionManager.legionData = kvp.Value;
				legionManager.Generation();

				legionDict.Add(kvp.Value.legionId, legionManager);
			}
		}

		public void OnGameOver()
		{
			foreach(var kvp in legionDict)
			{
				kvp.Value.OnGameOver();
			}
		}

		public int[] GetSuccessStars(int legionId)
		{
			if(legionDict.ContainsKey(legionId))
			{
				legionDict[legionId].GetSuccessStars();
			}

			return new int[]{};
		}

		public void OnRest()
		{
			foreach(var kvp in legionDict)
			{
				kvp.Value.OnRest();
			}
			legionDict.Clear();
		}

		public List<ProtoRoleFightResult> GetServiceEndData()
		{
			List<ProtoRoleFightResult> list = new List<ProtoRoleFightResult>();

			int buildTotal = War.scene.GetBuilds().Count;
			foreach(var kvp in legionDict)
			{
				LegionData legionData = kvp.Value.legionData;
				int legionId = legionData.legionId;
				ProtoRoleFightResult result = new ProtoRoleFightResult();
				result.roleId = legionData.roleId;
				result.star =  War.overType == OverType.Draw ? 1 :  kvp.Value.GetSuccessStars().Length;
				result.build_count = War.scene.GetBuilds(legionId).Count;
				result.build_total = buildTotal;
				result.team_id = legionId;



				Debug.LogFormat("GetServiceEndData legionId={0}, result.roleId={1}, type={2}, star={3}, build_count={4}", legionId, result.roleId, legionData.type, result.star, result.build_count);
				if(War.GetRelationType(kvp.Value.legionData.legionId) != RelationType.Enemy)
				{
					result.end_type = (int) War.overType;
				}
				else
				{
					OverType overType = OverType.Draw;
					switch(War.overType)
					{
					case OverType.Draw:
						overType = OverType.Draw;
						break;
					case OverType.Lose:
						overType = OverType.Win;
						break;
					case OverType.Win:
						overType = OverType.Lose;
						break;
					}

					
					result.end_type = (int) overType;
				}

				list.Add(result);

				//TODO Test
				//result.star = 3;


			}

			return list;
		}

		public List<WarOverLegionData> GetOverData()
		{
			List<WarOverLegionData> list = new List<WarOverLegionData>();
			
			int buildTotal = War.scene.GetBuilds().Count;
			foreach(var kvp in legionDict)
			{
				LegionData legionData = kvp.Value.legionData;
				int legionId = legionData.legionId;
				WarOverLegionData result = new WarOverLegionData();
				result.legionId = legionData.legionId;
				result.roleId = legionData.roleId;
				result.starCount = kvp.Value.GetSuccessStars().Length;
				result.buildCount = War.scene.GetBuilds(legionId).Count;
				result.buildTotal = buildTotal;
				Debug.LogFormat("GetOverData legionId={0}, result.roleId={1}, type={2}, starCount={3},  buildCount={4}", legionId, result.roleId, legionData.type, result.starCount, result.buildCount);

				
				if(War.GetRelationType(kvp.Value.legionData.legionId) != RelationType.Enemy)
				{
					result.overType = War.overType;
				}
				else
				{
					OverType overType = OverType.Draw;
					switch(War.overType)
					{
					case OverType.Draw:
						overType = OverType.Draw;
						break;
					case OverType.Lose:
						overType = OverType.Win;
						break;
					case OverType.Win:
						overType = OverType.Lose;
						break;
					}
					
					
					result.overType = overType;
				}
				
				list.Add(result);
				
				
				//TODO Test
				//result.starCount = 3;
			}
			
			return list;
		}
	
	}
}