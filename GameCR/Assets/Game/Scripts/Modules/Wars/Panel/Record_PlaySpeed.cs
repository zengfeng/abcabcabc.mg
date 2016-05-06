using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CC.UI;
using CC.Runtime.signals;
using CC.Runtime.Utils;


namespace Games.Module.Wars
{
	public class Record_PlaySpeed : MonoBehaviour 
	{
		public float[] vals = new float[]{0.5f, 1, 2, 4};
		public GameObject 	text_half;
		public Text 		text;
		public RectTransform rate;
		public float rateWidth = 80;
		public int index = 1;
		public void OnClick()
		{
			index++;
			if (index >= vals.Length)
				index = 0;

			if (vals [index] < 1)
			{
				text_half.SetActive (true);
				text.gameObject.SetActive (false);
			} 
			else
			{
				text_half.SetActive (false);
				text.gameObject.SetActive (true);

				text.text = "×" + vals [index];
			}

			Time.timeScale = vals [index] <= 1 ? vals [index] : vals [index] * 2;

			rate.sizeDelta = rate.sizeDelta.SetX (rateWidth * (index + 1) / vals.Length);
		
		}
	}
}
