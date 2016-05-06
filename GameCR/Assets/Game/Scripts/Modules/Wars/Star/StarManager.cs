using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	public class StarManager : MonoBehaviour 
	{
		/** 处理器配置 */
		private Dictionary<StarType, Type> _processorConfig;
		public bool isGameOver;
		private bool isSenOpenEnd;
		public Dictionary<StarType, Type> ProcessorConfig
		{
			get
			{
				if(_processorConfig == null)
				{
					_processorConfig = new Dictionary<StarType, Type>();
					_processorConfig.Add(StarType.T1_FullManual, typeof(Star_T1_FullManual));
					_processorConfig.Add(StarType.T2_InitOwnCasernNoOccupy, typeof(Star_T2_InitOwnCasernNoOccupy));
					_processorConfig.Add(StarType.T3_InitOwnCasernNoOccupy_HasHero, typeof(Star_T3_InitOwnCasernNoOccupy_HasHero));
					_processorConfig.Add(StarType.T4_OnlyDeathSoliderXNum, typeof(Star_T4_OnlyDeathSoliderXNum));
					_processorConfig.Add(StarType.T5_AlsoOwnsCasern, typeof(Star_T5_AlsoOwnsCasern));
					_processorConfig.Add(StarType.T6_LimitTimeOccupyXCansern, typeof(Star_T6_LimitTimeOccupyXCansern));
					_processorConfig.Add(StarType.T7_LimitTimeOccupyXCansern_HasHero, typeof(Star_T7_LimitTimeOccupyXCansern_HasHero));
					_processorConfig.Add(StarType.T8_LimitTimePass, typeof(Star_T8_LimitTimePass));
					_processorConfig.Add(StarType.T9_CasernOccupyPercent, typeof(Star_T9_CasernOccupyPercent));
					_processorConfig.Add(StarType.T10_CasernOccupyLatest, typeof(Star_T10_CasernOccupyLatest));
					_processorConfig.Add(StarType.T11_CasernOccupyPercent_GameOver, typeof(Star_T11_CasernOccupyPercent_GameOver));
					_processorConfig.Add(StarType.T12_GameOver_NoNeutral_OccupyBuild__All, typeof(Star_T12_GameOver_NoNeutral_OccupyBuild__All));
					_processorConfig.Add(StarType.T13_GameOver_NoNeutral_OccupyBuild__OwnFriend_Greater_Enemy, typeof(Star_T13_GameOver_NoNeutral_OccupyBuild__OwnFriend_Greater_Enemy));

				}
				return _processorConfig;
			}
		}


		/** 本关卡处理器列表 */
		public List<StarProcessor> list = new List<StarProcessor>();
		public StarBox getPanel;
		
		protected void Awake ()
		{
			War.starManager = this;
			if(getPanel == null) getPanel = GameObject.Find("StarBox").GetComponent<StarBox>();
		}

		protected void Update()
		{
			if(!isSenOpenEnd && isGameOver)
			{
//				if(getPanel.isFinal)
//				{
					isSenOpenEnd = true;
					War.OnOverEnd();
//				}
			}
		}


		/** 生成处理器 */
		public void Generation()
		{

			int[] stars = War.sceneData.stageConfig.stars;
//			Debug.Log(string.Format("<color=yello>Generation stars={0}</color>", stars.ToStr ()));
			int count = 0;
			foreach(int starId in stars)
			{
				if(starId < 1) continue;
				count ++;
				StarConfig starConfig = War.model.GetStarConfig(starId);

				Type type;
				if(ProcessorConfig.TryGetValue(starConfig.starType, out type))
				{
					StarProcessor processor = gameObject.AddComponent(type) as StarProcessor;
					processor.Init(starConfig);
					list.Add(processor);
				}
			}

			if(count == 0)
			{
				getPanel.gameObject.SetActive(false);
			}

		}

		public void OnGameOver()
		{
			foreach(StarProcessor processor in list)
			{
				processor.OnGameOver();
			}
			isGameOver = true;
		}

		public int[] GetSuccessStars()
		{
			List<int> stars = new List<int>();
			foreach(StarProcessor processor in list)
			{
				if(processor.state == StarState.Success)
				{
					stars.Add(processor.starConfig.id);
				}
			}

			return stars.ToArray();
		}

		public void OnRest()
		{
			foreach(StarProcessor processor in list)
			{
				Destroy(processor);
			}
			list.Clear();
		}
	}
}