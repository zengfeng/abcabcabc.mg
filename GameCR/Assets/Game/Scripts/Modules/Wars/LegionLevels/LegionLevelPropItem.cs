using UnityEngine;
using System.Collections;
using CC.Runtime.Utils;
using UnityEngine.UI;
using DG.Tweening;


namespace Games.Module.Wars
{

	public class LegionLevelPropItem : MonoBehaviour 
	{

		private float rateInit;
		private float rateVal;
		public float max = 100;
		public float init = 0;
		public float val = 0;

		public float maxWidth = 330;
		public RectTransform colorInit;
		public RectTransform colorVal;
		public Text text;

		void Start ()
		{
		
		}

		public void Set()
		{
			rateInit = init / max;
			rateVal = val / max;

			rateInit = Mathf.Max(0, Mathf.Min(rateInit, 1));
			rateVal  = Mathf.Max(0, Mathf.Min(rateVal, 1));

			colorInit.sizeDelta = colorInit.sizeDelta.SetX(maxWidth * rateInit);
//			colorVal.sizeDelta = colorVal.sizeDelta.SetX(maxWidth * rateVal);


//			text.text = Mathf.FloorToInt(val);
			text.text ="(" + init + ") "+ val;
		}

		void OnEnable()
		{
			colorVal.DOKill();
			colorVal.DOSizeDelta(colorVal.sizeDelta.SetX(maxWidth * rateVal), 1f).SetDelay(0.5f);
		}

		void OnDisable()
		{
			colorVal.DOKill();
			colorVal.sizeDelta = colorVal.sizeDelta.SetX(maxWidth * rateVal);
		}
	}
}