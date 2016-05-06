using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinchZoom : MonoBehaviour {

	public RectTransform rect;
	
	public Vector2 size;
	public float scale = 1f;
	public float initScaleMutiple = 1F;
	public float MaxScaleMutiple = 4F;
	public float minScale = 1F;
	public float maxScale = 4F;
	private float _screenWidth;
	private float _screenHeight;
	
	void Awake () {
		Input.multiTouchEnabled = true;
        CanvasScaler canvasScaler = GameObject.Find("Canvas").GetComponent<CanvasScaler>();
        if(canvasScaler.uiScaleMode == CanvasScaler.ScaleMode.ConstantPixelSize)
        {
            size = rect.sizeDelta;  // if canvas scale constant pixel size, use this
        }
        else if(canvasScaler.uiScaleMode == CanvasScaler.ScaleMode.ScaleWithScreenSize)
        {
            size = new Vector2(Screen.width * (rect.sizeDelta.x / 1920), Screen.height * (rect.sizeDelta.y / 1280));  // if canvas scale with screen size, use this
        }
        
		Init ();
	}

	void UpdateScaleLimit()
	{
		float r1 = (float)Screen.width / (float)Screen.height;
		float r2 = size.x / size.y;
		
		_screenWidth = Screen.width;
		_screenHeight = Screen.height;
        Debug.Log("screenWidth=" + _screenWidth + ", screenHeight=" + _screenHeight);
        Debug.Log("size.x=" + size.x + ", size.y=" + size.y); 

		float minWidth = Screen.width;
		float minHeight = Screen.height;
		if(r2 < r1)
		{
			minHeight = minWidth / size.x * size.y;
		}
        else if(r2 > r1)
		{
			minWidth = minHeight / size.y * size.x;
		}
		
		if (r1 >= 1) {
			minScale = minWidth / size.x;
		} else {
			minScale = minHeight / size.y;
		}
		
		if (minScale > maxScale) {
			maxScale = minScale;
		}
	}

	void Init()
	{
		UpdateScaleLimit ();
		maxScale = minScale * MaxScaleMutiple;
		scale = minScale * initScaleMutiple;
		rect.localScale= Vector3.one * scale;
		Vector2 position = rect.anchoredPosition;
		CheckBound(position);
	}

	void OnScreenResize()
	{
		UpdateScaleLimit ();
		scale = Mathf.Max (scale, minScale);
		scale = Mathf.Min (scale, maxScale);
		rect.localScale = Vector3.one * scale;
		Vector2 position = rect.anchoredPosition;
		CheckBound(position);
	}
	
	bool drag = false;
	Vector3 oldPos;
	public float moveSpeed = 1f;
	public float scaleSpeed = 0.5f;
	
	void Update () 
	{
		if(_screenWidth != Screen.width || _screenHeight != Screen.height)
		{
			OnScreenResize();
		}

		UpdateFingerTouch();
		UpdateMouseMove();
		UpdateScrollScale();
	}

	// touch scale & move
	void UpdateFingerTouch() {
		// If there are two touches on the device, zoom map
		if (Input.touchCount == 2)
		{
			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);
			
			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
			
			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
			
			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = touchDeltaMag - prevTouchDeltaMag;   

			// scale map
			float old_scale = scale;
			scale += deltaMagnitudeDiff * 0.05f * scaleSpeed;
			scale = Mathf.Max(scale, minScale);
			scale = Mathf.Min(scale, maxScale);
			rect.localScale = Vector3.one * scale;

			// move map position to fit the sceen center zoom
			Vector2 position = rect.anchoredPosition;
			position += new Vector2((position.x / old_scale * scale - position.x), 
			                        (position.y / old_scale * scale - position.y));
			CheckBound(position);
		} 

		// if there are one touch on the device, move map position
		else if(Input.touchCount == 1) {
			if(Input.touches[0].phase == TouchPhase.Began) {
				oldPos = Input.GetTouch(0).position;
			} else if(Input.touches[0].phase == TouchPhase.Moved) {
				Vector3 pos = Input.GetTouch(0).position;
				Debug.Log("Touch position x:" + pos.x + " y:" + pos.y);
				Vector3 offest = pos - oldPos;
				Vector2 position = rect.anchoredPosition;
				position += new Vector2(offest.x, offest.y);
				CheckBound(position);
				oldPos= pos;
			}
		}
	}

	// scroll wheel scale zoom for unity editor test
	void UpdateScrollScale () 
	{		
		if (Input.GetAxis("Mouse ScrollWheel")!= 0)
		{	
			float old_scale = scale;
			scale += Input.GetAxis("Mouse ScrollWheel") * scaleSpeed;
			scale = Mathf.Max(scale, minScale);
			scale = Mathf.Min(scale, maxScale);
			rect.localScale = Vector3.one * scale;

			Vector2 position = rect.anchoredPosition;
			position += new Vector2((position.x / old_scale * scale - position.x), 
			                        (position.y / old_scale * scale - position.y));
			CheckBound(position);
		}
	}

	// mouse move for unity editor test
	void UpdateMouseMove() 
	{
		if (Input.GetMouseButtonDown (0))
		{
			drag = true;
			oldPos = Input.mousePosition;
		}
		
		if (Input.GetMouseButtonUp (0))
		{
			drag = false;
		}
		
		if(drag)
		{
			Vector3 pos = Input.mousePosition;
			Vector3 offest = pos - oldPos;
			Vector2 position = rect.anchoredPosition;
			position += new Vector2(offest.x, offest.y);
			CheckBound(position);
			oldPos= pos;		
		}
	}
	
	void CheckBound(Vector2 position)
	{
		float minX = -(size.x * scale - Screen.width ) * 0.5f ;
		float maxX = (size.x  * scale - Screen.width) * 0.5f;
		
		float minY = -(size.y * scale - Screen.height) * 0.5f ;
		float maxY = (size.y * scale - Screen.height) * 0.5f;

		Debug.Log("minX=" + minX + ", maxX=" + maxX + ", minY=" + minY + ", maxY=" + maxY);
		
		if(position.x < minX)
		{
			position.x = minX;
		}
		
		if(position.x > maxX)
		{
			position.x = maxX;
		}
		
		if(position.y < minY)
		{
			position.y = minY;
		}
		
		if(position.y > maxY)
		{
			position.y = maxY;
		}

		rect.anchoredPosition = position;
	}
}
