using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


namespace CC.Runtime.signals
{
	public class SignalFactory
	{
		private static Dictionary<Type, IHSignal> pools = new Dictionary<Type, IHSignal>();
		public static IHSignal GetInstance(Type type) 
		{
			IHSignal obj = null;
			if(!pools.TryGetValue(type, out obj))
			{
				obj = (IHSignal) Activator.CreateInstance(type);
				pools.Add(type, obj);
			}
			return obj;
		}
		
		public static T GetInstance<T>() where T : IHSignal
		{
			return (T)GetInstance(typeof(T));
		}
	}
}
