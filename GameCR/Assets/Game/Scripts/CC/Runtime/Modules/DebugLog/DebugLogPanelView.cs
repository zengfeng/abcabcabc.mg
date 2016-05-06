using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CC.Runtime;
using CC.UI;

namespace CC.Module.DebugLog
{
    public class DebugLogPanelView : Window
    {
        public Transform logInfoPanel;
		public Transform warningInfoPanel;
		public Transform errorInfoPanel;
		public Transform systemInfoPanel;
		public Transform gmInfoPanel;
		private Dictionary<int, Transform> panels = new Dictionary<int, Transform>();
		public TabGroup tabGroup;

		public override void OnEnter ()
		{
			base.OnEnter();
			UpdateView();
		}
		
		public void UpdateView()
		{
			transform.SetAsLastSibling();
		}


        protected override void Start()
        {
            logInfoPanel.gameObject.SetActive(true);
            warningInfoPanel.gameObject.SetActive(false);
            errorInfoPanel.gameObject.SetActive(false);
            systemInfoPanel.gameObject.SetActive(false);
            gmInfoPanel.gameObject.SetActive(false);
			panels.Add(0, logInfoPanel);
			panels.Add(1, warningInfoPanel);
			panels.Add(2, errorInfoPanel);
			panels.Add(3, systemInfoPanel);
			panels.Add(4, gmInfoPanel);

			if(tabGroup != null) tabGroup.onValueChange.AddListener(OnChangeTab);
			
			base.Start();
        }

		public void OnChangeTab(TabButton tab)
		{

			switch(tab.uid)
			{
			case 0:
				OnLogInfoButtonClick();
				break;
			case 1:
				OnWarningInfoButtonClick();
				break;
			case 2:
				OnErrorInfoButtonClick();
				break;
			case 3:
				OnSystemInfoButtonClick();
				break;
			case 4:
				OnGMInfoButtonClick();
				break;
			}
		}

        public void OnCloseButtonClick()
        {
            gameObject.SetActive(false);
        }
		
		public void onClearButtonClick()
		{
			Transform t = panels[tabGroup.select.uid].FindChild("TextList") ;
			if(t != null)
			{
				ITextList textList = t.GetComponent<ITextList>();
				textList.Clear();
			}
		}

        public void OnLogInfoButtonClick()
        {
            logInfoPanel.gameObject.SetActive(true);
            warningInfoPanel.gameObject.SetActive(false);
            errorInfoPanel.gameObject.SetActive(false);
            systemInfoPanel.gameObject.SetActive(false);
            gmInfoPanel.gameObject.SetActive(false);
        }

        public void OnWarningInfoButtonClick()
        {
            logInfoPanel.gameObject.SetActive(false);
            warningInfoPanel.gameObject.SetActive(true);
            errorInfoPanel.gameObject.SetActive(false);
            systemInfoPanel.gameObject.SetActive(false);
            gmInfoPanel.gameObject.SetActive(false);
        }

        public void OnErrorInfoButtonClick()
        {
            logInfoPanel.gameObject.SetActive(false);
            warningInfoPanel.gameObject.SetActive(false);
            errorInfoPanel.gameObject.SetActive(true);
            systemInfoPanel.gameObject.SetActive(false);
            gmInfoPanel.gameObject.SetActive(false);
        }

        public void OnSystemInfoButtonClick()
        {
            logInfoPanel.gameObject.SetActive(false);
            warningInfoPanel.gameObject.SetActive(false);
            errorInfoPanel.gameObject.SetActive(false);
            systemInfoPanel.gameObject.SetActive(true);
            gmInfoPanel.gameObject.SetActive(false);
        }

        public void OnGMInfoButtonClick()
        {
            logInfoPanel.gameObject.SetActive(false);
            warningInfoPanel.gameObject.SetActive(false);
            errorInfoPanel.gameObject.SetActive(false);
            systemInfoPanel.gameObject.SetActive(false);
            gmInfoPanel.gameObject.SetActive(true);
        }
    }
}
