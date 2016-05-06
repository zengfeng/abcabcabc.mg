using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CenterGrid : UIBehaviour, IEndDragHandler {

	public GridLayoutGroup gridLayoutGroup;
	public float minScale = 0.5f;

	private ScrollRect _scrollRect;
	private float _sidePosX = 0;
	private bool _first = true;

	void Awake () 
	{
		_scrollRect = GetComponent<ScrollRect>();
		if (_scrollRect)
		{
			_scrollRect.onValueChanged.AddListener(OnValueChanged);
		}
	}

	void LateUpdate()
	{
		if (_first)
			OnValueChanged(Vector2.zero);

		_first = false;
	}

	void OnValueChanged(Vector2 pos)
	{
		var rectTrans = _scrollRect.transform as RectTransform;
		var gridRectTrans = gridLayoutGroup.transform as RectTransform;
		float minDelta = 9999;
		for (int i=0; i<gridRectTrans.childCount; i++)
		{
			var child = gridRectTrans.GetChild(i) as RectTransform;
			float delta = Mathf.Abs(rectTrans.rect.width / 2 - (child.anchoredPosition.x + gridRectTrans.anchoredPosition.x));
			float scale = minScale + (1 - minScale) * (1 - delta / gridLayoutGroup.cellSize.x);
			child.localScale = new Vector3(scale, scale, 1);

			if (delta < minDelta)
			{
				minDelta = delta;
				_sidePosX = rectTrans.rect.width/2 - child.anchoredPosition.x;
			}
		}
	}

	public void OnEndDrag (PointerEventData data)
	{
		var gridRectTrans = gridLayoutGroup.transform as RectTransform;
		gridRectTrans.DOKill(false);
		gridRectTrans.DOAnchorPos(new Vector2(_sidePosX, gridRectTrans.anchoredPosition.y), 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
