using UnityEngine;
using System;
using System.Collections.Generic;

public class NativeCodeManager : MonoBehaviour {

	private Dictionary<string, Action<string[]>> _functions = new Dictionary<string, Action<string[]>>();

	private static NativeCodeManager _Instance;
	public static NativeCodeManager Instance
	{
		get
		{
			if(_Instance == null)
			{
				GameObject go = GameObject.Find("GameManagers");
				if(go == null) go = new GameObject("GameManagers");

				_Instance = go.GetComponent<NativeCodeManager>();
				if(_Instance == null) _Instance = go.AddComponent<NativeCodeManager>();
			}
			return _Instance;
		}
	}

	public void AddNativeFunctionCallback(string functionTag, Action<string[]> callback){
		_functions.Add(functionTag, callback);
	}

	void OnNativeMessage(string arg){
		string []func = arg.Split(new char[]{':'});
		if (func.Length > 1 && _functions.ContainsKey(func[0]))
		{
			var para = func[1].Split(new char[]{','});
			_functions[func[0]].Invoke(para);
		}
	}

//
//各平台相关函数
//

#if	UNITY_EDITOR || UNITY_IPHONE
	public void SetAppInfo(string appId, string appKey)
	{
	}

	public void InitCenter()
	{
		var g = GameObject.Find("GameManager");
		if (_functions.ContainsKey("OnInitCenter"))
			_functions["OnInitCenter"].Invoke(new string[]{});
	}

	public void LoginCenter()
	{
		if (_functions.ContainsKey("OnLogin"))
			_functions["OnLogin"].Invoke(new string[]{});
	}

	public void AppendQQGroup(string key)
	{
	}

	public string GetUserInfo()
	{
		return "";
	}

#elif UNITY_ANDROID
	public void SetAppInfo(string appId, string appKey)
	{
		Debugger.Log("NativeNodeManager .." + "SetAppInfo");
		AndroidJavaClass jc = new AndroidJavaClass("com.mb.common.BaseCenterManager");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("Instance");
		jo.Call("setAppInfo", new object[]{appId, appKey});
	}

	public void InitCenter()
	{
		Debugger.Log("NativeNodeManager .." + "InitCenter");
		AndroidJavaClass jc = new AndroidJavaClass("com.mb.common.BaseCenterManager");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("Instance");
		jo.Call("initCenter");
	}

	public void LoginCenter()
	{
		Debugger.Log("NativeNodeManager .." + "LoginCenter");
		AndroidJavaClass jc = new AndroidJavaClass("com.mb.common.BaseCenterManager");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("Instance");
		jo.Call("loginCenter");
	}

	public void AppendQQGroup(string key)
	{
		AndroidJavaClass jc = new AndroidJavaClass("com.mb.common.MiscUtils");
		jc.CallStatic<bool>("joinQQGroup", new object[]{key});
	}

	public string GetUserInfo()
	{
		Debugger.Log("NativeNodeManager .." + "GetUserInfo");
		AndroidJavaClass jc = new AndroidJavaClass("com.mb.common.BaseCenterManager");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("Instance");
		return jo.Call<string>("userInfo");
	}
#elif UNITY_IPHONE
	//todo
#endif
}
