package com.mb.common;

import com.unity3d.player.UnityPlayerActivity;

import android.os.Bundle;

public class CommonActivity extends UnityPlayerActivity {
	static public CommonActivity Currrent = null;
	
	@Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        
        Currrent = this;
    }
}
