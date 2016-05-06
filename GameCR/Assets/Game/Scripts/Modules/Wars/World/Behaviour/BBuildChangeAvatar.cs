using UnityEngine;
using System.Collections;
using CC.Runtime;
using CC.Runtime.Utils;


namespace Games.Module.Wars
{
	public class BBuildChangeAvatar : EBehaviour
	{
		public ClockView clockView;

		// 隐藏时间点
		public float hideAvatarTime = 0.02f;
		// 隐藏后间隔时间，显示
		public float showAvatarTime = 0.7f;
		public float hideEffectTime = 2f;
		public Transform avatarContainer;
		public BuildAgent buildAgent;
		public BBuildShake buildShake;
		private Coroutine _coroutiner;

		public GameObject effect;

		protected override void OnAwake ()
		{
			base.OnAwake ();

			
			buildAgent = GetComponent<BuildAgent>();
			buildShake = GetComponent<BBuildShake>();
			if(avatarContainer == null) avatarContainer = transform.FindChild("AvatarContainer");

		}
		
		protected override void OnStart ()
		{
			base.OnStart ();

			InitClock();
		}

		
		void InitClock()
		{
			GameObject go = GameObject.Instantiate<GameObject>(WarRes.GetPrefab(WarRes.WarViews_UnitClock));
			go.name = "WarViews_Clock-" + unitData.id;
			go.transform.SetParent(War.scene.rootUnitClock);
			go.transform.localScale = Vector3.one;
			clockView = go.GetComponent<ClockView>();
			clockView.Hide();
			go.GetComponent<UIFllowWorldPosition>().targetWorld = transform;
		}


		
		public void Play(float clockTime, float hideAvatarTime, float showAvatarTime, float hideEffectTime, GameObject effect)
		{
			if(this.effect != null)
			{
				if(this.effect.activeSelf) this.effect.SetActive(false);
			}

			if(clockTime > 0 && unitData.relation != RelationType.Enemy)
			{
				clockView.Show(clockTime);
			}
			else
			{
				clockView.Hide();
			}

			this.hideAvatarTime = hideAvatarTime;
			this.showAvatarTime = showAvatarTime;
			this.hideEffectTime = hideEffectTime;
			this.effect = effect;

			Play();
		}

		public void Play()
		{
			if(_coroutiner != null)
			{
				StopCoroutine(_coroutiner);
			}
			_coroutiner = StartCoroutine(OnPlay());
		}
		
		IEnumerator OnPlay()
		{
			if(effect != null)
			{
				if(effect.activeSelf) effect.SetActive(false);
				effect.SetActive(true);
			}

			buildShake.Stop();
			buildShake.enabled = false;

			buildAgent.immediatelyChangeLegion = false;
			yield return new WaitForSeconds(hideAvatarTime);
			avatarContainer.gameObject.SetActive(false);
			yield return new WaitForSeconds(showAvatarTime);
			buildAgent.SetAvatar();
			buildAgent.immediatelyChangeLegion = true;

			Vector3 scale0 = new Vector3(1f, 0f, 1f);
			Vector3 scale1 = new Vector3(1f, 1f, 1f);
			Vector3 scale2 = new Vector3(1f, 0.8f, 1f);
			avatarContainer.localScale = scale0;
			avatarContainer.gameObject.SetActive(true);
			
			float time = 0.5f;
			float _time = 0;
			float _t = 0;
			Vector3 _scale;
			while(_time < time)
			{
				_time += Time.deltaTime;
				_t = _time / time;
				
				_scale =  Vector3.Lerp(scale0, scale1, _t);
				avatarContainer.localScale = _scale;
				avatarContainer.transform.localPosition = avatarContainer.transform.localPosition.SetY((_scale.y - 1) * 2);
				
				yield return new WaitForEndOfFrame();
			}
			
			time = 0.12f;
			_time = 0f;
			while(_time < time)
			{
				_time += Time.deltaTime;
				_t = _time / time;
				
				_scale =  Vector3.Lerp(scale1, scale2, _t);
				avatarContainer.localScale = _scale;
				avatarContainer.transform.localPosition = avatarContainer.transform.localPosition.SetY((_scale.y - 1) * 2);
				
				yield return new WaitForEndOfFrame();
			}
			
			
			time = 0.1f;
			_time = 0f;
			while(_time < time)
			{
				_time += Time.deltaTime;
				_t = _time / time;
				
				_scale =  Vector3.Lerp(scale2, scale1, _t);
				avatarContainer.localScale = _scale;
				avatarContainer.transform.localPosition = avatarContainer.transform.localPosition.SetY((_scale.y - 1) * 2);
				
				yield return new WaitForEndOfFrame();
			}
			
			buildShake.enabled = true;
			clockView.Hide();
			yield return new WaitForSeconds(hideEffectTime);

			if(effect != null)
			{
				effect.SetActive(false);

				effect = null;
			}
		}


	}
}
