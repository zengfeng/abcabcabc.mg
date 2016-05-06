using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CC.Runtime.Utils
{
    public static class ReflectUtil
    {
        public static Attribute GetCustomAttribute(this MemberInfo type, Type attr) {
            Attribute[] attrs = type.GetCustomAttributes(attr,false) as Attribute[];
            if (attrs != null && attrs.Length > 0)
            {
                return attrs[0];
            }
            return null;
        }

        public static T GetCustomAttribute<T>(this MemberInfo type) where T : Attribute
        {
            T[] res = type.GetCustomAttributes(typeof(T), false) as T[];
            if( res != null && res.Length > 0 )
            {
                return res[0];
            }
            return null;
        }
    }
}
