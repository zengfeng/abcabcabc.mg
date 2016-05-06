using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

namespace Game.Editors
{
	public class ABForOSX
	{
//		[MenuItem("CC/Bundle5_OSX/UI", false, 1)]
//		public static void UIFolder()
//		{
//			AB.UIFolder(RuntimePlatform.OSXPlayer, BuildTarget.StandaloneOSXIntel64);
//		}
//
//		
//
//		//-----------------
//		[MenuItem("CC/Bundle5_OSX/Image", false, 2)]
//		public static void ImageFolder()
//		{
//			AB.ImageFolder(RuntimePlatform.OSXPlayer, BuildTarget.StandaloneOSXIntel64);
//		}
//
//		[MenuItem("CC/Bundle5_OSX/Sound", false, 2)]
//		public static void SoundFolder()
//		{
//			AB.SoundFolder(RuntimePlatform.OSXPlayer, BuildTarget.StandaloneOSXIntel64);
//		}

		
		
		//-----------------
		[MenuItem ("CC/Bundle5_OSX/Effect", false, 3)]
		public static void Effect () 
		{
			AB.Effect(RuntimePlatform.OSXPlayer, BuildTarget.StandaloneOSXIntel64);
		}

		
		
		//-----------------
		[MenuItem ("CC/Bundle5_OSX/Unit_Prefab", false, 3)]
		public static void Unit_Prefab () 
		{
			AB.Unit_Prefab(RuntimePlatform.OSXPlayer, BuildTarget.StandaloneOSXIntel64);
		}

		
		//-----------------
		[MenuItem ("CC/Bundle5_OSX/Map", false, 3)]
		public static void Map () 
		{
			AB.Map(RuntimePlatform.OSXPlayer, BuildTarget.StandaloneOSXIntel64);
		}
		
		//-----------------
		[MenuItem ("CC/Bundle5_OSX/UI", false, 3)]
		public static void UI () 
		{
			AB.UI(RuntimePlatform.OSXPlayer, BuildTarget.StandaloneOSXIntel64);
		}

		
		
		//------------------
		[MenuItem ("CC/Bundle5_OSX/Lua", false, 2)]
		public static void Lua () 
		{
			AB.Lua(RuntimePlatform.OSXPlayer, BuildTarget.StandaloneOSXIntel64);
		}
		
		//------------------
		[MenuItem ("CC/Bundle5_OSX/Config", false, 2)]
		public static void Config () 
		{
			AB.Config(RuntimePlatform.OSXPlayer, BuildTarget.StandaloneOSXIntel64);
		}

	}

	public class ABForAndroid
	{

		
//		[MenuItem("CC/Bundle5_Android/UI", false, 1)]
//		public static void UIFolder()
//		{
//			AB.UIFolder(RuntimePlatform.Android, BuildTarget.Android);
//		}
//
//		
//		
//		//-----------------
//		[MenuItem("CC/Bundle5_Android/Image", false, 2)]
//		public static void ImageFolder()
//		{
//			AB.ImageFolder(RuntimePlatform.Android, BuildTarget.Android);
//		}
//		
//		[MenuItem("CC/Bundle5_Android/Sound", false, 2)]
//		public static void SoundFolder()
//		{
//			AB.SoundFolder(RuntimePlatform.Android, BuildTarget.Android);
//		}
		
		//-----------------
		[MenuItem("CC/Bundle5_Android/Effect", false, 2)]
		public static void Effect3d()
		{
			AB.Effect(RuntimePlatform.Android, BuildTarget.Android);
		}
		
		//------------------
		[MenuItem ("CC/Bundle5_Android/Unit_Prefab", false, 2)]
		public static void Unit_Prefab () 
		{
			AB.Unit_Prefab(RuntimePlatform.Android, BuildTarget.Android);
		}

		//------------------
		[MenuItem ("CC/Bundle5_Android/Map", false, 2)]
		public static void Map () 
		{
			AB.Map(RuntimePlatform.Android, BuildTarget.Android);
		}

		//------------------
		[MenuItem ("CC/Bundle5_Android/UI", false, 2)]
		public static void UI () 
		{
			AB.UI(RuntimePlatform.Android, BuildTarget.Android);
		}

		
		//------------------
		[MenuItem ("CC/Bundle5_Android/Lua", false, 2)]
		public static void Lua () 
		{
			AB.Lua(RuntimePlatform.Android, BuildTarget.Android);
		}
		
