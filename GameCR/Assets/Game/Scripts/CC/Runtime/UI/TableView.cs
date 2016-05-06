using UnityEngine;
using System.Collections.Generic;
using CC.UI;
using UnityEngine.UI;
using CC.Runtime;
using Games.Module.Wars;
using LuaInterface;
using System;
using System.Collections.Generic;
using System.Collections;

[AddComponentMenu("CC/UI/TableView", 36)]
[RequireComponent(typeof(RectTransform))]
public class TableView : BaseUI
{
	class LinePair
	{
		public int start;//开始行
		public int end;  //结束行，不包括这行
	}
	
	public enum CellArrange
	{
		Vertical,
		VerticalAndHorizontal,
		Horizontal
	}
	
	public GameObject itemPrefab;
	public RectTransform content;
	public CellArrange cellArrange = CellArrange.VerticalAndHorizontal;
	public bool resizeToFit = false;		//自动缩放适应大小
	public float cellVerticalGap = 0.0f;
	public float cellHorizontalGap = 0.0f;
	public float spacingX = 0.0f;
	public float spacingY = 0.0f;
	public bool isNotifyWhenRemove = false; //使用元素移除时通知调用
	public bool isMaxArrange = true; 		//使用最大化排列，只在元素超出边界的下一个才换行
	public bool isDynamicLineHeight = false;//使用动态行高
	
	private Dictionary<int, TableViewCell> _row = new Dictionary<int, TableViewCell> ();
	private LinePair visualLines = new LinePair ();
	private float _cellWidth = 0;
	private float _cellHeight = 0;
	private float _lastContentX = 0;
	private float _lastContentY = 0;
	private int _upline = 0;
	private int _downline = 0;
	private bool _hasLoad = false;
	private int _itemNum = 0;
	private int _eachLineNum = 0;
	private int _totalLine = 0;
	private LuaFunction _lineCallback = null;
	private LuaFunction _lineHeightCallback = null;
	
	private List<float> _dynamicLinePosYList = new List<float>();

	Texture2D d;
	
	protected override void Start ()
	{
		base.Start ();
	}
	
	void Update ()
	{
		if (_hasLoad) {
			UpdateVisualLine ();
			if (_upline != visualLines.start || _downline != visualLines.end) {
				RefreshLine ();
			}
			_lastContentX = content.anchoredPosition.x;
			_lastContentY = content.anchoredPosition.y;
		}
	}
	
	protected override void Awake ()
	{
		base.Awake ();
		
		if (content)
		{
			Vector2 pivot = new Vector2(0, 1);
			Vector2 anchor = new Vector2(0, 1);
			Vector2 size = content.rect.size;
			Vector2 deltaPivot = content.pivot - pivot;
			Vector3 deltaPosition = new Vector3(deltaPivot.x * size.x, deltaPivot.y * size.y);
			content.pivot = pivot;
			content.localPosition -= deltaPosition;
			
			Vector2 centerAnchor = (content.anchorMax + content.anchorMin)/2;
			Vector2 deltaAnchor = centerAnchor - anchor;
			deltaPosition = new Vector3(deltaAnchor.x * size.x, deltaAnchor.y * size.y);
			content.anchorMin = anchor;
			content.anchorMax = anchor;
			content.localPosition += deltaPosition;

			//StartCoroutine (Delay());
		}
	}

 	IEnumerator Delay()
	{
		yield return 0;

		var x = content.sizeDelta.x;
		Debug.Log ("wwww=======" + x + "++++++" + content.sizeDelta.y);
	}

	void LateUpdate()
	{
		float x = content.sizeDelta.x;
	}
	
	void OnValidate ()
	{
		//_hasLoad = false;
//		ReloadData();
	}

	public float cellHeight
	{
		get
		{
			return _cellHeight;
		}
	}
	
