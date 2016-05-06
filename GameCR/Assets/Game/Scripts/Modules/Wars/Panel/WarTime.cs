using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using System;
using UnityEngine.UI;
using CC.Runtime;

namespace Games.Module.Wars
{
	public class WarTime : MonoBehaviour 
	{
		public Text text;
		public TwinkleTextColor twinkleTextColor;
		public Text leftTimeText;
		public int time = 0;
        public Color[] c = new Color[10];
		private int _time = 0;
        UIAnimationComm anim;
		void Start () 
		{
			if(text == null) text = GetComponent<Text>();
			if(twinkleTextColor == null) twinkleTextColor = GetComponent<TwinkleTextColor>();
            if (leftTimeText != null)
            {
                anim = leftTimeText.GetComponent<UIAnimationComm>();
            }
            
            Set();
		}

		void Update () 
		{
			if(War.isGameing)
			{

				Set();
			}
		}

		public void Set()
		{
			transform.parent.gameObject.SetActive(War.timeLimit);
//			DateTime dateTime = DateTimeUtils.ConvertIntDatetime(War.time);

			time = Mathf.FloorToInt(War.timeLimit ? War.timeMax - War.time : War.time);
			text.text = TimeUtil.ToMMSS(time);

			if(War.timeLimit && time <= 60 && twinkleTextColor.enabled == false)
			{
				twinkleTextColor.enabled = true;
			}
            //Debug.Log("=========time: " + time);
			if(War.timeLimit && time <= 10)
			{
				time = time == 10 ? 10 : time % 10;

                leftTimeText.text = time + "";
				leftTimeText.color = c[time > 0 ? time - 1 : 0];

                if (!leftTimeText.gameObject.activeSelf)
				{
					leftTimeText.gameObject.SetActive(true);
				}

				if (_time != time) 
				{
                    anim.TextAnimation();
                    _time = time;
					//Coo.soundManager.PlaySound ("sound_timeleft_" + time);
				}
			}

			if(time == 0)
			{
				if(twinkleTextColor.enabled)
				{
					twinkleTextColor.enabled = false;
				}

				if(leftTimeText.gameObject.activeSelf)
				{
					leftTimeText.gameObject.SetActive(false);
				}
			}

		}

       
	}
}
