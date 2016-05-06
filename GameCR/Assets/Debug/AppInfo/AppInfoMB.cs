using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CC.Module.DebugLog;
using CC.Runtime;
using CC.Runtime.PB;

public class AppInfoMB : MonoBehaviour
{
	
	public Queue allQueue;
	public Queue logQueue;
	public Queue warningQueue;
	public Queue errorQueue;
	public GameObject gmPanel;
	
	public void Awake()
	{
		
		//		logQueue = Queue.Synchronized(new Queue());
		//		warningQueue = Queue.Synchronized(new Queue());
		//		errorQueue = Queue.Synchronized(new Queue());
		
		
		//Application.RegisterLogCallback(CatchLogInfo);
		
		gameObject.SetActive(false);
		
		
	}
	
	
	public string str;
	private DebugLogVO preVO;
	private void CatchLogInfo(string logString, string stackTrace, LogType type)
	{
		//		if(preVO != null && preVO.logString == logString && preVO.stackTrace == stackTrace && type == type)
		//		{
		//			return;
		//		}
		
		vo = new DebugLogVO();
		vo.logString = logString;
		vo.stackTrace = stackTrace;
		vo.logType = type;
		
		preVO = vo;
		
		switch (type)
		{
		case LogType.Log:
			logQueue.Enqueue(vo);
			break;
		case LogType.Warning:
			warningQueue.Enqueue(vo);
			break;
		case LogType.Assert:
		case LogType.Error:
		case LogType.Exception:
			errorQueue.Enqueue(vo);
			break;
		default:
			break;
		}
		
		allQueue.Enqueue(vo);
	}
	
	
	public DebugLogType debugLogType;
	private DebugLogVO vo;
	void Update()
	{
		if(debugLogType == DebugLogType.None)
		{
			return;
		}
		
		if(text.text.Split('\n').Length > 100)
		{
			return;
		}
		
		if(logQueue == null)
		{
			allQueue = Coo.debugLogManager.allQueue;
			logQueue = Coo.debugLogManager.logQueue;
			warningQueue = Coo.debugLogManager.warningQueue;
			errorQueue = Coo.debugLogManager.errorQueue;
		}
		
		
		if (debugLogType == DebugLogType.All && allQueue.Count > 0)
		{
			vo = allQueue.Dequeue() as DebugLogVO;
		}
		else if (debugLogType == DebugLogType.Log && logQueue.Count > 0)
		{
			vo = logQueue.Dequeue() as DebugLogVO;
		}
		else if (debugLogType == DebugLogType.Warning && warningQueue.Count > 0)
		{
			vo = warningQueue.Dequeue() as DebugLogVO;
		}
		else if (debugLogType == DebugLogType.Error && errorQueue.Count > 0)
		{
			vo = errorQueue.Dequeue() as DebugLogVO;
		}
		else
		{
			vo = null;
		}
		
		if (vo == null)
		{
			return;
		}
		
		string stackTrace = vo.stackTrace;
		//		if(stackTrace.Length > 500)
		//		{
		//			string[] lines = stackTrace.Split('\n');
		//			stackTrace = "";
		//			for(int i = 0; i < (lines.Length < 20 ? lines.Length : 20); i ++)
		//			{
		//				stackTrace += lines[i] + "\n";
		//			}
		//		}
		
		text.text += "\n";
		switch (vo.logType)
		{
		case LogType.Log:
			text.text += string.Format("<color='{1}'>{0}</color>\n{2}", vo.logString , "#008844", stackTrace);
			break;
		case LogType.Warning:
			text.text += string.Format("<color='{1}'>{0}</color>\n{2}", vo.logString, "#ffa500", stackTrace);
			break;
		case LogType.Assert:
		case LogType.Error:
		case LogType.Exception:
			text.text += string.Format("<color='{1}'>{0}</color>\n{2}", vo.logString, "#ff0000", stackTrace);
			break;
		default:
			break;
		}
		//		text.text +=  "Length=" + text.text.Length.ToString() + " linenum="+ (text.text.Split('\n').Length);
		//		try{
		text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, text.preferredHeight > (text.transform.parent as RectTransform).sizeDelta.y ? text.preferredHeight :  (text.transform.parent as RectTransform).sizeDelta.y);
		//		}
		//		catch()
		//		{
		//
		//		}
	}
	
	
	public void ShowAll()
	{
		debugLogType = DebugLogType.All;
	}
	
	public void ShowLog()
	{
		debugLogType = DebugLogType.Log;
	}
	
	public void ShowWarning()
	{
		debugLogType = DebugLogType.Warning;
	}
	
	public void ShowError()
	{
		debugLogType = DebugLogType.Error;
	}
	
	public Text text;
	public void ShowInfo()
	{
		debugLogType = DebugLogType.None;
		text.text += "\n";
		text.text += AppInfo.GetAppInfo();
		text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, text.preferredHeight > (text.transform.parent as RectTransform).sizeDelta.y ? text.preferredHeight :  (text.transform.parent as RectTransform).sizeDelta.y);
	}
	
	public void AddInfo(string str)
	{
		text.text += "\n";
		text.text += str;
		text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, text.preferredHeight > (text.transform.parent as RectTransform).sizeDelta.y ? text.preferredHeight :  (text.transform.parent as RectTransform).sizeDelta.y);
		
	}
	
	public void Clear()
	{
		text.text = "";
	}
	
	public void GMVisiable()
	{
		if(gmPanel != null) gmPanel.SetActive(!gmPanel.activeSelf);
		
		int isFlagShowPanel = PlayerPrefsUtil.GetInt(PlayerPrefsKey.Setting_ShowLoginPanel);
		Text text = transform.FindChild("GBPanel/Button--Manual/Text").GetComponent<Text>();
		if (isFlagShowPanel == 0)
		{
			text.text = "设置自动登录";
		}
		else
		{
			text.text = "设置手动登录";
		}
	}
	
	public void Hide()
	{
		gameObject.SetActive(false);
	}
	
	public void Show()
	{
		gameObject.SetActive(true);
	}
	
	public void OnGMSendButtonClick()
	{
		Text gmText = gameObject.transform.Find("GMBar/InputField/Text").GetComponent<Text>();
		
		C_GmCmd_0x1618 msg = new C_GmCmd_0x1618();
		msg.cmd = gmText.text;
		Coo.packetManager.SendMessage<C_GmCmd_0x1618>(msg);
		
		gmText.text = "send over!";
		
		Hide();
	}
	
	
	
	//	public class DebugLogVO
	//	{
	//		public string logString;
	//		public string stackTrace;
	//		public LogType logType;
	//	}
	//	
	//	
	//	public enum DebugLogType
	//	{
	//		None,
	//		Log,
	//		Warning,
	//		Error,
	//	}
}



