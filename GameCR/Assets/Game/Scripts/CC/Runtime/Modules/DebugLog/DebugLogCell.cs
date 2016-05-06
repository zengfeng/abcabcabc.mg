using UnityEngine;
using System.Collections;
using CC.UI;
using UnityEngine.UI;

namespace CC.Module.DebugLog
{
    public class DebugLogCell : MonoBehaviour
    {
        private DebugLogVO vo;
        public InputField inputText;

        public DebugLogVO Vo
        {
            get
            {
                return vo;
            }
            set
            {
                vo = value;
            }
        }

		public InputField HInputText
        {
            get
            {
                return inputText;
            }

            set
            {
                inputText = value;
            }
        }

        public void OnClick()
        {
			if(vo != null)
				inputText.text = vo.stackTrace;
			else
				inputText.text = "No Find VO";
        }
    }
}

