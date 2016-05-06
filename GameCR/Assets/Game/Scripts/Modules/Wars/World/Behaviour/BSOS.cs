using UnityEngine;
using System.Collections;
using Games.Module.Wars;
using CC.Runtime;

namespace Games.Module.Wars
{
	public class BSOS : EBehaviour
	{
		public UnitSOS view;

		protected override void OnStart ()
		{
			base.OnStart ();
			if (War.sceneData.stageConfig.sos == false)
			{
				this.enabled = false;
				return;
			}

			Coo.assetManager.Load(WarRes.WarViews_UnitSOS, OnLoadRes);
		}


		protected override void OnDestroy ()
		{
			base.OnDestroy ();

			if(view != null)
			{
				GameObject.Destroy(view.gameObject);
			}
		}
		
		protected void OnLoadRes(string name, System.Object obj)
		{
			GameObject go = (GameObject)GameObject.Instantiate(obj as UnityEngine.Object);
			go.name = "WarViews_UnitSOS-" + unitData.id;
			go.transform.SetParent(War.scene.rootUnitSOS);
			go.transform.localScale = Vector3.one * 2;
			view = go.GetComponent<UnitSOS>();
			go.GetComponent<UIFllowWorldPosition>().targetWorld = transform;
		}

		
		protected override void OnUpdate ()
		{
			base.OnUpdate ();

			if(unitData.sos)
			{
				unitData.sosTime -= Time.deltaTime;
			}
			


			if(unitData.relation == RelationType.Own)
			{
				foreach(UnitData item in  unitData.fromList)
				{
					RelationType relation = unitData.GetRelation(item.legionId);
					if(relation == RelationType.Enemy)
					{
						if(item.unitNum > 0)
						{
//							Debug.Log("item.hp=" + item.hp + " item.unitNum=" + item.unitNum);
							unitData.sos = true;
						}
					}
				}
			}
			
			if(view != null)
			{
				view.SetVisible(unitData.sos);
			}


		}


	}
}
