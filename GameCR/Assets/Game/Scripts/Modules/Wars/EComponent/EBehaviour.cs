using UnityEngine;
using System.Collections;
using CC.Runtime;
using System;

namespace Games.Module.Wars
{
	public class EBehaviour : EntityMBBehaviour, IEComponent 
	{
		
		/*---------------------IEComponent-------------------------*/
		public GameObject go{	get{return gameObject;} 	set{}	}
		public void AddData(EData data)
		{
			data.go = go;
			AddEC(data);
		}

		public void AddEC(IEComponent component)
		{
			this.AddEComponent(component);
		}

		public void RemoveEC(IEComponent component)
		{
			this.RemoveEComponent(component);
		}

		public T GetEC<T>() where T : IEComponent
		{
			return this.GetEComponent<T>();
		}

		protected override void OnAwake ()
		{
			base.OnAwake ();
			AddEC(this);
			event3D = GetComponent<Event3D>();
		}

		
		protected override void OnDestroy ()
		{
			base.OnDestroy ();
			RemoveEC(this);

			unitData = null;
			levelData = null;
			_heroData = null;
			produceData = null;
			sendArmData = null;
			unitCtl = null;
		}

		public override void OnRelease ()
		{
			base.OnRelease ();



			unitData = null;
			levelData = null;
			_heroData = null;
			produceData = null;
			sendArmData = null;
		}



		
		protected Type _ecType;
		virtual public Type GetECType()
		{
			if(_ecType == null)
			{
				_ecType = this.GetType();
			}
			
			return _ecType;
		}




		/*---------------------variables-------------------------*/

		private UnitData 	_unitData;
		private LevelData 	_levelData;
		private HeroData 	_heroData;
		private ProduceData _produceData;
		private SendArmData _sendArmData;
		private UnitCtl 	_unitCtl;
		private UnitAgent 	_unitAgent;
		private UnitAnchor 	_unitAnchor;
		[HideInInspector]
		public Event3D event3D;



		
		public UnitData unitData
		{
			get
			{
				if(_unitData == null)
				{
					_unitData = GetEC<UnitData>();
				}
				return _unitData;
			}
			
			set
			{
				_unitData = value;
			}
		}
		
		public LegionData legionData
		{
			get
			{
				return War.GetLegionData(unitData.legionId);
			}
		}
		
		
		public HeroData heroData
		{
			get
			{
				if(_heroData == null)
				{
					_heroData = GetEC<HeroData>();
				}
				return _heroData;
			}
			
			set
			{
				_heroData = value;
			}
		}
		
		public LevelData levelData
		{
			get
			{
				if(_levelData == null)
				{
					_levelData = GetEC<LevelData>();
				}
				return _levelData;
			}
			
			set
			{
				_levelData = value;
			}
		}
		
		
		
		public ProduceData produceData
		{
			get
			{
				if(_produceData == null)
				{
					_produceData = GetEC<ProduceData>();
				}
				return _produceData;
			}
			
			set
			{
				_produceData = value;
			}
		}
		
		
		
		public SendArmData sendArmData
		{
			get
			{
				if(_sendArmData == null)
				{
					_sendArmData = GetEC<SendArmData>();
				}
				return _sendArmData;
			}
			
			set
			{
				_sendArmData = value;
			}
		}
		

		
		
		
		public UnitCtl unitCtl
		{
			get
			{
				if(_unitCtl == null)
				{
					_unitCtl = GetEC<UnitCtl>();
				}
				return _unitCtl;
			}
			
			set
			{
				_unitCtl = value;
			}
		}

		
		
		public UnitAgent unitAgent
		{
			get
			{
				if(_unitAgent == null)
				{
					_unitAgent = GetEC<UnitAgent>();
				}
				return _unitAgent;
			}
			
			set
			{
				_unitAgent = value;
			}
		}

		public UnitAnchor unitAnchor
		{
			get
			{
				if(_unitAnchor == null)
				{
					_unitAnchor = GetEC<UnitAnchor>();
				}
				return _unitAnchor;
			}
			
			set
			{
				_unitAnchor = value;
			}
		}






















	}
}
