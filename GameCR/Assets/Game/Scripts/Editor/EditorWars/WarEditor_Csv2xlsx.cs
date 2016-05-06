using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Diagnostics;
using Games.Guides;
using System.Collections.Generic;
using System.IO;

public class WarEditor_Csv2xlsx {

	
	[MenuItem ("关卡/csv2xlsx", false, 6000)]
	public static void Csv2xlsx()
	{
		#if UNITY_EDITOR_OSX
		
		string shell = Application.dataPath +"/../csv2xlsx/csv2xlsx_mac.sh";
		System.Diagnostics.Process.Start("/bin/bash", shell);
		#else
		
		string shell = Application.dataPath +"/../csv2xlsx/csv2xlsx_win.bat";
		string log = RunCmd(shell);
		UnityEngine.Debug.Log(log);
		#endif
	}

	private static string RunCmd(string command)
	{
		//例Process
		Process p = new Process();
		p.StartInfo.FileName = "cmd.exe";           //确定程序名
		p.StartInfo.Arguments = "/c " + command;    //确定程式命令行
		p.StartInfo.UseShellExecute = false;        //Shell的使用
		p.StartInfo.RedirectStandardInput = true;   //重定向输入
		p.StartInfo.RedirectStandardOutput = true; //重定向输出
		p.StartInfo.RedirectStandardError = true;   //重定向输出错误
		p.StartInfo.CreateNoWindow = true;          //设置置不显示示窗口
		p.Start();   
		return p.StandardOutput.ReadToEnd();        //输出出流取得命令行结果果
	}


	[MenuItem ("关卡/导出引导描述", false, 6000)]
	public static void ExportGuide()
	{
		GuideModel guideModel = new GuideModel ();
		List<string> list = guideModel.GetCsv ();

		string path = Application.dataPath + "/../csv2xlsx/war_guide.csv";;


		if (File.Exists(path)) File.Delete(path);

		FileStream fs = new FileStream(path, FileMode.CreateNew);
		StreamWriter sw = new StreamWriter(fs);



		for(int i = 0; i < list.Count; i ++)
		{
			sw.WriteLine(list[i]);
		}


		sw.Close(); fs.Close();

		UnityEngine.Debug.Log(path);








		#if UNITY_EDITOR_OSX
		string shell = Application.dataPath +"/../csv2xlsx/warguide_mac.sh";
		System.Diagnostics.Process.Start("/bin/bash", shell);
		#else
		string shell = Application.dataPath +"/../csv2xlsx/warguide_win.bat";
		string log = RunCmd(shell);
		UnityEngine.Debug.Log(log);
		#endif





	}



}
