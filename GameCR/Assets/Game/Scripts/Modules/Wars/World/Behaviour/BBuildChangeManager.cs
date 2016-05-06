using UnityEngine;
using System.Collections;
using CC.Runtime;
using CC.Runtime.Utils;


namespace Games.Module.Wars
{
	public class BBuildChangeManager : EBehaviour
	{

		// 隐藏时间点
		public float hideAvatarTime = 0.02f;
		// 隐藏后间隔时间，显示
		public float showAvatarTime = 0.7f;

		public float changeTime = 15;
		
		public Transform anchorEffectUplevel;
		public GameObject effect;
		public BBuildChangeAvatar buildChangeAvatar;


		protected override void OnAwake ()
		{
			base.OnAwake ();
			anchorEffectUplevel = transform.FindChild(UnitAnchorName.EffectUplevel);
			buildChangeAvatar = GetComponent<BBuildChangeAvatar>();

		}
		
		protected override void OnStart ()
		{
			base.OnStart ();

			changeTime = War.config.skillChangeBuildTime;

			CreateEffect();
		}
		
		protected void CreateEffect()
		{
			GameObject prefab = WarRes.GetPrefab(WarRes.Effect_Uplevel);
			GameObject go = (GameObject)GameObject.Instantiate(prefab);
			go.SetActive(false);
			go.transform.SetParent(anchorEffectUplevel);
			go.transform.localPosition = Vector3.zero;
			go.transform.localScale = Vector3.one;
			effect = go;
		}

		public BBuildChangeCallHandler changeConfigCallHandler;
		public BBuildChangeCallHandler attachModuleCallHandler;
		public BBuildChangeCallHandler uplevelCallHandler;


		//-------------------
		public void StopAll()
		{
			StopBuildChangeConfig();
			StopBuildAttachModule();
			StopBuildUplevel();
			unitData.changeBuilding = false;
		}

		public void StopBuildChangeConfig()
		{
			if(changeConfigCallHandler != null)
			{
				changeConfigCallHandler.StopCall();
				changeConfigCallHandler = null;
			}
		}

		
		
		public void StopBuildAttachModule()
		{
			if(attachModuleCallHandler != null)
			{
				attachModuleCallHandler.StopCall();
				attachModuleCallHandler = null;
			}
		}

		
		
		public void StopBuildUplevel()
		{
			if(uplevelCallHandler != null)
			{
				uplevelCallHandler.StopCall();
				uplevelCallHandler = null;
			}
		}

		
		/** 改造 */
		public void BuildChangeConfig(int buildId)
		{
			StopBuildChangeConfig();

			changeConfigCallHandler = gameObject.AddComponent<BBuildChangeCallHandler>();
			changeConfigCallHandler.Play(changeTime, effect, OnBuildChangeConfig, buildId);
			SetBuildChangeTime(changeTime);
		}

		void OnBuildChangeConfig(object buildId)
		{
			unitData.BuildChangeBuildConfig((int) buildId);
			changeConfigCallHandler = null;
		}
		
		/** 附加建筑功能 */
		public void BuildAttachModule(AbstractBuildConfig config)
		{
			StopBuildAttachModule();
			
			attachModuleCallHandler = gameObject.AddComponent<BBuildChangeCallHandler>();
			attachModuleCallHandler.Play(changeTime, effect, OnBuildAttachModule, config);
			SetBuildChangeTime(changeTime);
		}

		
		void OnBuildAttachModule(object config)
		{
			unitData.BuildAttachModule((AbstractBuildConfig)config);
			attachModuleCallHandler = null;
		}

		/** uplevel */
		public void BuildUplevel()
		{
			StopBuildUplevel();

			//Debug.LogFormat ("<color=#FF8877>BBuildChangeManager BuildUplevel levelData.uplevelTime={0}</color>", levelData.uplevelTime);

			uplevelCallHandler = gameObject.AddComponent<BBuildChangeCallHandler>();
			uplevelCallHandler.Play(levelData.uplevelTime, effect, OnBuildUplevel, null);
			SetBuildChangeTime(levelData.uplevelTime);
		}

		void OnBuildUplevel(object arg)
		{
			levelData.AddLevel();
		}

		
		
		/** 设置建筑改变时间 */
		public void SetBuildChangeTime(float time)
		{
			if(unitData.changeBuildTime < time)
			{
				unitData.changeBuildTime = time;
			}
		}

		
		protected override void OnUpdate ()
		{
			UpdateUplevel();
			UpdateChangeBuildTime();
		}

		void UpdateChangeBuildTime ()
		{
			if(unitData.changeBuildTime > 0)
			{
				unitData.changeBuildTime -= Time.deltaTime;
			}
		}

		private bool _upleveling = false;
		void UpdateUplevel ()
		{
			if(levelData.Upleveing)
			{
				levelData.uplevelTime -= Time.deltaTime;
				
				
				if(levelData.uplevelTime < 0)
				{
					levelData.uplevelTime = 0;
				}
			}

			
			if(_upleveling != levelData.Upleveing)
			{
				_upleveling = levelData.Upleveing;
				
				if(_upleveling)
				{
					BuildUplevel();
				}
			}
		}


	}
}