	public void ReloadData (int itemNum = -1)
	{
		if (!_hasLoad) {
			RectTransform itemTrans = itemPrefab.GetComponent<RectTransform> ();
			_cellHeight = itemTrans.rect.height + cellVerticalGap;
			_cellWidth = itemTrans.rect.width + cellHorizontalGap;
			
			if (cellArrange == CellArrange.Vertical || cellArrange == CellArrange.Horizontal)
			{
				_eachLineNum = 1;
			}
			else
			{
				if (isMaxArrange)
					_eachLineNum =  Mathf.CeilToInt(((RectTransform)transform).rect.width / _cellWidth);
				else
					_eachLineNum =  Mathf.FloorToInt(((RectTransform)transform).rect.width / _cellWidth);
			}
		}
		if (itemNum >= 0) {
			_totalLine =  Mathf.CeilToInt((float)itemNum / _eachLineNum);
			_itemNum = itemNum;
		}
		
		for (int i=_upline; i<_downline; i++)
			RemoveRow (i);
		
		if (isDynamicLineHeight)
		{
			_dynamicLinePosYList.Clear();
			float accum = 0;
			_dynamicLinePosYList.Add(0);
			for (int i=0; i<_itemNum; i++)
			{
				float height = InvokeLineHeight(i);
				accum += height;
				_dynamicLinePosYList.Add(accum);
			}
		}

		visualLines.start = visualLines.end = 0;

		UpdateVisualLine();

		_upline = _downline = visualLines.start;

		RefreshLine ();

		if (cellArrange == CellArrange.Horizontal)
			content.anchoredPosition = new Vector2 (_lastContentX, content.anchoredPosition.y);
		else
			content.anchoredPosition = new Vector2 (content.anchoredPosition.x, _lastContentY);

		if (isDynamicLineHeight)
		{
			content.sizeDelta = new Vector2 (content.sizeDelta.x, _dynamicLinePosYList[_dynamicLinePosYList.Count-1]);
		}
		else
		{
			if (cellArrange == CellArrange.Horizontal)
			{
				content.sizeDelta = new Vector2 (_cellWidth * _totalLine, content.sizeDelta.y);
			}
			else
			{
				content.sizeDelta = new Vector2 (content.sizeDelta.x, _cellHeight * _totalLine);
			}
		}
		
		_hasLoad = true;
	}
	
	public void Setup (LuaFunction lineCallback, int itemNum, bool loadData = false)
	{
		_lineCallback = lineCallback;
		_itemNum = itemNum;
		if (loadData) {
			ReloadData ();
		}
	}
	
	public void SetLineHeightFunc(LuaFunction lineHeightCallback)
	{
		_lineHeightCallback = lineHeightCallback;
	}
	
	void RefreshLine ()
	{
		int visualLineStartDelta = visualLines.start - _upline;
		int visualLineEndDelta = visualLines.end - _downline;
		
		if (visualLineStartDelta < 0) {
			for (int i=1; i<=-visualLineStartDelta; i++) {
				AddRow (_upline - i);
			}
		} else if (visualLineStartDelta > 0) {
			for (int i=visualLineStartDelta-1; i>=0; i--) {
				RemoveRow (_upline + i);
			}
		}
		
		if (visualLineEndDelta > 0) {
			for (int i=0; i<visualLineEndDelta; i++) {
				AddRow (_downline + i);
			}
		} else if (visualLineEndDelta < 0) {
			for (int i=-visualLineEndDelta; i>=0; i--) {
				RemoveRow (_downline - i);
			}
		}
		
		_upline = visualLines.start;
		_downline = visualLines.end;
	}
	
	void UpdateVisualLine ()
	{
		float portTop, portBottom;
		if (cellArrange == CellArrange.Horizontal)
		{
			portTop = Mathf.Min (content.anchoredPosition.x, 0);
			portBottom = portTop - ((RectTransform)transform).rect.width;
		}
		else
		{
			portTop = Mathf.Max (content.anchoredPosition.y, 0);
			portBottom = portTop + ((RectTransform)transform).rect.height;
		}
		
		if (isDynamicLineHeight)
		{
			int lineStart = -1;
			int lineEnd = -1;
			for (int i=1; i<_dynamicLinePosYList.Count; i++)
			{
				float posY = _dynamicLinePosYList[i];
				if (lineStart < 0 && portTop < posY)
				{
					lineStart = i - 1;
				}
				if (lineEnd < 0)
				{
					if (portBottom < posY || i >= _dynamicLinePosYList.Count - 1)
						lineEnd = i;
				}
				if (lineStart >= 0 && lineEnd >= 0)
				{
					break;
				}
			}
			if (lineStart >= 0)
				visualLines.start = lineStart;
			if (lineEnd >= 0)
				visualLines.end = lineEnd;
		}
		else
		{
			if (cellArrange == CellArrange.Horizontal)
			{
				visualLines.start = Mathf.Max (Mathf.FloorToInt (Math.Abs(portTop) / _cellWidth), 0);
				visualLines.end = Mathf.Min (Mathf.CeilToInt (Math.Abs(portBottom) / _cellWidth), _totalLine);
			}
			else
			{
				visualLines.start = Mathf.Max (Mathf.FloorToInt (portTop / _cellHeight), 0);
				visualLines.end = Mathf.Min (Mathf.CeilToInt (portBottom / _cellHeight), _totalLine);
			}
		}
	}
	
