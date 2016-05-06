using UnityEngine;
using System.Collections;

namespace CC.Module.DebugLog
{
    public class GMInfoVO
    {
        public string name;
        public string enPart;
        public string numPart;

		public override string ToString ()
		{
			return string.Format ("[GMInfoVO] name={0}, enPart={1}, numPart={2}", name, enPart, numPart);
		}
    }
}

