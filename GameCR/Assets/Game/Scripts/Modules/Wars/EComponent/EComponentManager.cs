using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Games.Module.Wars
{
	public static class EComponentManager 
	{
		
		public static Dictionary<GameObject, Dictionary<Type, IEComponent>> goecs = new Dictionary<GameObject, Dictionary<Type, IEComponent>>();
		
		public static void AddEComponent(this GameObject src, IEComponent ec)
		{
			ec.go = src;
			Dictionary<Type, IEComponent> ecs;
			if(!goecs.TryGetValue(ec.go, out ecs))
			{
				ecs = new Dictionary<Type, IEComponent>();
				goecs.Add(ec.go, ecs);
			}
			
			Type type = ec.GetECType();
			if(ecs.ContainsKey(type))
			{
				ecs[type] = ec;
			}
			else
			{
				ecs.Add(type, ec);
			}
		}

		public static void AddEComponent(this IEComponent src, IEComponent ec)
		{
			Dictionary<Type, IEComponent> ecs;
			if(!goecs.TryGetValue(ec.go, out ecs))
			{
				ecs = new Dictionary<Type, IEComponent>();
				goecs.Add(ec.go, ecs);
			}
			
			Type type = ec.GetECType();
			if(ecs.ContainsKey(type))
			{
				ecs[type] = ec;
			}
			else
			{
				ecs.Add(type, ec);
			}
		}

		public static T GetEComponent<T>(this IEComponent src) where T : IEComponent
		{
			Dictionary<Type, IEComponent> ecs;
			
			IEComponent result = null;
			if(src.go != null)
			{
				if(goecs.TryGetValue(src.go, out ecs))
				{
					Type type = typeof(T);
					if(ecs.TryGetValue(type, out result))
					{
						return (T)result;
					}
				}
			}
			return (T)result;
		}

		public static void RemoveEComponent(this IEComponent src, IEComponent ec)
		{
			Dictionary<Type, IEComponent> ecs;
			
			if(goecs.TryGetValue(ec.go, out ecs))
			{
				Type type = ec.GetECType();
				if(ecs.ContainsKey(type))
				{
					ecs.Remove(type);
				}
				
				if(ecs.Count == 0)
				{
					goecs.Remove(ec.go);
				}
			}
		}

		public static void RemoveGameObject(GameObject go)
		{
			if(goecs.ContainsKey(go))
			{
				goecs.Remove(go);
			}
		}


	}
}
