using UnityEngine;
using System.Collections;

public class ScreenshotTool 
{
	public static void Shot(Camera myCamera, int resWidthN, int resHeightN, bool isTransparent, string filename)
	{
		RenderTexture rt = new RenderTexture(resWidthN, resHeightN, 24);
		myCamera.targetTexture = rt;
		
		TextureFormat tFormat;
		if(isTransparent)
			tFormat = TextureFormat.ARGB32;
		else
			tFormat = TextureFormat.RGB24;
		
		
		Texture2D screenShot = new Texture2D(resWidthN, resHeightN, tFormat,false);
		myCamera.Render();
		RenderTexture.active = rt;
		screenShot.ReadPixels(new Rect(0, 0, resWidthN, resHeightN), 0, 0);
		myCamera.targetTexture = null;
		RenderTexture.active = null; 
		byte[] bytes = screenShot.EncodeToPNG();
		
		System.IO.File.WriteAllBytes(filename, bytes);
		Debug.Log(string.Format("Took screenshot to: {0}", filename));
	}

}
