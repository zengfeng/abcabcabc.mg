using UnityEngine;
using System.Collections;
using CC.Runtime;
using UnityEngine.UI;
using CC.Runtime.signals;
using System.Collections.Generic;

namespace Games.Module.Sysmsgs
{
	public class MsgScrollPanel : Window 
	{
		public RectTransform panel;
		public CanvasRenderer renderer;
		public Text text;
		public float bottomRate = 0.2F;
		public float topRate = 0.2F;
		public float showTime = 0.3F;
		public float stopTime = 1F;
		public float hideTime = 0.3F;
		bool isRuning = false;
		Queue msgList = new Queue();
	
		public override void SetParameter(object obj)
		{
			this.parameter = obj;
			msgList.Enqueue(obj);

			if(isRuning)
			{
				OnEnter();
			}
		}

		public override void OnEnter ()
		{
			base.OnEnter();
			UpdateView();
			isRuning = true;
		}

		
		public  override void OnExit()
		{
			base.OnExit();
			msgList.Clear();
			isRuning = false;
		}

		public void UpdateView()
		{	

			MsgMenuData msgMenuData = null;
			if(msgList.Count > 0)
			{
				msgMenuData = msgList.Dequeue() as MsgMenuData;
			}


			if(msgMenuData == null)
			{
				Exit();
				return;
			}
			text.text = msgMenuData.content;

			TweenShow();
		}

		public float bottom;
		public float top;
		public float alpha;
		public void TweenShow()
		{
			Alhpa = 0;
			panel.localPosition = new Vector3(0F, 0F, 0F);
			
			bottom = Screen.height * 0.5F * bottomRate * -1;
			top = Screen.height * 0.5F * topRate;
			iTween.MoveFrom(panel.gameObject, iTween.Hash("y", bottom, 
			                                              "islocal", true, 
			                                              "easetype", iTween.EaseType.easeOutExpo, 
			                                              "onupdate", "OnTweenShowUpdate", 
			                                              "oncomplete", "OnTweenShowComplete",
			                                              "onupdatetarget", gameObject,
			                                              "oncompletetarget", gameObject,
			                                              "time", showTime));
		}

		void OnTweenShowUpdate()
		{
			Alhpa = 1F - panel.localPosition.y / Mathf.Abs(bottom);
		}
		
		void OnTweenShowComplete()
		{
			Alhpa = 1F;
			TweenHide();
		}

		void TweenHide()
		{
			iTween.MoveTo(panel.gameObject, iTween.Hash("y", top, 
			                                            "islocal", true, 
			                                            "easetype", iTween.EaseType.easeInExpo, 
			                                            "onupdate", "OnTweenHideUpdate", 
			                                            "oncomplete", "OnTweenHideComplete",
			                                            "onupdatetarget", gameObject,
			                                            "oncompletetarget", gameObject,
			                                            "delay", stopTime,
			                                            "time", hideTime));
		}

		
		
		void OnTweenHideUpdate()
		{
			Alhpa = 1 - panel.localPosition.y / Mathf.Abs(top);
		}
		
		void OnTweenHideComplete()
		{
			Alhpa = 0F;
			UpdateView();
			SignalFactory.GetInstance<MsgScrollCompleteSignal>().Dispatch();
		}

		public float Alhpa
		{
			get
			{
				return alpha;
			}

			set
			{
				alpha = value;
				renderer.SetAlpha(alpha);
			}
		}



	}
}
