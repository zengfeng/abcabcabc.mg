using UnityEngine;
using System;
using System.Collections;
using CC.Runtime;
using UnityEngine.UI;
using CC.Runtime.Actions;
using Games.Manager;


namespace Games.Module.Wars
{
	public class BHero : EBehaviour
	{
		public GameObject stateGO;
		public Text stateText;

		public HeroHead heroHead;

		public HeroState state;


		void SetStateText(string text, bool isActive, int team)
		{
			
			stateGO.SetActive(isActive);
			stateText.text = text;
			stateText.color = team == 1 ? Color.red : (team == 2 ? Color.blue : Color.gray);
		}

		void CreateHeroHead()
		{
			GameObject prefab = WarRes.GetPrefab(WarRes.WarViews_HeroHead);
			GameObject go = GameObject.Instantiate(prefab);
			go.name = "WarViews_HeroHead-" + heroData.heroId;
			go.transform.SetParent(War.scene.rootHeroHeads, false);
			go.transform.localScale = Vector3.one;
			
			heroHead = go.GetComponent<HeroHead>();
			heroHead.SetData(heroData);
			heroHead.Hide();
		}


		protected override void OnStart ()
		{
			base.OnStart ();

			stateGO = transform.FindChild("Anchor-UI/War_Scene_Canvas/State").gameObject;
			stateText = transform.FindChild("Anchor-UI/War_Scene_Canvas/State/Text").GetComponent<Text>();

			CreateHeroHead();

			if(heroData.state == HeroState.Backstage)
			{
				Backstage(false);
			}
			else
			{
				Foregstage();
			}
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();

			if(heroHead != null && heroHead.gameObject != null) GameObject.Destroy(heroHead.gameObject);
		}


		public UnitCtl hostBuild
		{
			get
			{
				return War.scene.GetBuild(heroData.buildId);
			}
		}


		protected override void OnUpdate ()
		{
			base.OnUpdate ();

			if(state != heroData.state)
			{
				state = heroData.state;

				switch(state)
				{
				case HeroState.Backstage:
					Backstage(false);
					break;
				case HeroState.Foregstage:
					Foregstage();
					break;
				}
			}
		}
		
	

		/** 幕后 */
		public void Backstage(bool isKill = true)
		{

			SetStateText("幕后", false, unitData.legionId);
			
			state = heroData.state = HeroState.Backstage;
			heroData.death = true;
			if(heroData.buildId >= 0)
			{
//				hostBuild.unitData.RevokeProps(heroData.hero2BuildProps, true);
				if (hostBuild.unitData != null)
				{
					hostBuild.unitData.build_addMaxLevel = 0;
				}

				hostBuild.heroData = null;
				hostBuild.unitData.heroData = null;
			}
			unitData.RevokeAll();

			if(heroData.sBackstage != null) heroData.sBackstage(heroData); 

			if(isKill)
			{
				heroHead.Kill();
			}
			else
			{
				heroHead.Hide();
			}

			if(War.scene.heroDictByBuild.ContainsKey(heroData.buildId))
			{
				War.scene.heroDictByBuild.Remove(heroData.buildId);
			}

			heroData.buildId = -1;
		}

	
		
		/** 幕前 */
		public void Foregstage()
		{
			SetStateText("幕前", false, unitData.legionId);
			
			state = heroData.state = HeroState.Foregstage;

			unitData.RevokeAll();


			if (hostBuild != null) {
				transform.position = hostBuild.transform.position;
				hostBuild.heroData = heroData;
				hostBuild.unitData.heroData = heroData;
			} else {
				if (Application.isEditor)
				{
					Debug.LogErrorFormat ("BHero.Foregstage hostBuild={0}, heroData={1}, heroData.buildId={2}", hostBuild, heroData, heroData.buildId );
				}
			}

			
			// 英雄附加建筑属性
//			hostBuild.unitData.heroPropContainer.UnitApp(unitData);
			// 英雄附加势力属性
//			legionData.heroPropContainer.UnitApp(unitData);
			// 英雄附加英雄配置属性
//			unitData.AppProps(heroData.props, true);

			// 建筑附加英雄属性
//			hostBuild.unitData.AppProps(heroData.hero2BuildProps, true);

			
			if(heroData.sForegstage != null) heroData.sForegstage(heroData); 

			heroHead.Show();

			
			if(War.scene.heroDictByBuild.ContainsKey(heroData.buildId))
			{
				War.scene.heroDictByBuild.Remove(heroData.buildId);
			}

			
			War.scene.heroDictByBuild.Add(heroData.buildId, unitCtl);
		}
	
	}
}
