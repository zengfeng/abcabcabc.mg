package com.mbsgcr.mi;

import com.mb.common.*;
import com.xiaomi.gamecenter.sdk.MiErrorCode;
import com.xiaomi.gamecenter.sdk.OnLoginProcessListener;
import com.xiaomi.gamecenter.sdk.entry.MiAccountInfo;

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
