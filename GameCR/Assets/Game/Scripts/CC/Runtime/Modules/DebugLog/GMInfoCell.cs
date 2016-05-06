using UnityEngine;
using System.Collections;
using CC.Runtime.PB;
using CC.Runtime;
using CC.Runtime.signals;
using UnityEngine.UI;

namespace CC.Module.DebugLog
{
    public class GMInfoCell : MonoBehaviour
    {
        public Text meLabel;
        public InputField meInput;
        private GMInfoVO vo;
        private PacketManager packetManager;

        public GMInfoVO Vo
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

        void Start()
        {
            packetManager = Coo.packetManager;
        }

        public void updateView()
        {
            meLabel.text = vo.name + "\n" + vo.enPart;
            meInput.text = vo.numPart;
        }

        public void OnButtonClick()
        {
			SignalFactory.GetInstance<GMSignal>().Dispatch(vo, meInput.text);

//            C_GM_GameCommand_0x40 msg = new C_GM_GameCommand_0x40();
//            msg.content = vo.enPart + " " + meInput.label.text;
//            Debugger.Log("GM : " + msg.content);
//            packetManager.SendMessage<C_GM_GameCommand_0x40>(msg);
        }
    }
}

