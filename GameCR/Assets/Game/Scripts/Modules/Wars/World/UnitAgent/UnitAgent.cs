using UnityEngine;
using System.Collections;
using Games.Module.Avatars;
using Games.Module.Wars;
using CC.Runtime.Utils;
using System;
using System.Collections.Generic;


namespace Games.Module.Wars
{
	public class UnitAgent : EBehaviour 
	{
		public Transform avatarContainer;
		public Action<UnitAgent> sChangeAvatar;
		public AvatarInfo avatarInfo;
		public Avatara avatar;
		public SpriteRenderer avatarSpriteRender;
		public Transform anchorAngle;

		#region Materials
		private 	WarMaterialsType 		_materialType;
		public 		WarMaterialsType 		materialType;
		public 		Material 				material;
		private 	Material 				defaultMaterial;
		private		List<WarMaterialsType>	materialHistory = new List<WarMaterialsType>();
		private		Dictionary<WarMaterialsType, int> materialStates = new Dictionary<WarMaterialsType, int> ();
		#endregion

		
		public float hitFlyPower = 1000f;
		public float hitFlyPowerUp = 10F;
		public float hitFlyPowerRadius = 6F;

		public SkillOperateSelectUnitView_Build skillOperateSelectUnitView;

		protected override void OnStart ()
		{
			base.OnStart ();
			if(avatarContainer == null) avatarContainer = transform;

			if(unitData != null) SetAvatar(unitData.prefabFile);
			if(avatar == null) avatar = GetComponent<Avatara>();
			if(avatar == null) avatar = GetComponentInChildren<Avatara>();
			if(anchorAngle == null) anchorAngle = transform.FindChild("Anchor-Angle");
			if (avatar != null) avatarSpriteRender = avatar.GetComponent<SpriteRenderer> ();

			unitData.hitFlyPower = hitFlyPower;
			unitData.hitFlyPowerUp = hitFlyPowerUp;
			unitData.hitFlyPowerRadius = hitFlyPowerRadius;
		}

		#region action
		virtual public void Idle()
		{
			action = "idle";
		}

		virtual public void Walk()
		{
			action = "walk";
		}
		
		virtual public void Move()
		{
			action = "run";
		}

		
		virtual public void Attack()
		{
			action = "attack";
		}


		virtual public void Die()
		{
			action = "die";
		}

		/** 动作 */
		protected string _action = "idle";
		public string action
		{
			get
			{
				return _action;
			}

			set
			{
				_action = value;
				if(avatar != null)
				{
					avatar.action = _action;
				}
			}
		}
		
		/** 方向 */
		protected float _angle = 0f;
		public float angel
		{
			get
			{
				return _angle;
			}

			set
			{
				_angle = value;
				if(avatar != null)
				{
					avatar.angle = _angle;
				}
			}
		}
		
		
		/** 播放速度 */
		protected float _speed = 1f;
		public float speed
		{
			get
			{
				return _speed;
			}
			
			set
			{
				_speed = value;
				if(avatar != null)
				{
					avatar.speed = _speed;
				}
			}
		}

		#endregion






		public string prefabFile;
		virtual public void SetAvatar(string prefabFile)
		{
			if(this.prefabFile == prefabFile) return;
			this.prefabFile = prefabFile;


			GameObject prefab = WarRes.GetPrefab(prefabFile);
            if (avatar == null)
            {
                if (prefab == null)
                {
                    Debug.Log(string.Format("<color=red>单位资源没找到 prefabFile={0}</color>", prefabFile));
                }
                GameObject go = GameObject.Instantiate(prefab);
                go.name = "avatar";
                go.transform.SetParent(avatarContainer);
                go.transform.localPosition = unitData.unitType == UnitType.Solider ? new Vector3(0, 0, 0.5f) : Vector3.zero;
                avatar = go.GetComponent<Avatara>();
                avatarInfo = go.GetComponent<AvatarInfo>();
				avatarSpriteRender = go.GetComponent<SpriteRenderer> ();
				defaultMaterial = avatarSpriteRender.material;
            }
            else
            {
//                Debug.Log("prefabFile=" + prefabFile + " , prefab=" + prefab);
                SpriteAvatar spriteAvatar = (SpriteAvatar)avatar;
                SpriteAvatar prefabSpriteAvatar = prefab.GetComponent<SpriteAvatar>();
                if (prefabSpriteAvatar != null)
                {
                    spriteAvatar.avatarData = prefabSpriteAvatar.avatarData;
                    avatar.gameObject.transform.localScale = prefab.transform.localScale;
                }
                else
                {
                    Debug.LogFormat("<color=red>prefabFile={0} 有问题</color>", prefabFile);
                }

				if(avatarInfo != null)
				{
					AvatarInfo spriteAvatarInfo = prefab.GetComponent<AvatarInfo>();
					avatarInfo.CopyInfo(spriteAvatarInfo);
				}
			}

			avatar.angle = angel;
			avatar.action = action;
			avatar.speed = speed;

			if (materialType != WarMaterialsType.stateDefault) 
			{
				_materialType = materialType;
				avatarSpriteRender.material = War.materials.GetMaterial (materialType);
			}

			if(sChangeAvatar != null)
			{
				sChangeAvatar(this);
			}
		}

//		virtual public void SetAvatar(string prefabFile)
//		{
//			if(this.prefabFile == prefabFile) return;
//			this.prefabFile = prefabFile;
//			if(avatar != null)
//			{
//				GameObject.Destroy(avatar.gameObject);
//				avatar = null;
//			}
//			
//			GameObject prefab = WarRes.GetPrefab(prefabFile);
//			if(prefab == null)
//			{
//				Debug.Log(string.Format("<color=red>单位资源没找到 prefabFile={0}</color>" , prefabFile));
//			}
//			GameObject go = GameObject.Instantiate(prefab);
//			go.name = "avatar";
//			go.transform.SetParent(transform);
//			go.transform.localPosition = unitData.unitType == UnitType.Solider ? new Vector3(0, 0, 0.5f) : Vector3.zero;
//			avatar = go.GetComponent<Avatara>();
//			avatar.angle = angel;
//			avatar.action = action;
//			avatar.speed = speed;
//		}

		
		/** 暂停 */
		virtual public void Pause()
		{
			if(avatar != null) avatar.Pause();
			SpriteAvatar[] avatars = GetComponentsInChildren<SpriteAvatar>();
			foreach(SpriteAvatar spriteAvatar in avatars)
			{
				spriteAvatar.Pause();
			}
		}
		
