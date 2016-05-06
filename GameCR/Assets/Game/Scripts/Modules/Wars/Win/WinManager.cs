using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{
	public class WinManager : MonoBehaviour 
	{
		public GameObject[] views;
		/** 处理器配置 */
		private Dictionary<WinType, Type> _processorConfig;
		public Dictionary<WinType, Type> ProcessorConfig
		{
			get
			{
				if(_processorConfig == null)
				{
					_processorConfig = new Dictionary<WinType, Type>();
					_processorConfig.Add(WinType.T1_Occupy, typeof(Win_T1_Occupy));
					_processorConfig.Add(WinType.T2_Defend, typeof(Win_T2_Defend));
					_processorConfig.Add(WinType.T3_Attack, typeof(Win_T3_Attack));

				}
				return _processorConfig;
			}
		}


		/** 本关卡处理器列表 */
		public WinProcessor winProcessor;
		
		protected void Awake ()
		{
			War.winManager = this;
			foreach(GameObject go in views)
			{
				if(go != null) go.SetActive(false);
			}
		}

		protected void Update()
		{

		}


		/** 生成处理器 */
		public void Generation()
		{
			int winId = War.sceneData.stageConfig.winId;
			if(winId <=0 ) return;

			WinConfig winConfig = War.sceneData.stageConfig.winConfig;
			Debug.Log(string.Format("<color=yello>Generation winId={0} winConfig={1}</color>", winId, winConfig));
			Type type;
			if(ProcessorConfig.TryGetValue(winConfig.winType, out type))
			{
				winProcessor = gameObject.AddComponent(type) as WinProcessor;
				int index = ((int)winConfig.winType)-1;
				GameObject viewGO = null;
				if(index < views.Length)
				{
					viewGO = views[index];
				}

				winProcessor.Init(winConfig, viewGO);
				if(viewGO != null) viewGO.SetActive(true);

			}
		}

		public void OnGameOver()
		{
			if(winProcessor != null) winProcessor.OnGameOver();
		}
		
		public OverType GetGameOverType()
		{
//			if (winProcessor != null) return winProcessor.GetGameOverType();
			return War.overType;
		}


		public void SetWarOverData(WarOverData overData)
		{
			if (winProcessor != null) winProcessor.SetWarOverData(overData);
		}

		public void OnRest()
		{
			if(winProcessor != null)
			{
				Destroy(winProcessor);
				winProcessor = null;
			}
		}



	}
}