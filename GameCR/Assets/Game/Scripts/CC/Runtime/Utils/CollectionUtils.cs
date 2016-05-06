using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Runtime.Utils
{
    public delegate int Comparison2<T1,T2>(T1 t1, T2 t2); 

    public static class CollectionUtils
    {
        public static int BinaryBound<T1, T2>(this List<T1> list, T2 t, Comparison2<T1, T2> comp) {
            return list.BinaryBound(t, comp, 0, list.Count);
        }

        public static int BinaryBound<T1, T2>(this List<T1> list, T2 t, Comparison2<T1, T2> comp, int begin, int end)
        {
            int count = end - begin;
            int idx;
            int step;
            while (count > 0)
            {
                idx = begin;
                step = count / 2;
                idx += step;
                if (comp(list[idx], t) < 0)
                {
                    begin = ++idx;
                    count -= step + 1;
                }
                else
                {
                    count = step;
                }
            }
            return begin;
        }

        public static int BinaryBound<T>(this List<T> list , T t , Comparison<T> comp ) {
            return list.BinaryBound(t, comp, 0, list.Count);
        }

        public static int BinaryBound<T>(this List<T> list, T t , Comparison<T> comp , int begin, int end) {
            int count = end - begin;
            int idx;
            int step;
            while (count > 0) {
                idx = begin;
                step = count / 2;
                idx += step;
                if (comp(list[idx], t) < 0) {
                    begin = ++idx;
                    count -= step + 1;
                }
                else
                {
                    count = step;
                }
            }
            return begin;
        }

        public static void OrderedInsert<T>(this List<T> list, T t, Comparison<T> comp) {
            int idx = list.BinaryBound(t, comp);
            list.Insert(idx, t);
        }

        public static T OrderedReplace<T>(this List<T> list, T t, Comparison<T> comp) {
            int idx = list.BinaryBound(t, comp);
            if (idx >= list.Count || comp(list[idx], t) != 0) {
                list.Insert(idx, t);
                return default(T);
            }
            else
            {
                T ot = list[idx];
                list[idx] = t;
                return ot;
            }
        }
    }
}
