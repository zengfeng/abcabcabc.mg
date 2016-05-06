using UnityEngine;
using System.Collections;

namespace CC.Runtime
{
	public class Model : IModel 
	{
		virtual public void LoadConfig()
		{

		}

		virtual public void LoadConfig<T1, T2>() where T2 : class, IKey<T1>
		{
			Coo.configManager.GetConfig<T1, T2>();
		}
	}
}
