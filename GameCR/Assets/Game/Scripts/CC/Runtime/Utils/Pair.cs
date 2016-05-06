using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Runtime.Utils
{
	[Serializable]
    public class Pair<T1,T2>
    {
		public Pair(){

		}
        public Pair( T1 t1, T2 t2 ) {
            first = t1;
            second = t2;
        }
        public T1 first;
        public T2 second;
    }

    public class Triple<T1,T2,T3>
    {
        public Triple(T1 t1, T2 t2, T3 t3)
        {
            first = t1;
            second = t2;
            third = t3;
        }
        public T1 first;
        public T2 second;
        public T3 third;
    }
}
