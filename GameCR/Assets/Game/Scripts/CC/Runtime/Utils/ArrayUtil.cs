
using System;
using System.Collections.Generic;
namespace CC.Runtime.Utils
{
	public class ArrayUtil
	{
		public ArrayUtil ()
		{
		}


		public static void Add<T>(ref T[] list, T obj)
		{
			T[] tempList = list;
			int len = tempList.Length;
			list = new T[len + 1];
			tempList.CopyTo (list, 0);
			list[len] = obj;
		}

		
		public static Tv[] ToArrayForKey<Tk, Tv>(Dictionary<Tk, Tv> dict)
		{
			Tv[] list = new Tv[dict.Count];
			int i = 0;
			foreach( KeyValuePair<Tk, Tv> kvp in dict )
			{
				list[i++] = kvp.Value;
			}
			return list;
		}
		
		public static List<Tv> ToArrayForKeyList<Tk, Tv>(Dictionary<Tk, Tv> dict)
		{
			List<Tv> list = new List<Tv>();
			int i = 0;
			foreach( KeyValuePair<Tk, Tv> kvp in dict )
			{
				list.Add(kvp.Value);
			}
			return list;
		}

	}
}
