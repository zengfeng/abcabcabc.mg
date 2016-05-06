using UnityEngine;
using System.Collections;
using Games.Module.Wars;
using CC.Runtime;

namespace Games.Module.Wars
{
	public class BAtkRadius : EBehaviour
	{
		public AtkRadius view;

		
		protected void CreateView()
		{
			GameObject prefab = WarRes.GetPrefab(WarRes.Unit_AtkRadius);
			GameObject go = (GameObject)GameObject.Instantiate(prefab);
			go.name = go.name.Replace("(Clone)", "-") + unitData.id;
			go.transform.SetParent(transform);
			go.transform.localPosition = Vector3.zero;
			view = go.GetComponent<AtkRadius>();
		}

		public int level = 1;
		public int colorId = -1;
		public float radius;
		public bool build_turret;

		protected override void OnUpdate ()
		{
			base.OnUpdate ();

			build_turret = unitData.build_turret;

			if(unitData.build_turret)
			{
				if(view == null)
				{
					CreateView();
				}

				if(!view.gameObject.activeSelf)
				{
					view.gameObject.SetActive(true);
				}

				if(level != unitData.level)
				{
					level = unitData.level;
					view.SetLevel(level);

				}


				if(colorId != unitData.colorId || radius != unitData.attackRadius)
				{
					colorId = unitData.colorId;
					radius = unitData.attackRadius;

					view.ChangeLegion(WarColor.GetTurretColor(colorId), radius);
				}



			}
			else
			{
				if(view != null && view.gameObject.activeSelf)
				{
					view.gameObject.SetActive(false);
				}
			}

		}


	}
}
