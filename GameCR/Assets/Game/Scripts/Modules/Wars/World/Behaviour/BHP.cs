using UnityEngine;
using System.Collections;
using Games.Module.Wars;
using CC.Runtime;

namespace Games.Module.Wars
{
	public class BHP : EBehaviour
	{
		public UnitHP hpView;

		protected override void OnStart ()
		{
			base.OnStart ();

			Coo.assetManager.Load(WarRes.WarViews_UnitHP, OnLoadRes);
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();
			if(hpView != null)
			{
				GameObject.Destroy(hpView.gameObject);
				
				if(unitCtl != null) unitCtl.OnDamage -= hpView.OnDamage;
			}

		}

		
		protected void OnLoadRes(string name, System.Object obj)
		{
			GameObject go = (GameObject)GameObject.Instantiate(obj as UnityEngine.Object);
			go.name = "WarViews_UnitHP-" + unitData.id;
			go.transform.SetParent(War.scene.rootUnitHP);
			go.transform.localScale = Vector3.one;
			hpView = go.GetComponent<UnitHP>();
			if(unitData.unitType == UnitType.Build)
			{
				hpView.colorId = legionData.colorId;
				hpView.SetBarVisiable(unitData.build_produce);
			}

			UIFllowWorldPosition uiFllow = go.GetComponent<UIFllowWorldPosition>();
			uiFllow.targetWorld = transform;

			unitCtl.OnDamage += hpView.OnDamage;


			
//			GameObject go = (GameObject)GameObject.Instantiate(obj as UnityEngine.Object);
//			go.name = go.name.Replace("(Clone)", "");
//			go.transform.SetParent(unit.GetAnchor(UnitAnchor.UICanva));
//			go.transform.localPosition = new Vector3(2f, -2f, 0f);
//			go.transform.rotation = Quaternion.Euler(new Vector3(45F, 0F, 0F));
//			go.transform.localScale = Vector3.one;
//			hpView = go.GetComponent<UnitHP>();
		}

		
		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			
			if(hpView != null)
			{
				hpView.SetVal(unitData.hp, unitData.maxHp);
				hpView.SetVisible(unitData.death ? false : unitData.showHPView);
				hpView.colorId = legionData.colorId;
			}


		}


	}
}