	TableViewCell LineUpdate (int line)
	{
		GameObject cell = new GameObject ();
		cell.AddComponent<RectTransform> ();
		cell.AddComponent<TableViewCell> ();
		cell.name = "line" + line.ToString ();
		
		RectTransform cellTrans = cell.GetComponent<RectTransform> ();
		cellTrans.anchorMin = new Vector2 (0, 1);
		cellTrans.anchorMax = new Vector2 (0, 1);
		cellTrans.pivot = new Vector2 (0, 1);
		
		RectTransform prefabTrans = itemPrefab.GetComponent<RectTransform> ();
		
		float width, height;
		if (cellArrange == CellArrange.Horizontal)
		{
			width = prefabTrans.sizeDelta.x;
			height = content.rect.height;
			if (isDynamicLineHeight)
			{
				width = _dynamicLinePosYList[line+1] - _dynamicLinePosYList[line];
			}
		}
		else
		{
			width = cellArrange == CellArrange.VerticalAndHorizontal ? 1 : content.rect.width;
			height = prefabTrans.sizeDelta.y;
			if (isDynamicLineHeight)
			{
				height = _dynamicLinePosYList[line+1] - _dynamicLinePosYList[line];
			}
		}
		cellTrans.sizeDelta = new Vector2 (width, height);
		
		List<GameObject> items = new List<GameObject> ();
		for (int i=0; i<_eachLineNum; i++) {
			if (line * _eachLineNum + i >= _itemNum)
				break;
			//TODO 对象池
			GameObject item = GameObject.Instantiate (itemPrefab);
			//item.transform.parent = cell.transform;
			item.transform.SetParent(cell.transform);
			
			RectTransform itemTrans = item.GetComponent<RectTransform> ();
			if (cellArrange == CellArrange.Horizontal)
			{
				itemTrans.anchorMin = new Vector2 (0.5f, 1);
				itemTrans.anchorMax = new Vector2 (0.5f, 1);
				itemTrans.pivot = new Vector2 (0.5f, 1);
			}
			else
			{
				itemTrans.anchorMin = new Vector2 (0, 0.5f);
				itemTrans.anchorMax = new Vector2 (0, 0.5f);
				itemTrans.pivot = new Vector2 (0, 0.5f);
			}

			itemTrans.anchoredPosition = new Vector2 (i * (_cellWidth), 0);
			items.Add (item);
			
			if (cellArrange == CellArrange.Vertical && resizeToFit)
			{
				itemTrans.sizeDelta = new Vector2(content.rect.width, itemTrans.sizeDelta.y);
			}
		}
		
		InvokeLineCallback(line, items.Count, items);
		return cell.GetComponent<TableViewCell> ();
	}
	
	//每行更新时回调，
	//如果增加新行，传入该行的每个prefab的生成的gameObject的一个table
	//如果删除行，传入字符串为null的一个table
	void InvokeLineCallback(int line, int count, List<GameObject> objs)
	{
		if (_lineCallback != null) {
			LuaTable table = LuaScriptMgr.Instance.lua.NewTable ();
			if (table != null) {
				int nums = count;
				int idx = 0;
				for (int i=0; i<nums; i++) {
					idx = line * _eachLineNum + i + 1;
					if (idx > _itemNum)
						break;
					
					if (objs != null)
						table.Set ((idx).ToString (), objs [i]);
					else
						table.Set ((idx).ToString (), "null");
				}
			}
			_lineCallback.Call (table, line, this);
			table.Dispose ();
		}
	}
	
	float InvokeLineHeight(int line)
	{
		if (_lineHeightCallback != null)
		{
			object[] ret = _lineHeightCallback.Call(line);
			if (ret.Length > 0)
				return Convert.ToSingle(ret[0]);
		}
		return 0;
	}
	
	void AddRow (int lineNum)
	{
		if (_row.ContainsKey (lineNum)) {
			_row [lineNum].transform.parent = null;
			_row.Remove (lineNum);
		}
		
		TableViewCell cell = LineUpdate (lineNum);
		Vector3 scale = cell.rectTransform.localScale;
		//cell.rectTransform.parent = content;
		cell.rectTransform.SetParent(content);
		cell.rectTransform.localScale = scale;
		
		float y = 0;
		if (isDynamicLineHeight)
		{
			y = -_dynamicLinePosYList[lineNum];
		}
		else
		{
			if (cellArrange == CellArrange.Horizontal)
				y = -lineNum * _cellWidth;
			else
				y = -lineNum * _cellHeight;
		}
		if (cellArrange == CellArrange.Horizontal)
			cell.rectTransform.anchoredPosition = new Vector2 (-y + spacingX, 0);
		else
			cell.rectTransform.anchoredPosition = new Vector2 (spacingX, y);
		
		_row.Add (lineNum, cell);
	}
	
	void RemoveRow (int lineNum)
	{
		if (!_row.ContainsKey (lineNum)) {
			return;
		}
		
		if (isNotifyWhenRemove)
			InvokeLineCallback(lineNum, _eachLineNum, null);
		
		TableViewCell cell = _row [lineNum];
		_row.Remove (lineNum);
		
		//TODO 对象池
		//cell.rectTransform.parent = null;
		cell.rectTransform.SetParent(null);
		GameObject.Destroy (cell.gameObject);
	}
}
