using UnityEngine;
using System.Collections;
using Games.Module.Wars;
using CC.Runtime;
using Games.Module.Avatars;

namespace Games.Module.Wars
{
	public class BWalkDust : EBehaviour
	{
		public Avatara avatar;
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
			if(unitAgent != null && unitAgent.avatarInfo != null && avatar != null)
			{
				avatar.transform.localScale = Vector3.one * unitAgent.avatarInfo.dustScale;
			}
		}
		
		protected void Init()
		{
			GameObject prefab = WarRes.GetPrefab(WarRes.effect_solider_walk);
			GameObject go = (GameObject)GameObject.Instantiate(prefab as UnityEngine.Object);
			go.name = "avatar_dust";
			Transform parent = transform.FindChild("Anchor-Angle");
			if(parent == null) parent = transform;
			RenderLayer renderLayer = go.AddComponent<RenderLayer>();
			renderLayer.sortingLayer = RenderLayer.Layer.War_Dust;
			go.transform.SetParent(parent);
			go.transform.localPosition = new Vector3(0f, -0.5f, -0.5f);
			avatar = go.GetComponent<Avatara>();
			avatar.gameObject.SetActive(_isWalk);

			
			OnChangeAvatar(unitAgent);
		}


		
		private string _action;
		private float _speed = 0f;
		public bool _isWalk = true;
		protected override void OnUpdate ()
		{
			base.OnUpdate ();

			if(_action != unitAgent.action || _speed != unitAgent.speed)
			{
				_action = unitAgent.action;
				_speed = unitAgent.speed;

				
				bool isWalk =  _action == "walk" && _speed != 0;
				if(_isWalk != isWalk)
				{
					_isWalk = isWalk;
					if(avatar != null)
					{
						avatar.gameObject.SetActive(_isWalk);
					}
				}
			}
		}



		


	}
}
