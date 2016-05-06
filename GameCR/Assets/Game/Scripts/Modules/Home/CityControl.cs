using UnityEngine;
using System.Collections;
using DG.Tweening;
using LuaInterface;

public class CityControl : MonoBehaviour {

	public ScrollZoomContainer city;
	public ScrollZoomContainer province;
	public CloudControl cloud;

	public float defaultScale = 1;
	public float maxStableScale = 2;
	public float maxExtremeScale = 2.5f;
	public float maxExtremeBackTime = 0.5f;
	public float moveEndTime = 0.5f;

	public string space_1 = "==============";

	public float cityMoveTime = 0.5f;
	public float provinceScaleTime = 0.5f;
	public float provinceStartScale = 1.3f;

	private RectTransform _cityTrans;
	private RectTransform _provinceTrans;

	void Awake()
	{
		UpdateCity();
	}

	void OnValidate()
	{
		if (Application.isPlaying)
		{
			UpdateCity();
		}
	}

	public void UpdateCity()
	{
		_cityTrans = city.target.GetComponent<RectTransform>();
		_provinceTrans = province.GetComponent<RectTransform>();

		_cityTrans.localScale = new Vector3(defaultScale, defaultScale, 1);
		
		city.maxScale = maxStableScale;
		city.maxScaleCushion = Mathf.Max(0, maxExtremeScale - maxStableScale);
		city.tweenTime = moveEndTime;
	}

	public void StartTween(LuaFunction cloudClose, LuaFunction scaleEnd)
	{
		_cityTrans.DOKill();
		Sequence seq = DOTween.Sequence();
		if (cityMoveTime > 0 && !_cityTrans.anchoredPosition.Equals(Vector2.zero)){
			seq.Append(_cityTrans.DOAnchorPos(Vector2.zero, cityMoveTime));
		}
		seq.AppendCallback(()=>{
			cloudClose.Call();

			float lastScale = _provinceTrans.localScale.x;
			_provinceTrans.localScale = new Vector3(provinceStartScale, provinceStartScale, 1);
			_provinceTrans.DOScale(lastScale, provinceScaleTime).OnComplete(()=>{
				scaleEnd.Call();
			});
		});
	}
}
