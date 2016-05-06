package com.mbgame.sdk.m4399;

import cn.m4399.operate.OperateCenter;
import cn.m4399.operate.OperateCenterConfig;
import cn.m4399.operate.OperateCenter.OnLoginFinishedListener;
import cn.m4399.operate.OperateCenterConfig.PopLogoStyle;
import cn.m4399.operate.OperateCenterConfig.PopWinPosition;
import cn.m4399.operate.User;

import com.mb.common.BaseCenterManager;

import android.content.pm.ActivityInfo;
import android.util.Log;

public class CenterManager extends BaseCenterManager  {
	
	private User _userInfo;
	
	private OperateCenter mOpeCenter;
	private boolean hasLogin = false;
	
	@Override
	public void initCenter() {
		mOpeCenter = OperateCenter.getInstance();
		
		OperateCenterConfig opeConfig = new OperateCenterConfig.Builder(MainActivity.Current)
			.setDebugEnabled(false)
			.setOrientation(ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE)
			.setPopLogoStyle(PopLogoStyle.POPLOGOSTYLE_ONE)
			.setPopWinPosition(PopWinPosition.POS_LEFT)
			.setSupportExcess(true)
			.setGameKey(_appKey)
			.build();
		
		hasLogin = false;
		final CenterManager _this = this;
		
		mOpeCenter.setConfig(opeConfig);
		MainActivity.Current.runOnUiThread(new Runnable() {
			@Override
			public void run() {
				mOpeCenter.init(MainActivity.Current, new OperateCenter.OnInitGloabListener() {
		
					@Override
					public void onInitFinished(boolean arg0, User arg1) {
						Log.d("Unity", "Init Finish");
						hasLogin = arg0;
						_userInfo = arg1;
						_this.OnInitCenter(true);
						if (arg0)
							OnLogin(true);
					}
		
					@Override
					public void onSwitchUserAccountFinished(User arg0) {
						Log.d("Unity", "Switch Account Finish");
						_userInfo = arg0;
						_this.OnSwitchAccount(true);
					}
		
					@Override
					public void onUserAccountLogout(boolean arg0, int arg1) {
						Log.d("Unity", "Logout Finish");
						_this.OnLogout(arg0);
					}
					
				});
			}
		});
		
		Log.e("Unity", "Init.......Center");
	}
	
	@Override
	public void loginCenter() {
		if (hasLogin)
			return;
		
		final CenterManager _this = this;
		MainActivity.Current.runOnUiThread(new Runnable() {
			@Override
			public void run() {
				mOpeCenter.login(MainActivity.Current, new OnLoginFinishedListener() {
					@Override
					public void onLoginFinished(boolean success, int resultCode, User userInfo) {
						Log.d("Unity", "onLoginFinish");
						_userInfo = userInfo;
						_this.OnLogin(success);
					}
				});
			}
		});
		
		Log.e("Unity", "Login.......Center");
	}
	
	@Override
	public String userInfo() {
		String str = "";
		str += _userInfo.getUid() + ",";
		str += _userInfo.getState() + ",";
		str += _userInfo.getName();
		Log.e("Unity", "Login.......Center....." + str);
		
		return str;
	}
	
}
