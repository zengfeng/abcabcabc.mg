using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Runtime
{
    public interface ISimplePoolItem { 
        object Pool{
            set;
        }

        void Release();
    }

    public class SimplePool<T> where T : ISimplePoolItem 
    {
        public static readonly object sync = new object();

        private static SimplePool<T> instance ;

        public static SimplePool<T> Instance{
            get{
                if( instance == null ){
                    lock(sync){
                        if( instance == null ){
                            instance = new SimplePool<T>();
                        }
                    }
                }
                return instance ;
            }
        }

        public SimplePool()
        {
            pool = new Stack<T>();
        }

        public T Get()
        {
            lock (this)
            {
                if (pool.Count > 0)
                {
                    return pool.Pop();
                }
                else
                {
                    T t = default(T);
                    if (factory == null)
                    {
                        t = Activator.CreateInstance<T>();
                    }
                    else
                    {
                        t = factory();
                    }
                    t.Pool = this;
                    return t;
                }
            }
        }

        public void Put(T item){
            lock (this)
            {
                pool.Push(item);
            }
        }

        public Func<T> Factory
        {
            get
            {
                return factory;
            }
            set
            {
                factory = value;
            }
        }

        private Stack<T> pool;
        private Func<T> factory;
    }
}
