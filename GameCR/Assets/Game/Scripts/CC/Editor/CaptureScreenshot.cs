using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;

public class CaptureScreenshot 
{
	[MenuItem ("CC/截图", false, 9000)]
	public static void Screenshot()
	{
		
		string path = string.Format("{0}/Screenshot_{1}.png", 
		                        Application.dataPath + "/_temp", 
		                        System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));

		PathUtil.CheckPath(path);

		Application.CaptureScreenshot(path);
	}
}
