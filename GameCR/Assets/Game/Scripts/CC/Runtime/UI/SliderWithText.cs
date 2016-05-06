using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class SliderWithText : Slider {
    public Text text;

    public void SetValue(float pValue)
    {
        value = pValue;
        text.text = Mathf.FloorToInt(value).ToString();
    }

    public void TweenTo(int endValue, float duration)
    {
        this.DOValue(endValue, duration).OnUpdate(()=>{
            text.text = Mathf.FloorToInt(value).ToString();
        });
    }
}
