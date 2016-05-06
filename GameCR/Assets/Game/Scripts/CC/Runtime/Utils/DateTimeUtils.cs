using UnityEngine;
using System;
using System.Globalization;
namespace CC.Runtime.Utils
{
    public static class DateTimeUtils
    {
        private static readonly DateTime startTime=TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        /*
        *  DateTime.ToString()函数有四个重载。一般用得多的就是不带参数的那个了。殊不知，DateTime.ToString(string format)功能更强大，能输出不同格式的日期。以下把一些情况罗列出来，供大家参考。有些在MSDN上有的就没有列出来了。
        1.         y代表年份，注意是小写的y，大写的Ｙ并不代表年份。
        2.         M表示月份。
        3.         d表示日期，注意D并不代表什么。
        4.         h或H表示小时，h用的是12小时制，H用的是24小时制。
        5.         m表示分钟。
        6.         s表示秒。注意S并不代表什么。
         * 
         * DateTimeUtils.ConvertIntDatetime(model.MyCart.timeEnd).ToString("mm:ss");
         * 
         * 参考文档
         * http://www.cnblogs.com/xvqm00/archive/2009/02/19/1394093.html
         * */
        public static DateTime ConvertIntDatetime(double   utc){                      
            return startTime.AddSeconds(utc);
        }

		/// <summary>
		/// DateTime时间格式转换为Unix时间戳格式
		/// </summary>
		/// <param name="time"> DateTime时间格式</param>
		/// <returns>Unix时间戳格式</returns>
		public static int ConvertDateTimeInt(DateTime time)
		{
			return (int)(time - startTime).TotalSeconds;
		}

		public static int CurrentTimestamp
		{
			get 
			{
				return ConvertDateTimeInt (DateTime.UtcNow);
			}
		}


		//使用C#把发表的时间改为几个月,几天前,几小时前,几分钟前,或几秒前
		public static string DateStringFromNow(int seconds)
		{
			return DateStringFromNow (ConvertIntDatetime(seconds));
		}

		public static string DateStringFromNow(DateTime dt)
		{
			TimeSpan span = DateTime.UtcNow - dt;
			double totalDays = span.TotalDays;
			if (totalDays > 60)
			{
				return dt.ToShortDateString();
			}
			else
			{
				if (totalDays > 30)
				{
					return "1个月前";
				}
				else
				{
					if (totalDays > 14)
					{
						return "2周前";
					}
					else
					{
						if (totalDays > 7)
						{
							return "1周前";
						}
						else
						{
							if (totalDays > 1)
							{
								return string.Format("{0}天前", (int)Math.Floor(totalDays));
							}
							else
							{
								if (span.TotalHours > 1)
								{
									return string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
								}
								else
								{
									if (span.TotalMinutes > 1)
									{
										return string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
									}
									else
									{
										if (span.TotalSeconds >= 1)
										{
											return string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
										}
										else
										{
											return
												"1秒前";
										}
									}
								}
							}
						}
					}
				}
			}
		}

    }
}