using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace CC.Runtime
{
	public class InstanceUtil
	{

		private static Dictionary<Type, object> pools = new Dictionary<Type, object>();
		public static object Get(Type type) 
		{
			object obj = null;
			if(!pools.TryGetValue(type, out obj))
			{
				obj =  Activator.CreateInstance(type);
				pools.Add(type, obj);
			}
			return obj;
		}


		
		public static T Get<T>()
		{
			return (T)Get(typeof(T));
		}
	}
}
