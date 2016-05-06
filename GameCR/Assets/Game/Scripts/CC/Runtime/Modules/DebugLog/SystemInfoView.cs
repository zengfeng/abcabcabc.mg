using UnityEngine;
using System.Collections;
using CC.UI;

namespace CC.Module.DebugLog
{
    public class SystemInfoView : DebugBaseView
    {
        public UITextList textList;

        void Start()
        {
            /*
            textList.Add("DeviceModel : " + SystemInfo.deviceModel);
            textList.Add("DeviceName : " + SystemInfo.deviceName);
            textList.Add("DeviceType : " + SystemInfo.deviceType);
            textList.Add("DeviceUniqueIdentifier : " + SystemInfo.deviceUniqueIdentifier);
            textList.Add("GraphicsDeviceName : " + SystemInfo.graphicsDeviceName);
            textList.Add("GraphicsMemorySize : " + SystemInfo.graphicsMemorySize + "MB");
            textList.Add("GraphicsPixelFillrate : " + SystemInfo.graphicsPixelFillrate);
            textList.Add("GraphicsShaderLevel : " + SystemInfo.graphicsShaderLevel);
            textList.Add("MaxTextureSize : " + SystemInfo.maxTextureSize);
            textList.Add("NpotSupport : " + SystemInfo.npotSupport);
            textList.Add("OperatingSystem : " + SystemInfo.operatingSystem);
            textList.Add("ProcessorCount : " + SystemInfo.processorCount);
            textList.Add("ProcessorType : " + SystemInfo.processorType);
            textList.Add("SystemMemorySize : " + SystemInfo.systemMemorySize + "MB");
            textList.Add("Resolution : " + Screen.currentResolution.width +" x "+ Screen.currentResolution.height);
            textList.Add("RefreshRate : " + Screen.currentResolution.refreshRate);
*/


            textList.Add("Application.unityVersion=" + Application.unityVersion );
            textList.Add("Application.version=" + Application.version );
            textList.Add("Application.productName=" + Application.productName );
            textList.Add("Application.isEditor=" + Application.isEditor );
            textList.Add("Application.isConsolePlatform=" + Application.isConsolePlatform );
            textList.Add("Application.isMobilePlatform=" + Application.isMobilePlatform );
            textList.Add("Application.platform=" + Application.platform );

            textList.Add("Application.persistentDataPath=" + Application.persistentDataPath );
            textList.Add("Application.dataPath=" + Application.dataPath );
            textList.Add("Application.streamingAssetsPath=" + Application.streamingAssetsPath );
            textList.Add("Application.temporaryCachePath=" + Application.temporaryCachePath );

            textList.Add("(WebPlay)Application.absoluteURL=" + Application.absoluteURL );
            textList.Add("(WebPlay)Application.srcValue=" + Application.srcValue );


            
            textList.Add("Application.internetReachability=" + Application.internetReachability );

            
            textList.Add("Application.levelCount=" + Application.levelCount );
            textList.Add("Application.loadedLevel=" + Application.loadedLevel );

            textList.Add("Application.loadedLevelName=" + Application.loadedLevelName );
            textList.Add("Application.isLoadingLevel=" + Application.isLoadingLevel );
            textList.Add("Application.isPlaying=" + Application.isPlaying );
            textList.Add("Application.isWebPlayer=" + Application.isWebPlayer );
            textList.Add("Application.runInBackground=" + Application.runInBackground );



			textList.Add("Application.backgroundLoadingPriority=" + Application.backgroundLoadingPriority );
			textList.Add("Application.bundleIdentifier=" + Application.bundleIdentifier );
			textList.Add("Application.cloudProjectId=" + Application.cloudProjectId );
			textList.Add("Application.companyName=" + Application.companyName );
			textList.Add("Application.genuine=" + Application.genuine );
			textList.Add("Application.genuineCheckAvailable=" + Application.genuineCheckAvailable );
			textList.Add("Application.installMode=" + Application.installMode );
			textList.Add("Application.genuineCheckAvailable=" + Application.genuineCheckAvailable );
			textList.Add("Application.sandboxType=" + Application.sandboxType );
			textList.Add("Application.streamedBytes=" + Application.streamedBytes );
			textList.Add("Application.systemLanguage=" + Application.systemLanguage );
			textList.Add("Application.targetFrameRate=" + Application.targetFrameRate );
			textList.Add("Application.webSecurityEnabled=" + Application.webSecurityEnabled );


            textList.Add("SystemInfo.DeviceModel : " + SystemInfo.deviceModel );
            textList.Add("SystemInfo.deviceName : " + SystemInfo.deviceName );
            textList.Add("SystemInfo.deviceType : " + SystemInfo.deviceType );
            textList.Add("SystemInfo.deviceUniqueIdentifier : " + SystemInfo.deviceUniqueIdentifier );
            textList.Add("SystemInfo.graphicsDeviceName : " + SystemInfo.graphicsDeviceName );
            textList.Add("SystemInfo.graphicsMemorySize : " + SystemInfo.graphicsMemorySize+ "MB" );
            textList.Add("SystemInfo.graphicsPixelFillrate : " + SystemInfo.graphicsPixelFillrate );
            textList.Add("SystemInfo.graphicsShaderLevel : " + SystemInfo.graphicsShaderLevel );
            textList.Add("SystemInfo.maxTextureSize : " + SystemInfo.maxTextureSize );
            textList.Add("SystemInfo.npotSupport : " + SystemInfo.npotSupport );
            textList.Add("SystemInfo.operatingSystem : " + SystemInfo.operatingSystem );
            textList.Add("SystemInfo.processorCount : " + SystemInfo.processorCount );
            textList.Add("SystemInfo.processorType : " + SystemInfo.processorType );
            textList.Add("SystemInfo.systemMemorySize : " + SystemInfo.systemMemorySize+ "MB" );
            textList.Add("Screen : " + Screen.currentResolution.width +" x "+ Screen.currentResolution.height );
            textList.Add("Screen.currentResolution.refreshRate : " + Screen.currentResolution.refreshRate );


        }
    }
}

