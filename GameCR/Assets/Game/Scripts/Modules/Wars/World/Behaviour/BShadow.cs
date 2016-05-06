using UnityEngine;
using System.Collections;
using Games.Module.Wars;
using CC.Runtime;

namespace Games.Module.Wars
{
	public class BShadow : EBehaviour
	{
		public UnitShadow shadow;
		
		UnitAgent unitAgent ;

		protected override void OnStart ()
		{
			base.OnStart ();
			unitAgent = GetComponent<UnitAgent>();
			if(unitAgent != null)
			{
				unitAgent.sChangeAvatar += OnChangeAvatar;
			}
			
			Init();
		}

		void OnChangeAvatar(UnitAgent unitAgent)
		{
			if(unitAgent != null && unitAgent.avatarInfo != null && shadow != null)
			{
				shadow.transform.localScale = Vector3.one * unitAgent.avatarInfo.shadowScale;
			}
		}
		
		protected void Init()
		{
			
			GameObject prefab = WarRes.GetPrefab(WarRes.Unit_Shadow);
			GameObject go = (GameObject)GameObject.Instantiate(prefab as UnityEngine.Object);
			go.name = "War_Shadow-" + unitData.id;
			go.transform.SetParent(War.scene.rootShadow);
			shadow = go.GetComponent<UnitShadow>();
			shadow.target = transform;
			shadow.SetPosition();

			OnChangeAvatar(unitAgent);
		}

		protected override void OnEnable ()
		{
			base.OnEnable ();
			if(shadow != null) shadow.gameObject.SetActive(true);
		}

		protected override void OnDisable ()
		{
			base.OnDisable ();
			if(shadow != null) shadow.gameObject.SetActive(false);
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();
			
			if(shadow != null) GameObject.Destroy(shadow.gameObject);

			if(unitAgent != null)
			{
				unitAgent.sChangeAvatar -= OnChangeAvatar;
			}
			unitAgent = null;
			shadow = null;
		}



		


	}
}
