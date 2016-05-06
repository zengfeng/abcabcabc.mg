package com.mbgame.sdk.m4399;

import com.mb.common.*;

import android.os.Bundle;

public class MainActivity extends CommonActivity {
	static public MainActivity Current = null;
	
	@Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        
        Current = this;
        
        BaseCenterManager.Instance = new CenterManager();
    }
}
