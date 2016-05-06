package com.mbsgcr.mi;

import com.mb.common.BaseCenterManager;
import com.xiaomi.gamecenter.sdk.MiCommplatform;
import com.xiaomi.gamecenter.sdk.MiErrorCode;
import com.xiaomi.gamecenter.sdk.OnLoginProcessListener;
import com.xiaomi.gamecenter.sdk.entry.MiAccountInfo;
import com.xiaomi.gamecenter.sdk.entry.MiAppInfo;

import android.util.Log;

public class CenterManager extends BaseCenterManager implements OnLoginProcessListener  {
	private MiAccountInfo _userInfo;
	
	@Override
	public void initCenter() {
		MiAppInfo appInfo = new MiAppInfo();
		appInfo.setAppId(_appID);
		appInfo.setAppKey(_appKey);
		MiCommplatform.Init(MainActivity.Current, appInfo);
		super.OnInitCenter(true);
		
		Log.e("Unity", "Init.......Center");
	}
	
	@Override
	public void loginCenter() {
		Log.e("Unity", "Login.......Center");
		MiCommplatform.getInstance().miLogin( MainActivity.Current, this );
	}
	
	@Override
	public String userInfo() {
		String str = "";
		str += _userInfo.getUid() + ",";
		str += _userInfo.getSessionId() + ",";
		str += _userInfo.getNikename();
		Log.e("Unity", "Login.......Center....." + str);
		
		return str;
	}
	
	@Override
	public void finishLoginProcess(int arg0, MiAccountInfo arg1) {
		if ( MiErrorCode.MI_XIAOMI_PAYMENT_SUCCESS == arg0 )
		{
			_userInfo = arg1;
			final CenterManager _this = this;
			MainActivity.Current.runOnUiThread(new Runnable() {
				
				@Override
				public void run() {
					_this.OnLogin(true);
				}
			});
		}
		else if ( MiErrorCode.MI_XIAOMI_PAYMENT_ERROR_ACTION_EXECUTED == arg0 )
		{
		}
		else
		{
			final CenterManager _this = this;
			MainActivity.Current.runOnUiThread(new Runnable() {
				
				@Override
				public void run() {
					_this.OnLogin(false);
				}
			});
		}
	}
}
