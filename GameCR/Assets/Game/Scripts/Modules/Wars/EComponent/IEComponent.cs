using UnityEngine;
using System.Collections;
using System;

namespace Games.Module.Wars
{
	public interface IEComponent 
	{
		GameObject go{get;set;}
		void AddEC(IEComponent component);
		void RemoveEC(IEComponent component);
		T GetEC<T>() where T : IEComponent;

		Type GetECType();
	}
}
