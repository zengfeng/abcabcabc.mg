using UnityEngine;
using System.Collections;
using Games.Module.Avatars;
using Games.Module.Wars;


namespace Games.Module.Wars
{
	public class BuildAgent : UnitAgent 
	{
		public void EditorStart()
		{
			OnStart();
		}


		override public System.Type GetECType()
		{
			if(_ecType == null)
			{
				_ecType = typeof(UnitAgent);
			}
			
			return _ecType;
		}
		
		public bool immediatelyChangeLegion = true;

		protected override void OnStart ()
		{
			Idle();
			base.OnStart ();
			if(unitData != null)
			{
				_legion = unitData.legionId;
				_prefabFile = unitData.prefabFile;
			}

			InitBuildGround();
		}

		public void InitBuildGround()
		{
//			return;

			Transform ground = transform.FindChild("ground");
			if(ground != null)
			{
				ground.gameObject.SetActive(false);
			}

			return;
			if(ground != null && string.IsNullOrEmpty(War.sceneData.mapConfig.buildGround) == false)
			{
				SpriteRenderer spriteRenderer = ground.GetComponent<SpriteRenderer>();
				if(spriteRenderer != null)
				{
//					spriteRenderer.gameObject.SetActive(false);
					spriteRenderer.sprite = WarRes.GetRes<Texture2D>(War.sceneData.mapConfig.buildGround).ToSprite();

				}
			}
		}

		#region action
		override public void Idle()
		{
			action = "idel_level1";
		}

		#endregion

		private string _prefabFile;
		private int _legion = -1;
		private Coroutine _coroutiner;
		protected override void OnUpdate ()
		{
			base.OnUpdate ();

			if(_prefabFile != unitData.prefabFile)
			{
				if(immediatelyChangeLegion)
				{
//					if(string.IsNullOrEmpty(_prefabFile)) immediatelyChangeLegion = false;
					SetAvatar();
				}
//				else
//				{
//					if(_coroutiner == null)
//					{
//						_coroutiner = StartCoroutine(DelaySetAvatar(0.3f));
//					}
//				}
				_prefabFile = unitData.prefabFile;
			}
		}

		IEnumerator DelaySetAvatar(float time)
		{
			immediatelyChangeLegion = false;
			yield return new WaitForSeconds(time);
			SetAvatar();
			immediatelyChangeLegion = true;
			_coroutiner = null;
		}

		
		public void SetAvatar ()
		{
			SetAvatar(unitData.prefabFile);
		}

		public override void SetAvatar (string prefabFile)
		{
			_prefabFile = prefabFile;
			base.SetAvatar (prefabFile);
		}





	}
}