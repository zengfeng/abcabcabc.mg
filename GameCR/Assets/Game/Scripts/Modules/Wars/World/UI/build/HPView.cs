using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace Games.Module.Wars
{
	public class HPView : EntityView 
	{
		public Slider slider;
		public Text text;
		public RectTransform uplevelTag;
		public Text uplevelText;

		public bool showInt = true;
		public float value = 0f;
		public float max = 100f;
		public float uplevel = 0F;
		private float _rate = 0f;
		private float _value = -1F;
		private float _max = -1F;
		private float _uplevel = -1F;

		protected override void OnUpdate ()
		{
			base.OnUpdate ();

			if(_value != value || _max != max || _uplevel != uplevel)
			{
				_value = value;
				_max = max;
				_uplevel = uplevel;
				_rate = max == 0F ? 0F : value / max;
				slider.value = _rate;
				text.text = showInt ? (int)value + "" : value + "";
				if(uplevelTag != null)
				{
					float x = uplevel / _max * 200f;

					uplevelTag.anchoredPosition = new Vector2(x, 0f);
					uplevelText.text = showInt ? (int)uplevel + "" : uplevel + "";
					if(uplevelTag.gameObject.activeSelf && uplevel == 0)
					{
						uplevelTag.gameObject.SetActive(false);
					}
					else if(!uplevelTag.gameObject.activeSelf && uplevel > 0)
					{
						uplevelTag.gameObject.SetActive(true);
					}
				}
			}
		}


	}
}