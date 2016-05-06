using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MultipleProgress : MonoBehaviour {

	public Slider[] sliders;
	public float[] values;
	public Text[] texts;
	public float minProgress = 0.15f; //0~1

	public float _maxValue = 0;
	public float maxValue
	{
		get
		{
			return _maxValue;
		}

		set
		{
			_maxValue = value;

			for (int i=0; i < sliders.Length; i++)
			{
				Slider s = sliders[i];
				if (s != null)
					s.maxValue = _maxValue;
			}
			RefreshProgress();
		}
	}

	public void SetValue(int index, float value)
	{
		if (index < values.Length)
		{
			values[index] = value;
		}
		RefreshProgress();
	}

	public void RefreshProgress()
	{
		float overlay = 0;
		for (int i=0; i<values.Length; i++)
		{
			if (i >= sliders.Length)
				break;

			overlay += Mathf.Max(values[i], minProgress*_maxValue);

			Slider s = sliders[i];
			if (s != null)
				s.value = overlay;

			if (i < texts.Length && texts[i] != null)
			{
				Text t = texts[i];
				t.text = Mathf.FloorToInt(values[i]).ToString();
				if (i > 0)
				{
					Slider last = sliders[i-1];
					if (last != null)
					{
						float lastRight = last.fillRect.rect.width;
						float curRight = s.fillRect.rect.width;
						Vector2 anchorPos = t.rectTransform.anchoredPosition;
						anchorPos.x = lastRight + (curRight - lastRight)/2;
						t.rectTransform.anchoredPosition = anchorPos;
					}
				}
				else
				{
					Vector2 anchorPos = t.rectTransform.anchoredPosition;
					anchorPos.x = s.fillRect.rect.width/2;
					t.rectTransform.anchoredPosition = anchorPos;
				}
			}
		}
	}

	void OnValidate()
	{
		maxValue = _maxValue;
	}
}
