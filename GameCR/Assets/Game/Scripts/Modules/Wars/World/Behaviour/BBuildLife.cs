using UnityEngine;
using System.Collections;
using CC.Runtime;
using CC.Runtime.Utils;


namespace Games.Module.Wars
{
	public class BBuildLife : EBehaviour
	{
		
		// 隐藏时间点
		public float hideAvatarTime = 0.02f;
		// 隐藏后间隔时间，显示
		public float showAvatarTime = 0.7f;

		public GameObject effect;
		public BBuildChangeAvatar buildChangeAvatar;
		public BBuildChangeManager buildChangeManager;
		protected override void OnStart ()
		{
			base.OnStart ();

            Coo.assetManager.Load(WarRes.build_legion_chenge, OnLoadRes);
			_team = unitData.legionId;

			buildChangeAvatar = GetComponent<BBuildChangeAvatar>();
			buildChangeManager = GetComponent<BBuildChangeManager>();
		}
		
		protected void OnLoadRes(string name, System.Object obj)
		{
			GameObject go = (GameObject)GameObject.Instantiate(obj as UnityEngine.Object);
			go.name = name;
			go.SetActive(false);
			go.transform.SetParent(unitAnchor.GetAnchor(UnitAnchorName.EffectDeath));
			go.transform.localPosition = Vector3.zero;
			go.transform.localScale = Vector3.one;
			effect = go;
		}
		
		private bool _death = false;
		private int _team = -1;
		private int _preteam = -1;

		public float changeInactiveTime = 1f;
		private float _changeInactiveTime = 0;
		private int _changeInactiveTeam = 0;
		private int _changeInactivePreTeam = 0;
		private bool _hasHero;
		protected override void OnUpdate ()
		{
			base.OnUpdate ();



			if(_team != unitData.legionId)
			{
				_preteam = _team;
				_team = unitData.legionId;
				if(_preteam == -1) _preteam = _team;
				unitData.death = true;

				if(_changeInactiveTime <= 0)
				{
					_changeInactivePreTeam = _preteam;
					_changeInactiveTeam = _team;
					if(!_hasHero)
					{
						// 添加经验--占领
						War.GetLegionData(_team).levelData.AddExp_Build(unitCtl);
					}
				}

				_changeInactiveTime = changeInactiveTime;

                Coo.soundManager.PlaySound("effect_get_build");
			}

			if(_changeInactiveTime > 0)
			{
				_changeInactiveTime -= Time.deltaTime;
				if(_changeInactiveTime <= 0 && _changeInactiveTeam != _team)
				{
					// 添加经验--占领
					War.GetLegionData(_team).levelData.AddExp_Build(unitCtl);
				}
			}

			_hasHero = unitData.hasHero;
			
			if(_death != unitData.death)
			{
				_death = unitData.death;

				if(_death)
				{
					buildChangeManager.StopAll();
					buildChangeAvatar.Play(0, hideAvatarTime, showAvatarTime, 0.02f, effect);
				}
			}

			if(_death)
			{
				unitData.deathTime -= Time.deltaTime;

				if(unitData.deathTime <= 0)
				{
//					if(unitData.level > 1) unitData.level -= 1;
				}
			}
		}


	}
}
