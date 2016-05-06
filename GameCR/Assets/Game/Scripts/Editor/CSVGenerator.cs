using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Diagnostics;

public class CSVGenerator : MonoBehaviour {

	[MenuItem("CC/生成表数据csv", false, 51)]
	public static void Generate()
	{
		ProcessStartInfo start = new ProcessStartInfo("sh");
		start.Arguments = Application.dataPath + "/../../../document/程序录入/out_mbcr.sh";
		start.CreateNoWindow = false;
		start.ErrorDialog = true;
		start.UseShellExecute = true;
		start.RedirectStandardOutput = false;
		start.RedirectStandardError = false;
		start.RedirectStandardInput = false;

		Process p = Process.Start(start);
		p.WaitForExit();
		p.Close();
	}

	[MenuItem("CC/生成表数据csv [git]", false, 51)]
	public static void GenerateGit()
	{
		ProcessStartInfo start = new ProcessStartInfo("sh");
		start.Arguments = Application.dataPath + "/../../../document/程序录入/out_git.sh";
		start.CreateNoWindow = false;
		start.ErrorDialog = true;
		start.UseShellExecute = true;
		start.RedirectStandardOutput = false;
		start.RedirectStandardError = false;
		start.RedirectStandardInput = false;

		Process p = Process.Start(start);
		p.WaitForExit();
		p.Close();
	}
}
