package com.mb.common;

import android.util.Log;

public class BaseCenterManager {
	static public BaseCenterManager Instance = null;
	
	protected String _appID;
	protected String _appKey;
	
	public void setAppInfo(String appId, String appKey){
		_appID = appId;
		_appKey = appKey;
	}
	
	public void initCenter() {
	}

	public void loginCenter() {
	}
	
	//uid, token, nickname
	public String userInfo() {
		return "";
	}
	
	protected void OnInitCenter(boolean isSuccess) {
		Log.d("Unity", "BaseCenterManager OnInitCenter");
		MiscUtils.CallUnityFunc("OnInitCenter", isSuccess);
	}
	
	protected void OnLogin(boolean isSuccess) {
		Log.d("Unity", "BaseCenterManager OnLogin");
		MiscUtils.CallUnityFunc("OnLogin", isSuccess);
	}
	
	protected void OnLogout(boolean isSuccess){
		Log.d("Unity", "BaseCenterManager OnLogout");
		MiscUtils.CallUnityFunc("OnLogout", isSuccess);
	}
	
	protected void OnSwitchAccount(boolean isSuccess) {
		Log.d("Unity", "BaseCenterManager OnSwitchAccount");
		MiscUtils.CallUnityFunc("OnSwitchAccount", isSuccess);
	}
}
