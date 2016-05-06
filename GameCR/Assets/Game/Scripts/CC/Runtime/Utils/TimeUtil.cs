using UnityEngine;
using System.Collections;
using System;

namespace CC.Runtime.Utils
{
	public class TimeUtil 
	{
		class TimeObject
		{
			public int d;
			public int h;
			public int m;
			public int s;

			public TimeObject()
			{
			}
		}

		/** 转换成d:h:m:s */
		static TimeObject ToDHMS(int time)
		{
			TimeObject obj = new TimeObject();
			int d = Mathf.FloorToInt(time / 86400);
			int h = Mathf.FloorToInt((time - d * 86400) / 3600);
			int m = Mathf.FloorToInt((time - d * 86400 - h * 3600) / 60);
			int s = time - d * 86400 - h * 3600 - m * 60;

			
			obj.d = d;
			obj.h  = h;
			obj.m  = m;
			obj.s  = s;
			return obj;
		}

		
		/** 转换成h:m:s */
		static  TimeObject ToHMS(int time)
		{
			
			TimeObject obj = new TimeObject();
			int h = Mathf.FloorToInt(time / 3600);
			int m =Mathf.FloorToInt((time - h * 3600) / 60);
			int s = time - h * 3600 - m * 60;
			
			obj.h = h;
			obj.m = m;
			obj.s = s;
			return obj;
		}
		
		
		/** 转换成m:s */
		static TimeObject ToMS(int time)
		{
			TimeObject obj = new TimeObject();
			int m = Mathf.FloorToInt(time / 60);
			int s = time - m * 60;
			
			obj.m = m;
			obj.s = s;
			return obj;
		}
		
		/** 转换成 D天H时M分SS秒 */
		public static string ToDHMSS(int time)
		{
			TimeObject obj = ToDHMS(time);
			return obj.d + "天" + obj.m + "分" + StringUtils.FillStr(obj.s, 2) + "秒";
		}
		/** 转换成 DD天HH时MM分SS秒 */
		public static string ToDDHHMMSS(int time)
		{
			TimeObject obj = ToDHMS(time);
			return StringUtils.FillStr(obj.d, 2) + "天" +StringUtils.FillStr(obj.h, 2) + "时" +  StringUtils.FillStr(obj.m, 2) + "分" + StringUtils.FillStr(obj.s, 2) + "秒";
		}

		
		/** 转换成hh:mm:ss */
		public static string ToHHMMSS(int time)
		{
			TimeObject obj = ToHMS(time);
			return StringUtils.FillStr(obj.h, 2) + ":" + StringUtils.FillStr(obj.m, 2) + ":" + StringUtils.FillStr(obj.s, 2);
		}
		
		public static string ToHHMM(int time)
		{
			TimeObject obj = ToHMS(time);
			return StringUtils.FillStr(obj.h, 2) + ":" + StringUtils.FillStr(obj.m, 2) ;
		}
		
		
		/** 转换成mm:ss */
		public static string ToMMSS(int time)
		{
			TimeObject obj = ToHMS(time);
			if(obj.h > 0)
			{
				return StringUtils.FillStr(obj.h, 2) + ":" +StringUtils.FillStr(obj.m, 2) + ":" + StringUtils.FillStr(obj.s, 2);
			}
			return StringUtils.FillStr(obj.m, 2) + ":" + StringUtils.FillStr(obj.s, 2);
		}
			
	}
}
