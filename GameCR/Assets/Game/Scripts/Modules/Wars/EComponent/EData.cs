using UnityEngine;
using System.Collections;
using CC.Runtime;
using System;

namespace Games.Module.Wars
{
	public class EData : IEComponent 
	{
		/*---------------------IEComponent-------------------------*/
		public GameObject go{get;set;}
		
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
		
		virtual protected void OnStart ()
		{

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




		private UnitData _unitData;
		private HeroData _heroData;
		private LevelData _levelData;
		private ProduceData _produceData;
		private SendArmData _sendArmData;
		private UnitCtl _unit;
		
		
		
		
		public UnitData unitData
		{
			get
			{
				if(_unitData == null)
				{
					_unitData = GetEC<UnitData>();
					if(_unitData == null && this is UnitData)
					{
						_unitData = this as UnitData;
					}
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
		

		
		
		
		public UnitCtl unit
		{
			get
			{
				if(_unit == null)
				{
					_unit = GetEC<UnitCtl>();
				}
				return _unit;
			}
			
			set
			{
				_unit = value;
			}
		}


		
		public virtual void OnRelease()
		{
			unit = null;
		}







	}
}
