using UnityEngine;
using System.Collections;

public class MaskPanel : MonoBehaviour 
{
	static MaskPanel _Instance;
	private static MaskPanel Instance
	{
		get
		{
			if(_Instance == null)
			{
				GameObject go = GameObject.Find("MaskPanel");
				_Instance = go.GetComponent<MaskPanel>();
			}
			return _Instance;
		}
	}

	
	public static bool isDestroy = false;
	public static void Show()
	{
		if(!isDestroy) Instance.gameObject.SetActive(true);
	}
	

	public static void Hide()
	{
		if(!isDestroy) Instance.gameObject.SetActive(false);
	}


	[HideInInspector]
	public RectTransform rectTransform;
	void Awake () 
	{
		isDestroy = false;
		_Instance = this;
		rectTransform = GetComponent<RectTransform>();
		gameObject.SetActive(false);
	}

	void OnEnable()
	{
		rectTransform.SetAsFirstSibling();
	}

	void OnDestroy()
	{
		isDestroy = true;
		_Instance = null;
	}


}
