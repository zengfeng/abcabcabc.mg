using UnityEngine;
using System.Collections;
using CC.Runtime;
using CC.Runtime.Utils;
using Games.Cores;

namespace Games.Module.Props
{
	public class FormulaProp 
    {
		public int id;
		public int formula;

		public FormulaProp(int id, int formula)
		{
			this.id = id;
			this.formula = formula;
		}

		public Prop GetProp(params object[] args)
		{
			float value = Formula.CallFloal(formula, args);
			return Prop.CreateInstance(id, value);
		}
    }
}