		//------------------
		[MenuItem ("CC/Bundle5_Android/Config", false, 2)]
		public static void Config () 
		{
			AB.Config(RuntimePlatform.Android, BuildTarget.Android);
		}
	}


	
	public class ABForIOS
	{
	
		
//		[MenuItem("CC/Bundle5_IOS/UI", false, 1)]
//		public static void UIFolder()
//		{
//			AB.UIFolder(RuntimePlatform.IPhonePlayer, BuildTarget.iOS);
//		}
//		
//		
//		
//		//-----------------
//		[MenuItem("CC/Bundle5_IOS/Image", false, 2)]
//		public static void ImageFolder()
//		{
//			AB.ImageFolder(RuntimePlatform.IPhonePlayer, BuildTarget.iOS);
//		}
//		
//		[MenuItem("CC/Bundle5_IOS/Sound", false, 2)]
//		public static void SoundFolder()
//		{
//			AB.SoundFolder(RuntimePlatform.IPhonePlayer, BuildTarget.iOS);
//		}
		
		//------------------
		[MenuItem ("CC/Bundle5_IOS/Effect", false, 3)]
		public static void Effect () 
		{
			AB.Effect(RuntimePlatform.IPhonePlayer, BuildTarget.iOS);
		}
		
		//------------------
		[MenuItem ("CC/Bundle5_IOS/Unit_Prefab", false, 3)]
		public static void Unit_Prefab () 
		{
			AB.Unit_Prefab(RuntimePlatform.IPhonePlayer, BuildTarget.iOS);
		}
		
		//------------------
		[MenuItem ("CC/Bundle5_IOS/Map", false, 3)]
		public static void Map () 
		{
			AB.Map(RuntimePlatform.IPhonePlayer, BuildTarget.iOS);
		}
		
		//------------------
		[MenuItem ("CC/Bundle5_IOS/UI", false, 3)]
		public static void UI () 
		{
			AB.UI(RuntimePlatform.IPhonePlayer, BuildTarget.iOS);
		}

		
		
		
		//------------------
		[MenuItem ("CC/Bundle5_IOS/Lua", false, 2)]
		public static void Lua () 
		{
			AB.Lua(RuntimePlatform.IPhonePlayer, BuildTarget.iOS);
		}
		
		//------------------
		[MenuItem ("CC/Bundle5_IOS/Config", false, 2)]
		public static void Config () 
		{
			AB.Config(RuntimePlatform.IPhonePlayer, BuildTarget.iOS);
		}
	}
	
	
	public class ABForWindows
	{

//		[MenuItem("CC/Bundle5_Windows/UI", false, 1)]
//		public static void UIFolder()
//		{
//			AB.UIFolder(RuntimePlatform.WindowsPlayer, BuildTarget.StandaloneWindows64);
//		}
//
//		
//		//-----------------
//		[MenuItem("CC/Bundle5_Windows/Image", false, 2)]
//		public static void ImageFolder()
//		{
//			AB.ImageFolder(RuntimePlatform.WindowsPlayer, BuildTarget.StandaloneWindows64);
//		}
//		
//		[MenuItem("CC/Bundle5_Windows/Sound", false, 2)]
//		public static void SoundFolder()
//		{
//			AB.SoundFolder(RuntimePlatform.WindowsPlayer, BuildTarget.StandaloneWindows64);
//		}

		
		//------------------
		[MenuItem ("CC/Bundle5_Windows/Effect", false, 3)]
		public static void Effect () 
		{
			AB.Effect(RuntimePlatform.WindowsPlayer, BuildTarget.StandaloneWindows64);
		}
		
		//------------------
		[MenuItem ("CC/Bundle5_Windows/Unit_Prefab", false, 3)]
		public static void Unit_Prefab () 
		{
			AB.Unit_Prefab(RuntimePlatform.WindowsPlayer, BuildTarget.StandaloneWindows64);
		}
		
		//------------------
		[MenuItem ("CC/Bundle5_Windows/Map", false, 3)]
		public static void Map () 
		{
			AB.Map(RuntimePlatform.WindowsPlayer, BuildTarget.StandaloneWindows64);
		}
		
		//------------------
		[MenuItem ("CC/Bundle5_Windows/UI", false, 3)]
		public static void UI () 
		{
			AB.UI(RuntimePlatform.WindowsPlayer, BuildTarget.StandaloneWindows64);
		}

		
		
		//------------------
		[MenuItem ("CC/Bundle5_Windows/Lua", false, 2)]
		public static void Lua () 
		{
			AB.Lua(RuntimePlatform.WindowsPlayer, BuildTarget.StandaloneWindows64);
		}
		
		//------------------
		[MenuItem ("CC/Bundle5_Windows/Config", false, 2)]
		public static void Config () 
		{
			AB.Config(RuntimePlatform.WindowsPlayer, BuildTarget.StandaloneWindows64);
		}
	}

	

}