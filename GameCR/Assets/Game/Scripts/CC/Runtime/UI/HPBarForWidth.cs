using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CC.Runtime.Utils;

namespace CC.UI
{
	public class HPBarForWidth :  BaseUI 
	{
		enum State
		{
			IDLE,
			FADEIN,
			HOLD,
			FADEOUT
		}

		public RectTransform tween;
		public RectTransform front;
		public Text text;
		public float value = 0.5f;
		private float _value = 0.5f;
		private State state = State.IDLE;

		public float maxCdFadeIn = 0.1F;
		public float maxCdFadeOut = 0.1F;
		public float maxCdHold = 1F;

		private float cdFadeIn;
		private float cdHold;
		private float cdFadeOut;
		
		private float scale = 1f;
		private float width = 800f;
		protected override void Awake ()
		{
			base.Awake ();

			if(tween == null) tween = (RectTransform) transform.FindChild("Color-Tween");
			if(front == null) front = (RectTransform) transform.FindChild("Color-Front");
			if(text == null) text = (Text) transform.FindChild("Text").GetComponent<Text>();
			width = front.sizeDelta.x;

		}

		public void InitValue(float val)
		{
			if(val > 1) val = 1;
			if(val < 0) val = 0;
			value = val;
			_value = val;
			scale = value;
			frontScale = scale;
			tweenScale = scale;
			TweenHide();
		}


		void TweenShow()
		{
			tween.gameObject.SetActive(true);
		}

		void TweenHide()
		{
			tween.gameObject.SetActive(false);
		}
		
		
		void TweenAlpha(float value)
		{
//			tweenImage.color = new Color(tweenImage.color.r, tweenImage.color.g, tweenImage.color.b, value);
		}

		private float _frontScale = 1f;
		private float frontScale
		{
			get
			{
				return _frontScale;
			}

			set
			{
				_frontScale = value;
				front.sizeDelta = front.sizeDelta.SetX(_frontScale * width);
			}
		}

		private float _tweenScale = 1f;
		private float tweenScale
		{
			get
			{
				return _tweenScale;
			}
			
			set
			{
				_tweenScale = value;
				tween.sizeDelta = tween.sizeDelta.SetX(_tweenScale * width);
			}
		}

		public float hideTime = 0f;
		virtual protected void Update()
		{
			if(_value != value)
			{
				
				if(value > 1) value = 1;
				if(value < 0) value = 0;

				scale = value;

				if(state == State.IDLE || state == State.FADEOUT)
				{
					state = State.FADEIN;
					cdFadeIn = maxCdFadeIn;

				}
				else if(state == State.HOLD)
				{
					cdHold = maxCdHold;
				}

				if(Mathf.Abs(_value - value) > 0.1f)
				{
					tweenScale = _value < value ? value : _value;
					hideTime = state == State.HOLD ? maxCdHold + maxCdFadeOut: cdFadeIn + maxCdHold + maxCdFadeOut;
					TweenShow();
				}


				_value = value;
			}

			if(hideTime > 0)
			{
				hideTime -= Time.deltaTime;
				if(hideTime <= 0)
				{
					TweenHide();
					tweenScale = scale;
				}
			}



			if (state == State.FADEOUT)
			{
				if (cdFadeOut <= 0)
				{
					state = State.IDLE;
//					TweenHide();
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
					
//					tweenScale = scale;
				}
				
				cdHold -= Time.deltaTime;
				frontScale = Mathf.Lerp(frontScale, scale, 1f - (cdHold / maxCdHold));
			}
		}


	}
}