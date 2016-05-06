using UnityEngine;
using System.Collections;

public class Platform {

	public static bool IsMobile
	{
		get
		{
			if (Application.platform 	== RuntimePlatform.Android 
			    || Application.platform == RuntimePlatform.IPhonePlayer
			    || Application.platform == RuntimePlatform.WP8Player)
			{
				return true;
			}
			return false;
		}
	}

	
	
	public static bool IsPC
	{
		get
		{
			if (Application.platform 	== RuntimePlatform.WindowsPlayer 
			    || Application.platform == RuntimePlatform.OSXDashboardPlayer
			    || Application.platform == RuntimePlatform.LinuxPlayer

			    
			    || Application.platform == RuntimePlatform.WSAPlayerX86
			    || Application.platform == RuntimePlatform.WSAPlayerX64
			    || Application.platform == RuntimePlatform.WSAPlayerARM
			    )
			{
				return true;
			}

			if(IsWeb)
			{
				return true;
			}

			return false;
		}
	}
	
	public static bool IsEditor
	{
		get
		{
			if (Application.platform 	== RuntimePlatform.OSXEditor 
			    || Application.platform == RuntimePlatform.WindowsEditor)
			{
				return true;
			}
			return false;
		}
	}

	public static bool IsWeb
	{
		get
		{
			if (Application.platform 	== RuntimePlatform.OSXWebPlayer 
			    || Application.platform == RuntimePlatform.WindowsWebPlayer)
			{
				return true;
			}
			return false;
		}
	}
}
