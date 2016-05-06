using UnityEngine;
using System.Collections;
using CC.Runtime;

public class LuaMB : MonoBehaviour 
{
	public LuaScriptMgr lua;
	void Start () 
	{
		lua = Coo.luaManager;
	}

	void Update () 
	{        
		lua.Update();
	}

	void LateUpdate()
	{
		lua.LateUpate();
	}
	
	void FixedUpdate()
	{
		lua.FixedUpdate();
	}

	void OnApplicationPause(bool isPause)
	{
		lua.OnApplicationPause(isPause);
	}
	
	void OnApplicationFocus(bool focusStatus)
	{
		lua.OnApplicationFocus(focusStatus);
	}
}
