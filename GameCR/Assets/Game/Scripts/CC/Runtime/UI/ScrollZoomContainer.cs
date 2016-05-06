using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
using System;
using LuaInterface;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollZoomContainer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public RectTransform target;
	public RectTransform ui;
	public Texture2D touchTexture = null;
	public float scaleToDrawDeltaTime = 0.1f;//拖动时间低于此值不滑动
	public Ease easeType = Ease.OutQuad;//缓动函数
    public Ease switchEaseType = Ease.Linear;

	public string dragAndZoomDivide = "------------------";
	public float moveScale = 0.2f;
	public float zoomScale = 0.2f;
	public float tweenTime = 0.5f;
	public float minScale = 0.7f;
	public float maxScale = 2f;
	public float maxScaleCushion = 2.0f;

	public string sceneChangeDivide = "------------------";
	public float sceneMoveTime = 0.2f;
	public float sceneScaleTime = 0.2f;
	public float zoomScaleOffset = 0.2f;

	public string uiDivide = "------------------";

	[Range(0, 1.0f)]
	public float uiScaleFactor = 0.0f;

	enum State{
		None = 0,
		Drag = 1,
		Scale = 2
	}

	bool _altDown = false;
	bool _mouseHasDown = false;
	bool _firstHasTouched = false;
	bool _secHasTouched = false;
	bool _isMouse = false;
	bool _multiState = false;
	bool _isTween = false;
	State _mouseState = State.None;

	Vector2 _firstBeganPos = Vector2.zero;
	Vector2 _secBeganPos = Vector2.zero;
	Vector2 _pivotDistance = Vector2.zero;
	Vector2 _originAnchorPos = Vector2.zero;

    float _touchBaganTime = 0.0f;
	float _startDistance = 0.0f;
	float _baseScale = 0.0f;
	float _lastScaleTime = 0.0f;
	float _originScale = 0.0f;

	CanvasGroup _targetGroup = null;

	void Awake () {
		Input.multiTouchEnabled = true;
		Application.targetFrameRate = 60;

		_targetGroup = target.GetComponent<CanvasGroup>();
		if (_targetGroup == null)
		{
			_targetGroup = target.gameObject.AddComponent<CanvasGroup>();
		}
	}
	
	void Update () {
		if (Application.platform == RuntimePlatform.OSXEditor || 
		    Application.platform == RuntimePlatform.WindowsEditor)
		{
			if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject() && IsPointerEnter())
			{
				UpdateMouse();
			}
		}
		else
		{
			if (Input.touchCount > 0 && IsPointerEnter())
			{
				UpdateTouch();
			}
		}
	}

	void IPointerEnterHandler.OnPointerEnter (PointerEventData eventData)
	{
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		_targetGroup.blocksRaycasts = true;
		_mouseState = State.None;
	}

	private void OnGUI()
	{
//		if (touchTexture != null && _multiState)
//		{
//			int texWidth = touchTexture.width;
//			int texHeight = touchTexture.height;
//			GUI.DrawTexture(new Rect(_firstBeganPos.x - texWidth/2, Screen.height - _firstBeganPos.y - texHeight/2, texWidth, texHeight), touchTexture, ScaleMode.ScaleToFit);
//			if (_secHasTouched)
//			{
//				GUI.DrawTexture(new Rect(_secBeganPos.x - texWidth/2, Screen.height - _secBeganPos.y - texHeight/2, texWidth, texHeight), touchTexture, ScaleMode.ScaleToFit);
//			}
//		}
	}

	bool IsPointerEnter()
	{
		EventSystem eventSys = EventSystem.current;
		var pointer = new PointerEventData(eventSys);
		pointer.position = Input.mousePosition;
		var raycast = new List<RaycastResult>();
		EventSystem.current.RaycastAll(pointer, raycast);
		if (raycast.Count > 0)
		{
			var trans = raycast[0].gameObject.transform;
			var isSelf = false;
			while (trans != null)
			{
				isSelf = trans == transform;
				if (isSelf)
					break;
				trans = trans.parent;
			}
			return isSelf;
		}
		return false;
	}

	void UpdateMouse()
	{
		if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
		{
			_altDown = true;
			_multiState = true;
		}
		else if(Input.GetKeyUp(KeyCode.LeftAlt) || Input.GetKeyUp(KeyCode.RightAlt))
		{
			_altDown = false;
		}

		if (_multiState)
		{
			if (Input.GetMouseButtonDown(0))
			{
				_mouseHasDown = true;
				if (!_firstHasTouched)
				{
					_firstBeganPos = Input.mousePosition;
				}
				else
				{
					_secHasTouched = true;
					OnTouchBegan(2, _firstBeganPos, Input.mousePosition);
					_mouseState = State.Scale;
				}
				_isMouse = true;
			}
			else if (Input.GetMouseButtonUp(0))
			{
				if (_firstHasTouched)
				{
					_mouseHasDown = false;
					_secHasTouched = false;
					_secBeganPos = Input.mousePosition;
					_mouseState = State.None;
					OnTouchEnd(2, _firstBeganPos, _secBeganPos);
				}
				else
				{
					_firstHasTouched = true;
				}
			}
		}
		else
		{
			if (Input.GetMouseButtonDown(0))
			{
				_mouseHasDown = true;
				_isMouse = true;
				OnTouchBegan(1, Input.mousePosition);
				_mouseState = State.Drag;
			}
			else if (Input.GetMouseButtonUp(0))
			{
				_mouseHasDown = true;
				_mouseState = State.None;
				OnTouchEnd(1, Input.mousePosition);
			}
		}

		if (!_mouseHasDown && !_altDown)
		{
			_multiState = false;
			_firstHasTouched = false;
		}
		if (_mouseState == State.Drag)
		{
			UpdatePosOrScale(_mouseState, Input.mousePosition);
		}
		else if (_mouseState == State.Scale)
		{
			UpdatePosOrScale(_mouseState, _firstBeganPos, Input.mousePosition);
		}
	}

	void UpdateTouch()
	{
		if (Input.touchCount == 1)
		{
			_isMouse = false;
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began)
			{
				OnTouchBegan(1, touch.position);
//				Debug.LogFormat("touch enter began! count = 1");
			}
			else if (touch.phase == TouchPhase.Moved)
			{
				UpdatePosOrScale(State.Drag, touch.position);
			}
			else if (touch.phase == TouchPhase.Ended)
			{
				OnTouchEnd(1, touch.position);
//				Debug.LogFormat("touch enter end! count = 1");
			}
//			Debug.LogFormat("touch go 1----{0}", touch.phase);
		}
		else if (Input.touchCount == 2)
		{
			Touch touch1 = Input.GetTouch(0);
			Touch touch2 = Input.GetTouch(1);

			if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
			{
				_multiState = true;
				OnTouchBegan(2, touch1.position, touch2.position);
//				Debug.LogFormat("touch enter began! count = 2");
			}
			if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
			{
				UpdatePosOrScale(State.Scale, touch1.position, touch2.position);
			}
			if (touch1.phase == TouchPhase.Ended || touch2.phase == TouchPhase.Ended)
			{
				_multiState = false;
				_lastScaleTime = Time.time;
				OnTouchEnd(2, touch1.position, touch2.position);
				if (touch1.phase != TouchPhase.Ended)
				{
					OnTouchBegan(1, touch1.position);
//					Debug.LogFormat("touch enter end1! count = 2");
				}
				else if (touch2.phase != TouchPhase.Ended)
				{
					OnTouchBegan(1, touch2.position);
//					Debug.LogFormat("touch enter end2! count = 2");
				}
			}

//			Debug.LogFormat("touch go 2----{0}, {1}", touch1.phase, touch2.phase);
		}
	}

	void UpdatePosOrScale(State state, Vector2 touch1, Vector2 touch2 = default(Vector2))
	{
		if (state == State.Drag)
		{
            Vector2 first = ScreenPointToLocalPointInRectangle(_firstBeganPos, (RectTransform)target.parent);
            Vector2 position = ScreenPointToLocalPointInRectangle(touch1);
            Vector2 delta = position - first;
            Vector2 anchorPos = _originAnchorPos + delta*target.localScale.x;
//			_firstBeganPos = position;

            target.anchoredPosition = ClampAnchorPosition(anchorPos);

			if ((_originAnchorPos - target.anchoredPosition).magnitude > 2)
			{
				_targetGroup.blocksRaycasts = false;
			}
		}
		else if (state == State.Scale)
		{
			Vector2 pos1 = touch1;
			Vector2 pos2 = touch2;

			float distance = (pos1 - pos2).magnitude;
			float scale = distance / _startDistance;
			_startDistance = distance;

			if ((target.localScale*scale).x >= _baseScale)
			{
				if (scale > 1 && maxScale > 0 && target.localScale.x*scale > maxScale)
				{
					if (target.localScale.x*scale < maxScale + maxScaleCushion)
					{
						scale = 1 + (scale-1)/2;
					}
					else
					{
						scale = 1;
					}
				}
				target.localScale *= scale;

				float targetScale = target.localScale.x;
				if (ui != null && targetScale < maxScale)
				{
					float reverse = 1 / targetScale;
					for (int i=0; i < ui.childCount; i++)
					{
						var child = ui.GetChild(i);
						child.localScale = new Vector3(reverse, reverse);
						
						float sign = targetScale >= 1 ? 1 : -1;
						child.localScale *= 1 + sign * Math.Abs(targetScale - 1)*uiScaleFactor;
					}
				}
				
				Vector2 pivotTrans = _pivotDistance*(scale-1);
				Vector2 anchorPos = target.anchoredPosition - pivotTrans;
				_pivotDistance *= scale;
				
				target.anchoredPosition = ClampAnchorPosition(anchorPos);

				if ((_originAnchorPos - target.anchoredPosition).magnitude > 2 || _originScale - target.localScale.x > 0.2f)
				{
					_targetGroup.blocksRaycasts = false;
				}
			}
		}
	}

	void OnTouchBegan(int touchCount, Vector2 touch1, Vector2 touch2 = default(Vector2))
	{
		if (touchCount == 1)
		{
			_firstBeganPos = touch1;
			_originAnchorPos = target.anchoredPosition;
            _touchBaganTime = Time.time;
			target.DOKill();
		}
		else if (touchCount == 2)
		{
			_originAnchorPos = target.anchoredPosition;
			_originScale = target.localScale.x;
			
			_firstBeganPos = touch1;
			_secBeganPos = touch2;


			Canvas canvas = target.GetComponentInParent<Canvas>();
			if (canvas == null)
			{
				throw new Exception("Can not found Canvas component in parent!");
			}

            _pivotDistance = ScreenPointToLocalPointInRectangle((touch2 + touch1)/2);
			_pivotDistance *= target.localScale.x;
			
			_startDistance = (touch2 - touch1).magnitude;
			target.DOKill();

			RectTransform parent = target.parent.GetComponent<RectTransform>();
			float widthMinScale = parent.rect.width / target.rect.width;
			float heightMinScale = parent.rect.height / target.rect.height;
			_baseScale = Mathf.Max(widthMinScale, heightMinScale);

//			Debugger.Log("start {0} {1}", _pivotDistance.x, _pivotDistance.y);
		}
	}

	void OnTouchEnd(int touchCount, Vector2 touch1,  Vector2 touch2 = default(Vector2))
	{
		if (touchCount == 1)
		{
			if (!_isTween && Time.time - _lastScaleTime > scaleToDrawDeltaTime)
			{
                float deltaTime = Time.time - _touchBaganTime;
                Vector2 speedVec = (touch1 - _firstBeganPos) / deltaTime;
				Vector2 vec = new Vector2(target.anchoredPosition.x, target.anchoredPosition.y);
                vec += speedVec * moveScale;

				target.DOAnchorPos(vec, tweenTime, true).SetEase(easeType).OnUpdate(()=>{
					target.anchoredPosition = ClampAnchorPosition(target.anchoredPosition);
				});
			}
		}
		else if (touchCount == 2)
		{
			float direct = (target.localScale.x - _originScale) > 0 ? 1 : -1;
			direct /= 20;
//			target.DOScale(new Vector3(target.localScale.x+direct, target.localScale.y+direct, target.localScale.z), 0.5f);
		}
		if (target.localScale.x > maxScale)
		{
			Vector2 pivotTrans = _pivotDistance*(1 - maxScale/target.localScale.x);
			Vector2 anchorPos = target.anchoredPosition + pivotTrans;
			target.DOScale(Vector2.one*maxScale, 0.5f);
			target.DOAnchorPos(anchorPos, 0.5f);
		}
		_targetGroup.blocksRaycasts = true;
	}

	Vector2 ClampAnchorPosition(Vector2 position)
	{
		Vector2 stretchDelta = target.anchorMax - target.anchorMin;
		if (stretchDelta.x > 0.01f || stretchDelta.y > 0.01f)
		{
			throw new Exception("Do not support stretch mode!");
			return Vector2.zero;
		}

		RectTransform parentTrans = target.parent.GetComponent<RectTransform>();
		if (parentTrans == null)
			return Vector2.zero;

		Rect parentRect = parentTrans.rect;
		Rect rect = target.rect;
		Vector2 parentAnchorPos = new Vector2(target.anchorMin.x * parentRect.width, target.anchorMin.y * parentRect.height);
		float minX, minY, maxX, maxY;

		minX = (parentRect.width - parentAnchorPos.x) - rect.xMax*target.localScale.x;
		minY = (parentRect.height - parentAnchorPos.y) - rect.yMax*target.localScale.y;
		maxX = -(parentRect.width - parentAnchorPos.x) - rect.xMin*target.localScale.x;
		maxY = -(parentRect.height - parentAnchorPos.y) - rect.yMin*target.localScale.y;

		Vector2 clampPos = position;
		clampPos.x = Mathf.Max(minX, clampPos.x);
		clampPos.y = Mathf.Max(minY, clampPos.y);
		clampPos.x = Mathf.Min(maxX, clampPos.x);
		clampPos.y = Mathf.Min(maxY, clampPos.y);

		clampPos.x = Mathf.Floor(clampPos.x);
		clampPos.y = Mathf.Floor(clampPos.y);

		return clampPos;
	}

    Vector2 ScreenPointToLocalPointInRectangle(Vector2 screenPos, RectTransform rect = null)
    {
        if (rect == null)
            rect = target;
        
        Vector2 retOut;
        
        Canvas canvas = rect.GetComponentInParent<Canvas>();
        if (canvas == null)
        {
            throw new Exception("Can not found Canvas component in parent!");
        }
        RectTransformUtility.ScreenPointToLocalPointInRectangle(target, screenPos, canvas.worldCamera, out retOut);
        
        return retOut;
    }
}
