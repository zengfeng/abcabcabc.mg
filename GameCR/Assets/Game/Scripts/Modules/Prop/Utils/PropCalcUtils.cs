using System;
using System.Collections.Generic;

namespace Games.Module.Props
{
    public static class PropCalcUtils
    {
        public static void PropClear(this float[] src) {
            for( int i = 0 ; i < src.Length ; ++ i ){
                src[i] = 0;
            }
        }

		public static float[] Limit(this float[] src)
		{
			
			for(int i = 0; i < src.Length; i ++)
			{
				if(src[i] != 0)
				{
					src[i] = PropConfig.Limit(i, src[i]);
				}
			}
			return src;
		}

		public static float Limit(this float src, int propId)
		{
			return PropConfig.Limit(propId, src);
		}

        public static float[] Organize(this float[] src){
            if( src.Length != PropId.MAX ){
                var res = new float[PropId.MAX];
                for( int i = 0 ; i < res.Length ; ++ i ){
                    res[i] = i < src.Length ? src[i] : 0;
                }
                return res;
            }
            return src;
        }
        
        public static float[] PropAdd(this float[] src, float[] add){
            var res = src.Organize();
            
            for( int i = 0 ; i < res.Length ; ++ i ){
                if( i < add.Length ){
                    res[i] += add[i];
                }
            }
            return res;
        }
        
        public static float[] PropMinus( this float[] src, float[] min){
            var res = src.Organize();
            
            for( int i = 0 ; i < res.Length ; ++ i ){
                if( i < min.Length ){
                    res[i] += min[i];
                }
            }
            return res;
        }
        
        public static float[] PropMulti( this float[] src, float m){
            var res = src.Organize();
            
            for(int i = 0 ; i < res.Length ; ++ i){
                res[i] *= m;
            }
            return src;
        }
        
        public static float[] PropAdd( this float[] src, Prop propValue ){
            var res = src.Organize();
            res[propValue.id] += propValue.value;
            return res;
        }

		
		public static float[] PropAdd( this float[] src, int propId, float propValue ){
			var res = src.Organize();
			res[propId] += propValue;
			return res;
		}
        
		public static float[] PropMinus(this float[] src, int propId, float propValue){
            var res = src.Organize();
			res[propId] -= propValue;
            return res;
        }

		
		public static float[] PropMinus(this float[] src, Prop propValue){
			var res = src.Organize();
			res[propValue.id] -= propValue.value;
			return res;
		}
        
        public static float[] PropAdd( this float[] src, Prop[] propValues, bool final = false ){
            var res = src.Organize();
            foreach( var propValue in propValues ){
				if(!final)
				{
					res[propValue.id] += propValue.value;
				}
				else
				{
					if(propValue.type == PropType.Final)
					{
						res[propValue.id] += propValue.value;
					}
				}
            } 
            return res;
        }
        
        public static float[] PropMinus( this float[] src, Prop[] propValues ){
            var res = src.Organize();
            foreach( var propValue in propValues ){
                res[propValue.id] -= propValue.value;
            }
            return res;
        }
        
        public static Prop PropMulti( this Prop propValue, float m ){
            propValue.value *= m;
            return propValue;
        }
        
        public static Prop[] PropMulti( this Prop[] src, float m){
            for( int i = 0 ; i < src.Length ; ++ i ){
                src[i].value *= m;
            }
            return src;
        }

        public static Prop[] FilterZero(this Prop[] src) {
            List<Prop> list = new List<Prop>();

            foreach (Prop prop in src)
            {
                if (prop.value != 0)
                    list.Add(prop);
            }

            return list.ToArray();
        }

		
		public static Prop[] FilterZero(this float[] src) {
			List<Prop> list = new List<Prop>();

			for(int i = 0; i < src.Length; i ++)
			{
				if(src[i] != 0)
				{
					Prop prop = Prop.CreateInstance(i, src[i]);
					list.Add(prop);
				}
			}
			
			return list.ToArray();
		}

		public static int[] SortProp(this int[] ids)
		{
			Array.Sort(ids, 
			           delegate(int p1, int p2){
				
				PropConfig c1 = PropConfig.GetInstance(p1);
				PropConfig c2 = PropConfig.GetInstance(p2);
				return c1.priority - c2.priority;
			});
			return ids;
		}
		
		public static Prop[] SortProp(this Prop[] props)
		{
			Array.Sort(props, 
			           delegate(Prop p1, Prop p2){
				return p1.priority - p2.priority;
			});
			return props;
		}

		
		
		public static Prop[] ToProps(this FormulaProp[] formulaProps, params object[] args)
		{
			Prop[] list = new Prop[formulaProps.Length];
			for(int i = 0; i < formulaProps.Length; i ++ )
			{
				list[i] = formulaProps[i].GetProp(args);
			}
			return list;
		}

		public static Prop FindProp(this Prop[] props, int id)
		{
			foreach (var prop in props)
			{
				if (prop.id == id)
				{
					return prop;
				}
			}
			return null;
		}
    }
}

