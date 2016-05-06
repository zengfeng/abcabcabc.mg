using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

public class EnumUtil
{

	public static void GetValuesAndNames<T>(out int[] ids, out string[] names)
	{
		T[] typeList =(T[]) Enum.GetValues(typeof(T));
		names = new string[typeList.Length];
		ids = new int[typeList.Length];
		
		for(int i = 0; i < typeList.Length; i ++)
		{

			ids[i] = Convert.ToInt32(typeList[i]);
		}

		Type t = typeof(T);
		FieldInfo[] fis = t.GetFields();
		for(int i = 0; i < fis.Length; i ++)
		{
			if(i < 1) continue;
			
			FieldInfo f = fis[i];
			if(f.GetCustomAttributes(true).Length > 0)
			{
				HelpAttribute help =(HelpAttribute) f.GetCustomAttributes(true)[0];
				names[i - 1] = help.description;
			}
			else
			{
				names[i - 1] = f.Name;
			}
		}
	}


	public static string GetName<T>(T val)
	{
		Type t = typeof(T);
		
		string name = Enum.GetName(t, val);
		FieldInfo fieldInfo = t.GetField(name);
		if(fieldInfo.GetCustomAttributes(true).Length > 0)
		{
			HelpAttribute help =(HelpAttribute) fieldInfo.GetCustomAttributes(true)[0];
			name = help.description;
		}

		return name;
	}

}
