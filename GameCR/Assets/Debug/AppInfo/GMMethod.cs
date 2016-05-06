using UnityEngine;
using System.Collections;
using Games.Module.Wars;
using Newtonsoft.Json;
using CC.Runtime.PB;
using CC.Runtime;
using Games;
using System.IO;
using UnityEngine.UI;
using CC.Module.DebugLog;

public class GMMethod : MonoBehaviour {
	
	
	public void OnGMSendButtonClick(string str)
	{
		C_GmCmd_0x1618 msg = new C_GmCmd_0x1618();
		msg.cmd = str;
		Coo.packetManager.SendMessage<C_GmCmd_0x1618>(msg);
	}
	
	//改变登录模式
	public void OnGMChangeLogin()
	{
		PlayerPrefsUtil.UseUserId = false;
		int isFlagShowPanel = PlayerPrefsUtil.GetInt(PlayerPrefsKey.Setting_ShowLoginPanel);
		PlayerPrefsUtil.UseUserId = true;
		Debug.LogFormat("==========isFlagShowPanel {0}", isFlagShowPanel);
		Text text = transform.FindChild("Button--Manual/Text").GetComponent<Text>();
		if( isFlagShowPanel == 0)
		{
			text.text = "设置自动登录";
			PlayerPrefsUtil.UseUserId = false;
			PlayerPrefsUtil.SetInt(PlayerPrefsKey.Setting_ShowLoginPanel, 1);
			PlayerPrefsUtil.UseUserId = true;
		}
		else
		{
			text.text = "设置手动登录";
			PlayerPrefsUtil.UseUserId = false;
			PlayerPrefsUtil.SetInt(PlayerPrefsKey.Setting_ShowLoginPanel, 0);
			PlayerPrefsUtil.UseUserId = true;
		}
		
	}
	
	public void War_Save_WarEnterData()
	{
		if(War.enterData == null)
		{
			return;
		}
		
		
		string str = JsonConvert.SerializeObject(War.enterData, Formatting.Indented);
		
		Debug.Log(str);
		
		
		string filesPath = PathUtil.DataPath + "test_WarEnterData.json";
		PathUtil.CheckPath(filesPath, true);
		if (File.Exists(filesPath)) File.Delete(filesPath);
		FileStream fs = new FileStream(filesPath, FileMode.CreateNew);
		StreamWriter sw = new StreamWriter(fs);
		sw.Write(str);
		sw.Close(); fs.Close();
		Debug.Log("[War_Save_WarEnterData]" + filesPath);
	}
	
	public void SaveLog()
	{
		Queue allQueue = Coo.debugLogManager.allQueue;
		
		string str = @"<html>
<head>
<meta charset='utf-8' />
</head>

<body>
";
		while(allQueue.Count > 0)
		{
			
			DebugLogVO vo = allQueue.Dequeue() as DebugLogVO;
			
			string stackTrace = vo.stackTrace;
			string logString = vo.logString;
			//			logString = logString.Replace("<color=", "<font color=\"").Replace(">", "\">").Replace("</color\">", "</font>");
			
			switch (vo.logType)
			{
			case LogType.Log:
				str += string.Format("<p><h3 style=\"color: {1}; \"><pre>[Log] {0}</pre></h3><br><pre>{2}</pre></p>", logString , "#008844", stackTrace);
				break;
			case LogType.Warning:
				str += string.Format("<p><h2 style=\"color: {1}; margin-bottom: 12px;\"><pre>[Warning] {0}</pre></h2><br><pre>{2}</pre></p>", logString , "#ffa500", stackTrace);
				break;
			case LogType.Assert:
			case LogType.Error:
			case LogType.Exception:
				str += string.Format("<p><h2 style=\"color: {1}; margin-bottom: 12px;\"><pre>[Error] {0}</pre></h2><br><pre>{2}</pre></p>", logString , "#ff0000", stackTrace);
				break;
			default:
				break;
			}
		}
		str += @"</body></html>";
		
		
		string filesPath = PathUtil.DataPath + (Application.isEditor ? "../../log.html" : "log.html");
		PathUtil.CheckPath(filesPath, true);
		if (File.Exists(filesPath)) File.Delete(filesPath);
		FileStream fs = new FileStream(filesPath, FileMode.CreateNew);
		StreamWriter sw = new StreamWriter(fs);
		sw.Write(str);
		sw.Close(); fs.Close();
		
		string url = PathUtil.DataUrl + (Application.isEditor ? "../../log.html" : "log.html");
		Application.OpenURL(url);
	}
	
	
	
}
