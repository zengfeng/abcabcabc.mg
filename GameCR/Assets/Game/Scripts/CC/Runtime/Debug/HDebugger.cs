using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace CC.Runtime
{
	public enum HDebuggerModule
	{
		Proto,
		Asset,
		Menu,
		Normal
	}

    public class HDebugger
    {
        // public field
        // ------------
        public static bool isLogEnable = true;
        public static bool isWarningEnable = true;
        public static bool isErrorEnable = true;
        public static bool isExceptionEnable = true;

		public static List<HDebuggerModule> disableList = new List<HDebuggerModule>();

        // public method
        // -------------
        public static void Log(object message)
        {
            if (isLogEnable)
            {
                Debug.Log(message);
            }
        }

        public static void Log(object message, UnityEngine.Object context)
        {
            if (isLogEnable)
            {
                Debug.Log(message, context);
            }
        }

        public static void LogWarning(object message)
        {
            if (isWarningEnable)
            {
                Debug.LogWarning(message);
            }
        }

        public static void LogWarning(object message, UnityEngine.Object context)
        {
            if (isWarningEnable)
            {
                Debug.LogWarning(message, context);
            }
        }

        public static void LogError(object message)
        {
            if (isErrorEnable)
            {
                Debug.LogError(message);
            }
        }

        public static void LogError(object message, UnityEngine.Object context)
        {
            if (isErrorEnable)
            {
                Debug.LogError(message, context);
            }
        }

        public static void LogException(Exception exception)
        {
            if (isExceptionEnable)
            {
                Debug.LogException(exception);
            }
        }

        public static void LogException(Exception exception, UnityEngine.Object context)
        {
            if (isExceptionEnable)
            {
                Debug.LogException(exception, context);
            }
        }
		//----------------------------------------------------


		public static void Log(HDebuggerModule module, object message)
		{
			if (isLogEnable)
			{
				if(disableList.IndexOf(module) == -1)
					Debug.Log(message);
			}
		}
		
		public static void Log(HDebuggerModule module, object message, UnityEngine.Object context)
		{
			if (isLogEnable)
			{
				Debug.Log(message, context);
			}
		}

		
		public static void LogWarning(HDebuggerModule module, object message)
		{
			if (isWarningEnable)
			{
				Debug.LogWarning(message);
			}
		}
		
		public static void LogWarning(HDebuggerModule module, object message, UnityEngine.Object context)
		{
			if (isWarningEnable)
			{
				Debug.LogWarning(message, context);
			}
		}
		
		public static void LogError(HDebuggerModule module, object message)
		{
			if (isErrorEnable)
			{
				Debug.LogError(message);
			}
		}
		
		public static void LogError(HDebuggerModule module, object message, UnityEngine.Object context)
		{
			if (isErrorEnable)
			{
				Debug.LogError(message, context);
			}
		}
		
		public static void LogException(HDebuggerModule module, Exception exception)
		{
			if (isExceptionEnable)
			{
				Debug.LogException(exception);
			}
		}
		
		public static void LogException(HDebuggerModule module, Exception exception, UnityEngine.Object context)
		{
			if (isExceptionEnable)
			{
				Debug.LogException(exception, context);
			}
		}


    }
}