		/** 继续播放 */
		virtual public void Resume()
		{
			if(avatar != null) avatar.Resume();

			SpriteAvatar[] avatars = GetComponentsInChildren<SpriteAvatar>();
			foreach(SpriteAvatar spriteAvatar in avatars)
			{
				spriteAvatar.Resume();
			}
		}


		/** 打飞 */
		public void HitFly()
		{
			if(unitData.unitType == UnitType.Solider)
			{
				SteeringAgentComponent m_steeringAgent = GetComponent<SteeringAgentComponent>();
				m_steeringAgent.StopSteering();

				if(transform.position != unitData.hitFlyPoint)
				{
					Vector3 dir =(unitData.hitFlyPoint - transform.position).normalized;
					unitAgent.angel = HMath.AngleBetweenForward2Vector(dir);
				}
				else
				{
					unitData.hitFlyPoint += (unitData.to.unit.transform.position - transform.position).normalized * 3f ;
				}

				Rigidbody rigidbody = GetComponent<Rigidbody>();
				rigidbody.useGravity = true;
				rigidbody.AddExplosionForce(unitData.hitFlyPower, unitData.hitFlyPoint, unitData.hitFlyPowerRadius, unitData.hitFlyPowerUp);

				unitAgent.action = "die";

				
//				BSolider_Alpha_Hide soliderAlphaHide = GetComponent<BSolider_Alpha_Hide>();
//				soliderAlphaHide.enabled = true;
				
//				Collider collider = GetComponent<Collider>();
//				collider.enabled = true;

			}
		}

		public void OnRest()
		{
			SetDefaultMaterial ();
			
			speed = 1;
			if(unitData != null) SetAvatar(unitData.prefabFile);
		}

		
		public void Synchronous()
		{
			SpriteAvatar spriteAvatar = (SpriteAvatar) avatar;
			if(spriteAvatar != null)
			{
				spriteAvatar.Synchronous();
			}
		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();

			UpdateMaterial ();

			if (_visiableAvatar != visiableAvatar) 
			{
				_visiableAvatar = visiableAvatar;
				avatarSpriteRender.enabled = visiableAvatar;
			}
		}


		#region Materials Metho

		void UpdateMaterial()
		{
			if (_materialType != materialType) 
			{
				_materialType = materialType;
				if (avatarSpriteRender != null)
				{
					if (materialType == WarMaterialsType.stateDefault)
					{
						avatarSpriteRender.material = defaultMaterial;
						material = null;
					} 
					else 
					{
						material = War.materials.GetMaterial (materialType);
						avatarSpriteRender.material = material;
					}
				}
			}
		}

		private void AddMaterialStateCount(WarMaterialsType type)
		{
			if (materialStates.ContainsKey (type))
			{
				materialStates [type] += 1;
			} 
			else
			{
				materialStates.Add (type, 1);
			}
		}


		private void RevokeMaterialStateCount(WarMaterialsType type)
		{
			if (materialStates.ContainsKey (type))
			{
				materialStates [type] -= 1;
				if (materialStates [type] <= 0) 
				{
					materialStates.Remove (type);
				}
			}
		}

		private int GetMaterialStateCount(WarMaterialsType type)
		{
			if (materialStates.ContainsKey (type))
			{
				return materialStates [type];
			}
			return 0;
		}

		public void SetMaterial(WarMaterialsType type)
		{
			if (materialType == type) 
			{
				AddMaterialStateCount (materialType);
				return;
			}
			
			materialHistory.Add (materialType);
			AddMaterialStateCount (materialType);
			materialType = type;
		}

		public void SetDefaultMaterial()
		{
			materialStates.Clear ();
			materialHistory.Clear ();
			materialType = WarMaterialsType.stateDefault;
		}

		private void BackMaterial()
		{
			if (materialHistory.Count > 0)
			{
				WarMaterialsType type = materialHistory[materialHistory.Count - 1];
				materialHistory.RemoveAt (materialHistory.Count - 1);

				materialType = type;
			} 
			else if(materialType != WarMaterialsType.stateDefault)
			{
				SetDefaultMaterial ();
			}
		}

		public void BackMaterial(WarMaterialsType type)
		{
			RevokeMaterialStateCount (type);
			int stateCount = GetMaterialStateCount (type);


			if (stateCount <= 0) 
			{
				if (materialType == type)
				{
					BackMaterial ();
				} 
				else 
				{
					for(int i = 0; i < materialHistory.Count;)
					{
						if (materialHistory [i] == type) 
						{
							materialHistory.RemoveAt (i);
						} 
						else 
						{
							i++;
						}
					}
				}
			}
		
		}
		#endregion

		private bool _visiableAvatar = true;
		public bool visiableAvatar = true;

	}
}