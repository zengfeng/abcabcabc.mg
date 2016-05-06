using UnityEngine;
using System.Collections;
using CC.Runtime;
using System;
using System.Collections.Generic;
using CC.UI;
using UnityEngine.UI;

namespace CC.Module.DebugLog
{
    public enum DebugLogType
    {
		None,
        Log,
        Warning,
		Error,
		All
    }

    public class LogInfoView : DebugBaseView
    {
        // public field
        // ------------
        public DebugLogType debugLogType;
        public int cellMinHeight = 50;
        public int maxLogCount = 100;
		public MultipleTextList textList;
		public GameObject logCell;
		public InputField inputField;

        // private field
        // -------------
        private DebugLogManager manager;
        private DebugLogVO vo;

        // public method
        // -------------
        public void ClearAllLogs()
        {
			textList.Clear();
        }

        // private method
        // --------------
        void Start()
        {
            manager = DebugLogManager.Instance;
        }
    
        void Update()
        {

            if (debugLogType == DebugLogType.Log && manager.logQueue.Count > 0)
            {
                vo = manager.logQueue.Dequeue() as DebugLogVO;
            }
            else if (debugLogType == DebugLogType.Warning && manager.warningQueue.Count > 0)
            {
                vo = manager.warningQueue.Dequeue() as DebugLogVO;
            }
            else if (debugLogType == DebugLogType.Error && manager.errorQueue.Count > 0)
            {
                vo = manager.errorQueue.Dequeue() as DebugLogVO;
            }
            else
            {
                vo = null;
            }

            if (vo == null)
            {
                return;
            }

			GameObject item = GameObject.Instantiate(logCell);
			Text text = item.GetComponent<Text>();

                
            switch (vo.logType)
            {
			case LogType.Log:
				text.text = string.Format("<color='{1}'>{0}</color>", vo.logString, "#000000");
                    break;
			case LogType.Warning:
				text.text = string.Format("<color='{1}'>{0}</color>", vo.logString, "#ffa500");
                    break;
                case LogType.Assert:
                case LogType.Error:
			case LogType.Exception:
				text.text = string.Format("<color='{1}'>{0}</color>", vo.logString, "#ff0000");
                    break;
                default:
                    break;
            }

			RectTransform rt = item.GetComponent<RectTransform>();
			rt.sizeDelta = new Vector2(rt.sizeDelta.x, text.preferredHeight > cellMinHeight ? text.preferredHeight : cellMinHeight);

			DebugLogCell debugLogCell = item.GetComponent<DebugLogCell>();
			debugLogCell.Vo = vo;
			debugLogCell.HInputText = inputField;


			item.SetActive(true);
			textList.Add(rt);
        }

       
    }
}

