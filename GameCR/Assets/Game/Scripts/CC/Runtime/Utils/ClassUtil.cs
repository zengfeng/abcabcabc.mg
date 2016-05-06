using System.Collections;
using System;
using System.Reflection;
namespace CC.Runtime.Utils
{
    public class ClassUtil
    {
        public static object ExecuteMethod(Type type ,string MethodName,object obj1,params object[] parameters)
        {
            Type[] parametersLength;
            if (parameters != null)
            {
                parametersLength = new Type[parameters.Length];
                int i=0;
                foreach (object obj in parameters)
                {
                    parametersLength.SetValue(obj.GetType(),i);
                    i++;
                }
            }else
            {
                parametersLength = new Type[0];
            }
            MethodInfo methodinfo = type.GetMethod(MethodName,
                                                   BindingFlags.Public | BindingFlags.Instance,
                                                   null,
                                                   CallingConventions.Any,
                                                   parametersLength,
                                                   null);
            return methodinfo.Invoke(obj1,parameters);
        }
    }

}
   
