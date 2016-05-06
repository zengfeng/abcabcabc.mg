using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CC.Runtime.Entitys
{
	public class EntityManager 
	{

		private static EntityManager _Instance;
		public static EntityManager Instance
		{
			get
			{
				if(_Instance == null) _Instance = new EntityManager();
				return _Instance;
			}
		}

		private EntityManager()
		{
		}

		private Dictionary<int, BaseGameEntity> _EntityMap = new Dictionary<int, BaseGameEntity>();

		public void RegisterEntity(BaseGameEntity entity)
		{
			if(entity == null) return;
			if(!_EntityMap.ContainsKey(entity.ID))
			{
				_EntityMap.Add(entity.ID, entity);
			}
		}
		
		public void RemoveEntity(BaseGameEntity entity)
		{
			if(entity == null) return;
			if(!_EntityMap.ContainsKey(entity.ID))
			{
				_EntityMap.Remove(entity.ID);
			}
		}

		public BaseGameEntity GetEntityFromID(int id)
		{
			BaseGameEntity entity;
			_EntityMap.TryGetValue(id, out entity);
			return entity;
		}
	}
}