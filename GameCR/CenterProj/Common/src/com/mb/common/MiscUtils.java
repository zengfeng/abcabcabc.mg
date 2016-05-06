package com.mb.common;

import com.unity3d.player.UnityPlayer;

import android.content.Intent;
import android.net.Uri;

public class MiscUtils {
	static public void CallUnityFunc(String functionTag, Object...args){
		String msg = functionTag + ":";
		for (int i=0; i<args.length; i++){
			msg += args[i];
			if (i != args.length - 1)
				msg += ",";
		}
		UnityPlayer.UnitySendMessage("GameManagers", "OnNativeMessage", msg);
	}
	
	static public boolean joinQQGroup(String key) {
	    Intent intent = new Intent();
	    intent.setData(Uri.parse("mqqopensdkapi://bizAgent/qm/qr?url=http%3A%2F%2Fqm.qq.com%2Fcgi-bin%2Fqm%2Fqr%3Ffrom%3Dapp%26p%3Dandroid%26k%3D" + key));
	    
		try {
			CommonActivity.Currrent.startActivity(intent);
			return true;
		} catch (Exception e) {
			return false;
		}
	}
}
