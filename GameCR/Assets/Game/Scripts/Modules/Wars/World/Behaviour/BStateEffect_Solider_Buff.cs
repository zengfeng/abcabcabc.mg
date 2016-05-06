using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games.Module.Avatars;
using Games.Module.Props;
using CC.Runtime.Utils;

namespace Games.Module.Wars
{

	public class BStateEffect_Solider_Buff : EBehaviour
	{
		public enum Buff
		{
			None,
			Attack_Up,
			MoveSpeed_Up
		}


		public Transform angleAnchor;
		public Buff buff = Buff.None;
		private Buff _buff = Buff.None;
		public SpriteAvatar effect;

		public int stateAtkUp;
		public int stateMoveSpeedUp;
		
		private int _stateAtkUp;
		private int _stateMoveSpeedUp;

		public BShadow shadow;
		private bool _isHitFly;

		protected override void OnStart ()
		{
			base.OnStart ();
			shadow = GetComponent<BShadow>();
			angleAnchor = transform.FindChild(UnitAnchorName.Angle);
		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			if(unitData == null) return;


			if(stateAtkUp != unitData.Props[PropId.StateAtkUp])
			{
				stateAtkUp = (int) unitData.Props[PropId.StateAtkUp];
			
			}

			if(stateMoveSpeedUp != unitData.Props[PropId.StateMoveSpeedUp])
			{
				stateMoveSpeedUp = (int) unitData.Props[PropId.StateMoveSpeedUp];
			}

			
			if(stateAtkUp > 0)
			{
				buff = Buff.Attack_Up;
			}
			else if(stateMoveSpeedUp > 0)
			{
				buff = Buff.MoveSpeed_Up;
			}
			else
			{
				buff = Buff.None;
			}


			if(_isHitFly != unitData.isHitFly)
			{
				_isHitFly = unitData.isHitFly;
				buff = Buff.None;
			}


			if(_buff != buff)
			{
				_stateAtkUp = stateAtkUp;
				_stateMoveSpeedUp = stateMoveSpeedUp;

				OnChangeBuff();
			}

			if(_stateAtkUp != stateAtkUp)
			{
				_stateAtkUp = stateAtkUp;
				UpdateAtkUp();
			}
			
			if(_stateMoveSpeedUp != stateMoveSpeedUp)
			{
				_stateMoveSpeedUp = stateMoveSpeedUp;
				UpdateMoveSpeedUp();
			}
		}


		void OnChangeBuff()
		{
			RemoveBuff(_buff);
			_buff = buff;
			AddBuff(_buff);
		}
		
		private AbstateStateBuffLevel stateBuffLevel_atk;
		private AbstateStateBuffLevel stateBuffLevel_moveSpeed;

		void RemoveBuff(Buff buff)
		{
			switch(buff)
			{
			case Buff.None:
				shadow.enabled = false;
				break;

			case Buff.Attack_Up:
				if(stateBuffLevel_atk != null) stateBuffLevel_atk.Release();
				stateBuffLevel_atk = null;
				break;

			case Buff.MoveSpeed_Up:
				if(stateBuffLevel_moveSpeed != null) stateBuffLevel_moveSpeed.Release();
				stateBuffLevel_moveSpeed = null;
				break;
			}
		}

		void AddBuff(Buff buff)
		{
			GameObject go;
			switch(buff)
			{
			case Buff.None:
				shadow.enabled = true;
				break;
				
			case Buff.Attack_Up:
				go = War.pool.stateBuffAtkUp.Get();
				stateBuffLevel_atk = go.GetComponent<AbstateStateBuffLevel>();
				stateBuffLevel_atk.SetLevel(stateAtkUp, legionData.colorId);
				go.transform.SetParent(angleAnchor, false);
				go.transform.localPosition = Vector3.zero;
				go.transform.localEulerAngles = Vector3.zero;
				go.SetActive(true);
				break;	

			case Buff.MoveSpeed_Up:
				go = War.pool.stateBuffMoveSpeedUp.Get();
				stateBuffLevel_moveSpeed = go.GetComponent<AbstateStateBuffLevel>();
				stateBuffLevel_moveSpeed.SetLevel(stateMoveSpeedUp, legionData.colorId);
				go.transform.SetParent(angleAnchor, false);
				go.transform.localPosition = Vector3.zero;
				go.transform.localEulerAngles = Vector3.zero;
				go.SetActive(true);
				break;
			}
		}

		void UpdateAtkUp()
		{
			if(stateBuffLevel_atk != null) stateBuffLevel_atk.SetLevel(stateAtkUp, legionData.colorId);
		}
		
		void UpdateMoveSpeedUp()
		{
			if(stateBuffLevel_moveSpeed != null) stateBuffLevel_moveSpeed.SetLevel(stateMoveSpeedUp, legionData.colorId);
		}


		public override void OnRelease ()
		{
			base.OnRelease ();

			stateAtkUp 			= 0;
			stateMoveSpeedUp 	= 0;

			
			_stateAtkUp 			= 0;
			_stateMoveSpeedUp 	= 0;

			_isHitFly = false;


			buff = Buff.None;
			_buff = Buff.None;

			if(effect != null)
			{
				effect.gameObject.SetActive(false);
			}

			
			shadow.enabled = true;

			
			if(stateBuffLevel_atk != null) stateBuffLevel_atk.Release();
			stateBuffLevel_atk = null;

			
			if(stateBuffLevel_moveSpeed != null) stateBuffLevel_moveSpeed.Release();
			stateBuffLevel_moveSpeed = null;
		}



	}

}