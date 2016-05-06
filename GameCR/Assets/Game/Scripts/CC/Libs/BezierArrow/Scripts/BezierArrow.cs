using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BezierArrow : MonoBehaviour
{
	public enum StateType
	{
		None,
		Set,
		Forward,
		Backward,
	}

	public StateType stateType = StateType.Set;
	public BezierSegment bezierSegment = new BezierSegment();

	#region bezier point
	/** 贝塞尔--开始点--锚点 */
	public Transform beginAnchor;
	/** 贝塞尔--开始点--控制点 */
	public Transform beginControl;

	/** 贝塞尔--结束点--锚点 */
	public Transform endAnchor;
	/** 贝塞尔--结束点--控制点 */
	public Transform endControl;

	/** 是否计算控制点 */
	public bool 	calculateControl = false;
	/** "开始控制点" 相对 "开始锚点" 的偏移方向 */
	public Vector3 	beginControlDirection = new Vector3(-0.1f, 0.3f, 0.4f);
	/** ”结束控制点“ 相对 “结束锚点” 的偏移方向 */
	public Vector3 	endControlDirection = new Vector3(0.1f, 0.1f, 0.3f);

	private Vector3 sourceBeginControlDirection;
	private Vector3 sourceEndControlDirection;
	#endregion


	#region display
	public GameObject display;

	/** 显示对象--箭头 */
	public Transform 	elementArrow;
	/** 显示对象--点预设 */
	public GameObject 	pointPrefab;
	/** 显示对象--点容器 */
	public Transform 	container;
	/** 点--大小 */
	public float size = 1;
	/** 点--排列间距 */
	public float gap = 1;

	/** 点--传递速度 */
	public float speed = 1;
	/** 点--传递速度 */
	public float speedForwardMin = 0.1f;
	public float speedForwardMax = 0.5f;
	public float speedForward = 0.5f;
	private float speedForwardTime = 0f;
	public Vector3 forwardDriftBegin;
	public Vector3 forwardDriftEnd;
	public float forwardDriftSinXMin = 0;
	public float forwardDriftSinXMax = 30;
	public float forwardDriftSinX = 1;
	private float forwardDriftXVal = 1;

	public float forwardDriftSinYMin = 0;
	public float forwardDriftSinYMax = 30;
	public float forwardDriftSinY = 1;
	private float forwardDriftYVal = 1;

	private float forwardTime = 0;
	/** 点--传递速度 */
	public float speedBackWardMin = -1;
	public float speedBackWardMax = -2;
	public float speedBackWard = -1;
	private float speedBackWardTime = 0;
	/** 时间偏移 */
	private float _offset;

	public float alpha = 1f;

	/** 点--没激活的列表 */
	public List<Transform> boxUnactionList = new List<Transform>();
	/** 点--已激活的列表 */
	public List<Transform> boxActionList = new List<Transform>();
	#endregion



	#region transition
	/** 首尾点--过度数量 */
	public int transitionCount = 2;
	/** 首尾点--过度是否缩放 */
	public bool transitionScale = true;
	/** 中间点--是否重新设置 */
	public bool resetCenterTransition = true;
	#endregion

	public Vector3 worldUp = Vector3.up;

	private int pointCount;
	private float u = 0.001f;
	private float b = 0.001f;
	private float e = 0.001f;


	void Start () 
	{
		sourceBeginControlDirection = beginControlDirection;
		sourceEndControlDirection = endControlDirection;
	}

	void Update ()
	{
		switch(stateType)
		{
		case StateType.Set:
			Set ();
			break;
		case StateType.Forward:
			DoForward ();
			break;
		case StateType.Backward:
			DoBackward ();
			break;
		}
	}

	void Set () 
	{
		if(calculateControl)
		{

//			forwardDriftXVal +=  Mathf.Lerp (forwardDriftSinXMin, forwardDriftSinXMax, forwardTime * forwardDriftSinX);
//			forwardDriftYVal =  Mathf.Lerp (forwardDriftSinYMin, forwardDriftSinYMax, forwardTime * forwardDriftSinY);
//			float sin =  Mathf.Sin (forwardDriftXVal) * forwardDriftYVal;


			Vector3 direction = endAnchor.position - beginAnchor.position;
			direction.Normalize();
			float distance = Vector3.Distance ( endAnchor.position, beginAnchor.position);
			beginControl.position = beginAnchor.position;
			beginControl.LookAt (endAnchor, worldUp);
			Vector3 d = new Vector3 (beginControlDirection.x, beginControlDirection.y, beginControlDirection.z);
//			d += forwardDriftBegin * sin;
			d.x *= direction.x;
			beginControl.position =  beginControl.TransformPoint (d * distance);

			endControl.position = endAnchor.position;
			endControl.LookAt (beginAnchor, worldUp);
			d = new Vector3 (endControlDirection.x, endControlDirection.y, endControlDirection.z);
//			d += forwardDriftEnd * sin;
			d.x *=- direction.x;
			endControl.position =  endControl.TransformPoint (d * distance);
		}


//		forwardTime += Time.deltaTime;

		bezierSegment.begin.anchorPoint 	= beginAnchor.position;
		bezierSegment.begin.controlPoint 	= beginControl.position;

		bezierSegment.end.anchorPoint 		= endAnchor.position;
		bezierSegment.end.controlPoint 		= endControl.position;




		int count =  Mathf.FloorToInt( bezierSegment.LineDistance / (size + gap ) );

		this.pointCount = count;

		u = 1f / count;
		b = u * transitionCount;
		e = 1 - u;



		Transform item = null;
		for(int i = 0; i < count; i ++)
		{
			if (i < boxActionList.Count) 
			{
				item = boxActionList[i];
			}
			else if(boxUnactionList.Count > 0)
			{
				item = boxUnactionList[0];
				boxUnactionList.RemoveAt (0);
				item.gameObject.SetActive (true);
				boxActionList.Add (item);
			}
			else
			{
				item = GameObject.Instantiate (pointPrefab).transform;
				item.SetParent (container);
				item.gameObject.SetActive (true);
				boxActionList.Add (item);
			}


			SetItem (item, i, count, _offset, b, e);
		}

		_offset += Time.deltaTime * speed;

		for(int i = boxActionList.Count - 1; i >= count; i -- )
		{
			item = boxActionList[i];
			item.gameObject.SetActive (false);

			Material m = item.GetComponentInChildren<MeshRenderer> ().material;
			m.color = new Color (m.color.r, m.color.g, m.color.b, alpha);
			if(transitionScale) item.localScale = Vector3.one;
			boxActionList.RemoveAt (i);
			boxUnactionList.Add (item);
		}

		elementArrow.position = endAnchor.position;
		if (count > 1) 
		{
			Vector3 v = bezierSegment.GetPoint (0.99f);
			v = elementArrow.position - v;
			elementArrow.rotation = Quaternion.LookRotation (v, worldUp);
		}
		else 
		{
			Vector3 v  = elementArrow.position - beginAnchor.position;
			elementArrow.rotation = Quaternion.LookRotation (v, worldUp);
		}


		elementArrow.gameObject.SetActive (true);
	}


	void DoForward()
	{

		if(calculateControl)
		{
			forwardDriftXVal +=  Mathf.Lerp (forwardDriftSinXMin, forwardDriftSinXMax, forwardTime * forwardDriftSinX);
			forwardDriftYVal =  Mathf.Lerp (forwardDriftSinYMin, forwardDriftSinYMax, forwardTime * forwardDriftSinY);
			float sin =  Mathf.Sin (forwardDriftXVal) * forwardDriftYVal;

			Vector3 direction = endAnchor.position - beginAnchor.position;
			direction.Normalize();
			float distance = Vector3.Distance ( endAnchor.position, beginAnchor.position);
			beginControl.position = beginAnchor.position;
			beginControl.LookAt (endAnchor, worldUp);
			Vector3 d = new Vector3 (beginControlDirection.x, beginControlDirection.y, beginControlDirection.z);
			d += forwardDriftBegin * sin;
			d.x *= direction.x;
			beginControl.position =  beginControl.TransformPoint (d * distance);

			endControl.position = endAnchor.position;
			endControl.LookAt (beginAnchor, worldUp);
			d = new Vector3 (endControlDirection.x, endControlDirection.y, endControlDirection.z);
			d += forwardDriftEnd * sin;
			d.x *=- direction.x;
			endControl.position =  endControl.TransformPoint (d * distance);



			bezierSegment.begin.controlPoint 	= beginControl.position;
			bezierSegment.end.controlPoint 		= endControl.position;
		}



		forwardTime += Time.deltaTime;



		int minIndex = pointCount - boxActionList.Count;

		Transform item = null;
		for(int index = boxActionList.Count - 1; index >= 0; index --)
		{
			item = boxActionList[index];
			int i = index + minIndex;
			SetItem (item, i, pointCount, _offset, b, e);
			float t = 1f * i / pointCount + _offset;
			if (t > 1) 
			{
				boxActionList.RemoveAt (index);
				boxUnactionList.Add (item);
				item.gameObject.SetActive (false);
			}
		}

		speedForwardTime += Time.deltaTime * speedForward;
		_offset += Mathf.Lerp (speedForwardMin, speedForwardMax, speedForwardTime);

		if (boxActionList.Count == 0)
		{
			Hide ();
		}

	}

	void DoBackward()
	{
		Transform item = null;
		for(int index = boxActionList.Count - 1; index >= 0; index --)
		{
			item = boxActionList[index];
			int i = index;
			SetItem (item, i, pointCount, _offset, b, e);
			float t = 1f * i / pointCount + _offset;

			if (t < 0) 
			{
				boxActionList.RemoveAt (index);
				boxUnactionList.Add (item);
				item.gameObject.SetActive (false);
			}
		}


		speedBackWardTime += Time.deltaTime * speedBackWard;
		_offset += Mathf.Lerp (speedBackWardMax, speedBackWardMax, speedBackWardTime);


		if (boxActionList.Count == 0)
		{
			Hide ();
		}

	}


	public void SetItem(Transform item, int i, int count, float _offset, float b, float e)
	{
		item.position = bezierSegment.GetPoint (GetT (i, count, _offset));

		float t = GetT (i, count, _offset);
		if (t < b) 
		{
			item.LookAt (bezierSegment.GetPoint (GetT (i + 1, count, _offset)), worldUp);
		}
		else 
		{
			Vector3 targetPoint = bezierSegment.GetPoint (GetT (i - 1, count, _offset));
			targetPoint = item.position + (item.position - targetPoint);
			item.LookAt (targetPoint, worldUp);
		}

		if (t < b) 
		{
			Material m = item.GetComponentInChildren<MeshRenderer> ().material;
			m.color = new Color (m.color.r, m.color.g, m.color.b, t / b * alpha);

			if (transitionScale)
				item.localScale = new Vector3 (1, 1,  t / b);
		} 
		else if (t > e) 
		{
			Material m = item.GetComponentInChildren<MeshRenderer> ().material;
			m.color = new Color (m.color.r, m.color.g, m.color.b, 1f - (t - e) / b * alpha);
			if (transitionScale)
				item.localScale = new Vector3 (1, 1, 1f - (t - e) / b);
		} 
		else if(resetCenterTransition)
		{
			Material m = item.GetComponentInChildren<MeshRenderer> ().material;
			m.color = new Color (m.color.r, m.color.g, m.color.b, alpha);
			if (transitionScale)
				item.localScale = new Vector3 (1, 1, 1);
		}
	}


	public float GetT(int i, int count, float offset = 0)
	{
		float t = 1f * i / count;
		t += _offset;
		if (t == Mathf.FloorToInt (t) && t != 0) 
		{
			t = 1;
		}
		else 
		{
			t = t - Mathf.FloorToInt (t);
		}

		return t;
	}

	public Vector3 GetPoint(int i, int count, float offset = 0)
	{
		return  bezierSegment.GetPoint (GetT(i, count, offset));
	}


	public void Hide()
	{
		for(int i = boxActionList.Count - 1; i >= 0; i -- )
		{
			Transform item = boxActionList[i];
			item.gameObject.SetActive (false);

			Material m = item.GetComponentInChildren<MeshRenderer> ().material;
			m.color = new Color (m.color.r, m.color.g, m.color.b, 1);
			if(transitionScale) item.localScale = Vector3.one;
			boxActionList.RemoveAt (i);
		}


		elementArrow.gameObject.SetActive (false);

		stateType = StateType.None;
		_offset = 0;

		pointCount = 0;

		Visiable = false;
	}

	public void Show()
	{
		elementArrow.gameObject.SetActive (true);
		stateType = StateType.Set;

		beginControlDirection = sourceBeginControlDirection;
		endControlDirection = sourceEndControlDirection;

		_offset = 0;

		Visiable = true;
	}


	public void Forward()
	{
		stateType = StateType.Forward;
		_offset = _offset - Mathf.FloorToInt(_offset / u) * u;
		speedForward = 0;
		speedForwardTime = 0;
		forwardTime = 0;
	}



	public void Backward()
	{
		stateType = StateType.Backward;
		_offset = _offset - Mathf.FloorToInt(_offset / u) * u;
		speedBackWard = 0;
		speedBackWardTime = 0;
	}

	public bool Visiable
	{
		set 
		{
			if (value == false) 
			{
				for (int i = boxActionList.Count - 1; i >= 0; i--) {
					Transform item = boxActionList [i];
					item.gameObject.SetActive (false);

					Material m = item.GetComponentInChildren<MeshRenderer> ().material;
					m.color = new Color (m.color.r, m.color.g, m.color.b, 1);
					if (transitionScale)
						item.localScale = Vector3.one;
					boxActionList.RemoveAt (i);
				}

				pointCount = 0;
			}

			display.SetActive (value);
		}

		get
		{
			return display.activeSelf;
		}
	}


	private bool _VisiableArrow = true;
	public bool VisiableArrow
	{
		set 
		{
			_VisiableArrow = value;
			elementArrow.localScale = value ? Vector3.one : Vector3.zero;
		}

		get
		{
			return _VisiableArrow;
		}
	}

	public bool useing = false;


	public void SetTexture(Texture texture)
	{
		MeshRenderer[] mrs = elementArrow.GetComponentsInChildren<MeshRenderer> ();
		for(int i = 0; i < mrs.Length; i ++)
		{
			mrs [i].material.mainTexture = texture;
		}

		mrs = pointPrefab.GetComponentsInChildren<MeshRenderer> ();
		for(int i = 0; i < mrs.Length; i ++)
		{
			mrs [i].material.mainTexture = texture;
		}

		Transform item;
		Material m;
		for (int i = 0; i < boxActionList.Count; i++) 
		{
			item = boxActionList [i];
			m = item.GetComponentInChildren<MeshRenderer> ().material;
			m.mainTexture = texture;
		}

		for (int i = 0; i < boxUnactionList.Count; i++) 
		{
			item = boxUnactionList [i];
			m = item.GetComponentInChildren<MeshRenderer> ().material;
			m.mainTexture = texture;
		}
	}

}
