using UnityEngine;
using System.Collections;
using LuaInterface;
using DG.Tweening;

public class ProvinceControl : MonoBehaviour {

	public ScrollZoomContainer city;
	public ScrollZoomContainer province;
	public CloudControl cloud;

	public float defaultScale = 1;
	public float maxStableScale = 2;
	public float maxExtremeScale = 2.5f;
	public float maxExtremeBackTime = 0.5f;
	public float moveEndTime = 0.5f;
	
	public string space_1 = "==============";

	public float provinceMoveTime = 0.5f;
	public float cityScaleTime = 0.5f;
	public float cityStartScale = 1.3f;

	private RectTransform _cityTrans;
	private RectTransform _provinceTrans;

	void Awake()
	{
		UpdateProvince();
	}
	
	void OnValidate()
	{
		if (Application.isPlaying)
		{
			UpdateProvince();
		}
	}
	
	public void UpdateProvince()
	{
		_cityTrans = city.GetComponent<RectTransform>();
		_provinceTrans = province.target.GetComponent<RectTransform>();
		_provinceTrans.localScale = new Vector3(defaultScale, defaultScale, 1);

		province.maxScale = maxStableScale;
		province.maxScaleCushion = Mathf.Max(0, maxExtremeScale - maxStableScale);
		province.tweenTime = moveEndTime;
	}

	public void StartTween(LuaFunction cloudClose, LuaFunction scaleEnd)
	{
		_provinceTrans.DOKill();
		Sequence seq = DOTween.Sequence();
		if (provinceMoveTime > 0 && !_provinceTrans.anchoredPosition.Equals(Vector2.zero)){
			seq.Append(_provinceTrans.DOAnchorPos(Vector2.zero, provinceMoveTime));
		}
		seq.AppendCallback(()=>{
			cloud.PlayCloudClose((CloudControl c)=>{
				cloud.PlayCloudOpen();
				cloudClose.Call();
				
				float lastScale = _cityTrans.localScale.x;
				_cityTrans.localScale = new Vector3(cityStartScale, cityStartScale, 1);
				_cityTrans.DOScale(lastScale, cityScaleTime).OnComplete(()=>{
					scaleEnd.Call();
				});
			});
		});
	}
}
