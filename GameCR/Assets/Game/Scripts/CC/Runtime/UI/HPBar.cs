using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CC.UI
{
	public class HPBar :  BaseUI 
	{
		enum State
		{
			IDLE,
			FADEIN,
			HOLD,
			FADEOUT
		}
		
		public Image tweenImage;
		public RectTransform tween;
		public RectTransform front;
		public float value = 0.5f;
		private float _value = 0.5f;
		private State state = State.IDLE;

		public float maxCdFadeIn = 0.1F;
		public float maxCdFadeOut = 0.1F;
		public float maxCdHold = 1F;

		private float cdFadeIn;
		private float cdHold;
		private float cdFadeOut;
		
		private Vector3 scale = Vector3.one;
		protected override void Awake ()
		{
			base.Awake ();

			if(tween != null) tween = (RectTransform) transform.FindChild("Color-Tween");
			if(front != null) front = (RectTransform) transform.FindChild("Color-Front");
			
			tweenImage = tween.GetComponent<Image>();
		}

		public void InitValue(float val)
		{
			if(val > 1) val = 1;
			if(val < 0) val = 0;
			value = val;
			_value = val;
			scale.x = value;
			front.localScale = scale;
			tween.localScale = scale;
			TweenHide();
		}


		void TweenShow()
		{
			tween.gameObject.SetActive(true);
		}

		void TweenHide()
		{
//			tween.gameObject.SetActive(false);
		}
		
		
		void TweenAlpha(float value)
		{
//			tweenImage.color = new Color(tweenImage.color.r, tweenImage.color.g, tweenImage.color.b, value);
		}

		virtual protected void Update()
		{
			if(_value != value)
			{
				
				if(value > 1) value = 1;
				if(value < 0) value = 0;

//				if(_value < value)
//				{
//					RectTransform team = front;
//					front = tween;
//					tween = team;
//				}
				scale.x = value;
				if(_value < value)
				{
					tween.localScale = scale;
				}

				_value = value;
				
				if(state == State.IDLE || state == State.FADEOUT)
				{
					state = State.FADEIN;
					cdFadeIn = maxCdFadeIn;
					TweenShow();
				}
				else if(state == State.HOLD)
				{
					cdHold = maxCdHold;
				}
			}



	
			if (state == State.FADEOUT)
			{
				if (cdFadeOut <= 0)
				{
					state = State.IDLE;
					TweenHide();
				}

				TweenAlpha(cdFadeOut / maxCdFadeOut);
				cdFadeOut -= Time.deltaTime;
			}
			else if (state == State.FADEIN)
			{
				if (cdFadeIn <= 0)
				{
					state = State.HOLD;
					cdHold = maxCdHold;
				}
				
				TweenAlpha(1 - cdFadeIn / maxCdFadeIn);
				cdFadeIn -= Time.deltaTime;
			}
			else if (state == State.HOLD)
			{
				if (cdHold <= 0)
				{
					state = State.FADEOUT;
					cdFadeOut = maxCdFadeOut;
					
					tween.localScale = scale;
				}
				
				cdHold -= Time.deltaTime;
				front.localScale = Vector3.Lerp(front.localScale, scale, 1f - (cdHold / maxCdHold));
			}
		}


	}
}