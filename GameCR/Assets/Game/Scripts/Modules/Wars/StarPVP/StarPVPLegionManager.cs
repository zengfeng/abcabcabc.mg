using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	public class StarPVPLegionManager
	{
		public GameObject gameObject;
		public LegionData legionData;


		/** 处理器配置 */
		private Dictionary<StarType, Type> _processorConfig;
		public Dictionary<StarType, Type> ProcessorConfig
		{
			get
			{
				if(_processorConfig == null)
				{
					_processorConfig = new Dictionary<StarType, Type>();
					_processorConfig.Add(StarType.T9_CasernOccupyPercent, typeof(Star_T9_CasernOccupyPercent_PVP));
					_processorConfig.Add(StarType.T10_CasernOccupyLatest, typeof(Star_T10_CasernOccupyLatest_PVP));
					_processorConfig.Add(StarType.T11_CasernOccupyPercent_GameOver, typeof(Star_T11_CasernOccupyPercent_GameOver_PVP));
					_processorConfig.Add(StarType.T12_GameOver_NoNeutral_OccupyBuild__All, typeof(Star_T12_GameOver_NoNeutral_OccupyBuild__All_PVP));
					_processorConfig.Add(StarType.T13_GameOver_NoNeutral_OccupyBuild__OwnFriend_Greater_Enemy, typeof(Star_T13_GameOver_NoNeutral_OccupyBuild__OwnFriend_Greater_Enemy_PVP));

				}
				return _processorConfig;
			}
		}


		/** 本关卡处理器列表 */
		public List<StarProcessor> list = new List<StarProcessor>();


		/** 生成处理器 */
		public void Generation()
		{
			int[] stars = War.sceneData.stageConfig.stars;
			foreach(int starId in stars)
			{
				if(starId < 1) continue;
				StarConfig starConfig = War.model.GetStarConfig(starId);

				Type type;
				if(ProcessorConfig.TryGetValue(starConfig.starType, out type))
				{
					StarProcessor processor = gameObject.AddComponent(type) as StarProcessor;
					processor.legionData = legionData;
					processor.Init(starConfig);
					list.Add(processor);
				}
			}
		}

		public void OnGameOver()
		{
			foreach(StarProcessor processor in list)
			{
				processor.OnGameOver();
			}
		}

		public int[] GetSuccessStars()
		{
			List<int> stars = new List<int>();
			foreach(StarProcessor processor in list)
			{
				if(processor.state == StarState.Success)
				{
					stars.Add(processor.starConfig.id);

					Debug.Log (processor.starConfig.id + "  " + processor.starConfig);
				}
			}

			return stars.ToArray();
		}

		public void OnRest()
		{
			foreach(StarProcessor processor in list)
			{
				GameObject.Destroy(processor);
			}
			list.Clear();
		}
	}
}